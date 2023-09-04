<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Loja.aspx.vb" Inherits="Chapeira.Loja" %>
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
            <input runat="server" id="txt_Loja" type="text" maxlength="128" class="form-control" required="required" />
        </div>
    </div>

    <div class="form-row">
        <%-- Endereço--%>
        <div class="form-group col-sm-12">
            <label class="text-primary">Endereço</label>
            <input runat="server" id="txt_Loja_Endereco" type="text" maxlength="128" class="form-control" />
        </div>
    </div>

    <div class="form-row">
        <%-- Cidade--%>
        <div class="form-group col-sm-10">
            <label class="text-primary">Cidade</label>
            <input runat="server" id="txt_Loja_Cidade" type="text" maxlength="128" class="form-control" />
        </div>

        <%-- UF--%>
        <div class="form-group col-sm-2">
            <label class="text-primary">UF</label>
            <input runat="server" id="txt_Loja_UF" type="text" maxlength="2" class="form-control" />
        </div>
    </div>
    <div class="form-row">
        <%-- Telefone--%>
        <div class="form-group col-sm-4">
            <label class="text-primary">Telefone</label>
            <input runat="server" id="txt_Loja_Telefone" type="text" maxlength="64" class="form-control" />
        </div>

        <%-- Horário--%>
        <div class="form-group col-sm-8">
            <label class="text-primary">Horário de Funcionamento</label>
            <input runat="server" id="txt_Loja_Horario" type="text" maxlength="128" class="form-control" />
        </div>
    </div>

    <input runat="server" id="cmd_Save" type="submit" value="Gravar" class="btn btn-primary" />
    &nbsp;<input id="cmd_Cancel" type="reset" value="Cancelar" class="btn btn-light" />
    &nbsp; <a href="Default.aspx" class="btn btn-link btn-light">Início</a>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
