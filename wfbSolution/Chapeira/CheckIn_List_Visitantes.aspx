<%@ Page Title="Visitantes Check In/Out" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="CheckIn_List_Visitantes.aspx.vb" Inherits="Chapeira.CheckIn_List_Visitantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <h4 class="text-secondary text-uppercase"><%:Page.Title %></h4>
    
    <div class="input-group">
        <input id="filter" type="text" maxlength="128" class="form-control" placeholder="Localizar" style="font-size: xx-large" />
        <div class="input-group-append">
            <span class="input-group-text text-primary" style="font-size:large""><a href="Default.aspx">INÍCIO</a></span>
        </div>
    </div>
    <br />

    <table class="table demo table-bordered table-hover " data-filter="#filter" data-paging="true" data-filter-text-only="true" data-page-size="1000">
        <thead class="navbar-default">
            <tr>
                <th>Nome</th>
                <th>Data Visita</th>
                <th>Check In/Out</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="dtrVisistantes" runat="server" DataSourceID="dtsVisitantes">
                <ItemTemplate>
                    <tr>
                        <td class="text-primary" style="font-size: x-large; width: 50%"><%# DataBinder.Eval(Container.DataItem, "Nome").ToString%></td>
                        <td class="text-primary" style="font-size: x-large; width: 25%"><%# DataBinder.Eval(Container.DataItem, "Admissao_Data").ToString%></td>
                        <td style="text-align: center; width: 25%"><a class='<%#"btn btn-lg btn-" + DataBinder.Eval(Container.DataItem, "cor").ToString %>' href='<%# "CheckIn_Form.aspx?IdColaborador" + "=" + DataBinder.Eval(Container.DataItem, "ID").ToString %>'><%#DataBinder.Eval(Container.DataItem, "Acao").ToString %></a></td>
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
  

        <asp:SqlDataSource ID="dtsVisitantes" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
