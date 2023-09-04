<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Master_Header.ascx.vb" Inherits="BiPh.Master_Header" %>

<!-- Metas-->
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
<!-- Icone-->
<link rel="shortcut icon" href="Images/Icons/favicon.ico">

<!-- Scripts-->
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
<link rel="stylesheet" href="https://unpkg.com/material-components-web@v4.0.0/dist/material-components-web.min.css" />
<link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto" />
<link href="Site.css" rel="stylesheet" />
<link href="Site_Carousel.css" rel="stylesheet" />
<!-- Scripts para validação de formularios-->
    <script type="text/javascript">
        <%--Máscara de entrada--%>
        function formatar(mascara, documento) {
            let i = documento.value.length;
            let saida = mascara.substring(0, 1);
            let texto = mascara.substring(i)

            if (texto.substring(0, 1) != saida) {
                documento.value += texto.substring(0, 1);
            }
        }
   
<%--Somente Numeros--%>
        function somenteNumeros(e) {
            var charCode = e.charCode ? e.charCode : e.keyCode;
            // charCode 8 = backspace   
            // charCode 9 = tab
            if (charCode != 8 && charCode != 9) {
                // charCode 48 equivale a 0   
                // charCode 57 equivale a 9
                if (charCode < 48 || charCode > 57) {
                    return false;
                }
            }
        }

     <%--Valida Data--%>
        function validaDat(campo, valor) {
            var date = valor;
            var ardt = new Array;
            var ExpReg = new RegExp("(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[12][0-9]{3}");
            ardt = date.split("/");
            erro = false;
            if (date.search(ExpReg) == -1) {
                erro = true;
            }
            else if (((ardt[1] == 4) || (ardt[1] == 6) || (ardt[1] == 9) || (ardt[1] == 11)) && (ardt[0] > 30))
                erro = true;
            else if (ardt[1] == 2) {
                if ((ardt[0] > 28) && ((ardt[2] % 4) != 0))
                    erro = true;
                if ((ardt[0] > 29) && ((ardt[2] % 4) == 0))
                    erro = true;
            }
            if (date == "") erro = false;
            if (erro) {
                alert("DATA Formato inválido (dd/mm/aaaa");
                campo.value = "";
                return false;
            }
            return true;
        }
 </script>

