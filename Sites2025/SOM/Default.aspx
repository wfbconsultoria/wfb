﻿<%@ Page Title="" Language="VB" MasterPageFile="~/Shared/Master.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">

    <%--Titulo da Pagina--%>
    <h4 class="text-secondary text-uppercase" style="padding-top: 5px"><%:Page.Title %></h4>

     <%--Corpo da Pagina--%>
    <div class="row g-3">

        <div class="alert alert-primary" role="alert">
            <h4 class="text-primary">ICU MEDICAL</h4>
            <h5>Definir Relatórios/DashBoard</h5>
            <br />
            <h5 class="text-primary">WFB Consultoria</h5>
            <h6 class="text-muted"><%:Now() %></h6>
        </div>

    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
</asp:Content>

