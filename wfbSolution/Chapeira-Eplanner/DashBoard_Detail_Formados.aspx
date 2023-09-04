<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DashBoard_Detail_Formados.aspx.vb" Inherits="Chapeira_Eplanner.DashBoard_Detail_Formados" %>

<%@ Register Src="~/_Header_Scripts.ascx" TagPrefix="uc1" TagName="_Header_Scripts" %>
<%@ Register Src="~/_Footer_Scripts.ascx" TagPrefix="uc1" TagName="_Footer_Scripts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <%--<link href="Content/bootstrap.min.css" rel="stylesheet" />--%>
    <title>Brigadistas Formados</title>
</head>
<body>
    <form id="frm_Mensagem" runat="server">
        <uc1:_Header_Scripts runat="server" ID="_Header_Scripts" />
        <div class="container-fluid">
            <div class="input-group input-group-sm mb-3">
                <div class="input-group-prepend">
                    <span class="input-group-text"><i class="far fa-envelope"></i></span>
                </div>
                <input type="email" class="form-control" id="Mailto" runat="server" />

                <div class="input-group-append">
                    <span class="input-group-text">
                        <asp:LinkButton ID="Enviar" runat="server">Enviar</asp:LinkButton></span>
                </div>
                <div class="input-group-append">
                    <span class="input-group-text"><a href="DashBoard.aspx">Voltar</a></span>
                </div>
            </div>
            <h4 class="text-secondary text-uppercase"><%:ConfigurationManager.AppSettings("App.Name")%></h4>
            <h4 class="text-primary text-uppercase"><%:ConfigurationManager.AppSettings("Loja")%></h4>
            <h5 class="text-primary text-uppercase"><%:Page.Title%></h5>
            <p class="text-muted"><%:Now() %></p>

            <%-- Relatório--%>
            <table class="table table-bordered table-responsive" style="width: 100%">
                <thead class="navbar-default">
                    <tr style="border-bottom: solid">
                        <td style="width: 5%; text-align: left; font-weight: bold; color: black"><strong>Andar</strong></td>
                        <td style="width: 5%; text-align: left; font-weight: bold; color: black"><strong>Zona</strong></td>
                        <td style="width: 20%; text-align: left; font-weight: bold; color: black"><strong>Status</strong></td>
                        <td style="width: 40%; font-weight: bold; color: black"><strong>Nome</strong></td>
                        <td style="width: 15%; text-align: left; font-weight: bold; color: black"><strong>Formação</strong></td>
                        <td style="width: 15%; text-align: left; font-weight: bold; color: black"><strong>Admissão</strong></td>
                    </tr>
                </thead>
                <asp:Repeater ID="dtrColaboradores" runat="server" DataSourceID="dtsColaboradores">
                    <ItemTemplate>
                        <tr>
                            <td style="width: 5%; text-align: left; font-weight: lighter; color: black"><%# DataBinder.Eval(Container.DataItem, "Id_Andar").ToString%></td>
                            <td style="width: 5%; text-align: left; font-weight: lighter; color: black"><%# DataBinder.Eval(Container.DataItem, "Id_Zona").ToString%></td>
                            <td style="width: 20%; text-align: left; font-weight: bold; color: black" class="<%#FormataTipo(DataBinder.Eval(Container.DataItem, "Brigadista_Desc")) %>"><%# DataBinder.Eval(Container.DataItem, "Brigadista_Desc").ToString%></td>
                            <td style="width: 40%; text-align: left; font-weight: lighter; color: black"><%# DataBinder.Eval(Container.DataItem, "Nome").ToString%></td>
                            <td style="width: 15%; text-align: left; font-weight: lighter; color: black"><%# DataBinder.Eval(Container.DataItem, "Formacao_Data").ToString%></td>
                            <td style="width: 15%; text-align: left; font-weight: lighter; color: black"><%# DataBinder.Eval(Container.DataItem, "Admissao_Data").ToString%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <h5>Emitido em <%:Now() %> - Chapeira_Eplanner <%:ConfigurationManager.AppSettings("Loja") %></h5>
            <br />
            <br />
        </div>
        <asp:SqlDataSource ID="dtsColaboradores" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
        <uc1:_Footer_Scripts runat="server" ID="_Footer_Scripts" />
    </form>
</body>
</html>
