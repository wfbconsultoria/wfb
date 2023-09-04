<%@ Page Title="Enviar E-mail" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="SendEmail.aspx.vb" Inherits="BIP.SendEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <!-- Contact Form -->
    <section class="container g-py-10">
        <!-- Heading -->
        <div class="row g-mb-10">
            <div class="col-lg-12 g-mb-20">
                <h2 class="h3 g-color-black g-font-weight-700 mb-0">Envie uma mensagem</h2>
                <p class="g-font-size-14 mb-0 text-secondary">Caso tenha dúvidas ou deseje relatar algum problema envie um e-mail ao suporte</p>
            </div>
        </div>
        <!-- End Heading -->

        <!-- Body -->
        <div class="row justify-content-center">
            <div class="col-md-5">
                <!-- Nome -->
                <div class="g-mb-20">
                    <label class="g-color-gray-dark-v2 g-font-size-13">Nome</label>
                    <input runat="server" id="txt_Nome" class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v4 g-brd-primary--focus rounded-3 g-py-13 g-px-15" type="text" placeholder="Nome"/>
                </div>
                <!-- Email -->
                <div class="g-mb-20">
                    <label class="g-color-gray-dark-v2 g-font-size-13">E-mail</label>
                    <input runat="server" id="txt_Email" class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v4 g-brd-primary--focus rounded-3 g-py-13 g-px-15" type="email" placeholder="nome@dominio.com" disabled="disabled" />
                </div>
                <!-- Telefone -->
                <div class="g-mb-20">
                    <label class="g-color-gray-dark-v2 g-font-size-13">Telefone</label>
                    <input runat="server" id="txt_Telefone" class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v4 g-brd-primary--focus rounded-3 g-py-13 g-px-15" type="tel" placeholder="(00) 00000-0000"/>
                </div>
            </div>
            <div class="col-md-7">
                <!-- Assunto -->
                <div class="g-mb-20">
                    <label class="g-color-gray-dark-v2 g-font-size-13">Assunto</label>
                    <input runat="server" id="txt_Assunto" class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v4 g-brd-primary--focus rounded-3 g-py-13 g-px-15" type="text" placeholder="Assunto (30 caracteres)" maxlength="32" />
                </div>
                <!-- Mensagem -->
                <div class="g-mb-40">
                    <label class="g-color-gray-dark-v2 g-font-size-13">Mensagem</label>
                    <textarea runat="server" id="txt_Mensagem" class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v4 g-brd-primary--focus g-resize-none rounded-3 g-py-13 g-px-15" rows="10" placeholder="Digite sua mensagem aqui (1000 caracteres)" maxlength="1024"></textarea>
                </div>
                <!-- Enviar -->
                <div class="text-right">
                    <button runat="server" id="cmd_Enviar" class="btn u-btn-primary g-font-weight-600 g-font-size-13 text-uppercase rounded-3 g-py-12 g-px-35" type="submit" role="button">Enviar</button>
                </div>
            </div>
        </div>
        <!-- End Body -->
    </section>
    <!-- End Contact Form -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
