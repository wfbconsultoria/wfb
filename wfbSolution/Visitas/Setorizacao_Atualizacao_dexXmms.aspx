<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Setorizacao_Atualizacao_dexXmms.aspx.vb" Inherits="Setorizacao_Atualizacao_dexXmms" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%ConfigurationManager.AppSettings("SIGLA").ToString()%> &nbsp;Atualização Setorizacao de KA Dex x MMS</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Atualização Setorizacao de KA Dex x MMS</div>
    <div id ="Titulo_Pagina_Links"></div>
</div>
<br />  
<div id ="Corpo">
     <br /> 
    <asp:Button ID="cmd_Atualizar" runat="server" Text="Atualizar" />
    <br />  
    <br />
    
    <asp:Table ID="tbl_Report" runat="server" BorderStyle="None" BorderWidth="0px" BorderColor="White"
            CaptionAlign="Left" Font-Names="Calibri" Font-Size="Small" 
            GridLines="Both" HorizontalAlign="Left" 
            style="text-align: center" Width="50%">
   </asp:Table>
</div>
</form>
</body>

</html>
