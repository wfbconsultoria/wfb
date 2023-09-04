<%@ Page Title="Chapeira" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="WFB_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" Runat="Server">
    <div class="row">

        <%--Colaboradores--%>
        <a href="CheckIn_Universos.aspx?TipoPessoa=colaborador" class="card col-md" style="padding: 10px; margin: 1px">
            <img class="rounded mx-auto d-block" src="/Images/Decathlon_Colaboradores.png" />
            <div class="card-body">
                <h5 class="text-center text-primary">COLABORADORES CHECK IN/OUT</h5>
            </div>
        </a>

        <%--Terceiros--%>
        <a href="CheckIn_List_Terceiros.aspx" class="card col-md" style="padding: 10px; margin: 1px">
            <img class="rounded mx-auto d-block" src="/Images/Decatlhon_Servicos.png" />
            <div class="card-body">
                <h5 class="text-center text-primary" style="color: white">SERVIÇOS CHECK IN/OUT</h5>
            </div>
        </a>

        <%--Visitantes--%>
        <a href="CheckIn_List_Visitantes.aspx" class="card col-md" style="padding: 10px; margin: 1px">
            <img class="rounded mx-auto d-block" src="/Images/Decathlon_Visitante.png" />
            <div class="card-body">
                <h5 class="text-center text-primary" style="color: white">VISITANTES CHECK IN/OUT</h5>
            </div>
        </a>
        <div class="w-100"></div>

        <%--DashBoard--%>
        <a href="DashBoard.aspx" class="card col-md" style="padding: 10px; margin: 1px">
            <img class="rounded mx-auto d-block" src="/Images/DashBoard.png" />
            <div class="card-body">
                <h5 class="text-center text-primary">DASHBOARD</h5>
            </div>
        </a>
        <%--Relatorio--%>
        <a href="<%:ConfigurationManager.AppSettings("PowerBi.Datamaster") %>" class="card col-md" style="padding: 10px; margin: 1px">
            <img class="rounded mx-auto d-block" src="/Images/Report.png" />
            <div class="card-body">
                <h5 class="text-center text-primary">Relatório Presentes/Ausentes</h5>
            </div>
        </a>

        <%--Planta--%>
        <a href="Planta_Loja.aspx" class="card col-md" style="padding: 10px; margin: 1px">
            <img class="rounded mx-auto d-block" src="/Images/Planta_Combate_Incendio_Small.png" />
            <div class="card-body">
                <h5 class="text-center text-primary">PLANTA DA LOJA</h5>
            </div>
        </a>
        <div class="w-100"></div>

        <%--Telefones--%>
        <a href="Contatos_Emergencia.aspx" class="card col-md" style="padding: 10px; margin: 1px">
            <img class="rounded mx-auto d-block" src="/Images/Telefone.jpg" />
            <div class="card-body">
                <h5 class="text-center text-primary">CONTATOS DE EMERGÊNCIA</h5>
            </div>
        </a>
         <%--vazio--%>
        <a href="Default.aspx" class="card col-md" style="padding: 10px; margin: 1px">
            <%-- <img class="rounded mx-auto d-block" src="" />--%>
            <div class="card-body bg-light">
                <h5 class="text-center text-primary"></h5>
            </div>
        </a>
        <%--vazio--%>
        <a href="Default" class="card col-md" style="padding: 10px; margin: 1px">
            <%-- <img class="rounded mx-auto d-block" src="" />--%>
            <div class="card-body bg-light">
                <h5 class="text-center text-primary"></h5>
            </div>
        </a>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" Runat="Server">
</asp:Content>