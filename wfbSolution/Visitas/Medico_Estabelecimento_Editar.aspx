<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Medico_Estabelecimento_Editar.aspx.vb" Inherits="Medico_Estabelecimento_Editar" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Editar Medico no Estabelecimento</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Editar Medico no Estabelecimento</div>
    <div id ="Titulo_Pagina_Links">
        
    </div>
</div>
<br />
<div id ="Corpo">
    
    <br />
    <asp:FormView ID="frv_MEDICO" runat="server" 
        DataSourceID="dts_MEDICOS_ESTABELECIMENTO_VIEW" Width="100%" 
        DataKeyNames="CRMUF">
        <EditItemTemplate>
            CRMUF:
            <asp:Label ID="CRMUFLabel1" runat="server" Text='<%# Eval("CRMUF") %>' />
            <br />
            NOME:
            <asp:TextBox ID="NOMETextBox" runat="server" Text='<%# Bind("NOME") %>' />
            <br />
            ESTABELECIMENTO_CNPJ:
            <asp:TextBox ID="ESTABELECIMENTO_CNPJTextBox" runat="server" Text='<%# Bind("ESTABELECIMENTO_CNPJ") %>' />
            <br />
            ESTABELECIMENTO:
            <asp:TextBox ID="ESTABELECIMENTOTextBox" runat="server" Text='<%# Bind("ESTABELECIMENTO") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <InsertItemTemplate>CRMUF:
            <asp:TextBox ID="CRMUFTextBox" runat="server" Text='<%# Bind("CRMUF") %>' />
            <br />
            NOME:
            <asp:TextBox ID="NOMETextBox" runat="server" Text='<%# Bind("NOME") %>' />
            <br />
            ESTABELECIMENTO_CNPJ:
            <asp:TextBox ID="ESTABELECIMENTO_CNPJTextBox" runat="server" Text='<%# Bind("ESTABELECIMENTO_CNPJ") %>' />
            <br />
            ESTABELECIMENTO:
            <asp:TextBox ID="ESTABELECIMENTOTextBox" runat="server" Text='<%# Bind("ESTABELECIMENTO") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            <strong>
            <asp:Label ID="NOMELabel" runat="server" Text='<%# Bind("NOME") %>' />
            &nbsp;-
            <asp:Label ID="CRMUFLabel" runat="server" Text='<%# Eval("CRMUF") %>' />
            <br />
            <asp:Label ID="ESTABELECIMENTO_CNPJLabel" runat="server" Text='<%# Bind("ESTABELECIMENTO_CNPJ") %>' />
            <br />
            </strong>
            <br />

        </ItemTemplate>
    </asp:FormView>
    <asp:FormView ID="frv_MEDICO_ESTABELECIMENTO" runat="server" DataKeyNames="ID_MEDICO_ESTABELECIMENTO" DataSourceID="dts_MEDICOS_ESTABELECIMENTO" DefaultMode="Edit" Width="100%">
        <EditItemTemplate>
            <strong>Perfil:</strong><br />
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="dts_Perfis" DataTextField="PERFIL" DataValueField="ID_PERFIL" SelectedValue='<%# Bind("ID_PERFIL") %>'>
            </asp:DropDownList>
            <br />
            <strong>Especialidade:</strong><br />
            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="dts_Especialidades" DataTextField="ESPECIALIDADE" DataValueField="ID_ESPECIALIDADE" SelectedValue='<%# Bind("ID_ESPECIALIDADE") %>'>
            </asp:DropDownList>
            <br />
            <strong>Area:</strong><br />
            <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="dts_AREAS" DataTextField="AREA" DataValueField="ID_AREA" SelectedValue='<%# Bind("ID_AREA") %>'>
            </asp:DropDownList>
            <br />
            <strong>Cargo:</strong><br />
            <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="dts_Cargos" DataTextField="CARGO" DataValueField="ID_CARGO" SelectedValue='<%# Bind("ID_CARGO") %>'>
            </asp:DropDownList>
            <br />
            <strong>Telefone:</strong><br />
            <asp:TextBox ID="TELEFONETextBox" runat="server" Text='<%# Bind("TELEFONE") %>'></asp:TextBox>
            <br />
            <strong>Ativo:</strong><br />
            <asp:DropDownList ID="DropDownList5" runat="server" SelectedValue='<%# Bind("ATIVO") %>'>
                <asp:ListItem Value="SIM">Sim</asp:ListItem>
                <asp:ListItem Value="NAO">Não</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Gravar" />
            &nbsp; <a href='Medicos_Ficha.aspx?CRMUF=<%=Session("CRMUF")%>'>Cancelar</a>
        </EditItemTemplate>
        <InsertItemTemplate>
           
        </InsertItemTemplate>
        <ItemTemplate></ItemTemplate>
           
    </asp:FormView>
    <asp:SqlDataSource ID="dts_MEDICOS_ESTABELECIMENTO" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_MEDICOS_ESTABELECIMENTOS] WHERE ([ID_MEDICO_ESTABELECIMENTO] = @ID_MEDICO_ESTABELECIMENTO)" DeleteCommand="DELETE FROM [TBL_MEDICOS_ESTABELECIMENTOS] WHERE [ID_MEDICO_ESTABELECIMENTO] = @ID_MEDICO_ESTABELECIMENTO" InsertCommand="INSERT INTO [TBL_MEDICOS_ESTABELECIMENTOS] ([CRMUF], [CNPJ], [ID_PERFIL], [ID_ESPECIALIDADE], [ID_AREA], [ID_CARGO], [TELEFONE], [ATIVO], [INCLUSAO_EMAIL], [INCLUSAO_DATA], [ALTERACAO_EMAIL], [ALTERACAO_DATA], [EXCLUSAO_EMAIL], [EXCLUSAO_DATA]) VALUES (@CRMUF, @CNPJ, @ID_PERFIL, @ID_ESPECIALIDADE, @ID_AREA, @ID_CARGO, @TELEFONE, @ATIVO, @INCLUSAO_EMAIL, @INCLUSAO_DATA, @ALTERACAO_EMAIL, @ALTERACAO_DATA, @EXCLUSAO_EMAIL, @EXCLUSAO_DATA)" UpdateCommand="UPDATE [TBL_MEDICOS_ESTABELECIMENTOS] SET [ID_PERFIL] = @ID_PERFIL, [ID_ESPECIALIDADE] = @ID_ESPECIALIDADE, [ID_AREA] = @ID_AREA, [ID_CARGO] = @ID_CARGO, [TELEFONE] = @TELEFONE, [ATIVO] = @ATIVO WHERE [ID_MEDICO_ESTABELECIMENTO] = @ID_MEDICO_ESTABELECIMENTO">
        <DeleteParameters>
            <asp:Parameter Name="ID_MEDICO_ESTABELECIMENTO" Type="Decimal" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CRMUF" Type="String" />
            <asp:Parameter Name="CNPJ" Type="Decimal" />
            <asp:Parameter Name="ID_PERFIL" Type="Decimal" />
            <asp:Parameter Name="ID_ESPECIALIDADE" Type="Decimal" />
            <asp:Parameter Name="ID_AREA" Type="Decimal" />
            <asp:Parameter Name="ID_CARGO" Type="Decimal" />
            <asp:Parameter Name="TELEFONE" Type="String" />
            <asp:Parameter Name="ATIVO" Type="String" />
            <asp:Parameter Name="INCLUSAO_EMAIL" Type="String" />
            <asp:Parameter Name="INCLUSAO_DATA" Type="Decimal" />
            <asp:Parameter Name="ALTERACAO_EMAIL" Type="String" />
            <asp:Parameter Name="ALTERACAO_DATA" Type="Decimal" />
            <asp:Parameter Name="EXCLUSAO_EMAIL" Type="String" />
            <asp:Parameter Name="EXCLUSAO_DATA" Type="Decimal" />
        </InsertParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="ID_MEDICO_ESTABELECIMENTO" QueryStringField="ID_MEDICO_ESTABELECIMENTO" Type="Decimal" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="ID_PERFIL" Type="Decimal" />
            <asp:Parameter Name="ID_ESPECIALIDADE" Type="Decimal" />
            <asp:Parameter Name="ID_AREA" Type="Decimal" />
            <asp:Parameter Name="ID_CARGO" Type="Decimal" />
