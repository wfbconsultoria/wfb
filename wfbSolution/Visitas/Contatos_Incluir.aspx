<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Contatos_Incluir.aspx.vb" Inherits="Contatos_Incluir" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Incluir Contato</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Incluir Contato</div>
    <div id ="Titulo_Pagina_Links">
         <a href="Estabelecimentos_Ficha.aspx?CNPJ=<%=Session("CNPJ")%>">Voltar para estabelecimento</a>
    </div>
</div>
<br />
<div id ="Corpo">
    <br />
       Estabelecimento
      
       <asp:FormView ID="frm_Estabelecimento_Ficha" runat="server" DataSourceID="dts_Estabelecimento" Width="100%">
            <EditItemTemplate></EditItemTemplate>
            <InsertItemTemplate></InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="ESTABELECIMENTOLabel" runat="server" Text='<%# Bind("ESTABELECIMENTO_CNPJ") %>'/>
                <br />
            </ItemTemplate>
       </asp:FormView>
       <br />
       <strong>Nome
       </strong>
       <br />
       <asp:TextBox ID="txt_NOME" runat="server" Width="50%"></asp:TextBox>
       <asp:RequiredFieldValidator ID="rfv_NOME" runat="server" 
        ControlToValidate="txt_NOME" ErrorMessage="OBRIGATÓRIO" ForeColor="Black">
       </asp:RequiredFieldValidator>
       <br />         
       <strong>Cargo</strong>
       <br />  
       <asp:DropDownList ID="cmb_ID_CARGO" runat="server" DataSourceID="TBL_CONTATOS_CARGOS" DataTextField="CARGO" DataValueField="ID_CARGO"> </asp:DropDownList>
       <br />           
       <strong>Area
       </strong>
       <br />
       <asp:DropDownList ID="cmb_ID_AREA" runat="server" DataSourceID="TBL_CONTATOS_AREAS" DataTextField="AREA" DataValueField="ID_AREA"> </asp:DropDownList>
       <br />
        <!--   
        <strong>Endereço</strong><br />
        <asp:TextBox ID="txt_Endereco" runat="server" Width="50%"></asp:TextBox>
        <br />
       <strong>Bairro</strong><br />
        <asp:TextBox ID="txt_Bairro" runat="server" Width="50%"></asp:TextBox>
        <br />
       <strong>CEP</strong><br />
        <asp:TextBox ID="txt_CEP" runat="server" Enabled  = "true" Width="100px" MaxLength="9"></asp:TextBox>
        <br />
       <strong>Cidade</strong><br />
        <asp:DropDownList ID="cmb_COD_MUNICIPIO" runat="server" 
                        DataSourceID="dts_Municipios" DataTextField="Municipio" 
                        DataValueField="Cod_Municipio" Width="50%">
                    </asp:DropDownList>
       <br />   
       -->
       <strong>Telefone</strong>
        <br />
        <asp:TextBox ID="txt_TELEFONE" runat="server" MaxLength="12" Width="15%"></asp:TextBox>
        <br />       
        <strong>Celular
        </strong>
        <br />
        <asp:TextBox ID="txt_CELULAR" runat="server" MaxLength="12" Width="15%"></asp:TextBox>
        <br />
        <strong>E-mail
        </strong>
        <br />
        <asp:TextBox ID="txt_EMAIL" runat="server" MaxLength="500" Width="35%"></asp:TextBox>
        <asp:RegularExpressionValidator ID="rev_EMAIL" runat="server" 
            ErrorMessage="EMAIL INVÁLIDO" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
            ControlToValidate="txt_EMAIL" Display="Dynamic" ForeColor="Black"></asp:RegularExpressionValidator>
        <br />          
        <strong>Mês Aniversário
        </strong>
        <br />
        <asp:DropDownList ID="cmb_MES_ANIVERSARIO" runat="server" 
            DataSourceID="TBL_DATAS_MESES" DataTextField="MES_EXTENSO" 
            DataValueField="MES_NUMERO_VALOR">
       </asp:DropDownList>
        <br />   
        <strong>Dia Aniversário
       </strong>
       <br />
       <asp:DropDownList ID="cmb_DIA_ANIVERSARIO" runat="server" 
         DataSourceID="TBL_DATAS_DIAS" DataTextField="DIA_NUMERO_TEXTO"
         DataValueField="DIA_NUMERO_VALOR">
        </asp:DropDownList>
        <br /><br />  
        <asp:Button ID="cmd_Gravar" runat="server" Text="Gravar" CssClass="buton_gravar" Visible="False"/>
        <br />
        <br />
        <br />
        <br /> 
     </div>
     <asp:SqlDataSource ID="dts_Estabelecimento" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS] WHERE ([CNPJ] = @CNPJ)">
            <SelectParameters>
                <asp:SessionParameter Name="CNPJ" SessionField="CNPJ" Type="Decimal" />  
            </SelectParameters>
        </asp:SqlDataSource>
     <asp:SqlDataSource ID="TBL_DATAS_MESES" runat="server" 
                ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
                SelectCommand="SELECT [MES_NUMERO_VALOR], [MES_EXTENSO] FROM [TBL_DATAS_MESES] ORDER BY [MES_NUMERO_VALOR]">
            </asp:SqlDataSource>
     <asp:SqlDataSource ID="TBL_DATAS_DIAS" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
                        
                        SelectCommand="SELECT [DIA_NUMERO_VALOR], [DIA_NUMERO_TEXTO] FROM [TBL_DATAS_DIAS] ORDER BY [DIA_NUMERO_VALOR]">
                    </asp:SqlDataSource>
     <asp:SqlDataSource ID="TBL_CONTATOS_AREAS" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
       SelectCommand="SELECT [ID_AREA], [AREA] FROM [TBL_ESTABELECIMENTOS_AREAS]">
       </asp:SqlDataSource>
     <asp:SqlDataSource ID="TBL_CONTATOS_CARGOS" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT [ID_CARGO], [CARGO] FROM [TBL_CONTATOS_CARGOS] ORDER BY [CARGO]">
       </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Municipios" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT [COD_MUNICIPIO], [MUNICIPIO] FROM [VIEW_MUNICIPIOS] ORDER BY [MUNICIPIO]">
    </asp:SqlDataSource>
 </form>
 </body>
</html>
