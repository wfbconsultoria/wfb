<%@ Page Title="Contatos Emergência (Cadastro)" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Contatos_Emergencia_Lista.aspx.vb" Inherits="Chapeira.Contatos_Emergencia_Lista" %>
  <asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    
   <h4 class="text-secondary text-uppercase"><%:Page.Title %></h4>
    <%-- Localizar/ Incluir--%>

    <div class="input-group">
        <input id="filter" type="text" maxlength="128" class="form-control" placeholder="Localizar" />
        <div class="input-group-append">
            <span class="input-group-text text-primary"><a href="Contatos_Emergencia_Form.aspx?IdContato=NOVO">Novo</a></span>
            <span class="input-group-text text-primary"><a href="Default.aspx">Início</a></span>
        </div>
    </div>
    <br />
     <%-- Lista de Contatos --%>
     <table class="table demo table-bordered table-hover " data-filter="#filter" data-paging="true" data-filter-text-only="true" data-page-size="50">
        <thead>
            <tr>
                <th data-toggle="true" class="text-left">Id &nbsp</th>
                <th data-toggle="true" class="text-left">Descrição &nbsp</th>
                <th data-toggle="true" class="text-left">Telefone &nbsp</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="dtrContatosEmergencia" runat="server" DataSourceID="dtsContatosEmergencia">
                <ItemTemplate>
                    <tr>
                        <td><a href='<%# "Contatos_Emergencia_Form.aspx?IdContato" + "=" + DataBinder.Eval(Container.DataItem, "Id").ToString  %>'><%# DataBinder.Eval(Container.DataItem, "Id").ToString%></a></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Descricao")%>&nbsp&nbsp</td>
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

    <asp:SqlDataSource ID="dtsContatosEmergencia" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
