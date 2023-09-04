<%@ Page Title="Pacientes" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master.Master" CodeBehind="Patients.aspx.vb" Inherits="CannaMedsBrasil.Patients" %>
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
    <%--/UF/CRM/ESPECIALIDADE--%>

    <br />


    <%--Combo (filtro) Representante--%>
    <div class="input-group">
        <div class="input-group-prepend">
            <span class="input-group-text text-secondary">Representante</span>
        </div>
       
    </div>
 
    <%--Caixa de Texto localizar--%>
    <div class="input-group">
         <div class="input-group-prepend">
            <span class="input-group-text text-primary"><a href="Doctor?DoctorCode=NOVO">Novo</a></span>
        </div>
        
    </div>
    <br />

    
    <asp:Repeater ID="dtrDoctorsQtd" runat="server" DataSourceID="dtsDoctorsQtd">
        <ItemTemplate>
        </ItemTemplate>
    </asp:Repeater>


    <%--Tabela - Lista de médicos--%>
    <table class="table demo table-bordered table-hover " data-filter="#filter" data-paging="true" data-filter-text-only="true" data-page-size="50">
        <thead class="navbar-default">
            <tr>
                <th data-toggle="true" style="width: 55%">Paciente</th>
                <th data-hide="phone" style="width: 25%">Médico</th>
                <th data-hide="phone" style="width: 18%">Cidade</th>
                <th data-hide="phone" style="width: 2%">UF</th>
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

