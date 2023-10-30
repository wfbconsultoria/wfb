<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Estabelecimentos_Ficha2.aspx.vb" Inherits="Estabelecimentos_Ficha2" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Ficha de Contatos e Visitas do Estabelecimento</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Ficha de Contatos e Visitas do Estabelecimento</div>
    <div id ="Titulo_Pagina_Links">
        <a href="Estabelecimentos_Ficha.aspx?CNPJ=<%=Session("CNPJ")%>">Voltar</a>
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
                <br />
                <table>
                    <tr>
                        <td class="style14">Atendido por</td>
                        <td class="style13">
                            <asp:Label ID="Label_Representante" runat="server" CssClass="style3" Text='<%# Eval("REPRESENTANTE") %>' />
                       </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:FormView>
    <br />
    <b>Médicos Cadastrados no Estabelecimento</b><!--<a href='Medicos_Incluir.aspx?CNPJ=<%=Session("CNPJ")%>'>&nbsp;Incluir</a>-->
    <br />
    <asp:GridView ID="gdv_Medicos" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="dts_Medicos" HorizontalAlign="Center" Width="100%" GridLines="None">
        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="CRMUF,CNPJ" DataNavigateUrlFormatString="Medicos_Ficha.aspx?CRMUF={0}&amp;PAGINA=1" DataTextField="CRMUF" HeaderText="CRMUF" SortExpression="CRMUF">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:HyperLinkField>
            <asp:BoundField DataField="NOME" HeaderText="Nome" SortExpression="NOME">
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="ESPECIALIDADE_MEDICO_NO_ESTABELECIMENTO" HeaderText="Especialidade" SortExpression="ESPECIALIDADE_MEDICO_NO_ESTABELECIMENTO">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="PERFIL_MEDICO_NO_ESTABELECIMENTO" HeaderText="Perfil" SortExpression="PERFIL_MEDICO_NO_ESTABELECIMENTO">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="TELEFONE_MEDICO" HeaderText="Telefone" SortExpression="TELEFONE_MEDICO">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="CELULAR_MEDICO" HeaderText="Celular" SortExpression="CELULAR_MEDICO">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="VISITAS_ANO_ATUAL" HeaderText="Visitas Neste Ano" SortExpression="VISITAS_ANO_ATUAL">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="VISITAS_MES_ATUAL" HeaderText="Visitas Neste Mês" SortExpression="VISITAS_MES_ATUAL">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="NOME,ID_MEDICO_ESTABELECIMENTO" DataNavigateUrlFormatString="Visitas_Incluir.aspx?NOME={0}&amp;TIPO=1&amp;ID={1}&amp;STATUS_ATIVO=ATIVO" FooterText="Visitar" Text="Visitar" Visible="False" />
        </Columns>
        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
    </asp:GridView>
    <br />
    <b>Contatos Cadastrados no Estabelecimento</b><!--<a href='Contatos_Incluir.aspx?CNPJ=<%=Session("CNPJ")%>'>&nbsp; Incluir</a>-->
    <br />
    <asp:GridView ID="gdv_CONTATOS" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID_CONTATO" DataSourceID="dts_CONTATOS" Width="100%" GridLines="None">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="ID_CONTATO" DataNavigateUrlFormatString="Contatos_Ficha.aspx?ID={0}" DataTextField="ID_CONTATO" HeaderText="ID" />
            <asp:BoundField DataField="STATUS_ATIVO" HeaderText="Status" SortExpression="STATUS_ATIVO" />
            <asp:BoundField DataField="NOME" HeaderText="Nome" SortExpression="NOME">
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="AREA" HeaderText="Área" SortExpression="AREA" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="CARGO" HeaderText="Cargo" SortExpression="CARGO" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="TELEFONE" HeaderText="Telefone" SortExpression="TELEFONE" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="CELULAR" HeaderText="Celular" SortExpression="CELULAR" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="VISITAS_ANO_ATUAL" HeaderText="Visitas Neste Ano" SortExpression="VISITAS_ANO_ATUAL">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="VISITAS_MES_ATUAL" HeaderText="Visitas Neste Mês" SortExpression="VISITAS_MES_ATUAL">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="NOME,ID_CONTATO,STATUS_ATIVO" DataNavigateUrlFormatString="Visitas_Incluir.aspx?NOME={0}&amp;TIPO=2&amp;ID={1}&amp;STATUS_ATIVO={2}" FooterText="visitar" Text="Visitar" Visible="False" />
        </Columns>
    </asp:GridView>
    <br />
    <!--<b>Lista das Ultimas 50 Visitas </b>-->
    <br />
    <asp:GridView ID="gdv_VISITAS" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID_VISITA" DataSourceID="dts_VISITAS" Width="100%" GridLines="None" Visible="False">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="ID_VISITA" DataNavigateUrlFormatString="Visita_Ficha.aspx?ID_VISITA={0}&amp;PAGINA=1" DataTextField="ID_VISITA" HeaderText="ID" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:HyperLinkField>
            <asp:BoundField DataField="DATA" HeaderText="Data" SortExpression="DATA" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="PERIODO" HeaderText="Período" SortExpression="PERIODO" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="NOME" HeaderText="Visitado" ReadOnly="True" SortExpression="NOME">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="PROXIMA_VISITA" HeaderText="Próxima Visita" SortExpression="PROXIMA_VISITA" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    <br />
</div>
    <asp:SqlDataSource ID="dts_Estabelecimento" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS] WHERE ([CNPJ] = @CNPJ)">
        <SelectParameters>
            <asp:SessionParameter Name="CNPJ" SessionField="CNPJ" Type="Decimal" />  
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_VISITAS" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT TOP(50) [ID_VISITA], [DATA], [PERIODO], [STATUS_VISITA], [NOME], [PROXIMA_VISITA] FROM [VIEW_VISITAS_GERAL] WHERE ([CNPJ] = @CNPJ) ORDER BY [DATA] DESC, [ID_PERIODO]">
        <SelectParameters>
            <asp:QueryStringParameter Name="CNPJ" QueryStringField="CNPJ" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_CONTATOS" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_CONTATOS] WHERE ([CNPJ_ESTABELECIMENTO] = @CNPJ_ESTABELECIMENTO) ORDER BY [NOME], [STATUS_ATIVO]">
        <SelectParameters>
            <asp:QueryStringParameter Name="CNPJ_ESTABELECIMENTO" QueryStringField="CNPJ" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Medicos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_MEDICOS_ESTABELECIMENTOS] WHERE ([CNPJ] = @CNPJ) AND ([ATIVO_MEDICO_NO_ESTABELECIMENTO] = 'SIM') ORDER BY [NOME]">
        <SelectParameters>
            <asp:SessionParameter Name="CNPJ" SessionField="CNPJ" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
</form>
</body>
</html>