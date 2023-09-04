<%@ Page Title="Enviar Mensagem" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Support_SendEmail.aspx.vb" Inherits="BiPh.Support_SendEmail" %>

<%@ Register Src="~/Page_Header.ascx" TagPrefix="uc1" TagName="Page_Header" %>
<%@ Register Src="~/Page_Footer.ascx" TagPrefix="uc1" TagName="Page_Footer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head_Content" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body_Content" runat="server">
    <uc1:Page_Header runat="server" ID="Page_Header" />
    <div>
        <div class="form-row">
            <!-- Nome -->
            <div class="form-group col-md-6">
                <label>Nome</label>
                <input runat="server" id="txt_Nome" class="form-control" type="text" placeholder="Seu nome" />
            </div>
            <!-- Email -->
            <div class="form-group col-md-4">
                <label>E-mail</label>
                <input runat="server" id="txt_Email" class="form-control" type="email" placeholder="nome@dominio.com" />
            </div>
            <!-- Telefone -->
            <div class="form-group col-md-2">
                <label>Telefone</label>
                <input runat="server" id="txt_Telefone" class="form-control" type="tel" placeholder="(00) 00000-0000" />
            </div>
        </div>

        <!-- Assunto -->
        <div class="form-row">
            <div class="form-group col-md-12">
                <label>Assunto</label>
                <input runat="server" id="txt_Assunto" class="form-control" type="text" placeholder="Assunto (30 caracteres)" maxlength="32" />
            </div>
        </div>
        <!-- Mensagem -->
        <div class="form-row">
            <div class="form-group col-md-12">
                <label>Mensagem</label>
                <textarea runat="server" id="txt_Mensagem" class="form-control" rows="10" placeholder="Digite sua mensagem aqui (1000 caracteres)" maxlength="1024"></textarea>
            </div>
        </div>
        <!-- Enviar -->
        <div class="text-right">
            <button runat="server" id="cmd_Enviar" class="btn btn-success" type="button" role="button">Enviar</button>
        </div>
    </div>
    <uc1:Page_Footer runat="server" ID="Page_Footer" />
</asp:Content>
