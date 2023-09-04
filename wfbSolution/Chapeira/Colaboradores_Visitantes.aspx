<%@ Page Title="Visitantes" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Colaboradores_Visitantes.aspx.vb" Inherits="Chapeira.Colaboradores_Visitantes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <h4 class="text-secondary text-uppercase"><%:Page.Title %></h4>
    <%-- Localizar/ Incluir--%>

    <div class="input-group">
        <input id="filter" type="text" maxlength="128" class="form-control" placeholder="Localizar" />
        <div class="input-group-append">
            <span class="input-group-text text-primary"><a href="Colaborador_Visitante.aspx?IdColaborador=NOVO">Novo</a></span>
            <span class="input-group-text text-primary"><a href="Default.aspx">Início</a></span>
        </div>
    </div>
    <br />

    <%-- Lista de Colaboradores--%>
    <table class="table demo table-bordered table-hover " data-filter="#filter" data-paging="true" data-filter-text-only="true" data-page-size="50">
        <thead class="navbar-default">
            <tr>
                <th data-toggle="true"></th>
                <th data-toggle="true">Ativo</th>
                <th data-toggle="true">Nome</th>
                <th data-toggle="phone">Data Visita</th>
                <th data-hide="all">Colaborador Visitado</th>
                <th data-hide="all">Empresa</th>
                <th data-hide="all">Email</th>
                <th data-hide="all">Telefone</th>
                 <th data-hide="all">Motivo Visita</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="dtrColaboradores" runat="server" DataSourceID="dtsColaboradores">
                <ItemTemplate>
                    <tr>
                        <td class="text-center"></td>
                        <td class="<%# FormataAtivo(DataBinder.Eval(Container.DataItem, "Ativo"))%>"><%# DataBinder.Eval(Container.DataItem, "Ativo").ToString%></td>
                        <td><a href='<%# "Colaborador_Visitante.aspx?IdColaborador" + "=" + DataBinder.Eval(Container.DataItem, "ID").ToString  %>'><%# DataBinder.Eval(Container.DataItem, "Nome").ToString%></a></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Admissao_Data").ToString%></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Funcao").ToString%></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Empresa").ToString%></td>
                        <td><%# LCase(DataBinder.Eval(Container.DataItem, "Email").ToString)%></td>
                        <td><%# LCase(DataBinder.Eval(Container.DataItem, "Telefone").ToString)%></td>
                         <td><%# LCase(DataBinder.Eval(Container.DataItem, "Observacao").ToString)%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="5">
                    <div class="pagination pagination-centered"></div>
                </td>
            </tr>
        </tfoot>
    </table>
    <asp:SqlDataSource ID="dtsColaboradores" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