<asp:Parameter Name="TELEFONE" Type="String"></asp:Parameter>
            <asp:Parameter Name="ATIVO" Type="String" />
            <asp:Parameter Name="ID_MEDICO_ESTABELECIMENTO" Type="Decimal" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Especialidades" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [TBL_MEDICOS_ESPECIALIDADES] ORDER BY [ESPECIALIDADE]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Cargos" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [TBL_MEDICOS_CARGOS] ORDER BY [ID_CARGO]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Perfis" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
                        SelectCommand="SELECT * FROM [TBL_MEDICOS_PERFIL] ORDER BY [PERFIL]">
                    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_AREAS" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [TBL_MEDICOS_AREAS] ORDER BY [AREA]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="TBL_DATAS_MESES" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
                        
                        SelectCommand="SELECT [MES_NUMERO_VALOR], [MES_SIGLA] FROM [TBL_DATAS_MESES] ORDER BY [MES_NUMERO_VALOR]">
                    </asp:SqlDataSource>
    <asp:SqlDataSource ID="TBL_DATAS_DIAS" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
                        
                        SelectCommand="SELECT [DIA_NUMERO_VALOR], [DIA_NUMERO_TEXTO] FROM [TBL_DATAS_DIAS] ORDER BY [DIA_NUMERO_VALOR]">
                    </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="dts_MEDICOS_ESTABELECIMENTO_VIEW" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT [CRMUF], [NOME], [ESTABELECIMENTO_CNPJ], [ESTABELECIMENTO] FROM [VIEW_MEDICOS_ESTABELECIMENTOS] WHERE ([ID_MEDICO_ESTABELECIMENTO] = @ID_MEDICO_ESTABELECIMENTO)">
        <SelectParameters>
            <asp:QueryStringParameter Name="ID_MEDICO_ESTABELECIMENTO" QueryStringField="ID_MEDICO_ESTABELECIMENTO" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
