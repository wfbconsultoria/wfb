<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Main.aspx.vb" Inherits="Chapeira.Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">

    <div class="row">

        <%--Colaboradores--%>
        <a href="CheckIn_Universos.aspx?TipoPessoa=colaborador" class="card col-md" style="padding: 10px; margin: 1px">
            <img class="rounded mx-auto d-block img80x80" src="Images/Decathlon_Colaboradores.png" />
            <div class="card-body">
                <h6 class="text-center text-primary">COLABORADORES</h6>
            </div>
        </a>

        <%--Visitantes--%>
        <a href="CheckIn_Universos.aspx" class="card col-md" style="padding: 10px; margin: 1px">
            <img class="rounded mx-auto d-block img80x80" src="Images/Visitantes.png" />
            <div class="card-body">
                <h6 class="text-center text-primary" style="color: white">VISITANTES</h6>
            </div>
        </a>

        <%--DashBoard--%>
        <a href="DashBoard.aspx" class="card col-md" style="padding: 10px; margin: 1px">
            <img class="rounded mx-auto d-block img80x80" src="Images/DashBoard.png" />
            <div class="card-body">
                <h6 class="text-center text-primary">DASHBOARD</h6>
            </div>
        </a>

        <div class="w-100"></div>

        <%--Planta--%>
        <a href="CheckIn_List.aspx?TipoPessoa=visitante" class="card col-md" style="padding: 10px; margin: 1px">
            <img class="rounded mx-auto d-block img80x80" src="Images/Planta_Combate_Incendio_Small.png" />
            <div class="card-body">
                <h6 class="text-center text-primary">PLANTA DA LOJA</h6>
            </div>
        </a>

        <%--Telefones--%>
        <a href="Telefones.aspx?TipoPessoa=visitante" class="card col-md" style="padding: 10px; margin: 1px">
            <img class="rounded mx-auto d-block img80x80" src="Images/Telefone.jpg" />
            <div class="card-body">
                <h6 class="text-center text-primary">PLANTA DA LOJA</h6>
            </div>
        </a>

        <%--Planta--%>
        <a href="CheckIn_List.aspx?TipoPessoa=visitante" class="card col-md" style="padding: 10px; margin: 1px">
            <img class="rounded mx-auto d-block img80x80" src="Images/Planta_Combate_Incendio_Small.png" />
            <div class="card-body">
                <h6 class="text-center text-primary">PLANTA DA LOJA</h6>
            </div>
        </a>

        <%--Planta--%>
        <a href="CheckIn_List.aspx?TipoPessoa=visitante" class="card col-md" style="padding: 10px; margin: 1px">
            <img class="rounded mx-auto d-block img80x80" src="Images/Mobi.png" />
            <div class="card-body">
                <h6 class="text-center text-primary">Mobi</h6>
            </div>
        </a>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
