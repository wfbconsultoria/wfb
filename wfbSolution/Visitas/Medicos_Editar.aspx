<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Medicos_Editar.aspx.vb" Inherits="Medicos_Editar" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Alterar Médico</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Alterar Médico</div>
    <div id ="Titulo_Pagina_Links">
        
    </div>
</div>
<br />
<div id ="Corpo">
    <br />
    <asp:FormView ID="frv_Medicos_Editar" runat="server" DataKeyNames="CRMUF" 
        DataSourceID="dts_Medicos" EnableModelValidation="True" Width="100%" 
        DefaultMode="Edit">
        <EditItemTemplate>
            <br />
            <strong>CRMFU</strong>
            <br />
            <asp:Label ID="CRMUFLabel1" runat="server" Text='<%# Eval("CRMUF") %>' />
            <br />
            <strong>Nome</strong>
            <br />
            <asp:TextBox ID="NOMETextBox" runat="server" Enabled="False" Font-Bold="True" Text='<%# Bind("NOME") %>' Width="50%" />
            <br />
            <strong>Especialidade</strong>
            <br />
            <asp:DropDownList ID="ID_ESPECIALIDADE" runat="server" 
                DataSourceID="dts_Especialidades" DataTextField="ESPECIALIDADE" 
                DataValueField="ID_ESPECIALIDADE" 
                SelectedValue='<%# Bind("ID_ESPECIALIDADE") %>'>
            </asp:DropDownList>
            <br />
            <strong>Telefone</strong>
            <br />
            <asp:TextBox ID="TELEFONETextBox" runat="server" Text='<%# Bind("TELEFONE") %>' Width="50%" />
            <br />
            <strong>Celular</strong>
            <br />
                <asp:TextBox ID="CELEULARTextBox" runat="server" Text='<%# Bind("CELEULAR") %>' Width="50%" />
            <br />
            <strong>Email</strong>
            <br />
            <asp:TextBox ID="EMAILTextBox" runat="server" Text='<%# Bind("EMAIL") %>' Width="50%" />
            <br />
            <strong>Aniversário</strong>
            <br />
            <strong>Dia</strong>
            <asp:DropDownList ID="DIA_ANIVERSARIO" runat="server" 
                DataSourceID="TBL_DATAS_DIAS" DataTextField="DIA_NUMERO_TEXTO" 
                DataValueField="DIA_NUMERO_VALOR" 
                SelectedValue='<%# Bind("DIA_ANIVERSARIO") %>'>
            </asp:DropDownList>
            &nbsp;<strong>Mês</strong>
            <asp:DropDownList ID="MES_ANIVERSARIO" runat="server" 
                DataSourceID="TBL_DATAS_MESES" DataTextField="MES_SIGLA" 
                DataValueField="MES_NUMERO_VALOR" 
                SelectedValue='<%# Bind("MES_ANIVERSARIO") %>'>
            </asp:DropDownList>
            <br />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                CommandName="Update" Text="Gravar" Visible="False" />
            &nbsp;&nbsp;<asp:HyperLink ID="lnk_Voltar" runat="server" 
                NavigateUrl="~/Medicos_Ficha.aspx">Cancelar</asp:HyperLink>
        </EditItemTemplate>
        <InsertItemTemplate>
            CRMUF:
            <asp:TextBox ID="CRMUFTextBox" runat="server" Text='<%# Bind("CRMUF") %>' />
            <br />
            NOME:
            <asp:TextBox ID="NOMETextBox" runat="server" Text='<%# Bind("NOME") %>' />
            <br />
            ID_ESPECIALIDADE:
            <asp:TextBox ID="ID_ESPECIALIDADETextBox" runat="server" 
                Text='<%# Bind("ID_ESPECIALIDADE") %>' />
            <br />
            ENDERECO:
            <asp:TextBox ID="ENDERECOTextBox" runat="server" 
                Text='<%# Bind("ENDERECO") %>' />
            <br />
            BAIRRO:
            <asp:TextBox ID="BAIRROTextBox" runat="server" Text='<%# Bind("BAIRRO") %>' />
            <br />
            CEP:
            <asp:TextBox ID="CEPTextBox" runat="server" Text='<%# Bind("CEP") %>' />
            <br />
            ID_MUNICIPIO:
            <asp:TextBox ID="ID_MUNICIPIOTextBox" runat="server" 
                Text='<%# Bind("ID_MUNICIPIO") %>' />
            <br />
            TELEFONE:
            <asp:TextBox ID="TELEFONETextBox" runat="server" 
                Text='<%# Bind("TELEFONE") %>' />
            <br />
            CELEULAR:
            <asp:TextBox ID="CELEULARTextBox" runat="server" 
                Text='<%# Bind("CELEULAR") %>' />
            <br />
            EMAIL:
            <asp:TextBox ID="EMAILTextBox" runat="server" Text='<%# Bind("EMAIL") %>' />
            <br />
            MES_ANIVERSARIO:
            <asp:TextBox ID="MES_ANIVERSARIOTextBox" runat="server" 
                Text='<%# Bind("MES_ANIVERSARIO") %>' />
            <br />
            DIA_ANIVERSARIO:
            <asp:TextBox ID="DIA_ANIVERSARIOTextBox" runat="server" 
                Text='<%# Bind("DIA_ANIVERSARIO") %>' />
            <br />
            ATIVO:
            <asp:TextBox ID="ATIVOTextBox" runat="server" Text='<%# Bind("ATIVO") %>' />
            <br />
            INCLUSAO_EMAIL:
            <asp:TextBox ID="INCLUSAO_EMAILTextBox" runat="server" 
                Text='<%# Bind("INCLUSAO_EMAIL") %>' />
            <br />
            INCLUSAO_DATA:
            <asp:TextBox ID="INCLUSAO_DATATextBox" runat="server" 
                Text='<%# Bind("INCLUSAO_DATA") %>' />
            <br />
            ALTERACAO_EMAIL:
            <asp:TextBox ID="ALTERACAO_EMAILTextBox" runat="server" 
                Text='<%# Bind("ALTERACAO_EMAIL") %>' />
            <br />
            ALTERACAO_DATA:
            <asp:TextBox ID="ALTERACAO_DATATextBox" runat="server" 
                Text='<%# Bind("ALTERACAO_DATA") %>' />
            <br />
            EXCLUSAO_EMAIL:
            <asp:TextBox ID="EXCLUSAO_EMAILTextBox" runat="server" 
                Text='<%# Bind("EXCLUSAO_EMAIL") %>' />
            <br />
            EXCLUSAO_DATA:
            <asp:TextBox ID="EXCLUSAO_DATATextBox" runat="server" 
                Text='<%# Bind("EXCLUSAO_DATA") %>' />
            <br />
            BLOQUEADO:
            <asp:CheckBox ID="BLOQUEADOCheckBox" runat="server" 
                Checked='<%# Bind("BLOQUEADO") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                CommandName="Insert" Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            ID_MEDICO:
            <asp:Label ID="ID_MEDICOLabel" runat="server" Text='<%# Eval("ID_MEDICO") %>' />
            <br />
            CRMUF:
            <asp:Label ID="CRMUFLabel" runat="server" Text='<%# Eval("CRMUF") %>' />
            <br />
            NOME:
            <asp:Label ID="NOMELabel" runat="server" Text='<%# Bind("NOME") %>' />
            <br />
            ID_ESPECIALIDADE:
            <asp:Label ID="ID_ESPECIALIDADELabel" runat="server" 
                Text='<%# Bind("ID_ESPECIALIDADE") %>' />
            <br />
            TELEFONE:
            <asp:Label ID="TELEFONELabel" runat="server" Text='<%# Bind("TELEFONE") %>' />
            <br />
            CELEULAR:
            <asp:Label ID="CELEULARLabel" runat="server" Text='<%# Bind("CELEULAR") %>' />
            <br />
            EMAIL:
            <asp:Label ID="EMAILLabel" runat="server" Text='<%# Bind("EMAIL") %>' />
            <br />
            MES_ANIVERSARIO:
            <asp:Label ID="MES_ANIVERSARIOLabel" runat="server" 
                Text='<%# Bind("MES_ANIVERSARIO") %>' />
            <br />
            DIA_ANIVERSARIO:
            <asp:Label ID="DIA_ANIVERSARIOLabel" runat="server" 
                Text='<%# Bind("DIA_ANIVERSARIO") %>' />
            <br />
            ATIVO:
            <asp:Label ID="ATIVOLabel" runat="server" Text='<%# Bind("ATIVO") %>' />
            <br />
            INCLUSAO_EMAIL:
            <asp:Label ID="INCLUSAO_EMAILLabel" runat="server" 
                Text='<%# Bind("INCLUSAO_EMAIL") %>' />
            <br />
            INCLUSAO_DATA:
            <asp:Label ID="INCLUSAO_DATALabel" runat="server" 
                Text='<%# Bind("INCLUSAO_DATA") %>' />
            <br />
            ALTERACAO_EMAIL:
            <asp:Label ID="ALTERACAO_EMAILLabel" runat="server" 
                Text='<%# Bind("ALTERACAO_EMAIL") %>' />
            <br />
            ALTERACAO_DATA:
            <asp:Label ID="ALTERACAO_DATALabel" runat="server" 
                Text='<%# Bind("ALTERACAO_DATA") %>' />
            <br />
            EXCLUSAO_EMAIL:
            <asp:Label ID="EXCLUSAO_EMAILLabel" runat="server" 
                Text='<%# Bind("EXCLUSAO_EMAIL") %>' />
            <br />
            EXCLUSAO_DATA:
            <asp:Label ID="EXCLUSAO_DATALabel" runat="server" 
                Text='<%# Bind("EXCLUSAO_DATA") %>' />
            <br />
            BLOQUEADO:
            <asp:CheckBox ID="BLOQUEADOCheckBox" runat="server" 
                Checked='<%# Bind("BLOQUEADO") %>' Enabled="false" />
            <br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
                CommandName="Edit" Text="Edit" />
            &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
                CommandName="Delete" Text="Delete" />
            &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
                CommandName="New" Text="New" />
        </ItemTemplate>
    </asp:FormView>
    </div>
