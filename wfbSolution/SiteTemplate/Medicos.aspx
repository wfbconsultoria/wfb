<%@ Page Title="Meus Médicos" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Medicos.aspx.vb" Inherits="Medicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />

    <%--Titulo da Pagina--%>
    <h4 class="text-secondary text-uppercase" style="padding-top: 5px"><%:Page.Title %></h4>

    <div>
        <div id="toolbar">
            <a href="Medico_Incluir.aspx" class="btn btn-primary">Novo Medico</a>
        </div>
        <table class="table table-bordered table-hover"
            id="table"
            data-toolbar="#toolbar"
            data-toggle="table"
            data-search="true"
            data-search-align="right"
            data-search-accent-neutralise="true"
            data-search-highlight="true"
            data-sortable="true"
            data-pagination="true"
            data-pagination-v-align="both"
            data-show-columns="true"
            data-show-columns-toggle-all="true"
            data-show-pagination-switch="true"
            data-show-toggle="true"
            data-show-multi-sort="true"
            data-show-fullscreen="true"
            data-buttons="buttons"
            data-mobile-responsive="true"
            data-check-on-init="true"
            data-filter-control="true"
            data-show-search-clear-button="true">

            <thead>
                <tr>
                    <th data-field="CRM" data-sortable="true" style="width: 10%">CRM</th>
                    <th data-field="NOME" data-sortable="true" style="width: 60%">Medico</th>
                    <th data-field="ESPECIALIDADE" data-sortable="true" style="width: 30%">Especialidade</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="dtr" runat="server" DataSourceID="dts">
                    <ItemTemplate>
                        <tr>
                            <td><a href='<%# "Medico.aspx?idMedico" + "=" + DataBinder.Eval(Container.DataItem, "ID").ToString %>'><%# DataBinder.Eval(Container.DataItem, "CRM_UF").ToString%></a></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "NOME").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "ESPECIALIDADE").ToString%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
</asp:Content>

