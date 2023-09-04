<%@ Page Title="CheckIn/Out" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="CheckIn_List.aspx.vb" Inherits="lojas_WFB_CheckIn_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <h4 class="text-secondary text-uppercase"><%:Page.Title %></h4>

    <div class="input-group">
        <input id="filter" type="text" maxlength="128" class="form-control" placeholder="Localizar" style="font-size: xx-large" />
        <div class="input-group-append">
            <span class="input-group-text text-primary" style="font-size: large"><a href="CheckIn_Universos.aspx">UNIVERSOS</a></span>
            <span class="input-group-text text-primary" style="font-size: large"><a href="Default.aspx">INÍCIO</a></span>
        </div>
    </div>
    <br />

    <table class="table demo table-bordered table-hover " data-filter="#filter" data-paging="true" data-filter-text-only="true" data-page-size="1000">
        <thead class="navbar-default">
            <tr>
                <th></th>
                <th>Nome</th>
                <%--<th class="text-center">Status</th>--%>
                <th class="text-center">Ação</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="dtrColaboradores" runat="server" DataSourceID="dtsColaboradores">
                <ItemTemplate>
                    <tr>
                        <td class="text-center" style="text-align: center;">
                            <img src="<%# FormataIcone(DataBinder.Eval(Container.DataItem, "Brigadista"))%>" /><span class='<%#"badge badge-" + DataBinder.Eval(Container.DataItem, "cor").ToString %>'><%# FormataStatus(DataBinder.Eval(Container.DataItem, "Status"))%></span></td>
                        <td class="text-primary" style="font-size: x-large; width: 65%"><%# DataBinder.Eval(Container.DataItem, "Nome").ToString%></td>
                        <%-- <td class="text-primary text-center" style="font-size: x-large;"><span class='<%#"badge badge-" + DataBinder.Eval(Container.DataItem, "cor").ToString %>'><%# FormataStatus(DataBinder.Eval(Container.DataItem, "Status"))%></span></td>--%>
                        <td class="text-center" style="text-align: center;"><a class='<%#"btn btn-lg btn-" + DataBinder.Eval(Container.DataItem, "cor").ToString %>' href='<%# "CheckIn_Form.aspx?IdColaborador" + "=" + DataBinder.Eval(Container.DataItem, "ID").ToString %>'><%#DataBinder.Eval(Container.DataItem, "Acao").ToString %></a></td>
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
    <asp:SqlDataSource ID="dtsColaboradores" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
