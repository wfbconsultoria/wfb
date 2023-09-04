<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Estabelecimentos_Ficha_Contatos.aspx.vb" Inherits="Estabelecimentos_Ficha_Contatos" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            color: #FF0000;
        }
        .auto-style2 {
            color: #808080;
        }
        .auto-style3 {
            font-weight: bold;
        }
    </style>
    </head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho"></div>
    <div id ="Titulo_Pagina_Links">
        <% If Request.QueryString("ORFAO") <> "True" Then%>
            &nbsp;<a href="Estabelecimentos_Editar.aspx?CNPJ=<%=Request.QueryString("CNPJ")%>">Alterar</a>
        <% End If%>
        &nbsp;<a href="Estabelecimentos_Ficha.aspx?CNPJ=<%=Request.QueryString("CNPJ")%>">Ficha do Estabelecimento</a>
        &nbsp;<a href="Estabelecimentos_Ficha_Report.aspx?CNPJ=<%=Request.QueryString("CNPJ")%>">Relatório do Estabelecimento</a>
        <!--&nbsp;<a href="Estabelecimentos_Setorizacao.aspx?CNPJ=<%=Request.QueryString("CNPJ")%>">Setorização</a>-->
    </div>
</div>
<br />
<div id ="Corpo">
    <asp:FormView ID="frm_Estabelecimento_Ficha" runat="server" DataSourceID="dts_Estabelecimento" Width="100%">
        <EditItemTemplate></EditItemTemplate>
        <InsertItemTemplate></InsertItemTemplate>
        <ItemTemplate>
            <span class="auto-style2"><b>Ficha de Pessoa </b>
            <asp:Label ID="TIPO_PESSOA_Label" runat="server" CssClass="auto-style3" Text='<%# Bind("TIPO_PESSOA")%>' />
            </span>
            <br />
            <asp:Label ID="GRUPO_ESTABELECIMENTO_Label" runat="server" style="font-weight: 700" Text='<%# Bind("GRUPO_ESTABELECIMENTO") %>' />
            <br />
            <asp:Label ID="ESTABELECIMENTO_Label" runat="server" style="font-weight: 700" Text='<%# Bind("ESTABELECIMENTO") %>' />
            <br />
            <asp:Label ID="RAZAO_SOCIAL_Label" runat="server" Text='<%# Bind("RAZAO_SOCIAL") %>' />
            <br />
            <asp:Label ID="ENDERECO_Label" runat="server" Text='<%# Bind("ENDERECO") %>' />
            &nbsp;-
            <asp:Label ID="BAIRRO_Label" runat="server" Text='<%# Bind("BAIRRO") %>' />
            <br />
            <asp:Label ID="MUNICIPIO_Label" runat="server" Text='<%# Bind("MUNICIPIO") %>' />
            &nbsp;-
            <asp:Label ID="UF_Label" runat="server" Text='<%# Bind("UF") %>' />
            <br />
            Documento
            <asp:Label ID="CNPJ_FORMATADO_Label" runat="server" Text='<%# Bind("CNPJ_FORMATADO") %>' />
            <br />
        </ItemTemplate>
     </asp:FormView>
    <hr />
    <b>Atendido por</b>
    <br /> 
    <asp:GridView ID="gdv_Setorizacao" runat="server" AutoGenerateColumns="False" DataSourceID="dts_Setorizacao" Width="100%" AllowSorting="True">
        <Columns>
            <asp:BoundField DataField="REPRESENTANTE" HeaderText="Representante" ReadOnly="True" SortExpression="REPRESENTANTE" >
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="INCLUSAO" HeaderText="Incluido por" ReadOnly="True" SortExpression="INCLUSAO" >
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
        </Columns>
        <EmptyDataTemplate>
            <span class="auto-style1"><strong>Nenhum Representante</strong></span>
        </EmptyDataTemplate>
    </asp:GridView>
    <br />
    <br />
    <b>Contatos</b>
    <% If Request.QueryString("ORFAO") <> "True" Then%>
        <a href="Contatos_Incluir.aspx?CNPJ=<%=Request.QueryString("CNPJ")%>">&nbsp Incluir</a>
    <% End If%>
    <br />
    <asp:GridView ID="gdv_CONTATOS" runat="server" AutoGenerateColumns="False" DataKeyNames="COD_CONTATO" DataSourceID="dts_CONTATOS" Width="100%" AllowSorting="True">
        <Columns>
                            <asp:HyperLinkField DataNavigateUrlFields="NOME,COD_CONTATO,CNPJ,ID_TIPO_CONTATO,ATIVO" DataNavigateUrlFormatString="Visitas_Incluir.aspx?NOME={0}&amp;COD_CONTATO={1}&amp;CNPJ={2}&amp;TIPO={3}&amp;ATIVO={4}" FooterText="visitar" Text="Visitar" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:HyperLinkField>
                            <asp:HyperLinkField DataNavigateUrlFields="COD_CONTATO,CNPJ" DataNavigateUrlFormatString="Contatos_Ficha_Estabelecimento.aspx?COD_CONTATO={0}&amp;CNPJ={1}" DataTextField="NOME" HeaderText="Nome" >
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:HyperLinkField>
                            <asp:BoundField DataField="TIPO_CONTATO" HeaderText="Tipo de Contato" SortExpression="TIPO_CONTATO">
                            </asp:BoundField>
                            <asp:BoundField DataField="STATUS" HeaderText="Status" SortExpression="STATUS" >
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AREA_ESTABELECIMENTO" HeaderText="Área" SortExpression="AREA_ESTABELECIMENTO" >
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CARGO_ESTABELECIMENTO" HeaderText="Cargo" SortExpression="CARGO_ESTABELECIMENTO" >
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TELEFONE" HeaderText="Telefone" SortExpression="TELEFONE" >
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CELULAR" HeaderText="Celular" SortExpression="CELULAR" >
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:BoundField>
                        </Columns>
    </asp:GridView>
    <br />
    <b>Visitas</b><br />
    <asp:GridView ID="gdv_Visitas_Contatos" runat="server" AutoGenerateColumns="False" DataSourceID="dts_Visitas_Contatos" Width="100%" AllowSorting="True">
        <Columns>
            <asp:HyperLinkField DataTextField="ID_VISITA" HeaderText="ID" DataNavigateUrlFields="ID_VISITA,COD_CONTATO,CNPJ_ESTABELECIMENTO" DataNavigateUrlFormatString="Visita_Ficha.aspx?ID_VISITA={0}&amp;COD_CONTATO={1}&amp;CNPJ={2}">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:HyperLinkField>
            <asp:BoundField DataField="DATA_EXTENSO" HeaderText="Data" ReadOnly="True" SortExpression="DATA_EXTENSO">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="NOME" HeaderText="Nome" SortExpression="NOME">
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="OBJETIVO" HeaderText="Objetivo" SortExpression="OBJETIVO">
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="PRODUTO_LINHA" HeaderText="Produto Foco" SortExpression="PRODUTO_LINHA">
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="COMENTARIOS" HeaderText="Comentarios" SortExpression="COMENTARIOS">
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="DATA_PROXIMA_EXTENSO" HeaderText="Proxima Visita" SortExpression="DATA_PROXIMA_EXTENSO">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    <br />
</div>
    <asp:SqlDataSource ID="dts_CONTATOS" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_CONTATOS_ESTABELECIMENTOS] WHERE (([CNPJ] = @CNPJ) AND ([ATIVO_ESTABELECIMENTO] = @ATIVO_ESTABELECIMENTO)) ORDER BY [NOME]">
        <SelectParameters>
            <asp:QueryStringParameter Name="CNPJ" QueryStringField="CNPJ" Type="Decimal" />
            <asp:Parameter DefaultValue="True" Name="ATIVO_ESTABELECIMENTO" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Estabelecimento" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS_001_DETALHADO] WHERE ([CNPJ] = @CNPJ)">
        <SelectParameters>
            <asp:QueryStringParameter Name="CNPJ" QueryStringField="CNPJ" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Target_Ativo" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_ATIVO]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Setorizacao" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [VIEW_SETORIZACAO] WHERE ([CNPJ] = @CNPJ) ORDER BY [REPRESENTANTE]">
        <SelectParameters>
            <asp:QueryStringParameter Name="CNPJ" QueryStringField="CNPJ" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource> 
    <rsweb:ReportViewer ID="rpt_Report" runat="server">
    </rsweb:ReportViewer>
    <asp:SqlDataSource ID="dts_Visitas_Contatos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_VISITAS] WHERE (([CNPJ_ESTABELECIMENTO] = @CNPJ_ESTABELECIMENTO) AND ([EMAIL_VISITANTE] = @EMAIL_VISITANTE)) ORDER BY [DATA_VALOR] DESC">
        <SelectParameters>
            <asp:QueryStringParameter Name="CNPJ_ESTABELECIMENTO" QueryStringField="CNPJ" Type="Decimal" />
            <asp:SessionParameter Name="EMAIL_VISITANTE" SessionField="EMAIL_LOGIN" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</form> 
</body>
    
</html>