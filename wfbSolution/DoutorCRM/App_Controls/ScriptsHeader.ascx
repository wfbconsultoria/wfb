<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ScriptsHeader.ascx.vb" Inherits="DoutorCRM.ScriptsHeader" %>

<!-- Meta tags Obrigatórias -->
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

<!-- Bootstrap CSS -->
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
<link href="Css/bootstrap.min.css" rel="stylesheet" />
<link href="Css/offCanvas.css" rel="stylesheet" />
<link href="Css/Site.css" rel="stylesheet" />

<!-- Footable -->
<link href="../Css/footable.standalone.css" rel="stylesheet" />
<link href="../Css/footable-demos.css" rel="stylesheet" />
<link href="../Css/footable.core.css" rel="stylesheet" />
<script src="https://kit.fontawesome.com/3e867150af.js"></script>

<!-- Javascript -->
<%--Máscara de entrada--%>
<script type="text/javascript">
    // mascara entrada
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
