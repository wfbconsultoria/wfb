<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Medico_Consulta_CRM.aspx.vb" Inherits="DoutorCRM.Medico_Consulta_CRM" %>

<%@ Register Src="~/App_Controls/ScriptsHeader.ascx" TagPrefix="uc1" TagName="ScriptsHeader" %>
<%@ Register Src="~/App_Controls/ScriptsFooter.ascx" TagPrefix="uc1" TagName="ScriptsFooter" %>
<%@ Register Src="~/App_Controls/PageHeader.ascx" TagPrefix="uc1" TagName="PageHeader" %>
<%@ Register Src="~/App_Controls/PageFooter.ascx" TagPrefix="uc1" TagName="PageFooter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <uc1:ScriptsHeader runat="server" ID="ScriptsHeader" />
    <title>Médico</title>
</head>
<body class="container">
    <form id="form1" runat="server">
        <uc1:PageHeader runat="server" ID="PageHeader" />
        <h4 class="text-secondary text-uppercase"><%:Page.Title %></h4>
        <!-- Conteudo da pagina -->
        <div id="PageContent">

            <asp:SqlDataSource ID="dts_UF" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [UF], [ESTADO] FROM [TBL_UF] ORDER BY [ESTADO]"></asp:SqlDataSource>

            <%--UF/CRM/NOME--%>
            <div class="form-row">
                <%-- UF--%>
                <div class="form-group col-sm-2">
                    <label class="text-danger">*UF</label>
                    <asp:DropDownList ID="UF_CRM" runat="server" CssClass="form-control" DataSourceID="dts_UF" DataTextField="UF" DataValueField="UF"></asp:DropDownList>
                </div>
                <%-- CRM--%>
                <div class="form-group col-sm-2">
                    <label class="text-danger">*CRM</label>
                    <input runat="server" id="CRM" type="text" maxlength="7" class="form-control" required="required" placeholder="CRM 0000000" onfocus="this.value='';" onkeypress="return somenteNumeros(event)" />
                </div>
                <%-- Nome--%>
                <div class="form-group col-sm-8">
                    <label class="text-danger">*Nome</label>
                    <input runat="server" id="NOME" type="text" maxlength="256" class="form-control" required="required" />
                </div>
            </div>
            <%--/UF/CRM/NOME--%>

            <%--MENSAGEM--%>
            <div class="form-row">
                <div class="form-group col-sm-12">
                    <label>Observações</label>
                    <textarea runat="server" id="MENSAGEM" type="text" class="form-control" rows="5" maxlength="2048" />
                </div>
            </div>
             <%--MENSAGEM--%>

            <%-- botoes de de comando--%>
            <input runat="server" id="cmd_Save" type="submit" value="Gravar" class="btn btn-primary" />&nbsp;
            <input id="cmd_Cancel" type="reset" value="Cancelar" class="btn btn-light" />&nbsp;
            <a href="Medicos_Lista.aspx" class="btn btn-link btn-light">Lista</a>
            <a href="Medico_Consulta_CRM.aspx" class="btn btn-link btn-light">Novo</a>
            

           
            <a id="lnk_Doctors" href="Doctors.aspx" class="btn btn-link btn-light">Lista</a>

        </div>
        <!-- Conteudo da pagina -->
        <uc1:PageFooter runat="server" ID="PageFooter" />
    </form>
    <uc1:ScriptsFooter runat="server" ID="ScriptsFooter" />
</body>
</html>
