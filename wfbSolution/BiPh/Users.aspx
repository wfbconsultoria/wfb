<%@ Page Title="Usuários" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Users.aspx.vb" Inherits="BiPh.Users" %>

<%@ Register Src="~/Page_Header.ascx" TagPrefix="uc1" TagName="Page_Header" %>
<%@ Register Src="~/Page_Footer.ascx" TagPrefix="uc1" TagName="Page_Footer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Head_Content" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body_Content" runat="server">
    <!--Cabeçalho da página -->
    <uc1:Page_Header runat="server" ID="Page_Header" />
    
    <!--Ferramnetas da tabela, filtrar, incluir novo -->
    <div class="input-group mb-3">
        <input id="txt_Search" onkeyup="searchTable()" type="text" placeholder="Localizar por nome" class="form-control" />
        <div class="input-group-append">
            <span class="input-group-text text-primary"><a href="User_Register.aspx">Novo</a></span>
        </div>
    </div>

    <!--Tabela -->
    <table id="tb_Main" class="table table-bordered" style="width: 100%; table-layout: fixed">
        <thead>
            <tr>
                <th style="width: 50%" onclick="sortTable(0)"><a href="#">Nome</a></th>
                <th style="width: 50%" onclick="sortTable(1)"><a href="#">Perfil</a></th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="dtrTable" runat="server" DataSourceID="dtsTable">
                <ItemTemplate>
                    <tr>
                        <td>
                            <div class="_LIMITA_CELULA"><a href='<%# "User.aspx?UserEmail" + "=" + DataBinder.Eval(Container.DataItem, "Email").ToString  %>'><%# DataBinder.Eval(Container.DataItem, "Name").ToString%></a></div>
                        </td>
                        <td>
                            <div class="_LIMITA_CELULA"><%# DataBinder.Eval(Container.DataItem, "User_Profile").ToString%></a></div>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <uc1:Page_Footer runat="server" ID="Page_Footer" />
    <!--Datasources -->
    <asp:SqlDataSource ID="dtsTable" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>'></asp:SqlDataSource>
</asp:Content>
