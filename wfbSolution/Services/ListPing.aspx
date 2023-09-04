<%@ Page Title="Ping para servidores" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListPing.aspx.cs" Inherits="ListPing" %>

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
                <h3>Ping para servidores</h3>
                <span class="text-muted">Configure os servidores que irão entrar na rotina de verificação</span>
            </div>
        </div>

        <!-- Incluir usuário -->
        <div class="row mt-4 pl-2">
          <div class="col-md-12">
              <small><a href="registerPing.aspx?session=<%: Request.Params["session"].ToString()%>" title="Cadastrar ping para servidor"><i class="fas fa-plus-circle fa-1x"></i> Adicionar servidor</a></small>
          </div>          
        </div>

        <!-- Tabela -->
        <table class="table table-striped table-bordered responsive dataTables-WFB" style="word-wrap: break-word;">
            <thead>
                <tr>
                    <th>Nome</th>
                    <th>Ip</th>
                    <th>Descrição</th>
                    <th>Ativo</th>
                </tr>
            </thead>
            <tbody>
                <%
                    clsMaster m = new clsMaster();
                    string sql = "SELECT Id, Nome, Ip, Descricao, Ativo FROM tb_ping";
                    MySql.Data.MySqlClient.MySqlDataReader dtr = m.ExecuteSelect(sql);
                    while (dtr.Read())
                    {
                %>
                <tr>
                    <td><a href="AlterPing.aspx?session=<%:Request.Params["session"].ToString() %>&id=<%: dtr["Id"].ToString() %>" title="Clique aqui para editar as configurações"><%:dtr["Nome"].ToString()%></a></td>
                    <td><%:dtr["Ip"].ToString()%></td>
                    <td><%:dtr["Descricao"].ToString()%></td>
                    <td><% if(dtr["Ativo"].ToString() == "True"){ Response.Write("Sim"); }else{ Response.Write("Não"); }%></td>
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

