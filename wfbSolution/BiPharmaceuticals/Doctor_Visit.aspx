<%@ Page Title="Visitar Médico" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master.Master" CodeBehind="Doctor_Visit.aspx.vb" Inherits="BiPharmaceuticals.Doctor_Visit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%--Titulo da Pagina--%>
    <h4 class="text-secondary text-uppercase" style="padding-top: 5px"><%:Page.Title %></h4>

    <%--UF/CRM/ESPECIALIDADE--%>
    <div class="form-row">
        <%-- CRM--%>
        <div class="form-group col-sm-2">
            <label class="text-secondary">CRM</label>
            <input runat="server" id="txt_Doctor_Code" type="text" maxlength="10" class="form-control" disabled="disabled" />
        </div>

        <%-- Nome--%>
        <div class="form-group col-sm-10">
            <label class="text-secondary">Nome</label>
            <input runat="server" id="txt_Doctor_Name" type="text" maxlength="128" class="form-control" disabled="disabled" />
        </div>
    </div>
    <br />
    <%--<a href='<%# "Doctor?DoctorCode" + "=" + Request.QueryString("DoctorCode")  %>'>Médico</a>
    &nbsp;<a runat="server" id="lnk_Visits" class=" btn btn-primary btn-link" href='<%#"Doctor?DoctorCode" + "=" + Request.QueryString("DoctorCode") %>'>Médico</a>
    &nbsp;<a href="Doctors.aspx" class=" btn btn-primary btn-link">Lista</a>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
