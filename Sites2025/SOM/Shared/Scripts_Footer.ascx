<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Scripts_Footer.ascx.vb" Inherits="Shared_Scripts_Footer" %>

<!-- JavaScript (Opcional) -->

<!-- jQuery primeiro, depois Popper.js, depois Bootstrap JS -->
<script src="../Bootstrap/jquery/jquery.js"></script>
<script src="../Bootstrap/popper/pooper.js"></script>
<script src="../Bootstrap/bootstrap/js/bootstrap.min.js"></script>

<!-- Scripts para Bootstrap Table -->
<script src="../Bootstrap/bootstrap-table/bootstrap-table.min.js"></script>
<script src="../Bootstrap/bootstrap-table/extensions/multiple-sort/bootstrap-table-multiple-sort.min.js"></script>
<script src="../Bootstrap/bootstrap-table/extensions/filter-control/bootstrap-table-filter-control.min.js"></script>
<script src="../Bootstrap/bootstrap-table/extensions/mobile/bootstrap-table-mobile.min.js"></script>

<script>
// Exemplo de JavaScript inicial para desativar envios de formulário, se houver campos inválidos.
(function() {
  'use strict';
  window.addEventListener('load', function() {
    // Pega todos os formulários que nós queremos aplicar estilos de validação Bootstrap personalizados.
    var forms = document.getElementsByClassName('needs-validation');
    // Faz um loop neles e evita o envio
    var validation = Array.prototype.filter.call(forms, function(form) {
      form.addEventListener('submit', function(event) {
        if (form.checkValidity() === false) {
          event.preventDefault();
          event.stopPropagation();
        }
        form.classList.add('was-validated');
      }, false);
    });
  }, false);
})();
</script>

