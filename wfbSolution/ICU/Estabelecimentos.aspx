<%@ Page Title="Estabelecimentos" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Estabelecimentos.aspx.vb" Inherits="Estabelecimentos" %>

<%@ Register Src="~/Titulo_Pagina.ascx" TagPrefix="uc1" TagName="Titulo_Pagina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <uc1:Titulo_Pagina runat="server" ID="Titulo_Pagina" />
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
                    <th data-field="CNPJ" data-sortable="true" style="width:10%">CNPJ</th>
                    <th data-field="NOME_FANTASIA" data-sortable="true"  style="width:40%">Cliente</th>
                    <th data-field="MUNICIPIO" data-sortable="true" style="width:25%">Cidade</th>
                    <th data-field="UF" data-sortable="true" style="width:5%">UF</th>
                    <th data-field="ESFERA" data-sortable="true" style="width:20%">ESFERA</th>
                    <th data-field="CLASSE_ESTABELECIMENTO" data-sortable="true" style="width:20%">CLASSE</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="dtr" runat="server" DataSourceID="dts">
                    <ItemTemplate>
                        <tr>
                            <td><a href='<%# "Estabelecimento_Editar.aspx?idEstabelecimento" + "=" + DataBinder.Eval(Container.DataItem, "Id").ToString %>'><%# DataBinder.Eval(Container.DataItem, "CNPJ").ToString%></a></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "NOME_FANTASIA").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "MUNICIPIO").ToString%></td>
                            <td><%# UCase(DataBinder.Eval(Container.DataItem, "UF").ToString)%></td>
                            <td><%# UCase(DataBinder.Eval(Container.DataItem, "ESFERA").ToString)%></td>
                            <td><%# UCase(DataBinder.Eval(Container.DataItem, "CLASSE_ESTABELECIMENTO").ToString)%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
    
</asp:Content>

