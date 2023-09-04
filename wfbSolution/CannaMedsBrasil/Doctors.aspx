<%@ Page Title="Meus Médicos" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master.Master" CodeBehind="Doctors.aspx.vb" Inherits="CannaMedsBrasil.Doctors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--Data Sources--%>
    <asp:SqlDataSource ID="dtsUsers" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dtsDoctors" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dtsDoctorsQtd" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />

    <%--Titulo da Pagina--%>
    <h4 class="text-secondary text-uppercase" style="padding-top: 5px"><%:Page.Title %></h4>

    <div class="form-row">
        <%-- Filtrar Representante--%>
        <div class="form-group col-sm-6">
            <label class="text-secondary">Representante</label>
             <asp:DropDownList ID="cmb_AccountExecutive" runat="server" CssClass="form-control" DataSourceID="dtsUsers" DataTextField="Account_Executive" DataValueField="Account_Executive_Email" AutoPostBack="True"></asp:DropDownList>
        </div>

        <%-- Localizar Médico--%>
        <div class="form-group col-sm-6">
            <label class="text-secondary">Localizar/<a href="Doctor?DoctorCode=NOVO">Novo</a></label>
            <input id="filter" type="text" maxlength="128" class="form-control" placeholder="Localizar" />
        </div>
    </div>

    <%--Tabela - Lista de médicos--%>
    <table class="table demo table-bordered table-hover " data-filter="#filter" data-paging="true" data-filter-text-only="true" data-page-size="50">
        <thead class="navbar-default">
            <tr>
                <th data-toggle="true" style="width: 50%">Medico</th>
                <th data-hide="phone" style="width: 25%">Especialidade</th>
                <th data-hide="phone" style="width: 20%">Cidade</th>
                <th data-hide="phone" style="width: 5%">UF</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="dtrDoctors" runat="server" DataSourceID="dtsDoctors">
                <ItemTemplate>
                    <tr>
                        <td><a href='<%# "Doctor?DoctorCode" + "=" + DataBinder.Eval(Container.DataItem, "Doctor_Code").ToString  %>'><%# DataBinder.Eval(Container.DataItem, "Doctor_Name").ToString%></a></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Doctor_Specialty").ToString%></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Address_City").ToString%></td>
                        <td><%# UCase(DataBinder.Eval(Container.DataItem, "Address_State_Code").ToString)%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="6">
                    <div class="pagination pagination-centered"></div>
                </td>
            </tr>
        </tfoot>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
