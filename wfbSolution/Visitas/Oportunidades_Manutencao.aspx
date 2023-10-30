<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Oportunidades_Manutencao.aspx.vb" Inherits="Oportunidades_Manutencao" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Atualizar Oportunidade</title>
    <script src="JScript.js" type="text/javascript"></script>
    <link href="App_Themes/MasterTheme/Master.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
     
        .style5
        {
            width: 100%;
        }
     
        .style9
        {
            color: #666666;
        }
     
        .style10
        {
            color: #FF0000;
        }
             
        .auto-style2 {
            color: #808080;
        }
             
    </style>
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Atualizar Oportunidade
    </div>
    <div id ="Titulo_Pagina_Links">
        <a href="Estabelecimentos_Ficha_Oportunidades.aspx?CNPJ=<%=Request.QueryString("CNPJ")%>">Ficha do Estabelecimento</a>&nbsp;
        <a href="Oportunidades_Localizar.aspx">Minhas Oportunidades</a>&nbsp;
    </div>
</div>    
<br />
<div id ="Corpo">
    
    <table class="style5">
            <tr>
                <td class="style9">
                    <asp:TextBox ID="txt_Acao" runat="server" AutoPostBack="True" Width="5%" BorderStyle="None" EnableTheming="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:FormView ID="frv_Oportunidade" runat="server" DataSourceID="dts_Oportunidades" Width="100%">
                        <EditItemTemplate>
                            ID_OPORTUNIDADE:
                            <asp:Label ID="ID_OPORTUNIDADELabel1" runat="server" 
                                Text='<%# Eval("ID_OPORTUNIDADE") %>' />
                            <br />
                            CNPJ:
                            <asp:TextBox ID="CNPJTextBox" runat="server" Text='<%# Bind("CNPJ") %>' />
                            <br />
                            ESTABELECIMENTO_CNPJ:
                            <asp:TextBox ID="ESTABELECIMENTO_CNPJTextBox" runat="server" 
                                Text='<%# Bind("ESTABELECIMENTO_CNPJ") %>' />
                            <br />
                            DESCRICAO:
                            <asp:TextBox ID="DESCRICAOTextBox" runat="server" 
                                Text='<%# Bind("DESCRICAO") %>' />
                            <br />
                            INCLUSAO:
                            <asp:TextBox ID="INCLUSAOTextBox" runat="server" 
                                Text='<%# Bind("INCLUSAO") %>' />
                            <br />
                            FASE_INICIAL:
                            <asp:TextBox ID="FASE_INICIALTextBox" runat="server" 
                                Text='<%# Bind("FASE_INICIAL") %>' />
                            <br />
                            ATUALIZACAO:
                            <asp:TextBox ID="ATUALIZACAOTextBox" runat="server" 
                                Text='<%# Bind("ATUALIZACAO") %>' />
                            <br />
                            FASE_ATUAL:
                            <asp:TextBox ID="FASE_ATUALTextBox" runat="server" 
                                Text='<%# Bind("FASE_ATUAL") %>' />
                            <br />
                            FASE_ATUAL_QTD_PREVISTA:
                            <asp:TextBox ID="FASE_ATUAL_QTD_PREVISTATextBox" runat="server" 
                                Text='<%# Bind("FASE_ATUAL_QTD_PREVISTA") %>' />
                            <br />
                            JAN:
                            <asp:TextBox ID="JANTextBox" runat="server" Text='<%# Bind("JAN") %>' />
                            <br />
                            FEV:
                            <asp:TextBox ID="FEVTextBox" runat="server" Text='<%# Bind("FEV") %>' />
                            <br />
                            MAR:
                            <asp:TextBox ID="MARTextBox" runat="server" Text='<%# Bind("MAR") %>' />
                            <br />
                            ABR:
                            <asp:TextBox ID="ABRTextBox" runat="server" Text='<%# Bind("ABR") %>' />
                            <br />
                            MAI:
                            <asp:TextBox ID="MAITextBox" runat="server" Text='<%# Bind("MAI") %>' />
                            <br />
                            JUN:
                            <asp:TextBox ID="JUNTextBox" runat="server" Text='<%# Bind("JUN") %>' />
                            <br />
                            JUL:
                            <asp:TextBox ID="JULTextBox" runat="server" Text='<%# Bind("JUL") %>' />
                            <br />
                            AGO:
                            <asp:TextBox ID="AGOTextBox" runat="server" Text='<%# Bind("AGO") %>' />
                            <br />
                            SET:
                            <asp:TextBox ID="SETTextBox" runat="server" Text='<%# Bind("SET") %>' />
                            <br />
                            OUT:
                            <asp:TextBox ID="OUTTextBox" runat="server" Text='<%# Bind("OUT") %>' />
                            <br />
                            NOV:
                            <asp:TextBox ID="NOVTextBox" runat="server" Text='<%# Bind("NOV") %>' />
                            <br />
                            DEZ:
                            <asp:TextBox ID="DEZTextBox" runat="server" Text='<%# Bind("DEZ") %>' />
                            <br />
                            TOTAL:
                            <asp:TextBox ID="TOTALTextBox" runat="server" Text='<%# Bind("TOTAL") %>' />
                            <br />
                            INCLUSAO_DATA:
                            <asp:TextBox ID="INCLUSAO_DATATextBox" runat="server" 
                                Text='<%# Bind("INCLUSAO_DATA") %>' />
                            <br />
                            INCLUSAO_EMAIL:
                            <asp:TextBox ID="INCLUSAO_EMAILTextBox" runat="server" 
                                Text='<%# Bind("INCLUSAO_EMAIL") %>' />
                            <br />
                            SITUACAO_OPORTUNIDADE:
                            <asp:TextBox ID="SITUACAO_OPORTUNIDADETextBox" runat="server" 
                                Text='<%# Bind("SITUACAO_OPORTUNIDADE") %>' />
                            <br />
                            ID_SITUACAO_OPORTUNIDADE:
                            <asp:TextBox ID="ID_SITUACAO_OPORTUNIDADETextBox" runat="server" 
                                Text='<%# Bind("ID_SITUACAO_OPORTUNIDADE") %>' />
                            <br />
                            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                                CommandName="Update" Text="Update" />
                            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                                CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            CNPJ:
                            <asp:TextBox ID="CNPJTextBox" runat="server" Text='<%# Bind("CNPJ") %>' />
                            <br />
                            ESTABELECIMENTO_CNPJ:
                            <asp:TextBox ID="ESTABELECIMENTO_CNPJTextBox" runat="server" 
                                Text='<%# Bind("ESTABELECIMENTO_CNPJ") %>' />
                            <br />
                            DESCRICAO:
                            <asp:TextBox ID="DESCRICAOTextBox" runat="server" 
                                Text='<%# Bind("DESCRICAO") %>' />
                            <br />
                            INCLUSAO:
                            <asp:TextBox ID="INCLUSAOTextBox" runat="server" 
                                Text='<%# Bind("INCLUSAO") %>' />
                            <br />
                            FASE_INICIAL:
                            <asp:TextBox ID="FASE_INICIALTextBox" runat="server" 
                                Text='<%# Bind("FASE_INICIAL") %>' />
                            <br />
                            ATUALIZACAO:
                            <asp:TextBox ID="ATUALIZACAOTextBox" runat="server" 
                                Text='<%# Bind("ATUALIZACAO") %>' />
                            <br />
                            FASE_ATUAL:
                            <asp:TextBox ID="FASE_ATUALTextBox" runat="server" 
                                Text='<%# Bind("FASE_ATUAL") %>' />
                            <br />
                            FASE_ATUAL_QTD_PREVISTA:
                            <asp:TextBox ID="FASE_ATUAL_QTD_PREVISTATextBox" runat="server" 
                                Text='<%# Bind("FASE_ATUAL_QTD_PREVISTA") %>' />
                            <br />
                            JAN:
                            <asp:TextBox ID="JANTextBox" runat="server" Text='<%# Bind("JAN") %>' />
                            <br />
                            FEV:
                            <asp:TextBox ID="FEVTextBox" runat="server" Text='<%# Bind("FEV") %>' />
                            <br />
                            MAR:
                            <asp:TextBox ID="MARTextBox" runat="server" Text='<%# Bind("MAR") %>' />
                            <br />
                            ABR:
                            <asp:TextBox ID="ABRTextBox" runat="server" Text='<%# Bind("ABR") %>' />
                            <br />
                            MAI:
                            <asp:TextBox ID="MAITextBox" runat="server" Text='<%# Bind("MAI") %>' />
                            <br />
                            JUN:
                            <asp:TextBox ID="JUNTextBox" runat="server" Text='<%# Bind("JUN") %>' />
                            <br />
                            JUL:
                            <asp:TextBox ID="JULTextBox" runat="server" Text='<%# Bind("JUL") %>' />
                            <br />
                            AGO:
                            <asp:TextBox ID="AGOTextBox" runat="server" Text='<%# Bind("AGO") %>' />
                            <br />
                            SET:
                            <asp:TextBox ID="SETTextBox" runat="server" Text='<%# Bind("SET") %>' />
                            <br />
                            OUT:
                            <asp:TextBox ID="OUTTextBox" runat="server" Text='<%# Bind("OUT") %>' />
                            <br />
                            NOV:
                            <asp:TextBox ID="NOVTextBox" runat="server" Text='<%# Bind("NOV") %>' />
                            <br />
                            DEZ:
                            <asp:TextBox ID="DEZTextBox" runat="server" Text='<%# Bind("DEZ") %>' />
                            <br />
                            TOTAL:
                            <asp:TextBox ID="TOTALTextBox" runat="server" Text='<%# Bind("TOTAL") %>' />
                            <br />
                            INCLUSAO_DATA:
                            <asp:TextBox ID="INCLUSAO_DATATextBox" runat="server" 
                                Text='<%# Bind("INCLUSAO_DATA") %>' />
                            <br />
                            INCLUSAO_EMAIL:
                            <asp:TextBox ID="INCLUSAO_EMAILTextBox" runat="server" 
                                Text='<%# Bind("INCLUSAO_EMAIL") %>' />
                            <br />
                            SITUACAO_OPORTUNIDADE:
                            <asp:TextBox ID="SITUACAO_OPORTUNIDADETextBox" runat="server" 
                                Text='<%# Bind("SITUACAO_OPORTUNIDADE") %>' />
                            <br />
                            ID_SITUACAO_OPORTUNIDADE:
                            <asp:TextBox ID="ID_SITUACAO_OPORTUNIDADETextBox" runat="server" 
                                Text='<%# Bind("ID_SITUACAO_OPORTUNIDADE") %>' />
                            <br />
                            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                                CommandName="Insert" Text="Insert" />
                            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                                CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <strong>ID</strong>
                            <asp:Label ID="ID_OPORTUNIDADELabel" runat="server" 
                                Text='<%# Bind("ID_OPORTUNIDADE")%>' style="font-weight: 700" />
                            <br />
                            <asp:Label ID="ESTABELECIMENTO_CNPJLabel" runat="server" style="font-weight: 700" Text='<%# Bind("ESTABELECIMENTO_CNPJ") %>' />
                            <br />
                            <span class="auto-style2">Inclusão:
                            <asp:Label ID="INCLUSAOLabel" runat="server" Text='<%# Bind("INCLUSAO") %>' />
                            <br />
                            Atualização:
                            <asp:Label ID="ATUALIZACAOLabel" runat="server" Text='<%# Eval("ALTERACAO") %>' />
                            </span>
                            <br />
                        </ItemTemplate>
                    </asp:FormView>
                </td>
            </tr>
            <tr>
                <td colspan="2"> &nbsp;</td>
            </tr>
            </table>
    <table width="100%">
        <tr>
            <td>Linha de Produto</td>
            <td>
                <asp:DropDownList ID="cmb_Cod_Linha_Produto" runat="server" 
                    DataSourceID="dts_LInha_Produto" DataTextField="LINHA" 
                    DataValueField="COD" Enabled="false">
                </asp:DropDownList>
                &nbsp;<asp:RangeValidator ID="rv_Cod_Linha_Produto" runat="server" ControlToValidate="cmb_Cod_Linha_Produto" 
                    ErrorMessage="Selecione" MaximumValue="100" MinimumValue="1" 
                    Type="Integer"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td>Etapa</td>
            <td>
                <asp:DropDownList ID="cmb_Fase" runat="server" 
                    DataSourceID="dts_Oportunidades_Fases" DataTextField="FASE" 
                    DataValueField="ID_FASE" Enabled="false">
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
                    TextMode="MultiLine" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td >
                Área</td>
            <td>
                <asp:DropDownList ID="cmb_Area" runat="server" 
                    DataSourceID="dts_Estabelecimentos_Areas" DataTextField="AREA" 
                    DataValueField="ID_AREA" Enabled="false">
                </asp:DropDownList>
                &nbsp;<asp:RangeValidator ID="rv_Area" runat="server" ControlToValidate="cmb_Area" 
                    ErrorMessage="Selecione" MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td >
                Localização</td>
            <td>
                <asp:TextBox ID="txt_Localizacao" runat="server" Width="75%" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td >
                Qtd Prevista </td>
            <td>
                <asp:TextBox ID="txt_Qtd_Prevista" runat="server" 
                    style="text-align: center; font-weight: 700" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td >Influenciador Econômico</td>
            <td>
                <asp:DropDownList ID="cmb_Influenciador_Economico" runat="server" DataSourceID="dts_Pessoas" DataTextField="PESSOA" DataValueField="PESSOA_ID" Enabled="false"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td >Influenciador Técnico</td>
            <td>
                <asp:DropDownList ID="cmb_Influenciador_Tecnico" runat="server" DataSourceID="dts_Pessoas" DataTextField="PESSOA" DataValueField="PESSOA_ID" Enabled="false"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td >Coach</td>
            <td>
                <asp:DropDownList ID="cmb_Treinador" runat="server" DataSourceID="dts_Pessoas" DataTextField="PESSOA" DataValueField="PESSOA_ID" Enabled="false"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td >Usuário</td>
            <td>
                <asp:DropDownList ID="cmb_Usuario" runat="server" DataSourceID="dts_Pessoas" DataTextField="PESSOA" DataValueField="PESSOA_ID" Enabled="false"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td >
                Ano Fechamento</td>
            <td>
                <asp:DropDownList ID="cmb_Ano" runat="server" DataSourceID="dts_Anos" DataTextField="ANO_VALOR" DataValueField="ANO_VALOR" Enabled="false">
                </asp:DropDownList>
            </td>
        </tr>
        
        <tr>
            <td >
                Mês Fechamento</td>
            <td>
                <asp:DropDownList ID="cmb_Mes_Fechamento" runat="server" 
                    DataSourceID="dts_Mes_Fechamento" DataTextField="MES_OPORTUNIDADE" 
                    DataValueField="MES_NUMERO_VALOR" Enabled="false">
                </asp:DropDownList>
            </td>
        </tr>
        
        <tr>
            <td >
                Situação</td>
            <td>
                <asp:DropDownList ID="cmb_Situacao" runat="server" DataSourceID="dts_Situacao" 
                    DataTextField="SITUACAO" DataValueField="ID_SITUACAO" Enabled="false">
                </asp:DropDownList>
            </td>
        </tr>
        
        <tr>
            <td >
                <asp:Button ID="cmd_Gravar" runat="server" Text="Gravar" Enabled="false" Visible="false" /></td>
            <td>
                &nbsp;</td>
        </tr>
        
        <tr>
            <td colspan="2" >
                &nbsp;</td>
        </tr>
        
        <tr>
            <td colspan="2" >
                <strong>Quantidades Distribuidas</strong></td>
        </tr>
        
        <tr>
            <td colspan="2" >
                    <asp:GridView ID="gdv_Oportunidades" runat="server" AutoGenerateColumns="False" DataSourceID="dts_Oportunidades" Width="100%">
        <Columns>
            <asp:BoundField DataField="LINHA" HeaderText="Linha" 
                SortExpression="LINHA">
            </asp:BoundField>
            <asp:BoundField DataField="JAN" HeaderText="JAN" SortExpression="JAN" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="FEV" HeaderText="FEV" SortExpression="FEV"  >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="MAR" HeaderText="MAR" SortExpression="MAR"  >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="ABR" HeaderText="ABR" SortExpression="ABR"  >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="MAI" HeaderText="MAI" SortExpression="MAI"  >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="JUN" HeaderText="JUN" SortExpression="JUN"  >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="JUL" HeaderText="JUL" SortExpression="JUL"  >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="AGO" HeaderText="AGO" SortExpression="AGO"  >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="SET" HeaderText="SET" SortExpression="SET"  >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="OUT" HeaderText="OUT" SortExpression="OUT"  >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="NOV" HeaderText="NOV" SortExpression="NOV"  >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="DEZ" HeaderText="DEZ" SortExpression="DEZ"  >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="TOTAL" HeaderText="TOTAL" SortExpression="TOTAL"  >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="FASE_ATUAL_QTD_PREVISTA" HeaderText="Qtd Inicial" SortExpression="FASE_ATUAL_QTD_PREVISTA"  >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
        </Columns>
        <HeaderStyle 
            HorizontalAlign="Center" VerticalAlign="Middle" />
        <RowStyle HorizontalAlign="Center" 
            VerticalAlign="Middle" />
    </asp:GridView> 
                </td>
        </tr>
        
    </table>
    <br /><br /><br />
