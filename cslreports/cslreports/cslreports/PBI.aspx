<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PBI.aspx.vb" Inherits="cslreports.PBI" %>

<%@ Register Src="~/Scripts_Header.ascx" TagPrefix="uc1" TagName="Scripts_Header" %>
<%@ Register Src="~/Scripts_Footer.ascx" TagPrefix="uc1" TagName="Scripts_Footer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Report</title>
</head>

<body class="container">
    <uc1:Scripts_Header runat="server" ID="Scripts_Header" />
    <form id="form1" runat="server">
        <div class="row col-md-12 text-muted">
            <a class="btn btn-sm btn-outline-info"href="Default.aspx">Meus Relatórios</a>
        </div>
        <div class="row col-md-12 text-muted">
            <div class="row">
                <div style="margin-left: 3%;">
                    <iframe runat="server" id="frmPower" style="height: 100vh;" src="https://app.powerbi.com/view?r=" frameborder="0" allowfullscreen="true" width="100%"></iframe>
                </div>
            </div>
        </div>
    </form>
    <uc1:Scripts_Footer runat="server" ID="Scripts_Footer" />
</body>

</html>
