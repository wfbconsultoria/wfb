<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Medicos_Lista.aspx.vb" Inherits="Medicos_Lista" EnableEventValidation ="false" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Meus Médicos</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Médicos (Desativado. Somente consulta.)</div>
    <div id ="Titulo_Pagina_Links">
        <asp:LinkButton ID="cmd_Excel" runat="server">Exportar para Excel</asp:LinkButton>
    </div>
</div>

<div id ="Corpo">
    <br /><br />
        <asp:GridView ID="gdv_Localizar" runat="server" AutoGenerateColumns="False" 
            DataSourceID="dts_Localizar" Width="100%" HorizontalAlign="Center" AllowSorting="True">
            <RowStyle VerticalAlign="Middle" 
                HorizontalAlign="Center" />
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="ID_MEDICO_ESTABELECIMENTO,CNPJ,CRMUF" DataNavigateUrlFormatString="Medicos_Ficha.aspx?ID_MEDICO_ESTABELECIMENTO={0}&amp;CNPJ={1}&amp;CRMUF={2}&amp;PAGINA=2" DataTextField="MEDICO" HeaderText="Médico" SortExpression="MEDICO" Target="_blank">
                <HeaderStyle HorizontalAlign="Center" Width="40%" />
                <ItemStyle HorizontalAlign="Left" Width="40%" />
                </asp:HyperLinkField>

                <asp:BoundField DataField="ESTABELECIMENTO" HeaderText="Estabelecimento" 
                    SortExpression="ESTABELECIMENTO">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30%" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30%" />
                </asp:BoundField>
                <asp:BoundField DataField="TELEFONE_MEDICO" HeaderText="Telefone" 
                    SortExpression="TELEFONE_MEDICO">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"  />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"  />
                </asp:BoundField>
                <asp:BoundField DataField="CELULAR_MEDICO" HeaderText="Celular" 
                    SortExpression="CELULAR_MEDICO">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"  />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"  />
                </asp:BoundField>
                <asp:TemplateField HeaderText="E-mail" SortExpression="EMAIL_MEDICO">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("EMAIL_MEDICO", "mailto:{0}") %>' Text='<%# Eval("EMAIL_MEDICO") %>'></asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle Font-Size="Small" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="VISITAS_ANO_ATUAL" HeaderText="Visitas Ano Atual" SortExpression="VISITAS_ANO_ATUAL">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="VISITAS_MES_ATUAL" HeaderText="Visitas Mês Atual" SortExpression="VISITAS_MES_ATUAL">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
            </Columns>
            <HeaderStyle 
                HorizontalAlign="Left" VerticalAlign="Middle" />
        </asp:GridView>
    </div>
    
</form><asp:SqlDataSource ID="dts_Localizar" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [VIEW_MEDICOS_ESTABELECIMENTOS] WHERE ([ATIVO_MEDICO_NO_ESTABELECIMENTO] = 'SIM') ORDER BY [MEDICO], [ESTABELECIMENTO]">
    </asp:SqlDataSource>
    
</body>  
</html>
