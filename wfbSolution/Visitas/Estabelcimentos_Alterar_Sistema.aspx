<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Estabelcimentos_Alterar_Sistema.aspx.vb" Inherits="Estabelcimentos_Alterar_Sistema" %>
<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Estabelecimentos Alterar (Sistema)</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Estabelecimentos Alterar (Sistema)</div>
    <div id ="Titulo_Pagina_Links">
         <asp:LinkButton ID="cmd_Excel" runat="server">Exportar para Excel</asp:LinkButton>
    </div>
</div>
<br />
<div id ="Corpo">
    <br />
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
                <asp:BoundField DataField="CNES" HeaderText="CNES" 
                    SortExpression="CNES" >
                </asp:BoundField>
                <asp:TemplateField HeaderText="CNPJ Para">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_CNPJ_PARA" runat="server" Text='<%# Bind("CNPJ_PARA") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CNPJ CNES">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_CNPJ_CNES" runat="server" Text='<%# Bind("CNPJ_CNES") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CNES Para">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_CNES_PARA" runat="server" Text='<%# Bind("CNES_PARA") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle 
                HorizontalAlign="Left" VerticalAlign="Middle" />
        </asp:GridView>
    <br />
    </div>

<asp:SqlDataSource ID="dts_Localizar" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            
            SelectCommand="SELECT * FROM [TBL_ESTABELECIMENTOS] ORDER BY [ESTABELECIMENTO]" 
            OldValuesParameterFormatString="original_{0}" DeleteCommand="DELETE FROM [TBL_ESTABELECIMENTOS] WHERE [CNPJ] = @original_CNPJ" InsertCommand="INSERT INTO [TBL_ESTABELECIMENTOS] ([CNPJ], [CNPJ_CNES], [CNPJ_PARA], [CNES], [CNES_PARA], [COD_SAP], [GRUPO], [ESTABELECIMENTO], [RAZAO_SOCIAL], [ENDERECO], [COMPLEMENTO], [BAIRRO], [CEP], [COD_MUNICIPIO], [COD_ESFERA_ADMINISTRATIVA], [COD_CLASSE], [CONTAS_CHAVE], [INCLUSAO_EMAIL], [INCLUSAO_DATA], [ALTERACAO_EMAIL], [ALTERACAO_DATA], [EXCLUSAO_EMAIL], [EXCLUSAO_DATA], [SETORIZACAO_EMAIL], [SETORIZACAO_DATA], [TRANSFERIR_PARA], [TRANSFERIDO_POR], [TRANSFERIDO_EM], [EMAIL_GERENTE_CONTA], [EXCLUIR]) VALUES (@CNPJ, @CNPJ_CNES, @CNPJ_PARA, @CNES, @CNES_PARA, @COD_SAP, @GRUPO, @ESTABELECIMENTO, @RAZAO_SOCIAL, @ENDERECO, @COMPLEMENTO, @BAIRRO, @CEP, @COD_MUNICIPIO, @COD_ESFERA_ADMINISTRATIVA, @COD_CLASSE, @CONTAS_CHAVE, @INCLUSAO_EMAIL, @INCLUSAO_DATA, @ALTERACAO_EMAIL, @ALTERACAO_DATA, @EXCLUSAO_EMAIL, @EXCLUSAO_DATA, @SETORIZACAO_EMAIL, @SETORIZACAO_DATA, @TRANSFERIR_PARA, @TRANSFERIDO_POR, @TRANSFERIDO_EM, @EMAIL_GERENTE_CONTA, @EXCLUIR)" UpdateCommand="UPDATE [TBL_ESTABELECIMENTOS] SET [CNPJ_CNES] = @CNPJ_CNES, [CNPJ_PARA] = @CNPJ_PARA, [CNES] = @CNES, [CNES_PARA] = @CNES_PARA, [COD_SAP] = @COD_SAP, [GRUPO] = @GRUPO, [ESTABELECIMENTO] = @ESTABELECIMENTO, [RAZAO_SOCIAL] = @RAZAO_SOCIAL, [ENDERECO] = @ENDERECO, [COMPLEMENTO] = @COMPLEMENTO, [BAIRRO] = @BAIRRO, [CEP] = @CEP, [COD_MUNICIPIO] = @COD_MUNICIPIO, [COD_ESFERA_ADMINISTRATIVA] = @COD_ESFERA_ADMINISTRATIVA, [COD_CLASSE] = @COD_CLASSE, [CONTAS_CHAVE] = @CONTAS_CHAVE, [INCLUSAO_EMAIL] = @INCLUSAO_EMAIL, [INCLUSAO_DATA] = @INCLUSAO_DATA, [ALTERACAO_EMAIL] = @ALTERACAO_EMAIL, [ALTERACAO_DATA] = @ALTERACAO_DATA, [EXCLUSAO_EMAIL] = @EXCLUSAO_EMAIL, [EXCLUSAO_DATA] = @EXCLUSAO_DATA, [SETORIZACAO_EMAIL] = @SETORIZACAO_EMAIL, [SETORIZACAO_DATA] = @SETORIZACAO_DATA, [TRANSFERIR_PARA] = @TRANSFERIR_PARA, [TRANSFERIDO_POR] = @TRANSFERIDO_POR, [TRANSFERIDO_EM] = @TRANSFERIDO_EM, [EMAIL_GERENTE_CONTA] = @EMAIL_GERENTE_CONTA, [EXCLUIR] = @EXCLUIR WHERE [CNPJ] = @original_CNPJ">
    <DeleteParameters>
        <asp:Parameter Name="original_CNPJ" Type="Decimal" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="CNPJ" Type="Decimal" />
        <asp:Parameter Name="CNPJ_CNES" Type="Decimal" />
        <asp:Parameter Name="CNPJ_PARA" Type="Decimal" />
        <asp:Parameter Name="CNES" Type="String" />
        <asp:Parameter Name="CNES_PARA" Type="String" />
        <asp:Parameter Name="COD_SAP" Type="String" />
        <asp:Parameter Name="GRUPO" Type="String" />
        <asp:Parameter Name="ESTABELECIMENTO" Type="String" />
        <asp:Parameter Name="RAZAO_SOCIAL" Type="String" />
        <asp:Parameter Name="ENDERECO" Type="String" />
        <asp:Parameter Name="COMPLEMENTO" Type="String" />
        <asp:Parameter Name="BAIRRO" Type="String" />
        <asp:Parameter Name="CEP" Type="String" />
        <asp:Parameter Name="COD_MUNICIPIO" Type="String" />
        <asp:Parameter Name="COD_ESFERA_ADMINISTRATIVA" Type="Decimal" />
        <asp:Parameter Name="COD_CLASSE" Type="Decimal" />
        <asp:Parameter Name="CONTAS_CHAVE" Type="Boolean" />
        <asp:Parameter Name="INCLUSAO_EMAIL" Type="String" />
        <asp:Parameter Name="INCLUSAO_DATA" Type="Decimal" />
        <asp:Parameter Name="ALTERACAO_EMAIL" Type="String" />
        <asp:Parameter Name="ALTERACAO_DATA" Type="Decimal" />
        <asp:Parameter Name="EXCLUSAO_EMAIL" Type="String" />
        <asp:Parameter Name="EXCLUSAO_DATA" Type="Decimal" />
        <asp:Parameter Name="SETORIZACAO_EMAIL" Type="String" />
        <asp:Parameter Name="SETORIZACAO_DATA" Type="Decimal" />
        <asp:Parameter Name="TRANSFERIR_PARA" Type="Decimal" />
        <asp:Parameter Name="TRANSFERIDO_POR" Type="String" />
        <asp:Parameter Name="TRANSFERIDO_EM" Type="Decimal" />
        <asp:Parameter Name="EMAIL_GERENTE_CONTA" Type="String" />
        <asp:Parameter Name="EXCLUIR" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="CNPJ_CNES" Type="Decimal" />
        <asp:Parameter Name="CNPJ_PARA" Type="Decimal" />
        <asp:Parameter Name="CNES" Type="String" />
        <asp:Parameter Name="CNES_PARA" Type="String" />
        <asp:Parameter Name="COD_SAP" Type="String" />
        <asp:Parameter Name="GRUPO" Type="String" />
        <asp:Parameter Name="ESTABELECIMENTO" Type="String" />
        <asp:Parameter Name="RAZAO_SOCIAL" Type="String" />
        <asp:Parameter Name="ENDERECO" Type="String" />
        <asp:Parameter Name="COMPLEMENTO" Type="String" />
        <asp:Parameter Name="BAIRRO" Type="String" />
        <asp:Parameter Name="CEP" Type="String" />
        <asp:Parameter Name="COD_MUNICIPIO" Type="String" />
        <asp:Parameter Name="COD_ESFERA_ADMINISTRATIVA" Type="Decimal" />
        <asp:Parameter Name="COD_CLASSE" Type="Decimal" />
        <asp:Parameter Name="CONTAS_CHAVE" Type="Boolean" />
        <asp:Parameter Name="INCLUSAO_EMAIL" Type="String" />
        <asp:Parameter Name="INCLUSAO_DATA" Type="Decimal" />
        <asp:Parameter Name="ALTERACAO_EMAIL" Type="String" />
        <asp:Parameter Name="ALTERACAO_DATA" Type="Decimal" />
        <asp:Parameter Name="EXCLUSAO_EMAIL" Type="String" />
        <asp:Parameter Name="EXCLUSAO_DATA" Type="Decimal" />
        <asp:Parameter Name="SETORIZACAO_EMAIL" Type="String" />
        <asp:Parameter Name="SETORIZACAO_DATA" Type="Decimal" />
        <asp:Parameter Name="TRANSFERIR_PARA" Type="Decimal" />
        <asp:Parameter Name="TRANSFERIDO_POR" Type="String" />
        <asp:Parameter Name="TRANSFERIDO_EM" Type="Decimal" />
        <asp:Parameter Name="EMAIL_GERENTE_CONTA" Type="String" />
        <asp:Parameter Name="EXCLUIR" Type="String" />
        <asp:Parameter Name="original_CNPJ" Type="Decimal" />
    </UpdateParameters>
        </asp:SqlDataSource>
</form>
    </body>
</html>