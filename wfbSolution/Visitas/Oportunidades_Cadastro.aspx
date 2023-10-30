<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Oportunidades_Cadastro.aspx.vb" Inherits="Oportunidades_Cadastro" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Nova Oportunidade</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Nova Oportunidade</div>
    <div id ="Titulo_Pagina_Links">
        <a href="Estabelecimentos_Ficha.aspx?CNPJ=<%=Session("CNPJ")%>">Voltar/Cancelar</a>
    </div>
</div>
<br />
<div id ="Corpo">
    <asp:FormView ID="frm_Estabelecimento_Ficha" runat="server" DataSourceID="dts_Estabelecimento" EnableModelValidation="True" Width="100%">
        <EditItemTemplate></EditItemTemplate>
        <InsertItemTemplate></InsertItemTemplate>
        <ItemTemplate>
            <asp:Label ID="ESTABELECIMENTOLabel" runat="server" Text='<%# Bind("ESTABELECIMENTO") %>' />
        </ItemTemplate>
     </asp:FormView>
    <b>Linha de Produto</b>
    <br />
    <asp:DropDownList ID="cmb_Cod_Linha_Produto" runat="server" DataSourceID="dts_LInha_Produto" DataTextField="LINHA" DataValueField="COD" Enabled="True"> </asp:DropDownList>&nbsp;
    <asp:RangeValidator ID="rv_Cod_Linha_Produto" runat="server" ControlToValidate="cmb_Cod_Linha_Produto" 
        ErrorMessage="Selecione" MaximumValue="100" MinimumValue="1" 
        Type="Integer" style="color: #FF0000">
    </asp:RangeValidator>
    <br />
    <b>Etapa Atual</b><br />
    <asp:DropDownList ID="cmb_Fase" runat="server" DataSourceID="dts_Oportunidades_Fases" DataTextField="FASE" DataValueField="ID_FASE"></asp:DropDownList>&nbsp;
    <asp:RangeValidator ID="rv_Fase" runat="server" ControlToValidate="cmb_Fase" 
                    ErrorMessage="Selecione" MaximumValue="100" MinimumValue="1" 
                    Type="Integer" style="color: #FF0000"></asp:RangeValidator>
    <br />
    <b>Descrição</b>
    <br />
    <asp:TextBox ID="txt_Descricao" runat="server" Width="50%" TextMode="MultiLine" Height="60px"></asp:TextBox>
    <br />
    <b>Área</b>
    <br />
    <asp:DropDownList ID="cmb_Area" runat="server" DataSourceID="dts_Estabelecimentos_Areas" DataTextField="AREA" DataValueField="ID_AREA"> </asp:DropDownList>&nbsp;
    <asp:RangeValidator ID="rv_Area" runat="server" ControlToValidate="cmb_Area" 
        ErrorMessage="Selecione" MaximumValue="100" MinimumValue="1" Type="Integer" style="color: #FF0000">
    </asp:RangeValidator>
    <br />
    <b>Localização</b>
    <br />
    <asp:TextBox ID="txt_Localizacao" runat="server" Width="50%"></asp:TextBox>
    <br />
    <b>Influenciador Econômico</b>
    <br />
    <asp:DropDownList ID="cmb_Influenciador_Economico" runat="server" DataSourceID="dts_Pessoas" DataTextField="PESSOA" DataValueField="PESSOA_ID"></asp:DropDownList>
    <br />
    <b>Influenciador Técnico</b>
    <br />
    <asp:DropDownList ID="cmb_Influenciador_Tecnico" runat="server" DataSourceID="dts_Pessoas" DataTextField="PESSOA" DataValueField="PESSOA_ID"></asp:DropDownList>
    <br />
    <b>Coach</b>
    <br />
    <asp:DropDownList ID="cmb_Treinador" runat="server" DataSourceID="dts_Pessoas" DataTextField="PESSOA" DataValueField="PESSOA_ID"></asp:DropDownList>
    <br />
    <b>Usuário</b>
    <br />
    <asp:DropDownList ID="cmb_Usuario" runat="server" DataSourceID="dts_Pessoas" DataTextField="PESSOA" DataValueField="PESSOA_ID"></asp:DropDownList>
    <br />
    <b>Qtd Prevista</b>
    <br />
    <asp:TextBox ID="txt_Qtd_Prevista" runat="server" style="text-align: center;" TextMode="Number"></asp:TextBox>
    <asp:RangeValidator ID="rfv_Qtd_Prevista" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Integer" ControlToValidate="txt_Qtd_Prevista" ForeColor="Red"></asp:RangeValidator>
    <br />
    <b>Mês Fechamento</b>
    <br />
    <asp:DropDownList ID="cmb_Mes_Fechamento" runat="server" DataSourceID="dts_Mes_Fechamento" DataTextField="MES_OPORTUNIDADE" DataValueField="MES_NUMERO_VALOR"> </asp:DropDownList>&nbsp;   
    <asp:RangeValidator ID="rfv_Mes_Fechamento" runat="server" ErrorMessage="Selecione" MinimumValue="1" MaximumValue="12" Type="Integer" ControlToValidate="cmb_Mes_Fechamento" ForeColor="Red"></asp:RangeValidator>
    <br /><br />
    <asp:Button ID="cmd_Gravar" CssClass="buton_gravar" runat="server" Text="Gravar" />
    <br /><br /><br />
    </div>
    <asp:SqlDataSource ID="dts_Estabelecimento" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS] WHERE ([CNPJ] = @CNPJ)">
        <SelectParameters>
            <asp:SessionParameter Name="CNPJ" SessionField="CNPJ" Type="Decimal" />  
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Estabelecimentos_Areas" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            SelectCommand="SELECT [ID_AREA], [AREA] FROM [TBL_ESTABELECIMENTOS_AREAS] ORDER BY [AREA]">
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Oportunidades_Fases" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            SelectCommand="SELECT [ID_FASE], [FASE] FROM [TBL_OPORTUNIDADES_FASES] WHERE ID_FASE&lt; 5 ORDER BY [FASE]">
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_LInha_Produto" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            SelectCommand="SELECT [COD], [LINHA] FROM [tbl_PRODUTOS_LINHAS] WHERE ([OPORTUNIDADES] = @OPORTUNIDADES)">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="OPORTUNIDADES" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Mes_Fechamento" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
                    SelectCommand="SELECT * FROM [TBL_DATAS_MESES] WHERE ([MES_FECHADO_OPORTUNIDADE] = @MES_FECHADO_OPORTUNIDADE) ORDER BY [MES_NUMERO_VALOR]">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="False" Name="MES_FECHADO_OPORTUNIDADE" Type="Boolean" />
                    </SelectParameters>
                </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Anos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_DATAS_ANOS] WHERE ANO_PERIODO = 'ATUAL' OR ANO_PERIODO = 'PROXIMO' ORDER BY [ANO_VALOR]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Pessoas" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT '@' AS PESSOA_ID, '@ Selecione' AS PESSOA Union All  SELECT PESSOA_ID, PESSOA FROM [VIEW_PESSOAS] WHERE (([PESSOA_CNPJ_ESTABELECIMENTO] = @PESSOA_CNPJ_ESTABELECIMENTO) AND ([PESSOA_ATIVO] = @PESSOA_ATIVO)) ORDER BY [PESSOA]">
        <SelectParameters>
            <asp:SessionParameter Name="PESSOA_CNPJ_ESTABELECIMENTO" SessionField="CNPJ" Type="Decimal" />
            <asp:Parameter DefaultValue="SIM" Name="PESSOA_ATIVO" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</form>
</body>
    
</html>
