<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Estabelecimentos_Contas_Chave.aspx.vb" Inherits="Estabelecimentos_Contas_Chave" EnableEventValidation ="false" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Contas Chave</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Contas Chave</div>
    <div id ="Titulo_Pagina_Links">
         <asp:LinkButton ID="cmd_Excel" runat="server">Exportar para Excel</asp:LinkButton>
    </div>
</div>
<br />
<div id ="Corpo">
    <br />
     Efetue todas as alterações e clique em <strong>Gravar</strong> e aguarde o final da atualização.
    <br /><asp:Button ID="cmd_Gravar" CssClass="buton_gravar" runat="server" Text="Gravar" />
    <br />
    <br />
    <asp:GridView ID="gdv_Localizar" runat="server" AutoGenerateColumns="False" 
            DataSourceID="dts_Localizar" Width="100%" DataKeyNames="CNPJ" HorizontalAlign="Left">
            <RowStyle VerticalAlign="Middle" HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField DataField="CNPJ" HeaderText="CNPJ" SortExpression="CNPJ" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="ESTABELECIMENTO_CNPJ" HeaderText="Estabelecimento" 
                    SortExpression="ESTABELECIMENTO_CNPJ" ReadOnly="True" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="ESFERA" HeaderText="Esfera ADM" 
                    SortExpression="ESFERA" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="GERENTE" HeaderText="Gerente" SortExpression="GERENTE" />
                <asp:BoundField DataField="REPRESENTANTE" HeaderText="Representante" SortExpression="REPRESENTANTE" />
                <asp:TemplateField HeaderText="Conta Chave" SortExpression="CONTAS_CHAVE">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CONTAS_CHAVE")%>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chk_CONTAS_CHAVE" runat="server" Checked='<%# Bind("CONTAS_CHAVE") %>' />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle 
                HorizontalAlign="Left" VerticalAlign="Middle" Font-Names="Calibri" />
        </asp:GridView>
    <br />
    </div>

        <asp:SqlDataSource ID="dts_Localizar" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>"  
            SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS_001_DETALHADO]" 
            OldValuesParameterFormatString="original_{0}">
        </asp:SqlDataSource>
</form>
</body> 
</html>