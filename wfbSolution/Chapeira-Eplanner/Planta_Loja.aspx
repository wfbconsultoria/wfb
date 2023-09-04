<%@ Page Title="Planta Loja" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Planta_Loja.aspx.vb" Inherits="Chapeira_Eplanner.Planta_Loja" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <h4 class="text-secondary text-uppercase"><%:Page.Title %></h4>
  
    <div class="card">
        <div class="card-body">
            <h5 class="card-title">Combate a Incêndio</h5>
            <img runat="server" id="Img1" class="rounded mx-auto d-block" style="max-width:100%" src="~/Images/Decathlon_Brigadista.png" alt="">
        </div>
    </div>
    <br />
    <div class="card">
        <div class="card-body">
            <h5 class="card-title">Detectores de Fumaça</h5>
            <img runat="server" id="Img2" class="rounded mx-auto d-block" style="max-width:100%" src="~/Images/Decathlon_Brigadista.png" alt="">
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>

