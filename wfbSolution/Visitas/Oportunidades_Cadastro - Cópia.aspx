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
       <a href='Estabelecimentos_Ficha_Oportunidades.aspx?CNPJ=<%=Session("CNPJ")%>'>Voltar</a>
    </div>
</div>    
<br />
<div id ="Corpo">
    
    
    <asp:FormView ID="frm_Estabelecimento_Ficha" runat="server" 
        DataSourceID="dts_Estabelecimento" 
        EnableModelValidation="True" Width="100%">
        <EditItemTemplate></EditItemTemplate>
        <InsertItemTemplate></InsertItemTemplate>
        <ItemTemplate>
            <span class="style8">
                <asp:Label ID="ESTABELECIMENTOLabel" runat="server" style="font-weight: 700; background-color: #FFFFFF;" 
                    Text='<%# Bind("ESTABELECIMENTO") %>' />
                    <br />
                </span>
        </ItemTemplate>
     </asp:FormView>
    <table width="100%">
        <tr>
            <td>Linha de Produto</td>
            <td>
                <asp:DropDownList ID="cmb_Cod_Linha_Produto" runat="server" 
                    DataSourceID="dts_LInha_Produto" DataTextField="LINHA" 
                    DataValueField="COD">
                </asp:DropDownList>
                &nbsp;<asp:RangeValidator ID="rv_Cod_Linha_Produto" runat="server" ControlToValidate="cmb_Cod_Linha_Produto" 
                    ErrorMessage="Selecione" MaximumValue="100" MinimumValue="1" 
                    Type="Integer"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td>Etapa Inicial</td>
            <td>
                <asp:DropDownList ID="cmb_Fase" runat="server" 
                    DataSourceID="dts_Oportunidades_Fases" DataTextField="FASE" 
                    DataValueField="ID_FASE">
                </asp:DropDownList>
                &nbsp;<asp:RangeValidator ID="rv_Fase" runat="server" ControlToValidate="cmb_Fase" 
                    ErrorMessage="Selecione" MaximumValue="100" MinimumValue="1" 
                    Type="Integer"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td width="10%">
                Descrição</td>
            <td><asp:TextBox ID="txt_Descricao" runat="server" Width="75%" Height="60px" 
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td >Área</td>
            <td>
                <asp:DropDownList ID="cmb_Area" runat="server" 
                    DataSourceID="dts_Estabelecimentos_Areas" DataTextField="AREA" 
                    DataValueField="ID_AREA">
                </asp:DropDownList>
                &nbsp;<asp:RangeValidator ID="rv_Area" runat="server" ControlToValidate="cmb_Area" 
                    ErrorMessage="Selecione" MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td >Localização</td>
            <td>
                <asp:TextBox ID="txt_Localizacao" runat="server" Width="75%"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td >
                Qtd Prevista </td>
            <td>
                <asp:TextBox ID="txt_Qtd_Prevista" runat="server" 
                    style="text-align: center; font-weight: 700"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td >Influenciador Econômico</td>
            <td>
                <asp:DropDownList ID="cmb_Influenciador_Economico" runat="server" DataSourceID="dts_Pessoas" DataTextField="PESSOA" DataValueField="PESSOA_ID"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td >Influenciador Técnico</td>
            <td>
                <asp:DropDownList ID="cmb_Influenciador_Tecnico" runat="server" DataSourceID="dts_Pessoas" DataTextField="PESSOA" DataValueField="PESSOA_ID"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td >Coach</td>
            <td>
                <asp:DropDownList ID="cmb_Treinador" runat="server" DataSourceID="dts_Pessoas" DataTextField="PESSOA" DataValueField="PESSOA_ID"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td >Usuário</td>
            <td>
                <asp:DropDownList ID="cmb_Usuario" runat="server" DataSourceID="dts_Pessoas" DataTextField="PESSOA" DataValueField="PESSOA_ID"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td >
                Mês Fechamento</td>
            <td>
                <asp:DropDownList ID="cmb_Mes_Fechamento" runat="server" 
                    DataSourceID="dts_Mes_Fechamento" DataTextField="MES_OPORTUNIDADE" 
                    DataValueField="MES_NUMERO_VALOR">
                </asp:DropDownList>
                <asp:SqlDataSource ID="dts_Mes_Fechamento" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
                    SelectCommand="SELECT * FROM [TBL_DATAS_MESES] WHERE ([MES_FECHADO_OPORTUNIDADE] = @MES_FECHADO_OPORTUNIDADE) ORDER BY [MES_NUMERO_VALOR]">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="False" Name="MES_FECHADO_OPORTUNIDADE" 
                            Type="Boolean" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        
    </table>
    <p>
        <asp:Button ID="cmd_Gravar" runat="server" Text="Gravar" />
                </p>
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
            SelectCommand="SELECT [ID_FASE], [FASE] FROM [TBL_OPORTUNIDADES_FASES] ORDER BY [FASE]">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_LInha_Produto" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            
            SelectCommand="SELECT * FROM [TBL_PRODUTOS_LINHAS] WHERE ([OPORTUNIDADES] = @OPORTUNIDADES) ORDER BY [COD]">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="OPORTUNIDADES" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
    <b>
    <asp:SqlDataSource ID="dts_Pessoas" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT '@' AS PESSOA_ID, '@ Selecione' AS PESSOA Union All  SELECT PESSOA_ID, PESSOA FROM [VIEW_PESSOAS] WHERE ([PESSOA_CNPJ_ESTABELECIMENTO] = @PESSOA_CNPJ_ESTABELECIMENTO) ORDER BY [PESSOA]">
        <SelectParameters>
            <asp:SessionParameter Name="PESSOA_CNPJ_ESTABELECIMENTO" SessionField="CNPJ" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
    </b>
</form>
</body>
</html>
