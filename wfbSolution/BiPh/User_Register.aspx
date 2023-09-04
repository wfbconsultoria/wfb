<%@ Page Title="Novo Usuário" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="User_Register.aspx.vb" Inherits="BiPh.User_Register" %>

<%@ Register Src="~/Page_Header.ascx" TagPrefix="uc1" TagName="Page_Header" %>
<%@ Register Src="~/Page_Footer.ascx" TagPrefix="uc1" TagName="Page_Footer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head_Content" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body_Content" runat="server">
    <!--Cabeçalho da página -->
    <uc1:Page_Header runat="server" ID="Page_Header" />
    <!-- Body -->
    <div class="row justify-content-center">
        <div class="col-md-5">
            <!-- Nome -->
            <div class="form-group">
                <label>Nome</label>
                <input runat="server" id="txt_Name" class="form-control" type="text" placeholder="Nome" maxlength="200" />
            </div>
            <!-- Email -->
            <div class="form-group">
                <label>E-mail</label>
                <input runat="server" id="txt_Email" class="form-control" type="email" placeholder="nome@dominio.com" maxlength="200" />
            </div>
            <!-- Phone -->
            <div class="form-group">
                <label>Telefone</label>
                <input runat="server" id="txt_Phone" class="form-control" type="tel" placeholder="(00) 00000-0000" maxlength="50" />
            </div>
        </div>
        <div class="col-md-7">
            <!-- User_Profile_Id  -->
            <div class="form-group">
                <label>Perfil</label>
                <asp:DropDownList runat="server" ID="cmb_User_Profile_Id" CssClass="form-control" DataSourceID="dts_User_Profile_Id" DataTextField="User_Profile" DataValueField="Id"></asp:DropDownList>
            </div>
            <!-- Notes -->
            <div class="form-group">
                <label>Observações</label>
                <textarea runat="server" id="txt_Notes" class="form-control" rows="6" placeholder="Digite sua mensagem aqui (1000 caracteres)" maxlength="1024"></textarea>
            </div>
            <!-- Salvar -->
            <div class="text-right">
                <button runat="server" id="cmd_Salvar" class="btn btn-success" type="button" role="button">Salvar</button>
                &nbsp;<input id="cmd_Cancel" type="reset" value="Cancelar" class="btn btn-light" />
                &nbsp; <a runat="server" id="lnk_Doctors" href="Users.aspx" class="btn btn-link btn-light">Usuários</a>
            </div>
        </div>
    </div>
    <!-- End Body -->

    <uc1:Page_Footer runat="server" ID="Page_Footer" />
    <!--Datasources -->
    <asp:SqlDataSource runat="server" ID="dts_User_Profile_Id" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [Id], [User_Profile] FROM [tb_Users_Profiles] ORDER BY [Id]"></asp:SqlDataSource>
</asp:Content>
