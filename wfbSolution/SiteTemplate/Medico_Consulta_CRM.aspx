<%@ Page Title="Consulta CRM" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Medico_Consulta_CRM.aspx.vb" Inherits="Medico_Consulta_CRM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts_UF" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />

    <%--Titulo da Pagina--%>
    <h4 class="text-secondary text-uppercase" style="padding-top: 5px"><%:Page.Title %></h4>

    <%--UF/CRM--%>
    <div class="row">
        <%-- UF--%>
        <div class="col-md-2">
            <label for="cmb_CRM_UF">UF</label>
            <asp:DropDownList ID="cmb_CRM_UF" runat="server" CssClass="form-select" DataSourceID="dts_UF" DataTextField="ESTADO" DataValueField="UF" Enabled="true"></asp:DropDownList>
        </div>
        <%-- CRM--%>
        <div class="col-md-1">
            <label for="txt_CRM">CRM</label>
            <input runat="server" id="txt_CRM" type="text" maxlength="7" class="form-control" required="required" placeholder="0000000" onfocus="this.value='';" onkeypress="return somenteNumeros(event)" />
        </div>

        <%-- BOTÃO--%>
        <div class="col-md-1">
             <label for="cmd_check"></label>
            <button runat="server" id="cmd_check" type="button" class="form-control btn btn-primary">Verificar</button>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
</asp:Content>

