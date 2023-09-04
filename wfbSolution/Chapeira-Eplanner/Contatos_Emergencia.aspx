<%@ Page Title="Contatos de Emergência" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Contatos_Emergencia.aspx.vb" Inherits="Chapeira_Eplanner.Contatos_Emergencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <h4 class="text-secondary text-uppercase"><%:Page.Title %></h4>
    <br />
    <asp:Repeater ID="dtrContatosEmergencia" runat="server" DataSourceID="dtsContatosEmergencia">
        <ItemTemplate>
            <div class="card">
                <div class="card-body">
                    <h4 class="card-title"><%# DataBinder.Eval(Container.DataItem, "Descricao").ToString%></h4>
                    <h2 class="card-title"><a href='<%# "tel:" + DataBinder.Eval(Container.DataItem, "Telefone").ToString  %>'><%# DataBinder.Eval(Container.DataItem, "Telefone").ToString%></a></h2>
                    <h6 class="card-text text-secondary"><%# DataBinder.Eval(Container.DataItem, "Endereco").ToString%></h6>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:SqlDataSource ID="dtsContatosEmergencia" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
