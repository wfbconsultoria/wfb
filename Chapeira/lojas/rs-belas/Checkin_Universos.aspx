<%@ Page Title="Check In/Out (Universos)" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Checkin_Universos.aspx.vb" Inherits="lojas_WFB_Checkin_Universos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <h4 class="text-secondary text-uppercase"><%:Page.Title %></h4>

    <div class="row">
        <%-- Universos--%>
        <div class="col-sm-12"><a class="btn btn-lg btn-primary btn-block bt" style="font-size: xx-large; word-wrap: hyphenate" href="CheckIn_List.aspx?IdUniverso=TODOS">Todos colaboradores</a></div>

        <asp:Repeater ID="dtrUniversos" runat="server" DataSourceID="dtsUniversos">
            <ItemTemplate>
                <div class="col-sm-6" style="padding-top: 10px; padding-bottom: 10px">
                    <a class="btn btn-lg btn-outline-primary btn-block bt" style="font-size: xx-large; word-wrap: hyphenate" href='<%# "CheckIn_List.aspx?IdUniverso" + "=" + DataBinder.Eval(Container.DataItem, "ID").ToString  %>'><%# DataBinder.Eval(Container.DataItem, "Universo").ToString%></a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="col-sm-12"><a class="btn btn-lg btn-link btn-light btn-block bt" style="font-size: xx-large; word-wrap: hyphenate" href="Default.aspx">Voltar</a></div>
    </div>

    <asp:SqlDataSource ID="dtsUniversos" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>