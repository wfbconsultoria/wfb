<%@ Page Title="Perfil do Usuário" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master.Master" CodeBehind="User_Profile.aspx.vb" Inherits="BiHospitalar2020.User_Profile" %>

<%@ Register Src="~/_Page_Header_Private.ascx" TagPrefix="uc1" TagName="_Page_Header_Private" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <%--Busca de CEP--%>
    <script type="text/javascript">
        function limpa_formulário_cep() {
            //Limpa valores do formulário de cep.
            document.getElementById('txt_Address_ZIP').value = ("");
            document.getElementById('txt_Address').value = ("");
            document.getElementById('txt_Address_District').value = ("");
            document.getElementById('txt_Address_City').value = ("");
            document.getElementById('txt_Address_State').value = ("");
            document.getElementById('txt_Address_City_Code').value = ("");
        }
        function meu_callback(conteudo) {
            if (!("erro" in conteudo)) {
                //Atualiza os campos com os valores.
                document.getElementById('txt_Address').value = (conteudo.logradouro);
                document.getElementById('txt_Address_District').value = (conteudo.bairro);
                document.getElementById('txt_Address_City').value = (conteudo.localidade);
                document.getElementById('txt_Address_State').value = (conteudo.uf);
                document.getElementById('txt_Address_City_Code').value = (conteudo.ibge);
            } //end if.
            else {
                //CEP não Encontrado.
                limpa_formulário_cep();
                alert("CEP não encontrado.");
            }
        }
        function pesquisacep(valor) {

            //Nova variável "cep" somente com dígitos.
            var cep = valor.replace(/\D/g, '');

            //Verifica se campo cep possui valor informado.
            if (cep != "") {

                //Expressão regular para validar o CEP.
                var validacep = /^[0-9]{8}$/;

                //Valida o formato do CEP.
                if (validacep.test(cep)) {

                    //Preenche os campos com "..." enquanto consulta webservice.
                     
                    document.getElementById('txt_Address_District').value = "...";
                    document.getElementById('txt_Address_City').value = "...";
                    document.getElementById('txt_Address_State').value = "...";
                    document.getElementById('txt_Address_City_Code').value = "...";

                    //Cria um elemento javascript.
                    var script = document.createElement('script');

                    //Sincroniza com o callback.
                    script.src = 'https://viacep.com.br/ws/' + cep + '/json/?callback=meu_callback';

                    //Insere script no documento e carrega o conteúdo.
                    document.body.appendChild(script);

                } //end if.
                else {
                    //cep é inválido.
                    alert("Formato de CEP inválido.");
                }
            } //end if.
            else {
                //cep sem valor, limpa formulário.
                limpa_formulário_cep();
            }
        };
    </script>
    <%--/Busca de CEP--%>

    <%--Valida CPF--%>
    <script type="text/javascript">
        function TestaCPF(strCPF) {
            var Soma;
            var Resto;
            Soma = 0;
            if (strCPF == "00000000000") return false;
            if (strCPF == "") return True;

            for (i = 1; i <= 9; i++) Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (11 - i);
            Resto = (Soma * 10) % 11;

            if ((Resto == 10) || (Resto == 11)) Resto = 0;
            if (Resto != parseInt(strCPF.substring(9, 10))) return false;

            Soma = 0;
            for (i = 1; i <= 10; i++) Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (12 - i);
            Resto = (Soma * 10) % 11;

            if ((Resto == 10) || (Resto == 11)) Resto = 0;
            if (Resto != parseInt(strCPF.substring(10, 11))) return false;
            return true;
        }

        function ValidaCPF(CPF) {
            if (TestaCPF(CPF)) {

            }
            else {
                document.getElementById('txt_Document').value = "";
                alert("CPF inválido");
            }
        }
    </script>
    <%--/Valida CPF--%>

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
                alert("Data Invalida (dd/mm/aaaa com as barras");
                campo.value = "";
                return false;
            }
            return true;
        }
    </script>
    <%--/Valida Data--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:_Page_Header_Private runat="server" ID="_Page_Header_Private" />
    <%--Conteudo da página--%>
    <div>

        <%--Email/CPF/Nascimento/Telefone--%>
        <div class="form-row">

            <%--EMAIL--%>
            <div class="form-group col-md-4">
                <asp:Label ID="lbl_Email" runat="server" AssociatedControlID="txt_Email" Text="Email" />
                <asp:TextBox ID="txt_Email" runat="server" CssClass="form-control" placeholder="Email" ClientIDMode="Inherit" Enabled="False" MaxLength="200" required="required" AutoCompleteType="Disabled" autocomplete="off" TextMode="Email" />
            </div>
            <%--/EMAIL--%>

            <%--CPF--%>
            <div class="form-group col-md-2">
                <asp:Label ID="lbl_Document" runat="server" AssociatedControlID="txt_Document" Text="CPF" />
                <asp:TextBox ID="txt_Document" runat="server" CssClass="form-control" placeholder="Somente números" MaxLength="11" required="required" AutoCompleteType="Disabled" autocomplete="off" onblur="ValidaCPF(this.value);" ClientIDMode="Static" />
                <asp:RequiredFieldValidator ID="rfv_Document" runat="server" ControlToValidate="txt_Document" CssClass="text-danger" ErrorMessage="CPF obrigatório" Display="Dynamic" />
                <asp:RegularExpressionValidator ID="rev_Document" runat="server" ControlToValidate="txt_Document" Display="Dynamic"
                    ErrorMessage="CPF Invalido" CssClass="text-danger"
                    ValidationExpression="(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)|(^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$)" />
            </div>
            <%--/CPF--%>

            <%--Data Nascimento--%>
            <div class="form-group col-md-2">
                <asp:Label ID="lbl_Birth_Date" runat="server" AssociatedControlID="txt_Birth_Date" Text="Nascimento" />
                <asp:TextBox ID="txt_Birth_Date" runat="server" CssClass="form-control" placeholder="dd/mm/aaaa" MaxLength="10" required="required" AutoCompleteType="Disabled" autocomplete="off" TextMode="SingleLine" onblur="validaDat(this,this.value);" ClientIDMode="Static" />
                <asp:RequiredFieldValidator ID="rfv_Birth_Date" runat="server" ControlToValidate="txt_Birth_Date" CssClass="text-danger" ErrorMessage="Obrigatório" Display="Dynamic" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_Birth_Date" Display="Dynamic"
                    ErrorMessage="Data inválida" CssClass="text-danger"
                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/(19|20)\d{2,2}" />
            </div>
            <%--/Data Nascimento--%>

            <%--TELEFONE--%>
            <div class="form-group col-md-4">
                <asp:Label ID="lbl_Phone" runat="server" AssociatedControlID="txt_Phone" Text="Telefone" />
                <asp:TextBox ID="txt_Phone" runat="server" CssClass="form-control" placeholder="DDD + Numero (00999990000) sem traços" MaxLength="50" required="required" AutoCompleteType="Disabled" autocomplete="off" />
                <asp:RequiredFieldValidator ID="rfv_Phone" runat="server" ControlToValidate="txt_Phone" CssClass="text-danger" ErrorMessage="Telefone obrigatório" Display="Dynamic" />
                <asp:RegularExpressionValidator ID="rev_Phone" runat="server" ControlToValidate="txt_Phone" Display="Dynamic"
                    ErrorMessage="Telefone 00999990000 sem traços e acentos " CssClass="text-danger"
                    ValidationExpression="^[a-zA-Z0-9 ]{0,50}$" />
            </div>
            <%--/TELEFONE--%>
        </div>
        <%--/Email/CPF/Nascimento/Telefone--%>
        <%--Nome--%>
        <div class="form-group">
            <asp:Label ID="lbl_Name" runat="server" AssociatedControlID="txt_Name" Text="Nome"></asp:Label>
            <asp:TextBox ID="txt_Name" runat="server" CssClass="form-control" placeholder="Nome (sem acentos, 5 caracteres)" Enabled="True" required="required" MaxLength="200" AutoCompleteType="Disabled" autocomplete="off" />
            <asp:RequiredFieldValidator ID="rfv_Name" runat="server" ControlToValidate="txt_Name" CssClass="text-danger" ErrorMessage="Nome obrigatório" Display="Dynamic" />
            <asp:RegularExpressionValidator ID="rev_Name" runat="server" ControlToValidate="txt_Name" Display="Dynamic"
                ErrorMessage="Nome inválido (somente letras, mímino 5 caracteres" CssClass="text-danger"
                ValidationExpression="^[a-zA-Zà-úÀ-Ú ]{5,200}$" />
        </div>
        <%--/Nome--%>

        <%--CEP/Endereço/Número--%>
        <div class="form-row">
            <%--CEP--%>
            <div class="form-group col-md-2">
                <asp:Label ID="lbl_Address_ZIP" runat="server" AssociatedControlID="txt_Address_ZIP" Text="CEP" />
                <asp:TextBox ID="txt_Address_ZIP" runat="server" CssClass="form-control" placeholder="CEP (sem traço)"
                    Enabled="True" required="required" MaxLength="8" AutoCompleteType="Disabled" autocomplete="off"
                    onblur="pesquisacep(this.value); " ClientIDMode="Static"
                    aria-label="CEP" aria-describedby="inputGroup-sizing-default" ToolTip="Busca de endereço" />
                <asp:RequiredFieldValidator ID="rfv_Address_ZIP" runat="server" ControlToValidate="txt_Address_ZIP" CssClass="text-danger" ErrorMessage="CEP obrigatório" Display="None" ValidationGroup="vgp_Adrress" />
                <asp:RegularExpressionValidator ID="rev_Address_ZIP" runat="server" ControlToValidate="txt_Address_ZIP" Display="None" ErrorMessage="CEP inválido (somente numeros, 8 posições)" CssClass="text-danger"
                    ValidationExpression="^[0-9 ]{8}$" ValidationGroup="vgp_Adrress" />
            </div>
            <%--/CEP--%>

            <%--Endereço--%>
            <div class="form-group col-md-8">
                <asp:Label ID="lbl_Address" runat="server" AssociatedControlID="txt_Address" Text="Endereço" />
                <%--<asp:TextBox ID="txt_Address" runat="server" CssClass="form-control" placeholder="Endereço" TextMode="SingleLine" Rows="2" MaxLength="200" ClientIDMode="Static" AutoCompleteType="Disabled" autocomplete="off" />--%>
                <input id="txt_Address" runat="server" class="form-control" placeholder="Endereço" type="text" autocomplete="off" maxlength="200" />
                <asp:RequiredFieldValidator ID="rfv_Address" runat="server" ControlToValidate="txt_Address" CssClass="text-danger" ErrorMessage="Endereço obrigatório" Display="None" ValidationGroup="vgp_Adrress" />
                <asp:RegularExpressionValidator ID="rev_Address" runat="server" ControlToValidate="txt_Address" Display="None"
                    ErrorMessage="Endereço inválido (Números e letras, mímino 5 caracteres" CssClass="text-danger"
                    ValidationExpression="^[a-zA-Zà-úÀ-Ú0-9 ]{5,200}$" ValidationGroup="vgp_Adrress" />
            </div>
            <%--/Endereço--%>

            <%--Número--%>
            <div class="form-group col-md-2">
                <asp:Label ID="lbl_Address_Number" runat="server" AssociatedControlID="txt_Address_Number" Text="Número"></asp:Label>
                <asp:TextBox ID="txt_Address_Number" runat="server" CssClass="form-control" placeholder="Número" TextMode="SingleLine" ClientIDMode="Static" MaxLength="10" AutoCompleteType="Disabled" autocomplete="off"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_Address_Number" runat="server" ControlToValidate="txt_Address_Number" CssClass="text-danger" ErrorMessage="Número obrigatório, caso não exista digite SN" Display="None" ValidationGroup="vgp_Adrress" />
                <asp:RegularExpressionValidator ID="rev_Address_Number" runat="server" ControlToValidate="txt_Address_Number" Display="None"
                    ErrorMessage="Número inválido (somente números e letras)" CssClass="text-danger" ValidationExpression="^[a-zA-Zà-úÀ-Ú0-9 ]{0,10}$" ValidationGroup="vgp_Adrress" />
            </div>
            <%--/Número--%>
        </div>
        <%--/CEP/Endereço/Número--%>

        <%--Complemento/Bairro--%>
        <div class="form-row">

            <%--Complemento--%>
            <div class="form-group col-md-6">
                <asp:Label ID="lbl_Address_Complement" runat="server" AssociatedControlID="txt_Address_Complement" Text="Complemento" />
                <input type="text" id="txt_Address_Complement" runat="server" class="form-control" placeholder="Complemento"  autocomplete="off" maxlength="100" />
                <asp:RegularExpressionValidator ID="rev_Address_Complement" runat="server" ControlToValidate="txt_Address_Complement" Display="None"
                    ErrorMessage="Complemento inválido (somente números ou letras, 50 posições)" CssClass="text-danger"
                    ValidationExpression="^[a-zA-Zà-úÀ-Ú0-9 ]{0,50}$" ValidationGroup="vgp_Adrress" />
            </div>
            <%--/Complemento--%>

            <%--Bairro--%>
            <div class="form-group col-md-6">
                <asp:Label ID="lbl_Address_District" runat="server" AssociatedControlID="txt_Address_District" Text="Bairro" />
                <asp:TextBox ID="txt_Address_District" runat="server" CssClass="form-control" placeholder="Bairro" ClientIDMode="Static" MaxLength="100" AutoCompleteType="Disabled" autocomplete="off" />
                <asp:RegularExpressionValidator ID="rev_Address_District" runat="server" ControlToValidate="txt_Address_District" Display="None"
                    ErrorMessage="Bairro inválido (somente números ou letras, 100 posições)" CssClass="text-danger"
                    ValidationExpression="^[a-zA-Zà-úÀ-Ú0-9 ]{0,100}$" ValidationGroup="vgp_Adrress" />
            </div>
            <%--/Bairro--%>
        </div>
        <%--/Complemento/Bairro--%>

        <%--Cidade/CodIBGE/UF--%>
        <div class="form-row">

            <%--Cidade--%>
            <div class="form-group col-md-8">
                <asp:Label ID="lbl_Address_City" runat="server" AssociatedControlID="txt_Address_City" Text="Cidade" />
                <asp:TextBox ID="txt_Address_City" runat="server" CssClass="form-control" placeholder="Cidade" ClientIDMode="Static" MaxLength="100" required="required" AutoCompleteType="Disabled" autocomplete="off" />
                <asp:RequiredFieldValidator ID="rfv_Address_City" runat="server" ControlToValidate="txt_Address_City" CssClass="text-danger" ErrorMessage="Cidade obrigatória" Display="None" ValidationGroup="vgp_Adrress" />
                <asp:RegularExpressionValidator ID="rev_Address_City" runat="server" ControlToValidate="txt_Address_City" Display="None"
                    ErrorMessage="Cidade inválida (somente letras, 100 posições)" CssClass="text-danger"
                    ValidationExpression="^[a-zA-Zà-úÀ-Ú ]{0,100}$" ValidationGroup="vgp_Adrress" />
            </div>
            <%--/Cidade--%>

            <%--CodIBGE--%>
            <div class="form-group col-md-2">
                <asp:Label ID="lbl_Address_City_Code" runat="server" AssociatedControlID="txt_Address_City_Code" Text="IBGE"></asp:Label>
                <asp:TextBox ID="txt_Address_City_Code" runat="server" CssClass="form-control" placeholder="IBGE" ClientIDMode="Static" Enabled="False" AutoCompleteType="Disabled" autocomplete="off"></asp:TextBox>
            </div>
            <%--/CodIBGE--%>

            <%--UF--%>
            <div class="form-group col-md-2">
                <asp:Label ID="lbl_Address_State" runat="server" AssociatedControlID="txt_Address_State" Text="UF"></asp:Label>
                <asp:TextBox ID="txt_Address_State" runat="server" CssClass="form-control" placeholder="UF" MaxLength="2" required="required" ClientIDMode="Static" AutoCompleteType="Disabled" autocomplete="off"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_Address_State" runat="server" ControlToValidate="txt_Address_State" CssClass="text-danger" ErrorMessage="UF obrigatória" Display="None" ValidationGroup="vgp_Adrress" />
                <asp:RegularExpressionValidator ID="rev_Address_State" runat="server" ControlToValidate="txt_Address_State" Display="None"
                    ErrorMessage="UF inválida (somente letras, 2 posições)" CssClass="text-danger"
                    ValidationExpression="^[A-Z]{2}$" ValidationGroup="vgp_Adrress" />
            </div>
            <%--/UF--%>
        </div>
        <%--/Cidade/CodIBGE/UF--%>

        <%--Validação CEP/Endereço/Número--%>
        <div class="form-group">
            <asp:ValidationSummary ID="vls_Adrress" runat="server" ValidationGroup="vgp_Adrress" CssClass="text-danger" />
        </div>
        <%--/Validação CEP/Endereço/Número--%>

        <%--Observações--%>
        <div class="form-group">
            <asp:Label ID="lbl_Notes" runat="server" AssociatedControlID="txt_Notes" Text="Anotações"></asp:Label>
            <asp:TextBox ID="txt_Notes" runat="server" CssClass="form-control" placeholder="Anotações e observações" Enabled="True" TextMode="MultiLine" Rows="3" AutoCompleteType="Disabled" autocomplete="off" />
            <asp:RegularExpressionValidator ID="rev_Notes" runat="server" ControlToValidate="txt_Notes" Display="Dynamic"
                ErrorMessage="Texto inválido (somente letras e números" CssClass="text-danger"
                ValidationExpression="^[a-zA-Zà-úÀ-Ú ]$" />
        </div>
        <%--/Observações--%>

        <%--Botões e links--%>
        <asp:Button ID="cmd_Update" runat="server" Text="Gravar" CssClass="btn btn-primary" />
        <%--/Botões e links--%>
    </div>
    <%--END Conteudo da página--%>
</asp:Content>

<%--Footer Scrpits--%>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
