<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Usuarios_Localizacao.aspx.vb" Inherits="Usuarios_Localizacao" EnableEventValidation ="false"%>
<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Usuários</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Cabecalho runat="server" id="Cabecalho" />
        <div id="Titulo_Pagina">
            <div id ="Titulo_Pagina_Cabecalho">USUÁRIOS</div>
            <div id ="Titulo_Pagina_Links">
            <asp:HyperLink ID="lnk_Novo" runat="server" NavigateUrl="~/Usuarios_Incluir.aspx">Incluir</asp:HyperLink>
            </div>
        </div>
        <br />
        <div id="Corpo">
            <asp:GridView ID="gdv_Localizar" runat="server" AutoGenerateColumns="False" 
                DataSourceID="dts_USUARIOS" DataKeyNames="EMAIL" AllowSorting="True" Width="100%">
                <Columns>
                    <asp:ButtonField CommandName="Select" DataTextField="NOME" HeaderText="Nome" ShowHeader="True" Text="Nome" SortExpression="NOME">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:ButtonField>
                    <asp:TemplateField HeaderText="Email" SortExpression="EMAIL">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("EMAIL") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("EMAIL", "mailto:{0}")%>' Text='<%# Eval("EMAIL")%>'></asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:TemplateField>
                    
                    
                    <asp:BoundField DataField="TELEFONE" HeaderText="Tel. Celular" SortExpression="TELEFONE">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FIXO" HeaderText="Tel. Comercial" SortExpression="FIXO">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PERFIL" HeaderText="Perfil" SortExpression="PERFIL">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="COORDENADOR" HeaderText="Ger Distrital" SortExpression="COORDENADOR" >
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="GERENTE" HeaderText="Ger Regional" SortExpression="GERENTE" >
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DIRETOR" HeaderText="Ger Nacional" SortExpression="DIRETOR">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ATIVO_STATUS" HeaderText="Status" SortExpression="ATIVO_STATUS" >
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="BLOQUEADO_STATUS" HeaderText="Bloqueado" SortExpression="BLOQUEADO_STATUS" >
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LOGIN_STATUS" HeaderText="Login" SortExpression="LOGIN_STATUS">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                </Columns>
                <HeaderStyle 
                    HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:GridView>
        </div>
    </form>
    <asp:SqlDataSource ID="dts_USUARIOS" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            SelectCommand="SELECT * FROM VIEW_USUARIOS ORDER BY [NOME]">
        </asp:SqlDataSource>    
</body>
</html>
