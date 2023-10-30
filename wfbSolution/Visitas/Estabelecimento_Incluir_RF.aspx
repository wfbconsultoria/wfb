<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Estabelecimento_Incluir_RF.aspx.vb" Inherits="Estabelecimento_Incluir_RF" %>

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
    <div id ="Titulo_Pagina_Cabecalho">Inclusão de cliente (PJ)</div>
    <div id ="Titulo_Pagina_Links">
        <asp:HyperLink ID="lnk_Estabelecimentos_Pesquisa_RF" runat="server" NavigateUrl="~/Estabelecimentos_Pesquisa_RF.aspx">Nova pesquisa</asp:HyperLink>
    </div>
</div>    
<div id ="Corpo">
    <br /> <br />
    <strong>1 - Verifique se é o cliente correto </strong>
    <br />
    <strong>
        <asp:Label ID="lbl_Documento" runat="server" Text="CNPJ" ></asp:Label>&nbsp
        <asp:Label ID="txt_Documento" runat="server" Width="200px"></asp:Label>
    </strong>
        <br />
        <strong>
        <asp:Label ID="lbl_Razao_Social" runat="server" Text="Razão Social" Width="200px"></asp:Label>
        </strong>
        <asp:Label ID="txt_Razao_Social" runat="server" Width="100%"></asp:Label>
        <br />
        <strong>
        <asp:Label ID="lbl_Nome_Fantasia" runat="server" Text="Nome Fantasia" Width="200px"></asp:Label>
        </strong>
       <asp:Label ID="txt_Nome_Fantasia" runat="server" Width="100%"></asp:Label>
        <br />
        <strong>
        <asp:Label ID="lbl_Logradouro" runat="server" Text="Logradouro" Width="200px"></asp:Label>
        <asp:Label ID="lbl_Numero" runat="server" Text="Numero" Width="200px"></asp:Label>
            <asp:Label ID="Label1" runat="server" Text="CEP" Width="200px"></asp:Label>
        </strong>
        <br />
        <asp:Label ID="txt_Logradouro" runat="server" Width="200px"></asp:Label>
        <asp:Label ID="txt_Numero" runat="server" Width="200px"></asp:Label>
        <asp:Label ID="txt_CEP" runat="server" Width="200px"></asp:Label>
        <br />
        <strong>
        <asp:Label ID="lbl_Complemento" runat="server" Text="Complemento" Width="200px"></asp:Label>
        </strong>
        <br />
        <asp:Label ID="txt_Complemento" runat="server" Width="200px"></asp:Label>
        <br />
        <strong>
        <asp:Label ID="lbl_Bairro" runat="server" Text="Bairro" Width="200px"></asp:Label>
        <asp:Label ID="lbl_Cidade" runat="server" Text="Cidade" Width="200px"></asp:Label>
        <asp:Label ID="lbl_Estado" runat="server" Text="Estado" Width="200px"></asp:Label>
        </strong>
        <br />
        <asp:Label ID="txt_Bairro" runat="server" Width="200px"></asp:Label>
        <asp:Label ID="txt_Cidade" runat="server" Width="200px"></asp:Label>
        <asp:Label ID="txt_Estado" runat="server" Width="200px"></asp:Label>    
        <br/>
        <strong>
        <asp:Label ID="lbl_Esfera_Administrativa" runat="server" Text="Esfera Administrativa" Width="200px"></asp:Label>
        </strong>
        <br />
        &nbsp;<asp:Label ID="txt_Esfera_Administrativa" runat="server" Width="200px"></asp:Label>
        <br />
        <br />
    <strong>
        2 - Caso queira incluir em algum painel de visitação, selecione o representante abaixo
    </strong>
    <br />
    <asp:DropDownList ID="cmb_USUARIOS" runat="server" DataSourceID="dts_USUARIOS" DataTextField="NOME" DataValueField="EMAIL"></asp:DropDownList>
    &nbsp;&nbsp;
    Target:
        <asp:DropDownList ID="cmb_TARGET" runat="server">
            <asp:ListItem Value="NÃO">NÃO</asp:ListItem>
            <asp:ListItem Value="SIM">SIM</asp:ListItem>
        </asp:DropDownList>
    <br /><br />
    <asp:Button ID="cmd_Gravar" CssClass="buton_gravar" runat="server" Text="Gravar" />
    <asp:Button ID="cmd_Cancelar" CssClass="buton_gravar" runat="server" Text="Cancelar" />
    <br />
    
    </div>
        <asp:SqlDataSource ID="dts_USUARIOS" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            SelectCommand="SELECT [EMAIL], [NOME] FROM [TBL_USUARIOS] ORDER BY [NOME]">
        </asp:SqlDataSource>   
    </form>
</body>
</html>
