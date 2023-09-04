<%@ Page Title="Localizar IP" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master.Master" CodeBehind="ConsultaIP.aspx.vb" Inherits="CannaMedsBrasil.ConsultaIP" %>

<%@ Register Src="~/_Page_Header_Public.ascx" TagPrefix="uc1" TagName="_Page_Header_Public" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:_Page_Header_Public runat="server" ID="_Page_Header_Public" />
    <%--Conteudo da página--%>
    <div>
        <%--EMAIL/IP--%>

        <div class="form-row">
            <%--UserEmail--%>
            <div class="form-group col-md-6">
                <label for="txt_UserEmail">Usuário</label>
                <input id="txt_UserEmail" runat="server" type="text" autocomplete="off" maxlength="256" class="form-control" placeholder="Email" readonly="readonly" />
            </div>
            <%--/UserEmail--%>

            <%--IP--%>
            <div class="form-group col-md-6">
                <label for="txt_IP">IP</label>
                <input id="txt_IP" runat="server" type="text" autocomplete="off" maxlength="256" class="form-control" placeholder="IP" readonly="readonly" />
            </div>
            <%--/IP--%>
        </div>
        <%--EMAIL/IP--%>

        <%--CODIGO PAIS/PAIS--%>
        <div class="form-row">

            <%--Código País--%>
            <div class="form-group col-md-2">
                <label for="txt_Country_Code">Codigo País</label>
                <input id="txt_Country_Code" runat="server" type="text" autocomplete="off" class="form-control" placeholder="Codigo País" readonly="readonly" />
            </div>
            <%--/Código País--%>

            <%--País--%>
            <div class="form-group col-md-10">
                <label for="txt_Country">País</label>
                <input id="txt_Country" runat="server" type="text" autocomplete="off" class="form-control" placeholder="País" readonly="readonly" />
            </div>
            <%--/País--%>
        </div>
        <%--/CODIGO PAIS/PAIS--%>

        <%--CIDADE/ESTADO--%>
        <div class="form-row">

            <%--Estado--%>
            <div class="form-group col-md-6">
                <label for="txt_State">Estado</label>
                <input id="txt_State" runat="server" type="text" autocomplete="off" class="form-control" placeholder="Estado" readonly="readonly" />
            </div>
            <%--/Estado--%>

            <%--Cidade--%>
            <div class="form-group col-md-6">
                <label for="txt_City">Cidade</label>
                <input id="txt_City" runat="server" type="text" autocomplete="off" class="form-control" placeholder="Cidade" readonly="readonly" />
            </div>
            <%--/Cidade--%>
        </div>
        <%--/CIDADE/ESTADO--%>

        <%--LATITUDE/LONGITUDE--%>
        <div class="form-row">

            <%--Latitude--%>
            <div class="form-group col-md-6">
                <label for="txt_Latitude">Latitude</label>
                <input id="txt_Latitude" runat="server" type="text" autocomplete="off" class="form-control" placeholder="Latitude" readonly="readonly" />
            </div>
            <%--/Latitude--%>

            <%--Longitude--%>
            <div class="form-group col-md-6">
                <label for="txt_Longitude">Longitude</label>
                <input id="txt_Longitue" runat="server" type="text" autocomplete="off" class="form-control" placeholder="Longitude" readonly="readonly" />
            </div>
            <%--/Longitude--%>
        </div>
        <%--/LATITUDE/LONGITUDE--%>
    </div>
    <%--END Conteudo da página--%>
</asp:Content>

<%--Footer Scrpits--%>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
