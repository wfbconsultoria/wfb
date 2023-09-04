<%@ Page Title="Alterar Senha" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="User_Change_Password.aspx.vb" Inherits="BIP.User_Change_Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <!-- Alterar Senha -->
    <section class="container g-py-10">
        <!-- Heading -->
        <div class="row g-mb-10">
            <div class="col-lg-12 g-mb-20">
                <h2 class="h3 g-color-black g-font-weight-700 mb-0">Alterar Senha</h2>
                <p class="g-font-size-14 mb-0 text-secondary">Recomendamos que mude sua senha a cada 30 dias</p>
            </div>
        </div>
        <!-- End Heading -->

        <!-- Body -->
        <div class="row justify-content-left">
            <div class="col-md-5">
                <!-- Senha Atual -->
                <div class="g-mb-20">
                    <label class="g-color-gray-dark-v2 g-font-size-13">Senha Atual</label>
                    <input runat="server" id="txt_Password" class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v4 g-brd-primary--focus rounded-3 g-py-13 g-px-15" type="text" placeholder="senha atual"/>
                </div>
                <!-- Nova Senha -->
                <div class="g-mb-20">
                    <label class="g-color-gray-dark-v2 g-font-size-13">Nova Senha</label>
                    <input runat="server" id="txt_New_Password" class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v4 g-brd-primary--focus rounded-3 g-py-13 g-px-15" type="text" placeholder="nova senha (sem acentos)"/>
                </div>
                <!-- Confirmar Senha -->
                <div class="g-mb-20">
                    <label class="g-color-gray-dark-v2 g-font-size-13">Confirmar Senha</label>
                    <input runat="server" id="txt_Confirm_Password" class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v4 g-brd-primary--focus rounded-3 g-py-13 g-px-15" type="text" placeholder="confirmar senha"/>
                </div>
                <!-- Salvar -->
                <div class="text-right">
                    <button runat="server" id="cmd_Salvar" class="btn u-btn-primary g-font-weight-600 g-font-size-13 text-uppercase rounded-3 g-py-12 g-px-35" type="submit" role="button">Salvar</button>
                </div>
            </div>
           
        </div>
        <!-- End Body -->
    </section>
    <!-- End Alterar Senha -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
