<%@ Page Title="Alterar Senha" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="User_Change_Password.aspx.vb" Inherits="BiPh.User_Change_Password" %>
<%@ Register Src="~/Page_Header.ascx" TagPrefix="uc1" TagName="Page_Header" %>
<%@ Register Src="~/Page_Footer.ascx" TagPrefix="uc1" TagName="Page_Footer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head_Content" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body_Content" runat="server">
    <!--Cabeçalho da página -->
    <uc1:Page_Header runat="server" ID="Page_Header" />
    <!-- Body -->
        <div class="row justify-content-left">
            <div class="col-md-5">
                <!-- Senha Atual -->
                <div class="form-group">
                    <label>Senha Atual</label>
                    <input runat="server" id="txt_Password" class="form-control" type="text" placeholder="senha atual" required="required"/>
                </div>
                <!-- Nova Senha -->
                 <div class="form-group">
                    <label>Nova Senha</label>
                    <input runat="server" id="txt_New_Password" class="form-control" type="text" placeholder="nova senha (sem acentos)" required="required"/>
                </div>
                <!-- Confirmar Senha -->
                 <div class="form-group">
                    <label>Confirmar Senha</label>
                    <input runat="server" id="txt_Confirm_Password" class="form-control" type="text" placeholder="confirmar senha" required="required"/>
                </div>
                <!-- Salvar -->
                <div class="text-right">
                    <button runat="server" id="cmd_Salvar" class="btn btn-success g" type="button" role="button">Salvar</button>
                </div>
            </div>
           
        </div>
        <!-- End Body -->

    <uc1:Page_Footer runat="server" ID="Page_Footer" />
    <!--Datasources -->
    
</asp:Content>
