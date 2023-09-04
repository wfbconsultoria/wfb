<%@ Page Title="Meus Médicos" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master.Master" CodeBehind="Doctors.aspx.vb" Inherits="BiPharmaceuticals.Doctors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <asp:SqlDataSource ID="dtsDoctors" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>

 <h4 class="text-secondary text-uppercase"><%:Page.Title %></h4>
    <%-- Localizar/ Incluir--%>
    <div class="input-group">
        <input id="filter" type="text" maxlength="128" class="form-control" placeholder="Localizar" />
        <div class="input-group-append">
            <span class="input-group-text text-primary"><a href="Doctor?DoctorCode=NOVO">Novo</a></span>
        </div>
    </div>
    <br />

    <%-- Lista de Colaboradores--%>
    <table class="table demo table-bordered table-hover " data-filter="#filter" data-paging="true" data-filter-text-only="true" data-page-size="50">
        <thead class="navbar-default">
            <tr>
                <th data-toggle="true" style="width:2%"></th>
                <th data-toggle="true"style="width:3%">Visitar</th>
                <th data-toggle="true">Medico</th>
                <th data-toggle="true">Atendido por</th>
                <th data-hide="phone">Telefone</th>
                <th data-hide="phone">Celular</th>
                <th data-hide="all">Whats App</th> 
                <th data-hide="all">Email</th>
                <th data-hide="all">Especialidade</th>
                <th data-hide="all">Endereço</th>
                <th data-hide="all">Cidade</th>
                <th data-hide="all">UF</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="dtrColaboradores" runat="server" DataSourceID="dtsDoctors">
                <ItemTemplate>
                    <tr>
                        <td class="text-center"></td>
                        <td class="text-center"><a href='<%# "Doctor_Visit?DoctorCode" + "=" + DataBinder.Eval(Container.DataItem, "Doctor_Code").ToString  %>'><img src="Images/Icone_visitar.png" /></a></td>
                        <td><a href='<%# "Doctor?DoctorCode" + "=" + DataBinder.Eval(Container.DataItem, "Doctor_Code").ToString  %>'><%# DataBinder.Eval(Container.DataItem, "Doctor_Name").ToString%></a></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Account_Executive").ToString%></td>
                        <td><a href='<%# "tel:" + LCase(DataBinder.Eval(Container.DataItem, "Phone").ToString)%>'><%# LCase(DataBinder.Eval(Container.DataItem, "Phone").ToString)%></a></td>
                        <td><a href='<%# "tel:" + LCase(DataBinder.Eval(Container.DataItem, "Mobile").ToString)%>'><%# LCase(DataBinder.Eval(Container.DataItem, "Mobile").ToString)%></a></td>
                        <td><%# LCase(DataBinder.Eval(Container.DataItem, "WhatsApp").ToString)%></td>
                        <td><a href='<%# "mailto:" + LCase(DataBinder.Eval(Container.DataItem, "Email").ToString)%>'><%# LCase(DataBinder.Eval(Container.DataItem, "Email").ToString)%></a></td>
                        
                        <td><%# UCase(DataBinder.Eval(Container.DataItem, "Doctor_Specialty").ToString)%></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Address").ToString%></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Address_City").ToString%></td>
                        <td><%# UCase(DataBinder.Eval(Container.DataItem, "Address_State_Code").ToString)%></td>
                       
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
  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
