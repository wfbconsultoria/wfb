<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Page_Header.ascx.vb" Inherits="EPlanner.Page_Header" %>

<!-- Verifica se usuari esta logado -->
<%--<%If Session("EMAIL_LOGIN") = "" Then Response.Redirect("Login.aspx") %>--%>

<!-- Titulo das páginas -->
<!-- start page title -->
<div class="row">
    <div class="col-12">
        <div class="page-title-box">
            <h4 class="page-title"><%:Page.Title %></h4>
        </div>
    </div>
</div>
<!-- end page title -->
