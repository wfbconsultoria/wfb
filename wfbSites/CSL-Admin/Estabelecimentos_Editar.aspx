<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Estabelecimentos_Editar.aspx.vb" Inherits="Estabelecimentos_Editar" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head><body>
<form id="form1" runat="server">
    <uc1:Cabecalho runat="server" id="Cabecalho" />
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Alterar Cadastro do Cliente</div>
</div>
<br />   
<div id ="Corpo">
    <br /> 
    <asp:FormView ID="frm_ESTABELECIMENTO_EDITAR" runat="server" DataKeyNames="CNPJ" DataSourceID="dts_Estabelecimentos" Width="100%" DefaultMode="Edit">
            <EditItemTemplate>
                <strong>
                <table class="auto-style1">
                    <tr>
                        <td><strong>Ficha de Pessoa
                            <asp:Label ID="TIPO_PESSOALabel" runat="server" Text='<%# Bind("TIPO_PESSOA") %>' />
                            </strong></td>
                        <td style="text-align: right">
                            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Gravar" />
                            &nbsp; <a href='Estabelecimentos_Ficha.aspx?CNPJ=<%=Request.QueryString("CNPJ")%>'>Cancelar/Voltar</a> </td>
                    </tr>
                </table>
                </strong>
                CNPJ:
                <asp:Label ID="lbl_CNPJ_FORMATADO" runat="server" Text='<%# Eval("CNPJ_FORMATADO") %>' style="color: #808080"></asp:Label>
                &nbsp;&nbsp;&nbsp;<br /> Razão Social:
                <asp:Label ID="lbl_RAZAO_SOCIAL" runat="server" Text='<%# Eval("RAZAO_SOCIAL") %>' CssClass="auto-style1"></asp:Label>
                <br />
                Nome Fantasia:
                <asp:Label ID="lbl_NOME_FANTASIA" runat="server" Text='<%# Eval("NOME_FANTASIA") %>' CssClass="auto-style1"></asp:Label>
                <br />
                <br />
                <strong>Grupo:
                <asp:DropDownList ID="ID_GRUPO_ESTABELECIMENTOTextBox" runat="server" DataSourceID="dts_Grupos_Estabelecimentos" DataTextField="GRUPO_ESTABELECIMENTO" DataValueField="ID_GRUPO_ESTABELECIMENTO" SelectedValue='<%# Bind("ID_GRUPO_ESTABELECIMENTO") %>'>
                </asp:DropDownList>
                <br />
                Cod CNES:
                <asp:TextBox ID="CNESTextBox" runat="server" Text='<%# Bind("CNES") %>' />
                <asp:RangeValidator ID="rfv_CNESTextBox" runat="server" ControlToValidate="CNESTextBox" ErrorMessage="Valor Invalido" ForeColor="Red" MaximumValue="999999999" MinimumValue="0" Type="Integer"></asp:RangeValidator>
                <br />
                Código Interno:
                <asp:TextBox ID="COD_INTERNOTextBox" runat="server" Text='<%# Bind("COD_INTERNO") %>' />
                <asp:RangeValidator ID="rfv_COD_INTERNO" runat="server" ControlToValidate="COD_INTERNOTextBox" ErrorMessage="Valor Invalido" ForeColor="Red" MaximumValue="999999999" MinimumValue="0" Type="Integer"></asp:RangeValidator>
                <br />
                </strong>
                <asp:TextBox ID="APELIDOTextBox" runat="server" Text='<%# Bind("APELIDO") %>' Enabled="False" Visible="False" Width="25%" />
                <br />
                Endereço:
                <asp:Label ID="lbl_ENDERECO" runat="server" Text='<%# Eval("ENDERECO") %>' CssClass="auto-style1"></asp:Label>
                <br />
                Complemento:
                <asp:Label ID="lbl_COMPLEMENTO" runat="server" Text='<%# Eval("COMPLEMENTO") %>' CssClass="auto-style1"></asp:Label>
                <br />
                Bairro:
                <asp:Label ID="lbl_BAIRRO" runat="server" Text='<%# Eval("BAIRRO") %>' CssClass="auto-style1"></asp:Label>
                <br />
                CEP:
                <asp:Label ID="lbl_CEP" runat="server" Text='<%# Eval("CEP") %>' CssClass="auto-style1"></asp:Label>
                <br />
                Cidade:
                <asp:Label ID="lbl_MUNICIPIO" runat="server" Text='<%# Eval("MUNICIPIO") %>' CssClass="auto-style1"></asp:Label>
                <br />
                UF:
                <asp:Label ID="lbl_UF" runat="server" Text='<%# Eval("UF") %>' CssClass="auto-style1"></asp:Label>
                <br />
                <br />
                Natureza Juridica:
                <asp:Label ID="lbl_NATUREZA_JURIDICA" runat="server" Text='<%# Eval("NATUREZA_JURIDICA_DESCRICAO") %>' CssClass="auto-style1"></asp:Label>
                <br />
                Esfera Administrativa:
                <asp:Label ID="lbl_ESFERA" runat="server" Text='<%# Eval("ESFERA") %>' CssClass="auto-style1"></asp:Label>
                <br />
                Gestão:
                <asp:Label ID="lbl_GESTAO" runat="server" Text='<%# Eval("GESTAO") %>' CssClass="auto-style1"></asp:Label>
                <br />
                <br />
                Gerente de Conta:
                <asp:Label ID="lbl_GERENTE_CONTA" runat="server" Text='<%# Eval("GERENTE_CONTA") %>' CssClass="auto-style1"></asp:Label>
                <br />
                Inclusão:
                <asp:Label ID="lbl_INCLUSAO" runat="server" Text='<%# Eval("INCLUSAO") %>' CssClass="auto-style1"></asp:Label>
                <br />
                Alteração:
                <asp:Label ID="lbl_ALTERACAO" runat="server" Text='<%# Eval("ALTERACAO") %>' CssClass="auto-style1"></asp:Label>
                <br />
                <br />
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
                ID_GRUPO_ESTABELECIMENTO:
                <asp:TextBox ID="ID_GRUPO_ESTABELECIMENTOTextBox" runat="server" Text='<%# Bind("ID_GRUPO_ESTABELECIMENTO") %>' />
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
                <strong>Ficha de Pessoa
                <asp:Label ID="TIPO_PESSOALabel" runat="server" Text='<%# Bind("TIPO_PESSOA") %>' />
                </strong>
                <br />
                CNPJ:
                <asp:Label ID="CNPJ_FORMATADOLabel" runat="server" Text='<%# Bind("CNPJ_FORMATADO") %>' style="color: #808080" />
                &nbsp;&nbsp;&nbsp; Código Interno:
                <asp:Label ID="COD_INTERNOLabel" runat="server" Text='<%# Bind("COD_INTERNO") %>' style="color: #808080" />
                <br />
                Razão Social:
                <asp:Label ID="RAZAO_SOCIALLabel" runat="server" Text='<%# Bind("RAZAO_SOCIAL") %>' style="color: #808080" />
                <br />
                Nome Fantasia:
                <asp:Label ID="NOME_FANTASIALabel" runat="server" Text='<%# Bind("NOME_FANTASIA") %>' style="color: #808080" />
                <br />
                Apelido:
                <asp:Label ID="APELIDOLabel" runat="server" Text='<%# Bind("APELIDO") %>' style="color: #808080" />
                <br />
                Grupo:
                <asp:Label ID="lbl_GRUPO_ESTABELECIMENTO" runat="server" style="color: #808080" Text='<%# Eval("GRUPO_ESTABELECIMENTO") %>'></asp:Label>
                <br />
                <br />
                Endereço:
                <asp:Label ID="ENDERECOLabel" runat="server" Text='<%# Bind("ENDERECO") %>' style="color: #808080" />
                <br />
                Complemento:
                <asp:Label ID="COMPLEMENTOLabel" runat="server" Text='<%# Bind("COMPLEMENTO") %>' style="color: #808080" />
                <br />
                Bairro:
                <asp:Label ID="BAIRROLabel" runat="server" Text='<%# Bind("BAIRRO") %>' style="color: #808080" />
                <br />
                CEP:
                <asp:Label ID="CEPLabel" runat="server" Text='<%# Bind("CEP") %>' style="color: #808080" />
                <br />
                Cidade:
                <asp:Label ID="MUNICIPIOLabel" runat="server" Text='<%# Eval("MUNICIPIO") %>' CssClass="auto-style1" />
                <br />
                UF:
                <asp:Label ID="UFLabel" runat="server" Text='<%# Bind("UF") %>' CssClass="auto-style1" />
                <br />
                <br />
                Natureza Jurídica:
                <asp:Label ID="NATUREZA_JURIDICA_DESCRICAOLabel" runat="server" Text='<%# Bind("NATUREZA_JURIDICA_DESCRICAO") %>' CssClass="auto-style1" />
                <br />
                Esfera Administrativa:
                <asp:Label ID="ESFERALabel" runat="server" Text='<%# Bind("ESFERA") %>' style="color: #808080" />
                <br />
                Gestão:
                <asp:Label ID="GESTAOLabel" runat="server" Text='<%# Bind("GESTAO") %>' CssClass="auto-style1" />
                <br />
                <br />
                Gerente de Conta:
                <asp:Label ID="EMAIL_GERENTE_CONTALabel" runat="server" Text='<%# Bind("EMAIL_GERENTE_CONTA") %>' CssClass="auto-style1" />
                <br />
                Inclusão:
                <asp:Label ID="INCLUSAO_EMAILLabel" runat="server" Text='<%# Eval("INCLUSAO") %>' CssClass="auto-style1" />

                <br />
                Alteração:
                <asp:Label ID="ALTERACAO_EMAILLabel" runat="server" Text='<%# Bind("ALTERACAO") %>' CssClass="auto-style1" />

                <br />
                <br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar" />
            </ItemTemplate>
        </asp:FormView>
