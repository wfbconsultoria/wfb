<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Estabelecimento_Incluir_PF_RF.aspx.vb" Inherits="Estabelecimento_Incluir_PF_RF" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Pesquisa na Receita Federal</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/MasterTheme/Master.css" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Pesquisa na Receita Federal</div>
    <div id ="Titulo_Pagina_Links">
        <a href="Estabelecimentos_Incluir_RF.aspx">Incluir Cliente</a>
    </div>
</div>    
<div id ="Corpo">
    <br />
    <br />
    <strong>1 - Verifique se é o Cliente correto, depois clique em Gravar.</strong>
    <br />
    <strong>2 - Caso não seja o correto, clique em Cancelar e você irá retornar para a tela de pesquisa.</strong>
    <br />
    <br />
        <strong>
            <asp:Label ID="lbl_Documento" runat="server" Text="CPF" Width="200px"></asp:Label>
        </strong>
        <br />
            <asp:Label ID="txt_Documento" runat="server" Width="200px"></asp:Label>
        <br />
        <strong>
            <asp:Label ID="lbl_Nome" runat="server" Text="Nome" Width="200px"></asp:Label>
        </strong>
            <asp:Label ID="txt_Nome" runat="server" Width="100%"></asp:Label>
        <br />
        <strong>
            <asp:Label ID="lbl_Logradouro" runat="server" Text="Logradouro" Width="250px"></asp:Label>
            <asp:Label ID="lbl_Numero" runat="server" Text="Numero" Width="110px"></asp:Label>
            <asp:Label ID="lbl_CEP" runat="server" Text="CEP" Width="200px"></asp:Label>
        </strong>
        <br />
            <asp:Label ID="txt_Logradouro" runat="server" Width="250px"></asp:Label>
            <asp:TextBox ID="txt_Numero" runat="server" Width="100px"></asp:TextBox>
            <asp:TextBox ID="txt_CEP" runat="server"></asp:TextBox>
            <asp:Button ID="cmd_Pesquisar" CssClass="buton_gravar" runat="server" Text="Pesquisar CEP" />
        <br />
        <strong>
            <asp:Label ID="lbl_Complemento" runat="server" Text="Complemento" Width="200px"></asp:Label>
        </strong>
        <br />
            <asp:TextBox ID="txt_Complemento" runat="server" Width="300px"></asp:TextBox>
        <br />
        <strong>
            <asp:Label ID="lbl_Bairro" runat="server" Text="Bairro" Width="200px"></asp:Label>&nbsp;
            <asp:Label ID="lbl_Cidade" runat="server" Text="Cidade" Width="200px"></asp:Label>&nbsp;
            <asp:Label ID="lbl_Estado" runat="server" Text="Estado" Width="200px"></asp:Label>
        </strong>
        <br />
            <asp:Label ID="txt_Bairro" runat="server" Width="200px"></asp:Label>&nbsp;
            <asp:Label ID="txt_Cidade" runat="server" Width="200px"></asp:Label>&nbsp;
            <asp:Label ID="txt_Estado" runat="server" Width="200px"></asp:Label>   
        <br />
        <strong>
            <asp:Label ID="lbl_Esfera" runat="server" Text="Esfera Administrativa" Width="260px"></asp:Label>
        </strong> 
            <br />
        <asp:Label ID="txt_Esfera" runat="server" Width="100%"></asp:Label>
        <br /><br />
        <br />
        <strong>
        2 - O cliente entrará no sistema sem setorização.<br />
    Entre na página de setorização de órfãos para setorizar este cliente,<br />
    caso não tenha acesso à essa pagina, peça para um administrador de setorização fazer a setorização do cliente.</strong>
        <br />
        <asp:DropDownList ID="cmb_USUARIOS" runat="server" DataSourceID="dts_USUARIOS" DataTextField="NOME" DataValueField="EMAIL" Enabled="False"></asp:DropDownList>
        &nbsp;&nbsp;
        Target:
        <asp:DropDownList ID="cmb_TARGET" runat="server" Enabled="False">
            <asp:ListItem Value="0">NÃO</asp:ListItem>
            <asp:ListItem Value="1">SIM</asp:ListItem>
        </asp:DropDownList>        
        <br />     
    <br /><br/>
    
    <asp:Button ID="cmd_Gravar" CssClass="buton_gravar" runat="server" Text="Gravar" />
    <asp:Button ID="cmd_Cancelar" CssClass="buton_gravar" runat="server" Text="Cancelar" />
    
    </div>
    </form>
    <asp:SqlDataSource ID="dts_USUARIOS" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT [EMAIL], [NOME] FROM [TBL_USUARIOS] ORDER BY [NOME]">
    </asp:SqlDataSource>
</body>
</html>