<%@ Page Title="" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Estabelecimento.aspx.vb" Inherits="Estabelecimento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />

    <asp:Repeater ID="dtr" runat="server" DataSourceID="dts">
        <ItemTemplate>
            <div class="row g-3">
                <div class="col-md-3">
                    <label for="txtCNPJ" class="form-label">CNPJ</label>
                    <input type="text" class="form-control" id="txtCNPJ" value='<%# DataBinder.Eval(Container.DataItem, "CNPJ").ToString%>' />
                </div>
                <div class="col-md-9">
                    <label for="txtEstabelecimento" class="form-label">Cliente</label>
                    <input type="text" class="form-control" id="txtEstabelecimento" value='<%# DataBinder.Eval(Container.DataItem, "Estabelecimento").ToString%>' />
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <div class="row g-3">
       <a href='<%#"Medico_Consulta_CRM.aspx?idEstabelecimento" + "=" + Request.QueryString("idEstabelecimento")%>'>Novo Médico</a>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
</asp:Content>

