<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Contatos_Lista.aspx.vb" Inherits="Contatos_Lista" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Meus Contatos</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Contatos (Desativado. Somente consulta.)</div>
    <div id ="Titulo_Pagina_Links">
        <asp:LinkButton ID="cmd_Excel" runat="server">Exportar para Excel</asp:LinkButton>
    </div>
</div>
<br />
<div id ="Corpo">
    <br />
    Selecione o Status do Contato
    <asp:DropDownList ID="cmb_ativo" runat="server" AutoPostBack="True" DataSourceID="dts_Contatos_Ativo" DataTextField="STATUS_ATIVO" DataValueField="STATUS_ATIVO">
        <asp:ListItem Selected="True" Value="ATIVO">Ativo</asp:ListItem>
        <asp:ListItem Value="INATIVO">Inativo</asp:ListItem>
    </asp:DropDownList>
    <br /><br />
        <asp:SqlDataSource ID="dts_Contatos_Ativo" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT DISTINCT STATUS_ATIVO FROM VIEW_CONTATOS"></asp:SqlDataSource>
        <asp:GridView ID="gdv_CONTATOS" runat="server" AutoGenerateColumns="False" DataSourceID="dts_Contatos" Width="100%" AllowSorting="True">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="ID_CONTATO,CNPJ_ESTABELECIMENTO" DataNavigateUrlFormatString="Contatos_Ficha.aspx?ID={0}&amp;CNPJ={1}" DataTextField="NOME" HeaderText="Nome" SortExpression="NOME" Target="_blank" >
                <HeaderStyle HorizontalAlign="Center" Width="25%" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="25%" />
                </asp:HyperLinkField>
                <asp:BoundField DataField="ESTABELECIMENTO" HeaderText="Estabelecimento" ReadOnly="True" SortExpression="ESTABELECIMENTO" >
                <HeaderStyle Width="35%" />
                <ItemStyle HorizontalAlign="Left" Width="35%" />
                </asp:BoundField>
                <asp:BoundField DataField="TELEFONE" HeaderText="Telefone" SortExpression="TELEFONE" >
                <HeaderStyle Width="20%" />
                <ItemStyle Width="20%" />
                </asp:BoundField>
                <asp:BoundField DataField="CELULAR" HeaderText="Celular" SortExpression="CELULAR" >
                <HeaderStyle Width="20%" />
                <ItemStyle Width="20%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Email" SortExpression="EMAIL">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("EMAIL") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("EMAIL", "mailto:{0}")%>' Text='<%# Eval("EMAIL")%>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="VISITAS_ANO_ATUAL" HeaderText="Visitas Ano Atual" SortExpression="VISITAS_ANO_ATUAL">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="VISITAS_MES_ATUAL" HeaderText="Visitas Mês Atual" SortExpression="VISITAS_MES_ATUAL">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="dts_Contatos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_CONTATOS] WHERE ([STATUS_ATIVO] = @STATUS_ATIVO) ORDER BY [NOME]">
            <SelectParameters>
                <asp:ControlParameter ControlID="cmb_ativo" Name="STATUS_ATIVO" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
    </asp:SqlDataSource>
    </div>
</form>
</body>  
</html>
