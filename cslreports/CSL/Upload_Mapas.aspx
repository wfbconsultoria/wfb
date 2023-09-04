<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Upload_Mapas.aspx.vb" Inherits="Upload_Mapas" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Upload de Mapas</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/MasterTheme/Master.css" />
    <style type="text/css">
        .auto-style1 {
            font-size: small;
        }
    </style>
    </head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Upload de Mapas</div>
    <div id ="Titulo_Pagina_Links"></div>
</div>    
<div id ="Corpo">
    
    <strong>
    <asp:Label ID="lbl_Caminho_Completo" runat="server" Visible="False"></asp:Label>
    </strong>
    
    <br />
    <br />
    Selecione o tipo de Mapa que está sendo enviado e a referência de data para determinar o local onde o mapa será armazenado.<br />
    <span class="auto-style1">Obs: Os mapas com referência <strong>Mensal</strong> serão armazenados na pasta do mês anterior, e com referência <strong>Parcial (Semanal)</strong> serão armazenados no mês atual!<br />
    </span>
    <br />
    Tipo de Mapa: <asp:DropDownList ID="cmb_Tipo_Mapa" runat="server" AutoPostBack="True">
        <asp:ListItem Value="0"># Selecione</asp:ListItem>
        <asp:ListItem>Demanda</asp:ListItem>
        <asp:ListItem>Estoque</asp:ListItem>
        <asp:ListItem>Vendas</asp:ListItem>
        <asp:ListItem>Cotas Venda</asp:ListItem>
        <asp:ListItem>Cotas Demanda</asp:ListItem>
    </asp:DropDownList>
    <br />
    Referência de data:
    <asp:DropDownList ID="cmb_referencia_data" runat="server" AutoPostBack="True">
        <asp:ListItem Value="0"># Selecione</asp:ListItem>
        <asp:ListItem Value="1">Parcial (Semanal)</asp:ListItem>
        <asp:ListItem Value="2">Mensal</asp:ListItem>
    </asp:DropDownList>
    <br />
    Pasta de armazenamento:<strong>
    <asp:Label ID="lbl_Caminho" runat="server"></asp:Label>
    </strong>
    <br />
    <span class="auto-style1">Obs: Só é aceito arquivos de no máximo 20MB!</span><br />
    
    <asp:FileUpload ID="fup_Mapas" runat="server" class="multi" />
    <br />
    Escreva alguma observação sobre o arquivo:<br />
    <asp:TextBox ID="txt_OBSERVACAO" runat="server" Rows="3" TextMode="MultiLine" Width="30%"></asp:TextBox>
    <br/>
    <asp:Button ID="btn_Upload_Enviar" runat="server" Text="Enviar" CssClass="buton_gravar" />
    
</div>
</form>
</body>
</html>
