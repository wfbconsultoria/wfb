<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="User_Password_Change.aspx.vb" Inherits="DoutorCRM.User_Password_Change" %>

<%@ Register Src="~/App_Controls/ScriptsHeader.ascx" TagPrefix="uc1" TagName="ScriptsHeader" %>
<%@ Register Src="~/App_Controls/ScriptsFooter.ascx" TagPrefix="uc1" TagName="ScriptsFooter" %>
<%@ Register Src="~/App_Controls/PageHeader.ascx" TagPrefix="uc1" TagName="PageHeader" %>
<%@ Register Src="~/App_Controls/PageFooter.ascx" TagPrefix="uc1" TagName="PageFooter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <uc1:ScriptsHeader runat="server" ID="ScriptsHeader" />
    <title>Alterar Senha</title>
</head>
<body class="container">
    <form id="form1" runat="server">
        <uc1:PageHeader runat="server" ID="PageHeader" />

        <!-- Conteudo da pagina -->
        <div id="PageContent">
            
            <div class="form-row">
                <%--Senha Atual--%>
                <div class="form-group col-sm-4">
                    <label class="text-primary">Senha Atual</label>
                    <input runat="server" id="txt_Senha_Atual" class="form-control" placeholder="senha atual" required="required" />
                </div>
                <%--Nova Senha--%>
                <div class="form-group col-sm-4">
                    <label class="text-primary">Nova Senha</label>
                    <input runat="server" id="txt_Senha_Nova" type="text" maxlength="128" class="form-control" required="required" placeholder="nova senha" />
                </div>

                <%-- Confirmação --%>
                <div class="form-group col-sm-4">
                    <label class="text-primary">Confirmação</label>
                    <input runat="server" id="txt_Senha_Confirmacao" type="text" maxlength="128" class="form-control" required="required" placeholder="confirmar senha" />
                </div>
            </div>
            <input runat="server" id="cmd_Save" type="submit" value="Gravar" class="btn btn-primary" />
            &nbsp;<input id="cmd_Cancel" type="reset" value="Cancelar" class="btn btn-light" />

        </div>
        <!-- Conteudo da pagina -->

        <uc1:PageFooter runat="server" ID="PageFooter" />
    </form>
    <uc1:ScriptsFooter runat="server" ID="ScriptsFooter" />
</body>
</html>
