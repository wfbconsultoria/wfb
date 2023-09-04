<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Estabelecimentos_Setorizacao_NS.aspx.vb" Inherits="Estabelecimentos_Setorizacao_NS" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    </head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Setorização de Órfãos</div>
    <div id ="Titulo_Pagina_Links">
        <a href="Menu_Setorizacao.aspx">Menu Setorização</a>
    </div>
</div>
<br />
<div id ="Corpo">
    <br />
    <b>Efetue as alterações e clique em</b> &nbsp; <asp:Button ID="cmd_Gravar" runat="server" Text="Gravar" />
    <br />
    <br />
    <b>Filtros de Pesquisa</b>
    <br />
    Estado
    <br />
    <asp:DropDownList ID="cmb_ESTADO" runat="server" DataSourceID="dts_ESTADO" DataTextField="UF_DESC" DataValueField="UF" AutoPostBack="True"></asp:DropDownList>
    <br />
    Municipio
    <br />
    <asp:DropDownList ID="cmb_MUNICIPIO" runat="server" DataSourceID="dts_MUNICIPIO" DataTextField="MUNICIPIO_DESC" DataValueField="MUNICIPIO" AutoPostBack="True"></asp:DropDownList>
    <br />
    Esfera Administrativa
    <br />
    <asp:DropDownList ID="cmb_ESFERA" runat="server" DataSourceID="dts_Esfera" DataTextField="ESFERA_ADMINISTRATIVA" DataValueField="ESFERA" AutoPostBack="True"></asp:DropDownList> 
    <br /><br />
    <asp:GridView ID="gdv_Localizar" runat="server" AutoGenerateColumns="False" 
    DataSourceID="dts_Localizar" Width="100%" DataKeyNames="CNPJ" HorizontalAlign="Left" AllowSorting="True">
        <RowStyle VerticalAlign="Middle" HorizontalAlign="Left" />
        <Columns>
            <asp:BoundField DataField="CNPJ" HeaderText="CNPJ" SortExpression="CNPJ" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="ESTABELECIMENTO" HeaderText="Estabelecimento" SortExpression="ESTABELECIMENTO" ReadOnly="True" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="ESFERA" HeaderText="Esfera ADM" SortExpression="ESFERA" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="MUNICIPIO" HeaderText="Municipio" SortExpression="MUNICIPIO" />
            <asp:BoundField DataField="UF" HeaderText="UF" SortExpression="UF" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Target" SortExpression="TARGET">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="cmb_TARGET" runat="server" DataSourceID="dts_Ativo" DataTextField="DESCRICAO" DataValueField="ATIVO">
                        <asp:ListItem Value="0">NÃO</asp:ListItem>
                       <asp:ListItem Value="1">SIM</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Representante" SortExpression="EMAIL_REPRESENTANTE">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="cmb_EMAIL_REPRESENTANTE" runat="server" 
                    DataSourceID="dts_Usuarios" DataTextField="NOME" DataValueField="EMAIL">
                    </asp:DropDownList>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:TemplateField>
        </Columns>
        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Names="Calibri" />
    </asp:GridView>
    <br />
