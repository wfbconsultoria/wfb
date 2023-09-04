<%@ Page Title="Registrar Bomba" Language="VB" MasterPageFile="~/_Logged.master" AutoEventWireup="false" CodeFile="Pump_Register.aspx.vb" Inherits="Pump_Register" %>

<%@ Register Src="~/_PageTitle_Logged.ascx" TagPrefix="uc1" TagName="_PageTitle_Logged" %>

<%--PAGINA RESTRITA REQUER CONTROLE DE ACESSO E LOGIN--%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" Runat="Server">
   <div class="row d-flex flex-column flex-md-row align-items-center p-3 px-md-4 mb-3 bg-white border-bottom">
        <%--Page Title--%>
       <uc1:_PageTitle_Logged runat="server" ID="_PageTitle_Logged" />
        
       <%--Links e comandos da página, caso não seja utilizados comentar este trecho de código--%>
        <%--<nav class="my-2 my-md-0 mr-md-3">
            
        </nav>--%>
        <%--END Links e comandos--%>
    </div>
    
    <%--Conteudo da página--%>

    <div class="form-group col-md-12">
        <asp:Label runat="server" CssClass="control-label" ID="lbl_Customer_Name" AssociatedControlID="txt_Customer_Name" Text="Estabelecimento"></asp:Label>
        <strong>
            <asp:TextBox runat="server" CssClass="form-control" Enabled="false" TextMode="MultiLine" Rows="3" ID="txt_Customer_Name" Font-Bold="True" /></strong>
    </div>

    <div class="form-group col-md-12 ">
        <asp:Label runat="server" CssClass="control-label" ID="lbl_Pump_Id" AssociatedControlID="txt_Pump_Id" Text="Número de Série"></asp:Label>
        <strong>
            <asp:TextBox runat="server" CssClass="form-control text-center" Enabled="true" TextMode="MultiLine" Rows="2" ID="txt_Pump_Id" Font-Bold="True" />
            <asp:RequiredFieldValidator ID="vld_Pump_Id" runat="server" CssClass="form-control alert-danger" ErrorMessage="Digite número de série obrigatório" ControlToValidate="txt_Pump_Id" Display="Dynamic"></asp:RequiredFieldValidator>
        </strong>
    </div>

    <div class="form-group ">
        <div class="col-md-12">
            <asp:FileUpload ID="FileUpload1" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1" Font-Bold="False" Font-Size="Medium" ForeColor="Black" CssClass="form-control-file" />
        </div>
    </div>

    <div class="form-group ">
        <div class="col-md-4">
            <asp:Button ID="cmd_Register" runat="server" Text="Registrar" CssClass="form-control btn btn-success" />
        </div>
    </div>
</asp:Content>

