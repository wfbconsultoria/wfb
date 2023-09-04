<%@ Page Title="Brigadistas" Language="VB" MasterPageFile="~/Master_Empty.master" AutoEventWireup="false" CodeFile="DashBoard_Detail_Brigadistas.aspx.vb" Inherits="lojas_WFB_DashBoard_Detail_Brigadistas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">

    <br />
    <h5 class="text-primary text-uppercase"><a href="DashBoard.aspx"><%:Page.Title %></a></h5>
    <h4 class="text-secondary"><asp:Literal ID="ltrTitulo" runat="server"></asp:Literal> - <%:Now()%></h4>
    <%-- Relatório--%>
    <table>
        <tr style="border-bottom: solid; border-bottom-color: darkgray">
            <th data-toggle="true" style="width: 6%; text-align: center; font-weight: bold; color: black">Andar</th>
                    <th data-toggle="true" style="width: 6%; text-align: center; font-weight: bold; color: black">Zona</th>
                    <th data-toggle="true" style="width: 18%; text-align: left; font-weight: bold; color: black">Universo</th>
                    <th data-toggle="true" style="width: 35%; text-align: left; font-weight: bold; color: black">Nome</th>
                    <th data-toggle="true" style="width: 15%; text-align: left; font-weight: bold; color: black">Status</th>
                    <th data-hide="all" style="width: 20%; text-align: left; font-weight: bold; color: black">Chek In</th>
        </tr>
        <asp:Repeater ID="dtrColaboradores" runat="server" DataSourceID="dtsColaboradores">
            <ItemTemplate>
                <tr>
                    <td style="width: 6%; text-align: center; font-weight: lighter; color: black"><%# DataBinder.Eval(Container.DataItem, "Id_Andar").ToString%></td>
                            <td style="width: 6%; text-align: center; font-weight: lighter; color: black"><%# DataBinder.Eval(Container.DataItem, "Id_Zona").ToString%></td>
                            <td style="width: 18%; text-align: left; font-weight: lighter; color: black"><%# DataBinder.Eval(Container.DataItem, "Universo").ToString%></td>
                            <td style="width: 35%; text-align: left; font-weight: lighter; color: black"><%# DataBinder.Eval(Container.DataItem, "Nome").ToString%></td>
                            <td style="width: 15%; text-align: left; font-weight: bold; color: black" class="<%# FormataStatus(DataBinder.Eval(Container.DataItem, "Status"))%>"><%# DataBinder.Eval(Container.DataItem, "Status")%></td>
                            <td style="width: 20%; text-align: left; font-weight: lighter; color: black"><%# DataBinder.Eval(Container.DataItem, "CheckIn_Date_Abb")%></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr style="border-top: solid">
            <td colspan="7">Emitido em <%:Now() %></td>
        </tr>
    </table>
    <br />
    <asp:SqlDataSource ID="dtsColaboradores" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
</asp:Content>
