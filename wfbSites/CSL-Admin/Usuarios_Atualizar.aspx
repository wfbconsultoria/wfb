<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Usuarios_Atualizar.aspx.vb" Inherits="Usuarios" EnableSessionState="True" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Manutenção no Cadastro de Usuario</title>
    <script src="JScript.js" type="text/javascript"></script>
</head>
<body>
    <form id="frmUsuarios" runat="server">
        <uc1:Cabecalho runat="server" id="Cabecalho" />
        <div id="Titulo_Pagina">
            <div id ="Titulo_Pagina_Cabecalho">Alterar Usuário</div>
            <div id ="Titulo_Pagina_Links">
                <asp:HyperLink ID="lnk_Voltar" runat="server" NavigateUrl="~/Usuarios_Localizacao.aspx">Lista de Usuários</asp:HyperLink>&nbsp;
            </div>
        <br />
        </div>
        <div id="Corpo">
            <br />
            <asp:FormView ID="frv_Usuarios" runat="server" DataKeyNames="EMAIL" DataSourceID="dts_Usuario" Width="1188px">
                <EditItemTemplate>
                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Gravar" />
                    &nbsp;<asp:HyperLink ID="lnk_Voltar" runat="server" NavigateUrl="~/Usuarios_Localizacao.aspx">Cancelar</asp:HyperLink>
                    <br />
                    <br />
                    E-mail:
                    <asp:Label ID="EMAILLabel1" runat="server" style="font-weight: 700" Text='<%# Eval("EMAIL") %>' />
                    <br />
                    Nome:
                    <br />
                    <asp:TextBox ID="NOMETextBox" runat="server" Text='<%# Bind("NOME") %>' Width="75%" style="font-weight: 700" />
                    <br />
                    Perfil:<br />
                    <asp:DropDownList ID="COD_PERFILTextBox" runat="server" DataSourceID="dts_Perfis" DataTextField="PERFIL" DataValueField="COD_PERFIL" SelectedValue='<%# Bind("COD_PERFIL") %>'>
                    </asp:DropDownList>
                    <br />
                    Função:<br />
                    <asp:DropDownList ID="COD_FUNCAOTextBox0" runat="server" DataSourceID="dts_Funcao" DataTextField="DESCRICAO" DataValueField="COD_FUNCAO" SelectedValue='<%# Bind("COD_FUNCAO") %>'>
                    </asp:DropDownList>
                    <br />
                    Equipe:<br />
                    <asp:DropDownList ID="COD_EQUIPETextBox1" runat="server" DataSourceID="dts_Equipe" DataTextField="EQUIPE" DataValueField="ID_EQUIPE" SelectedValue='<%# Bind("ID_EQUIPE") %>'>
                    </asp:DropDownList>
                    <br />
                    Telefone Celular:<br />
                    <asp:TextBox ID="TELEFONETextBox" runat="server" Text='<%# Bind("TELEFONE") %>' Width="50%" />
                    <br />
                    Telefone Fixo:<br />
                    <asp:TextBox ID="FIXOTextBox" runat="server" Text='<%# Bind("FIXO")%>' Width="50%" />
                    <br />
                    Código Interno:<br />
                    <asp:TextBox ID="COD_INTERNOTextBox" runat="server" Text='<%# Bind("COD_INTERNO")%>' />
                    <br />
                    Nascimento: <em>
                    <br />
                    Ano
                    <asp:TextBox ID="ANO_NASCIMENTOTextBox" runat="server" MaxLength="4" style="text-align: center" Text='<%# Bind("ANO_NASCIMENTO") %>' TextMode="Number" Width="40px" />
                    &nbsp;Mês
                    <asp:DropDownList ID="MES_NASCIMENTOTextBox" runat="server" DataSourceID="dts_Meses" DataTextField="MES_SIGLA" DataValueField="MES">
                    </asp:DropDownList>
                    &nbsp; Dia
                    <asp:TextBox ID="DIA_NASCIMENTOTextBox" runat="server" style="text-align: center" Text='<%# Bind("DIA_NASCIMENTO") %>' TextMode="Number" Width="40px" />
                    </em>
                    <br />
                    &nbsp;<br />Gerente Nacional:<br />
                    <asp:DropDownList ID="DIRETORTextBox" runat="server" DataSourceID="dts_Diretores" DataTextField="NOME" DataValueField="EMAIL" SelectedValue='<%# Bind("EMAIL_DIRETOR")%>'>
                    </asp:DropDownList>
                    <br />
                    Gerente Regional:<br />
                    <asp:DropDownList ID="GERENTETextBox" runat="server" DataSourceID="dts_Gerentes" DataTextField="NOME" DataValueField="EMAIL" SelectedValue='<%# Bind("EMAIL_GERENTE")%>'>
                    </asp:DropDownList>
                    <br />
                    Coordenador:<br />
                    <asp:DropDownList ID="COORDENADORTextBox" runat="server" DataSourceID="dts_Coordenadores" DataTextField="NOME" DataValueField="EMAIL" SelectedValue='<%# Bind("EMAIL_COORDENADOR") %>'>
                    </asp:DropDownList>
                    <br />
                    <br />
                    Ativo:
                    <asp:CheckBox ID="ATIVOCheckBox" runat="server" Checked='<%# Bind("ATIVO") %>' />
                    &nbsp;<br />Bloqueado:
                    <asp:CheckBox ID="BLOQUEADOCheckBox" runat="server" Checked='<%# Bind("BLOQUEADO") %>' />
                    &nbsp;<br /> Login:
                    <asp:CheckBox ID="LOGINCheckBox" runat="server" Checked='<%# Bind("LOGIN") %>' />
                    <br />
                    Administrador de Setorização:
                    <asp:CheckBox ID="ADMINISTRADOR_SETORIZACAOCheckBox" runat="server" Checked='<%# Bind("ADMINISTRADOR_SETORIZACAO") %>' />
                    <br />
                    Administrador de Cotas:
                    <asp:CheckBox ID="ADMINISTRADOR_COTASCheckBox" runat="server" Checked='<%# Bind("ADMINISTRADOR_COTAS")%>' />
                    <br />
                    Cálculo de Incentivo:
                    <asp:CheckBox ID="CALCULO_INCENTIVOCheckBox" runat="server" Checked='<%# Bind("CALCULO_INCENTIVO")%>' />
                    <br />
                    Download:
                    <asp:CheckBox ID="DOWNLOADCheckBox" runat="server" Checked='<%# Bind("DOWNLOAD")%>' />
                    <br />
                    Upload de Mapas:
                    <asp:CheckBox ID="UPLOAD_MAPASCheckBox" runat="server" Checked='<%# Bind("UPLOAD_MAPAS")%>' />
                    <% If Session("SISTEMA") = True Then%>
                    <br />
                    Upload:
                    <asp:CheckBox ID="UPLOADCheckBox" runat="server" Checked='<%# Bind("UPLOAD")%>' />
                    <br />
                    Sistema:&nbsp;<asp:CheckBox ID="SISTEMACheckBox" runat="server" Checked='<%# Bind("SISTEMA") %>' />
                    <% End If%>
                    &nbsp;<br />
                    <asp:TextBox ID="INCLUSAO_EMAILTextBox" runat="server" Text='<%# Bind("INCLUSAO_EMAIL") %>' Visible="False" />
                    <asp:TextBox ID="INCLUSAO_DATATextBox" runat="server" Text='<%# Bind("INCLUSAO_DATA") %>' Visible="False" />
                    <asp:TextBox ID="ALTERACAO_EMAILTextBox" runat="server" Text='<%# Bind("ALTERACAO_EMAIL") %>' Visible="False" />
                    <asp:TextBox ID="ALTERACAO_DATATextBox" runat="server" Text='<%# Bind("ALTERACAO_DATA") %>' Visible="False" />
                    <asp:TextBox ID="EXCLUSAO_EMAILTextBox" runat="server" Text='<%# Bind("EXCLUSAO_EMAIL") %>' Visible="False" />
                    <asp:TextBox ID="EXCLUSAO_DATATextBox" runat="server" Text='<%# Bind("EXCLUSAO_DATA") %>' Visible="False" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    EMAIL:
                    <asp:TextBox ID="EMAILTextBox" runat="server" Text='<%# Bind("EMAIL") %>' />
                    <br />
                    COD_PERFIL:
                    <asp:TextBox ID="COD_PERFILTextBox" runat="server" Text='<%# Bind("COD_PERFIL") %>' />
                    <br />
                    NOME:
                    <asp:TextBox ID="NOMETextBox" runat="server" Text='<%# Bind("NOME") %>' />
                    <br />
                    SENHA:
                    <asp:TextBox ID="SENHATextBox" runat="server" Text='<%# Bind("SENHA") %>' />
                    <br />
                    NUM_INTERNO:
                    <asp:TextBox ID="COD_INTERNOTextBox" runat="server" Text='<%# Bind("COD_INTERNO")%>' />
                    <br />
                    ATIVO:
                    <asp:CheckBox ID="ATIVOCheckBox" runat="server" Checked='<%# Bind("ATIVO") %>' />
                    <br />
                    BLOQUEADO:
                    <asp:CheckBox ID="BLOQUEADOCheckBox" runat="server" Checked='<%# Bind("BLOQUEADO") %>' />
                    <br />
                    LOGIN:
                    <asp:CheckBox ID="LOGINCheckBox" runat="server" Checked='<%# Bind("LOGIN") %>' />
                    <br />
                    SISTEMA:
                    <asp:CheckBox ID="SISTEMACheckBox" runat="server" Checked='<%# Bind("SISTEMA") %>' />
                    <br />
                    COD_FUNCAO:
                    <asp:TextBox ID="COD_FUNCAOTextBox" runat="server" Text='<%# Bind("COD_FUNCAO") %>' />
                    <br />
                    &nbsp;<br /> Gerente Nacional:
                    <asp:DropDownList ID="DIRETORTextBox" runat="server" DataSourceID="dts_Diretores" DataTextField="NOME" DataValueField="EMAIL" SelectedValue='<%# Bind("EMAIL_DIRETOR")%>'>
                    </asp:DropDownList>
                    <br />
                    Gerente Regional:
                    <asp:DropDownList ID="GERENTETextBox" runat="server" DataSourceID="dts_Gerentes" DataTextField="NOME" DataValueField="EMAIL" SelectedValue='<%# Bind("EMAIL_GERENTE")%>'>
                    </asp:DropDownList>
                    <br />
                    Coordenador:
                    <asp:DropDownList ID="COORDENADORTextBox" runat="server" DataSourceID="dts_Coordenadores" DataTextField="NOME" DataValueField="EMAIL" SelectedValue='<%# Bind("EMAIL_COORDENADOR")%>'>
                    </asp:DropDownList>
                    ANO_NASCIMENTO:
                    <asp:TextBox ID="ANO_NASCIMENTOTextBox" runat="server" Text='<%# Bind("ANO_NASCIMENTO") %>' />
                    <br />
                    MES_NASCIMENTO:
                    <asp:TextBox ID="MES_NASCIMENTOTextBox" runat="server" Text='<%# Bind("MES_NASCIMENTO") %>' />
                    <br />
                    DIA_NASCIMENTO:
                    <asp:TextBox ID="DIA_NASCIMENTOTextBox" runat="server" Text='<%# Bind("DIA_NASCIMENTO") %>' />
                    <br />
                    TELEFONE:
                    <asp:TextBox ID="TELEFONETextBox" runat="server" Text='<%# Bind("TELEFONE") %>' />
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
                    EMAIL:
                    <asp:Label ID="EMAILLabel" runat="server" Text='<%# Eval("EMAIL") %>' />
                    <br />
                    COD_PERFIL:
                    <asp:Label ID="COD_PERFILLabel" runat="server" Text='<%# Bind("COD_PERFIL") %>' />
                    <br />
                    NOME:
                    <asp:Label ID="NOMELabel" runat="server" Text='<%# Bind("NOME") %>' />
                    <br />
                    SENHA:
                    <asp:Label ID="SENHALabel" runat="server" Text='<%# Bind("SENHA") %>' />
                    <br />
                    NUM_INTERNO:
                    <asp:Label ID="COD_INTERNOLabel" runat="server" Text='<%# Bind("COD_INTERNO")%>' />
                    <br />
                    ATIVO:
                    <asp:CheckBox ID="ATIVOCheckBox" runat="server" Checked='<%# Bind("ATIVO") %>' Enabled="false" />
                    <br />
                    BLOQUEADO:
                    <asp:CheckBox ID="BLOQUEADOCheckBox" runat="server" Checked='<%# Bind("BLOQUEADO") %>' Enabled="false" />
                    <br />
                    LOGIN:
                    <asp:CheckBox ID="LOGINCheckBox" runat="server" Checked='<%# Bind("LOGIN") %>' Enabled="false" />
                    <br />
                    SISTEMA:
                    <asp:CheckBox ID="SISTEMACheckBox" runat="server" Checked='<%# Bind("SISTEMA") %>' Enabled="false" />
                    <br />
                    COD_FUNCAO:
                    <asp:Label ID="COD_FUNCAOLabel" runat="server" Text='<%# Bind("COD_FUNCAO") %>' />
                    <br />
                    &nbsp;<br />Gerente Nacional:
                    <asp:DropDownList ID="DIRETORTextBox" runat="server" DataSourceID="dts_Diretores" DataTextField="NOME" DataValueField="EMAIL" SelectedValue='<%# Bind("EMAIL_DIRETOR")%>'>
                    </asp:DropDownList>
                    <br />
                    Gerente Regional:
                    <asp:DropDownList ID="GERENTETextBox" runat="server" DataSourceID="dts_Gerentes" DataTextField="NOME" DataValueField="EMAIL" SelectedValue='<%# Bind("EMAIL_GERENTE")%>'>
                    </asp:DropDownList>
                    <br />
                    Coordenador:
                    <asp:DropDownList ID="COORDENADORTextBox" runat="server" DataSourceID="dts_Coordenadores" DataTextField="NOME" DataValueField="EMAIL" SelectedValue='<%# Bind("EMAIL_COORDENADOR")%>'>
                    </asp:DropDownList>
                    ANO_NASCIMENTO:
                    <asp:Label ID="ANO_NASCIMENTOLabel" runat="server" Text='<%# Bind("ANO_NASCIMENTO") %>' />
                    <br />
                    MES_NASCIMENTO:
                    <asp:Label ID="MES_NASCIMENTOLabel" runat="server" Text='<%# Bind("MES_NASCIMENTO") %>' />
                    <br />
                    DIA_NASCIMENTO:
                    <asp:Label ID="DIA_NASCIMENTOLabel" runat="server" Text='<%# Bind("DIA_NASCIMENTO") %>' />
                    <br />
                    TELEFONE:
                    <asp:Label ID="TELEFONELabel" runat="server" Text='<%# Bind("TELEFONE") %>' />
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
            Inclusão: <asp:Label ID="txtLogInclusao" runat="server"></asp:Label>
            <br />
            Atualização: 
            <asp:Label ID="txtLogAlteracao" runat="server"></asp:Label>
            <br /><br /><br />
     </div>
        
    <asp:SqlDataSource ID="dts_Meses" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [TBL_DATAS_MESES] ORDER BY [MES]">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Diretores" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT '@ Selecione' as NOME, '@' AS EMAIL UNION ALL SELECT [NOME], [EMAIL] FROM [VIEW_USUARIOS] WHERE [COD_PERFIL] = 1 ORDER BY [NOME]">
    </asp:SqlDataSource>

        <asp:SqlDataSource ID="dts_Funcao" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [tbl_USUARIOS_FUNCOES] ORDER BY [DESCRICAO]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_Equipe" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_PRODUTOS_LINHAS_EQUIPES] ORDER BY [EQUIPE]"></asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Gerentes" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT '@ Selecione' as NOME, '@' AS EMAIL UNION ALL SELECT [NOME], [EMAIL] FROM [VIEW_USUARIOS] WHERE [COD_PERFIL] = 2 ORDER BY [NOME]">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Coordenadores" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT '@ Selecione' as NOME, '@' AS EMAIL UNION ALL SELECT [NOME], [EMAIL] FROM [VIEW_USUARIOS] WHERE [COD_PERFIL] = 3 ORDER BY [NOME]">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Perfis" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [TBL_USUARIOS_PERFIS] ORDER BY [COD_PERFIL]">
    </asp:SqlDataSource>

        <asp:SqlDataSource ID="dts_Usuario" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            DeleteCommand="DELETE FROM [TBL_USUARIOS] WHERE [EMAIL] = @EMAIL" 
            InsertCommand="INSERT INTO [TBL_USUARIOS] ([EMAIL], [COD_PERFIL], [COD_FUNCAO], [ID_EQUIPE], [NOME], [COD_INTERNO], [ATIVO], [BLOQUEADO], [LOGIN], [SISTEMA], [COD_FUNCAO], [EMAIL_DIRETOR], [EMAIL_GERENTE], [EMAIL_COORDENADOR], [ANO_NASCIMENTO], [MES_NASCIMENTO], [DIA_NASCIMENTO], [TELEFONE], [INCLUSAO_EMAIL], [INCLUSAO_DATA], [ALTERACAO_EMAIL], [ALTERACAO_DATA], [EXCLUSAO_EMAIL], [EXCLUSAO_DATA]) VALUES (@EMAIL, @COD_PERFIL, @COD_FUNCAO, @ID_EQUIPE, @NOME, @SENHA, @NUM_INTERNO, @ATIVO, @BLOQUEADO, @LOGIN, @SISTEMA, @COD_FUNCAO, @DIRETOR, @GERENTE, @COORDENADOR, @ANO_NASCIMENTO, @MES_NASCIMENTO, @DIA_NASCIMENTO, @TELEFONE, @INCLUSAO_EMAIL, @INCLUSAO_DATA, @ALTERACAO_EMAIL, @ALTERACAO_DATA, @EXCLUSAO_EMAIL, @EXCLUSAO_DATA)" 
            SelectCommand="SELECT * FROM [TBL_USUARIOS] WHERE ([EMAIL] = @EMAIL)" 
            UpdateCommand="UPDATE [TBL_USUARIOS] SET [COD_PERFIL] = @COD_PERFIL, [COD_FUNCAO] = @COD_FUNCAO, [ID_EQUIPE] = @ID_EQUIPE, [NOME] = @NOME, [COD_INTERNO] = @COD_INTERNO, [ATIVO] = @ATIVO, [BLOQUEADO] = @BLOQUEADO, [LOGIN] = @LOGIN, [ADMINISTRADOR_SETORIZACAO] = @ADMINISTRADOR_SETORIZACAO, [ADMINISTRADOR_COTAS] = @ADMINISTRADOR_COTAS, [CALCULO_INCENTIVO] = @CALCULO_INCENTIVO, [DOWNLOAD] = @DOWNLOAD, [UPLOAD] = @UPLOAD, [UPLOAD_MAPAS] = @UPLOAD_MAPAS, [SISTEMA] = @SISTEMA, [EMAIL_DIRETOR] = @EMAIL_DIRETOR, [EMAIL_GERENTE] = @EMAIL_GERENTE, [EMAIL_COORDENADOR] = @EMAIL_COORDENADOR, [ANO_NASCIMENTO] = @ANO_NASCIMENTO, [MES_NASCIMENTO] = @MES_NASCIMENTO, [DIA_NASCIMENTO] = @DIA_NASCIMENTO, [TELEFONE] = @TELEFONE, [FIXO] = @FIXO, [INCLUSAO_EMAIL] = @INCLUSAO_EMAIL, [INCLUSAO_DATA] = @INCLUSAO_DATA, [ALTERACAO_EMAIL] = @ALTERACAO_EMAIL, [ALTERACAO_DATA] = @ALTERACAO_DATA, [EXCLUSAO_EMAIL] = @EXCLUSAO_EMAIL, [EXCLUSAO_DATA] = @EXCLUSAO_DATA WHERE [EMAIL] = @EMAIL">
            <DeleteParameters>
                <asp:Parameter Name="EMAIL" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="EMAIL" Type="String" />
                <asp:Parameter Name="COD_PERFIL" Type="Decimal" />
                <asp:Parameter Name="ID_EQUIPE" Type="Decimal" />
                <asp:Parameter Name="NOME" Type="String" />
                <asp:Parameter Name="NUM_INTERNO" />
                <asp:Parameter Name="ATIVO" Type="Boolean" />
                <asp:Parameter Name="BLOQUEADO" Type="Boolean" />
                <asp:Parameter Name="LOGIN" Type="Boolean" />
                <asp:Parameter Name="ADMINISTRADOR_SETORIZACAO" Type="Boolean" />
                <asp:Parameter Name="ADMINISTRADOR_COTAS" Type="Boolean" />
                <asp:Parameter Name="CALCULO_INCENTIVO" Type="Boolean" />
                <asp:Parameter Name="SISTEMA" Type="Boolean" />
                <asp:Parameter Name="COD_FUNCAO" Type="String" />
                <asp:Parameter Name="DIRETOR" />
                <asp:Parameter Name="GERENTE" />
                <asp:Parameter Name="COORDENADOR" />
                <asp:Parameter Name="ANO_NASCIMENTO" Type="Decimal" />
                <asp:Parameter Name="MES_NASCIMENTO" Type="Decimal" />
                <asp:Parameter Name="DIA_NASCIMENTO" Type="Decimal" />
                <asp:Parameter Name="TELEFONE" Type="String" />
                <asp:Parameter Name="INCLUSAO_EMAIL" Type="String" />
                <asp:Parameter Name="INCLUSAO_DATA" Type="Decimal" />
                <asp:Parameter Name="ALTERACAO_EMAIL" Type="String" />
                <asp:Parameter Name="ALTERACAO_DATA" Type="Decimal" />
                <asp:Parameter Name="EXCLUSAO_EMAIL" Type="String" />
                <asp:Parameter Name="EXCLUSAO_DATA" Type="Decimal" />
            </InsertParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="EMAIL" QueryStringField="email" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="COD_PERFIL" Type="Decimal" />
                <asp:Parameter Name="ID_EQUIPE" Type="Decimal" />
                <asp:Parameter Name="NOME" Type="String" />
                <asp:Parameter Name="COD_INTERNO" Type="String" />
                <asp:Parameter Name="ATIVO" Type="Boolean" />
                <asp:Parameter Name="BLOQUEADO" Type="Boolean" />
                <asp:Parameter Name="LOGIN" Type="Boolean" />
                <asp:Parameter Name="ADMINISTRADOR_SETORIZACAO" Type="Boolean" />
                <asp:Parameter Name="ADMINISTRADOR_COTAS" Type="Boolean" />
                <asp:Parameter Name="CALCULO_INCENTIVO" Type="Boolean" />
                <asp:Parameter Name="DOWNLOAD" Type="Boolean" />
                <asp:Parameter Name="UPLOAD" Type="Boolean" />
                <asp:Parameter Name="UPLOAD_MAPAS" Type="Boolean" />                     
                <asp:Parameter Name="SISTEMA" Type="Boolean" />
                <asp:Parameter Name="COD_FUNCAO" Type="String" />
                <asp:Parameter Name="EMAIL_DIRETOR" Type="String" />
                <asp:Parameter Name="EMAIL_GERENTE" Type="String" />
                <asp:Parameter Name="EMAIL_COORDENADOR" Type="String" />
                <asp:Parameter Name="ANO_NASCIMENTO" Type="Decimal" />
                <asp:Parameter Name="MES_NASCIMENTO" Type="Decimal" />
                <asp:Parameter Name="DIA_NASCIMENTO" Type="Decimal" />
                <asp:Parameter Name="TELEFONE" Type="String" />
                <asp:Parameter Name="FIXO" Type="String" />
                <asp:Parameter Name="INCLUSAO_EMAIL" Type="String" />
                <asp:Parameter Name="INCLUSAO_DATA" Type="Decimal" />
                <asp:Parameter Name="ALTERACAO_EMAIL" Type="String" />
                <asp:Parameter Name="ALTERACAO_DATA" Type="Decimal" />
                <asp:Parameter Name="EXCLUSAO_EMAIL" Type="String" />
                <asp:Parameter Name="EXCLUSAO_DATA" Type="Decimal" />
                <asp:Parameter Name="EMAIL" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>