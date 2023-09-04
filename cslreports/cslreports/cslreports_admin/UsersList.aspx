<%@ Page Title="Users List" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeFile="UsersList.aspx.vb" Inherits="UsersList" %>

<%@ Register Src="~/ScriptsFooter.ascx" TagPrefix="uc1" TagName="ScriptsFooter" %>
<%@ Register Src="~/ScriptsHeader.ascx" TagPrefix="uc1" TagName="ScriptsHeader" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <uc1:ScriptsHeader runat="server" ID="ScriptsHeader" />
    <div class="container body-content">
        <div class="row col-md-12 text-muted">
            <h4><strong><%:Page.Title%></strong></h4>
        </div>
        <div class="row">
            <div class="col-md-12">
                 
                <!--Links-->
                <h6><a href="UserRegister.aspx"><%:ConfigurationManager.AppSettings("UserRegister.Title")%></a></h6>

                <!--/Links-->

                <!--Corpo da página -->
                <div class="navbar-form navbar-left">
                    <div class="form-inline col-md-12">
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
                            <th data-toggle="true"><%:ConfigurationManager.AppSettings("UserRegister.lbl.UserStatus")%></th>
                            <th data-toggle="true"><%:ConfigurationManager.AppSettings("UserRegister.lbl.Username")%></th>
                            <th data-hide="phone,tablet"><%:ConfigurationManager.AppSettings("UserRegister.lbl.UserEmail")%></th>
                            <th data-hide="phone,tablet"><%:ConfigurationManager.AppSettings("UserRegister.lbl.UserProfile")%></th>
                            <th data-hide="phone,tablet"><%:ConfigurationManager.AppSettings("UserRegister.lbl.UserPhone")%></th>
                            <th data-hide="all"><%:ConfigurationManager.AppSettings("lbl.InsertUser")%></th>
                            <th data-hide="all"><%:ConfigurationManager.AppSettings("lbl.InsertDate")%></th>
                            <th data-hide="all"><%:ConfigurationManager.AppSettings("lbl.UpdateUser")%></th>
                            <th data-hide="all"><%:ConfigurationManager.AppSettings("lbl.UpdateDate")%></th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr class="<%# DataBinder.Eval(Container.DataItem,"Active")%>">
                                    <td class="<%#FormatRow(DataBinder.Eval(Container.DataItem,"Active"))%>"><%# DataBinder.Eval(Container.DataItem, "Active")%></td>
                                    <td><a href='<%# "UserEdit.aspx?ID" + "=" + DataBinder.Eval(Container.DataItem, "USER_ID").ToString%>'><%# DataBinder.Eval(Container.DataItem, "USER_NAME")%></a></td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "USER_EMAIL")%></td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "USER_PROFILE")%></td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "USER_PHONE")%></td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "Insert_User")%></td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "Insert_Date")%></td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "Update_User")%></td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "Update_Date")%></td>
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

                <!--/Corpo da página -->
            </div>
        </div>
    </div>
    <uc1:ScriptsFooter runat="server" ID="ScriptsFooter" />
</asp:Content>

