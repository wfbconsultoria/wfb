<%@ Page Title="Estabelecimento" Language="VB" MasterPageFile="~/_Logged.master" AutoEventWireup="false" CodeFile="Customer.aspx.vb" Inherits="Customer" %>

<%@ Register Src="~/_PageTitle_Logged.ascx" TagPrefix="uc1" TagName="_PageTitle_Logged" %>

<%--PAGINA RESTRITA REQUER CONTROLE DE ACESSO E LOGIN--%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div class="row d-flex flex-column flex-md-row align-items-center p-3 px-md-4 mb-3 bg-white border-bottom">
        <%--Page Title--%>
        <uc1:_PageTitle_Logged runat="server" ID="_PageTitle_Logged" />

        <%--Links e comandos da página, caso não seja utilizados comentar este trecho de código--%>
        <nav class="my-2 my-md-0 mr-md-3">
            <h5><a class="p-2 text-primary" href="Pump_Register.aspx">Registrar Bomba</a></h5>
        </nav>
        <%--END Links e comandos--%>
    </div>
    
    <%--Conteudo da página--%>

    <div class="form-group col-md-6">
        <strong>
            <asp:Label runat="server" CssClass="control-label" ID="lbl_Customer_Id" AssociatedControlID="txt_Customer_Id" Text="CNPJ"></asp:Label></strong>
        <strong>
            <asp:TextBox runat="server" CssClass="form-control" Enabled="false" ID="txt_Customer_Id" /></strong>
    </div>

    <div class="form-group col-md-12">
        <asp:Label runat="server" CssClass="control-label" ID="lbl_Customer_Name" AssociatedControlID="txt_Customer_Name" Text="Estabelecimento"></asp:Label>
        <strong>
            <asp:TextBox runat="server" CssClass="form-control" Enabled="false" TextMode="MultiLine" Rows="2" ID="txt_Customer_Name" /></strong>
    </div>

    <div class="form-group col-md-12">
        <asp:Label runat="server" CssClass="control-label" ID="lbl_Customer_Address" AssociatedControlID="txt_Customer_Address" Text="Endereço"></asp:Label>
        <asp:TextBox runat="server" CssClass="form-control" Enabled="false" TextMode="SingleLine" Rows="1" ID="txt_Customer_Address" />
    </div>

    <div class="form-group col-md-12">
        <asp:Label runat="server" CssClass="control-label" ID="lbl_Customer_City" AssociatedControlID="txt_Customer_City" Text="Cidade/UF"></asp:Label>
        <asp:TextBox runat="server" CssClass="form-control" Enabled="false" TextMode="SingleLine" ID="txt_Customer_City" />
    </div>

    <div class="form-row col-md-12">
        <div class="form-group col-md-2">
            <asp:Label runat="server" CssClass="" ID="lbl_Pumps_Qtde" AssociatedControlID="txt_Pumps_Qtde" Text="Bombas SAP"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control text-center" Enabled="false" TextMode="MultiLine" Rows="1" ID="txt_Pumps_Qtde" />
        </div>
        <div class="form-group col-md-2">
            <asp:Label runat="server" CssClass="" ID="lbl_Pumps_Contract" AssociatedControlID="txt_Pumps_Contract" Text="Bombas Contratos"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control text-center" Enabled="false" TextMode="MultiLine" Rows="1" ID="txt_Pumps_Contract" />
        </div>

        <div class="form-group col-md-2">
            <asp:Label runat="server" CssClass="control-label" ID="lbl_Pumps_Qtde_OK" AssociatedControlID="txt_Pumps_Qtde_OK" Text="Bombas Inventariadas"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control text-center" Enabled="false" TextMode="MultiLine" Rows="1" ID="txt_Pumps_Qtde_OK" BackColor="#00B482" ForeColor="White" Font-Bold="True" />
        </div>
        <div class="form-group col-md-2">
            <asp:Label runat="server" CssClass="control-label" ID="lbl_CNES_Pumps" AssociatedControlID="txt_CNES_Pumps" Text="Bombas CNES"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control text-center" Enabled="false" TextMode="MultiLine" Rows="1" ID="txt_CNES_Pumps" />
        </div>
    </div>

    <div class="form-group col-md-12">
        <asp:Label runat="server" CssClass="control-label" ID="lbl_Customer_Account_Executive" AssociatedControlID="txt_Customer_Account_Executive" Text="Representante"></asp:Label>
        <asp:TextBox runat="server" CssClass="form-control" Enabled="false" TextMode="SingleLine" ID="txt_Customer_Account_Executive" />
    </div>

    <div class="form-group col-md-12">
        <asp:Label runat="server" CssClass="control-label" ID="lbl_Customer_Nurse" AssociatedControlID="txt_Customer_Nurse" Text="Enfermeiro(a)"></asp:Label>
        <asp:TextBox runat="server" CssClass="form-control" Enabled="false" TextMode="SingleLine" ID="txt_Customer_Nurse" />
    </div>

    <%--END Conteudo da página--%>
</asp:Content>
