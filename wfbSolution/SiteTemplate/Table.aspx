<%@ Page Title="" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Table.aspx.vb" Inherits="Table" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />

    <div>
        <table class="table table-bordered table-hover"
            id="table"
            data-toggle="table"
            data-search="true"
            data-search-align="right"
            data-search-accent-neutralise="true"
            data-search-highlight="true"
            data-sortable="true"
            data-pagination="true"
            data-show-columns="true"
            data-show-columns-toggle-all="true"
            data-show-pagination-switch="true"
            data-show-toggle="true"
            data-show-multi-sort="true"
            data-mobile-responsive="true"
            data-check-on-init="true">
            <thead>
                <tr>
                    <th data-field="CNPJ" data-sortable="true" data-toggle="true" style="width: 10%">CNPJ</th>
                    <th data-field="Estabelecimento" data-sortable="true" data-toggle="true" style="width: 50%">Cliente</th>
                    <th data-field="Cidade" data-sortable="true" data-hide="phone" style="width: 35%">Cidade</th>
                    <th data-field="UF" data-sortable="true" data-hide="phone" style="width: 5%">UF</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="dtr" runat="server" DataSourceID="dts">
                    <ItemTemplate>
                        <tr>
                            <td><a href='<%# "Establishment?Id" + "=" + DataBinder.Eval(Container.DataItem, "Id").ToString %>'><%# DataBinder.Eval(Container.DataItem, "CNPJ").ToString%></a></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "Estabelecimento").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "Cidade").ToString%></td>
                            <td><%# UCase(DataBinder.Eval(Container.DataItem, "UF").ToString)%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
    
</asp:Content>