</div>

    <asp:SqlDataSource ID="dts_Usuarios" runat="server" 
    ConnectionString="<%$ ConnectionStrings:cnnStr %>"
    SelectCommand="SELECT * FROM [VIEW_USUARIOS] WHERE ([COD_PERFIL] = @COD_PERFIL) and ATIVO = 1">
        <SelectParameters>
            <asp:Parameter DefaultValue="4" Name="COD_PERFIL" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Localizar" runat="server" 
    ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
    SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS_001_DETALHADO_ORFAOS]" 
    OldValuesParameterFormatString="original_{0}">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Editar" runat="server" 
    ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
    SelectCommand="SELECT * FROM [TBL_SETORIZACAO] WHERE ([CNPJ] = @CNPJ)" 
    OldValuesParameterFormatString="original_{0}" 
    DeleteCommand="DELETE FROM [TBL_SETORIZACAO] WHERE [CNPJ] = @original_CNPJ" 
    InsertCommand="INSERT INTO [TBL_SETORIZACAO] ([EMAIL], [CNPJ], [TARGET], [INCLUSAO_EMAIL], [INCLUSAO_DATA], [ALTERACAO_EMAIL], [ALTERACAO_DATA], [EXCLUSAO_EMAIL], [EXCLUSAO_DATA], [EXCLUIDO]) VALUES (@EMAIL, @CNPJ, @TARGET, @INCLUSAO_EMAIL, @INCLUSAO_DATA, @ALTERACAO_EMAIL, @ALTERACAO_DATA, @EXCLUSAO_EMAIL, @EXCLUSAO_DATA, @EXCLUIDO)" 
    UpdateCommand="UPDATE [TBL_SETORIZACAO] SET [EMAIL] = @EMAIL, [TARGET] = @TARGET, [INCLUSAO_EMAIL] = @INCLUSAO_EMAIL, [INCLUSAO_DATA] = @INCLUSAO_DATA, [ALTERACAO_EMAIL] = @ALTERACAO_EMAIL, [ALTERACAO_DATA] = @ALTERACAO_DATA, [EXCLUSAO_EMAIL] = @EXCLUSAO_EMAIL, [EXCLUSAO_DATA] = @EXCLUSAO_DATA, [EXCLUIDO] = @EXCLUIDO WHERE [CNPJ] = @original_CNPJ">
        <DeleteParameters>
            <asp:Parameter Name="original_CNPJ" Type="Decimal" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="EMAIL" Type="String" />                
            <asp:Parameter Name="CNPJ" Type="Decimal" />                
            <asp:Parameter Name="TARGET" Type="String" />                
            <asp:Parameter Name="INCLUSAO_EMAIL" Type="String" />                            
            <asp:Parameter Name="INCLUSAO_DATA" Type="Decimal" />                            
            <asp:Parameter Name="ALTERACAO_EMAIL" Type="String" />                            
            <asp:Parameter Name="ALTERACAO_DATA" Type="Decimal" />                            
            <asp:Parameter Name="EXCLUSAO_EMAIL" Type="String" />                            
            <asp:Parameter Name="EXCLUSAO_DATA" Type="Decimal" />              
            <asp:Parameter Name="EXCLUIDO" Type="String" />
        </InsertParameters> 
        <SelectParameters>
            <asp:ControlParameter ControlID="gdv_Localizar" 
            Name="CNPJ" PropertyName="SelectedValue" Type="Decimal" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="EMAIL" Type="String" />
            <asp:Parameter Name="TARGET" Type="String" />
            <asp:Parameter Name="INCLUSAO_EMAIL" Type="String" />
            <asp:Parameter Name="INCLUSAO_DATA" Type="Decimal" />
            <asp:Parameter Name="ALTERACAO_EMAIL" Type="String" />
            <asp:Parameter Name="ALTERACAO_DATA" Type="Decimal" />
            <asp:Parameter Name="EXCLUSAO_EMAIL" Type="String" />
            <asp:Parameter Name="EXCLUSAO_DATA" Type="Decimal" />
            <asp:Parameter Name="EXCLUIDO" Type="String" />
            <asp:Parameter Name="original_CNPJ" Type="Decimal" />
        </UpdateParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Ativo" runat="server" 
    ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
    SelectCommand="SELECT * FROM [TBL_ATIVO] ORDER BY [STATUS] DESC">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Esfera" runat="server" 
    ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
    SelectCommand="SELECT '@' AS ESFERA, '# Todos' as ESFERA_ADMINISTRATIVA UNION ALL
    SELECT DISTINCT ESFERA AS ESFERA , ESFERA  AS ESFERA_ADMINISTRATIVA 
    FROM  VIEW_ESTABELECIMENTOS_001_DETALHADO_ORFAOS  ORDER BY ESFERA_ADMINISTRATIVA">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_ESTADO" runat="server" 
    ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
    SelectCommand="SELECT '@' AS UF, '# Todos' as UF_DESC UNION ALL 
    SELECT DISTINCT [UF] as UF, [UF] AS UF_DESC
    FROM  VIEW_ESTABELECIMENTOS_001_DETALHADO_ORFAOS ORDER BY UF_DESC">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_MUNICIPIO" runat="server" 
    ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
    SelectCommand="SELECT '@' AS MUNICIPIO, '#  Todos' as MUNICIPIO_DESC UNION ALL 
    SELECT DISTINCT [MUNICIPIO] as MUNICIPIO, [MUNICIPIO] as MUNICIPIO_DESC
    FROM  VIEW_ESTABELECIMENTOS_001_DETALHADO_ORFAOS  ORDER BY MUNICIPIO_DESC">
    </asp:SqlDataSource>

</form>
</body>
    
</html>