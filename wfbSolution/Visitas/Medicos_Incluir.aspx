<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Medicos_Incluir.aspx.vb" Inherits="Medicos_CRM" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inclusão de Médico</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Incluir Novo Médico no Estabelecimento</div>
    <div id ="Titulo_Pagina_Links">
        <a href="Estabelecimentos_Ficha2.aspx?CNPJ=<%=Session("CNPJ")%>">Voltar para estabelecimento</a>
    </div>
</div>
<br />
<div id ="Corpo">
    <br />
    <asp:FormView ID="frm_Estabelecimento_Ficha" runat="server" 
        DataSourceID="dts_Estabelecimento" Width="100%">
        <EditItemTemplate></EditItemTemplate>
        <InsertItemTemplate></InsertItemTemplate>
        <ItemTemplate>
            <asp:Label ID="ESTABELECIMENTOLabel" runat="server" Text='<%# Bind("ESTABELECIMENTO_CNPJ") %>' style="font-weight: 700" />
        </ItemTemplate>
     </asp:FormView>
    <br />
    <b>1 - Pesquisar do Conselho Fedral de Medicina</b>
    <br />
    Selecione o Estado&nbsp<asp:DropDownList ID="cmb_UF" runat="server" DataSourceID="TBL_ESTADOS" DataTextField="UF" DataValueField="UF"></asp:DropDownList>
    &nbsp Digite o CRM <asp:TextBox ID="txt_CRM" runat="server" MaxLength="10" TextMode="Number" style="text-align: center" Width="100px"></asp:TextBox>
    &nbsp  
    <asp:LinkButton ID="cmd_Pesquisar" runat="server">Pesquisar</asp:LinkButton>
    <br />
    Nome
    
    <br />
    <asp:TextBox ID="txt_NOME" runat="server" Width="50%" Enabled="False"></asp:TextBox>
    <br />
    CRM
    UF<br />
    <asp:TextBox ID="txt_CRMUF" runat="server" style="text-align: center;" Enabled="False"></asp:TextBox>
    <hr />    
    <br />
    <b>2 - Preencher dados do médico
    </b>
    <br />
    Especialidade de Formação
    <br />
    <asp:DropDownList ID="cmb_ESPECIALIDADE" runat="server" DataSourceID="dts_Especialidades" DataTextField="ESPECIALIDADE" DataValueField="ID_ESPECIALIDADE"> </asp:DropDownList>
    <br />
    <!-- Endereço do médico está desativado
            <strong>Endereço
        </strong>
        <br />
        <asp:TextBox ID="txt_Endereco" runat="server" Width="50%"></asp:TextBox>
        <br />
         <strong>Bairro
        </strong>
        <br />
        <asp:TextBox ID="txt_Bairro" runat="server" Width="50%"></asp:TextBox>
        <br />
         <strong>CEP
        </strong>
        <br />
        <asp:TextBox ID="txt_CEP" runat="server" Enabled  = "true" Width="100px" MaxLength="9"></asp:TextBox>
        <br />
         <strong>Cidade
        </strong>
        <br />
        <asp:DropDownList ID="cmb_COD_MUNICIPIO" runat="server" 
                        DataSourceID="dts_Municipios" DataTextField="Municipio" 
                        DataValueField="Cod_Municipio" Width="50%">
                    </asp:DropDownList>
        <br />
        -->
   Telefone
   <br />
   <asp:TextBox ID="txt_TELEFONE" runat="server" MaxLength="15" Width="15%"></asp:TextBox>
   <br />
   Celular
   <br />
   <asp:TextBox ID="txt_CELULAR" runat="server" MaxLength="15" Width="15%"></asp:TextBox>
   <br />
   Email
   <br />
   <asp:TextBox ID="txt_EMAIL" runat="server" MaxLength="100" Width="50%"></asp:TextBox>
   <br />
   Mês Aniversário
   <br />
   <asp:DropDownList ID="cmb_MES_ANIVERSARIO" runat="server" DataSourceID="TBL_DATAS_MESES" DataTextField="MES_EXTENSO" DataValueField="MES_NUMERO_VALOR"> </asp:DropDownList>
   <br />
   Dia Aniversário
   <br />
   <asp:DropDownList ID="cmb_DIA_ANIVERSARIO" runat="server" DataSourceID="TBL_DATAS_DIAS" DataTextField="DIA_NUMERO_TEXTO" DataValueField="DIA_NUMERO_VALOR"> </asp:DropDownList>
   <hr />
   <br />
    <b>3 - Preencher dados do médico no estabelecimento
    </b>
    <br />
    Especialidade no Estabelecimento
    <br />
    <asp:DropDownList ID="cmb_ID_ESPECIALIDADE" runat="server" DataSourceID="dts_Especialidades" DataTextField="ESPECIALIDADE" DataValueField="ID_ESPECIALIDADE"></asp:DropDownList>
    <br />
    Área
    <br />
    <asp:DropDownList ID="cmb_ID_AREA" runat="server" DataSourceID="dts_Areas" DataTextField="AREA" DataValueField="ID_AREA"> </asp:DropDownList>
    <br />
    Cargo
    <br />
    <asp:DropDownList ID="cmb_ID_CARGO" runat="server" DataSourceID="dts_Cargos" DataTextField="CARGO" DataValueField="ID_CARGO"> </asp:DropDownList>
    <br />
    Perfil
    <br />
    <asp:DropDownList ID="cmb_ID_PERFIL" runat="server" DataSourceID="dts_Perfis" DataTextField="PERFIL" DataValueField="ID_PERFIL"> </asp:DropDownList>
    <br />
    Telefone no Estabelecimento
    <br />
    <asp:TextBox ID="txt_TELEFONE_ESTABELECIMENTO" runat="server" MaxLength="15" Width="15%" TextMode="Phone"></asp:TextBox>
    <hr />
    <br />
    <asp:Button ID="cmd_Gravar" runat="server" CssClass="buton_gravar" Text="Gravar" Visible="False" />
    <br /><br />
