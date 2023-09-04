<%@ Page Title="Pacientes" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master.Master" CodeBehind="Doctor_Patients.aspx.vb" Inherits="BiPharmaceuticals.Doctor_Patients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%--Titulo da Pagina--%>
    <h4 class="text-secondary text-uppercase" style="padding-top: 5px"><%:Page.Title %></h4>

    <%--UF/CRM/ESPECIALIDADE--%>
    <div class="form-row">
        <%-- CRM--%>
        <div class="form-group col-sm-3">
            <label class="text-secondary">CRM</label>
            <input runat="server" id="txt_Doctor_Code" type="text" maxlength="10" class="form-control" disabled="disabled" />
        </div>

        <%-- Nome--%>
        <div class="form-group col-sm-9">
            <label class="text-secondary">Nome</label>
            <input runat="server" id="txt_Doctor_Name" type="text" maxlength="128" class="form-control" disabled="disabled" />
        </div>
    </div>
    <br />
   <%-- &nbsp;<a runat="server" id="lnk_Visits" class=" btn btn-primary btn-link" href='<%# "Doctor_Visit?DoctorCode" + "=" + txt_Doctor_Code.Value  %>'>Visitar</a>
    &nbsp;<a href="Doctors.aspx" class=" btn btn-primary btn-link">Lista</a>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
