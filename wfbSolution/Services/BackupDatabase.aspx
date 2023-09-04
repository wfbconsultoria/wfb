<%@ Page Title="Backup dos bancos de dados" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BackupDatabase.aspx.cs" Inherits="BackupDatabase" %>

<%--Referencias com css--%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head_Content" runat="Server">
    <!-- Css para criar loader -->
    <link href="css/Custom/Loader/loader.css" rel="stylesheet" />
</asp:Content>

<%--Conteudo da página--%>
<asp:Content ID="Content2" ContentPlaceHolderID="Body_Content" runat="Server">
    <div class="container mt-5">
        <!-- Titulo -->
        <div class="row pt-2 text-center">
            <div class="col-md-12">
                <h3><%:Page.Title%></h3>
                <span class="text-muted">Está página é voltada para executar os backups de banco de dados cadastrados no menu de configurações</span>
            </div>
        </div>
        <!-- Botão para backup -->
        <div class="row mt-5 mb-5">
            <div class="col-md-12 text-center">
                <input type="submit" id="btnBackup" runat="server" class="btn btn-sm btn-primary" onclick="backup()" onserverclick="btnBackup_Click" />
            </div>
        </div>
        <!-- Lista de backups -->
        <div class="row">
            <div class="col-md-12">
                <!-- Div para informações do backup -->
                <div id="dvBackups" runat="server" class="text-center">
                </div>
                <!-- div para informações durante o processo do backup -->
                <div id="dvInfo" class="text-center mt-4"></div>
            </div>
        </div>
    </div>
</asp:Content>

<%--Referencias com js--%>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer_Content" runat="Server">
    <script>
        //Atualizar div quando clicar para fazer backup
        function backup() {
            //Limpa todos os textos na div e transforma ela em um loader
            document.getElementById("Body_Content_dvBackups").innerText = "";
            document.getElementById("Body_Content_dvBackups").className = "loader";
            //Desativa o botão enquanto faz o processo
            document.getElementById("Body_Content_btnBackup").style.visibility = "hidden"
            //Informa a hora que iniciou o processo
            now = new Date
            document.getElementById("dvInfo").innerHTML = "<small class='text-muted'> Backup iniciado ás " + now.getHours() + ":" + now.getMinutes() + "</small>";
        }
    </script>
</asp:Content>

