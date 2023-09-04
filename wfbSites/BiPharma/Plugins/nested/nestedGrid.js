//Author: Ribo Mo
(function ($) {
    "use strict";

    var GRID_WIDTH = 200;

    $.fn.nestedGrid = function (options) {
        $.fn.nestedGrid.Options = $.extend($.fn.nestedGrid.defaultOptions, options);
        this.each(function () {
            var $table = $(this);
            $(this).data("settings", options);
            setGrid($table, options);
        });
    };

    // Provide default options for plugin
    $.fn.nestedGrid.defaultOptions = {
        ajax: {
            method: "post",
            dataType: "json"
        }
    };

    // Reload grid
    $.fn.nestedGrid.reloadGrid = function ($container) {
        setGrid($container, $container.data("settings"));
    };

    // Pass in selector and this function will make it a grid!
    var setGrid = function ($table, userSettings) {
        $table.off();
        var options = $.fn.nestedGrid.Options;
        // generate from AJAX
        if (!options.data) {
            var request = $.ajax(options.ajax);
            return request.success(function (result) {
                var grid = new Grid(result.data, result.fields, result.tableName);
                $table.html(grid.$grid);
                addEventDelegation($table);
            });
        }
        else {
            var grid = new Grid(userSettings.data, userSettings.fields, userSettings.tableName);
            $table.html(grid.$grid);
            addEventDelegation($table);
        }
    };

    var addEventDelegation = function ($target) {
        $target.on("click", ".text-field", editRow);
        $target.on("click", ".save-link", editEvent().saveClickEvent);
        $target.on("click", ".delete-link", editEvent().deleteClickEvent);

        // Allow user to edit data in the row
        function editRow() {
            var removeEditing = function () {
                $(this).find(".text-field").each(function () {
                    var textBox = $(this).find("input");
                    $(this).text(textBox.val());
                    textBox.remove();
                });
                $(this).removeClass("editing");
            };

            var $row = $(this).parent();
            if (!$row.hasClass("editing")) {
                var $html = $("html");

                // If there's another row in editing status, cancel the editing state.
                // Make sure editing row is unique.
                var $grid = $row.parents(".nestedGrid").last();
                var $editingRows = $grid.find(".editing");
                if ($editingRows.length !== 0) {
                    $editingRows.each(removeEditing);
                    $html.off("click");
                }

                // Replace text with input
                $row.find(".text-field").each(function () {
                    if (($(this)).has("input").length === 0) {
                        $row.addClass("editing");
                        var text = $(this).text();
                        var $textBox = $("<input>").attr("type", "text").attr("value", text);
                        $(this).text('').append($textBox);
                    }
                });

                // When user clicked elsewhere, remove editing status.
                $html.click(function (event) {
                    if (!$(event.target).closest(".text-field").length && !$(event.target).is(".text-field")) {
                        var $that = $(".nestedGrid").find("tr");
                        removeEditing.bind($that)();
                        $("html").off("click");
                    }
                });
            }
        }

        function editEvent() {
            // Get values in fields
            var getFieldData = function () {
                var $row = $(this).closest("tr");
                var obj = {};
                var topLevelFields = showTopLevelFields($(this).closest(".nestedGrid").data("fields"));
                var i = 0;
                if ($row.hasClass("editing")) {
                    $row.find("td input").each(function () {
                        obj[topLevelFields[i]] = $(this).val();
                        i++;
                    });
                }
                else {
                    $row.find("td.data").each(function () {
                        obj[topLevelFields[i]] = $(this).text();
                        i++;
                    });
                }
                return obj;
            };

            var getOriginalData = function () {
                return $(this).closest("tr").data("data");
            };

            var getTableName = function () {
                return $(this).closest(".nestedGrid").data("table");
            };
            var options = $.fn.nestedGrid.Options;
            return {
                saveClickEvent: function (event) {
                    event.preventDefault();
                    var newData = getFieldData.bind(this)();
                    var object = {
                        purpose: "edit",
                        tableName: getTableName.bind(this)(),
                        new: newData,
                        old: getOriginalData.bind(this)()
                    };
                    //Pass data to server
                    confirmPopup(function () {
                        console.log(object.new);
                        console.log(object.old);
                        $.ajax({
                            method: "post",
                            url: options.ajax.url,
                            dataType: "json",
                            data: JSON.stringify(object),

                            success: function () {
                                //Refresh grid
                                var $topContainer = $(event.target).parents(".nestedGrid").last().parent();
                                $.fn.nestedGrid.reloadGrid($topContainer);
                            }
                        });
                    });
                },
                deleteClickEvent: function (event) {
                    event.preventDefault();
                    var object = {
                        purpose: "delete",
                        tableName: getTableName.bind(this)(),
                        old: getOriginalData.bind(this)()
                    };
                    confirmPopup(function () {
                        console.log(object.old);
                        $.ajax({
                            method: "post",
                            url: options.ajax.url,
                            dataType: "json",
                            data: JSON.stringify(object),

                            success: function () {
                                var $topContainer = $(event.target).parents(".nestedGrid").last().parent();
                                $.fn.nestedGrid.reloadGrid($topContainer);
                            }
                        });
                    });
                }
            }
        }

    };

    // Ask user to confirm their action
    function confirmPopup(yesFunction, noFunction) {
        var $popup = $("<div>").attr("id", "popup");
        var $overlay = $("<div>").attr("id", "overlay");

        var $popupContent = $("<div>").append("Are you sure you want to continue?<br>");

        var $yes = $("<a>").append("yes<br>").click(function () {
            $popup.remove();
            $overlay.remove();
            if (yesFunction) {
                yesFunction();
            }
        });

        var $no = $("<a>").append("no").click(function () {
            $popup.remove();
            $overlay.remove();
            if (noFunction) {
                noFunction();
            }
        });
        $popupContent.append($yes).append($no);
        $popup.append($popupContent);
        $("body").append($popup);
        $("body").append($overlay);

        $overlay.css({
            opacity: 0.7,
            'width': $(document).width(),
            'height': $(document).height(),
            "position": "absolute",
            "top": 0,
            "left": 0,
            "background": "#000"
        });
        $popup.css({
            "display": "block"
        });
    }

    function Grid(data, fields, tableName) {
        this.data = data;
        this.fields = fields;
        this.tableName = tableName;
        this.$grid = null;
        this.init();
    }

    Grid.prototype = {
        init: function () {
            this.$grid = $("<table>");
            this.$grid.append(this.createHeader());
            this.$grid.append(this.createBody());

            this.$grid.addClass("nestedGrid");
            this.$grid.data("table", this.tableName);
            this.$grid.data("data", this.data);
            this.$grid.data("fields", this.fields);
        },

        createHeader: function () {
            var fields = showTopLevelFields(this.fields);
            var $fieldData = [];
            $fieldData.push($("<th>"));
            for (var i = 0; i < fields.length; i++) {
                var $field = $("<th>").append(fields[i]);
                $field.width(GRID_WIDTH);
                $fieldData.push($field);
            }
            $fieldData.push($("<th>").append("action"));
            return $("<thead><tr>").append($fieldData);
        },

        createBody: function () {
            var rows = [];
            for (var i = 0; i < this.data.length; i++) {
                var row = new Row(this.data[i], this.fields, this.$grid);

                // Add Strap
                if (i % 2 == 0) {
                    row.$row.addClass("odd-row");
                } else {
                    row.$row.addClass("even-row");
                }
                rows = rows.concat(rows, row.getRow());
            }
            return $("<tbody>").append(rows);
        }
    };

    // Constructor for Row
    function Row(data, fields, $grid) {
        this.data = data;
        this.fields = fields;
        this.$grid = $grid;
        this.$row = null;
        this.topLevelFields = null;
        this.$subgrid = null;
        this.init();
    }

    Row.prototype = {
        init: function () {
            this.$row = $("<tr>");
            this.topLevelFields = showTopLevelFields(this.fields);

            var $rowData = [];
            var $subgridTrigger = this.createSubgridTrigger();
            $rowData.push($subgridTrigger);
            $rowData = $rowData.concat(this.createCells());
            $rowData.push(this.createSaveDeleteField());
            this.$row.append($rowData);

            // Add subgrid
            if (this.isSubgridExist()) {
                this.$subgrid = this.createSubgrid();
                var that = this;
                this.$row.on("click", ".subgrid-trigger", function () {
                    that.$subgrid.fadeToggle();
                    var $this = $(this);
                    if ($this.hasClass("expand")) {
                        $this.removeClass("expand");
                        $this.addClass("collapse");
                    }
                    else {
                        $this.removeClass("collapse");
                        $this.addClass("expand");
                    }
                });
            }

            this.$row.data("data", this.data);
        },

        //Return $row selector and $subgrid selector
        getRow: function () {
            var result = [];
            result.push(this.$row);
            if (this.$subgrid) {
                result.push(this.$subgrid);
            }
            return result;
        },

        // Add subgrid to existing grid
        createSubgrid: function () {
            var that = this;
            var subgridInfo = function (fields) {
                var result = {
                    fields: [],
                    table: []
                };
                for (var i = 0; i < fields.length; i++) {
                    if (fields[i].indexOf(".") !== -1) {
                        var data = fields[i].split(".");
                        result["fields"].push(data[1]);
                        if (result["table"].indexOf(data[0]) === -1) {
                            result["table"] = data[0];
                        }
                    }
                }
                return result;
            }(this.fields);

            // Get the max number of column
            var maxCol = function () {
                var maxCol = 0;
                that.$row.find('td').each(function () {
                    maxCol += 1;
                });
                return maxCol;
            }();
            var subgridData = this.data[this.getSubgridName()[0]];
            var subgrid = new Grid(subgridData, subgridInfo.fields, subgridInfo.table);
            subgrid.$grid.addClass("subgrid");
            var $insertCell = $("<td>").append(subgrid.$grid).attr("colspan", maxCol);
            var $insertRow = $("<tr>").append($insertCell).addClass("collapse");
            $insertRow.hide();
            return $insertRow;
        },

        // Return all the data contain in the fields
        createCells: function () {
            var fields = this.topLevelFields;
            var $result = [];
            for (var i = 0; i < fields.length; i++) {
                var $fieldData = $("<td>").append(this.data[fields[i]]).addClass("text-field").addClass("data");
                $result.push($fieldData);
            }
            return $result;
        },

        // Add trigger
        createSubgridTrigger: function () {
            if (this.isSubgridExist()) {
                var $expand = $("<div>").addClass("subgrid-trigger").addClass("expand").addClass("trigger-placeholder");
                return $("<td>").append($expand);
            }
            else {
                return $("<td>").append($("<div>").addClass("trigger-placeholder"));
            }
        },

        createSaveDeleteField: function () {
            var $editField = $("<td>");
            var $save = $("<a>").append("save").attr("href", "#").addClass("save-link");
            var $delete = $("<a>").append("delete").attr("href", "#").addClass("delete-link");
            $editField.append($save).append(" ").append($delete);
            return $editField;
        },

        getSubgridName: function () {
            var result = [];
            for (var i = 0; i < this.fields.length; i++) {
                if (this.fields[i].indexOf(".") !== -1) {
                    var data = this.fields[i].split(".");
                    if (result.indexOf(data[0]) === -1) {
                        result.push(data[0]);
                    }
                }
            }
            return result;
        },

        isSubgridExist: function () {
            return this.data[this.getSubgridName()[0]] !== undefined;
        }
    };

    //Only show fields that are in top level
    function showTopLevelFields(fields) {
        var result = [];
        for (var i = 0; i < fields.length; i++) {
            if (fields[i].indexOf(".") === -1) {
                result.push(fields[i]);
            }
        }
        return result;
    }
}(jQuery));