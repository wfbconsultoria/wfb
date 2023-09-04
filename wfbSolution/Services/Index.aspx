<%@ Page Title="Home" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<%--Referencias com css--%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head_Content" Runat="Server">
</asp:Content>

<%--Conteudo da página--%>
<asp:Content ID="Content2" ContentPlaceHolderID="Body_Content" Runat="Server">
    <div class="conteudo">
            <!-- Titulo -->
            <h1 class="text-center pt-3">Monitoramento</h1>
            <h3 class="text-center">Monitoramento dos servidores usados na WFB Consultoria</h3>

            <div class="row mt-5">
                <!-- Servidores -->
                <div class="col-md-12">
                    <!-- subtitulo -->
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:Timer ID="tmrServers" runat="server" Enabled="true" Interval="300000">

                    </asp:Timer>
                    <!-- Lista de servidores -->
                    <div class="row text-center">
                        <div class="col-md-12">
                            <div id="dvServidores" runat="server">

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

<%--Referencias com js--%>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer_Content" Runat="Server">
</asp:Content>

