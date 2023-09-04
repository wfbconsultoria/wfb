<%@ Page Title="Brigadistas Formados" Language="VB" MasterPageFile="~/Master_Empty.master" AutoEventWireup="false" CodeFile="DashBoard_Detail_Formados.aspx.vb" Inherits="lojas_WFB_DashBoard_Detail_Formados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">

    <br />
    <h5 class="text-primary text-uppercase"><a href="DashBoard.aspx"><%:Page.Title %></a></h5>
    <h4 class="text-secondary">
        <asp:Literal ID="ltrTitulo" runat="server"></asp:Literal>
        - <%:Now()%></h4>
    <%-- Relatório--%>
    <table>
        <tr style="border-bottom: solid; border-bottom-color: darkgray">
            <th style="width: 5%; text-align: left; font-weight: bold; color: black">Andar</th>
            <th style="width: 5%; text-align: left; font-weight: bold; color: black">Zona</th>
            <th style="width: 20%; text-align: left; font-weight: bold; color: black">Status</th>
            <th style="width: 40%; font-weight: bold; color: black">Nome</th>
            <th style="width: 15%; text-align: left; font-weight: bold; color: black">Formação</th>
            <th style="width: 15%; text-align: left; font-weight: bold; color: black">Admissão</th>
        </tr>

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
        <tr style="border-top: solid">
            <td colspan="5">Emitido em <%:Now() %></td>
        </tr>
    </table>
    <br />
    <asp:SqlDataSource ID="dtsColaboradores" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
</asp:Content>
