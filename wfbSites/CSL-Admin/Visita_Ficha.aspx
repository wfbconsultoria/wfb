<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Visita_Ficha.aspx.vb" Inherits="Visita_Ficha" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Ficha de Visita</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Ficha da Visita</div>
    <div id ="Titulo_Pagina_Links">
        <a href="Visitas_Editar.aspx?ID_VISITA=<%=Request.QueryString("ID_VISITA")%>
            <% If Request.QueryString("CNPJ") <> "" Then%>
                &CNPJ=<%=Request.QueryString("CNPJ")%>
            <%  End If%>
            <% If Request.QueryString("COD_CONTATO") <> "" Then%>
                &COD_CONTATO=<%=Request.QueryString("COD_CONTATO")%>
            <%  End If%>
        ">Alterar</a>&nbsp;
        <% If Request.QueryString("CNPJ") <> "" Then%>
            <a href="Estabelecimentos_Ficha.aspx?CNPJ=<%=Request.QueryString("CNPJ")%>">Ficha do Estabelecimento</a>
        <%  End If%>
        <% If Request.QueryString("COD_CONTATO") <> "" Then%>
            <a href="Contatos_Ficha.aspx?COD_CONTATO=<%=Request.QueryString("COD_CONTATO")%>">Ficha do Contato</a>
        <%  End If%>
    </div>
