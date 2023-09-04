<%@ Page Title="Novo Usuário" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="User_Register.aspx.vb" Inherits="BIP.User_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <asp:SqlDataSource runat="server" ID="dts_User_Profile_Id" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [Id], [User_Profile] FROM [tb_Users_Profiles] ORDER BY [Id]"></asp:SqlDataSource>
    <!-- Contact Form -->
    <section class="container g-py-10">
        <!-- Heading -->
        <div class="row g-mb-10">
            <div class="col-lg-12 g-mb-20">
                <h2 class="h3 g-color-black g-font-weight-700 mb-0">Novo Usuário</h2>
                <p class="g-font-size-14 mb-0 text-secondary">Incluir novo usuário no <%:ConfigurationManager.AppSettings("App.Name") %></p>
            </div>
        </div>
        <!-- End Heading -->

        <!-- Body -->
        <div class="row justify-content-center">
            <div class="col-md-5">
                <!-- Nome -->
                <div class="g-mb-20">
                    <label class="g-color-gray-dark-v2 g-font-size-13">Nome</label>
                    <input runat="server" id="txt_Name" class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v4 g-brd-primary--focus rounded-3 g-py-13 g-px-15" type="text" placeholder="Nome" maxlength="200" />
                </div>
                <!-- Email -->
                <div class="g-mb-20">
                    <label class="g-color-gray-dark-v2 g-font-size-13">E-mail</label>
                    <input runat="server" id="txt_Email" class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v4 g-brd-primary--focus rounded-3 g-py-13 g-px-15" type="email" placeholder="nome@dominio.com" maxlength="200" />
                </div>
                <!-- Phone -->
                <div class="g-mb-20">
                    <label class="g-color-gray-dark-v2 g-font-size-13">Telefone</label>
                    <input runat="server" id="txt_Phone" class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v4 g-brd-primary--focus rounded-3 g-py-13 g-px-15" type="tel" placeholder="(00) 00000-0000" maxlength="50" />
                </div>
            </div>
            <div class="col-md-7">
                <!-- User_Profile_Id  -->
                <div class="g-mb-20">
                    <label class="g-color-gray-dark-v2 g-font-size-13">Perfil</label>
                    <asp:DropDownList runat="server" ID="cmb_User_Profile_Id" CssClass="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v4 g-brd-primary--focus rounded-3 g-py-13 g-px-15" DataSourceID="dts_User_Profile_Id" DataTextField="User_Profile" DataValueField="Id"></asp:DropDownList>
                </div>
                <!-- Notes -->
                <div class="g-mb-40">
                    <label class="g-color-gray-dark-v2 g-font-size-13">Observações</label>
                    <textarea runat="server" id="txt_Notes" class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v4 g-brd-primary--focus g-resize-none rounded-3 g-py-13 g-px-15" rows="6" placeholder="Digite sua mensagem aqui (1000 caracteres)" maxlength="1024"></textarea>
                </div>
                <!-- Salvar -->
                <div class="text-right">
                    <button runat="server" id="cmd_Salvar" class="btn u-btn-primary g-font-weight-600 g-font-size-13 text-uppercase rounded-3 g-py-12 g-px-35" type="submit" role="button">Salvar</button>
                </div>
            </div>
        </div>
        <!-- End Body -->
    </section>
    <!-- End Contact Form -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
                    