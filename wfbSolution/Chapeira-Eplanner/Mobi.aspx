<%@ Page Title="Mobi" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Mobi.aspx.vb" Inherits="Chapeira_Eplanner.Mobi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <h4 class="text-secondary text-uppercase"><%:Page.Title %></h4>

    <div class="form-row">
        <%-- Sigla--%>
        <div class="form-group col-sm-2">
            <label class="text-primary">Sigla</label>
            <input runat="server" id="txt_Loja_Sigla" type="text" maxlength="8" class="form-control" required="required" disabled="disabled" />
        </div>

        <%-- Loja--%>
        <div class="form-group col-sm-10">
            <label class="text-primary">Loja</label>
            <input runat="server" id="txt_Loja" type="text" maxlength="128" class="form-control" required="required" disabled="disabled" />
        </div>
    </div>

    <div class="form-row">
        <%--Colaborador--%>
        <div class="form-group col-sm-1">
            <label class="text-primary">Id</label>
            <input runat="server" id="txt_Id" class="form-control" disabled="disabled" />
        </div>

        <div class="form-group col-sm-9">
            <label class="text-primary">Nome</label>
            <input runat="server" id="txt_Nome" type="text" maxlength="128" class="form-control" required="required" />
        </div>

        <div class="form-group col-sm-1">
            <label class="text-primary">Ativo</label>
            <select runat="server" id="txt_Ativo" class="form-control">
                <option value="Sim">Sim</option>
                <option value="Nao">Não</option>
            </select>
        </div>

        <div class="form-group col-sm-1">
            <label class="text-primary">Admin</label>
            <select runat="server" id="txt_Administrador" class="form-control">
                <option value="Sim">Sim</option>
                <option value="Nao">Não</option>
            </select>
        </div>
    </div>

    <div class="form-row">
        <%-- Universo--%>
        <div class="form-group col-sm-10">
            <label class="text-primary">Universo</label>
            <asp:DropDownList ID="cmb_Id_Universo" runat="server" class="form-control" DataSourceID="dtsUniversos" DataTextField="Universo" DataValueField="Id"></asp:DropDownList>
        </div>
        <%--Brigadista--%>
        <div class="form-group col-sm-2">
            <label class="text-primary">Brigadista</label>
            <select runat="server" id="cmb_Brigadista" class="form-control">
                <option value="Nao">Não</option>
                <option value="Sim">Sim</option>
            </select>
        </div>
    </div>
    <div class="form-row">
        <%--Formação--%>
        <div class="form-group col-sm-6">
            <label class="text-primary">Formação</label>
            <input runat="server" id="txt_Formacao_Data" type="date" maxlength="2" class="form-control" />
        </div>
        <%--Admissão--%>
        <div class="form-group col-sm-6">
            <label class="text-primary">Admissão</label>
            <input runat="server" id="txt_Admissao_Data" type="date" maxlength="2" class="form-control" />
        </div>
    </div>
    <%-- Email/Telefone/Funcao--%>
    <div class="form-row">

        <%-- Email--%>
        <div class="form-group col-sm-6">
            <label class="text-primary">E-mail</label>
            <input runat="server" id="txt_Email" type="email" maxlength="128" class="form-control" required="required" placeholder="IDENTIFICADOR EXCLUSIVO" />
        </div>
        <%--Telefone--%>
        <div class="form-group col-sm-3">
            <label class="text-primary">Telefone</label>
            <input runat="server" id="txt_Telefone" type="text" maxlength="128" class="form-control" />
        </div>
        <%--Funcao--%>
        <div class="form-group col-sm-3">
            <label class="text-primary">Função</label>
            <input runat="server" id="txt_Funcao" type="text" maxlength="128" class="form-control" />
        </div>
    </div>
    <div class="form-row">
        <%-- Endereço--%>
        <div class="form-group col-sm-12">
            <label class="text-primary">Endereço</label>
            <input runat="server" id="txt_Endereco" type="text" maxlength="128" class="form-control" />
        </div>
    </div>
    <div class="form-row">
        <%-- Cidade--%>
        <div class="form-group col-sm-10">
            <label class="text-primary">Cidade</label>
            <input runat="server" id="txt_Cidade" type="text" maxlength="128" class="form-control" />
        </div>
        <%-- UF--%>
        <div class="form-group col-sm-2">
            <label class="text-primary">UF</label>
            <input runat="server" id="txt_UF" type="text" maxlength="2" class="form-control" />
        </div>
    </div>
    <div class="form-row">
        <%-- Observacoes--%>
        <div class="form-group col-sm-12">
            <label class="text-primary">Observações</label>
            <textarea runat="server" id="txt_Observacao" type="text" maxlength="2048" rows="2" class="form-control" />
        </div>
    </div>
    <%-- LOG--%>
    <div class="form-row">
        <%-- Incluido por--%>
        <div class="form-group col-sm-4">
            <label class="text-muted">Incluido Por</label>
            <input runat="server" id="Insert_User" type="text" class="form-control text-muted" disabled="disabled" />
        </div>
        <%-- Incluido Em--%>
        <div class="form-group col-sm-2">
            <label class="text-muted">Data Inclusão</label>
            <input runat="server" id="Insert_Date" type="text" class="form-control text-muted" disabled="disabled" />
        </div>
        <%-- Atualizado por--%>
        <div class="form-group col-sm-4">
            <label class="text-muted">Atualizado Por</label>
            <input runat="server" id="Update_User" type="text" class="form-control text-muted" disabled="disabled" />
        </div>
        <%-- Incluido Em--%>
        <div class="form-group col-sm-2">
            <label class="text-muted">Data Inclusão</label>
            <input runat="server" id="Update_Date" type="text" class="form-control text-muted" disabled="disabled" />
        </div>
    </div>

    <%-- botoes de de comando--%>
    <input runat="server" id="cmd_Save" type="submit" value="Gravar" class="btn btn-primary" />
    &nbsp;<a href="Colaborador.aspx?IdColaborador=NOVO" class=" btn btn-primary">Novo</a>
    &nbsp;<input id="cmd_Cancel" type="reset" value="Cancelar" class="btn btn-light" />
    &nbsp; <a href="Colaboradores.aspx" class="btn btn-link btn-light">Lista</a>

    <asp:SqlDataSource ID="dtsUniversos" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [tb_Universos] ORDER BY [Universo]"></asp:SqlDataSource>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
