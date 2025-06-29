<%@ Page Title="Dash Contatos" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="PBI.aspx.vb" Inherits="PBI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" Runat="Server">
     <%--Titulo da Pagina--%>
    <h4 class="text-secondary text-uppercase" style="padding-top: 5px"><%:Page.Title %></h4>

    <div class="row g-3">
    <iframe title="ICU_Datamaster_2024" width="1024" height="640" src="https://app.powerbi.com/view?r=eyJrIjoiZThhNWM5M2EtZmQ0OC00MjYyLWIxYmItODQ5ZWFjOWJkNWEzIiwidCI6Ijc2YjM2MTMwLTMzZjUtNGY2MC05NWVmLTg0MzlmOTQ4NmNmZiJ9" frameborder="0" allowFullScreen="true"></iframe>
</div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" Runat="Server">
</asp:Content>

