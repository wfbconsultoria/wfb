<%@ Page Language="VB" AutoEventWireup="false" CodeFile="P1.aspx.vb" Inherits="P1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <title>P1</title>
</head>
<body class="container">
    <form id="frmALert" runat="server">


        <!-- INFOS DO POSTO -->
        <br />
        <div class="alert alert-light" role="alert">
            <asp:Label ID="POSTO_LOCAL" runat="server"></asp:Label>:
        </div>
        <br />
        <div class="alert alert-light" role="alert">
            <asp:Label ID="POSTO_FISCAL" runat="server"></asp:Label>:
        </div>
        <br /><br /><br />
        
        <!-- botao para iniciar o alerta -->
        <div class="row align-content-lg-center">
            <button type="button" class="btn btn-danger btn-lg" data-bs-toggle="modal" data-bs-target="#checkAlert">
                ALERTAR
            </button>
        </div>

        <!-- Modal de alerta confirmar -->
        <div class="modal fade" id="checkAlert" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5 align-content-center" id="exampleModalLabel">CONFIRMAR ALERTA</h1>
                    </div>
                    <div class="modal-body align-content-center">
                       <asp:Button ID="cmdAlert" runat="server" CssClass="btn btn-danger btn-lg" Text="ALERTAR" />
                    </div>
                    <div class="modal-footer align-content-center">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">CANCELAR</button>
                    </div>
                </div>
            </div>
        </div>


        <!-- script bootstrap -->
        <script src="Scripts/bootstrap.bundle.min.js"></script>
    </form>
</body>
</html>
