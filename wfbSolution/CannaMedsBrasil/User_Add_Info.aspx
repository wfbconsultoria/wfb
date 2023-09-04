<%@ Page Title="Informações do Usuario" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master.Master" CodeBehind="User_Add_Info.aspx.vb" Inherits="CannaMedsBrasil.User_Add_Info" %>

<%@ Register Src="~/_Page_Header_Private.ascx" TagPrefix="uc1" TagName="_Page_Header_Private" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    <%--Busca de CEP--%>
    <script type="text/javascript">
        function limpa_formulário_cep() {
            //Limpa valores do formulário de cep.
            document.getElementById('txt_Address').value = ("");
            document.getElementById('txt_District').value = ("");
            document.getElementById('txt_City').value = ("");
            document.getElementById('txt_UF').value = ("");
            document.getElementById('txt_City_Code').value = ("");
        }
        function meu_callback(conteudo) {
            if (!("erro" in conteudo)) {
                //Atualiza os campos com os valores.
                document.getElementById('txt_Address').value = (conteudo.logradouro);
                document.getElementById('txt_District').value = (conteudo.bairro);
                document.getElementById('txt_City').value = (conteudo.localidade);
                document.getElementById('txt_UF').value = (conteudo.uf);
                document.getElementById('txt_City_Code').value = (conteudo.ibge);
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
                    document.getElementById('txt_Address').value = "";
                    document.getElementById('txt_District').value = "";
                    document.getElementById('txt_City').value = "";
                    document.getElementById('txt_UF').value = "";
                    document.getElementById('txt_City_Code').value = "";

                    //Cria um elemento javascript.
                    var script = document.createElement('script');

                    //Sincroniza com o callback.
                    script.src = 'https://viacep.com.br/ws/' + cep + '/json/?callback=meu_callback';

                    //Insere script no documento e carrega o conteúdo.
                    document.body.appendChild(script);

                } //end if.
                else {
                    //cep é inválido.
                    limpa_formulário_cep();
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
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:_Page_Header_Private runat="server" ID="_Page_Header_Private" />
    <%--Conteudo da página--%>
    <div>
        
        <%--Email e CPF--%>
        <div class="form-row">

            <%--EMAIL--%>
            <div class="form-group col-md-6">
                <asp:Label ID="lbl_Email" runat="server" AssociatedControlID="txt_Email" Text="Email" />
                <asp:TextBox ID="txt_Email" runat="server" CssClass="form-control" placeholder="Email" ClientIDMode="Inherit" Enabled="False" />
            </div>
            <%--/EMAIL--%>

            <%--CPF--%>
            <div class="form-group col-md-6">
                <asp:Label ID="lbl_Document" runat="server" AssociatedControlID="txt_Document" Text="CPF" />
                <asp:TextBox ID="txt_Document" runat="server" CssClass="form-control" placeholder="CPF (somente números)" MaxLength="11" required="required" AutoCompleteType="Disabled" />
                <asp:RequiredFieldValidator ID="rfv_Document" runat="server" ControlToValidate="txt_Document" CssClass="text-danger" ErrorMessage="CPF obrigatório" Display="Dynamic" />
                <asp:RegularExpressionValidator ID="rev_Document" runat="server" ControlToValidate="txt_Document" Display="Dynamic"
                    ErrorMessage="CPF INVÁLIDO" CssClass="text-danger"
                    ValidationExpression="(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)|(^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$)" />
            </div>
            <%--/CPF--%>

            <%--TELEFONE--%>
            <div class="form-group col-md-6">
                <asp:Label ID="lbl_Phone" runat="server" AssociatedControlID="txt_Phone" Text="Telefone" />
                <asp:TextBox ID="txt_Phone" runat="server" CssClass="form-control" placeholder="DDD + Numero (00 99999 0000) sem traços" MaxLength="50" required="required" AutoCompleteType="Disabled" />
                <asp:RequiredFieldValidator ID="rfv_Phone" runat="server" ControlToValidate="txt_Document" CssClass="text-danger" ErrorMessage="Telefone obrigatório" Display="Dynamic" />
                <asp:RegularExpressionValidator ID="rev_Phone" runat="server" ControlToValidate="txt_Document" Display="Dynamic"
                    ErrorMessage="Telefone invalido preencher DDD + Numero 00 99999 0000 sem traços e acentos " CssClass="text-danger"
                    ValidationExpression="^[a-zA-Z0-9 ]{12,50}$" />
            </div>
            <%--/TELEFONE--%>

        </div>
        <%--/Email e CPF--%>

        <%--Nome--%>
        <div class="form-group">
            <asp:Label ID="lbl_Name" runat="server" AssociatedControlID="txt_Name" Text="Nome"></asp:Label>
            <asp:TextBox ID="txt_Name" runat="server" CssClass="form-control" placeholder="Nome (sem acentos, 5 caracteres)" Enabled="True" required="required" MaxLength="200" AutoCompleteType="Disabled" />
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
                <asp:Label ID="lbl_ZIP" runat="server" AssociatedControlID="txt_ZIP" Text="CEP" />
                <asp:TextBox ID="txt_ZIP" runat="server" CssClass="form-control" placeholder="CEP (somente numeros)"
                    Enabled="True" required="required" MaxLength="8" AutoCompleteType="Disabled"
                    onblur="pesquisacep(this.value); " ClientIDMode="Static"
                    aria-label="CEP" aria-describedby="inputGroup-sizing-default" ToolTip="Busca de endereço" />
                <asp:RequiredFieldValidator ID="rfv_ZIP" runat="server" ControlToValidate="txt_ZIP" CssClass="text-danger" ErrorMessage="CEP obrigatório" Display="None" ValidationGroup="vgp_Adrress" />
                <asp:RegularExpressionValidator ID="rev_ZIP" runat="server" ControlToValidate="txt_ZIP" Display="None" ErrorMessage="CEP inválido (somente numeros, 8 posições)" CssClass="text-danger"
                    ValidationExpression="^[0-9 ]{8}$" ValidationGroup="vgp_Adrress" />
            </div>
            <%--/CEP--%>

            <%--Endereço--%>
            <div class="form-group col-md-8">
                <asp:Label ID="lbl_Address" runat="server" AssociatedControlID="txt_Address" Text="Endereço" />
                <asp:TextBox ID="txt_Address" runat="server" CssClass="form-control" placeholder="Endereço" TextMode="SingleLine" Rows="2" MaxLength="200" ClientIDMode="Static" />
                <asp:RequiredFieldValidator ID="rfv_Address" runat="server" ControlToValidate="txt_Address" CssClass="text-danger" ErrorMessage="Endereço obrigatório" Display="None" ValidationGroup="vgp_Adrress" />
                <asp:RegularExpressionValidator ID="rev_Address" runat="server" ControlToValidate="txt_Address" Display="None"
                    ErrorMessage="Endereço inválido (Números e letras, mímino 5 caracteres" CssClass="text-danger"
                    ValidationExpression="^[a-zA-Zà-úÀ-Ú0-9 ]{5,200}$" ValidationGroup="vgp_Adrress" />
            </div>
            <%--/Endereço--%>

            <%--Número--%>
            <div class="form-group col-md-2">
                <asp:Label ID="lbl_Address_Number" runat="server" AssociatedControlID="txt_Address_Number" Text="Número"></asp:Label>
                <asp:TextBox ID="txt_Address_Number" runat="server" CssClass="form-control" placeholder="Número" TextMode="SingleLine" ClientIDMode="Static" MaxLength="10"></asp:TextBox>
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
                <asp:Label ID="lbl_Address_Complement" runat="server" AssociatedControlID="txt_Address_Complement" Text="Complemento"/>
                <asp:TextBox ID="txt_Address_Complement" runat="server" CssClass="form-control" placeholder="Complemento" MaxLength="50" />
                <asp:RegularExpressionValidator ID="rev_Address_Complement" runat="server" ControlToValidate="txt_Address_Complement" Display="None"
                    ErrorMessage="Complemento inválido (somente números ou letras, 50 posições)" CssClass="text-danger"
                    ValidationExpression="^[a-zA-Zà-úÀ-Ú0-9 ]{0,50}$" ValidationGroup="vgp_Adrress" />
            </div>
            <%--/Complemento--%>
            
            <%--Bairro--%>
            <div class="form-group col-md-6">
                <asp:Label ID="lbl_District" runat="server" AssociatedControlID="txt_District" Text="Bairro"/>
                <asp:TextBox ID="txt_District" runat="server" CssClass="form-control" placeholder="Bairro" ClientIDMode="Static" MaxLength="100" />
                <asp:RegularExpressionValidator ID="rev_District" runat="server" ControlToValidate="txt_District" Display="None"
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
                <asp:Label ID="lbl_City" runat="server" AssociatedControlID="txt_City" Text="Cidade"/>
                <asp:TextBox ID="txt_City" runat="server" CssClass="form-control" placeholder="Cidade" ClientIDMode="Static" MaxLength="100" required="required"/>
                <asp:RequiredFieldValidator ID="rfv_City" runat="server" ControlToValidate="txt_City" CssClass="text-danger" ErrorMessage="Cidade obrigatória" Display="None" ValidationGroup="vgp_Adrress" />
                <asp:RegularExpressionValidator ID="rev_City" runat="server" ControlToValidate="txt_City" Display="None"
                    ErrorMessage="Cidade inválida (somente letras, 100 posições)" CssClass="text-danger"
                    ValidationExpression="^[a-zA-Zà-úÀ-Ú ]{0,100}$" ValidationGroup="vgp_Adrress" />
            </div>
            <%--/Cidade--%>
            
            <%--CodIBGE--%>
            <div class="form-group col-md-2">
                <asp:Label ID="lbl_City_Code" runat="server" AssociatedControlID="txt_City_Code" Text="IBGE"></asp:Label>
                <asp:TextBox ID="txt_City_Code" runat="server" CssClass="form-control" placeholder="IBGE" ClientIDMode="Static" Enabled="False"></asp:TextBox>
            </div>
            <%--/CodIBGE--%>

            <%--UF--%>
            <div class="form-group col-md-2">
                <asp:Label ID="lbl_UF" runat="server" AssociatedControlID="txt_UF" Text="UF"></asp:Label>
                <asp:TextBox ID="txt_UF" runat="server" CssClass="form-control" placeholder="UF" MaxLength="2" required="required" ClientIDMode="Static"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_UF" runat="server" ControlToValidate="txt_UF" CssClass="text-danger" ErrorMessage="UF obrigatória" Display="None" ValidationGroup="vgp_Adrress" />
                <asp:RegularExpressionValidator ID="rev_UF" runat="server" ControlToValidate="txt_UF" Display="None"
                    ErrorMessage="UF inválida (somente letras, 2 posições)" CssClass="text-danger"
                    ValidationExpression="^[A-Z]{2}$" ValidationGroup="vgp_Adrress" />
            </div>
            <%--/UF--%>
        
        </div>
        <%--/Cidade/CodIBGE/UF--%>

        <%--Validação CEP/Endereço/Número--%>
        <div class="form-group">
            <asp:ValidationSummary ID="vls_Adrress" runat="server" ValidationGroup="vgp_Adrress" CssClass="text-danger"/>
        </div>
        <%--/Validação CEP/Endereço/Número--%>

        <%--Observações--%>
        <div class="form-group">
            <asp:Label ID="lbl_Notes" runat="server" AssociatedControlID="txt_Notes" Text="Anotações"></asp:Label>
            <asp:TextBox ID="txt_Notes" runat="server" CssClass="form-control" placeholder="Anotações e observações" Enabled="True" AutoCompleteType="Disabled" TextMode="MultiLine" Rows="3" />
            <asp:RegularExpressionValidator ID="rev_Notes" runat="server" ControlToValidate="txt_Notes" Display="Dynamic"
                ErrorMessage="Texto inválido (somente letras e números" CssClass="text-danger"
                ValidationExpression="^[a-zA-Zà-úÀ-Ú ]$" />
        </div>
        <%--/Observações--%>
        
        <%--Botões e links--%>
        <button type="submit" class="btn btn-primary">Atualizar</button>
        <%--/Botões e links--%>

    </div>
    <%--END Conteudo da página--%>
</asp:Content>

<%--Footer Scrpits--%>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
