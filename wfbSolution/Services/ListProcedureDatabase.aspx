<%@ Page Title="Procedimentos de Banco de dados" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListProcedureDatabase.aspx.cs" Inherits="ListProcedureDatabase" %>

<%--Referencias com css--%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head_Content" runat="Server">
    <!-- data tables -->
    <link href="css/Custom/dataTables/datatables.min.css" rel="stylesheet" />
    <link href="css/Custom/dataTables/responsive-dataTables.min.css" rel="stylesheet" />
</asp:Content>

<%--Conteudo da página--%>
<asp:Content ID="Content2" ContentPlaceHolderID="Body_Content" runat="Server">
    <div class="container">
        <!-- Titulo -->
        <div class="row pt-2 text-center">
            <div class="col-md-12">
                <h3><%: Page.Title %></h3>
                <span class="text-muted">Configure os procedimentos para serem executados de forma mais fácil</span>
            </div>
        </div>

        <!-- Incluir backup -->
        <div class="row mt-4 pl-2">
            <div class="col-md-12">
                <small><a href="RegisterProcedureDatabase.aspx?session=<%: Request.Params["session"].ToString()%>" title="Cadastrar procedimento"><i class="fas fa-plus-circle fa-1x"></i> Cadastrar procedimento</a></small>
            </div>
        </div>

        <!-- Tabela -->
        <table class="table table-striped table-bordered responsive dataTables-WFB" style="word-wrap: break-word;">
            <thead>
                <tr>
                    <th>Nome</th>
                    <th>Banco</th>
                    <th>Responsavel</th>
                    <th>Ativo</th>
                </tr>
            </thead>
            <tbody>
                <%
                    clsMaster m = new clsMaster();
                    string sql = "SELECT Id,Nome, Banco, Email_Responsavel, Tipo, Ativo FROM vw_procedure_banco";
                    MySql.Data.MySqlClient.MySqlDataReader dtr = m.ExecuteSelect(sql);
                    while (dtr.Read())
                    {
                %>
                <tr>
                    <td><a href="AlterBackupDatabase.aspx?session=<%:Request.Params["session"].ToString() %>&id=<%: dtr["Id"].ToString() %>" title="Clique aqui para editar as configurações"><%:dtr["Nome"].ToString()%></a></td>
                    <td><%:dtr["Tipo"].ToString()%></td>
                    <td><%:dtr["Email_Responsavel"].ToString()%></td>
                    <td><% if (dtr["Ativo"].ToString() == "True") { Response.Write("Sim"); } else { Response.Write("Não"); }%></td>
                </tr>
                <%
                    }
                    dtr.Close();
                %>
            </tbody>
        </table>
    </div>
</asp:Content>

<%--Referencias com js--%>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer_Content" runat="Server">
    <!-- data tables -->
    <script src="js/Custom/dataTables/DataTables.min.js"></script>
    <script src="js/Custom/dataTables/dataTables.bootstrap4.min.js"></script>
    <script src="js/Custom/dataTables/dataTables-responsive.min.js"></script>

    <!-- Script para habilitar a tabela -->
    <script type="text/javascript">
        $(document).ready(function () {
            $('.dataTables-WFB').DataTable({
                "autoWidth": false,
                pageLength: 25,
                responsive: true,
                dom: '<"row"<"col-md-12"B>><"row"<"col-md-4"l><"col-md-4"><"col-md-4"f>><"row"<"col-md-12"t>><"row"<"col-md-12 w-100"p>>',
                buttons: [
                ]
            });

        });
    </script>
</asp:Content>

