<%@ Page Title="Estabelecimento" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Estabelecimento.aspx.vb" Inherits="Estabelecimento" %>

<%@ Register Src="~/Titulo_Pagina.ascx" TagPrefix="uc1" TagName="Titulo_Pagina" %>
<%@ Register Src="~/Estabelecimento_Cabecalho.ascx" TagPrefix="uc1" TagName="Estabelecimento_Cabecalho" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts_UF" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
   
    
    <%--Titulo da Página--%>
    <uc1:Titulo_Pagina runat="server" ID="Titulo_Pagina" />

    <%--Conteudo--%>
    <uc1:Estabelecimento_Cabecalho runat="server" ID="Estabelecimento_Cabecalho" />

    <%-- DIV PRINCIPAL --%>
    <div class="row g-3">

        <%-- Sub Titulo e instruções--%>
        <div class="row">
            <br />
            <h5>Incluir novo médico</h5>
            <h6 class="text-muted">Selecione o UF e digite o CRM</h6>
        </div>
        <%-- Sub Titulo e instruções--%>

        <%-- UF_CRM/CRM/BOTÃO--%>
        <div class="row g-2">
            <div class="col-10">
                <div class="input-group mb-3">
                    <%-- UF_CRM --%>
                    <span class="input-group-text">UF</span>
                    <asp:DropDownList runat="server" ID="UF_CRM" CssClass="form-select" DataSourceID="dts_UF" DataTextField="UF" DataValueField="UF" required="required"></asp:DropDownList>
                    <%-- CRM --%>
                    <span class="input-group-text">CRM</span>
                    <input runat="server" id="CRM" type="text" class="form-control" maxlength="8" placeholder="00000000" required="required" onfocus="this.value='';" onkeypress="return somenteNumeros(event)" />
                </div>
            </div>
            <div class="col-2">
                <%-- BOTÃO INCLUIR --%>
                <button runat="server" id="cmd_Novo_CRM" type="button" class="form-control btn btn-primary">OK</button>
            </div>
        </div>
        <%-- UF_CRM/CRM/BOTÃO--%>
    </div>
    <%-- DIV PRINCIPAL --%>

   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
</asp:Content>

