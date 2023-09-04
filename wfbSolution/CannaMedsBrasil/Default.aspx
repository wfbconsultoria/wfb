<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master.Master" CodeBehind="Default.aspx.vb" Inherits="CannaMedsBrasil._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .grow:hover {
            -webkit-transform: scale(1.3);
            -ms-transform: scale(1.3);
            transform: scale(1.3);
        }

        .shrink:hover {
            -webkit-transform: scale(0.8);
            -ms-transform: scale(0.8);
            transform: scale(0.8);
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="row">

        <%--Médicos--%>
        <a href="Doctors.aspx" class="card col-md grow" style="padding: 10px; margin: 1px">
            <img class="rounded mx-auto d-block" src="Images/Doctor_120.png" width="120" height="120" />
            <div class="card-body">
                <h5 class="nav-link text-center text-primary  text-uppercase">Médicos</h5>
            </div>
        </a>

        <%--Pacientes--%>
        <a href="Patients.aspx" class="card col-md grow" style="padding: 10px; margin: 1px">
            <img class="rounded mx-auto d-block" src="Images/Patient_120.png" width="120" height="120" />
            <div class="card-body">
                <h5 class="nav-link text-center text-primary  text-uppercase" style="color: white">Pacientes</h5>
            </div>
        </a>

        <%--Agenda--%>
        <a href="CheckIn_List_Visitantes.aspx" class="card col-md grow" style="padding: 10px; margin: 1px;">
            <img class="rounded mx-auto d-block" src="Images/Schedule_120.png" width="120" height="120" />
            <div class="card-body">
                <h5 class="nav-link text-center text-primary  text-uppercase" style="color: white">Agenda</h5>
            </div>
        </a>
        <%--Receituario--%>
        <a href="CheckIn_List_Visitantes.aspx" class="card col-md grow" style="padding: 10px; margin: 1px">
            <img class="rounded mx-auto d-block" src="Images/Prescription_120.png" width="120" height="120" />
            <div class="card-body">
                <h5 class="nav-link text-center text-primary text-uppercase" style="color: white">Receituario</h5>
            </div>
        </a>
        <div class="w-100"></div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
