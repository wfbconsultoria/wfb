<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/_Header_Scripts.ascx" TagPrefix="uc1" TagName="_Header_Scripts" %>
<%@ Register Src="~/_Footer_Scripts.ascx" TagPrefix="uc1" TagName="_Footer_Scripts" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%:ConfigurationManager.AppSettings("App.Name")%></title>
</head>
<body class="container">
    <uc1:_Header_Scripts runat="server" ID="_Header_Scripts" />
    <form id="form1" runat="server">
        <div>
            <div class="jumbotron">
                <h1><%:ConfigurationManager.AppSettings("App.Name")%></h1>
                <p><a href="lojas/WFB/Default.aspx">WFB</a></p>
                <p><a href="lojas/mg-bh/Default.aspx">BELO HORIZONTE</a></p>
                <p><a href="lojas/sp-cd01/Default.aspx">CENTRO DISTRIBUIÇÃO</a></p>
                <p><a href="lojas/pr-maringa/Default.aspx">MARINGÁ</a></p>
                <p><a href="lojas/rs-belas/Default.aspx">PRAIA DE BELAS</a></p>
                <p><a href="lojas/sp-paulista/Default.aspx">PAULISTA</a></p>
                <p><a href="lojas/sp-paulista/Default.aspx">MG-SUL</a></p>
            </div>
        </div>
    </form>
    <uc1:_Footer_Scripts runat="server" ID="_Footer_Scripts" />
</body>
</html>
