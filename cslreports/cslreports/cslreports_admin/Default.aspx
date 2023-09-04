<%@ Page Title="Meus Relatórios" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/ScriptsFooter.ascx" TagPrefix="uc1" TagName="ScriptsFooter" %>
<%@ Register Src="~/ScriptsHeader.ascx" TagPrefix="uc1" TagName="ScriptsHeader" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row col-md-12 text-muted">
            <h4><strong>Relatórios</strong></h4>
        </div>
    </div>
    <uc1:ScriptsHeader runat="server" ID="ScriptsHeader" />
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <!-- Page Content -->
                <div class="navbar-form navbar-left">
                    <div class="form-inline col-sm-12">
                        Search:
                        <input id="filter" type="text" class="form-control"/>
                        Page Size:
                        <select id="change-page-size" class="form-control">
                            <option value="10">10</option>
                            <option value="20">20</option>
                            <option value="50">50</option>
                            <option value="100">100</option>
                        </select>
                    </div>
                </div>

                <table class="table demo table-bordered table-hover" data-filter="#filter" data-paging="true" data-filter-text-only="true" data-page-size="10">
                    <thead class="navbar-default">
                        <tr>
                            <th data-toggle="true">Nome</th>
                            <th data-toggle="true" style="width: 10%;">Visualizar</th>
                            <th data-hide="all">Descrição</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr class="<%# DataBinder.Eval(Container.DataItem, "Active")%>">
                                    <td><%# DataBinder.Eval(Container.DataItem, "REPORT_NAME")%></td>
                                    <td style="text-align: center;"><a href='<%# "PowerBi.aspx?rptId" + "=" + DataBinder.Eval(Container.DataItem, "REPORT_STRING").ToString%>' title="Visualizar"><img src="Images/icon_bi.png" style="max-width: 30px;" /></a></td>                                   
                                    <td><%# DataBinder.Eval(Container.DataItem, "REPORT_DESCRIPTION")%></td>
                                </tr>
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

                <!--/ Page Content -->

                <!-- Page Links Botton-->

                <!--/ Page Links Botton -->
            </div>
        </div>
        <uc1:ScriptsFooter runat="server" ID="ScriptsFooter" />
    </div>
</asp:Content>


