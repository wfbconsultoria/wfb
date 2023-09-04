<%@ Page Title="Download" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Download.aspx.vb" Inherits="Download" %>

<%@ Register Src="~/ScriptsFooter.ascx" TagPrefix="uc1" TagName="ScriptsFooter" %>
<%@ Register Src="~/ScriptsHeader.ascx" TagPrefix="uc1" TagName="ScriptsHeader" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <uc1:ScriptsHeader runat="server" ID="ScriptsHeader" />
    <div class="container">
        <div class="row">
            <div class="col-md-12 text-muted">
                <h4><strong>Downloads disponíveis para seu usuário</strong></h4>
            </div>
        </div>
        <!-- Cadastrar download -->
        <a id="lnkRegisterDownload" runat="server" href="#" visible="false">Cadastrar download</a>
        <br />
        <!-- Tabela de downloads disponiveis -->
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

                            <th data-toggle="true" style="width: 10%;">Download</th>

                            <%  Dim m As New clsMaster
                                If Session("USER_PROFILE_CODE") = "001" And m.onlyDomain(Session("USER_EMAIL").ToString) = "wfbconsultoria.com.br" Then %>
                            <th data-toggle="true" style="width: 10%;">Editar</th>
                            <%End If%>
                            <th data-hide="all">Descrição</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# DataBinder.Eval(Container.DataItem, "DOWNLOAD_TITLE")%></td>

                                    <!-- Apenas usuários system administrator podem associar-->
                                    <% If Session("USER_PROFILE_CODE") = "001" Then %>
                                    <td style="text-align: center;"><a href='AssociateDownload.aspx?id=<%# DataBinder.Eval(Container.DataItem, "ID")%>'><span class="glyphicon glyphicon-user" title="Associar usuários"></span></a></td>
                                    <%End If%>

                                    <td style="text-align: center;"><a href='<%# DataBinder.Eval(Container.DataItem, "DOWNLOAD_LINK")%>' download><span class="glyphicon glyphicon-save" title="Baixar"></span></a></td>


                                    <% Dim m As New clsMaster
                                        If Session("USER_PROFILE_CODE") = "001" And m.onlyDomain(Session("USER_EMAIL").ToString) = "wfbconsultoria.com.br" Then %>
                                    <td style="text-align: center;"><a href='DownloadEdit.aspx?id=<%# DataBinder.Eval(Container.DataItem, "ID")%>'><span class="glyphicon glyphicon-pencil" title="Editar registro"></span></a></td>
                                    <%End If%>

                                    <td><%# DataBinder.Eval(Container.DataItem, "DOWNLOAD_DESCRIPTION")%></td>
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
        <uc1:ScriptsFooter runat="server" ID="ScriptsFooter" />
    </div>
</asp:Content>

