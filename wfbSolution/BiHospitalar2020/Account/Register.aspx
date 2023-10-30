<%@ Page Title="Registre-se" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master_Public.Master" CodeBehind="Register.aspx.vb" Inherits="BiHospitalar2020.Register" %>

<%@ Import Namespace="BiHospitalar2020" %>
<%@ Import Namespace="Microsoft.AspNet.Identity" %>
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
    </script>
    <%--Máscara de entrada--%>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <uc1:_Page_Header_Public runat="server" ID="_Page_Header_Public" />
       
    <div> 
        <div class="form-group"><asp:Label runat="server" ID="PageMessage" Text="! - Preencher e validar suas informações E-mail, CPF, Nascimento" CssClass=" form-control alert-info"></asp:Label></div>
        <%--EMAIL/CPF/DATA NASCIMENTO--%>
        <div class="form-row">

            <%--Email--%>
            <div class="form-group col-md-8">
                <asp:Label runat="server" AssociatedControlID="Email">E-mail</asp:Label>
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" MaxLength="200" AutoCompleteType="Disabled" ClientIDMode="Static"
                    required="required" placeholder="E-mail válido e ativo" autocomplete="off" onfocus="this.value='';">
                </asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" Display="Dynamic"
                    ErrorMessage="E-mail obrigatório">
                </asp:RequiredFieldValidator>
            </div>
            <%--/Email--%>

            <%--CPF--%>
            <div class="form-group col-md-2">
                <asp:Label runat="server" AssociatedControlID="Document">CPF</asp:Label>
                <asp:TextBox runat="server" ID="Document" CssClass="form-control" MaxLength="14" ClientIDMode="Static"
                    AutoCompleteType="Disabled" placeholder="000.000.000-00" autocomplete="off" required="required"
                    onfocus="this.value='';" onkeypress="formatar('###.###.###-##', this)">
                </asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Document" CssClass="text-danger" Display="Dynamic"
                    ErrorMessage="Requerido">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ControlToValidate="Document" CssClass="text-danger" Display="Dynamic"
                    ErrorMessage="Invalido"
                    ValidationExpression="(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)|(^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$)">
                </asp:RegularExpressionValidator>
            </div>
            <%--/CPF--%>

            <%--Data Nascimento--%>
            <div class="form-group col-md-2">
                <asp:Label runat="server" AssociatedControlID="Birth_Date">Data Nascimento</asp:Label>
                <asp:TextBox runat="server" ID="Birth_Date" CssClass="form-control" MaxLength="10" TextMode="SingleLine" ClientIDMode="Static" AutoCompleteType="Disabled"
                  required="required" placeholder="dd/mm/aaaa" autocomplete="off" onblur="validaDat(this,this.value);" onfocus="this.value='';" onkeypress="formatar('##/##/####', this)">
                </asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Birth_Date" CssClass="text-danger" Display="Dynamic"
                    ErrorMessage="Requerido">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ControlToValidate="Birth_Date" Display="Dynamic"
                    ErrorMessage="Invalido" CssClass="text-danger" ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/(19|20)\d{2,2}">
                </asp:RegularExpressionValidator>
            </div>
            <%--/Data Nascimento--%>
        </div>
        <%--/EMAIL/CPF/DATA NASCIMENTO--%>


        <%--Nome--%>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Name">Nome</asp:Label>
            <asp:TextBox runat="server" ID="Name" CssClass="form-control" MaxLength="10" TextMode="SingleLine" ClientIDMode="Static" AutoCompleteType="Disabled"
                autocomplete="off" ReadOnly="True">
            </asp:TextBox>
        </div>
        <%--/Nome--%>

        <%--SENHA/VALIDAÇÃO DA SENHA--%>
        <div class="form-row">
            <%--Senha--%>
            <div class="form-group col-md-6">
                <asp:Label runat="server" AssociatedControlID="Password">Senha</asp:Label>
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" placeholder="Senha, mínimo 4 caracteres letras e/ou numeros sem acentos" MaxLength="30" onfocus="this.value='';" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="O campo de senha é obrigatório." Display="Dynamic" />
            </div>
            <%--/Senha--%>

            <%--Confirmação Senha--%>
            <div class="form-group col-md-6">
                <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Confirmar senha</asp:Label>
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" onfocus="this.value='';" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="O campo para confirmar senha é obrigatório." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="A senha e a senha de confirmação não coincidem." />
            </div>
            <%--/Confirmação Senha--%>
        </div>
        <div class="form-group">
            
            <asp:Button runat="server" id="cmdRegister" OnClick="CreateUser_Click" Text="Verifique suas informações e registre-se" CssClass="btn btn-primary rounded"  CausesValidation="True"/>
            <asp:Button runat="server" ID="cmdValidate" OnClick="Validate_User" Text="Validar suas informações" CssClass="btn btn-secondary rounded" CausesValidation="False" />
            <input runat="server" id="cmdClear" type="reset" value="reset" Class="btn btn-light rounded" />
        </div>
    </div>
    
</asp:Content>
