<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DashBoard.aspx.vb" Inherits="SiteEmpty.DashBoard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Src="~/_Header.ascx" TagPrefix="uc1" TagName="_Header" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />

    <title>Chapeira WEB</title>
</head>
<body>
    <form id="frm_Main" runat="server">
        <%
            Session("Sigla_Loja") = ConfigurationManager.AppSettings("Loja_Sigla")
            Dim m1 As New SiteEmpty.clsMaster
        %>
        <div class="container">

            <uc1:_Header runat="server" ID="_Header" />
            <div class="row">
                <%--Colaboradores por Loja--%>
                <div class="card col-md-6">
                    <img class="rounded mx-auto d-block" src="Images/Decathlon_Colaboradores.png" />
                    
                    <%--Total--%>
                    <div class="card-body">
                        <h5 class="text-center badge-primary">Colaboradores</h5>
                        <div class="input-group">
                            <%--link LIsta todos os colaboradores--%>
                            <a href="Pessoas_Lista.aspx?TipoLista=LojaTodosColaboradores" class="form-control">Total</a> 
                            <div class="input-group-append">
                                <span class="input-group-text badge-primary">
                                    <asp:Literal ID="txt_Colaboradores" runat="server"></asp:Literal></span>
                            </div>
                        </div>
                        
                        <div class="input-group">
                            <input type="text" class="form-control" value="Presentes" />
                            <div class="input-group-append">
                                <span class="input-group-text badge-success">
                                    <asp:Literal ID="txt_Colaboradores_Presentes_Percent" runat="server"></asp:Literal></span>
                                <span class="input-group-text badge-success">
                                    <asp:Literal ID="txt_Colaboradores_Presentes" runat="server"></asp:Literal></span>
                            </div>
                        </div>

                        <div class="input-group">
                            <input type="text" class="form-control" value="Ausentes" />
                            <div class="input-group-append">
                                <span class="input-group-text badge-light">
                                    <asp:Literal ID="txt_Colaboradores_Ausentes_Percent" runat="server"></asp:Literal></span>
                                <span class="input-group-text badge-light">
                                    <asp:Literal ID="txt_Colaboradores_Ausentes" runat="server"></asp:Literal></span>
                            </div>
                        </div>
                    </div>
                </div>



                <%--Brigadistas por loja--%>
                <div class="card col-md-6">
                    <img class="rounded mx-auto d-block" src="Images/Decathlon_Brigadista_Small.png" />
                    <div class="card-body">
                        <h5 class="text-center badge-danger" style="color: yellow">Brigadistas</h5>
                        <div class="input-group">
                            <input type="text" class="form-control" value="Total" />
                            <div class="input-group-append">
                                <span class="input-group-text badge-danger">
                                    <asp:Literal ID="txt_Brigadistas" runat="server"></asp:Literal></span>
                            </div>
                        </div>
                        <div class="input-group">
                            <input type="text" class="form-control" value="Presentes" />
                            <div class="input-group-append">
                                <span class="input-group-text badge-success">
                                    <asp:Literal ID="txt_Brigadistas_Presentes_Percent" runat="server"></asp:Literal></span>
                                <span class="input-group-text badge-success">
                                    <asp:Literal ID="txt_Brigadistas_Presentes" runat="server"></asp:Literal></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br />

        </div>
        <asp:SqlDataSource ID="dtsLojas" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dtsAndares" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dtsZonas" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dtsUniversos" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
        <%--<asp:SqlDataSource ID="dtsPessoas" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>--%>

        <script src="Scripts/jquery-3.0.0.min.js"></script>
        <script>window.jQuery || document.write('<script src="Scripts/jquery-3.0.0.min.js"><\/script>')</script>
        <script src="Scripts/popper.min.js"></script>
        <script src="Scripts/bootstrap.min.js"></script>
    </form>
</body>
</html>
