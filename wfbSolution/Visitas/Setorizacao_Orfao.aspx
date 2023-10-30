<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Setorizacao_Orfao.aspx.vb" Inherits="Setorizacao_Orfao" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Setorização (Inclusão de orfãos)</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Setorização (Inclusão de orfãos)</div>
    <div id ="Titulo_Pagina_Links">
    </div>
</div>    
<br />
<div id ="Corpo">
    <br />
      <b>Selecione o representante (orfão) que deseja ver o painel de visitação .</b>
        <br />
          <asp:DropDownList                        
              ID="cmb_EMAIL_REPRESENTANTE1" runat="server" AutoPostBack="True"                       
              DataSourceID="dts_Usuarios" DataTextField="USUARIO"                        
              DataValueField="EMAIL">                    
          </asp:DropDownList>
    <br /><br />
    <b>Efetue todas as alterações e clique em</b>&nbsp;
    <asp:Button ID="cmd_Gravar" runat="server" Text="Gravar" />
    <br />
    <b>Aguarde o processamento das informações</b>
    <br /><br />
        <asp:GridView ID="gdv_Localizar" runat="server" AutoGenerateColumns="False" 
            DataSourceID="dts_Localizar" Width="100%" 
            CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" 
            BorderStyle="Solid" BorderWidth="1px" DataKeyNames="CNPJ" 
            ForeColor="Black">
            <RowStyle VerticalAlign="Middle" />
            <Columns>
                <asp:BoundField DataField="CNPJ" HeaderText="CNPJ" SortExpression="CNPJ" />
                <asp:BoundField DataField="ESTABELECIMENTO" HeaderText="ESTABELECIMENTO" 
                    SortExpression="ESTABELECIMENTO" ReadOnly="True" />
                <asp:BoundField DataField="ESFERA" HeaderText="ESFERA" 
                    SortExpression="ESFERA" />
                <asp:TemplateField HeaderText="TARGET" SortExpression="TARGET">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("TARGET") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:DropDownList ID="cmb_TARGET" runat="server" 
                            SelectedValue='<%# Bind("TARGET_2")%>'>
                            <asp:ListItem Value="SIM">SIM</asp:ListItem>
                            <asp:ListItem Value="NÃO">NÃO</asp:ListItem>
                            <asp:ListItem Value="0" Enabled="false"></asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="REPRESENTANTE" 
                    SortExpression="EMAIL_REPRESENTANTE">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" 
                            Text='<%# Bind("EMAIL_REPRESENTANTE") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:DropDownList ID="cmb_EMAIL_REPRESENTANTE" runat="server" 
                            DataSourceID="dts_Usuarios_Representante" DataTextField="USUARIO" DataValueField="EMAIL" 
                            SelectedValue='<%# Bind("EMAIL_REPRESENTANTE") %>'>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="Black" Font-Bold="True" 
                HorizontalAlign="Left" VerticalAlign="Middle" ForeColor="White" />
            <AlternatingRowStyle BackColor="#CCCCCC" />
            
        </asp:GridView>
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
            
            SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS_001_DETALHADO] WHERE ([EMAIL_REPRESENTANTE] = @EMAIL_REPRESENTANTE) ORDER BY [ESTABELECIMENTO_CNPJ], [REPRESENTANTE]" 
            OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="cmb_EMAIL_REPRESENTANTE1" 
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
    <asp:SqlDataSource ID="dts_Usuarios_Representante" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>"
                SelectCommand="SELECT * FROM [TBL_USUARIOS] WHERE (([ATIVO] = @ATIVO) AND ([BLOQUEADO] = @BLOQUEADO) AND ([PERFIL] = @PERFIL))">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="ATIVO" Type="Boolean" />
                <asp:Parameter DefaultValue="False" Name="BLOQUEADO" Type="Boolean" />
                <asp:Parameter DefaultValue="Representante" Name="PERFIL" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
</form>
</body>
</html>

