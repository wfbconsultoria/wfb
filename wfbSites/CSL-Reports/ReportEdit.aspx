<%@ Page Title="Editar Relatório" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="ReportEdit.aspx.vb" Inherits="ReportEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container">
        <div class="row">
        <div class="col-md-12 text-muted">
            <h4><strong>Editar Relatório</strong></h4>
        </div>
        </div>
        <div class="form-group">
            <!--Id-->
            <div class="row">
                <asp:Label ID="lbl_id" runat="server" Text="ID"></asp:Label>
                <asp:TextBox ID="txt_id" runat="server" CssClass="form-control" disabled="true"></asp:TextBox>
            </div>
            <!--/Id-->

            <!--nome-->
            <div class="row">
                <asp:Label ID="lbl_nome" runat="server" Text="Report"></asp:Label>
                <asp:TextBox ID="txt_nome" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <!--/nome-->

            <!--Descrição do Report-->
            <div class="row">
                <asp:Label ID="lbl_descricao" runat="server" Text="Descrição"></asp:Label>
                <asp:TextBox ID="txt_descricao" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <!--/Descrição do report-->

            <!--link-->
            <div class="row">
                <asp:Label ID="lbl_link" runat="server" Text="Link"></asp:Label>
                <asp:TextBox ID="txt_link" runat="server" CssClass="form-control"></asp:TextBox>
            </div><br/>
            <!--/link-->

            <!--btn atualizar-->
            <div class="row">
                <div class="col-sm">                    
                    <asp:Button ID="btn_update" runat="server" Text="Atualizar" CssClass="btn btn-sm btn-default" />
                    <asp:Button ID="btn_deletar" runat="server" Text="Excluir" CssClass="btn btn-sm btn-danger" style="margin-top: -0.5px;" />
                </div>
            </div>
        </div>
        <asp:Literal ID="ltr_nome" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="ltr_descricao" runat="server" Visible="False"></asp:Literal>
        <asp:Literal ID="ltr_link" runat="server" Visible="False"></asp:Literal>
    </div>
</asp:Content>

