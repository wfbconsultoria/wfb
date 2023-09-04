<%@ Page Title="Associar Download" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="AssociateDownload.aspx.vb" Inherits="AssociateDownload" %>

<%@ Register Src="~/ScriptsFooter.ascx" TagPrefix="uc1" TagName="ScriptsFooter" %>
<%@ Register Src="~/ScriptsHeader.ascx" TagPrefix="uc1" TagName="ScriptsHeader" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <uc1:ScriptsHeader runat="server" ID="ScriptsHeader" />
    <div class="container">
        <div class="form-group">
            <div class="row col-md-12 text-muted">
                <h4><strong>Associar Usuários</strong></h4>
            </div>
        </div>
        <!--Download-->
        <div class="form-group">
            <div class="row">
                <div class="col-md-12">
                    <span>Associe qualquer usuário para fazer download do <label id="lbl_title" runat="server"></label>.</span>
                </div>
            </div>
        </div>

        <!-- Associar usuário -->
        <div class="form-group">
            <div class="row">
                <div class="col-md-12">
                    <label>Associar usuários ao download</label>
                    <asp:DropDownList ID="ddl_associado" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-md-12">
                    <asp:Button ID="btn_associar" runat="server" Text="Associar" CssClass="btn btn-sm btn-default"/>
                    <asp:Button ID="btn_cancelar" runat="server" Text="Voltar" CssClass="btn btn-sm btn-danger" style="margin-top: -0.2px"/>
                </div>
            </div>
        </div>

        <!--tabela-->
        <table class="table demo table-bordered table-hover" data-filter="#filter" data-paging="true" data-filter-text-only="true" data-page-size="10">
            <thead class="navbar-default">
                <tr>
                    <th data-toggle="true">Usuarios associados</th>
                    <th data-toggle="true">Desassociar</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="width: 85%;">
                                <%# DataBinder.Eval(Container.DataItem, "USER_NAME")%>
                            </td>
                            <td style="text-align: center;">
                                <a href="DisassociateDownload.aspx?id=<%#: DataBinder.Eval(Container.DataItem, "ID") & "&email=" & DataBinder.Eval(Container.DataItem, "USER_EMAIL") %>">
                                    <span class="glyphicon glyphicon-remove text-danger" title="Desassociar usuário"></span>
                                </a>
                            </td>
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
    <uc1:ScriptsFooter runat="server" ID="ScriptsFooter" />
</asp:Content>

