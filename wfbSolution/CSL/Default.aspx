<%@ Page Title="CSL" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <br />
    <br />
    <div class="row g-3">
        <div class="form">
            <iframe runat="server" id="frameReport" title="Report" width="880" height="550" src="#" frameborder="0" allow="fullscreen"></iframe>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
</asp:Content>


