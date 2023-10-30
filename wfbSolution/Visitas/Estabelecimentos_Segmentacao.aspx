<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Estabelecimentos_Segmentacao.aspx.vb" Inherits="Estabelecimentos_Segmentacao" %>
<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Segmentação dos Estabelecimentos</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Segmentação dos Estabelecimentos</div>
    <div id ="Titulo_Pagina_Links">
         <asp:LinkButton ID="cmd_Excel" runat="server">Exportar para Excel</asp:LinkButton>
    </div>
</div>
<br />
<div id ="Corpo">
    <br />
    Selecione o representante que deseja ver o painel de segmentação.
    <br />
                    <asp:DropDownList 
                        ID="cmb_EMAIL_REPRESENTANTE" runat="server" AutoPostBack="True" 
                        DataSourceID="dts_Usuarios" DataTextField="USUARIO" 
                        DataValueField="EMAIL">
                    </asp:DropDownList><br /><br />
     Efetue todas as alterações e clique em <strong>Gravar</strong>
                    
               e aguarde o final da atualização.
    <br /><asp:Button ID="cmd_Gravar" CssClass="buton_gravar" runat="server" Text="Gravar" />
    <br />
    <br />
<asp:GridView ID="gdv_Localizar" runat="server" AutoGenerateColumns="False" 
            DataSourceID="dts_Localizar" Width="100%" DataKeyNames="CNPJ" HorizontalAlign="Left" Font-Size="Medium" GridLines="None">
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
                <asp:BoundField DataField="ESFERA" HeaderText="Esfera ADM" 
                    SortExpression="ESFERA" >
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Segmentação" SortExpression="COD_CLASSE">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("TARGET") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:DropDownList ID="cmb_CLASSE" runat="server" 
                            SelectedValue='<%# Bind("COD_CLASSE")%>' AutoPostBack="True" DataSourceID="dts_Segmentacao" DataTextField="DESCRICAO_CLASSE" DataValueField="COD_CLASSE">
                        </asp:DropDownList>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
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
<asp:SqlDataSource ID="dts_Localizar" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            
            SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS_001_DETALHADO] WHERE ([EMAIL_REPRESENTANTE] = @EMAIL_REPRESENTANTE) ORDER BY [ESTABELECIMENTO]" 
            OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="cmb_EMAIL_REPRESENTANTE" 
                    Name="EMAIL_REPRESENTANTE" PropertyName="SelectedValue" Type="String" />
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
                        <asp:SqlDataSource ID="dts_Segmentacao" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT [COD_CLASSE], [DESCRICAO_CLASSE] FROM [TBL_ESTABELECIMENTOS_CLASSE]"></asp:SqlDataSource>

</form>
    </body>
</html>