<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Contatos_Ativos.aspx.vb" Inherits="Contatos_Ativos" EnableEventValidation ="false" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Manutenção de Contatos</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Manutenção de Contatos</div>
    <div id ="Titulo_Pagina_Links">
         <asp:LinkButton ID="cmd_Excel" runat="server">Exportar para Excel</asp:LinkButton>
    </div>
</div>
<br />
<div id ="Corpo">
    <br />
    Selecione o representante que deseja ver o painel.
    <br />
    <asp:DropDownList ID="cmb_EMAIL_REPRESENTANTE" runat="server" AutoPostBack="True" DataSourceID="dts_Usuarios" DataTextField="USUARIO" DataValueField="EMAIL"></asp:DropDownList>
    <br />
    <br />
    <asp:DropDownList ID="cmb_ATIVO" runat="server" AutoPostBack="True" DataSourceID="dts_ATIVO" DataTextField="STATUS" DataValueField="VALOR">
    </asp:DropDownList>
    <br />
    <br />
     Efetue todas as alterações e clique em <strong>Gravar</strong> e aguarde o final da atualização.
    <br /><asp:Button ID="cmd_Gravar" CssClass="buton_gravar" runat="server" Text="Gravar" />
    <br />
    <br />
    <asp:GridView ID="gdv_Localizar" runat="server" AutoGenerateColumns="False" 
            DataSourceID="dts_Localizar" Width="100%" HorizontalAlign="Left" AllowSorting="True">
            <RowStyle VerticalAlign="Middle" HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField DataField="ID_CONTATO" HeaderText="ID" SortExpression="ID_CONTATO" InsertVisible="False" />
                <asp:BoundField DataField="NOME" HeaderText="Nome" SortExpression="NOME" >
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="ESTABELECIMENTO_CNPJ" HeaderText="Estabelecimento" 
                    SortExpression="ESTABELECIMENTO_CNPJ" >
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="VISITAS_MES_ATUAL" HeaderText="Visitas Mês Atual" SortExpression="VISITAS_MES_ATUAL">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="VISITAS_ANO_ATUAL" HeaderText="Visitas Ano Atual" SortExpression="VISITAS_ANO_ATUAL">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Ativo" SortExpression="ATIVO">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CONTAS_CHAVE")%>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:DropDownList ID="cmb_CONTATO_ATIVO" runat="server" DataSourceID="dts_ATIVO" DataTextField="ATIVO" DataValueField="VALOR" SelectedValue='<%# Bind("ATIVO") %>'>
                        </asp:DropDownList>
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
            SelectCommand="SELECT * FROM [VIEW_CONTATOS] WHERE (([EMAIL_REPRESENTANTE] = @EMAIL_REPRESENTANTE) AND ([ATIVO] = @ATIVO))" 
            OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="cmb_EMAIL_REPRESENTANTE" 
                    Name="EMAIL_REPRESENTANTE" PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="cmb_ATIVO" Name="ATIVO" PropertyName="SelectedValue" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_ATIVO" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_ATIVO]"></asp:SqlDataSource>
</form>
</body> 
</html>