</div>

    <asp:SqlDataSource ID="dts_Oportunidades_Fases" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            SelectCommand="SELECT [ID_FASE], [FASE] FROM [TBL_OPORTUNIDADES_FASES] ORDER BY [FASE]">
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Estabelecimentos_Areas" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [tbl_ESTABELECIMENTOS_AREAS] ORDER BY [AREA]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Mes_Fechamento" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
                    
            SelectCommand="SELECT * FROM [TBL_DATAS_MESES] ORDER BY [MES_NUMERO_VALOR]">
                </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_LInha_Produto" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            SelectCommand="SELECT * FROM [TBL_PRODUTOS_LINHAS] WHERE ([OPORTUNIDADES] = @OPORTUNIDADES) ORDER BY [LINHA]">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="OPORTUNIDADES" Type="Boolean" />
        </SelectParameters>
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Pessoas" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT '@' AS PESSOA_ID, '@ Selecione' AS PESSOA Union All  SELECT PESSOA_ID, PESSOA FROM [VIEW_PESSOAS] WHERE ([PESSOA_CNPJ_ESTABELECIMENTO] = @PESSOA_CNPJ_ESTABELECIMENTO) ORDER BY [PESSOA]">
            <SelectParameters>
                <asp:QueryStringParameter Name="PESSOA_CNPJ_ESTABELECIMENTO" QueryStringField="CNPJ" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Oportunidades" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            SelectCommand="SELECT * FROM [VIEW_OPORTUNIDADES_FINAL] WHERE ([ID_OPORTUNIDADE] = @ID_OPORTUNIDADE)">
        <SelectParameters>
            <asp:QueryStringParameter Name="ID_OPORTUNIDADE" QueryStringField="ID_OPORTUNIDADE" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Situacao" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
                    SelectCommand="SELECT * FROM [TBL_OPORTUNIDADES_FASES_SITUACAO] ORDER BY [ID_SITUACAO]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Anos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [tbl_DATAS_ANOS] WHERE ([ANO_ABERTO_OPORTUNIDADES] = @ANO_ABERTO_OPORTUNIDADES) ORDER BY [ANO_VALOR] DESC">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="ANO_ABERTO_OPORTUNIDADES" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
</form>
</body>
</html>

