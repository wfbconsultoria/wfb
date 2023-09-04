<%@ Page Title="Report" Language="VB" MasterPageFile="~/SitePowerBi.master" AutoEventWireup="false" CodeFile="PowerBi.aspx.vb" Inherits="PowerBi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="row col-md-12 text-muted">

        <div class="row">
                <div style="margin-left:3%;"><iframe runat="server" id="frmPower"  style="height: 95vh;" src="https://app.powerbi.com/view?r=" frameborder="0" allowfullscreen="true" width="100%"></iframe></div>
        </div>
    </div>
</asp:Content>

