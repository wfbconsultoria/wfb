<%@ Page Title="Cadastrar Procedimento" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RegisterProcedureDatabase.aspx.cs" Inherits="RegisterProcedureDatabase" %>

<%--Referencias com css--%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head_Content" runat="Server">
</asp:Content>

<%--Conteudo da página--%>
<asp:Content ID="Content2" ContentPlaceHolderID="Body_Content" runat="Server">
    <div class="container mt-5">
        <!-- Titulo -->
        <div class="row pt-2 text-center">
            <div class="col-md-12">
                <h3><%:Page.Title%></h3>
                <span class="text-muted">Todos os campos com <span class="text-danger">*</span> são obrigatórios</span>
            </div>
        </div>
        <!--Nome-->
        <div class="row mt-3">
            <div class="col-md-12">
                <label>Nome: </label>
                <span class="text-danger">*</span>
                <input type="text" id="txtName" runat="server" class="form-control" required="required" placeholder="Nome do procedimento" maxlength="50" />
            </div>
        </div>
        <!--Banco-->
        <div class="row">
            <div class="col-md-8">
                <label>Banco de dados: </label>
                <span class="text-danger">*</span>
                <input type="text" id="txtBase" runat="server" class="form-control" required="required" placeholder="Nome do banco de dados" maxlength="50" />
            </div>

            <!--Tipo-->
            <div class="col-md-4">
                <label>Tipo de banco de dados: </label>
                <span class="text-danger">*</span>
                <select id="selType" runat="server" class="form-control input-group-text bg-white" required="required">
                </select>
            </div>
        </div>

        <!-- Servidor -->
        <div class="row">
            <div class="col-md-4">
                <label>Servidor: </label>
                <span class="text-danger">*</span>
                <input type="text" id="txtServer" runat="server" class="form-control" required="required" placeholder="Servidor onde o banco esta" maxlength="50" />
            </div>
            <!-- Usuário -->
            <div class="col-md-4">
                <label>Usuário: </label>
                <span class="text-danger">*</span>
                <input type="text" id="txtUser" runat="server" class="form-control" required="required" placeholder="Usuário para login no banco" maxlength="50" />
            </div>
            <!-- Senha -->
            <div class="col-md-4">
                <label>Senha: </label>
                <span class="text-danger">*</span>
                <input type="password" id="txtPassword" runat="server" class="form-control" required="required" placeholder="Senha para login no banco" maxlength="50" />
            </div>
        </div>


        <!--Email do responsavel-->
        <div class="row">
            <div class="col-md-12 mt-2">
                <label>E-mail do responsável: </label>
                <span class="text-danger">*</span>
                <input type="email" id="txtEmail" runat="server" class="form-control" required="required" placeholder="Responsável caso houver alguma falha" maxlength="100" />
            </div>
        </div>

        <!--Script-->
        <div class="row">
            <div class="col-md-12 mt-2">
                <label>Script do procedimento: </label>
                <span class="text-danger">*</span>
                <textarea id="txtScript" runat="server" class="form-control" placeholder="Insira o script para executar o procedimento" required="required" rows="3"></textarea>
            </div>
        </div>

        <!-- Botões -->
        <div class="row">
            <div class="col-md-12">
                <!-- Cadastrar -->
                <input type="submit" id="btnRegister" runat="server" class="btn btn-sm btn-primary" title="clique para se cadastrar roteiro de backup" onserverclick="btnRegister_Click" />
                <!-- Voltar -->
                <a id="btnReturn" runat="server" class="btn btn-sm btn-secondary text-light" title="clique para voltar" onserverclick="btnReturn_Click"></a>
                <!-- Testar conexão -->
                <div class="float-right">
                    <input type="submit" id="btnTestConnection" runat="server" class="btn btn-sm btn-primary" title="clique para testar as configurações" onserverclick="btnTestConnection_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<%--Referencias com js--%>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer_Content" runat="Server">
</asp:Content>

