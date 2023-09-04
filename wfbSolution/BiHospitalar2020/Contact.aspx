<%@ Page Title="Contato" Language="VB" MasterPageFile="~/_Master.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.vb" Inherits="BiHospitalar2020.Contact" %>

<%@ Register Src="~/_Page_Header_Public.ascx" TagPrefix="uc1" TagName="_Page_Header_Public" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="contact-form">
        <div class="container">
            <uc1:_Page_Header_Public runat="server" ID="_Page_Header_Public" />

            <div class="row">
                <div class="col-lg-4 col-md-4 col-sm-12">
                    <div class="row">
                    </div>
                    <div class="row">
                        <address>
                            <p class="sub-txt"><i class="fas fa-phone"></i>
                                <abbr title="Phone">Telefone:</abbr>
                                +55 11 4765-0408</p>
                            <p class="sub-txt"><i class="fas fa-map-marker-alt"></i>Localização:</p>
                            <p style="margin: 0;">Alameda Santos, 1165 - sala 306</p>
                            <p class="small">Cerqueira César - São Paulo - SP</p>
                        </address>
                    </div>
                </div>
                <div class="col-lg-8 col-md-8 col-sm-12 right">
                    <div class="form-group">
                        <asp:TextBox ID="TextBox1" runat="server" placeholder="Nome" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txt_MailTo" runat="server" TextMode="Email" placeholder="E-mail" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txt_MailMessage" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control"></asp:TextBox>
                    </div>
                    <asp:Button ID="cmd_SendMail" runat="server" Text="Enviar" CssClass="btn btn-primary btn-block" />
                </div>
            </div>

        </div>
    </div>
</asp:Content>
