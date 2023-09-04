<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Distribuidores_Editar.aspx.vb" Inherits="Distribuidores_Editar" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>
<!DOCTYPE html><html xmlns="http://www.w3.org/1999/xhtml"><head id="Head1" runat="server"><title>Início</title><link rel="stylesheet" type="text/css" href="App_Themes/MasterTheme/Master.css" />
    </head><body><uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Alterar Cadastro do Distribuidor</div>
    <div id ="Titulo_Pagina_Links">
        <a href="Distribuidores_Pesquisa_RF.aspx">Incluir novo</a>&nbsp;&nbsp;
        <a href="Distribuidores_Ficha.aspx?CNPJ=<%=Request.QueryString("CNPJ")%>">Ficha do Distribuidor</a>
        &nbsp;<a href="Menu_Distribuidor.aspx">Menu Distribuidor</a>
    </div>
</div>
<br />   <br /> 
<div id ="Corpo">
    <asp:FormView ID="frm_DISTRIBUIDOR_EDITAR" runat="server" DataKeyNames="CNPJ" DataSourceID="dts_Distribuidores" DefaultMode="Edit" Width="1367px">
        <EditItemTemplate>
            <strong>Ficha de Pessoa </strong>
                    <asp:Label ID="lbl_TIPO_PESSOA" runat="server" style="font-weight: 700" Text='<%# Eval("TIPO_PESSOA") %>'></asp:Label>
                    <br />
                    CNPJ:
                    <asp:Label ID="lbl_CNPJ_FORMATADO" runat="server" style="color: #808080" Text='<%# Eval("CNPJ_FORMATADO") %>'></asp:Label>
                    &nbsp;&nbsp;&nbsp; Código Interno:
                    <asp:TextBox ID="txt_COD_INTERNO" runat="server" Height="20px" Text='<%# Bind("COD_INTERNO") %>' />
                    <br />
                    Razão Social:
                    <asp:Label ID="lbl_RAZAO_SOCIAL" runat="server" CssClass="auto-style1" Text='<%# Eval("RAZAO_SOCIAL") %>'></asp:Label>
                    <br />
                    Nome Fantasia:
                    <asp:Label ID="lbl_NOME_FANTASIA" runat="server" CssClass="auto-style1" Text='<%# Eval("NOME_FANTASIA") %>'></asp:Label>
                    <br />
                    Grupo:
                    <asp:DropDownList ID="ID_GRUPO_ESTABELECIMENTOTextBox" runat="server" DataSourceID="dts_Grupos_Distribuidores" DataTextField="GRUPO_DISTRIBUIDOR" DataValueField="ID_GRUPO_DISTRIBUIDOR" SelectedValue='<%# Bind("ID_GRUPO_DISTRIBUIDOR")%>'>
                    </asp:DropDownList>
                    <br />
                    <br />
                    Endereço:
                    <asp:Label ID="lbl_ENDERECO" runat="server" Text='<%# Eval("ENDERECO") %>'></asp:Label>
                    <br />
                    Complemento:
                    <asp:Label ID="lbl_COMPLEMENTO" runat="server" Text='<%# Eval("COMPLEMENTO") %>'></asp:Label>
                    <br />
                    Bairro:
                    <asp:Label ID="lbl_BAIRRO" runat="server" CssClass="auto-style1" Text='<%# Eval("BAIRRO") %>'></asp:Label>
                    <br />
                    CEP:
                    <asp:Label ID="lbl_CEP" runat="server" CssClass="auto-style1" Text='<%# Eval("CEP") %>'></asp:Label>
                    <br />
                    Cidade:
                    <asp:Label ID="lbl_MUNICIPIO" runat="server" CssClass="auto-style1" Text='<%# Eval("MUNICIPIO")%>'></asp:Label>
                    <br />
                    UF:
                    <asp:Label ID="lbl_UF" runat="server" CssClass="auto-style1" Text='<%# Eval("UF") %>'></asp:Label>
                    <br />
                    <br />
                    Natureza Juridica:
                    <asp:Label ID="lbl_NATUREZA_JURIDICA" runat="server" CssClass="auto-style1" Text='<%# Eval("NATUREZA_JURIDICA_DESCRICAO") %>'></asp:Label>
                    <br />
                    Esfera Administrativa:
                    <asp:Label ID="lbl_ESFERA" runat="server" CssClass="auto-style1" Text='<%# Eval("ESFERA") %>'></asp:Label>
                    <br />
                    Gestão:
                    <asp:Label ID="lbl_GESTAO" runat="server" CssClass="auto-style1" Text='<%# Eval("GESTAO") %>'></asp:Label>
                    <br />
                    <br />
                    Mês de Inicio:
                    <asp:DropDownList ID="cmb_MES_INICIO" runat="server" SelectedValue='<%# Bind("PERIODO_INICIO_MES") %>' DataSourceID="dts_Meses" DataTextField="MES_EXTENSO" DataValueField="MES">
                    </asp:DropDownList>
                    <br />
                    Ano Inicio:
                    <asp:DropDownList ID="cmb_ANO_INICIO" runat="server" DataSourceID="dts_Anos" DataTextField="ANO" DataValueField="ANO" SelectedValue='<%# Bind("PERIODO_INICIO_ANO") %>'>
                    </asp:DropDownList>
                    <br />
                    <br />
                    Mês Final :
                    <asp:DropDownList ID="cmb_MES_FIM" runat="server" DataSourceID="dts_Meses" DataTextField="MES_EXTENSO" DataValueField="MES" SelectedValue='<%# Bind("PERIODO_FIM_MES") %>'>
                    </asp:DropDownList>
                    <br />
                    Ano Final:
                    <asp:DropDownList ID="cmb_ANO_FIM" runat="server" DataSourceID="dts_Anos" DataTextField="ANO" DataValueField="ANO" SelectedValue='<%# Bind("PERIODO_FIM_ANO") %>'>
                    </asp:DropDownList>
                    <br />
                    <br />
                    Nome do Contato:<br />
                    <asp:TextBox ID="txt_NOME_CONTATO" runat="server" Text='<%# Bind("NOME_CONTATO") %>' Width="50%" />
                    <br />
                    Telefone:<br />
                    <asp:TextBox ID="txt_TELEFONE" runat="server" Height="20px" Text='<%# Bind("TELEFONE") %>' Width="50%"></asp:TextBox>
                    <br />
                    E-mail do Contato:<br />
                    <asp:TextBox ID="txt_EMAIL_CONTATO" runat="server" Height="20px" Text='<%# Bind("EMAIL_CONTATO") %>' Width="50%"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="rev_EMAIL" runat="server" ControlToValidate="txt_EMAIL_CONTATO" Display="Dynamic" ErrorMessage="EMAIL INVÁLIDO" style="color: #FF0000;" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <br />
                    <br />
                    Captar Demanda:
                    <asp:CheckBox ID="chk_CAPTAR_DEMANDA" runat="server" Checked='<%# Bind("CAPTAR_DEMANDA") %>' />
                    <br />
                    Captar Estoque:
                    <asp:CheckBox ID="chk_CAPTAR_ESTOQUE" runat="server" Checked='<%# Bind("CAPTAR_ESTOQUE") %>' />
                    <br />
                    <br />
            <asp:Button ID="cmd_Gravar" runat="server" CommandName="Update" CssClass="buton_gravar" Text="Gravar" />
            &nbsp;<asp:Button ID="cmd_Cancelar" runat="server" CssClass="buton_gravar" OnClick="cmd_Cancelar_Click" Text="Cancelar" />           
        </EditItemTemplate>
        <InsertItemTemplate>
            CNPJ:
            <asp:TextBox ID="CNPJTextBox" runat="server" Text='<%# Bind("CNPJ") %>' />
            <br />
            CNPJ_FORMATADO:
            <asp:TextBox ID="CNPJ_FORMATADOTextBox" runat="server" Text='<%# Bind("CNPJ_FORMATADO") %>' />
            <br />
            CNES:
            <asp:TextBox ID="CNESTextBox" runat="server" Text='<%# Bind("CNES") %>' />
            <br />
            COD_INTERNO:
            <asp:TextBox ID="COD_INTERNOTextBox" runat="server" Text='<%# Bind("COD_INTERNO") %>' />
            <br />
            TIPO_PESSOA:
            <asp:TextBox ID="TIPO_PESSOATextBox" runat="server" Text='<%# Bind("TIPO_PESSOA") %>' />
            <br />
            COD_TIPO_PESSOA:
            <asp:TextBox ID="COD_TIPO_PESSOATextBox" runat="server" Text='<%# Bind("COD_TIPO_PESSOA") %>' />
            <br />
            ID_GRUPO_DISTRIBUIDOR:
            <asp:TextBox ID="ID_GRUPO_DISTRIBUIDORTextBox" runat="server" Text='<%# Bind("ID_GRUPO_DISTRIBUIDOR") %>' />
            <br />
            APELIDO:
            <asp:TextBox ID="APELIDOTextBox" runat="server" Text='<%# Bind("APELIDO") %>' />
            <br />
            ESTABELECIMENTO:
            <asp:TextBox ID="ESTABELECIMENTOTextBox" runat="server" Text='<%# Bind("ESTABELECIMENTO") %>' />
            <br />
            ESTABELECIMENTO_CNPJ:
            <asp:TextBox ID="ESTABELECIMENTO_CNPJTextBox" runat="server" Text='<%# Bind("ESTABELECIMENTO_CNPJ") %>' />
            <br />
            RAZAO_SOCIAL:
            <asp:TextBox ID="RAZAO_SOCIALTextBox" runat="server" Text='<%# Bind("RAZAO_SOCIAL") %>' />
            <br />
            NOME_FANTASIA:
            <asp:TextBox ID="NOME_FANTASIATextBox" runat="server" Text='<%# Bind("NOME_FANTASIA") %>' />
            <br />
            ENDERECO:
            <asp:TextBox ID="ENDERECOTextBox" runat="server" Text='<%# Bind("ENDERECO") %>' />
            <br />
            LOGRADOURO:
            <asp:TextBox ID="LOGRADOUROTextBox" runat="server" Text='<%# Bind("LOGRADOURO") %>' />
            <br />
            NUMERO:
            <asp:TextBox ID="NUMEROTextBox" runat="server" Text='<%# Bind("NUMERO") %>' />
            <br />
            COMPLEMENTO:
            <asp:TextBox ID="COMPLEMENTOTextBox" runat="server" Text='<%# Bind("COMPLEMENTO") %>' />
            <br />
            BAIRRO:
            <asp:TextBox ID="BAIRROTextBox" runat="server" Text='<%# Bind("BAIRRO") %>' />
            <br />
            CEP:
            <asp:TextBox ID="CEPTextBox" runat="server" Text='<%# Bind("CEP") %>' />
            <br />
            COD_MUNICIPIO:
            <asp:TextBox ID="COD_MUNICIPIOTextBox" runat="server" Text='<%# Bind("COD_MUNICIPIO") %>' />
            <br />
            CIDADE:
            <asp:TextBox ID="CIDADETextBox" runat="server" Text='<%# Bind("CIDADE") %>' />
            <br />
            UF:
            <asp:TextBox ID="UFTextBox" runat="server" Text='<%# Bind("UF") %>' />
            <br />
            ESTADO:
            <asp:TextBox ID="ESTADOTextBox" runat="server" Text='<%# Bind("ESTADO") %>' />
            <br />
            REGIAO:
            <asp:TextBox ID="REGIAOTextBox" runat="server" Text='<%# Bind("REGIAO") %>' />
            <br />
            REGIAO_SAUDE:
            <asp:TextBox ID="REGIAO_SAUDETextBox" runat="server" Text='<%# Bind("REGIAO_SAUDE") %>' />
            <br />
            MICRO_REGIAO_SAUDE:
            <asp:TextBox ID="MICRO_REGIAO_SAUDETextBox" runat="server" Text='<%# Bind("MICRO_REGIAO_SAUDE") %>' />
            <br />
            COD_NATUREZA_JURIDICA:
            <asp:TextBox ID="COD_NATUREZA_JURIDICATextBox" runat="server" Text='<%# Bind("COD_NATUREZA_JURIDICA") %>' />
            <br />
            NATUREZA_JURIDICA_DESCRICAO:
            <asp:TextBox ID="NATUREZA_JURIDICA_DESCRICAOTextBox" runat="server" Text='<%# Bind("NATUREZA_JURIDICA_DESCRICAO") %>' />
            <br />
            COD_ESFERA_ADMINISTRATIVA:
            <asp:TextBox ID="COD_ESFERA_ADMINISTRATIVATextBox" runat="server" Text='<%# Bind("COD_ESFERA_ADMINISTRATIVA") %>' />
            <br />
            ESFERA:
            <asp:TextBox ID="ESFERATextBox" runat="server" Text='<%# Bind("ESFERA") %>' />
            <br />
            GESTAO:
            <asp:TextBox ID="GESTAOTextBox" runat="server" Text='<%# Bind("GESTAO") %>' />
            <br />
            COD_CNAE:
            <asp:TextBox ID="COD_CNAETextBox" runat="server" Text='<%# Bind("COD_CNAE") %>' />
            <br />
            CNAE_DESCRICAO:
            <asp:TextBox ID="CNAE_DESCRICAOTextBox" runat="server" Text='<%# Bind("CNAE_DESCRICAO") %>' />
            <br />
            DATA_FUNDACAO:
            <asp:TextBox ID="DATA_FUNDACAOTextBox" runat="server" Text='<%# Bind("DATA_FUNDACAO") %>' />
            <br />
            DATA_SITUACAORFB:
            <asp:TextBox ID="DATA_SITUACAORFBTextBox" runat="server" Text='<%# Bind("DATA_SITUACAORFB") %>' />
            <br />
            SITUACAORFB:
            <asp:TextBox ID="SITUACAORFBTextBox" runat="server" Text='<%# Bind("SITUACAORFB") %>' />
            <br />
            MOTIVO_SITUACAORFB:
            <asp:TextBox ID="MOTIVO_SITUACAORFBTextBox" runat="server" Text='<%# Bind("MOTIVO_SITUACAORFB") %>' />
            <br />
            MOTIVO_ESPECIAL_SITUACAORFB:
            <asp:TextBox ID="MOTIVO_ESPECIAL_SITUACAORFBTextBox" runat="server" Text='<%# Bind("MOTIVO_ESPECIAL_SITUACAORFB") %>' />
            <br />
            EMAIL_GERENTE_CONTA:
            <asp:TextBox ID="EMAIL_GERENTE_CONTATextBox" runat="server" Text='<%# Bind("EMAIL_GERENTE_CONTA") %>' />
            <br />
            PERIODO_INICIO_MES:
            <asp:TextBox ID="PERIODO_INICIO_MESTextBox" runat="server" Text='<%# Bind("PERIODO_INICIO_MES") %>' />
            <br />
            PERIODO_INICIO_ANO:
            <asp:TextBox ID="PERIODO_INICIO_ANOTextBox" runat="server" Text='<%# Bind("PERIODO_INICIO_ANO") %>' />
            <br />
            PERIODO_FIM_MES:
            <asp:TextBox ID="PERIODO_FIM_MESTextBox" runat="server" Text='<%# Bind("PERIODO_FIM_MES") %>' />
            <br />
            PERIODO_FIM_ANO:
            <asp:TextBox ID="PERIODO_FIM_ANOTextBox" runat="server" Text='<%# Bind("PERIODO_FIM_ANO") %>' />
            <br />
            NOME_CONTATO:
            <asp:TextBox ID="NOME_CONTATOTextBox" runat="server" Text='<%# Bind("NOME_CONTATO") %>' />
            <br />
            TELEFONE:
            <asp:TextBox ID="TELEFONETextBox" runat="server" Text='<%# Bind("TELEFONE") %>' />
            <br />
            EMAIL_CONTATO:
            <asp:TextBox ID="EMAIL_CONTATOTextBox" runat="server" Text='<%# Bind("EMAIL_CONTATO") %>' />
            <br />
            CAPTAR_DEMANDA:
            <asp:CheckBox ID="CAPTAR_DEMANDACheckBox" runat="server" Checked='<%# Bind("CAPTAR_DEMANDA") %>' />
            <br />
            CAPTAR_ESTOQUE:
            <asp:CheckBox ID="CAPTAR_ESTOQUECheckBox" runat="server" Checked='<%# Bind("CAPTAR_ESTOQUE") %>' />
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
            ATUALIZACAO_RECEITA_DATA:
            <asp:TextBox ID="ATUALIZACAO_RECEITA_DATATextBox" runat="server" Text='<%# Bind("ATUALIZACAO_RECEITA_DATA") %>' />
            <br />
            ATUALIZACAO_RECEITA_CHECK:
            <asp:CheckBox ID="ATUALIZACAO_RECEITA_CHECKCheckBox" runat="server" Checked='<%# Bind("ATUALIZACAO_RECEITA_CHECK") %>' />
            <br />
            ATUALIZACAO_RECEITA_EMAIL:
            <asp:TextBox ID="ATUALIZACAO_RECEITA_EMAILTextBox" runat="server" Text='<%# Bind("ATUALIZACAO_RECEITA_EMAIL") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            CNPJ:
            <asp:Label ID="CNPJLabel" runat="server" Text='<%# Eval("CNPJ") %>' />
            <br />
            CNPJ_FORMATADO:
            <asp:Label ID="CNPJ_FORMATADOLabel" runat="server" Text='<%# Bind("CNPJ_FORMATADO") %>' />
            <br />
            CNES:
            <asp:Label ID="CNESLabel" runat="server" Text='<%# Bind("CNES") %>' />
            <br />
            COD_INTERNO:
            <asp:Label ID="COD_INTERNOLabel" runat="server" Text='<%# Bind("COD_INTERNO") %>' />
            <br />
            TIPO_PESSOA:
            <asp:Label ID="TIPO_PESSOALabel" runat="server" Text='<%# Bind("TIPO_PESSOA") %>' />
            <br />
            COD_TIPO_PESSOA:
            <asp:Label ID="COD_TIPO_PESSOALabel" runat="server" Text='<%# Bind("COD_TIPO_PESSOA") %>' />
            <br />
            ID_GRUPO_DISTRIBUIDOR:
            <asp:Label ID="ID_GRUPO_DISTRIBUIDORLabel" runat="server" Text='<%# Bind("ID_GRUPO_DISTRIBUIDOR") %>' />
            <br />
            APELIDO:
            <asp:Label ID="APELIDOLabel" runat="server" Text='<%# Bind("APELIDO") %>' />
            <br />
            ESTABELECIMENTO:
            <asp:Label ID="ESTABELECIMENTOLabel" runat="server" Text='<%# Bind("ESTABELECIMENTO") %>' />
            <br />
            ESTABELECIMENTO_CNPJ:
            <asp:Label ID="ESTABELECIMENTO_CNPJLabel" runat="server" Text='<%# Bind("ESTABELECIMENTO_CNPJ") %>' />
            <br />
            RAZAO_SOCIAL:
            <asp:Label ID="RAZAO_SOCIALLabel" runat="server" Text='<%# Bind("RAZAO_SOCIAL") %>' />
            <br />
            NOME_FANTASIA:
            <asp:Label ID="NOME_FANTASIALabel" runat="server" Text='<%# Bind("NOME_FANTASIA") %>' />
            <br />
            ENDERECO:
            <asp:Label ID="ENDERECOLabel" runat="server" Text='<%# Bind("ENDERECO") %>' />
            <br />
            LOGRADOURO:
            <asp:Label ID="LOGRADOUROLabel" runat="server" Text='<%# Bind("LOGRADOURO") %>' />
            <br />
            NUMERO:
            <asp:Label ID="NUMEROLabel" runat="server" Text='<%# Bind("NUMERO") %>' />
            <br />
            COMPLEMENTO:
            <asp:Label ID="COMPLEMENTOLabel" runat="server" Text='<%# Bind("COMPLEMENTO") %>' />
            <br />
            BAIRRO:
            <asp:Label ID="BAIRROLabel" runat="server" Text='<%# Bind("BAIRRO") %>' />
            <br />
            CEP:
            <asp:Label ID="CEPLabel" runat="server" Text='<%# Bind("CEP") %>' />
            <br />
            COD_MUNICIPIO:
            <asp:Label ID="COD_MUNICIPIOLabel" runat="server" Text='<%# Bind("COD_MUNICIPIO") %>' />
            <br />
            CIDADE:
            <asp:Label ID="CIDADELabel" runat="server" Text='<%# Bind("CIDADE") %>' />
            <br />
            UF:
            <asp:Label ID="UFLabel" runat="server" Text='<%# Bind("UF") %>' />
            <br />
            ESTADO:
            <asp:Label ID="ESTADOLabel" runat="server" Text='<%# Bind("ESTADO") %>' />
            <br />
            REGIAO:
            <asp:Label ID="REGIAOLabel" runat="server" Text='<%# Bind("REGIAO") %>' />
            <br />
            REGIAO_SAUDE:
            <asp:Label ID="REGIAO_SAUDELabel" runat="server" Text='<%# Bind("REGIAO_SAUDE") %>' />
            <br />
            MICRO_REGIAO_SAUDE:
            <asp:Label ID="MICRO_REGIAO_SAUDELabel" runat="server" Text='<%# Bind("MICRO_REGIAO_SAUDE") %>' />
            <br />
            COD_NATUREZA_JURIDICA:
            <asp:Label ID="COD_NATUREZA_JURIDICALabel" runat="server" Text='<%# Bind("COD_NATUREZA_JURIDICA") %>' />
            <br />
            NATUREZA_JURIDICA_DESCRICAO:
            <asp:Label ID="NATUREZA_JURIDICA_DESCRICAOLabel" runat="server" Text='<%# Bind("NATUREZA_JURIDICA_DESCRICAO") %>' />
            <br />
            COD_ESFERA_ADMINISTRATIVA:
            <asp:Label ID="COD_ESFERA_ADMINISTRATIVALabel" runat="server" Text='<%# Bind("COD_ESFERA_ADMINISTRATIVA") %>' />
            <br />
            ESFERA:
            <asp:Label ID="ESFERALabel" runat="server" Text='<%# Bind("ESFERA") %>' />
            <br />
            GESTAO:
            <asp:Label ID="GESTAOLabel" runat="server" Text='<%# Bind("GESTAO") %>' />
            <br />
            COD_CNAE:
            <asp:Label ID="COD_CNAELabel" runat="server" Text='<%# Bind("COD_CNAE") %>' />
            <br />
            CNAE_DESCRICAO:
            <asp:Label ID="CNAE_DESCRICAOLabel" runat="server" Text='<%# Bind("CNAE_DESCRICAO") %>' />
            <br />
            DATA_FUNDACAO:
            <asp:Label ID="DATA_FUNDACAOLabel" runat="server" Text='<%# Bind("DATA_FUNDACAO") %>' />
            <br />
            DATA_SITUACAORFB:
            <asp:Label ID="DATA_SITUACAORFBLabel" runat="server" Text='<%# Bind("DATA_SITUACAORFB") %>' />
            <br />
            SITUACAORFB:
            <asp:Label ID="SITUACAORFBLabel" runat="server" Text='<%# Bind("SITUACAORFB") %>' />
            <br />
            MOTIVO_SITUACAORFB:
            <asp:Label ID="MOTIVO_SITUACAORFBLabel" runat="server" Text='<%# Bind("MOTIVO_SITUACAORFB") %>' />
            <br />
            MOTIVO_ESPECIAL_SITUACAORFB:
            <asp:Label ID="MOTIVO_ESPECIAL_SITUACAORFBLabel" runat="server" Text='<%# Bind("MOTIVO_ESPECIAL_SITUACAORFB") %>' />
            <br />
            EMAIL_GERENTE_CONTA:
            <asp:Label ID="EMAIL_GERENTE_CONTALabel" runat="server" Text='<%# Bind("EMAIL_GERENTE_CONTA") %>' />
            <br />
            PERIODO_INICIO_MES:
            <asp:Label ID="PERIODO_INICIO_MESLabel" runat="server" Text='<%# Bind("PERIODO_INICIO_MES") %>' />
            <br />
            PERIODO_INICIO_ANO:
            <asp:Label ID="PERIODO_INICIO_ANOLabel" runat="server" Text='<%# Bind("PERIODO_INICIO_ANO") %>' />
            <br />
            PERIODO_FIM_MES:
            <asp:Label ID="PERIODO_FIM_MESLabel" runat="server" Text='<%# Bind("PERIODO_FIM_MES") %>' />
            <br />
            PERIODO_FIM_ANO:
            <asp:Label ID="PERIODO_FIM_ANOLabel" runat="server" Text='<%# Bind("PERIODO_FIM_ANO") %>' />
            <br />
            NOME_CONTATO:
            <asp:Label ID="NOME_CONTATOLabel" runat="server" Text='<%# Bind("NOME_CONTATO") %>' />
            <br />
            TELEFONE:
            <asp:Label ID="TELEFONELabel" runat="server" Text='<%# Bind("TELEFONE") %>' />
            <br />
            EMAIL_CONTATO:
            <asp:Label ID="EMAIL_CONTATOLabel" runat="server" Text='<%# Bind("EMAIL_CONTATO") %>' />
            <br />
            CAPTAR_DEMANDA:
            <asp:CheckBox ID="CAPTAR_DEMANDACheckBox" runat="server" Checked='<%# Bind("CAPTAR_DEMANDA") %>' Enabled="false" />
            <br />
            CAPTAR_ESTOQUE:
            <asp:CheckBox ID="CAPTAR_ESTOQUECheckBox" runat="server" Checked='<%# Bind("CAPTAR_ESTOQUE") %>' Enabled="false" />
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
            ATUALIZACAO_RECEITA_DATA:
            <asp:Label ID="ATUALIZACAO_RECEITA_DATALabel" runat="server" Text='<%# Bind("ATUALIZACAO_RECEITA_DATA") %>' />
            <br />
            ATUALIZACAO_RECEITA_CHECK:
            <asp:CheckBox ID="ATUALIZACAO_RECEITA_CHECKCheckBox" runat="server" Checked='<%# Bind("ATUALIZACAO_RECEITA_CHECK") %>' Enabled="false" />
            <br />
            ATUALIZACAO_RECEITA_EMAIL:
            <asp:Label ID="ATUALIZACAO_RECEITA_EMAILLabel" runat="server" Text='<%# Bind("ATUALIZACAO_RECEITA_EMAIL") %>' />
            <br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
            &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />
            &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />
        </ItemTemplate>
    </asp:FormView>
    <br /> 
    <asp:SqlDataSource ID="dts_Distribuidores" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" OldValuesParameterFormatString="original_{0}" 
        SelectCommand="SELECT * FROM [VIEW_DISTRIBUIDORES_001_DETALHADO] WHERE ([CNPJ] = @CNPJ)" 
        DeleteCommand="DELETE FROM [TBL_DISTRIBUIDORES] WHERE [CNPJ] = @original_CNPJ" 
        InsertCommand="INSERT INTO [TBL_DISTRIBUIDORES] ([CNPJ], [CNPJ_FORMATADO], [CNES], [COD_INTERNO], [TIPO_PESSOA], [COD_TIPO_PESSOA], [ID_GRUPO_DISTRIBUIDOR], [APELIDO], [ESTABELECIMENTO], [ESTABELECIMENTO_CNPJ], [RAZAO_SOCIAL], [NOME_FANTASIA], [ENDERECO], [LOGRADOURO], [NUMERO], [COMPLEMENTO], [BAIRRO], [CEP], [COD_MUNICIPIO], [CIDADE], [UF], [ESTADO], [REGIAO], [REGIAO_SAUDE], [MICRO_REGIAO_SAUDE], [COD_NATUREZA_JURIDICA], [NATUREZA_JURIDICA_DESCRICAO], [COD_ESFERA_ADMINISTRATIVA], [ESFERA], [GESTAO], [COD_CNAE], [CNAE_DESCRICAO], [DATA_FUNDACAO], [DATA_SITUACAORFB], [SITUACAORFB], [MOTIVO_SITUACAORFB], [MOTIVO_ESPECIAL_SITUACAORFB], [EMAIL_GERENTE_CONTA], [PERIODO_INICIO_MES], [PERIODO_INICIO_ANO], [PERIODO_FIM_MES], [PERIODO_FIM_ANO], [NOME_CONTATO], [TELEFONE], [EMAIL_CONTATO], [CAPTAR_DEMANDA], [CAPTAR_ESTOQUE], [INCLUSAO_EMAIL], [INCLUSAO_DATA], [ALTERACAO_EMAIL], [ALTERACAO_DATA], [EXCLUSAO_EMAIL], [EXCLUSAO_DATA], [ATUALIZACAO_RECEITA_DATA], [ATUALIZACAO_RECEITA_CHECK], [ATUALIZACAO_RECEITA_EMAIL]) VALUES (@CNPJ, @CNPJ_FORMATADO, @CNES, @COD_INTERNO, @TIPO_PESSOA, @COD_TIPO_PESSOA, @ID_GRUPO_DISTRIBUIDOR, @APELIDO, @ESTABELECIMENTO, @ESTABELECIMENTO_CNPJ, @RAZAO_SOCIAL, @NOME_FANTASIA, @ENDERECO, @LOGRADOURO, @NUMERO, @COMPLEMENTO, @BAIRRO, @CEP, @COD_MUNICIPIO, @CIDADE, @UF, @ESTADO, @REGIAO, @REGIAO_SAUDE, @MICRO_REGIAO_SAUDE, @COD_NATUREZA_JURIDICA, @NATUREZA_JURIDICA_DESCRICAO, @COD_ESFERA_ADMINISTRATIVA, @ESFERA, @GESTAO, @COD_CNAE, @CNAE_DESCRICAO, @DATA_FUNDACAO, @DATA_SITUACAORFB, @SITUACAORFB, @MOTIVO_SITUACAORFB, @MOTIVO_ESPECIAL_SITUACAORFB, @EMAIL_GERENTE_CONTA, @PERIODO_INICIO_MES, @PERIODO_INICIO_ANO, @PERIODO_FIM_MES, @PERIODO_FIM_ANO, @NOME_CONTATO, @TELEFONE, @EMAIL_CONTATO, @CAPTAR_DEMANDA, @CAPTAR_ESTOQUE, @INCLUSAO_EMAIL, @INCLUSAO_DATA, @ALTERACAO_EMAIL, @ALTERACAO_DATA, @EXCLUSAO_EMAIL, @EXCLUSAO_DATA, @ATUALIZACAO_RECEITA_DATA, @ATUALIZACAO_RECEITA_CHECK, @ATUALIZACAO_RECEITA_EMAIL)" 
        UpdateCommand="UPDATE [TBL_DISTRIBUIDORES] SET [COD_INTERNO] = @COD_INTERNO, [ID_GRUPO_DISTRIBUIDOR] = @ID_GRUPO_DISTRIBUIDOR, [EMAIL_GERENTE_CONTA] = @EMAIL_GERENTE_CONTA, [PERIODO_INICIO_MES] = @PERIODO_INICIO_MES, [PERIODO_INICIO_ANO] = @PERIODO_INICIO_ANO, [PERIODO_FIM_MES] = @PERIODO_FIM_MES, [PERIODO_FIM_ANO] = @PERIODO_FIM_ANO, [NOME_CONTATO] = @NOME_CONTATO, [TELEFONE] = @TELEFONE, [EMAIL_CONTATO] = @EMAIL_CONTATO, [CAPTAR_DEMANDA] = @CAPTAR_DEMANDA, [CAPTAR_ESTOQUE] = @CAPTAR_ESTOQUE WHERE [CNPJ] = @original_CNPJ">
            <DeleteParameters>
                <asp:Parameter Name="original_CNPJ" Type="Decimal" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="CNPJ" Type="Decimal" />
                <asp:Parameter Name="CNPJ_FORMATADO" Type="String" />
                <asp:Parameter Name="CNES" Type="String" />
                <asp:Parameter Name="COD_INTERNO" Type="String" />
                <asp:Parameter Name="TIPO_PESSOA" Type="String" />
                <asp:Parameter Name="COD_TIPO_PESSOA" Type="String" />
                <asp:Parameter Name="ID_GRUPO_DISTRIBUIDOR" Type="Decimal" />
                <asp:Parameter Name="APELIDO" Type="String" />
                <asp:Parameter Name="ESTABELECIMENTO" Type="String" />
                <asp:Parameter Name="ESTABELECIMENTO_CNPJ" Type="String" />
                <asp:Parameter Name="RAZAO_SOCIAL" Type="String" />
                <asp:Parameter Name="NOME_FANTASIA" Type="String" />
                <asp:Parameter Name="ENDERECO" Type="String" />
                <asp:Parameter Name="LOGRADOURO" Type="String" />
                <asp:Parameter Name="NUMERO" Type="String" />
                <asp:Parameter Name="COMPLEMENTO" Type="String" />
                <asp:Parameter Name="BAIRRO" Type="String" />
                <asp:Parameter Name="CEP" Type="String" />
                <asp:Parameter Name="COD_MUNICIPIO" Type="String" />
                <asp:Parameter Name="CIDADE" Type="String" />
                <asp:Parameter Name="UF" Type="String" />
                <asp:Parameter Name="ESTADO" Type="String" />
                <asp:Parameter Name="REGIAO" Type="String" />
                <asp:Parameter Name="REGIAO_SAUDE" Type="String" />
                <asp:Parameter Name="MICRO_REGIAO_SAUDE" Type="String" />
                <asp:Parameter Name="COD_NATUREZA_JURIDICA" Type="Decimal" />
                <asp:Parameter Name="NATUREZA_JURIDICA_DESCRICAO" Type="String" />
                <asp:Parameter Name="COD_ESFERA_ADMINISTRATIVA" Type="Decimal" />
                <asp:Parameter Name="ESFERA" Type="String" />
                <asp:Parameter Name="GESTAO" Type="String" />
                <asp:Parameter Name="COD_CNAE" Type="String" />
                <asp:Parameter Name="CNAE_DESCRICAO" Type="String" />
                <asp:Parameter Name="DATA_FUNDACAO" Type="Decimal" />
                <asp:Parameter Name="DATA_SITUACAORFB" Type="Decimal" />
                <asp:Parameter Name="SITUACAORFB" Type="String" />
                <asp:Parameter Name="MOTIVO_SITUACAORFB" Type="String" />
                <asp:Parameter Name="MOTIVO_ESPECIAL_SITUACAORFB" Type="String" />
                <asp:Parameter Name="EMAIL_GERENTE_CONTA" Type="String" />
                <asp:Parameter Name="PERIODO_INICIO_MES" Type="Decimal" />
                <asp:Parameter Name="PERIODO_INICIO_ANO" Type="Decimal" />
                <asp:Parameter Name="PERIODO_FIM_MES" Type="Decimal" />
                <asp:Parameter Name="PERIODO_FIM_ANO" Type="Decimal" />
                <asp:Parameter Name="NOME_CONTATO" Type="String" />
                <asp:Parameter Name="TELEFONE" Type="String" />
                <asp:Parameter Name="EMAIL_CONTATO" Type="String" />
                <asp:Parameter Name="CAPTAR_DEMANDA" Type="Boolean" />
                <asp:Parameter Name="CAPTAR_ESTOQUE" Type="Boolean" />
                <asp:Parameter Name="INCLUSAO_EMAIL" Type="String" />
                <asp:Parameter Name="INCLUSAO_DATA" Type="Decimal" />
                <asp:Parameter Name="ALTERACAO_EMAIL" Type="String" />
                <asp:Parameter Name="ALTERACAO_DATA" Type="Decimal" />
                <asp:Parameter Name="EXCLUSAO_EMAIL" Type="String" />
                <asp:Parameter Name="EXCLUSAO_DATA" Type="Decimal" />
                <asp:Parameter Name="ATUALIZACAO_RECEITA_DATA" Type="Decimal" />
                <asp:Parameter Name="ATUALIZACAO_RECEITA_CHECK" Type="Boolean" />
                <asp:Parameter Name="ATUALIZACAO_RECEITA_EMAIL" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="CNPJ" QueryStringField="CNPJ" Type="Decimal" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="CNPJ_FORMATADO" Type="String" />
                <asp:Parameter Name="CNES" Type="String" />
                <asp:Parameter Name="COD_INTERNO" Type="String" />
                <asp:Parameter Name="TIPO_PESSOA" Type="String" />
                <asp:Parameter Name="COD_TIPO_PESSOA" Type="String" />
                <asp:Parameter Name="ID_GRUPO_DISTRIBUIDOR" Type="Decimal" />
                <asp:Parameter Name="APELIDO" Type="String" />
                <asp:Parameter Name="ESTABELECIMENTO" Type="String" />
                <asp:Parameter Name="ESTABELECIMENTO_CNPJ" Type="String" />
                <asp:Parameter Name="RAZAO_SOCIAL" Type="String" />
                <asp:Parameter Name="NOME_FANTASIA" Type="String" />
                <asp:Parameter Name="ENDERECO" Type="String" />
                <asp:Parameter Name="LOGRADOURO" Type="String" />
                <asp:Parameter Name="NUMERO" Type="String" />
                <asp:Parameter Name="COMPLEMENTO" Type="String" />
                <asp:Parameter Name="BAIRRO" Type="String" />
                <asp:Parameter Name="CEP" Type="String" />
                <asp:Parameter Name="COD_MUNICIPIO" Type="String" />
                <asp:Parameter Name="CIDADE" Type="String" />
                <asp:Parameter Name="UF" Type="String" />
                <asp:Parameter Name="ESTADO" Type="String" />
                <asp:Parameter Name="REGIAO" Type="String" />
                <asp:Parameter Name="REGIAO_SAUDE" Type="String" />
                <asp:Parameter Name="MICRO_REGIAO_SAUDE" Type="String" />
                <asp:Parameter Name="COD_NATUREZA_JURIDICA" Type="Decimal" />
                <asp:Parameter Name="NATUREZA_JURIDICA_DESCRICAO" Type="String" />
                <asp:Parameter Name="COD_ESFERA_ADMINISTRATIVA" Type="Decimal" />
                <asp:Parameter Name="ESFERA" Type="String" />
                <asp:Parameter Name="GESTAO" Type="String" />
                <asp:Parameter Name="COD_CNAE" Type="String" />
                <asp:Parameter Name="CNAE_DESCRICAO" Type="String" />
                <asp:Parameter Name="DATA_FUNDACAO" Type="Decimal" />
                <asp:Parameter Name="DATA_SITUACAORFB" Type="Decimal" />
                <asp:Parameter Name="SITUACAORFB" Type="String" />
                <asp:Parameter Name="MOTIVO_SITUACAORFB" Type="String" />
                <asp:Parameter Name="MOTIVO_ESPECIAL_SITUACAORFB" Type="String" />
                <asp:Parameter Name="EMAIL_GERENTE_CONTA" Type="String" />
                <asp:Parameter Name="PERIODO_INICIO_MES" Type="Decimal" />
                <asp:Parameter Name="PERIODO_INICIO_ANO" Type="Decimal" />
                <asp:Parameter Name="PERIODO_FIM_MES" Type="Decimal" />
                <asp:Parameter Name="PERIODO_FIM_ANO" Type="Decimal" />
                <asp:Parameter Name="NOME_CONTATO" Type="String" />
                <asp:Parameter Name="TELEFONE" Type="String" />
                <asp:Parameter Name="EMAIL_CONTATO" Type="String" />
                <asp:Parameter Name="CAPTAR_DEMANDA" Type="Boolean" />
                <asp:Parameter Name="CAPTAR_ESTOQUE" Type="Boolean" />
                <asp:Parameter Name="INCLUSAO_EMAIL" Type="String" />
                <asp:Parameter Name="INCLUSAO_DATA" Type="Decimal" />
                <asp:Parameter Name="ALTERACAO_EMAIL" Type="String" />
                <asp:Parameter Name="ALTERACAO_DATA" Type="Decimal" />
                <asp:Parameter Name="EXCLUSAO_EMAIL" Type="String" />
                <asp:Parameter Name="EXCLUSAO_DATA" Type="Decimal" />
                <asp:Parameter Name="ATUALIZACAO_RECEITA_DATA" Type="Decimal" />
                <asp:Parameter Name="ATUALIZACAO_RECEITA_CHECK" Type="Boolean" />
                <asp:Parameter Name="ATUALIZACAO_RECEITA_EMAIL" Type="String" />
                <asp:Parameter Name="original_CNPJ" Type="Decimal" />
            </UpdateParameters>
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Meses" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
                    SelectCommand="SELECT '0' AS MES, '@  Selecione' as MES_EXTENSO UNION ALL 
    SELECT DISTINCT [MES], [MES_EXTENSO] AS ANO_TEXTO
    FROM  VIEW_DATAS  ORDER BY MES"></asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Anos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT '0' AS ANO UNION ALL 
    SELECT DISTINCT [ANO]
    FROM  VIEW_DATAS  ORDER BY ANO"></asp:SqlDataSource>
</div>
    <asp:SqlDataSource ID="dts_Grupos_Distribuidores" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_DISTRIBUIDORES_GRUPOS] ORDER BY GRUPO_DISTRIBUIDOR"></asp:SqlDataSource>    
</form>
</body>
</html>