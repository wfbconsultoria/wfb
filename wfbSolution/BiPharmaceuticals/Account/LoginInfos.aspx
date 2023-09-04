<%@ Page Title="Informações do Usuário" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master.Master" CodeBehind="LoginInfos.aspx.vb" Inherits="BiPharmaceuticals.LoginInfos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%--Titulo da Pagina--%>
    <h4 class="text-secondary text-uppercase" style="padding-top: 5px"><%:Page.Title %></h4>

    <table class="table demo table-bordered table-hover " data-filter="#filter" data-paging="true" data-filter-text-only="true" data-page-size="50">
        <thead class="navbar-default">
            <tr>
                <th data-toggle="true"></th>
                <th data-toggle="true">Info</th>
                <th data-toggle="true">Descrição</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td></td>
                <td></td>
            </tr>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
