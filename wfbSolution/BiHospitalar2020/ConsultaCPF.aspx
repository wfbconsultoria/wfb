<%@ Page Title="Validar seu CPF" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master.Master" CodeBehind="ConsultaCPF.aspx.vb" Inherits="BiHospitalar2020.ConsultaCPF" %>

<%@ Register Src="~/_Page_Header_Public.ascx" TagPrefix="uc1" TagName="_Page_Header_Public" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <%--Máscara de entrada--%>
    <script type="text/javascript">
        // mascara entrada
        function formatar(mascara, documento) {
            let i = documento.value.length;
            let saida = mascara.substring(0, 1);
            let texto = mascara.substring(i)

            if (texto.substring(0, 1) != saida) {
                documento.value += texto.substring(0, 1);
            }
        }

        function somenteNumeros(e) {
            var charCode = e.charCode ? e.charCode : e.keyCode;
            // charCode 8 = backspace   
            // charCode 9 = tab
            if (charCode != 8 && charCode != 9) {
                // charCode 48 equivale a 0   
                // charCode 57 equivale a 9
                if (charCode < 48 || charCode > 57) {
                    return false;
                }
            }
        }

    </script>
    <%--Máscara de entrada--%>

    <%--Valida Data--%>
    <script type="text/javascript">
        function validaDat(campo, valor) {
            var date = valor;
            var ardt = new Array;
            var ExpReg = new RegExp("(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[12][0-9]{3}");
            ardt = date.split("/");
            erro = false;
            if (date.search(ExpReg) == -1) {
                erro = true;
            }
            else if (((ardt[1] == 4) || (ardt[1] == 6) || (ardt[1] == 9) || (ardt[1] == 11)) && (ardt[0] > 30))
                erro = true;
            else if (ardt[1] == 2) {
                if ((ardt[0] > 28) && ((ardt[2] % 4) != 0))
                    erro = true;
                if ((ardt[0] > 29) && ((ardt[2] % 4) == 0))
                    erro = true;
            }
            if (date == "") erro = false;
            if (erro) {
                alert("DATA Formato inválido (dd/mm/aaaa");
                campo.value = "";
                return false;
            }
            return true;
        }
    </script>
    <%--/Valida Data--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:_Page_Header_Public runat="server" ID="_Page_Header_Public" />
    <%--Conteudo da página--%>
    <div>
        
        <%--Mensagens--%>
        <p runat="server" id="PageMessages" class="text-info"></p>
        <%--Mensagens--%>
        
        <%--EMAIL/CPF/DATA NASCIMENTO--%>
        <div class="form-row">

            <%--Email--%>
            <div class="form-group col-md-8">
                <label for="txt_Email">E-mail</label>
                <input id="txt_Email" runat="server" type="text" required="required" autocomplete="off" maxlength="128" class="form-control" placeholder="Email" readonly="readonly" />
            </div>
            <%--/Email--%>

            <%--CPF--%>
            <div class="form-group col-md-2">
                <label for="txt_Document">CPF</label>
                <input id="txt_Document" runat="server" type="text" required="required" autocomplete="off" maxlength="14" class="form-control" placeholder="000.000.000-00" onfocus="this.value='';ResetMessage()" onkeypress="formatar('###.###.###-##', this)" disabled="disabled" />
            </div>
            <%--/CPF--%>

            <%--Data Nascimento--%>
            <div class="form-group col-md-2">
                <label for="txt_Birth_Date">Data Nascimento</label>
                <input id="txt_Birth_Date" runat="server" type="text" required="required" autocomplete="off" maxlength="10" class="form-control" placeholder="dd/mm/aaaa" onfocus="this.value=''" onkeypress="formatar('##/##/####', this);" onblur="validaDat(this,this.value);" disabled="disabled"/>
            </div>
            <%--/Data Nascimento--%>
        </div>
        <%--/EMAIL/CPF/DATA NASCIMENTO--%>

        <%--Nome--%>
        <div class="form-group">
            <label for="txt_Name">Nome</label>
            <input id="txt_Name" runat="server" type="text" required="required" autocomplete="off" maxlength="128" class="form-control" placeholder="Nome somente letras sem acentuação" readonly="readonly" />
        </div>
        <%--/Nome--%>

        <%--CEP/ENDERECO/NUMERO--%>
        <div class="form-row">

            <%--CEP--%>
            <div class="form-group col-md-2">
                <label for="txt_Address_ZIP">CEP</label>
                <input id="txt_Address_ZIP" runat="server" type="text" required="required" autocomplete="off" maxlength="9" class="form-control" placeholder="CEP 00000-000" onfocus="this.value=''" onkeypress="formatar('#####-##', this)" />
            </div>
            <%--/CEP--%>

            <%--Endereço--%>
            <div class="form-group col-md-8">
                <label for="txt_Address">Endereço</label>
                <input id="txt_Address" runat="server" type="text" autocomplete="off" maxlength="200" class="form-control" placeholder="Endereço" readonly="readonly" />
            </div>
            <%--/Endereço--%>

            <%--Numero--%>
            <div class="form-group col-md-2">
                <label for="txt_Address_Number">Número</label>
                <input id="txt_Address_Number" runat="server" type="text" required="required" autocomplete="off" maxlength="30" class="form-control" placeholder="Número" />
            </div>
            <%--/Numero--%>
        </div>
        <%--CEP/ENDERECO/NUMERO--%>

        <%--COMPLEMENTO/BAIRRO--%>
        <div class="form-row">

            <%--Complemento--%>
            <div class="form-group col-md-6">
                <label for="txt_Address_Complement">Complemento</label>
                <input id="txt_Address_Complement" runat="server" type="text" autocomplete="off" maxlength="50" class="form-control" placeholder="Complemento" />
            </div>
            <%--/Complemento--%>

            <%--Bairro--%>
            <div class="form-group col-md-6">
                <label for="txt_Address_District">Bairro</label>
                <input id="txt_Address_District" runat="server" type="text" autocomplete="off" class="form-control" placeholder="Bairro" readonly="readonly" />
            </div>
            <%--/Bairro--%>
        </div>
        <%--/COMPLEMENTO/BAIRRO--%>

        <%--CIDADE/ESTADO/PAIS--%>
        <div class="form-row">

            <%--Cidade--%>
            <div class="form-group col-md-6">
                <label for="txt_Address_City">Cidade</label>
                <input id="txt_Address_City" runat="server" type="text" autocomplete="off" class="form-control" placeholder="Cidade" readonly="readonly" />
            </div>
            <%--/Cidade--%>

            <%--UF--%>
            <div class="form-group col-md-2">
                <label for="txt_Address_State">UF</label>
                <input id="txt_Address_State" runat="server" type="text" autocomplete="off" class="form-control" placeholder="UF" readonly="readonly" />
            </div>
            <%--/UF--%>

            <%--Pais--%>
            <div class="form-group col-md-4">
                <label for="txt_Address_Country">País</label>
                <input id="txt_Address_Country" runat="server" type="text" autocomplete="off" class="form-control" placeholder="País" readonly="readonly" />
            </div>
            <%--/Pais--%>
        </div>
        <%--/CIDADE/ESTADO/PAIS--%>

        <%--Botões e links--%>
        <asp:Button runat="server" Text="Consultar e validar" OnClick="ConsultaCPF" />
        <input runat="server" type="button" id="cmd_ConsultaCPF" value="Consultar CPF" />
        <input runat="server" type="button" id="cmd_ConsultaCEP" value="Consultar CEP" />
        <input runat="server" type="button" id="cmd_Save" value="Gravar" />
        <%--/Botões e links--%>
    </div>
    <%--END Conteudo da página--%>
</asp:Content>

<%--Footer Scrpits--%>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
