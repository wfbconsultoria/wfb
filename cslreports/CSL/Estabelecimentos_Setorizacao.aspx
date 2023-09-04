<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Estabelecimentos_Setorizacao.aspx.vb" Inherits="Estabelecimentos_Setorizacao" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Setorização de Estabelecimentos</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>

<form id="form1" runat="server">
    <uc1:Cabecalho runat="server" id="Cabecalho" />
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Setorização</div>
    <div id ="Titulo_Pagina_Links">
        &nbsp;<a href="Estabelecimentos_Ficha.aspx?CNPJ=<%=Request.QueryString("CNPJ")%>">Voltar</a>
    </div>
</div>
<br />
<div id ="Corpo">
    <br/>
    <asp:FormView ID="frm_Estabelecimento_Ficha" runat="server" DataSourceID="dts_Estabelecimento" Width="100%">
        <EditItemTemplate></EditItemTemplate>
        <InsertItemTemplate></InsertItemTemplate>
        <ItemTemplate>
            <asp:Label ID="ESTABELECIMENTOLabel" runat="server" Text='<%# Bind("ESTABELECIMENTO_CNPJ") %>' style="font-weight: 700" />
        </ItemTemplate>
     </asp:FormView>
    <br />
    <strong>Para Incluir</strong><br />
    Selecione o Representante
    <asp:DropDownList ID="cmb_Representante" runat="server" DataSourceID="dts_Representantes" DataTextField="NOME" DataValueField="EMAIL" AutoPostBack="True"></asp:DropDownList>
    <br />
    Se o cliente é TARGET &nbsp;
    <asp:DropDownList ID="cmb_TARGET" runat="server" SelectedValue='<%# Bind("TARGET") %>'>
        <asp:ListItem Value="0">NÃO</asp:ListItem>
        <asp:ListItem Value="1">SIM</asp:ListItem>
    </asp:DropDownList>
    <br />
    Clique em <asp:Button ID="cmd_Setorizar" runat="server" Text="Setorizar"  CssClass="buton_gravar" />
    <br /><br />
    <strong>Para Alterar ou Excluir
    </strong>
    <br />
    Efetue a manutenção na lista abaixo 
     <br />
    Clique em <asp:Button ID="cmd_gravar" runat="server" Text="Gravar"  CssClass="buton_gravar" />
    <br /><br />
    <asp:GridView ID="gdv_Localizar" runat="server" AutoGenerateColumns="False" DataSourceID="dts_Setorizacao" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="Representante" SortExpression="EMAIL_REPRESENTANTE">
                <ItemTemplate>
                    <asp:DropDownList ID="cmb_EMAIL_REPRESENTANTE" runat="server" DataSourceID="dts_Representantes" DataTextField="NOME" DataValueField="EMAIL" Enabled="False" SelectedValue='<%# Bind("EMAIL_REPRESENTANTE") %>'>
                    </asp:DropDownList>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Target" SortExpression="TARGET">
                <ItemTemplate>
                    <asp:DropDownList ID="cmb_TARGET" runat="server" DataSourceID="dts_Ativo" DataTextField="DESCRICAO" DataValueField="ATIVO" SelectedValue='<%# Bind("TARGET") %>' AutoPostBack="True">
                        <asp:ListItem Value="1">SIM</asp:ListItem>
                        <asp:ListItem Value="0">NÃO</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:BoundField DataField="INCLUSAO" HeaderText="Inclusão" ReadOnly="True" SortExpression="INCLUSAO" >
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Excluir">
                <ItemTemplate>
                    <asp:CheckBox ID="chk_Excluir" runat="server" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
    <asp:SqlDataSource ID="dts_Setorizacao" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_SETORIZACAO] WHERE ([CNPJ] = @CNPJ) ORDER BY [REPRESENTANTE]">
        <SelectParameters>
            <asp:SessionParameter Name="CNPJ" SessionField="CNPJ" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Representantes" runat="server" 
    ConnectionString="<%$ ConnectionStrings:cnnStr %>"
    SelectCommand="SELECT * FROM [VIEW_USUARIOS] WHERE (([ATIVO] = @ATIVO) AND ([BLOQUEADO] = @BLOQUEADO) AND ([COD_PERFIL] = @COD_PERFIL))">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="ATIVO" Type="Boolean" />
            <asp:Parameter DefaultValue="False" Name="BLOQUEADO" Type="Boolean" />
            <asp:Parameter DefaultValue="4" Name="COD_PERFIL" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Ativo" runat="server" 
    ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
    SelectCommand="SELECT * FROM [TBL_ATIVO] ORDER BY [STATUS]">
    </asp:SqlDataSource>

   <asp:SqlDataSource ID="dts_Estabelecimento" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS_001_DETALHADO] WHERE ([CNPJ] = @CNPJ)">
        <SelectParameters>
            <asp:SessionParameter Name="CNPJ" SessionField="CNPJ" Type="Decimal" />  
        </SelectParameters>
    </asp:SqlDataSource>
</form>
</body>
</html>