</div>
    <asp:SqlDataSource ID="TBL_ESTADOS" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [TBL_MUNICIPIOS_ESTADOS] ORDER BY [UF]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Especialidades" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [TBL_MEDICOS_ESPECIALIDADES] ORDER BY [ESPECIALIDADE]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Perfil" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [TBL_MEDICOS_PERFIL_PROFISSIONAL] ORDER BY [PERFIL]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Estabelecimento" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        
        SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS] WHERE ([CNPJ] = @CNPJ)">
        <SelectParameters>
            <asp:SessionParameter Name="CNPJ" SessionField="CNPJ" Type="Decimal" />  
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Cargos" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [TBL_MEDICOS_CARGOS] ORDER BY [ID_CARGO]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Perfis" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
                        SelectCommand="SELECT * FROM [TBL_MEDICOS_PERFIL] ORDER BY [PERFIL]">
                    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_AREAS" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [TBL_MEDICOS_AREAS] ORDER BY [AREA]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Municipios" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT [COD_MUNICIPIO], [MUNICIPIO] FROM [VIEW_MUNICIPIOS] ORDER BY [MUNICIPIO]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="TBL_DATAS_MESES" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
                        
                        SelectCommand="SELECT * FROM [TBL_DATAS_MESES] ORDER BY [MES_NUMERO_VALOR]">
                    </asp:SqlDataSource>
    <asp:SqlDataSource ID="TBL_DATAS_DIAS" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
                        
                        SelectCommand="SELECT [DIA_NUMERO_VALOR], [DIA_NUMERO_TEXTO] FROM [TBL_DATAS_DIAS] ORDER BY [DIA_NUMERO_VALOR]">
                    </asp:SqlDataSource>
</form>
</body>
</html>
