<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="DoutorCRM._Default" %>

<%@ Register Src="~/App_Controls/ScriptsHeader.ascx" TagPrefix="uc1" TagName="ScriptsHeader" %>
<%@ Register Src="~/App_Controls/ScriptsFooter.ascx" TagPrefix="uc1" TagName="ScriptsFooter" %>
<%@ Register Src="~/App_Controls/PageHeader.ascx" TagPrefix="uc1" TagName="PageHeader" %>
<%@ Register Src="~/App_Controls/PageFooter.ascx" TagPrefix="uc1" TagName="PageFooter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <uc1:ScriptsHeader runat="server" ID="ScriptsHeader" />
    <title>Início</title>
</head>
<body class="container">
    <form id="form1" runat="server">
        <uc1:PageHeader runat="server" id="PageHeader" />
        
        <!-- Conteudo da pagina -->
        <div id="PageContent">


        </div>
        <!-- Conteudo da pagina -->
        <uc1:PageFooter runat="server" id="PageFooter" />
    </form>
    <uc1:ScriptsFooter runat="server" ID="ScriptsFooter" />
</body>
</html>
