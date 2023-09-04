<%@ Page Title="Usuarios" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master.Master" CodeBehind="Users.aspx.vb" Inherits="BiPharmaceuticals.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <asp:SqlDataSource ID="dtsUsers" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>

 <h4 class="text-secondary text-uppercase"><%:Page.Title %></h4>
    <%-- Localizar/ Incluir--%>
    <div class="input-group">
        <input id="filter" type="text" maxlength="128" class="form-control" placeholder="Localizar" />
    </div>
    <br />

    <%-- Lista de Usuários--%>
    <table class="table demo table-bordered table-hover " data-filter="#filter" data-paging="true" data-filter-text-only="true" data-page-size="50">
        <thead class="navbar-default">
            <tr>
                <th data-toggle="true"></th>
                <th data-toggle="true">Status</th>
                <th data-toggle="true">Nome</th>
                <th data-toggle="true">E-mail</th>
                <th data-toggle="true">Perfil</th>
                <th data-hide="all">Ultimo login</th>
            </tr>
        </thead>
        <tbody>
            
            <asp:Repeater ID="dtrUsers" runat="server" DataSourceID="dtsUsers">
                <ItemTemplate>
                    <tr>
                        <td class="text-center"></td>
                        <td class="text-center"><img src="<%# FormataIcone(DataBinder.Eval(Container.DataItem, "User_Status"))%>" /></td>
                        <td><a href='<%# "User?UserEmail" + "=" + DataBinder.Eval(Container.DataItem, "Email").ToString  %>'><%# DataBinder.Eval(Container.DataItem, "Name").ToString%></a></td>
                        <td><%# LCase(DataBinder.Eval(Container.DataItem, "Email").ToString)%></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "User_Profile").ToString%></td>
                        <td><%#Left(DataBinder.Eval(Container.DataItem, "Login_Date").ToString, 16)%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="7">
                    <div class="pagination pagination-centered"></div>
                </td>
            </tr>
        </tfoot>
    </table>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
