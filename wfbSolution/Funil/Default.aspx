<%@ Page Title="" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">

    <%--Titulo da Pagina--%>
    <h4 class="text-secondary text-uppercase" style="padding-top: 5px"><%:Page.Title %></h4>

    <div class="row g-3">
        <iframe src="https://bihospitalar-my.sharepoint.com/personal/miro_wfbconsultoria_com_br/_layouts/15/Doc.aspx?sourcedoc={d86e793f-2427-4e1c-80de-0525781bff7e}&amp;action=embedview" width="402px" height="327px" frameborder="0">Este é um diagrama do <a target="_blank" href="https://office.com">Microsoft Office</a> incorporado, da plataforma <a target="_blank" href="https://office.com/webapps">Office</a>.</iframe>
    </div>
    
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
</asp:Content>


