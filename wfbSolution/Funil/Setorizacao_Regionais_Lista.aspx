<%@ Page Title="Regionais" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Setorizacao_Regionais_Lista.aspx.vb" Inherits="Setorizacao_Regionais_Lista" %>

<%@ Register Src="~/Titulo_Pagina.ascx" TagPrefix="uc1" TagName="Titulo_Pagina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">

    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />

    <%--CORPO DA PAGINA--%>
    <uc1:Titulo_Pagina runat="server" ID="Titulo_Pagina" />

    <%--BOTOES--%>
    <div>
        <a href="Setorizacao_Regionais_Incluir.aspx?Id=NOVO" class="btn btn-primary">Nova Regional</a>
    </div>
    <%--TABELA--%>
    <div>
        <table id="table"
            class="table table-bordered table-hover"
            data-toggle="table"
            data-search="true"
            data-search-align="left"
            data-search-accent-neutralise="true"
            data-search-highlight="true"
            <%--data-show-search-clear-button="true"--%>
            data-show-toggle="true"
            data-show-columns="true"
            <%--data-show-columns-toggle-all="true"--%>
            <%--data-show-fullscreen="true"--%>
            <%--data-show-pagination-switch="true"--%>
            data-sortable="true"
            <%--data-pagination="true"--%>
            data-mobile-responsive="true">
            <thead>
                <tr>
                    <th data-field="ID_REGIONAL" data-sortable="true" style="width: 10%">Regional</th>
                    <th data-field="REGIONAL" data-sortable="true" style="width: 40%">Regional</th>
                    <th data-field="GERENTE" data-sortable="true" style="width: 40%">Responsável</th>
                    <th data-field="STATUS_REGIONAL" data-sortable="true" style="width: 10%">Status</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="dtr" runat="server" DataSourceID="dts">
                    <ItemTemplate>
                        <tr>
                            <td><a href='<%# "Setorizacao_Regionais_Incluir.aspx?Id" + "=" + DataBinder.Eval(Container.DataItem, "ID").ToString %>'><%# DataBinder.Eval(Container.DataItem, "ID_REGIONAL").ToString%></a></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "REGIONAL").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "GERENTE").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "STATUS_REGIONAL").ToString%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>

    <%--CORPO DA PAGINA--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
</asp:Content>