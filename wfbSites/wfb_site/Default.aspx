<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/header.ascx" TagPrefix="uc1" TagName="header" %>
<%@ Register Src="~/footer.ascx" TagPrefix="uc1" TagName="footer" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <title>WFB Consultoria</title>
</head>
<body class="container">
    <form id="frmMain" runat="server">
        <uc1:header runat="server" id="header" />
        <div class="row">
            <div class="col-md-4 align-items-center">
                <img class="img-fluid" src="Images/Logo_wfb.png" />
            </div>
            <div class="col-md-8 d-flex align-items-center">
                <h3 class="text-primary">WFB Consultoria em Informática Ltda</h3>
            </div>
            <hr />
            <div class="col-md-12 d-flex align-items-center">
                <img src="Images/Organograma_WFB.png" />
            </div>

            
        </div>



        <uc1:footer runat="server" id="footer" />
    </form>
</body>
</html>