</div>
    
    <asp:SqlDataSource ID="dts_Grupos_Estabelecimentos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_ESTABELECIMENTOS_GRUPOS]"></asp:SqlDataSource>    
    <asp:SqlDataSource ID="dts_Estabelecimentos" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        DeleteCommand="DELETE FROM [TBL_ESTABELECIMENTOS] WHERE [CNPJ] = @original_CNPJ" 
        InsertCommand="INSERT INTO [TBL_ESTABELECIMENTOS] ([CNPJ], [CNPJ_FORMATADO], [CNES], [COD_INTERNO], [TIPO_PESSOA], [GRUPO], [APELIDO], [ESTABELECIMENTO], [ESTABELECIMENTO_CNPJ], [RAZAO_SOCIAL], [NOME_FANTASIA], [ENDERECO], [LOGRADOURO], [NUMERO], [COMPLEMENTO], [BAIRRO], [CEP], [COD_MUNICIPIO], [CIDADE], [UF], [ESTADO], [REGIAO], [REGIAO_SAUDE], [MICRO_REGIAO_SAUDE], [COD_NATUREZA_JURIDICA], [NATUREZA_JURIDICA_DESCRICAO], [COD_ESFERA_ADMINISTRATIVA], [ESFERA], [GESTAO], [COD_CNAE], [CNAE_DESCRICAO], [DATA_FUNDACAO], [DATA_SITUACAORFB], [SITUACAORFB], [MOTIVO_SITUACAORFB], [MOTIVO_ESPECIAL_SITUACAORFB], [EMAIL_GERENTE_CONTA], [INCLUSAO_EMAIL], [INCLUSAO_DATA], [ALTERACAO_EMAIL], [ALTERACAO_DATA], [EXCLUSAO_EMAIL], [EXCLUSAO_DATA], [ATUALIZACAO_RECEITA_DATA], [ATUALIZACAO_RECEITA_CHECK], [ATUALIZACAO_RECEITA_EMAIL]) VALUES (@CNPJ, @CNPJ_FORMATADO, @CNES, @COD_INTERNO, @TIPO_PESSOA, @GRUPO, @APELIDO, @ESTABELECIMENTO, @ESTABELECIMENTO_CNPJ, @RAZAO_SOCIAL, @NOME_FANTASIA, @ENDERECO, @LOGRADOURO, @NUMERO, @COMPLEMENTO, @BAIRRO, @CEP, @COD_MUNICIPIO, @CIDADE, @UF, @ESTADO, @REGIAO, @REGIAO_SAUDE, @MICRO_REGIAO_SAUDE, @COD_NATUREZA_JURIDICA, @NATUREZA_JURIDICA_DESCRICAO, @COD_ESFERA_ADMINISTRATIVA, @ESFERA, @GESTAO, @COD_CNAE, @CNAE_DESCRICAO, @DATA_FUNDACAO, @DATA_SITUACAORFB, @SITUACAORFB, @MOTIVO_SITUACAORFB, @MOTIVO_ESPECIAL_SITUACAORFB, @EMAIL_GERENTE_CONTA, @INCLUSAO_EMAIL, @INCLUSAO_DATA, @ALTERACAO_EMAIL, @ALTERACAO_DATA, @EXCLUSAO_EMAIL, @EXCLUSAO_DATA, @ATUALIZACAO_RECEITA_DATA, @ATUALIZACAO_RECEITA_CHECK, @ATUALIZACAO_RECEITA_EMAIL)" OldValuesParameterFormatString="original_{0}" 
        SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS_001_DETALHADO] WHERE ([CNPJ] = @CNPJ)" 
        UpdateCommand="UPDATE [TBL_ESTABELECIMENTOS] SET [CNES] = @CNES, [COD_INTERNO] = @COD_INTERNO, [ID_GRUPO_ESTABELECIMENTO] = @ID_GRUPO_ESTABELECIMENTO, [APELIDO] = @APELIDO WHERE [CNPJ] = @original_CNPJ ">
            <DeleteParameters>
                <asp:Parameter Name="original_CNPJ" Type="Decimal" />
                <asp:Parameter Name="original_CNPJ_FORMATADO" Type="String" />
                <asp:Parameter Name="original_CNES" Type="String" />
                <asp:Parameter Name="original_COD_INTERNO" Type="String" />
                <asp:Parameter Name="original_TIPO_PESSOA" Type="String" />
                <asp:Parameter Name="original_GRUPO" Type="String" />
                <asp:Parameter Name="original_APELIDO" Type="String" />
                <asp:Parameter Name="original_ESTABELECIMENTO" Type="String" />
                <asp:Parameter Name="original_ESTABELECIMENTO_CNPJ" Type="String" />
                <asp:Parameter Name="original_RAZAO_SOCIAL" Type="String" />
                <asp:Parameter Name="original_NOME_FANTASIA" Type="String" />
                <asp:Parameter Name="original_ENDERECO" Type="String" />
                <asp:Parameter Name="original_LOGRADOURO" Type="String" />
                <asp:Parameter Name="original_NUMERO" Type="String" />
                <asp:Parameter Name="original_COMPLEMENTO" Type="String" />
                <asp:Parameter Name="original_BAIRRO" Type="String" />
                <asp:Parameter Name="original_CEP" Type="String" />
                <asp:Parameter Name="original_COD_MUNICIPIO" Type="String" />
                <asp:Parameter Name="original_CIDADE" Type="String" />
                <asp:Parameter Name="original_UF" Type="String" />
                <asp:Parameter Name="original_ESTADO" Type="String" />
                <asp:Parameter Name="original_REGIAO" Type="String" />
                <asp:Parameter Name="original_REGIAO_SAUDE" Type="String" />
                <asp:Parameter Name="original_MICRO_REGIAO_SAUDE" Type="String" />
                <asp:Parameter Name="original_COD_NATUREZA_JURIDICA" Type="Decimal" />
                <asp:Parameter Name="original_NATUREZA_JURIDICA_DESCRICAO" Type="String" />
                <asp:Parameter Name="original_COD_ESFERA_ADMINISTRATIVA" Type="Decimal" />
                <asp:Parameter Name="original_ESFERA" Type="String" />
                <asp:Parameter Name="original_GESTAO" Type="String" />
                <asp:Parameter Name="original_COD_CNAE" Type="String" />
                <asp:Parameter Name="original_CNAE_DESCRICAO" Type="String" />
                <asp:Parameter Name="original_DATA_FUNDACAO" Type="Decimal" />
                <asp:Parameter Name="original_DATA_SITUACAORFB" Type="Decimal" />
                <asp:Parameter Name="original_SITUACAORFB" Type="String" />
                <asp:Parameter Name="original_MOTIVO_SITUACAORFB" Type="String" />
                <asp:Parameter Name="original_MOTIVO_ESPECIAL_SITUACAORFB" Type="String" />
                <asp:Parameter Name="original_EMAIL_GERENTE_CONTA" Type="String" />
                <asp:Parameter Name="original_INCLUSAO_EMAIL" Type="String" />
                <asp:Parameter Name="original_INCLUSAO_DATA" Type="Decimal" />
                <asp:Parameter Name="original_ALTERACAO_EMAIL" Type="String" />
                <asp:Parameter Name="original_ALTERACAO_DATA" Type="Decimal" />
                <asp:Parameter Name="original_EXCLUSAO_EMAIL" Type="String" />
                <asp:Parameter Name="original_EXCLUSAO_DATA" Type="Decimal" />
                <asp:Parameter Name="original_ATUALIZACAO_RECEITA_DATA" Type="Decimal" />
                <asp:Parameter Name="original_ATUALIZACAO_RECEITA_CHECK" Type="Boolean" />
                <asp:Parameter Name="original_ATUALIZACAO_RECEITA_EMAIL" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="CNPJ" Type="Decimal" />
                <asp:Parameter Name="CNPJ_FORMATADO" Type="String" />
                <asp:Parameter Name="CNES" Type="String" />
                <asp:Parameter Name="COD_INTERNO" Type="String" />
                <asp:Parameter Name="TIPO_PESSOA" Type="String" />
                <asp:Parameter Name="GRUPO" Type="String" />
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
                <asp:Parameter Name="ID_GRUPO_ESTABELECIMENTO" Type="String" />
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
                <asp:Parameter Name="MUNICIPIO" Type="String" />
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
                <asp:Parameter Name="original_CNPJ_FORMATADO" Type="String" />
                <asp:Parameter Name="original_CNES" Type="String" />
                <asp:Parameter Name="original_COD_INTERNO" Type="String" />
                <asp:Parameter Name="original_TIPO_PESSOA" Type="String" />
                <asp:Parameter Name="original_GRUPO" Type="String" />
                <asp:Parameter Name="original_APELIDO" Type="String" />
                <asp:Parameter Name="original_ESTABELECIMENTO" Type="String" />
                <asp:Parameter Name="original_ESTABELECIMENTO_CNPJ" Type="String" />
                <asp:Parameter Name="original_RAZAO_SOCIAL" Type="String" />
                <asp:Parameter Name="original_NOME_FANTASIA" Type="String" />
                <asp:Parameter Name="original_ENDERECO" Type="String" />
                <asp:Parameter Name="original_LOGRADOURO" Type="String" />
                <asp:Parameter Name="original_NUMERO" Type="String" />
                <asp:Parameter Name="original_COMPLEMENTO" Type="String" />
                <asp:Parameter Name="original_BAIRRO" Type="String" />
                <asp:Parameter Name="original_CEP" Type="String" />
                <asp:Parameter Name="original_COD_MUNICIPIO" Type="String" />
                <asp:Parameter Name="original_CIDADE" Type="String" />
                <asp:Parameter Name="original_UF" Type="String" />
                <asp:Parameter Name="original_ESTADO" Type="String" />
                <asp:Parameter Name="original_REGIAO" Type="String" />
                <asp:Parameter Name="original_REGIAO_SAUDE" Type="String" />
                <asp:Parameter Name="original_MICRO_REGIAO_SAUDE" Type="String" />
                <asp:Parameter Name="original_COD_NATUREZA_JURIDICA" Type="Decimal" />
                <asp:Parameter Name="original_NATUREZA_JURIDICA_DESCRICAO" Type="String" />
                <asp:Parameter Name="original_COD_ESFERA_ADMINISTRATIVA" Type="Decimal" />
                <asp:Parameter Name="original_ESFERA" Type="String" />
                <asp:Parameter Name="original_GESTAO" Type="String" />
                <asp:Parameter Name="original_COD_CNAE" Type="String" />
                <asp:Parameter Name="original_CNAE_DESCRICAO" Type="String" />
                <asp:Parameter Name="original_DATA_FUNDACAO" Type="Decimal" />
                <asp:Parameter Name="original_DATA_SITUACAORFB" Type="Decimal" />
                <asp:Parameter Name="original_SITUACAORFB" Type="String" />
                <asp:Parameter Name="original_MOTIVO_SITUACAORFB" Type="String" />
                <asp:Parameter Name="original_MOTIVO_ESPECIAL_SITUACAORFB" Type="String" />
                <asp:Parameter Name="original_EMAIL_GERENTE_CONTA" Type="String" />
                <asp:Parameter Name="original_INCLUSAO_EMAIL" Type="String" />
                <asp:Parameter Name="original_INCLUSAO_DATA" Type="Decimal" />
                <asp:Parameter Name="original_ALTERACAO_EMAIL" Type="String" />
                <asp:Parameter Name="original_ALTERACAO_DATA" Type="Decimal" />
                <asp:Parameter Name="original_EXCLUSAO_EMAIL" Type="String" />
                <asp:Parameter Name="original_EXCLUSAO_DATA" Type="Decimal" />
                <asp:Parameter Name="original_ATUALIZACAO_RECEITA_DATA" Type="Decimal" />
                <asp:Parameter Name="original_ATUALIZACAO_RECEITA_CHECK" Type="Boolean" />
                <asp:Parameter Name="original_ATUALIZACAO_RECEITA_EMAIL" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
</form>
</body>
</html>