</form>
    <asp:SqlDataSource ID="TBL_ESTADOS" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [TBL_MUNICIPIOS_ESTADOS] ORDER BY [UF]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Especialidades" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [TBL_MEDICOS_ESPECIALIDADES] ORDER BY [ESPECIALIDADE]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Perfil" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [TBL_MEDICOS_PERFIL_PROFISSIONAL] ORDER BY [PERFIL]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Cargos" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [TBL_MEDICOS_CARGOS] ORDER BY [ID_CARGO]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_AREAS" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [TBL_MEDICOS_AREAS] ORDER BY [AREA]">
    </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="dts_Municipios" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT [COD_MUNICIPIO], [MUNICIPIO] FROM [VIEW_MUNICIPIOS] ORDER BY [MUNICIPIO]">
    </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="TBL_DATAS_MESES" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT [MES_NUMERO_VALOR], [MES_SIGLA] FROM [TBL_DATAS_MESES] ORDER BY [MES_NUMERO_VALOR]">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="TBL_DATAS_DIAS" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT [DIA_NUMERO_VALOR], [DIA_NUMERO_TEXTO] FROM [TBL_DATAS_DIAS] ORDER BY [DIA_NUMERO_VALOR]">
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Medicos" runat="server" 
        ConflictDetection="CompareAllValues" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        DeleteCommand="DELETE FROM [TBL_MEDICOS] WHERE [CRMUF] = @original_CRMUF AND [ID_MEDICO] = @original_ID_MEDICO AND [NOME] = @original_NOME AND [ID_ESPECIALIDADE] = @original_ID_ESPECIALIDADE AND (([ENDERECO] = @original_ENDERECO) OR ([ENDERECO] IS NULL AND @original_ENDERECO IS NULL)) AND (([BAIRRO] = @original_BAIRRO) OR ([BAIRRO] IS NULL AND @original_BAIRRO IS NULL)) AND (([CEP] = @original_CEP) OR ([CEP] IS NULL AND @original_CEP IS NULL)) AND [ID_MUNICIPIO] = @original_ID_MUNICIPIO AND (([TELEFONE] = @original_TELEFONE) OR ([TELEFONE] IS NULL AND @original_TELEFONE IS NULL)) AND (([CELEULAR] = @original_CELEULAR) OR ([CELEULAR] IS NULL AND @original_CELEULAR IS NULL)) AND (([EMAIL] = @original_EMAIL) OR ([EMAIL] IS NULL AND @original_EMAIL IS NULL)) AND (([MES_ANIVERSARIO] = @original_MES_ANIVERSARIO) OR ([MES_ANIVERSARIO] IS NULL AND @original_MES_ANIVERSARIO IS NULL)) AND (([DIA_ANIVERSARIO] = @original_DIA_ANIVERSARIO) OR ([DIA_ANIVERSARIO] IS NULL AND @original_DIA_ANIVERSARIO IS NULL)) AND (([ATIVO] = @original_ATIVO) OR ([ATIVO] IS NULL AND @original_ATIVO IS NULL)) AND (([INCLUSAO_EMAIL] = @original_INCLUSAO_EMAIL) OR ([INCLUSAO_EMAIL] IS NULL AND @original_INCLUSAO_EMAIL IS NULL)) AND (([INCLUSAO_DATA] = @original_INCLUSAO_DATA) OR ([INCLUSAO_DATA] IS NULL AND @original_INCLUSAO_DATA IS NULL)) AND (([ALTERACAO_EMAIL] = @original_ALTERACAO_EMAIL) OR ([ALTERACAO_EMAIL] IS NULL AND @original_ALTERACAO_EMAIL IS NULL)) AND (([ALTERACAO_DATA] = @original_ALTERACAO_DATA) OR ([ALTERACAO_DATA] IS NULL AND @original_ALTERACAO_DATA IS NULL)) AND (([EXCLUSAO_EMAIL] = @original_EXCLUSAO_EMAIL) OR ([EXCLUSAO_EMAIL] IS NULL AND @original_EXCLUSAO_EMAIL IS NULL)) AND (([EXCLUSAO_DATA] = @original_EXCLUSAO_DATA) OR ([EXCLUSAO_DATA] IS NULL AND @original_EXCLUSAO_DATA IS NULL)) AND (([BLOQUEADO] = @original_BLOQUEADO) OR ([BLOQUEADO] IS NULL AND @original_BLOQUEADO IS NULL))" 
        InsertCommand="INSERT INTO [TBL_MEDICOS] ([CRMUF], [NOME], [ID_ESPECIALIDADE], [ENDERECO], [BAIRRO], [CEP], [ID_MUNICIPIO], [TELEFONE], [CELEULAR], [EMAIL], [MES_ANIVERSARIO], [DIA_ANIVERSARIO], [ATIVO], [INCLUSAO_EMAIL], [INCLUSAO_DATA], [ALTERACAO_EMAIL], [ALTERACAO_DATA], [EXCLUSAO_EMAIL], [EXCLUSAO_DATA], [BLOQUEADO]) VALUES (@CRMUF, @NOME, @ID_ESPECIALIDADE, @ENDERECO, @BAIRRO, @CEP, @ID_MUNICIPIO, @TELEFONE, @CELEULAR, @EMAIL, @MES_ANIVERSARIO, @DIA_ANIVERSARIO, @ATIVO, @INCLUSAO_EMAIL, @INCLUSAO_DATA, @ALTERACAO_EMAIL, @ALTERACAO_DATA, @EXCLUSAO_EMAIL, @EXCLUSAO_DATA, @BLOQUEADO)" 
        OldValuesParameterFormatString="original_{0}" 
        SelectCommand="SELECT * FROM [TBL_MEDICOS] WHERE ([CRMUF] = @CRMUF)" 
        UpdateCommand="UPDATE [TBL_MEDICOS] SET [ID_ESPECIALIDADE] = @ID_ESPECIALIDADE, [ENDERECO] = @ENDERECO, [BAIRRO] = @BAIRRO, [CEP] = @CEP, [ID_MUNICIPIO] = @ID_MUNICIPIO, [TELEFONE] = @TELEFONE, [CELEULAR] = @CELEULAR, [EMAIL] = @EMAIL, [MES_ANIVERSARIO] = @MES_ANIVERSARIO, [DIA_ANIVERSARIO] = @DIA_ANIVERSARIO, [ATIVO] = @ATIVO WHERE [CRMUF] = @original_CRMUF ">
        <DeleteParameters>
            <asp:Parameter Name="original_CRMUF" Type="String" />
            <asp:Parameter Name="original_ID_MEDICO" Type="Decimal" />
            <asp:Parameter Name="original_NOME" Type="String" />
            <asp:Parameter Name="original_ID_ESPECIALIDADE" Type="Decimal" />
            <asp:Parameter Name="original_ENDERECO" Type="String" />
            <asp:Parameter Name="original_BAIRRO" Type="String" />
            <asp:Parameter Name="original_CEP" Type="String" />
            <asp:Parameter Name="original_ID_MUNICIPIO" Type="String" />
            <asp:Parameter Name="original_TELEFONE" Type="String" />
            <asp:Parameter Name="original_CELEULAR" Type="String" />
            <asp:Parameter Name="original_EMAIL" Type="String" />
            <asp:Parameter Name="original_MES_ANIVERSARIO" Type="Decimal" />
            <asp:Parameter Name="original_DIA_ANIVERSARIO" Type="Decimal" />
            <asp:Parameter Name="original_ATIVO" Type="String" />
            <asp:Parameter Name="original_INCLUSAO_EMAIL" Type="String" />
            <asp:Parameter Name="original_INCLUSAO_DATA" Type="Decimal" />
            <asp:Parameter Name="original_ALTERACAO_EMAIL" Type="String" />
            <asp:Parameter Name="original_ALTERACAO_DATA" Type="Decimal" />
            <asp:Parameter Name="original_EXCLUSAO_EMAIL" Type="String" />
            <asp:Parameter Name="original_EXCLUSAO_DATA" Type="Decimal" />
            <asp:Parameter Name="original_BLOQUEADO" Type="Boolean" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CRMUF" Type="String" />
            <asp:Parameter Name="NOME" Type="String" />
            <asp:Parameter Name="ID_ESPECIALIDADE" Type="Decimal" />
            <asp:Parameter Name="ENDERECO" Type="String" />
            <asp:Parameter Name="BAIRRO" Type="String" />
            <asp:Parameter Name="CEP" Type="String" />
            <asp:Parameter Name="ID_MUNICIPIO" Type="String" />
            <asp:Parameter Name="TELEFONE" Type="String" />
            <asp:Parameter Name="CELEULAR" Type="String" />
            <asp:Parameter Name="EMAIL" Type="String" />
            <asp:Parameter Name="MES_ANIVERSARIO" Type="Decimal" />
            <asp:Parameter Name="DIA_ANIVERSARIO" Type="Decimal" />
            <asp:Parameter Name="ATIVO" Type="String" />
            <asp:Parameter Name="INCLUSAO_EMAIL" Type="String" />
            <asp:Parameter Name="INCLUSAO_DATA" Type="Decimal" />
            <asp:Parameter Name="ALTERACAO_EMAIL" Type="String" />
            <asp:Parameter Name="ALTERACAO_DATA" Type="Decimal" />
            <asp:Parameter Name="EXCLUSAO_EMAIL" Type="String" />
            <asp:Parameter Name="EXCLUSAO_DATA" Type="Decimal" />
            <asp:Parameter Name="BLOQUEADO" Type="Boolean" />
        </InsertParameters>
        <SelectParameters>
            <asp:SessionParameter Name="CRMUF" SessionField="CRMUF" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="ID_MEDICO" Type="Decimal" />
            <asp:Parameter Name="NOME" Type="String" />
            <asp:Parameter Name="ID_ESPECIALIDADE" Type="Decimal" />
            <asp:Parameter Name="ENDERECO" Type="String" />
            <asp:Parameter Name="BAIRRO" Type="String" />
            <asp:Parameter Name="CEP" Type="String" />
            <asp:Parameter Name="ID_MUNICIPIO" Type="String" />
            <asp:Parameter Name="TELEFONE" Type="String" />
            <asp:Parameter Name="CELEULAR" Type="String" />
            <asp:Parameter Name="EMAIL" Type="String" />
            <asp:Parameter Name="MES_ANIVERSARIO" Type="Decimal" />
            <asp:Parameter Name="DIA_ANIVERSARIO" Type="Decimal" />
            <asp:Parameter Name="ATIVO" Type="String" />
            <asp:Parameter Name="INCLUSAO_EMAIL" Type="String" />
            <asp:Parameter Name="INCLUSAO_DATA" Type="Decimal" />
            <asp:Parameter Name="ALTERACAO_EMAIL" Type="String" />
            <asp:Parameter Name="ALTERACAO_DATA" Type="Decimal" />
            <asp:Parameter Name="EXCLUSAO_EMAIL" Type="String" />
            <asp:Parameter Name="EXCLUSAO_DATA" Type="Decimal" />
            <asp:Parameter Name="BLOQUEADO" Type="Boolean" />
            <asp:Parameter Name="original_CRMUF" Type="String" />
            <asp:Parameter Name="original_ID_MEDICO" Type="Decimal" />
            <asp:Parameter Name="original_NOME" Type="String" />
            <asp:Parameter Name="original_ID_ESPECIALIDADE" Type="Decimal" />
            <asp:Parameter Name="original_ENDERECO" Type="String" />
            <asp:Parameter Name="original_BAIRRO" Type="String" />
            <asp:Parameter Name="original_CEP" Type="String" />
            <asp:Parameter Name="original_ID_MUNICIPIO" Type="String" />
            <asp:Parameter Name="original_TELEFONE" Type="String" />
            <asp:Parameter Name="original_CELEULAR" Type="String" />
            <asp:Parameter Name="original_EMAIL" Type="String" />
            <asp:Parameter Name="original_MES_ANIVERSARIO" Type="Decimal" />
            <asp:Parameter Name="original_DIA_ANIVERSARIO" Type="Decimal" />
            <asp:Parameter Name="original_ATIVO" Type="String" />
            <asp:Parameter Name="original_INCLUSAO_EMAIL" Type="String" />
            <asp:Parameter Name="original_INCLUSAO_DATA" Type="Decimal" />
            <asp:Parameter Name="original_ALTERACAO_EMAIL" Type="String" />
            <asp:Parameter Name="original_ALTERACAO_DATA" Type="Decimal" />
            <asp:Parameter Name="original_EXCLUSAO_EMAIL" Type="String" />
            <asp:Parameter Name="original_EXCLUSAO_DATA" Type="Decimal" />
            <asp:Parameter Name="original_BLOQUEADO" Type="Boolean" />
        </UpdateParameters>
    </asp:SqlDataSource>
</body>
</html>
