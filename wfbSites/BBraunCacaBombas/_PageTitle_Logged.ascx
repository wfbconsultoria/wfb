<%@ Control Language="VB" AutoEventWireup="false" CodeFile="_PageTitle_Logged.ascx.vb" Inherits="_PageTitle_Logged" %>

<%--Verifica se o usuário está autuenticado--%>
<%If Context.User.Identity.IsAuthenticated = False Then Response.Redirect("Account/Login")%>

<%--Page Title--%>
<h4 class="my-0 mr-md-auto font-weight-normal" style="color:#00B482;"><%:Page.Title %></h4>
