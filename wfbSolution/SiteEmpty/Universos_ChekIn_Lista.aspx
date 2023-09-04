<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Universos_ChekIn_Lista.aspx.vb" Inherits="SiteEmpty.Universos_ChekIn_Lista" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
    <title>Universos CHECK IN</title>
</head>
<body>
    <form id="frm_Main" runat="server">
        <div>
            
            <%--Colaboradores--%>
                <a href="CheckIn_List.aspx?TipoPessoa=colaborador" class="card col-md" style="padding: 10px; margin: 1px">
                    <img class="rounded mx-auto d-block img80x80"  src="Images/Decathlon_Colaboradores.png" />
                    <div class="card-body">
                        <h6 class="text-center text-primary">COLABORADORES</h6>
                    </div>
                </a>


        </div>
    </form>
</body>
</html>
