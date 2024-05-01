<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
    <div class="col-md-5">
   
         <iframe id="ifrm_Report" runat="server" width="512" height="320"  frameborder="0" allowFullScreen="true"></iframe>
    </div>
        <div class="col-md-2"></div>
    <div class="col-md-5">
   
         <iframe id="ifrm_Report2" runat="server" width="512" height="320"  frameborder="0" allowFullScreen="true"></iframe>
    </div>
    </div>
</asp:Content>
