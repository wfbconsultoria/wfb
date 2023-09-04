<%@ Page Title="Administrar Relatório" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Report.aspx.vb" Inherits="Report" %>

<%@ Register Src="~/ScriptsFooter.ascx" TagPrefix="uc1" TagName="ScriptsFooter" %>
<%@ Register Src="~/ScriptsHeader.ascx" TagPrefix="uc1" TagName="ScriptsHeader" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <uc1:ScriptsHeader runat="server" ID="ScriptsHeader" />
    <div class="container">
        <div class="row">
            <div class="col-md-12 text-muted">
                <h4><strong>Administrar Relatórios</strong></h4>
                <!-- Cadastrar relatório -->
                <%If Session("USER_PROFILE_CODE") = "001" Then %>
                <a id="lnkRegisterDownload" runat="server" href="RegisterReport.aspx">Cadastrar relatório</a>
                <%End if %>
            </div>
        </div>
        <br />

        <!-- Tabela de relatórios disponiveis -->
        <div class="row">
            <div class="col-md-12">
                <div class="navbar-form navbar-left">
                    <div class="form-inline col-sm-12">
                        Search:
                        <input id="filter" type="text" class="form-control" />
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

                            <!-- Apenas usuários system administrator podem associar-->
                            <% If Session("USER_PROFILE_CODE") = "001" Or Session("USER_PROFILE_CODE") = "100" Then %>
                            <th data-toggle="true" style="width: 10%;">Associar</th>
                            <%End If%>

                            <%  Dim m As New clsMaster
                                If Session("USER_PROFILE_CODE") = "001" Then %>
                            <th data-toggle="true" style="width: 10%;">Editar</th>
                            <%End If%>
                            <th data-hide="all">Descrição</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# DataBinder.Eval(Container.DataItem, "REPORT_NAME")%></td>

                                    <!-- Apenas usuários system administrator ou report administrator podem associar-->
                                    <% If Session("USER_PROFILE_CODE") = "001" Or Session("USER_PROFILE_CODE") = "100" Then %>
                                    <td style="text-align: center;"><a href='<%# "AssociateReport.aspx?ID" + "=" + DataBinder.Eval(Container.DataItem, "ID").ToString%>' ><span class="glyphicon glyphicon-user" title="Associar usuários"></span></a></td>
                                    <%End If%>

                                    <% Dim m As New clsMaster
                                        If Session("USER_PROFILE_CODE") = "001" Then %>
                                    <td style="text-align: center;"><a href='<%# "ReportEdit.aspx?ID" + "=" + DataBinder.Eval(Container.DataItem, "ID").ToString%>'><span class="glyphicon glyphicon-pencil" title="Editar relatório"></span></a></td>
                                    <%End If%>

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
            </div>
        </div>
    </div>
    <uc1:ScriptsFooter runat="server" ID="ScriptsFooter" />
</asp:Content>
