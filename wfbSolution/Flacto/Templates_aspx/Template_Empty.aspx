<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Template_Empty.aspx.vb" Inherits="Flacto.Template_Empty" %>

<%@ Register Src="~/App_Controls/Page_Footer.ascx" TagPrefix="uc1" TagName="Page_Footer" %>
<%@ Register Src="~/App_Controls/Navigation_Header.ascx" TagPrefix="uc1" TagName="Navigation_Header" %>
<%@ Register Src="~/App_Controls/Page_Header.ascx" TagPrefix="uc1" TagName="Page_Header" %>
<%@ Register Src="~/App_Controls/Meta.ascx" TagPrefix="uc1" TagName="Meta" %>
<%@ Register Src="~/App_Controls/Scripts_Header.ascx" TagPrefix="uc1" TagName="Scripts_Header" %>
<%@ Register Src="~/App_Controls/Scripts_Footer.ascx" TagPrefix="uc1" TagName="Scripts_Footer" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <uc1:Meta runat="server" ID="Meta" />
    <uc1:Scripts_Header runat="server" ID="Scripts_Header" />
    <title>Starter Page | Flacto - Responsive Bootstrap 4 Admin Dashboard</title>
</head>

<body data-layout="horizontal">
    <form id="form1" runat="server">
        <!-- Begin wrapper -->
        <div id="wrapper">
            <!-- Navigation -->
            <uc1:Navigation_Header runat="server" ID="Navigation_Header" />
            <!-- End Navigation -->
            
            <!-- div de inicio do conteudo da pagina -->
            <div class="content-page">
                <div class="content">
                    
                    <!--Container-fluid -->
                    <div class="container-fluid">
                        
                        <!-- Titulo da Página-->
                        <uc1:Page_Header runat="server" ID="Page_Header" />
                        <!-- End Titulo da Página-->

                        <!-- ============================================================== -->
                        <!-- Start Page Content here -->
                        <!-- ============================================================== -->
                        <div>


                        </div>
                        <!-- ============================================================== -->
                        <!-- End Page content -->
                        <!-- ============================================================== -->
                    </div>
                    <!-- End Container-fluid -->
                
                </div>
                <!-- end content -->
                
                <!-- Footer -->
                <uc1:Page_Footer runat="server" ID="Page_Footer" />
                <!-- End Footer -->
            
            </div>
            <!-- End div de inicio do conteudo da pagina -->
        </div>
        <!-- End wrapper -->

        <!-- Scripts -->
        <uc1:Scripts_Footer runat="server" ID="Scripts_Footer" />
        <!-- End Scripts -->
    </form>
</body>
</html>
