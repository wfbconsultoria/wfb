<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DashBoard_Detail_Servicos.aspx.vb" Inherits="Chapeira_Eplanner.DashBoard_Detail_Servicos" %>

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
                <tr style="border-bottom: solid; border-bottom-color:darkgray">
                    <th data-toggle="true" style="width: 5%; text-align: center; font-weight: bold; color: black">Andar</th>
                    <th data-toggle="true" style="width: 5%; text-align: center; font-weight: bold; color: black">Zona</th>
                    <th data-toggle="true" style="width: 15%; text-align: left; font-weight: bold; color: black">Universo</th>
                    <th data-toggle="true" style="width: 15%; text-align: left; font-weight: bold; color: black">Tipo</th>
                    <th data-toggle="true" style="width: 30%; text-align: left; font-weight: bold; color: black">Nome</th>
                    <th data-toggle="true" style="width: 12%; text-align: left; font-weight: bold; color: black">Status</th>
                    <th data-hide="all" style="width: 18%; text-align: left; font-weight: bold; color: black">Chek In</th>
                </tr>
                <asp:Repeater ID="dtrColaboradores" runat="server" DataSourceID="dtsColaboradores">
                    <ItemTemplate>
                        <tr>
                            <td style="width: 5%; text-align: center; font-weight: lighter; color: black"><%# DataBinder.Eval(Container.DataItem, "Id_Andar").ToString%></td>
                            <td style="width: 5%; text-align: center; font-weight: lighter; color: black"><%# DataBinder.Eval(Container.DataItem, "Id_Zona").ToString%></td>
                            <td style="width: 15%; text-align: left; font-weight: lighter; color: black"><%# DataBinder.Eval(Container.DataItem, "Universo").ToString%></td>
                            <td style="width: 15%; text-align: left; font-weight: bold; color: black" class="<%#FormataTipo(DataBinder.Eval(Container.DataItem, "Brigadista_Desc").ToString) %>"><%# DataBinder.Eval(Container.DataItem, "Brigadista_Desc").ToString%></td>
                            <td style="width: 30%; text-align: left; font-weight: lighter; color: black"><%# DataBinder.Eval(Container.DataItem, "Nome").ToString%></td>
                            <td style="width: 12%; text-align: left; font-weight:bold; color: black" class="<%# FormataStatus(DataBinder.Eval(Container.DataItem, "Status"))%>"><%# DataBinder.Eval(Container.DataItem, "Status")%></td>
                            <td style="width: 18%; text-align: left; font-weight: lighter; color: black"><%# DataBinder.Eval(Container.DataItem, "CheckIn_Date_Abb")%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr style="border-top: solid">
                    <td colspan="7">Emitido em <%:Now() %> - Chapeira_Eplanner <%:ConfigurationManager.AppSettings("Loja") %></td>
                </tr>
            </table>
            <br />
            Compartilhar com:
            <input id="Mailto" runat="server" type="email" style="width: 40%" /><asp:LinkButton ID="Enviar" runat="server"> Enviar </asp:LinkButton><a href="DashBoard.aspx"> Voltar </a>
        </div>

        <asp:SqlDataSource ID="dtsColaboradores" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
    </form>
</body>
</html>