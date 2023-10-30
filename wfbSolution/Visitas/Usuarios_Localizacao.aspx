<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Usuarios_Localizacao.aspx.vb" Inherits="Usuarios_Localizacao" EnableEventValidation ="false"%>
<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Usuarios</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Cabecalho runat="server" id="Cabecalho" />
        <div id="Titulo_Pagina">
            <div id ="Titulo_Pagina_Cabecalho">Administrar Usuários</div>
            <div id ="Titulo_Pagina_Links">
                <asp:HyperLink ID="lnk_Novo" runat="server" NavigateUrl="~/Usuarios_Incluir.aspx">Incluir</asp:HyperLink>&nbsp
                <asp:LinkButton ID="cmd_Excel" runat="server">Exportar para Excel</asp:LinkButton>
            </div>
        </div>
        <br />
        <div id="Corpo">
            <br />
            <asp:GridView ID="gdv_Localizar" runat="server" AutoGenerateColumns="False" 
                DataSourceID="dts_USUARIOS" DataKeyNames="EMAIL" AllowSorting="True" GridLines="None">
                <Columns>
                    <asp:ButtonField CommandName="Select" DataTextField="USUARIO" HeaderText="Nome" ShowHeader="True" Text="NOME" SortExpression="USUARIO">
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:ButtonField>
                    <asp:BoundField DataField="EMAIL" HeaderText="E-Mail" SortExpression="EMAIL">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TELEFONE" HeaderText="Telefone" SortExpression="TELEFONE">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PERFIL" HeaderText="Perfil" SortExpression="PERFIL">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="GERENTE" HeaderText="Regional" SortExpression="GERENTE">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DIRETOR" HeaderText="Nacional" SortExpression="DIRETOR">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TERRITORIO" HeaderText="Território" SortExpression="TERRITORIO" />
                    <asp:BoundField DataField="STATUS" HeaderText="Status" SortExpression="STATUS">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                </Columns>
                <HeaderStyle 
                    HorizontalAlign="Center" VerticalAlign="Middle" Width="100%" />
                <RowStyle VerticalAlign="Middle" />
            </asp:GridView>
        </div>
    </form>
    <asp:SqlDataSource ID="dts_USUARIOS" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            SelectCommand="SELECT * FROM VIEW_USUARIOS ORDER BY [NOME]">
        </asp:SqlDataSource>    
</body>
</html>
