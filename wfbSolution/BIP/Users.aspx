<%@ Page Title="Usuários" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Users.aspx.vb" Inherits="BIP.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <section class="container g-py-10">
        <!--Table -->
        <div class="card g-brd-primary rounded-0">
            <h3 class="card-header g-bg-primary g-brd-transparent g-color-white g-font-size-16 rounded-0 g-mb-10">
                <i class="icon-user g-mr-5"></i>
                Usuários
            </h3>

            <%-- Localizar --%>
            <div class="col-md-5">
                <div class="input-group g-brd-primary--focus">
                    <div class="input-group-prepend">
                        <span class="input-group-text rounded-0 g-bg-white g-color-gray-light-v1"><i class="icon-magnifier"></i></span>
                    </div>
                    <input id="txt_Search" onkeyup="searchTable()" type="text" placeholder="Localizar por nome" class="form-control form-control-md border-left-0 rounded-0 pl-0">
                </div>
            </div>

            <table id="tb_Main" class="table g-mb-10" style="width: 100%; table-layout:fixed">
                <thead>
                    <tr>
                        <th style="width: 50%" onclick="sortTable(0)"><a href="#">Status</a></th>
                        <th style="width: 50%" onclick="sortTable(1)"><a href="#">Nome</a></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="dtr_Table" runat="server" DataSourceID="dts_Table">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <div class="LimitaCelula"><a href='<%# "User?UserEmail" + "=" + DataBinder.Eval(Container.DataItem, "Email").ToString  %>'><%# DataBinder.Eval(Container.DataItem, "Name").ToString%></a></div>
                                </td>
                                <td>
                                    <div class="LimitaCelula">FuhrmanBBBBBBBBBBBBBBBBBBBBBBBBBBBBBgrgrrBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBggBBBBBBBBBBgrgB</div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </section>
    <!--Datasources -->
    <asp:SqlDataSource ID="dts_Table" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>'></asp:SqlDataSource>
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
                td = tr[i].getElementsByTagName("td")[0];
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
