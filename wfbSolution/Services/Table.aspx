<%@ Page Title="Data Table" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Table.aspx.cs" Inherits="Models_Table" %>

<%--referencias com css para página--%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head_Content" runat="Server">
    <!-- data tables -->
    <link href="css/Custom/dataTables/datatables.min.css" rel="stylesheet" />
    <link href="css/Custom/dataTables/responsive-dataTables.min.css" rel="stylesheet" />
</asp:Content>

<%--conteudo da página--%>
<asp:Content ID="Content2" ContentPlaceHolderID="Body_Content" runat="Server">
    <!-- Tabela -->
    <div class="container">
        <h3>Data - Tables</h3>
        <table class="table table-striped table-bordered responsive dataTables-WFB" style="word-wrap: break-word;">
            <thead>
                <tr>
                    <th>CNPJ</th>
                    <th>RAZAO SOCIAL</th>
                    <th>NOME FANTASIA</th>
                </tr>
            </thead>
            <tbody>
                <%
                    System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection("Data Source=SRV-DEV;Initial Catalog=ESTABELECIMENTOS-DEV;Persist Security Info=True;User ID=sa;Password=@Mepm2412; MultipleActiveResultSets=True;");
                    cnn.Open();
                    string sql = "SELECT TOP(1000) CNPJ, RAZAO_SOCIAL, NOME_FANTASIA FROM TBL_ESTABELECIMENTOS";
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, cnn);
                    System.Data.SqlClient.SqlDataReader dtr = cmd.ExecuteReader();

                    while (dtr.Read())
                    {
                %>
                <tr>
                    <td><%:dtr[0].ToString()%></td>
                    <td><%:dtr[1].ToString()%></td>
                    <td><%:dtr[2].ToString()%></td>
                </tr>
                <%
                    }
                    dtr.Close();
                %>
            </tbody>
        </table>
    </div>
</asp:Content>

<%--referencias com js para pagina--%>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer_Content" runat="Server">
    <!-- data tables -->
    <script src="../js/Custom/dataTables/DataTables.min.js"></script>
    <script src="../js/Custom/dataTables/dataTables.bootstrap4.min.js"></script>
    <script src="../js/Custom/dataTables/dataTables-responsive.min.js"></script>

    <!-- Script para habilitar a tabela -->
    <script type="text/javascript">
        $(document).ready(function () {
            $('.dataTables-WFB').DataTable({
                "autoWidth": false,
                pageLength: 25,
                responsive: true,
                dom: '<"row"<"col-md-12"B>><"row"<"col-md-4"l><"col-md-4"><"col-md-4"f>><"row"<"col-md-12"t>><"row"<"col-md-12 w-100"p>>',
                buttons: [
                    { extend: 'excel', text: 'Excel', className: 'btn-sm btn-primary', title: "<%: Page.Title %>" }
                ]
            });

        });
    </script>

</asp:Content>

