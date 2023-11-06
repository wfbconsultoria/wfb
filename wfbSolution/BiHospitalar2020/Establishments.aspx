<%@ Page Title="Meus Estabelecimentos" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master.Master" CodeBehind="Establishments.aspx.vb" Inherits="BiHospitalar2020.Establishments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    
    <%--Titulo da Pagina--%>
    <h4 class="text-secondary text-uppercase" style="padding-top: 5px"><%:Page.Title %></h4>

    <div class="form-row">
        <%-- Localizar Estabelecimento--%>
        <div class="form-group col-sm-12">
            <input id="filter" type="text" maxlength="128" class="form-control" placeholder="Localizar" />
        </div>
    </div>

    <%--Tabela - Lista de estabelecimentos--%>
    <table class="table demo table-bordered table-hover " data-filter="#filter" data-paging="true" data-filter-text-only="true" data-page-size="50">
        <thead class="navbar-default">
            <tr>
                <th data-toggle="true" style="width: 10%">CNPJ</th>
                <th data-toggle="true" style="width: 50%">Estabelecimento</th>
                <th data-hide="phone" style="width: 35%">Cidade</th>
                <th data-hide="phone" style="width: 5%">UF</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="dtr" runat="server" DataSourceID="dts">
                <ItemTemplate>
                    <tr>
                        <td><a href='<%# "Establishment?Id" + "=" + DataBinder.Eval(Container.DataItem, "Id").ToString  %>'><%# DataBinder.Eval(Container.DataItem, "CNPJ").ToString%></a></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Estabelecimento").ToString%></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Cidade").ToString%></td>
                        <td><%# UCase(DataBinder.Eval(Container.DataItem, "UF").ToString)%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="6">
                    <div class="pagination pagination-centered"></div>
                </td>
            </tr>
        </tfoot>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>