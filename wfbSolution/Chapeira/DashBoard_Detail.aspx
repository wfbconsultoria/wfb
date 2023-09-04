<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DashBoard_Detail.aspx.vb" Inherits="Chapeira.DashBoard_Detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="frm_Mensagem" runat="server">
        <div class="container">
            <br />
            <h5 class="text-primary text-uppercase"><a href="DashBoard.aspx">DECATHLON -  <%:ConfigurationManager.AppSettings("Loja") %></a></h5>
            <h4 class="text-secondary"><%:Page.Title%> - <%:Now() %></h4>
            <%-- Relatório--%>
            <table>
                <tr style="border-bottom: solid">
                    <th data-toggle="true" style="width: 30%; text-align: left; font-weight: bold; color: black">Nome</th>
                    <th data-toggle="true" style="width: 18%; text-align: left; font-weight: bold; color: black">Universo</th>
                    <th data-toggle="true" style="width: 5%; text-align: center; font-weight: bold; color: black">Zona</th>
                    <th data-toggle="true" style="width: 5%; text-align: center; font-weight: bold; color: black">Andar</th>
                    <th data-hide="all" style="width: 12%; text-align: left; font-weight: bold; color: black">Tipo</th>
                    <th data-hide="all" style="width: 12%; text-align: left; font-weight: bold; color: black">Status</th>
                    <th data-hide="all" style="width: 18%; text-align: left; font-weight: bold; color: black">Check In/Out</th>
                </tr>
                <asp:Repeater ID="dtrColaboradores" runat="server" DataSourceID="dtsColaboradores">
                    <ItemTemplate>
                        <tr>
                            <td style="width: 30%; text-align: left; font-weight: lighter; color: black"><%# DataBinder.Eval(Container.DataItem, "Nome").ToString%></td>
                            <td style="width: 18%; text-align: left; font-weight: lighter; color: black"><%# DataBinder.Eval(Container.DataItem, "Universo").ToString%></td>
                            <td style="width: 5%; text-align: center; font-weight: lighter; color: black"><%# DataBinder.Eval(Container.DataItem, "Id_Zona").ToString%></td>
                            <td style="width: 5%; text-align: center; font-weight: lighter; color: black"><%# DataBinder.Eval(Container.DataItem, "Id_Andar").ToString%></td>
                            <td style="width: 12%; text-align: left; font-weight: lighter; color: black"><%# DataBinder.Eval(Container.DataItem, "Brigadista_Desc")%></td>
                            <td style="width: 12%; text-align: left; font-weight: lighter; color: black"><%# DataBinder.Eval(Container.DataItem, "Status")%></td>
                            <td style="width: 18%; text-align: left; font-weight: lighter; color: black"><%# LCase(DataBinder.Eval(Container.DataItem, "CheckIn_Date_Abb").ToString)%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr style="border-top: solid">
                    <td colspan="7">Emitido em <%:Now() %> - Chapeira <%:ConfigurationManager.AppSettings("Loja") %></td>
                </tr>
            </table>
            <br />
            <br />
            <div class="row"></div>
            Compartilhar com:
            <input class="form-control" id="Mailto" runat="server" type="email" style="width: 40%" /><asp:LinkButton ID="Enviar" runat="server" CssClass="btn btn-outline-primary"> Enviar </asp:LinkButton>&nbsp<a class="btn btn-link" href="DashBoard.aspx"> Voltar </a>
        </div>
        <br />
        <br />
        <asp:SqlDataSource ID="dtsColaboradores" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
    </form>
</body>
</html>
