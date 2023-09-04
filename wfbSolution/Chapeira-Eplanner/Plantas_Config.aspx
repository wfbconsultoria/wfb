<%@ Page Title="PLantas da Loja" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Plantas_Config.aspx.vb" Inherits="Chapeira_Eplanner.Plantas_Config" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <h4 class="text-secondary text-uppercase"><%:Page.Title %></h4>
    <br />
    <div class="card">
        <div class="card-body">
            <h5 class="card-title">Combate a Incêndio</h5>
            <div class="form-inline">
                <div class="form-group mb-2">
                    <input runat="server" id="fup_Planta01" type="file" class="form-control-file" />
                </div>
                <div class="form-group mx-sm-3 mb-2">
                    <asp:Button ID="cmd_Planta01" runat="server" CssClass="form-control-file" Text="Enviar" />
                </div>
            </div>
            <img runat="server" id="Img1" class="rounded mx-auto d-block" style="max-width:100%" src="~/Images/Decathlon_Brigadista.png" alt="">
        </div>
    </div>
    <br />
    <div class="card">
        <div class="card-body">
            <h5 class="card-title">Detectores de Fumaça</h5>
            <div class="form-inline">
                <div class="form-group mb-2">
                    <asp:FileUpload ID="fup_Planta02" runat="server" CssClass="form-control-file" />
                </div>
                <div class="form-group mx-sm-3 mb-2">
                    <asp:Button ID="cmd_Planta02" runat="server" Text="Enviar" CssClass="form-control-file" />
                </div>
            </div>
            <img runat="server" id="Img2" class="rounded mx-auto d-block" style="max-width:100%" src="~/Images/Decathlon_Brigadista.png" alt="">
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
