<%@ Page Title="" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">

    <%--Titulo da Pagina--%>
    <h4 class="text-secondary text-uppercase" style="padding-top: 5px"><%:Page.Title %></h4>

    <div class="row g-3">
        <div class="alert alert-primary" role="alert">
            <h4 class="text-primary">NOVA FUNCIONALIDADE</h4>
            <h5>Agora é possível gerenciar a sua lista de médicos e contatos</h5>
            <h5>Na página de Médicos/Contatos incluimos a função <strong>Ativar/Inativar</strong></h5>
            <h5>Veja na figura abaixo</h5>
            <h5>Basta mudar o Status para que o médico seja ativado ou inativado</h5>
        </div>
    </div>
    <hr />
    <div class="row g-3">
        <figure class="figure">
            <img src="Images/INATIVAR.png" class="figure-img img-fluid rounded rounded mx-auto d-block" style=" max-width: 75%; height: auto" alt="">
        </figure>
    </div>
    <hr />
    <div class="row g-3">
        <h5>Bom trabalho a todos,</h5>
        <h5 class="text-primary">WFB Consultoria</h5>
        <h6 class="text-muted"><%:Now() %></h6>
    </div>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
</asp:Content>


