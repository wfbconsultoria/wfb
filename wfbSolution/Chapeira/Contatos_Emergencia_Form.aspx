<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Contatos_Emergencia_Form.aspx.vb" Inherits="Chapeira.Contatos_Emergencia_Form" %>
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
         <%--Id--%>
        <div class="form-group col-sm-1">
            <label class="text-primary">Id</label>
            <input runat="server" id="txt_Id" type="text" maxlength="3" class="form-control" disabled="disabled" />
        </div>
        <%--Contato--%>
        <div class="form-group col-sm-11">
            <label class="text-primary">Contato</label>
            <input runat="server" id="txt_Descricao" type="text" maxlength="256" class="form-control" required="required" />
        </div>
    </div>
   
    <div class="form-row">
        <%--Telefone--%>
        <div class="form-group col-sm-12">
            <label class="text-primary">Telefone</label>
            <input runat="server" id="txt_Telefone" type="text" maxlength="128" class="form-control" />
        </div>
    </div>
    
    <div class="form-row">
        <%-- Endereço--%>
        <div class="form-group col-sm-12">
            <label class="text-primary">Endereço</label>
            <input runat="server" id="txt_Endereco" type="text" maxlength="128" class="form-control" />
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
    &nbsp;<a href="Contatos_Emergencia_Form.aspx?IdContato=NOVO" class=" btn btn-primary">Novo</a>
    &nbsp;<input id="cmd_Cancel" type="reset" value="Cancelar" class="btn btn-light" />
    &nbsp; <a href="Contatos_Emergencia_Lista.aspx" class="btn btn-link btn-light">Lista</a>
    &nbsp;<asp:LinkButton ID="cmd_Delete" runat="server" CssClass="text-danger" Font-Size="Small">Excluir</asp:LinkButton>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
