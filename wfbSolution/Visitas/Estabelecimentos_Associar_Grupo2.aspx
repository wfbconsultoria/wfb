<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Estabelecimentos_Associar_Grupo2.aspx.vb" Inherits="Estabelecimentos_Associar_Grupo2" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Setorização</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Associar Grupo 2</div>
    <div id ="Titulo_Pagina_Links">
         <asp:LinkButton ID="cmd_Excel" runat="server">Exportar para Excel</asp:LinkButton>
    </div>
</div>
<br />
<div id ="Corpo">
    <br />
    Estado
    <br />
    <asp:DropDownList ID="cmb_ESTADO" runat="server" AutoPostBack="True" DataSourceID="dts_ESTADO" DataTextField="DESCRICAO" DataValueField="UF">
    </asp:DropDownList>
    <br />
    Municipio
    <br />
    <asp:DropDownList ID="cmb_MUNICIPIO" runat="server" AutoPostBack="True" DataSourceID="dts_MUNICIPIO" DataTextField="MUNICIPIO_DESC" DataValueField="MUNICIPIO">
    </asp:DropDownList>
    <br />
    Esfera Administrativa
    <br />
    <asp:DropDownList ID="cmb_ESFERA" runat="server" AutoPostBack="True" DataSourceID="dts_Esfera" DataTextField="ESFERA_DESC" DataValueField="ESFERA">
    </asp:DropDownList>
    <br />
    <br />
     Efetue todas as alterações e clique em <strong>Gravar</strong>
                    
               e aguarde o final da atualização.
    <br /><asp:Button ID="cmd_Gravar" CssClass="buton_gravar" runat="server" Text="Gravar" />
    <br />
    <br />
<asp:GridView ID="gdv_Localizar" runat="server" AutoGenerateColumns="False" 
            DataSourceID="dts_Localizar" Width="100%" DataKeyNames="CNPJ" HorizontalAlign="Left" Font-Size="Medium" GridLines="None" AllowSorting="True">
            <RowStyle VerticalAlign="Middle" HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField DataField="CNPJ" HeaderText="CNPJ" SortExpression="CNPJ" >
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="ESTABELECIMENTO" HeaderText="Estabelecimento" 
                    SortExpression="ESTABELECIMENTO" ReadOnly="True" >
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="MUNICIPIO" HeaderText="Municipio" SortExpression="MUNICIPIO" />
                <asp:BoundField DataField="UF" HeaderText="Estado" SortExpression="UF" />
                <asp:BoundField DataField="GRUPO" HeaderText="GRUPO" 
                    SortExpression="GRUPO" >
                </asp:BoundField>
                <asp:TemplateField HeaderText="Grupo 2" SortExpression="COD_GRUPO2">
                    <ItemTemplate>
                        <asp:DropDownList ID="cmb_GRUPO2" runat="server" DataSourceID="dts_GRUPO2" DataTextField="GRUPO2" DataValueField="COD_GRUPO2" SelectedValue='<%# Bind("COD_GRUPO2") %>'>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle 
                HorizontalAlign="Left" VerticalAlign="Middle" />
        </asp:GridView>
    <br />
    </div>

<asp:SqlDataSource ID="dts_Usuarios" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>"
            SelectCommand="SELECT * FROM [TBL_USUARIOS] WHERE (([ATIVO] = @ATIVO) AND ([BLOQUEADO] = @BLOQUEADO) AND ([PERFIL] = @PERFIL))">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="ATIVO" Type="Boolean" />
                <asp:Parameter DefaultValue="False" Name="BLOQUEADO" Type="Boolean" />
                <asp:Parameter DefaultValue="Representante" Name="PERFIL" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Esfera" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT '@' AS ESFERA, '@ Todos' AS ESFERA_DESC UNION ALL SELECT DISTINCT [ESFERA] AS ESFERA, [ESFERA] AS ESFERA_DESC FROM [VIEW_ESTABELECIMENTOS_001_DETALHADO] ORDER BY [ESFERA]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_ESTADO" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT '@' AS UF, '@ Todos' AS DESCRICAO UNION ALL SELECT DISTINCT [UF] AS UF, [UF] AS DESCRICAO FROM [VIEW_ESTABELECIMENTOS_001_DETALHADO] ORDER BY [UF]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_MUNICIPIO" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT '@' AS MUNICIPIO, '@ Todos' AS MUNICIPIO_DESC UNION ALL SELECT DISTINCT [MUNICIPIO] AS MUNICIPIO, [MUNICIPIO] AS MUNICIPIO_DESC FROM [VIEW_ESTABELECIMENTOS_001_DETALHADO] ORDER BY [MUNICIPIO]"> </asp:SqlDataSource>
<asp:SqlDataSource ID="dts_Localizar" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            
            SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS_001_DETALHADO]" 
            OldValuesParameterFormatString="original_{0}">
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_GRUPO2" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_ESTABELECIMENTOS_GRUPOS2]"></asp:SqlDataSource>

</form>
</body>
</html>