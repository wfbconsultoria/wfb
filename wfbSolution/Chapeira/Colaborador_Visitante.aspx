<%@ Page Title="Visitante" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Colaborador_Visitante.aspx.vb" Inherits="Chapeira.Colaborador_Visitante" %>

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

        <div class="form-group col-sm-10">
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
    </div>
     
    <%--Empresa--%>
    <div class="form-row">
        <div class="form-group col-sm-12">
            <label class="text-primary">Empresa</label>
            <input runat="server" id="txt_Empresa" maxlength="128" class="form-control" placeholder="Empresa (opcional)" />
        </div>
    </div>

    <%-- Email/Telefone/Funcao--%>
    <div class="form-row">
        <%-- Email--%>
        <div class="form-group col-sm-6">
            <label class="text-primary">E-mail</label>
            <input runat="server" id="txt_Email" type="email" maxlength="128" class="form-control" placeholder="Email" />
        </div>
        <%--Telefone--%>
        <div class="form-group col-sm-6">
            <label class="text-primary">Telefone</label>
            <input runat="server" id="txt_Telefone" type="text" maxlength="128" class="form-control" placeholder="Telefone" />
        </div>
    </div>

    <%--Funcao--%>
    <div class="form-row">
        <div class="form-group col-sm-10">
            <label class="text-primary">Colaborador Visitado</label>
            <input runat="server" id="txt_Funcao" type="text" maxlength="128" class="form-control" placeholder="Colaborador Visitado" />
        </div>
         <%--data visita--%>
        <div class="form-group col-sm-2">
            <label class="text-primary">Data Visita</label>
            <input runat="server" id="txt_Admissao_Data" type="date" maxlength="2" class="form-control" />
        </div>
    </div>

    <div class="form-row">
        <%-- Observacoes--%>
        <div class="form-group col-sm-12">
            <label class="text-primary">Motivo da Visita</label>
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
    &nbsp;<a href="Colaborador_Visitante.aspx?IdColaborador=NOVO" class=" btn btn-primary">Novo</a>
    &nbsp;<input id="cmd_Cancel" type="reset" value="Cancelar" class="btn btn-light" />
    &nbsp; <a href="Colaboradores_Visitantes.aspx" class="btn btn-link btn-light">Lista</a>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
