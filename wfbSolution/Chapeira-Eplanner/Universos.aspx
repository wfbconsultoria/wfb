<%@ Page Title="Universos" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Universos.aspx.vb" Inherits="Chapeira_Eplanner.Universos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <h4 class="text-secondary text-uppercase"><%:Page.Title %></h4>
    <%-- Localizar/ Incluir--%>

    <div class="input-group">
        <input id="filter" type="text" maxlength="128" class="form-control" placeholder="Localizar" />
        <div class="input-group-append">
            <span class="input-group-text text-primary"><a href="Universo.aspx?IdUniverso=NOVO">Novo</a></span>
            <span class="input-group-text text-primary"><a href="Default.aspx">Início</a></span>
        </div>
    </div>
    <br />

    <%-- Lista de Universos--%>
    <table class="table demo table-bordered table-hover " data-filter="#filter" data-paging="true" data-filter-text-only="true" data-page-size="50">
        <thead class="navbar-default">
            <tr>
                <th>Universo</th>
                <th>Andar</th>
                <th>Zona</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="dtrUniversos" runat="server" DataSourceID="dtsUniversos">
                <ItemTemplate>
                    <tr>
                        <td style="font-size: large; width: 90%"><a href='<%# "Universo.aspx?IdUniverso" + "=" + DataBinder.Eval(Container.DataItem, "ID").ToString  %>'><%# DataBinder.Eval(Container.DataItem, "Universo").ToString%></a></td>
                        <td style="text-align: center; font-size: large; width: 5%"><%#DataBinder.Eval(Container.DataItem, "Andar").ToString %></td>
                        <td style="text-align: center; font-size: large; width: 5%"><%#DataBinder.Eval(Container.DataItem, "Zona").ToString %></td>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="12">
                    <div class="pagination pagination-centered"></div>
                </td>
            </tr>
        </tfoot>
    </table>
    <asp:SqlDataSource ID="dtsUniversos" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server"></asp:Content>