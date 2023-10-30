<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Setorizacao_KA.aspx.vb" Inherits="Setorizacao_KA" EnableEventValidation ="false" %>
<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Setorização KA</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            margin-top: 0px;
        }
    </style>
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Setorização Key Account</div>
    <div id ="Titulo_Pagina_Links">
         <asp:LinkButton ID="cmd_Excel" runat="server">Exportar para Excel</asp:LinkButton>
    </div>
</div>
<br />
<div id ="Corpo">
    <br />
    Selecione o Key Account que deseja ver o painel de visitação.
    <br />
        <asp:DropDownList 
                        ID="cmb_EMAIL_REPRESENTANTE" runat="server" AutoPostBack="True" 
                        DataSourceID="dts_Usuarios" DataTextField="USUARIO" 
                        DataValueField="EMAIL">
                    </asp:DropDownList>
    <br />
    <br />
     Efetue todas as alterações e clique em <strong>Gravar</strong> e aguarde o final da atualização.
    <br /><asp:Button ID="cmd_Gravar" CssClass="buton_gravar" runat="server" Text="Gravar" />
    <br />
    <br />
<asp:GridView ID="gdv_Localizar" runat="server" AutoGenerateColumns="False" 
            DataSourceID="dts_Localizar" Width="100%" DataKeyNames="CNPJ" HorizontalAlign="Left" Font-Size="Medium" GridLines="None" CssClass="auto-style1">
            <RowStyle VerticalAlign="Middle" HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField DataField="CNPJ" HeaderText="CNPJ" SortExpression="CNPJ" >
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="ESTABELECIMENTO" HeaderText="Estabelecimento" SortExpression="ESTABELECIMENTO" />
                <asp:BoundField DataField="MUNICIPIO" HeaderText="Cidade" SortExpression="MUNICIPIO" />
                <asp:BoundField DataField="UF" HeaderText="UF" SortExpression="UF" />
                <asp:BoundField DataField="REPRESENTANTE" HeaderText="Representante" SortExpression="REPRESENTANTE" />
                <asp:TemplateField HeaderText="Key Account" SortExpression="EMAIL_GERENTE_CONTA">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("EMAIL_REPRESENTANTE") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:DropDownList ID="cmb_EMAIL_REPRESENTANTE" runat="server" 
                            SelectedValue='<%# Bind("EMAIL_GERENTE_CONTA") %>' DataSourceID="dts_Usuarios" DataTextField="NOME" DataValueField="EMAIL">
                        </asp:DropDownList>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle 
                HorizontalAlign="Left" VerticalAlign="Middle" />
        </asp:GridView>
    <br />
    </div>

</form>
    <asp:SqlDataSource ID="dts_Usuarios" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>"
                SelectCommand="SELECT * FROM [VIEW_USUARIOS]">
        </asp:SqlDataSource>
<asp:SqlDataSource ID="dts_Localizar" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            
            SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS_001_DETALHADO] WHERE ([EMAIL_GERENTE_CONTA] = @EMAIL_GERENTE_CONTA) ORDER BY [ESTABELECIMENTO_CNPJ]" 
            OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:ControlParameter ControlID="cmb_EMAIL_REPRESENTANTE" Name="EMAIL_GERENTE_CONTA" PropertyName="SelectedValue" Type="String" />
    </SelectParameters>
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
</body>
    
</html>