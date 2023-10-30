<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Estabelecimentos_CNES.aspx.vb" Inherits="Estabelecimentos_CNES" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Pesquisa CNES</title>
    <script src="JScript.js" type="text/javascript"></script>
    <link href="App_Themes/MasterTheme/Master.css" rel="stylesheet" type="text/css" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="frmHospitais" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Pesquisa CNES</div>
    <div id ="Titulo_Pagina_Links">
         <td style="text-align: right"><asp:HyperLink ID="lnk_Estabelecimentos_Incluir" runat="server"  NavigateUrl="~/Estabelecimentos_Incluir.aspx" ToolTip="Cadastrar novo estabelecimento no sistema">Incluir sem pesquisar</asp:HyperLink>&nbsp;</td>
    </div>
</div>    
<br />
<div id ="Corpo">
    <br />
        <b>Procurar Por</b>
        <br />
        <asp:DropDownList ID="cmb_Tabela" runat="server">
            <asp:ListItem Value="TBL_CADGER_PESQUISA_J_HOSPITAL" Selected="True">Hospitais</asp:ListItem>
            <asp:ListItem Value="TBL_CADGER_PESQUISA_J_PRONTO_SOCORRO">Prontos Socorros</asp:ListItem>
            <asp:ListItem Value="TBL_CADGER_PESQUISA_J_SECRETARIA_SAUDE">Secretarias de Saude</asp:ListItem>
            <asp:ListItem Value="TBL_CADGER_PESQUISA_J_COOPERATIVA">Cooperativas</asp:ListItem>
            <asp:ListItem Value="TBL_CADGER_PESQUISA_J_CLINICA">Clínicas</asp:ListItem>
            <asp:ListItem Value="TBL_CADGER_PESQUISA_J_CONSULTORIO">Consultórios</asp:ListItem>
            <asp:ListItem Value="TBL_CADGER_PESQUISA_J_OUTROS">Outros</asp:ListItem>
            <asp:ListItem Value="TBL_CAGDER_PESQUISA_J">Todas Pessoas Jurídicas (demorado)</asp:ListItem>
        </asp:DropDownList>
        <br />
        <b>Que contenham</b>
        <br />
        <asp:TextBox ID="txt_Parametro" runat="server" style="text-align: left; " Width="25%" MaxLength="200" CssClass="style5"></asp:TextBox>&nbsp;
        <asp:RequiredFieldValidator ID="rfv_Parametro" runat="server" ControlToValidate="txt_Parametro" ErrorMessage="DIGITE O PARÂMETRO"></asp:RequiredFieldValidator>
        <br />
        <b>Na coluna</b>
        <br />
        <asp:DropDownList ID="cmb_Filtro" runat="server">
            <asp:ListItem Selected="True">CNPJ</asp:ListItem>
            <asp:ListItem Value="CNES">CNES</asp:ListItem>
            <asp:ListItem Value="ESTABELECIMENTO">Nome Fantasia</asp:ListItem>
            <asp:ListItem Value="RAZAO_SOCIAL">Razão Social</asp:ListItem>
            <asp:ListItem Value="MUNICIPIO_IBGE">Município</asp:ListItem>
            <asp:ListItem Value="UF">UF</asp:ListItem>
        </asp:DropDownList>
        <br />
        <b>Classificando por</b>
        <br />
        <asp:DropDownList ID="cmb_Ordem" runat="server">
            <asp:ListItem>CNPJ</asp:ListItem>
            <asp:ListItem Value="ESTABELECIMENTO" Selected="True">Nome Fantasia</asp:ListItem>
            <asp:ListItem Value="CNPJ/RAZAO_SOCIAL">Razão Social</asp:ListItem>
        </asp:DropDownList>
        <br /> <br />
    <asp:Button ID="cmd_Pesquisar" runat="server" Text="Pesquisar" CssClass="buton_gravar" />
    <br /> <br />
        <asp:GridView ID="gdv_Localizar" runat="server" AutoGenerateColumns="False" DataKeyNames="CNES" 
            DataSourceID="dts_CADGER" 
            GridLines="None" Width="100%" CaptionAlign="Left">
            <Columns>
                <asp:ButtonField Text="Incluir" CommandName="INCLUIR" ButtonType="Button" />
                <asp:BoundField DataField="CNES" HeaderText="CNES" ReadOnly="True" 
                    SortExpression="CNES" >
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="ESTABELECIMENTO" HeaderText="Estabelecimento" 
                    SortExpression="ESTABELECIMENTO" >
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="RAZAO_SOCIAL" HeaderText="CNPJ/Razão Social" 
                    SortExpression="RAZAO_SOCIAL" >
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="ESFERA_ADMINISTRATIVA_01" HeaderText="Gestão" 
                    SortExpression="ESFERA_ADMINISTRATIVA_01" >
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="LT_UTI" HeaderText="UTI" 
                    SortExpression="LT_UTI" >
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="SL_CIR_HOSPITALAR" HeaderText="SL CIR" 
                    SortExpression="SL_CIR_HOSPITALAR" >
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="EXCLUIDO" HeaderText="Excluido" 
                    SortExpression="EXCLUIDO" >
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="PERFIL_CNES" HeaderText="Perfil" 
                    SortExpression="PERFIL_CNES">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
            </Columns>
            <HeaderStyle 
                HorizontalAlign="Left" VerticalAlign="Middle" />
        </asp:GridView>
</div>
     <asp:SqlDataSource ID="dts_CADGER" runat="server" ConnectionString="<%$ ConnectionStrings:cnnCNES %>" SelectCommand="SELECT * FROM [TBL_CADGER_PESQUISA_VAZIA]"></asp:SqlDataSource>
</form>
</body>
</html>