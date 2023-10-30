<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Estabelecimentos_Pesquisa_Geral.aspx.vb" Inherits="Estabelecimentos_Pesquisa_Geral" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Pesquisa Geral</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Pesquisa Geral</div>
    <div id ="Titulo_Pagina_Links">
        &nbsp;</td> 
    </div>
</div>
<br />
<div id ="Corpo">
    <br />
    <form id="frmHospitais" runat="server">
                    <b>Que contenham</b><br />
                    <asp:TextBox ID="txt_Parametro" runat="server" style="text-align: left; " Width="25%" MaxLength="200" CssClass="style5"></asp:TextBox>&nbsp;
                        <asp:RequiredFieldValidator ID="rfv_Parametro" runat="server" ControlToValidate="txt_Parametro" ErrorMessage="DIGITE O PARÂMETRO"></asp:RequiredFieldValidator>
                    <br />
                    <b>Coluna</b><br />
                    <asp:DropDownList 
                        ID="cmb_Filtro" runat="server">
                        <asp:ListItem Value="ESTABELECIMENTO" Selected="True">Estabelecimento</asp:ListItem>
                        <asp:ListItem Value="RF_ESTABELECIMENTO">Estabelecimento RF</asp:ListItem>
                        <asp:ListItem>CNPJ</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <strong>Estado</strong><br /> 
                    <asp:DropDownList ID="cmb_UF" runat="server" DataSourceID="dts_ESTADOS" DataTextField="UF" DataValueField="UF">
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:Button ID="cmd_PESQUISAR" runat="server" CssClass="buton_gravar" Text="Pesquisar" />
                    <br />
        <asp:GridView ID="gdv_Localizar" runat="server" AutoGenerateColumns="False" 
            DataSourceID="dts_ESTABELECIMENTOS" Width="100%" CaptionAlign="Left">
            <Columns>
                <asp:BoundField DataField="CNPJ" HeaderText="CNPJ" 
                    SortExpression="CNPJ" >
                </asp:BoundField>
                <asp:BoundField DataField="CNES" HeaderText="CNES" 
                    SortExpression="CNES" >
                </asp:BoundField>
                <asp:BoundField DataField="ESTABELECIMENTO" HeaderText="Estabelecimento" 
                    SortExpression="ESTABELECIMENTO" ReadOnly="True" >
                </asp:BoundField>
                <asp:BoundField DataField="MUNICIPIO" HeaderText="Municipio" 
                    SortExpression="MUNICIPIO" ReadOnly="True" >
                </asp:BoundField>
                <asp:BoundField DataField="UF" HeaderText="UF" SortExpression="UF" />
            </Columns>
            <HeaderStyle 
                HorizontalAlign="Left" VerticalAlign="Middle" />
        </asp:GridView>
                    <asp:SqlDataSource ID="dts_ESTABELECIMENTOS" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS]"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="dts_ESTADOS" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT [UF] FROM [TBL_MUNICIPIOS_ESTADOS]"></asp:SqlDataSource>
</form>
</div>
     </body>
</html>