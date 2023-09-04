<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Pessoas_Lista.aspx.vb" Inherits="SiteEmpty.Pessoas_Lista" %>

<%@ Register Src="~/_Header.ascx" TagPrefix="uc1" TagName="_Header" %>
<%@ Register Src="~/_Header_Scripts.ascx" TagPrefix="uc1" TagName="_Header_Scripts" %>
<%@ Register Src="~/_Footer_Scripts.ascx" TagPrefix="uc1" TagName="_Footer_Scripts" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Lista</title>
</head>
<body>
    <form id="frm_Main" runat="server">
        <div class="container">
            <uc1:_Header runat="server" ID="_Header" />
            <uc1:_Header_Scripts runat="server" ID="_Header_Scripts" />
            <div class="navbar-form navbar-left">
                <div class="form-inline col-sm-12">
                    <span class="text-primary text-uppercase ">Localizar:&nbsp;</span><input id="filter" type="text" class="form-control text-primary text-uppercase tex col-sm-10" style="font-size: large" />
                    <%--Page Size:
                        <select id="change-page-size" class="form-control">
                            <option value="10">10</option>
                            <option value="20">20</option>
                            <option value="50">50</option>
                        </select>--%>
                </div>
            </div>
            <br />
            <table class="table demo table-bordered table-hover " data-filter="#filter" data-paging="true" data-filter-text-only="true" data-page-size="50">
                <thead class="navbar-default">
                    <tr>
                        <th>Nome</th>
                        <th>Status</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="dtrPessoas" runat="server" DataSourceID="dtsPessoas">
                        <ItemTemplate>
                            <tr>
                                <td style="font-size: large; width: 90%"><a href='<%# "Pessoas_Ficha.aspx?ID" + "=" + DataBinder.Eval(Container.DataItem, "ID").ToString%>'><%# DataBinder.Eval(Container.DataItem, "Nome").ToString%></a></td>
                                <td style="text-align: center; width: 10%"><a class='<%#"text-" + DataBinder.Eval(Container.DataItem, "cor").ToString %>' href='<%# "Pessoas_Ficha.aspx?ID" + "=" + DataBinder.Eval(Container.DataItem, "ID").ToString + "&Status=" + DataBinder.Eval(Container.DataItem, "Status").ToString%>'><%#DataBinder.Eval(Container.DataItem, "Status").ToString %></a></td>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan="12">
                            <div class="pagination pagination-centered"></div>
                        </td>
                    </tr>
                </tfoot>
            </table>
        </div>
        <asp:SqlDataSource ID="dtsPessoas" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
        <uc1:_Footer_Scripts runat="server" ID="_Footer_Scripts" />
    </form>
</body>
</html>
