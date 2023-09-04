<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Password_Change.aspx.vb" Inherits="Chapeira_Eplanner.Password_Change" %>

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
            <input runat="server" id="txt_Id" class="form-control" disabled="disabled" />
        </div>
        <%--Colaborador--%>
        <div class="form-group col-sm-6">
            <label class="text-primary">Nome</label>
            <input runat="server" id="txt_Nome" type="text" maxlength="128" class="form-control" required="required" disabled="disabled" />
        </div>

        <%-- Email--%>
        <div class="form-group col-sm-5">
            <label class="text-primary">E-mail</label>
            <input runat="server" id="txt_Email" type="email" maxlength="128" class="form-control" required="required" disabled="disabled" />
        </div>
    </div>

     <div class="form-row">
        <%--Senha Atual--%>
        <div class="form-group col-sm-4">
            <label class="text-primary">Senha Atual</label>
            <input runat="server" id="txt_Senha_Atual" class="form-control" placeholder="senha atual" required="required" />
        </div>
        <%--Nova Senha--%>
        <div class="form-group col-sm-4">
            <label class="text-primary">Nova Senha</label>
            <input runat="server" id="txt_Senha_Nova" type="text" maxlength="128" class="form-control" required="required" placeholder="nova senha" />
        </div>

        <%-- Confirmação --%>
        <div class="form-group col-sm-4">
            <label class="text-primary">Confirmação</label>
            <input runat="server" id="txt_Senha_Confirmacao" type="text" maxlength="128" class="form-control" required="required" placeholder="confirmar senha" />
        </div>
    </div>
    <input runat="server" id="cmd_Save" type="submit" value="Gravar" class="btn btn-primary" />
     &nbsp;<input id="cmd_Cancel" type="reset" value="Cancelar" class="btn btn-light" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
