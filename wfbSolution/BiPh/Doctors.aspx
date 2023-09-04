<%@ Page Title="Médicos" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Doctors.aspx.vb" Inherits="BiPh.Doctors" %>

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
            <input id="txt_Search2" onkeyup="searchTable2()" type="text" placeholder="Localizar por CRM" class="form-control" />
        </div>
        <div class="input-group-append">
            <span class="input-group-text text-primary"><a href="Doctor.aspx">Novo</a></span>
        </div>
    </div>
    <%-- Filtrar Representante--%>
        <div class="form-group col-sm-6">
            <label class="text-secondary">Representante</label>
             <asp:DropDownList ID="cmb_AccountExecutive" runat="server" CssClass="form-control" DataSourceID="dtsUsers" DataTextField="Account_Executive" DataValueField="Account_Executive_Email" AutoPostBack="True"></asp:DropDownList>
        </div>
    <!--Tabela -->
    <table id="tb_Main" class="table table-bordered" style="width: 100%; table-layout: fixed">
        <thead>
            <tr>
                <th style="width: 55%" onclick="sortTable(0)"><a href="#">Nome</a></th>
                <th style="width: 15%" onclick="sortTable(1)"><a href="#">CRM</a></th>
                <th style="width: 30%" onclick="sortTable(2)"><a href="#">Especialidade</a></th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="dtrTable" runat="server" DataSourceID="dtsTable">
                <ItemTemplate>
                    <tr>
                        <td>
                            <div class="_LIMITA_CELULA"><a href='<%# "Doctor.aspx?Doctor_Code" + "=" + DataBinder.Eval(Container.DataItem, "Doctor_Code").ToString  %>'><%# DataBinder.Eval(Container.DataItem, "Doctor_Name").ToString%></a></div>
                        </td>
                        <td>
                            <div class="_LIMITA_CELULA"><%# DataBinder.Eval(Container.DataItem, "Doctor_Code").ToString%></a></div>
                        </td>
                        <td>
                            <div class="_LIMITA_CELULA"><%# DataBinder.Eval(Container.DataItem, "Doctor_Specialty").ToString%></a></div>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <uc1:Page_Footer runat="server" ID="Page_Footer" />
    <!--Datasources -->
    <asp:SqlDataSource ID="dtsTable" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>'/>
    <asp:SqlDataSource ID="dtsUsers" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
</asp:Content>
