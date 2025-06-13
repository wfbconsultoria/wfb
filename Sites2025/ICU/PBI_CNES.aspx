<%@ Page Title="ICU CNES MARKET" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="PBI_CNES.aspx.vb" Inherits="PBI_CNES" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" Runat="Server">
     <%--Titulo da Pagina--%>
    <h4 class="text-secondary text-uppercase" style="padding-top: 5px"><%:Page.Title %></h4>
    <div class="row g-3">
<iframe title="ICU_ANALISE_CNES" width="1024" height="640" src="https://app.powerbi.com/view?r=eyJrIjoiMjg5MTI2ODEtMDgyZC00OTg0LWJlNzMtZDk3YjJiOTdiMWNmIiwidCI6Ijc2YjM2MTMwLTMzZjUtNGY2MC05NWVmLTg0MzlmOTQ4NmNmZiJ9" frameborder="0" allowFullScreen="true"></iframe></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" Runat="Server">
</asp:Content>

