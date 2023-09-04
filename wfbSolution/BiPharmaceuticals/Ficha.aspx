<%@ Page Title="User Infos" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master.Master" CodeBehind="Ficha.aspx.vb" Inherits="BiPharmaceuticals.Ficha" %>

<%@ Register Src="~/_Page_Header_Public.ascx" TagPrefix="uc1" TagName="_Page_Header_Public" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%--funcoes de validacao--%>
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
        // valida data
        function validarDtNasc() {
            let value = document.getElementById("nascimento").value;
            let re = /^[0-9]{2}\/[0-9]{2}\/[0-9]{4}$/;
            if (!re.test(value)) {
                // campo inválido, retorna false para o formulário não ser submetido
                alert('Data de Nascimento Inválida');
                document.form.nascimento.focus();
                return false;
            }
            return true;
        }
        // validar CPF
        function validarCPF() {
            let value = document.getElementById("cpf").value;
            let re = /([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})/g
            if (!re.test(value)) {
                // campo inválido, retorna false para o formulário não ser submetido
                alert('CPF Inválido');
                document.form.cpf.focus();
                return false;
            }
            return true;
        }
        // valida telefone
        function validarTel() {
            let value = document.getElementById("tel").value;
            let re = /^[0-9]{2}-[0-9]{5}-[0-9]{4}/g;
            if (!re.test(value)) {
                // campo inválido, retorna false para o formulário não ser submetido
                alert('Telefone Inválido');
                document.form.tel.focus();
                return false;
            }
            return true;
        }
        // Validar nome
        function validarNome() {
            let value = document.getElementById("nome").value;
            let re = /^[a-zA-ZéúíóáÉÚÍÓÁèùìòàçÇÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄ\-\ \s]+$/;
            if (!re.test(value)) {
                // campo inválido, retorna false para o formulário não ser submetido
                alert('Nome Inválido');
                document.form.nome.focus();
                return false;
            }
            return true;
        }
        // valida todos os campos
        function validarTudo() {
            // se um deles for inválido, retorna false e o form não é submetido
            return validarNome() && validarTel() && validarDtNasc() && validarCPF();
        }
    </script>
    <%--/funcoes de validacao--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:_Page_Header_Public runat="server" ID="_Page_Header_Public" />
    <%--Conteudo da página--%>
    <div>
        <%--/Modal Login Infos--%>
        <div id="ModalLoginInfos" class="modal" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Login Infos</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Fechar">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <p class="text-muted">IP:<label runat="server" id="txt_IP" class="text-info"></label></p>
                        <p class="text-muted">Browser:<label  runat="server" id="txt_Browser" class="text-info"></label></p>
                        <p class="text-muted">SessionId:<label runat="server"   id="txt_SessionId" class="text-info"></label></p>
                        <p class="text-muted">Authenticated:<label runat="server" id="txt_Authenticated" class="text-info"></label>
                        <p class="text-muted">Registrado:<label runat="server" id="txt_Registred" class="text-info"></label></p>
                        <p class="text-muted">Confirmado:<label runat="server" id="txt_Confirmed" class="text-info"></label></p>
                        <p class="text-muted">Bloqueado:<label runat="server" id="txt_Locked" class="text-info"></label></p>
                        <p class="text-muted">UserId:<label runat="server" id="txt_UserId" class="text-info"></label></p>
                        <p class="text-muted">Email:<label runat="server" id="txt_UserEmail" class="text-info"></label></p>
                        <p class="text-muted">Name:<label runat="server" id="txt_UserName" class="text-info"></label></p>
                    </div>
                    <div class="modal-footer">
                    </div>
                </div>
            </div>
        </div>

        <%--/Modal Login Infos--%>

        <%--CPF--%>
        <div class="form-group">
            <label for="txt_Document">CPF:</label>
            <input runat="server" type="text" id="txt_Document" required="required" autocomplete="off" maxlength="14" class="form-control" placeholder="CPF" onkeypress="formatar('###.###.###-##', this)">
        </div>
        <%--/CPF--%>
         
        <%--Nome--%>
        <div class="form-group">
            <label for="txt_Name">Nome</label>
            <input runat="server" type="text" id="txt_Name" required="required" maxlength="200" class="form-control" placeholder="Nome (sem acentos, 5 caracteres)" />
        </div>
        <%--/Nome--%>
        
        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#ModalLoginInfos">Login Infos</button>

    </div>
    <%--END Conteudo da página--%>
</asp:Content>

<%--Footer Scrpits--%>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
