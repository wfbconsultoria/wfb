<%@ Page Title="Editar download" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="DownloadEdit.aspx.vb" Inherits="DownloadEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <div class="container">
        <!-- Titulo da página -->
        <div class="row" style="margin-bottom: 1%;">
            <div class="col-md-12 text-muted">
                <h4><strong>Cadastrar Download</strong></h4>
            </div>
        </div>
        <div class="form-group">
            <!-- Título -->
            <div class="row" style="margin-bottom: 1%;">
                <div class="col-sm-2">
                    <asp:Label ID="lbl_titulo" runat="server" Text="Nome do download" AssociatedControlID="txt_titulo" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="txt_titulo" runat="server" CssClass="form-control" CausesValidation="true" placeholder="Insira o nome do download"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_titulo" runat="server" ErrorMessage="Preencha o campo" ControlToValidate="txt_titulo" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>

            <!-- Link -->
            <div class="row" style="margin-bottom: 1%;">
                <div class="col-sm-2">
                    <asp:Label ID="lbl_link" runat="server" Text="Link do download" AssociatedControlID="txt_link" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="txt_link" runat="server" CssClass="form-control" CausesValidation="true" placeholder="Insira o caminho do download"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_link" runat="server" ErrorMessage="Preencha o campo" ControlToValidate="txt_link" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>

            <!-- Descrição -->
            <div class="row">
                <div class="col-sm-2" style="margin-bottom: 1%;">
                    <asp:Label ID="lbl_descricao" runat="server" Text="Descrição do download" AssociatedControlID="txt_descricao" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="txt_descricao" runat="server" CssClass="form-control" CausesValidation="true" Rows="3" TextMode="MultiLine" style="resize: none;" placeholder="Insira uma descrição para seu download"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_descricao" runat="server" ErrorMessage="Preencha o campo" ControlToValidate="txt_descricao" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <label class="text-danger">OBS: O caminho do download(Link) deve ser o caminho de um arquivo com sua extensão dento da pasta Documentos do site, como "Documentos/helper.jpg"</label>
                </div>
            </div>
            <br />

            <!--btn incluir-->
            <div class="row">
                <div class="col-sm-12">
                    <asp:Button ID="btn_atualizar" runat="server" Text="Atualizar" CssClass="btn btn-sm btn-default" />
                    <a id="btn_voltar" runat="server" class="btn btn-sm btn-danger" href="Download.aspx" style="margin-top: -0.5px">Voltar</a>
                    <asp:Button ID="btn_excluir" runat="server" Text="Excluir" CssClass="btn btn-sm btn-danger" style="margin-top: -0.5px; right:20px; position: absolute;" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

