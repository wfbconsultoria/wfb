<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="RegisterReport.aspx.vb" Inherits="RegisterReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container">
        <div class="row col-md-12 text-muted">
            <h4><strong>Cadastro de Relatório</strong></h4>
        </div>
    </div>
    <div class="container">
        <div class="form-group">
            <!--Nome-->
            <div class="row" style="margin-bottom: 1%;">
                <div class="col-sm-2">
                    <asp:Label ID="lbl_nome" runat="server" Text="Nome do Relátorio" AssociatedControlID="txt_nome" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="txt_nome" runat="server" CssClass="form-control" CausesValidation="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_nome" runat="server" ErrorMessage="Preencha o campo" ControlToValidate="txt_nome" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>
            <!--/Nome-->

            <!--Descrição-->
            <div class="row" style="margin-bottom: 1%;">
                <div class="col-sm-2">
                    <asp:Label ID="lbl_descricao" runat="server" Text="Descrição do Relatório" AssociatedControlID="txt_descricao" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="txt_descricao" runat="server" CssClass="form-control" CausesValidation="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_descricao" runat="server" ErrorMessage="Preencha o campo" ControlToValidate="txt_descricao" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>
            <!--/Descrição-->

            <!--link-->
            <div class="row">
                <div class="col-sm-2" style="margin-bottom: 1%;">
                    <asp:Label ID="lbl_link" runat="server" Text="Link do Relatório" AssociatedControlID="txt_link" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="txt_link" runat="server" CssClass="form-control" CausesValidation="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_link" runat="server" ErrorMessage="Preencha o campo" ControlToValidate="txt_link" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>
            <br />
            <!--/link-->

            <!--btn incluir-->
            <div class="row">
                <asp:Button ID="btn_incluir" runat="server" Text="Incluir" CssClass="btn btn-sm btn-default" />
                <a id="btn_voltar" runat="server" class="btn btn-sm btn-danger" href="Report.aspx" style="margin-top: -0.5px">Voltar</a>
            </div>

            <!--btn incluir-->

        </div>
    </div>
</asp:Content>

