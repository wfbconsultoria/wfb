<%@ Page Title="Colaboradores" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Colaboradores_Lista.aspx.vb" Inherits="Chapeira.Colaboradores_Lista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    
    <h4 class="text-secondary text-uppercase"><%:Page.Title%> <%:Now() %></h4>
    <%-- Localizar/ Incluir--%>
    <div class="row"><asp:LinkButton ID="cmd_SendEmail" runat="server" CssClass="nav-link">Compartilhar por E-mail </asp:LinkButton><a href="DashBoard.aspx" class="nav-link"> Voltar </a></div>
    <%-- Lista de Colaboradores--%>
    
    <table class="table table-sm table-hover">
        <thead>
            <tr>
                <th data-toggle="true" class="text-left">Nome &nbsp</th>
                <th data-toggle="true" class="text-left">Tipo &nbsp</th>
                <th data-hide="phone" class="text-left">Universo &nbsp</th>
                <th data-hide="phone" class="text-left">Status &nbsp</th>
                <th data-hide="phone" class="text-left">Horario &nbsp</th>
                <th data-hide="all" class="text-left">Função &nbsp</th>
                <th data-hide="all" class="text-left">Telefone &nbsp</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="dtrColaboradores" runat="server" DataSourceID="dtsColaboradores">
                <ItemTemplate>
                    <tr>
                        <td><%# DataBinder.Eval(Container.DataItem, "Nome").ToString%>&nbsp&nbsp</td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Tipo")%>&nbsp&nbsp</td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Universo_Zona_Andar").ToString%>&nbsp&nbsp</td>
                         <td><%# DataBinder.Eval(Container.DataItem, "Status").ToString%>&nbsp&nbsp</td>
                         <td><%# LCase(DataBinder.Eval(Container.DataItem, "CheckIn_Date").ToString)%>&nbsp&nbsp</td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Funcao")%>&nbsp&nbsp</td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Telefone").ToString%>&nbsp&nbsp</td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="7">
                    Emitido em <%:Now() %> - Chapeira <%:ConfigurationManager.AppSettings("Loja") %>
                </td>
            </tr>
        </tfoot>
    </table>


    <asp:SqlDataSource ID="dtsColaboradores" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
