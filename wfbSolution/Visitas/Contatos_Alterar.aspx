<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Contatos_Alterar.aspx.vb" Inherits="Contatos_Alterar" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Alterar Contato</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            font-weight: bold;
        }
    </style>
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Alterar Contato</div>
    <div id ="Titulo_Pagina_Links">
        <a href="Contatos_Ficha.aspx?ID=<%=Session("ID_CONTATO")%>">Voltar</a>
    </div>
</div>
<br />
<div id ="Corpo">

    <asp:FormView ID="frv_Contatos_Editar" runat="server" DataSourceID="dts_CONTATOS" DataKeyNames="ID_CONTATO" DefaultMode="Edit" Width="100%">
        <EditItemTemplate>
            <strong>
            <br />
            Nome:</strong>
            <br />
            <asp:TextBox ID="NOMETextBox" runat="server" CssClass="auto-style1" Text='<%# Bind("NOME") %>' Width="50%" />
            <br /><strong>Área:<br /></strong>
            <asp:DropDownList ID="cmb_area" runat="server" DataSourceID="TBL_CONTATOS_AREAS" DataTextField="AREA" DataValueField="ID_AREA" SelectedValue='<%# Bind("ID_AREA") %>'>
            </asp:DropDownList>
            <br />
            <strong>Cargo:<br /></strong>
            <asp:DropDownList ID="cmb_cargo" runat="server" DataSourceID="TBL_CONTATOS_CARGOS" DataTextField="CARGO" DataValueField="ID_CARGO" SelectedValue='<%# Bind("ID_CARGO") %>'>
            </asp:DropDownList>
            <br />
            <strong>Telefone:<br /></strong>
            <asp:TextBox ID="TELEFONETextBox" runat="server" Text='<%# Bind("TELEFONE") %>' />
            <br />
            <strong>Celular:<br /></strong>
            <asp:TextBox ID="CELULARTextBox" runat="server" Text='<%# Bind("CELULAR") %>' />
            <br />
            <strong>E-mail:<br /></strong>
            <asp:TextBox ID="EMAILTextBox" runat="server" Text='<%# Bind("EMAIL") %>' Width="50%" />
            <br />
            <strong>Dia:<br /> <asp:DropDownList ID="cmb_dia" runat="server" DataSourceID="TBL_DATAS_DIAS" DataTextField="DIA_NUMERO_TEXTO" DataValueField="DIA_NUMERO_VALOR" SelectedValue='<%# Bind("DIA_ANIVERSARIO") %>'>
            </asp:DropDownList>
            <br />Mês:<br /> <asp:DropDownList ID="cmb_mes" runat="server" DataSourceID="TBL_DATAS_MESES" DataTextField="MES_EXTENSO" DataValueField="MES_NUMERO_VALOR" SelectedValue='<%# Bind("MES_ANIVERSARIO") %>'>
            </asp:DropDownList>
            </strong><br /><strong>Ativo:</strong>
            <asp:CheckBox ID="ATIVOCheckBox" runat="server" Checked='<%# Bind("ATIVO") %>' />
            <br />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Gravar" Visible="False" />
            &nbsp;&nbsp;
            <a href="Contatos_Ficha.aspx?ID=<%=Session("ID_CONTATO")%>">Cancelar</a>
            &nbsp;
        </EditItemTemplate>
        <InsertItemTemplate>
            CNPJ_ESTABELECIMENTO:
            <asp:TextBox ID="CNPJ_ESTABELECIMENTOTextBox" runat="server" Text='<%# Bind("CNPJ_ESTABELECIMENTO") %>' />
            <br />
            ID_AREA:
            <asp:TextBox ID="ID_AREATextBox" runat="server" Text='<%# Bind("ID_AREA") %>' />
            <br />
            ID_CARGO:
            <asp:TextBox ID="ID_CARGOTextBox" runat="server" Text='<%# Bind("ID_CARGO") %>' />
            <br />
            COD_TIPO:
            <asp:TextBox ID="COD_TIPOTextBox" runat="server" Text='<%# Bind("COD_TIPO") %>' />
            <br />
            NOME:
            <asp:TextBox ID="NOMETextBox" runat="server" Text='<%# Bind("NOME") %>' />
            <br />
            ENDERECO:
            <asp:TextBox ID="ENDERECOTextBox" runat="server" Text='<%# Bind("ENDERECO") %>' />
            <br />
            BAIRRO:
            <asp:TextBox ID="BAIRROTextBox" runat="server" Text='<%# Bind("BAIRRO") %>' />
            <br />
            CEP:
            <asp:TextBox ID="CEPTextBox" runat="server" Text='<%# Bind("CEP") %>' />
            <br />
            ID_MUNICIPIO:
            <asp:TextBox ID="ID_MUNICIPIOTextBox" runat="server" Text='<%# Bind("ID_MUNICIPIO") %>' />
            <br />
            TELEFONE:
            <asp:TextBox ID="TELEFONETextBox" runat="server" Text='<%# Bind("TELEFONE") %>' />
            <br />
            CELULAR:
            <asp:TextBox ID="CELULARTextBox" runat="server" Text='<%# Bind("CELULAR") %>' />
            <br />
            EMAIL:
            <asp:TextBox ID="EMAILTextBox" runat="server" Text='<%# Bind("EMAIL") %>' />
            <br />
            MES_ANIVERSARIO:
            <asp:TextBox ID="MES_ANIVERSARIOTextBox" runat="server" Text='<%# Bind("MES_ANIVERSARIO") %>' />
            <br />
            DIA_ANIVERSARIO:
            <asp:TextBox ID="DIA_ANIVERSARIOTextBox" runat="server" Text='<%# Bind("DIA_ANIVERSARIO") %>' />
            <br />
            ATIVO:
            <asp:CheckBox ID="ATIVOCheckBox" runat="server" Checked='<%# Bind("ATIVO") %>' />
            <br />
            INCLUSAO_EMAIL:
            <asp:TextBox ID="INCLUSAO_EMAILTextBox" runat="server" Text='<%# Bind("INCLUSAO_EMAIL") %>' />
            <br />
            INCLUSAO_DATA:
            <asp:TextBox ID="INCLUSAO_DATATextBox" runat="server" Text='<%# Bind("INCLUSAO_DATA") %>' />
            <br />
            ALTERACAO_EMAIL:
            <asp:TextBox ID="ALTERACAO_EMAILTextBox" runat="server" Text='<%# Bind("ALTERACAO_EMAIL") %>' />
            <br />
            ALTERACAO_DATA:
            <asp:TextBox ID="ALTERACAO_DATATextBox" runat="server" Text='<%# Bind("ALTERACAO_DATA") %>' />
            <br />
            EXCLUSAO_EMAIL:
            <asp:TextBox ID="EXCLUSAO_EMAILTextBox" runat="server" Text='<%# Bind("EXCLUSAO_EMAIL") %>' />
            <br />
            EXCLUSAO_DATA:
            <asp:TextBox ID="EXCLUSAO_DATATextBox" runat="server" Text='<%# Bind("EXCLUSAO_DATA") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            ID_CONTATO:
            <asp:Label ID="ID_CONTATOLabel" runat="server" Text='<%# Eval("ID_CONTATO") %>' />
            <br />
            CNPJ_ESTABELECIMENTO:
            <asp:Label ID="CNPJ_ESTABELECIMENTOLabel" runat="server" Text='<%# Bind("CNPJ_ESTABELECIMENTO") %>' />
            <br />
            ID_AREA:
            <asp:Label ID="ID_AREALabel" runat="server" Text='<%# Bind("ID_AREA") %>' />
            <br />
            ID_CARGO:
            <asp:Label ID="ID_CARGOLabel" runat="server" Text='<%# Bind("ID_CARGO") %>' />
            <br />
            COD_TIPO:
            <asp:Label ID="COD_TIPOLabel" runat="server" Text='<%# Bind("COD_TIPO") %>' />
            <br />
            NOME:
            <asp:Label ID="NOMELabel" runat="server" Text='<%# Bind("NOME") %>' />
            <br />
            ENDERECO:
            <asp:Label ID="ENDERECOLabel" runat="server" Text='<%# Bind("ENDERECO") %>' />
            <br />
            BAIRRO:
            <asp:Label ID="BAIRROLabel" runat="server" Text='<%# Bind("BAIRRO") %>' />
            <br />
            CEP:
            <asp:Label ID="CEPLabel" runat="server" Text='<%# Bind("CEP") %>' />
            <br />
            ID_MUNICIPIO:
            <asp:Label ID="ID_MUNICIPIOLabel" runat="server" Text='<%# Bind("ID_MUNICIPIO") %>' />
            <br />
            TELEFONE:
            <asp:Label ID="TELEFONELabel" runat="server" Text='<%# Bind("TELEFONE") %>' />
            <br />
            CELULAR:
            <asp:Label ID="CELULARLabel" runat="server" Text='<%# Bind("CELULAR") %>' />
            <br />
            EMAIL:
            <asp:Label ID="EMAILLabel" runat="server" Text='<%# Bind("EMAIL") %>' />
            <br />
            MES_ANIVERSARIO:
            <asp:Label ID="MES_ANIVERSARIOLabel" runat="server" Text='<%# Bind("MES_ANIVERSARIO") %>' />
            <br />
            DIA_ANIVERSARIO:
            <asp:Label ID="DIA_ANIVERSARIOLabel" runat="server" Text='<%# Bind("DIA_ANIVERSARIO") %>' />
            <br />
            ATIVO:
            <asp:CheckBox ID="ATIVOCheckBox" runat="server" Checked='<%# Bind("ATIVO") %>' Enabled="false" />
            <br />
            INCLUSAO_EMAIL:
            <asp:Label ID="INCLUSAO_EMAILLabel" runat="server" Text='<%# Bind("INCLUSAO_EMAIL") %>' />
            <br />
            INCLUSAO_DATA:
            <asp:Label ID="INCLUSAO_DATALabel" runat="server" Text='<%# Bind("INCLUSAO_DATA") %>' />
            <br />
            ALTERACAO_EMAIL:
            <asp:Label ID="ALTERACAO_EMAILLabel" runat="server" Text='<%# Bind("ALTERACAO_EMAIL") %>' />
            <br />
            ALTERACAO_DATA:
            <asp:Label ID="ALTERACAO_DATALabel" runat="server" Text='<%# Bind("ALTERACAO_DATA") %>' />
            <br />
            EXCLUSAO_EMAIL:
            <asp:Label ID="EXCLUSAO_EMAILLabel" runat="server" Text='<%# Bind("EXCLUSAO_EMAIL") %>' />
            <br />
            EXCLUSAO_DATA:
            <asp:Label ID="EXCLUSAO_DATALabel" runat="server" Text='<%# Bind("EXCLUSAO_DATA") %>' />
            <br />

        </ItemTemplate>
    </asp:FormView>
    <asp:SqlDataSource ID="dts_CONTATOS" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" DeleteCommand="DELETE FROM [TBL_CONTATOS] WHERE [ID_CONTATO] = @ID_CONTATO" InsertCommand="INSERT INTO [TBL_CONTATOS] ([CNPJ_ESTABELECIMENTO], [ID_AREA], [ID_CARGO], [COD_TIPO], [NOME], [ENDERECO], [BAIRRO], [CEP], [ID_MUNICIPIO], [TELEFONE], [CELULAR], [EMAIL], [MES_ANIVERSARIO], [DIA_ANIVERSARIO], [ATIVO], [INCLUSAO_EMAIL], [INCLUSAO_DATA], [ALTERACAO_EMAIL], [ALTERACAO_DATA], [EXCLUSAO_EMAIL], [EXCLUSAO_DATA]) VALUES (@CNPJ_ESTABELECIMENTO, @ID_AREA, @ID_CARGO, @COD_TIPO, @NOME, @ENDERECO, @BAIRRO, @CEP, @ID_MUNICIPIO, @TELEFONE, @CELULAR, @EMAIL, @MES_ANIVERSARIO, @DIA_ANIVERSARIO, @ATIVO, @INCLUSAO_EMAIL, @INCLUSAO_DATA, @ALTERACAO_EMAIL, @ALTERACAO_DATA, @EXCLUSAO_EMAIL, @EXCLUSAO_DATA)" SelectCommand="SELECT * FROM [TBL_CONTATOS] WHERE ([ID_CONTATO] = @ID_CONTATO)" UpdateCommand="UPDATE [TBL_CONTATOS] SET [ID_AREA] = @ID_AREA, [ID_CARGO] = @ID_CARGO, [NOME] = @NOME, [TELEFONE] = @TELEFONE, [CELULAR] = @CELULAR, [EMAIL] = @EMAIL, [MES_ANIVERSARIO] = @MES_ANIVERSARIO, [DIA_ANIVERSARIO] = @DIA_ANIVERSARIO, [ATIVO] = @ATIVO WHERE [ID_CONTATO] = @ID_CONTATO">
        <DeleteParameters>
            <asp:Parameter Name="ID_CONTATO" Type="Decimal" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CNPJ_ESTABELECIMENTO" Type="Decimal" />
            <asp:Parameter Name="ID_AREA" Type="Decimal" />
            <asp:Parameter Name="ID_CARGO" Type="Decimal" />
            <asp:Parameter Name="COD_TIPO" Type="Decimal" />
            <asp:Parameter Name="NOME" Type="String" />
            <asp:Parameter Name="ENDERECO" Type="String" />
            <asp:Parameter Name="BAIRRO" Type="String" />
            <asp:Parameter Name="CEP" Type="String" />
            <asp:Parameter Name="ID_MUNICIPIO" Type="String" />
            <asp:Parameter Name="TELEFONE" Type="String" />
            <asp:Parameter Name="CELULAR" Type="String" />
            <asp:Parameter Name="EMAIL" Type="String" />
            <asp:Parameter Name="MES_ANIVERSARIO" Type="Decimal" />
            <asp:Parameter Name="DIA_ANIVERSARIO" Type="Decimal" />
            <asp:Parameter Name="ATIVO" Type="Boolean" />
            <asp:Parameter Name="INCLUSAO_EMAIL" Type="String" />
            <asp:Parameter Name="INCLUSAO_DATA" Type="Decimal" />
            <asp:Parameter Name="ALTERACAO_EMAIL" Type="String" />
            <asp:Parameter Name="ALTERACAO_DATA" Type="Decimal" />
            <asp:Parameter Name="EXCLUSAO_EMAIL" Type="String" />
            <asp:Parameter Name="EXCLUSAO_DATA" Type="Decimal" />
        </InsertParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="ID_CONTATO" QueryStringField="ID_CONTATO" Type="Decimal" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="ID_AREA" Type="Decimal" />
            <asp:Parameter Name="ID_CARGO" Type="Decimal" />
            <asp:Parameter Name="NOME" Type="String" />
            <asp:Parameter Name="TELEFONE" Type="String" />
            <asp:Parameter Name="CELULAR" Type="String" />
            <asp:Parameter Name="EMAIL" Type="String" />
            <asp:Parameter Name="MES_ANIVERSARIO" Type="Decimal" />
            <asp:Parameter Name="DIA_ANIVERSARIO" Type="Decimal" />
            <asp:Parameter Name="ATIVO" Type="Boolean" />
            <asp:Parameter Name="ID_CONTATO" Type="Decimal" />
        </UpdateParameters>
    </asp:SqlDataSource>

    <br />
     <asp:SqlDataSource ID="TBL_DATAS_MESES" runat="server" 
                ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
                SelectCommand="SELECT [MES_NUMERO_VALOR], [MES_EXTENSO] FROM [TBL_DATAS_MESES] ORDER BY [MES_NUMERO_VALOR]">
            </asp:SqlDataSource>
     <asp:SqlDataSource ID="TBL_DATAS_DIAS" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
                        
                        SelectCommand="SELECT [DIA_NUMERO_VALOR], [DIA_NUMERO_TEXTO] FROM [TBL_DATAS_DIAS] ORDER BY [DIA_NUMERO_VALOR]">
                    </asp:SqlDataSource>
     <asp:SqlDataSource ID="TBL_CONTATOS_AREAS" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
       SelectCommand="SELECT [ID_AREA], [AREA] FROM [TBL_ESTABELECIMENTOS_AREAS]">
       </asp:SqlDataSource>
     <asp:SqlDataSource ID="TBL_CONTATOS_CARGOS" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT [ID_CARGO], [CARGO] FROM [TBL_CONTATOS_CARGOS] ORDER BY [CARGO]">
       </asp:SqlDataSource>

</div>
</form>
</body>
</html>