</div>
<br />
<div id ="Corpo">
    <br />
    <asp:FormView ID="FormView1" runat="server" DataSourceID="dts_Visita" Width="793px">
        <EditItemTemplate>
            ID_VISITA:
            <asp:Label ID="ID_VISITALabel1" runat="server" Text='<%# Eval("ID_VISITA") %>' />
            <br />
            VISITANTE:
            <asp:TextBox ID="VISITANTETextBox" runat="server" Text='<%# Bind("VISITANTE") %>' />
            <br />
            EMAIL_VISITANTE:
            <asp:TextBox ID="EMAIL_VISITANTETextBox" runat="server" Text='<%# Bind("EMAIL_VISITANTE") %>' />
            <br />
            CNPJ:
            <asp:TextBox ID="CNPJTextBox" runat="server" Text='<%# Bind("CNPJ") %>' />
            <br />
            ESTABELECIMENTO_CNPJ:
            <asp:TextBox ID="ESTABELECIMENTO_CNPJTextBox" runat="server" Text='<%# Bind("ESTABELECIMENTO_CNPJ") %>' />
            <br />
            MUNICIPIO:
            <asp:TextBox ID="MUNICIPIOTextBox" runat="server" Text='<%# Bind("MUNICIPIO") %>' />
            <br />
            UF:
            <asp:TextBox ID="UFTextBox" runat="server" Text='<%# Bind("UF") %>' />
            <br />
            EMAIL_GERENTE_CONTA:
            <asp:TextBox ID="EMAIL_GERENTE_CONTATextBox" runat="server" Text='<%# Bind("EMAIL_GERENTE_CONTA") %>' />
            <br />
            GERENTE_CONTA:
            <asp:TextBox ID="GERENTE_CONTATextBox" runat="server" Text='<%# Bind("GERENTE_CONTA") %>' />
            <br />
            TARGET:
            <asp:TextBox ID="TARGETTextBox" runat="server" Text='<%# Bind("TARGET") %>' />
            <br />
            TARGET_2:
            <asp:TextBox ID="TARGET_2TextBox" runat="server" Text='<%# Bind("TARGET_2") %>' />
            <br />
            ESFERA:
            <asp:TextBox ID="ESFERATextBox" runat="server" Text='<%# Bind("ESFERA") %>' />
            <br />
            GESTAO:
            <asp:TextBox ID="GESTAOTextBox" runat="server" Text='<%# Bind("GESTAO") %>' />
            <br />
            CAPITAL:
            <asp:TextBox ID="CAPITALTextBox" runat="server" Text='<%# Bind("CAPITAL") %>' />
            <br />
            LEITOS_UTI_ADULTO:
            <asp:TextBox ID="LEITOS_UTI_ADULTOTextBox" runat="server" Text='<%# Bind("LEITOS_UTI_ADULTO") %>' />
            <br />
            SALAS_CIRURGIA:
            <asp:TextBox ID="SALAS_CIRURGIATextBox" runat="server" Text='<%# Bind("SALAS_CIRURGIA") %>' />
            <br />
            EMAIL_REPRESENTANTE:
            <asp:TextBox ID="EMAIL_REPRESENTANTETextBox" runat="server" Text='<%# Bind("EMAIL_REPRESENTANTE") %>' />
            <br />
            REPRESENTANTE:
            <asp:TextBox ID="REPRESENTANTETextBox" runat="server" Text='<%# Bind("REPRESENTANTE") %>' />
            <br />
            EMAIL_COORDENADOR:
            <asp:TextBox ID="EMAIL_COORDENADORTextBox" runat="server" Text='<%# Bind("EMAIL_COORDENADOR") %>' />
            <br />
            COORDENADOR:
            <asp:TextBox ID="COORDENADORTextBox" runat="server" Text='<%# Bind("COORDENADOR") %>' />
            <br />
            EMAIL_GERENTE:
            <asp:TextBox ID="EMAIL_GERENTETextBox" runat="server" Text='<%# Bind("EMAIL_GERENTE") %>' />
            <br />
            GERENTE:
            <asp:TextBox ID="GERENTETextBox" runat="server" Text='<%# Bind("GERENTE") %>' />
            <br />
            EMAIL_DIRETOR:
            <asp:TextBox ID="EMAIL_DIRETORTextBox" runat="server" Text='<%# Bind("EMAIL_DIRETOR") %>' />
            <br />
            DIRETOR:
            <asp:TextBox ID="DIRETORTextBox" runat="server" Text='<%# Bind("DIRETOR") %>' />
            <br />
            NOME:
            <asp:TextBox ID="NOMETextBox" runat="server" Text='<%# Bind("NOME") %>' />
            <br />
            ID_DATA:
            <asp:TextBox ID="ID_DATATextBox" runat="server" Text='<%# Bind("ID_DATA") %>' />
            <br />
            DIA_INCLUSAO:
            <asp:TextBox ID="DIA_INCLUSAOTextBox" runat="server" Text='<%# Bind("DIA_INCLUSAO") %>' />
            <br />
            DATA_VISITA:
            <asp:TextBox ID="DATA_VISITATextBox" runat="server" Text='<%# Bind("DATA_VISITA") %>' />
            <br />
            DATA:
            <asp:TextBox ID="DATATextBox" runat="server" Text='<%# Bind("DATA") %>' />
            <br />
            PERIODO:
            <asp:TextBox ID="PERIODOTextBox" runat="server" Text='<%# Bind("PERIODO") %>' />
            <br />
            STATUS_VISITA:
            <asp:TextBox ID="STATUS_VISITATextBox" runat="server" Text='<%# Bind("STATUS_VISITA") %>' />
            <br />
            TEMPO:
            <asp:TextBox ID="TEMPOTextBox" runat="server" Text='<%# Bind("TEMPO") %>' />
            <br />
            OBJETIVO:
            <asp:TextBox ID="OBJETIVOTextBox" runat="server" Text='<%# Bind("OBJETIVO") %>' />
            <br />
            COMENTARIOS:
            <asp:TextBox ID="COMENTARIOSTextBox" runat="server" Text='<%# Bind("COMENTARIOS") %>' />
            <br />
            DAT_PROXIMA_VISITA:
            <asp:TextBox ID="DAT_PROXIMA_VISITATextBox" runat="server" Text='<%# Bind("DAT_PROXIMA_VISITA") %>' />
            <br />
            PROXIMA_VISITA:
            <asp:TextBox ID="PROXIMA_VISITATextBox" runat="server" Text='<%# Bind("PROXIMA_VISITA") %>' />
            <br />
            ACAO_PROXIMA_VISITA:
            <asp:TextBox ID="ACAO_PROXIMA_VISITATextBox" runat="server" Text='<%# Bind("ACAO_PROXIMA_VISITA") %>' />
            <br />
            TIPO_VISITADO:
            <asp:TextBox ID="TIPO_VISITADOTextBox" runat="server" Text='<%# Bind("TIPO_VISITADO") %>' />
            <br />
            ID:
            <asp:TextBox ID="IDTextBox" runat="server" Text='<%# Bind("ID") %>' />
            <br />
            Cargo:
            <asp:TextBox ID="CargoTextBox" runat="server" Text='<%# Bind("Cargo") %>' />
            <br />
            ESPECIALIDADE_MEDICO_NO_ESTABELECIMENTO:
            <asp:TextBox ID="ESPECIALIDADE_MEDICO_NO_ESTABELECIMENTOTextBox" runat="server" Text='<%# Bind("ESPECIALIDADE_MEDICO_NO_ESTABELECIMENTO") %>' />
            <br />
            AREA_MEDICO_NO_ESTABELECIMENTO:
            <asp:TextBox ID="AREA_MEDICO_NO_ESTABELECIMENTOTextBox" runat="server" Text='<%# Bind("AREA_MEDICO_NO_ESTABELECIMENTO") %>' />
            <br />
            PERFIL_MEDICO_NO_ESTABELECIMENTO:
            <asp:TextBox ID="PERFIL_MEDICO_NO_ESTABELECIMENTOTextBox" runat="server" Text='<%# Bind("PERFIL_MEDICO_NO_ESTABELECIMENTO") %>' />
            <br />
            INCLUSAO_DATA:
            <asp:TextBox ID="INCLUSAO_DATATextBox" runat="server" Text='<%# Bind("INCLUSAO_DATA") %>' />
            <br />
            INCLUSAO_EMAIL:
            <asp:TextBox ID="INCLUSAO_EMAILTextBox" runat="server" Text='<%# Bind("INCLUSAO_EMAIL") %>' />
            <br />
            CRMUF:
            <asp:TextBox ID="CRMUFTextBox" runat="server" Text='<%# Bind("CRMUF") %>' />
            <br />
            ESTABELECIMENTO:
            <asp:TextBox ID="ESTABELECIMENTOTextBox" runat="server" Text='<%# Bind("ESTABELECIMENTO") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <InsertItemTemplate>
            VISITANTE:
            <asp:TextBox ID="VISITANTETextBox" runat="server" Text='<%# Bind("VISITANTE") %>' />
            <br />
            EMAIL_VISITANTE:
            <asp:TextBox ID="EMAIL_VISITANTETextBox" runat="server" Text='<%# Bind("EMAIL_VISITANTE") %>' />
            <br />
            CNPJ:
            <asp:TextBox ID="CNPJTextBox" runat="server" Text='<%# Bind("CNPJ") %>' />
            <br />
            ESTABELECIMENTO_CNPJ:
            <asp:TextBox ID="ESTABELECIMENTO_CNPJTextBox" runat="server" Text='<%# Bind("ESTABELECIMENTO_CNPJ") %>' />
            <br />
            MUNICIPIO:
            <asp:TextBox ID="MUNICIPIOTextBox" runat="server" Text='<%# Bind("MUNICIPIO") %>' />
            <br />
            UF:
            <asp:TextBox ID="UFTextBox" runat="server" Text='<%# Bind("UF") %>' />
            <br />
            EMAIL_GERENTE_CONTA:
            <asp:TextBox ID="EMAIL_GERENTE_CONTATextBox" runat="server" Text='<%# Bind("EMAIL_GERENTE_CONTA") %>' />
            <br />
            GERENTE_CONTA:
            <asp:TextBox ID="GERENTE_CONTATextBox" runat="server" Text='<%# Bind("GERENTE_CONTA") %>' />
            <br />
            TARGET:
            <asp:TextBox ID="TARGETTextBox" runat="server" Text='<%# Bind("TARGET") %>' />
            <br />
            TARGET_2:
            <asp:TextBox ID="TARGET_2TextBox" runat="server" Text='<%# Bind("TARGET_2") %>' />
            <br />
            ESFERA:
            <asp:TextBox ID="ESFERATextBox" runat="server" Text='<%# Bind("ESFERA") %>' />
            <br />
            GESTAO:
            <asp:TextBox ID="GESTAOTextBox" runat="server" Text='<%# Bind("GESTAO") %>' />
            <br />
            CAPITAL:
            <asp:TextBox ID="CAPITALTextBox" runat="server" Text='<%# Bind("CAPITAL") %>' />
            <br />
            LEITOS_UTI_ADULTO:
            <asp:TextBox ID="LEITOS_UTI_ADULTOTextBox" runat="server" Text='<%# Bind("LEITOS_UTI_ADULTO") %>' />
            <br />
            SALAS_CIRURGIA:
            <asp:TextBox ID="SALAS_CIRURGIATextBox" runat="server" Text='<%# Bind("SALAS_CIRURGIA") %>' />
            <br />
            EMAIL_REPRESENTANTE:
            <asp:TextBox ID="EMAIL_REPRESENTANTETextBox" runat="server" Text='<%# Bind("EMAIL_REPRESENTANTE") %>' />
            <br />
            REPRESENTANTE:
            <asp:TextBox ID="REPRESENTANTETextBox" runat="server" Text='<%# Bind("REPRESENTANTE") %>' />
            <br />
            EMAIL_COORDENADOR:
            <asp:TextBox ID="EMAIL_COORDENADORTextBox" runat="server" Text='<%# Bind("EMAIL_COORDENADOR") %>' />
            <br />
            COORDENADOR:
            <asp:TextBox ID="COORDENADORTextBox" runat="server" Text='<%# Bind("COORDENADOR") %>' />
            <br />
            EMAIL_GERENTE:
            <asp:TextBox ID="EMAIL_GERENTETextBox" runat="server" Text='<%# Bind("EMAIL_GERENTE") %>' />
            <br />
            GERENTE:
            <asp:TextBox ID="GERENTETextBox" runat="server" Text='<%# Bind("GERENTE") %>' />
            <br />
            EMAIL_DIRETOR:
            <asp:TextBox ID="EMAIL_DIRETORTextBox" runat="server" Text='<%# Bind("EMAIL_DIRETOR") %>' />
            <br />
            DIRETOR:
            <asp:TextBox ID="DIRETORTextBox" runat="server" Text='<%# Bind("DIRETOR") %>' />
            <br />
            NOME:
            <asp:TextBox ID="NOMETextBox" runat="server" Text='<%# Bind("NOME") %>' />
            <br />
            ID_DATA:
            <asp:TextBox ID="ID_DATATextBox" runat="server" Text='<%# Bind("ID_DATA") %>' />
            <br />
            DIA_INCLUSAO:
            <asp:TextBox ID="DIA_INCLUSAOTextBox" runat="server" Text='<%# Bind("DIA_INCLUSAO") %>' />
            <br />
            DATA_VISITA:
            <asp:TextBox ID="DATA_VISITATextBox" runat="server" Text='<%# Bind("DATA_VISITA") %>' />
            <br />
            DATA:
            <asp:TextBox ID="DATATextBox" runat="server" Text='<%# Bind("DATA") %>' />
            <br />
            PERIODO:
            <asp:TextBox ID="PERIODOTextBox" runat="server" Text='<%# Bind("PERIODO") %>' />
            <br />
            STATUS_VISITA:
            <asp:TextBox ID="STATUS_VISITATextBox" runat="server" Text='<%# Bind("STATUS_VISITA") %>' />
            <br />
            TEMPO:
            <asp:TextBox ID="TEMPOTextBox" runat="server" Text='<%# Bind("TEMPO") %>' />
            <br />
            OBJETIVO:
            <asp:TextBox ID="OBJETIVOTextBox" runat="server" Text='<%# Bind("OBJETIVO") %>' />
            <br />
            COMENTARIOS:
            <asp:TextBox ID="COMENTARIOSTextBox" runat="server" Text='<%# Bind("COMENTARIOS") %>' />
            <br />
            DAT_PROXIMA_VISITA:
            <asp:TextBox ID="DAT_PROXIMA_VISITATextBox" runat="server" Text='<%# Bind("DAT_PROXIMA_VISITA") %>' />
            <br />
            PROXIMA_VISITA:
            <asp:TextBox ID="PROXIMA_VISITATextBox" runat="server" Text='<%# Bind("PROXIMA_VISITA") %>' />
            <br />
            ACAO_PROXIMA_VISITA:
            <asp:TextBox ID="ACAO_PROXIMA_VISITATextBox" runat="server" Text='<%# Bind("ACAO_PROXIMA_VISITA") %>' />
            <br />
            TIPO_VISITADO:
            <asp:TextBox ID="TIPO_VISITADOTextBox" runat="server" Text='<%# Bind("TIPO_VISITADO") %>' />
            <br />
            ID:
            <asp:TextBox ID="IDTextBox" runat="server" Text='<%# Bind("ID") %>' />
            <br />
            Cargo:
            <asp:TextBox ID="CargoTextBox" runat="server" Text='<%# Bind("Cargo") %>' />
            <br />
            ESPECIALIDADE_MEDICO_NO_ESTABELECIMENTO:
            <asp:TextBox ID="ESPECIALIDADE_MEDICO_NO_ESTABELECIMENTOTextBox" runat="server" Text='<%# Bind("ESPECIALIDADE_MEDICO_NO_ESTABELECIMENTO") %>' />
            <br />
            AREA_MEDICO_NO_ESTABELECIMENTO:
            <asp:TextBox ID="AREA_MEDICO_NO_ESTABELECIMENTOTextBox" runat="server" Text='<%# Bind("AREA_MEDICO_NO_ESTABELECIMENTO") %>' />
            <br />
            PERFIL_MEDICO_NO_ESTABELECIMENTO:
            <asp:TextBox ID="PERFIL_MEDICO_NO_ESTABELECIMENTOTextBox" runat="server" Text='<%# Bind("PERFIL_MEDICO_NO_ESTABELECIMENTO") %>' />
            <br />
            INCLUSAO_DATA:
            <asp:TextBox ID="INCLUSAO_DATATextBox" runat="server" Text='<%# Bind("INCLUSAO_DATA") %>' />
            <br />
            INCLUSAO_EMAIL:
            <asp:TextBox ID="INCLUSAO_EMAILTextBox" runat="server" Text='<%# Bind("INCLUSAO_EMAIL") %>' />
            <br />
            CRMUF:
            <asp:TextBox ID="CRMUFTextBox" runat="server" Text='<%# Bind("CRMUF") %>' />
            <br />
            ESTABELECIMENTO:
            <asp:TextBox ID="ESTABELECIMENTOTextBox" runat="server" Text='<%# Bind("ESTABELECIMENTO") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            <strong>ID:</strong>
            <asp:Label ID="ID_VISITALabel" runat="server" Text='<%# Eval("ID_VISITA") %>' />
            <br />
            <strong>Data:</strong>
            <asp:Label ID="DATA_VISITALabel" runat="server" style="font-weight: 700" Text='<%# Eval("DATA_EXTENSO") %>' />
            &nbsp;-
            <asp:Label ID="PERIODOLabel" runat="server" Text='<%# Bind("PERIODO") %>' />
            -&nbsp;<asp:Label ID="TEMPOLabel" runat="server" Text='<%# Bind("TEMPO") %>' />
            <br />
            <strong>Visitado: </strong><asp:Label ID="VISITADOLabel0" runat="server" style="font-weight: 700" Text='<%# Bind("NOME") %>' />
            &nbsp;<br />
            <strong>Vistante:</strong>
            <asp:Label ID="VISITANTELabel" runat="server" Text='<%# Eval("VISITANTE") %>' />
            <br />
            <strong>Estabelecimento:</strong>
            <asp:Label ID="ESTABELECIMENTO_CNPJLabel" runat="server" Text='<%# Bind("ESTABELECIMENTO_CNPJ") %>' />
            <br />
            <strong>Objetivo:</strong>
            <asp:Label ID="OBJETIVOLabel" runat="server" Text='<%# Bind("OBJETIVO") %>' />
            <br />
            <strong>Comentários:</strong>
            <br />
            <asp:TextBox ID="COMENTARIOSTextBox" runat="server" Text='<%# Bind("COMENTARIOS") %>' Enabled="False" Height="100px" TextMode="MultiLine" Width="100%" style="font-size: medium" />
            <br />
            <br />
            <strong>Próxima Visita: </strong>
            <asp:Label ID="PROXIMA_VISITALabel" runat="server" style="font-weight: 700" Text='<%# Eval("DATA_PROXIMA_EXTENSO") %>' />
            <br />
            <br />
            <asp:TextBox ID="ACAO_PROXIMA_VISITATextBox" runat="server" Text='<%# Bind("ACAO_PROXIMA_VISITA") %>' Enabled="False" Height="100px" TextMode="MultiLine" Width="100%" style="font-size: medium" />
            <br />
            <br />
        </ItemTemplate>
    </asp:FormView>
    <asp:SqlDataSource ID="dts_Visita" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_VISITAS] WHERE ([ID_VISITA] = @ID_VISITA)">
        <SelectParameters>
            <asp:QueryStringParameter Name="ID_VISITA" QueryStringField="ID_VISITA" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
