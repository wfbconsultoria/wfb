<%@ Page Title="Mobis" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Mobis.aspx.vb" Inherits="Chapeira.Mobis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <h4 class="text-secondary text-uppercase"><%:Page.Title %></h4>
    <%-- Localizar/ Incluir--%>

    <div class="input-group">
        <input id="filter" type="text" maxlength="128" class="form-control" placeholder="Localizar" />
        <div class="input-group-append">
            <span class="input-group-text text-primary"><a href="Colaborador.aspx?IdColaborador=NOVO">Novo</a></span>
            <span class="input-group-text text-primary"><a href="Default.aspx">Início</a></span>
        </div>
    </div>
    <br />

    <%-- Lista de Colaboradores--%>
    <table class="table demo table-bordered table-hover " data-filter="#filter" data-paging="true" data-filter-text-only="true" data-page-size="50">
        <thead class="navbar-default">
            <tr>
               <%-- <th data-toggle="true"></th>--%>
                <th data-toggle="true">Ativo</th>
                <th data-toggle="true">Status</th>
                <th data-toggle="true">CheckIn</th>
                <th data-toggle="true">Modelo</th>
                <th data-hide="phone">Telefone</th>
                <th data-hide="phone">Colaborador</th>
                <th data-hide="phone">Universo</th>
                <th data-hide="phone">Status</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="dtrMobis" runat="server" DataSourceID="dtsMobis">
                <ItemTemplate>
                    <tr>
                        <%--<td class="text-center"></td>--%>
                        <td class="<%# FormataAtivo(DataBinder.Eval(Container.DataItem, "Ativo"))%>"><%# DataBinder.Eval(Container.DataItem, "Ativo").ToString%></td>
                        <td class="text-center"><img src="<%# FormataIcone(DataBinder.Eval(Container.DataItem, "Status"))%>" /></td>
                        <td><%# LCase(DataBinder.Eval(Container.DataItem, "CheckIn_Date").ToString)%></td>
                        <td><%# LCase(DataBinder.Eval(Container.DataItem, "Modelo").ToString)%></td>
                        <td><%# LCase(DataBinder.Eval(Container.DataItem, "Telefone").ToString)%></td>
                        <td><%# LCase(DataBinder.Eval(Container.DataItem, "Colaborador").ToString)%></td>
                        <td><%# LCase(DataBinder.Eval(Container.DataItem, "Universo").ToString)%></td>
                        <td><%# LCase(DataBinder.Eval(Container.DataItem, "Colaborador_Status").ToString)%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="11">
                    <div class="pagination pagination-centered"></div>
                </td>
            </tr>
        </tfoot>
    </table>
    <asp:SqlDataSource ID="dtsMobis" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
