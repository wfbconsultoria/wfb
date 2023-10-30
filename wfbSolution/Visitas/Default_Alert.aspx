<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default_Alert.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <style type="text/css">
        #Corpo {
            text-align: center;
        }
    </style>
</head>
<head id="Head1" runat="server">
    <title>Início</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    <style type="text/css">
        #imgAlert {
            text-align: center;
        }
    </style>
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<br />
<div id ="Corpo"><br />
<img id="imgAlert" src="Images/comunicado2.jpg"/>   
</div>
</form>
</body>
</html>