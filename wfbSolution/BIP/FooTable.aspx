<%@ Page Title="Tabela" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="FooTable.aspx.vb" Inherits="BIP.FooTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <section class="container g-py-10">
        <!--Table -->
        <div class="card g-brd-primary rounded-0">
            <h3 class="card-header g-bg-primary g-brd-transparent g-color-white g-font-size-16 rounded-0 mb-0">
                <i class="fa fa-tasks g-mr-5"></i>
                Basic Table
            </h3>

            <div class="card-block g-pa-15">
                <%-- Localizar --%>
                <div class="form-group col-sm-6">
                    <input id="txt_Search" type="text" maxlength="128" class="form-control" onkeyup="searchTable()" placeholder="Localizar" />
                </div>
            </div>
                <table id="tb_Main" class="table" style="width: 100%; table-layout:fixed">
                    <thead>
                        <tr>
                            <th style="width:5%" onclick="sortTable(0)"><a href="#">ID</a></th>
                            <th style="width:30%" onclick="sortTable(1)"><a href="#">Name</a></th>
                            <th style="width:25%" onclick="sortTable(2)"><a href="#">Last Name</a></th>
                            <th style="width:10%" onclick="sortTable(3)"><a href="#">Job</a></th>
                            <th style="width:10%" onclick="sortTable(4)"><a href="#">Start</a></th>
                            <th style="width:10%" onclick="sortTable(5)"><a href="#">Date</a></th>
                            <th style="width:10%" onclick="sortTable(6)"><a href="#">Info</a></th>
                        </tr>
                    </thead>
                    <tbody  style="height:300px;overflow-y:scroll"
   width: 100%;>
                        <tr>
                            <td><div class="LimitaCelula">1</div></td>
                            <td><div class="LimitaCelula">DenniseBBBBBBBBggrrrBBBBBBBBBBBBBBBgrgrrBBBBBBBBBBBBBBBBBBBBBBBBBBBgrgrrgrrrrBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB</div></td>
                            <td><div class="LimitaCelula">FuhrmanBBBBBBBBBBBBBBBBBBBBBBBBBBBBBgrgrrBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBggBBBBBBBBBBgrgB</div></td>
                            <td><div class="LimitaCelula">miro</div></td>
                            <td><div class="LimitaCelula">November 8th 2011</div></td>
                            <td><div class="LimitaCelula">July 25th 1960</div></td>
                            <td><div class="LimitaCelula"><a href="#placeholder">Info link</a></div></td>
                        </tr>
                         <tr>
                            <td><div class="LimitaCelula">2</div></td>
                            <td><div class="LimitaCelula">aaaaaaBBBBBBBBggrrrBBBBBBBBBBBBBBBgrgrrBBBBBBBBBBBBBBBBBBBBBBBBBBBgrgrrgrrrrBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB</div></td>
                            <td><div class="LimitaCelula">FuhrmanBBBBBBBBBBBBBBBBBBBBBBBBBBBBBgrgrrBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBggBBBBBBBBBBgrgB</div></td>
                            <td><div class="LimitaCelula">pedro</div></td>
                            <td><div class="LimitaCelula">November 8th 2011</div></td>
                            <td><div class="LimitaCelula">July 25th 1960</div></td>
                            <td><div class="LimitaCelula"><a href="#placeholder">Info link</a></div></td>
                        </tr>
                         <tr>
                            <td><div class="LimitaCelula">3</div></td>
                            <td><div class="LimitaCelula">BBBBBBBBggrrrBBBBBBBBBBBBBBBgrgrrBBBBBBBBBBBBBBBBBBBBBBBBBBBgrgrrgrrrrBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB</div></td>
                            <td><div class="LimitaCelula">FuhrmanBBBBBBBBBBBBBBBBBBBBBBBBBBBBBgrgrrBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBggBBBBBBBBBBgrgB</div></td>
                            <td><div class="LimitaCelula">maria</div></td>
                            <td><div class="LimitaCelula">November 8th 2011</div></td>
                            <td><div class="LimitaCelula">July 25th 1960</div></td>
                            <td><div class="LimitaCelula"><a href="#placeholder">Info link</a></div></td>
                        </tr>
                         <tr>
                            <td><div class="LimitaCelula">4</div></td>
                            <td><div class="LimitaCelula">ccccBBBBBBBBggrrrBBBBBBBBBBBBBBBgrgrrBBBBBBBBBBBBBBBBBBBBBBBBBBBgrgrrgrrrrBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB</div></td>
                            <td><div class="LimitaCelula">FuhrmanBBBBBBBBBBBBBBBBBBBBBBBBBBBBBgrgrrBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBggBBBBBBBBBBgrgB</div></td>
                            <td><div class="LimitaCelula">High School History Teacher</div></td>
                            <td><div class="LimitaCelula">November 8th 2011</div></td>
                            <td><div class="LimitaCelula">July 25th 1960</div></td>
                            <td><div class="LimitaCelula"><a href="#placeholder">Info link</a></div></td>
                        </tr>
                         <tr>
                            <td><div class="LimitaCelula">11</div></td>
                            <td><div class="LimitaCelula">ddddBBBBBBBBggrrrBBBBBBBBBBBBBBBgrgrrBBBBBBBBBBBBBBBBBBBBBBBBBBBgrgrrgrrrrBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB</div></td>
                            <td><div class="LimitaCelula">vvvvvBBBBBBBBBBBBBBBBBBBBBBBBBBBBBgrgrrBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBggBBBBBBBBBBgrgB</div></td>
                            <td><div class="LimitaCelula">High School History Teacher</div></td>
                            <td><div class="LimitaCelula">November 8th 2011</div></td>
                            <td><div class="LimitaCelula">July 25th 1960</div></td>
                            <td><div class="LimitaCelula"><a href="#placeholder">Info link</a></div></td>
                        </tr>
                         <tr>
                            <td><div class="LimitaCelula">11</div></td>
                            <td><div class="LimitaCelula">DenniseBBBBBBBBggrrrBBBBBBBBBBBBBBBgrgrrBBBBBBBBBBBBBBBBBBBBBBBBBBBgrgrrgrrrrBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB</div></td>
                            <td><div class="LimitaCelula">FuhrmanBBBBBBBBBBBBBBBBBBBBBBBBBBBBBgrgrrBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBggBBBBBBBBBBgrgB</div></td>
                            <td><div class="LimitaCelula">High School History Teacher</div></td>
                            <td><div class="LimitaCelula">November 8th 2011</div></td>
                            <td><div class="LimitaCelula">July 25th 1960</div></td>
                            <td><div class="LimitaCelula"><a href="#placeholder">Info link</a></div></td>
                        </tr>
                         <tr>
                            <td><div class="LimitaCelula">11</div></td>
                            <td><div class="LimitaCelula">DenniseBBBBBBBBggrrrBBBBBBBBBBBBBBBgrgrrBBBBBBBBBBBBBBBBBBBBBBBBBBBgrgrrgrrrrBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB</div></td>
                            <td><div class="LimitaCelula">FuhrmanBBBBBBBBBBBBBBBBBBBBBBBBBBBBBgrgrrBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBggBBBBBBBBBBgrgB</div></td>
                            <td><div class="LimitaCelula">High School History Teacher</div></td>
                            <td><div class="LimitaCelula">November 8th 2011</div></td>
                            <td><div class="LimitaCelula">July 25th 1960</div></td>
                            <td><div class="LimitaCelula"><a href="#placeholder">Info link</a></div></td>
                        </tr>
                         <tr>
                            <td><div class="LimitaCelula">11</div></td>
                            <td><div class="LimitaCelula">DenniseBBBBBBBBggrrrBBBBBBBBBBBBBBBgrgrrBBBBBBBBBBBBBBBBBBBBBBBBBBBgrgrrgrrrrBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB</div></td>
                            <td><div class="LimitaCelula">FuhrmanBBBBBBBBBBBBBBBBBBBBBBBBBBBBBgrgrrBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBggBBBBBBBBBBgrgB</div></td>
                            <td><div class="LimitaCelula">High School History Teacher</div></td>
                            <td><div class="LimitaCelula">November 8th 2011</div></td>
                            <td><div class="LimitaCelula">July 25th 1960</div></td>
                            <td><div class="LimitaCelula"><a href="#placeholder">Info link</a></div></td>
                        </tr>
                         <tr>
                            <td><div class="LimitaCelula">11</div></td>
                            <td><div class="LimitaCelula">DenniseBBBBBBBBggrrrBBBBBBBBBBBBBBBgrgrrBBBBBBBBBBBBBBBBBBBBBBBBBBBgrgrrgrrrrBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB</div></td>
                            <td><div class="LimitaCelula">FuhrmanBBBBBBBBBBBBBBBBBBBBBBBBBBBBBgrgrrBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBggBBBBBBBBBBgrgB</div></td>
                            <td><div class="LimitaCelula">High School History Teacher</div></td>
                            <td><div class="LimitaCelula">November 8th 2011</div></td>
                            <td><div class="LimitaCelula">July 25th 1960</div></td>
                            <td><div class="LimitaCelula"><a href="#placeholder">Info link</a></div></td>
                        </tr>
                         <tr>
                            <td><div class="LimitaCelula">11</div></td>
                            <td><div class="LimitaCelula">DenniseBBBBBBBBggrrrBBBBBBBBBBBBBBBgrgrrBBBBBBBBBBBBBBBBBBBBBBBBBBBgrgrrgrrrrBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB</div></td>
                            <td><div class="LimitaCelula">FuhrmanBBBBBBBBBBBBBBBBBBBBBBBBBBBBBgrgrrBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBggBBBBBBBBBBgrgB</div></td>
                            <td><div class="LimitaCelula">High School History Teacher</div></td>
                            <td><div class="LimitaCelula">November 8th 2011</div></td>
                            <td><div class="LimitaCelula">July 25th 1960</div></td>
                            <td><div class="LimitaCelula"><a href="#placeholder">Info link</a></div></td>
                        </tr>
                         <tr>
                            <td><div class="LimitaCelula">11</div></td>
                            <td><div class="LimitaCelula">DenniseBBBBBBBBggrrrBBBBBBBBBBBBBBBgrgrrBBBBBBBBBBBBBBBBBBBBBBBBBBBgrgrrgrrrrBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB</div></td>
                            <td><div class="LimitaCelula">FuhrmanBBBBBBBBBBBBBBBBBBBBBBBBBBBBBgrgrrBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBggBBBBBBBBBBgrgB</div></td>
                            <td><div class="LimitaCelula">High School History Teacher</div></td>
                            <td><div class="LimitaCelula">November 8th 2011</div></td>
                            <td><div class="LimitaCelula">July 25th 1960</div></td>
                            <td><div class="LimitaCelula"><a href="#placeholder">Info link</a></div></td>
                        </tr>
                         <tr>
                            <td><div class="LimitaCelula">11</div></td>
                            <td><div class="LimitaCelula">DenniseBBBBBBBBggrrrBBBBBBBBBBBBBBBgrgrrBBBBBBBBBBBBBBBBBBBBBBBBBBBgrgrrgrrrrBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB</div></td>
                            <td><div class="LimitaCelula">FuhrmanBBBBBBBBBBBBBBBBBBBBBBBBBBBBBgrgrrBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBggBBBBBBBBBBgrgB</div></td>
                            <td><div class="LimitaCelula">High School History Teacher</div></td>
                            <td><div class="LimitaCelula">November 8th 2011</div></td>
                            <td><div class="LimitaCelula">July 25th 1960</div></td>
                            <td><div class="LimitaCelula"><a href="#placeholder">Info link</a></div></td>
                        </tr>
                    </tbody>
                </table>

           
        </div>
    </section>
   
    <script>
        function searchTable() {
            // Declare variables
            var input, filter, table, tr, td, i, txtValue;
            input = document.getElementById("txt_Search");
            filter = input.value.toUpperCase();
            table = document.getElementById("tb_Main");
            tr = table.getElementsByTagName("tr");

            // Loop through all table rows, and hide those who don't match the search query
            for (i = 0; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td")[1];
                if (td) {
                    txtValue = td.textContent || td.innerText;
                    if (txtValue.toUpperCase().indexOf(filter) > -1) {
                        tr[i].style.display = "";
                    } else {
                        tr[i].style.display = "none";
                    }
                }
            }
        }
    </script>

    <script>
        function sortTable(n) {
            var table, rows, switching, i, x, y, shouldSwitch, dir, switchcount = 0;
            table = document.getElementById("tb_Main");
            switching = true;
            // Set the sorting direction to ascending:
            dir = "asc";
            /* Make a loop that will continue until
            no switching has been done: */
            while (switching) {
                // Start by saying: no switching is done:
                switching = false;
                rows = table.rows;
                /* Loop through all table rows (except the
                first, which contains table headers): */
                for (i = 1; i < (rows.length - 1); i++) {
                    // Start by saying there should be no switching:
                    shouldSwitch = false;
                    /* Get the two elements you want to compare,
                    one from current row and one from the next: */
                    x = rows[i].getElementsByTagName("TD")[n];
                    y = rows[i + 1].getElementsByTagName("TD")[n];
                    /* Check if the two rows should switch place,
                    based on the direction, asc or desc: */
                    if (dir == "asc") {
                        if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                            // If so, mark as a switch and break the loop:
                            shouldSwitch = true;
                            break;
                        }
                    } else if (dir == "desc") {
                        if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
                            // If so, mark as a switch and break the loop:
                            shouldSwitch = true;
                            break;
                        }
                    }
                }
                if (shouldSwitch) {
                    /* If a switch has been marked, make the switch
                    and mark that a switch has been done: */
                    rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
                    switching = true;
                    // Each time a switch is done, increase this count by 1:
                    switchcount++;
                } else {
                    /* If no switching has been done AND the direction is "asc",
                    set the direction to "desc" and run the while loop again. */
                    if (switchcount == 0 && dir == "asc") {
                        dir = "desc";
                        switching = true;
                    }
                }
            }
        }
    </script>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
