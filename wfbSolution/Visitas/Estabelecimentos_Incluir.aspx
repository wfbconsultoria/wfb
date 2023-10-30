<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Estabelecimentos_Incluir.aspx.vb" Inherits="Estabelecimentos_Incluir" %>
<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Incluir Estabelecimento</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="frmHospitais" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Incluir Estabelecimento</div>
    <div id ="Titulo_Pagina_Links">
         <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Estabelecimentos_CNES.aspx" ToolTip="Pesquisar estabelecimento no CNES">Pesquisa CNES</asp:HyperLink>&nbsp;
    </div>
</div>    
<br />
<div id ="Corpo">                
    <ol>
       <li>Para setorizar este estabelecimento selecione o usuário&nbsp;                            
           <asp:DropDownList ID="cmb_USUARIOS" runat="server" DataSourceID="dts_USUARIOS"                               
               DataTextField="NOME" DataValueField="EMAIL">                           
           </asp:DropDownList>                      
       </li>
        <li>Selecione se o estabelecimento é Target
            <asp:DropDownList ID="cmb_TARGET" runat="server">
                <asp:ListItem Value="NÃO">Não</asp:ListItem>
                <asp:ListItem Value="SIM">Sim</asp:ListItem>
            </asp:DropDownList>
       </li>                        
       <li>Verifique se os campos em vermelho (obrigatórios) estão preenchidos e clique                     
           em                             
           <asp:Button ID="cmd_Gravar" runat="server" Text="Gravar" />                       
       </li>                   
    </ol>                
    <b>CNPJ</b>                
    <br />                
    <asp:TextBox ID="txt_CNPJ" runat="server" style="text-align: center;" Width="200px" MaxLength="18" Font-Bold="True"></asp:TextBox>                
    <br />                
    <b>CNES</b>                
    <br />                
    <asp:TextBox ID="txt_CNES" runat="server" Enabled  = "False" Width="100px" style="font-weight: 700; background-color: #C0C0C0; text-align: center;"></asp:TextBox>                
    <br />                
    <b>Estabelecimento</b>                
    <br />                
    <asp:TextBox ID="txt_NOME_FANTASIA" runat="server" Enabled  = "true" style="font-weight: 700" Width="75%" MaxLength="200"></asp:TextBox>                
    <br />                
    <b>CEP</b>                
    <br />                
    <asp:TextBox ID="txt_CEP" runat="server" Enabled  = "true" Width="100px" MaxLength="9"></asp:TextBox>                
    <br />                
    <b>Cidade</b>                
    <br />                
    <asp:DropDownList ID="cmb_COD_MUNICIPIO" runat="server"                     
        DataSourceID="dts_Municipios" DataTextField="Municipio"                     
        DataValueField="Cod_Municipio">                
    </asp:DropDownList>                
    <br />                
    <b>Esfera Administrativa</b>                
    <br />                
    <asp:DropDownList ID="cmb_ESFERA_ADMINISTRATIVA" runat="server"                     
        DataSourceID="dts_Esfera_Administrativa" DataTextField="ESFERA"                     
        DataValueField="COD" Width="25%">                
    </asp:DropDownList>        
    <br />
</div>
    <asp:SqlDataSource ID="dts_Municipios" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>"
        SelectCommand="SELECT [COD_MUNICIPIO], [MUNICIPIO] FROM [VIEW_MUNICIPIOS] ORDER BY [MUNICIPIO]">
    </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="dts_Esfera_Administrativa" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT COD, ESFERA + '  ' + GESTAO AS ESFERA FROM tbl_ESFERA_ADMINISTRATIVA ORDER BY COD">
    </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="dts_USUARIOS" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [VIEW_USUARIOS] WHERE (([ATIVO] = @ATIVO) AND ([COD_PERFIL] = @COD_PERFIL) AND ([BLOQUEADO] = @BLOQUEADO)) ORDER BY [NOME]">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="ATIVO" Type="Boolean" />
            <asp:Parameter DefaultValue="4" Name="COD_PERFIL" Type="Decimal" />
            <asp:Parameter DefaultValue="False" Name="BLOQUEADO" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
</form>
</body>
</html>
