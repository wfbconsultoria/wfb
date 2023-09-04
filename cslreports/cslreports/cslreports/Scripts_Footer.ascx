<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Scripts_Footer.ascx.vb" Inherits="cslreports.Scripts_Footer" %>
<!-- Bootstrap 3.37 jQuery (obrigatório para plugins JavaScript) -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
<!-- FooTable -->
<script src="FooTable/js/footable.js"></script>

<!-- FooTable script para inicialização -->
<script>
    jQuery(function ($) {
        $('.table').footable({
            "paging": {
                "enabled": true
            },
            "filtering": {
                "enabled": true
            },
            "sorting": {
                "enabled": true
            }
        });
    });
    $('[data-page-size]').on('click', function (e) {
        e.preventDefault();
        var newSize = $(this).data('pageSize');
        FooTable.get('#tbMain').pageSize(newSize);
    });
</script>

<!-- Funcao para proteger codigo -->
<script>
    function protegercodigo() {
        if (event.button == 2 || event.button == 3) {
            alert('não é possivel exibir o codigo fonte desta página');
        }
    }
        document.onmousedown = protegercodigo
</script>