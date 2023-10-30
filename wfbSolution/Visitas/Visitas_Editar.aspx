<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Visitas_Editar.aspx.vb" Inherits="Visitas_Editar" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Editar Visita</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style2
        {
            font-size: small;
            color: #FF0000;
        }
        .auto-style3 {
            font-size: medium;
            color: #FF0000;
        }
    </style>
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Editar Visita&nbsp;</div>
    <div id ="Titulo_Pagina_Links"><a href="Visita_Ficha.aspx?ID_VISITA=<%=Session("ID_VISITA")%>&PAGINA=<%=Session("PAGINA")%>">Voltar</a>&nbsp;</div>      
</div>
<br />
<div id ="Corpo">
    <br />
    <span class="auto-style1">Só será disponibilizado para alteração as informações da próxima visita.</span><br />
    <asp:FormView ID="frm_Visita" runat="server" DataSourceID="dts_Visitas" style="margin-right: 470px" Width="100%">
            <EditItemTemplate>
                ID_VISITA:
                <asp:Label ID="ID_VISITALabel1" runat="server" Text='<%# Eval("ID_VISITA") %>' />
                <br />
                ID_DATA:
                <asp:TextBox ID="ID_DATATextBox" runat="server" Text='<%# Bind("ID_DATA") %>' />
                <br />
                DATA_VISITA:
                <asp:TextBox ID="DATA_VISITATextBox" runat="server" Text='<%# Bind("DATA_VISITA") %>' />
                <br />
                DIA_INCLUSAO:
                <asp:TextBox ID="DIA_INCLUSAOTextBox" runat="server" Text='<%# Bind("DIA_INCLUSAO") %>' />
                <br />
                ANO_VISITA:
                <asp:TextBox ID="ANO_VISITATextBox" runat="server" Text='<%# Bind("ANO_VISITA") %>' />
                <br />
                MES_VISITA_SIGLA:
                <asp:TextBox ID="MES_VISITA_SIGLATextBox" runat="server" Text='<%# Bind("MES_VISITA_SIGLA") %>' />
                <br />
                MES_VISITA:
                <asp:TextBox ID="MES_VISITATextBox" runat="server" Text='<%# Bind("MES_VISITA") %>' />
                <br />
                DIA_VISITA:
                <asp:TextBox ID="DIA_VISITATextBox" runat="server" Text='<%# Bind("DIA_VISITA") %>' />
                <br />
                DATA:
                <asp:TextBox ID="DATATextBox" runat="server" Text='<%# Bind("DATA") %>' />
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
                ESTABELECIMENTO:
                <asp:TextBox ID="ESTABELECIMENTOTextBox" runat="server" Text='<%# Bind("ESTABELECIMENTO") %>' />
                <br />
                GRUPO:
                <asp:TextBox ID="GRUPOTextBox" runat="server" Text='<%# Bind("GRUPO") %>' />
                <br />
                MUNICIPIO:
                <asp:TextBox ID="MUNICIPIOTextBox" runat="server" Text='<%# Bind("MUNICIPIO") %>' />
                <br />
                UF:
                <asp:TextBox ID="UFTextBox" runat="server" Text='<%# Bind("UF") %>' />
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
                ID_TIPO_VISITADO:
                <asp:TextBox ID="ID_TIPO_VISITADOTextBox" runat="server" Text='<%# Bind("ID_TIPO_VISITADO") %>' />
                <br />
                TIPO_VISITADO:
                <asp:TextBox ID="TIPO_VISITADOTextBox" runat="server" Text='<%# Bind("TIPO_VISITADO") %>' />
                <br />
                ID_MEDICO:
                <asp:TextBox ID="ID_MEDICOTextBox" runat="server" Text='<%# Bind("ID_MEDICO") %>' />
                <br />
                ID_CONTATO:
                <asp:TextBox ID="ID_CONTATOTextBox" runat="server" Text='<%# Bind("ID_CONTATO") %>' />
                <br />
                ID_PESSOA:
                <asp:TextBox ID="ID_PESSOATextBox" runat="server" Text='<%# Bind("ID_PESSOA") %>' />
                <br />
                ID:
                <asp:TextBox ID="IDTextBox" runat="server" Text='<%# Bind("ID") %>' />
                <br />
                NOME:
                <asp:TextBox ID="NOMETextBox" runat="server" Text='<%# Bind("NOME") %>' />
                <br />
                CARGO:
                <asp:TextBox ID="CARGOTextBox" runat="server" Text='<%# Bind("CARGO") %>' />
                <br />
                AREA:
                <asp:TextBox ID="AREATextBox" runat="server" Text='<%# Bind("AREA") %>' />
                <br />
                CRMUF:
                <asp:TextBox ID="CRMUFTextBox" runat="server" Text='<%# Bind("CRMUF") %>' />
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
                ID_PERIODO:
                <asp:TextBox ID="ID_PERIODOTextBox" runat="server" Text='<%# Bind("ID_PERIODO") %>' />
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
                INCLUSAO_DATA:
                <asp:TextBox ID="INCLUSAO_DATATextBox" runat="server" Text='<%# Bind("INCLUSAO_DATA") %>' />
                <br />
                INCLUSAO_EMAIL:
                <asp:TextBox ID="INCLUSAO_EMAILTextBox" runat="server" Text='<%# Bind("INCLUSAO_EMAIL") %>' />
                <br />
                EMAIL_GERENTE_CONTA:
                <asp:TextBox ID="EMAIL_GERENTE_CONTATextBox" runat="server" Text='<%# Bind("EMAIL_GERENTE_CONTA") %>' />
                <br />
                GERENTE_CONTA:
                <asp:TextBox ID="GERENTE_CONTATextBox" runat="server" Text='<%# Bind("GERENTE_CONTA") %>' />
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
                JAN:
                <asp:TextBox ID="JANTextBox" runat="server" Text='<%# Bind("JAN") %>' />
                <br />
                FEV:
                <asp:TextBox ID="FEVTextBox" runat="server" Text='<%# Bind("FEV") %>' />
                <br />
                MAR:
                <asp:TextBox ID="MARTextBox" runat="server" Text='<%# Bind("MAR") %>' />
                <br />
                ABR:
                <asp:TextBox ID="ABRTextBox" runat="server" Text='<%# Bind("ABR") %>' />
                <br />
                MAI:
                <asp:TextBox ID="MAITextBox" runat="server" Text='<%# Bind("MAI") %>' />
                <br />
                JUN:
                <asp:TextBox ID="JUNTextBox" runat="server" Text='<%# Bind("JUN") %>' />
                <br />
                JUL:
                <asp:TextBox ID="JULTextBox" runat="server" Text='<%# Bind("JUL") %>' />
                <br />
                AGO:
                <asp:TextBox ID="AGOTextBox" runat="server" Text='<%# Bind("AGO") %>' />
                <br />
                SET:
                <asp:TextBox ID="SETTextBox" runat="server" Text='<%# Bind("SET") %>' />
                <br />
                OUT:
                <asp:TextBox ID="OUTTextBox" runat="server" Text='<%# Bind("OUT") %>' />
                <br />
                NOV:
                <asp:TextBox ID="NOVTextBox" runat="server" Text='<%# Bind("NOV") %>' />
                <br />
                DEZ:
                <asp:TextBox ID="DEZTextBox" runat="server" Text='<%# Bind("DEZ") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
            <InsertItemTemplate>
                ID_DATA:
                <asp:TextBox ID="ID_DATATextBox" runat="server" Text='<%# Bind("ID_DATA") %>' />
                <br />
                DATA_VISITA:
                <asp:TextBox ID="DATA_VISITATextBox" runat="server" Text='<%# Bind("DATA_VISITA") %>' />
                <br />
                DIA_INCLUSAO:
                <asp:TextBox ID="DIA_INCLUSAOTextBox" runat="server" Text='<%# Bind("DIA_INCLUSAO") %>' />
                <br />
                ANO_VISITA:
                <asp:TextBox ID="ANO_VISITATextBox" runat="server" Text='<%# Bind("ANO_VISITA") %>' />
                <br />
                MES_VISITA_SIGLA:
                <asp:TextBox ID="MES_VISITA_SIGLATextBox" runat="server" Text='<%# Bind("MES_VISITA_SIGLA") %>' />
                <br />
                MES_VISITA:
                <asp:TextBox ID="MES_VISITATextBox" runat="server" Text='<%# Bind("MES_VISITA") %>' />
                <br />
                DIA_VISITA:
                <asp:TextBox ID="DIA_VISITATextBox" runat="server" Text='<%# Bind("DIA_VISITA") %>' />
                <br />
                DATA:
                <asp:TextBox ID="DATATextBox" runat="server" Text='<%# Bind("DATA") %>' />
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
                ESTABELECIMENTO:
                <asp:TextBox ID="ESTABELECIMENTOTextBox" runat="server" Text='<%# Bind("ESTABELECIMENTO") %>' />
                <br />
                GRUPO:
                <asp:TextBox ID="GRUPOTextBox" runat="server" Text='<%# Bind("GRUPO") %>' />
                <br />
                MUNICIPIO:
                <asp:TextBox ID="MUNICIPIOTextBox" runat="server" Text='<%# Bind("MUNICIPIO") %>' />
                <br />
                UF:
                <asp:TextBox ID="UFTextBox" runat="server" Text='<%# Bind("UF") %>' />
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
                ID_TIPO_VISITADO:
                <asp:TextBox ID="ID_TIPO_VISITADOTextBox" runat="server" Text='<%# Bind("ID_TIPO_VISITADO") %>' />
                <br />
                TIPO_VISITADO:
                <asp:TextBox ID="TIPO_VISITADOTextBox" runat="server" Text='<%# Bind("TIPO_VISITADO") %>' />
                <br />
                ID_MEDICO:
                <asp:TextBox ID="ID_MEDICOTextBox" runat="server" Text='<%# Bind("ID_MEDICO") %>' />
                <br />
                ID_CONTATO:
                <asp:TextBox ID="ID_CONTATOTextBox" runat="server" Text='<%# Bind("ID_CONTATO") %>' />
                <br />
                ID_PESSOA:
                <asp:TextBox ID="ID_PESSOATextBox" runat="server" Text='<%# Bind("ID_PESSOA") %>' />
                <br />
                ID:
                <asp:TextBox ID="IDTextBox" runat="server" Text='<%# Bind("ID") %>' />
                <br />
                NOME:
                <asp:TextBox ID="NOMETextBox" runat="server" Text='<%# Bind("NOME") %>' />
                <br />
                CARGO:
                <asp:TextBox ID="CARGOTextBox" runat="server" Text='<%# Bind("CARGO") %>' />
                <br />
                AREA:
                <asp:TextBox ID="AREATextBox" runat="server" Text='<%# Bind("AREA") %>' />
                <br />
                CRMUF:
                <asp:TextBox ID="CRMUFTextBox" runat="server" Text='<%# Bind("CRMUF") %>' />
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
                ID_PERIODO:
                <asp:TextBox ID="ID_PERIODOTextBox" runat="server" Text='<%# Bind("ID_PERIODO") %>' />
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
                INCLUSAO_DATA:
                <asp:TextBox ID="INCLUSAO_DATATextBox" runat="server" Text='<%# Bind("INCLUSAO_DATA") %>' />
                <br />
                INCLUSAO_EMAIL:
                <asp:TextBox ID="INCLUSAO_EMAILTextBox" runat="server" Text='<%# Bind("INCLUSAO_EMAIL") %>' />
                <br />
                EMAIL_GERENTE_CONTA:
                <asp:TextBox ID="EMAIL_GERENTE_CONTATextBox" runat="server" Text='<%# Bind("EMAIL_GERENTE_CONTA") %>' />
                <br />
                GERENTE_CONTA:
                <asp:TextBox ID="GERENTE_CONTATextBox" runat="server" Text='<%# Bind("GERENTE_CONTA") %>' />
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
                JAN:
                <asp:TextBox ID="JANTextBox" runat="server" Text='<%# Bind("JAN") %>' />
                <br />
                FEV:
                <asp:TextBox ID="FEVTextBox" runat="server" Text='<%# Bind("FEV") %>' />
                <br />
                MAR:
                <asp:TextBox ID="MARTextBox" runat="server" Text='<%# Bind("MAR") %>' />
                <br />
                ABR:
                <asp:TextBox ID="ABRTextBox" runat="server" Text='<%# Bind("ABR") %>' />
                <br />
                MAI:
                <asp:TextBox ID="MAITextBox" runat="server" Text='<%# Bind("MAI") %>' />
                <br />
                JUN:
                <asp:TextBox ID="JUNTextBox" runat="server" Text='<%# Bind("JUN") %>' />
                <br />
                JUL:
                <asp:TextBox ID="JULTextBox" runat="server" Text='<%# Bind("JUL") %>' />
                <br />
                AGO:
                <asp:TextBox ID="AGOTextBox" runat="server" Text='<%# Bind("AGO") %>' />
                <br />
                SET:
                <asp:TextBox ID="SETTextBox" runat="server" Text='<%# Bind("SET") %>' />
                <br />
                OUT:
                <asp:TextBox ID="OUTTextBox" runat="server" Text='<%# Bind("OUT") %>' />
                <br />
                NOV:
                <asp:TextBox ID="NOVTextBox" runat="server" Text='<%# Bind("NOV") %>' />
                <br />
                DEZ:
                <asp:TextBox ID="DEZTextBox" runat="server" Text='<%# Bind("DEZ") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </InsertItemTemplate>
            <ItemTemplate>
                <strong>ID:</strong>
                <asp:Label ID="ID_VISITALabel" runat="server" Text='<%# Eval("ID_VISITA") %>' />
                &nbsp;- <strong>Data: </strong>
                <asp:Label ID="DATALabel" runat="server" Text='<%# Bind("DATA") %>' />
                <br />
                <strong>Período:</strong>
                <asp:Label ID="PERIODOLabel" runat="server" Text='<%# Bind("PERIODO") %>' />
                &nbsp;- <strong>Tempo: </strong>
                <asp:Label ID="TEMPOLabel" runat="server" Text='<%# Bind("TEMPO") %>' />
                <br />
                <strong>Visitante:</strong>
                <asp:Label ID="VISITANTELabel" runat="server" Text='<%# Bind("VISITANTE") %>' />
                &nbsp; - <asp:Label ID="EMAIL_VISITANTELabel" runat="server" Text='<%# Bind("EMAIL_VISITANTE") %>' />
                <br />
                <strong>Estabelecimentos:</strong>
                <asp:Label ID="ESTABELECIMENTO_CNPJLabel" runat="server" Text='<%# Bind("ESTABELECIMENTO_CNPJ") %>' />
                <br />
                <strong>Visitado:</strong>
                <asp:Label ID="NOMELabel" runat="server" Text='<%# Bind("NOME") %>' />
                &nbsp;-
                <asp:Label ID="CARGOLabel" runat="server" Text='<%# Bind("CARGO") %>' />
                &nbsp;-
                <asp:Label ID="AREALabel" runat="server" Text='<%# Bind("AREA") %>' />
                <br />
                <strong>Objetivo:</strong>
                <asp:Label ID="OBJETIVOLabel" runat="server" Text='<%# Bind("OBJETIVO") %>' />
                <br />
                <strong>Comentários:</strong>
                <asp:Label ID="COMENTARIOSLabel" runat="server" Text='<%# Bind("COMENTARIOS") %>' />
                <br />
                <strong>Próxima Visita: </strong>
                <asp:Label ID="PROXIMA_VISITALabel" runat="server" Text='<%# Bind("PROXIMA_VISITA") %>' />
                <br />
                <strong>Comentários da Próxima Visita:</strong>
                <br />
                <asp:Label ID="ACAO_PROXIMA_VISITALabel" runat="server" Text='<%# Bind("ACAO_PROXIMA_VISITA") %>' />
                <br />
            </ItemTemplate>
        </asp:FormView>
        
        <br />
    <span class="auto-style3">Caso queira cancelar o agendamento dessa visita, clique no botão &quot;Cancelar Agendamento&quot;.</span><br />
    <asp:Button ID="btn_CANCELAR" runat="server" Text="Cancelar Agendamento" />
    <br />
        
        <br />
        <b>Próxima Visita 
        <br />
        </b>
        <span class="auto-style2">Caso queira alterar selecione a data no calendário</span><b> 
        <asp:Calendar ID="cld_Proxima_Visita" runat="server" Height="16px" Width="50%"></asp:Calendar>
        </b>
        <br />
        <b>Objetivo para próxima visita</b><br />
        <asp:TextBox ID="txt_COMENTARIOS0" runat="server" Rows="3" TextMode="MultiLine" Width="75%"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="cmd_GRAVAR" runat="server" CssClass="buton_gravar" Text="Gravar" Visible="False" />
        <br />
        <br />
        <br />
        <br />
        <asp:SqlDataSource ID="dts_Contatos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_MEDICOS_ESTABELECIMENTOS] WHERE ([CNPJ] = @CNPJ) ORDER BY [NOME]">
            <SelectParameters>
                <asp:SessionParameter Name="CNPJ" SessionField="CNPJ" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_PRODUTOS_LINHAS" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_PRODUTOS_LINHAS]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_Estabelecimento" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS] WHERE ([CNPJ] = @CNPJ)">
            <SelectParameters>
                <asp:SessionParameter Name="CNPJ" SessionField="CNPJ" Type="Decimal" />  
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_VISITAS_OBJETIVOS" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT [ID_OBJETIVO], [OBJETIVO] FROM [TBL_VISITAS_OBJETIVO]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_DATA" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT [ID_DATA], [DATA] FROM [TBL_VISITAS_DATA]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_VISITAS_STATUS" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT [COD_STATUS_VISITA], [STATUS_VISITA] FROM [TBL_VISITAS_STATUS]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_VISITAS_PERIODO" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_VISITAS_PERIODOS]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_VISITAS_TEMPO" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT [MINUTOS], [TEMPO] FROM [TBL_VISITAS_TEMPO]"></asp:SqlDataSource>
    
        <asp:SqlDataSource ID="dts_Visitas" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_VISITAS_GERAL] WHERE ([ID_VISITA] = @ID_VISITA)">
            <SelectParameters>
                <asp:SessionParameter Name="ID_VISITA" SessionField="ID_VISITA" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
    
</div>
</form>
</body>
    
</html>
