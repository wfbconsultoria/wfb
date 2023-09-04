<%@ Page Title="Check-IN/OUT MOBIS" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="CheckIn_Mobis.aspx.vb" Inherits="Chapeira_Eplanner.CheckIn_Mobis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <h4 class="text-secondary text-uppercase"><%:Page.Title %></h4>
    <%-- Localizar/ Incluir--%>

    <div class="input-group">
        <input id="filter" type="text" maxlength="128" class="form-control" placeholder="Localizar" />
        <div class="input-group-append">
            <span class="input-group-text text-primary"><a href="Colaborador.aspx?IdColaborador=NOVO">Novo</a></span>
            <span class="input-group-text text-primary"><a href="Default.aspx">Início</a></span>
        </div>
    </div>
    <br />

    <%-- Lista de Colaboradores--%>
    <table class="table demo table-bordered table-hover " data-filter="#filter" data-paging="true" data-filter-text-only="true" data-page-size="50">
        <thead class="navbar-default">
            <tr>
               <%-- <th data-toggle="true"></th>--%>
                <th data-toggle="true">Modelo</th>
                <th data-hide="phone">Colaborador</th>
                <th data-toggle="true">Check-IN/OUT</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="dtrMobis" runat="server" DataSourceID="dtsMobis">
                <ItemTemplate>
                    <tr>
                        <%--<td class="text-center"></td>--%>
                        
                        <td class="text-primary" style="font-size: x-large; width: 40%"><%# LCase(DataBinder.Eval(Container.DataItem, "Modelo").ToString)%></td>
                        <td class="text-primary" style="font-size: x-large; width: 40%"><%# LCase(DataBinder.Eval(Container.DataItem, "Colaborador").ToString)%></td>
                        <td class="text-center" style="text-align: center;"><a class='<%#"btn btn-lg btn-" + DataBinder.Eval(Container.DataItem, "cor").ToString %>' href='<%# "CheckIn_Form.aspx?IdColaborador" + "=" + DataBinder.Eval(Container.DataItem, "ID").ToString %>'><%#DataBinder.Eval(Container.DataItem, "Acao").ToString %></a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="11">
                    <div class="pagination pagination-centered"></div>
                </td>
            </tr>
        </tfoot>
    </table>
    <asp:SqlDataSource ID="dtsMobis" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
