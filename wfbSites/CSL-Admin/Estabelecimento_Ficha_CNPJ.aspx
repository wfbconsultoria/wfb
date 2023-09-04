<%@ Page Language="VB" Debug="true" AutoEventWireup="false" CodeFile="Estabelecimento_Ficha_CNPJ.aspx.vb" Inherits="Estabelecimento_Ficha_CNPJ" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    </head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Ficha de Cliente CNPJ</div>
    <div id ="Titulo_Pagina_Links">
        <a href="Estabelecimentos_Localizar_CNPJ.aspx">LIsta de  Estabelecimentos CNPJ</a>
    </div>
</div>
<br />
    <div id ="Corpo">
        <br/>
        <asp:FormView ID="FormView1" runat="server" DataSourceID="dts_Estabelecimentos" Width="100%">
            <EditItemTemplate>
                Origem:
                <asp:TextBox ID="OrigemTextBox" runat="server" Text='<%# Bind("Origem") %>' />
                <br />
                DOCUMENTO:
                <asp:TextBox ID="DOCUMENTOTextBox" runat="server" Text='<%# Bind("DOCUMENTO") %>' />
                <br />
                CNES:
                <asp:TextBox ID="CNESTextBox" runat="server" Text='<%# Bind("CNES") %>' />
                <br />
                ESTABELECIMENTO:
                <asp:TextBox ID="ESTABELECIMENTOTextBox" runat="server" Text='<%# Bind("ESTABELECIMENTO") %>' />
                <br />
                NOME_FANTASIA:
                <asp:TextBox ID="NOME_FANTASIATextBox" runat="server" Text='<%# Bind("NOME_FANTASIA") %>' />
                <br />
                RAZAO_SOCIAL:
                <asp:TextBox ID="RAZAO_SOCIALTextBox" runat="server" Text='<%# Bind("RAZAO_SOCIAL") %>' />
                <br />
                Cidade:
                <asp:TextBox ID="CidadeTextBox" runat="server" Text='<%# Bind("Cidade") %>' />
                <br />
                Cidade_Mapa:
                <asp:TextBox ID="Cidade_MapaTextBox" runat="server" Text='<%# Bind("Cidade_Mapa") %>' />
                <br />
                UF:
                <asp:TextBox ID="UFTextBox" runat="server" Text='<%# Bind("UF") %>' />
                <br />
                MICRO_REGIAO:
                <asp:TextBox ID="MICRO_REGIAOTextBox" runat="server" Text='<%# Bind("MICRO_REGIAO") %>' />
                <br />
                REGIAO:
                <asp:TextBox ID="REGIAOTextBox" runat="server" Text='<%# Bind("REGIAO") %>' />
                <br />
                LOGRADOURO:
                <asp:TextBox ID="LOGRADOUROTextBox" runat="server" Text='<%# Bind("LOGRADOURO") %>' />
                <br />
                COMPLEMENTO:
                <asp:TextBox ID="COMPLEMENTOTextBox" runat="server" Text='<%# Bind("COMPLEMENTO") %>' />
                <br />
                NUMERO:
                <asp:TextBox ID="NUMEROTextBox" runat="server" Text='<%# Bind("NUMERO") %>' />
                <br />
                BAIRRO:
                <asp:TextBox ID="BAIRROTextBox" runat="server" Text='<%# Bind("BAIRRO") %>' />
                <br />
                CEP:
                <asp:TextBox ID="CEPTextBox" runat="server" Text='<%# Bind("CEP") %>' />
                <br />
                TIPO_PESSOA:
                <asp:TextBox ID="TIPO_PESSOATextBox" runat="server" Text='<%# Bind("TIPO_PESSOA") %>' />
                <br />
                ESFERA:
                <asp:TextBox ID="ESFERATextBox" runat="server" Text='<%# Bind("ESFERA") %>' />
                <br />
                GESTAO:
                <asp:TextBox ID="GESTAOTextBox" runat="server" Text='<%# Bind("GESTAO") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
            <InsertItemTemplate>
                Origem:
                <asp:TextBox ID="OrigemTextBox" runat="server" Text='<%# Bind("Origem") %>' />
                <br />
                DOCUMENTO:
                <asp:TextBox ID="DOCUMENTOTextBox" runat="server" Text='<%# Bind("DOCUMENTO") %>' />
                <br />
                CNES:
                <asp:TextBox ID="CNESTextBox" runat="server" Text='<%# Bind("CNES") %>' />
                <br />
                ESTABELECIMENTO:
                <asp:TextBox ID="ESTABELECIMENTOTextBox" runat="server" Text='<%# Bind("ESTABELECIMENTO") %>' />
                <br />
                NOME_FANTASIA:
                <asp:TextBox ID="NOME_FANTASIATextBox" runat="server" Text='<%# Bind("NOME_FANTASIA") %>' />
                <br />
                RAZAO_SOCIAL:
                <asp:TextBox ID="RAZAO_SOCIALTextBox" runat="server" Text='<%# Bind("RAZAO_SOCIAL") %>' />
                <br />
                Cidade:
                <asp:TextBox ID="CidadeTextBox" runat="server" Text='<%# Bind("Cidade") %>' />
                <br />
                Cidade_Mapa:
                <asp:TextBox ID="Cidade_MapaTextBox" runat="server" Text='<%# Bind("Cidade_Mapa") %>' />
                <br />
                UF:
                <asp:TextBox ID="UFTextBox" runat="server" Text='<%# Bind("UF") %>' />
                <br />
                MICRO_REGIAO:
                <asp:TextBox ID="MICRO_REGIAOTextBox" runat="server" Text='<%# Bind("MICRO_REGIAO") %>' />
                <br />
                REGIAO:
                <asp:TextBox ID="REGIAOTextBox" runat="server" Text='<%# Bind("REGIAO") %>' />
                <br />
                LOGRADOURO:
                <asp:TextBox ID="LOGRADOUROTextBox" runat="server" Text='<%# Bind("LOGRADOURO") %>' />
                <br />
                COMPLEMENTO:
                <asp:TextBox ID="COMPLEMENTOTextBox" runat="server" Text='<%# Bind("COMPLEMENTO") %>' />
                <br />
                NUMERO:
                <asp:TextBox ID="NUMEROTextBox" runat="server" Text='<%# Bind("NUMERO") %>' />
                <br />
                BAIRRO:
                <asp:TextBox ID="BAIRROTextBox" runat="server" Text='<%# Bind("BAIRRO") %>' />
                <br />
                CEP:
                <asp:TextBox ID="CEPTextBox" runat="server" Text='<%# Bind("CEP") %>' />
                <br />
                TIPO_PESSOA:
                <asp:TextBox ID="TIPO_PESSOATextBox" runat="server" Text='<%# Bind("TIPO_PESSOA") %>' />
                <br />
                ESFERA:
                <asp:TextBox ID="ESFERATextBox" runat="server" Text='<%# Bind("ESFERA") %>' />
                <br />
                GESTAO:
                <asp:TextBox ID="GESTAOTextBox" runat="server" Text='<%# Bind("GESTAO") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="ESTABELECIMENTOLabel" runat="server" Text='<%# Bind("ESTABELECIMENTO") %>' style="font-weight: 700" />
                <br />
                <br />
                <strong>Origem:</strong>
                <asp:Label ID="OrigemLabel" runat="server" Text='<%# Bind("Origem") %>' />
                <br />
                <strong>Documento:</strong>
                <asp:Label ID="DOCUMENTOLabel" runat="server" Text='<%# Bind("DOCUMENTO") %>' />
                <br />
                <strong>CNES:</strong>
                <asp:Label ID="CNESLabel" runat="server" Text='<%# Bind("CNES") %>' />
                <br />
                <strong>Nome Fantasia:</strong>
                <asp:Label ID="NOME_FANTASIALabel" runat="server" Text='<%# Bind("NOME_FANTASIA") %>' />
                <br />
                <strong>Razão Social:</strong>
                <asp:Label ID="RAZAO_SOCIALLabel" runat="server" Text='<%# Bind("RAZAO_SOCIAL") %>' />
                <br />
                <strong>Cidade:</strong>
                <asp:Label ID="CidadeLabel" runat="server" Text='<%# Bind("Cidade") %>' />
                <br />
                <strong>Cidade Mapa:</strong>
                <asp:Label ID="Cidade_MapaLabel" runat="server" Text='<%# Bind("Cidade_Mapa") %>' />
                <br />
                <strong>UF:</strong>
                <asp:Label ID="UFLabel" runat="server" Text='<%# Bind("UF") %>' />
                <br />
                <strong>Micro Região</strong>:
                <asp:Label ID="MICRO_REGIAOLabel" runat="server" Text='<%# Bind("MICRO_REGIAO") %>' />
                <br />
                <strong>Região:</strong>
                <asp:Label ID="REGIAOLabel" runat="server" Text='<%# Bind("REGIAO") %>' />
                <br />
                <strong>Logradouro:</strong>
                <asp:Label ID="LOGRADOUROLabel" runat="server" Text='<%# Bind("LOGRADOURO") %>' />
                <br />
                <strong>Complemento:</strong>
                <asp:Label ID="COMPLEMENTOLabel" runat="server" Text='<%# Bind("COMPLEMENTO") %>' />
                <br />
                <strong>Número:</strong>
                <asp:Label ID="NUMEROLabel" runat="server" Text='<%# Bind("NUMERO") %>' />
                <br />
                <strong>Bairro:</strong>
                <asp:Label ID="BAIRROLabel" runat="server" Text='<%# Bind("BAIRRO") %>' />
                <br />
                <strong>Cep:</strong>
                <asp:Label ID="CEPLabel" runat="server" Text='<%# Bind("CEP") %>' />
                <br />
                <strong>Tipo Pessoa:</strong>
                <asp:Label ID="TIPO_PESSOALabel" runat="server" Text='<%# Bind("TIPO_PESSOA") %>' />
                <br />
                <strong>Esfera:</strong>
                <asp:Label ID="ESFERALabel" runat="server" Text='<%# Bind("ESFERA") %>' />
                <br />
                <strong>Gestão:</strong>
                <asp:Label ID="GESTAOLabel" runat="server" Text='<%# Bind("GESTAO") %>' />
                <br />

            </ItemTemplate>
        </asp:FormView>
        <br />
    <asp:SqlDataSource ID="dts_Estabelecimentos" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [View_RF_Estabelecimentos] WHERE ([DOCUMENTO] = @DOCUMENTO)">
        <SelectParameters>
            <asp:QueryStringParameter Name="DOCUMENTO" QueryStringField="CNPJ" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
    </form> 
</body>
</html>
