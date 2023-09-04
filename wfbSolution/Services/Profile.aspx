<%@ Page Title="Perfil" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Models_Profile" %>

<%--Referencias com css--%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head_Content" runat="Server">
</asp:Content>

<%--Conteudo da página--%>
<asp:Content ID="Content2" ContentPlaceHolderID="Body_Content" runat="Server">
    <div class="container">
        <!-- Título -->
        <div class="row">
            <div class="col-md-12 text-center">
                <h2 class="pt-2"><%: Page.Title %></h2>
                <p>Todos os campos com <span class="text-danger">*</span> são obrigatórios</p>
            </div>
        </div>

        <div class="row">
            <!--Nome-->
            <div class="col-md-4 mt-4">
                <label>Nome: </label>
                <span class="text-danger">*</span>
                <input type="text" id="txtName" runat="server" class="form-control" required="required" placeholder="Insira seu nome" maxlength="20" />
            </div>
            <!--Sobrenome-->
            <div class="col-md-8 mt-4">
                <label>Sobrenome: </label>
                <span class="text-danger">*</span>
                <input type="text" id="txtLastname" runat="server" class="form-control" required="required" placeholder="Insira seu sobrenome" maxlength="70" />
            </div>
        </div>

        <div class="row">
            <!-- Email -->
            <div class="col-md-6 mt-2">
                <label>E-mail: </label>
                <span class="text-danger">*</span>
                <input type="email" id="txtEmail" runat="server" class="form-control" required="required" placeholder="Insira seu e-mail" maxlength="70" />
            </div>
            <!-- Celular -->
            <div class="col-md-6 mt-2">
                <label>Celular: </label>
                <span class="text-danger">*</span>
                <!-- Select / Caixa de texto -->
                <div class="input-group">
                    <div class="input-group-prepend">
                        <select id="selDdd" runat="server" class="form-control input-group-text bg-white" required="required" style="max-width: 80px;">
                        </select>
                    </div>
                    <input type="number" id="txtCellphone" runat="server" class="form-control" required="required" placeholder="Insira seu celular" min="900000000" max="999999999" />
                </div>
            </div>
        </div>

        <div class="row">
            <!-- CEP -->
            <div class="col-md-8">
                <label>CEP: </label>
                <input type="number" id="txtCEP" runat="server" class="form-control" placeholder="Insira seu CEP" max="99999999" onblur="pesquisacep(this.value);" />
            </div>
            <!-- Número -->
            <div class="col-md-2">
                <label>Número: </label>
                <input type="text" id="txtNumber" runat="server" class="form-control" placeholder="Ex: 42 B" maxlength="5" />
            </div>
            <!-- Uf -->
            <div class="col-md-2">
                <label>UF: </label>
                <input type="text" id="txtUf" runat="server" class="form-control" placeholder="Ex: SP" maxlength="2" />
            </div>
        </div>

        <div class="row">
            <!-- Cidade -->
            <div class="col-md-8">
                <label>Cidade: </label>
                <input type="text" id="txtCity" runat="server" class="form-control" placeholder="Insira sua cidade" maxlength="70"/>
            </div>
            <!-- Bairro -->
            <div class="col-md-4">
                <label>Bairro: </label>
                <input type="text" id="txtNeighborhood" runat="server" class="form-control" placeholder="Insira seu bairro" maxlength="70" />
            </div>
        </div>

        <div class="row">
            <!-- Endereço -->
            <div class="col-md-12">
                <label>Endereço: </label>
                <input type="text" id="txtAddress" runat="server" class="form-control" placeholder="Insira seu endereço" maxlength="70" />
            </div>
        </div>

        <div class="row">
            <!-- Complemento -->
            <div class="col-md-12">
                <label>Complemento: </label>
                <input type="text" id="txtComplement" runat="server" class="form-control" placeholder="Insira um complemento" maxlength="70" />
            </div>
        </div>

        <fieldset class="form-control mb-3 bg-transparent">
            <legend class="w-auto">Para trocar senha </legend>

            <!-- senha atual -->
            <div class="row">
                <div class="col-md-12">
                    <label for="txtPassword">Senha atual:</label>
                    <input type="password" id="txtPassword" runat="server" class="form-control" placeholder="Digite sua senha atual" maxlength="100" />
                </div>
            </div>

            <div class="row">
                <!-- Nova senha -->
                <div class="col-md-6">
                    <label for="txtNewPassword">Nova Senha</label>
                    <input type="password" id="txtNewPassword" runat="server" class="form-control" placeholder="Digite sua nova senha" maxlength="100" />
                </div>
                <!-- Confirmar nova senha -->
                <div class="col-md-6">
                    <label for="txtConfirmPassword">Confirmar Senha</label>
                    <input type="password" id="txtConfirmPassword" runat="server" class="form-control" placeholder="Confirme sua nova senha" onblur="validationConfirmPassword('Body_Content_txtNewPassword','Body_Content_txtConfirmPassword')" maxlength="100" />
                </div>
            </div>

        </fieldset>

        <!-- Botões -->
        <div class="row">
            <div class="col-md-12">
                <input type="submit" id="btnUpdate" runat="server" class="btn btn-sm btn-primary" title="clique para atualizar seus dados" onserverclick="btnUpdate_Click"/>
                <a id="btnReturn" runat="server" class="btn btn-sm btn-secondary text-light" title="clique para voltar" onserverclick="btnReturn_Click"></a>
            </div>
        </div>
    </div>
</asp:Content>

<%--Referencias com js--%>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer_Content" runat="Server">

    <!-- Buscar cep -->
    <script src="js/Custom/buscarCep/BuscarCep-BodyContent.js"></script>
</asp:Content>

