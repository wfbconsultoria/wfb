<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Medicos_Lista.aspx.vb" Inherits="DoutorCRM.Medicos_Lista" %>

<%@ Register Src="~/App_Controls/ScriptsHeader.ascx" TagPrefix="uc1" TagName="ScriptsHeader" %>
<%@ Register Src="~/App_Controls/ScriptsFooter.ascx" TagPrefix="uc1" TagName="ScriptsFooter" %>
<%@ Register Src="~/App_Controls/PageHeader.ascx" TagPrefix="uc1" TagName="PageHeader" %>
<%@ Register Src="~/App_Controls/PageFooter.ascx" TagPrefix="uc1" TagName="PageFooter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <uc1:ScriptsHeader runat="server" ID="ScriptsHeader" />
    <title>Médicos</title>
</head>
<body class="container">
    <form id="form1" runat="server">
        <uc1:PageHeader runat="server" ID="PageHeader" />
        <!-- Conteudo da pagina -->
        <div id="PageContent">

            <%-- Localizar/ Incluir--%>
            <div class="input-group">
                <input id="filter" type="text" maxlength="128" class="form-control" placeholder="Localizar" />
                <div class="input-group-append"><span class="input-group-text text-primary"><a href="Medico_Consulta_CRM.aspx">Novo</a></span></div>
            </div>
            <br />

            <%-- Lista de MEDICOS--%>
            <table class="table demo table-bordered table-hover " data-filter="#filter" data-paging="true" data-filter-text-only="true" data-page-size="50">
                <thead class="navbar-default">
                    <tr>
                        <th data-toggle="true"></th>
                        <th data-toggle="true">CRM</th>
                        <th data-toggle="true">Nome</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="dtr_MEDICOS" runat="server" DataSourceID="dts_MEDICOS">
                        <ItemTemplate>
                            <tr>
                                <td class="text-center"></td>
                                <td class="text-center"><a href='<%# "Medico.aspx?CRMUF" + "=" + DataBinder.Eval(Container.DataItem, "CRMUF").ToString  %>'><%# DataBinder.Eval(Container.DataItem, "CRMUF").ToString%></a></td>
                                <td class="text-left"><%# DataBinder.Eval(Container.DataItem, "NOME").ToString%></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan="3">
                            <div class="pagination pagination-centered"></div>
                        </td>
                    </tr>
                </tfoot>
            </table>
            <asp:SqlDataSource ID="dts_MEDICOS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>

        </div>
        <!-- Conteudo da pagina -->
        <uc1:ScriptsFooter runat="server" ID="ScriptsFooter" />
        <uc1:PageFooter runat="server" ID="PageFooter" />
    </form>
    
</body>
</html>
