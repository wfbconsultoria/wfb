<%@ Page Title="Distrito" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Setorizacao_Distritos_Incluir.aspx.vb" Inherits="Setorizacao_Distritos_Incluir" %>

<%@ Register Src="~/Titulo_Pagina.ascx" TagPrefix="uc1" TagName="Titulo_Pagina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%--Titulo da Página--%>
    <uc1:Titulo_Pagina runat="server" ID="Titulo_Pagina" />
    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts_REGIONAL" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_EMAIL_SUPERVISOR" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_ATIVO" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />

    <%--CORPO DA PAGINA--%>
    <div class="row g-3">
        <%-- COD_REGIONAL --%>
        <div class="row g-2">
            <div class="col-md-4">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="COD_REGIONAL" CssClass="form-select" DataSourceID="dts_REGIONAL" DataTextField="REGIONAL" DataValueField="COD_REGIONAL" required="required"></asp:DropDownList>
                    <label for="COD_REGIONAL">Regional</label>
                </div>
            </div>
        </div>

        <%-- COD_DISTRITO --%>
        <div class="row g-2">
            <div class="col-md-2">
                <div class="form-floating">
                    <input runat="server" id="COD_DISTRITO" type="text" class="form-control" placeholder="" value="" required="required" />
                    <label for="COD_DISTRITO">Codigo</label>
                </div>
            </div>
        </div>

        <%-- DISTRITO --%>
        <div class="row g-2">
            <div class="col-md-4">
                <div class="form-floating">
                    <input runat="server" id="DISTRITO" type="text" class="form-control" placeholder="" value="" required="required" />
                    <label for="DISTRITO">Distrito</label>
                </div>
            </div>
        </div>

        <%-- EMAIL_SUPERVISOR --%>
        <div class="row g-2">
            <div class="col-md-4">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="EMAIL_SUPERVISOR" CssClass="form-select" DataSourceID="dts_EMAIL_SUPERVISOR" DataTextField="NOME" DataValueField="EMAIL" required="required"></asp:DropDownList>
                    <label for="EMAIL_SUPERVISOR">Supervisor</label>
                </div>
            </div>
        </div>

        <%-- ATIVO INATIVO --%>
        <div class="row g-2">
            <div class="col-md-4">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="ATIVO" CssClass="form-select" DataSourceID="dts_ATIVO" DataTextField="ATIVO_DESCRICAO" DataValueField="ATIVO"></asp:DropDownList>
                    <label for="ATIVO">Status</label>
                </div>
            </div>
        </div>
        <%-- BOTÕES --%>
        <div class="row g-2">
            <div class="col-md-4">
                <div class="input-group">
                    <a href="Setorizacao_Distritos_Lista.aspx" class="btn btn-secondary">Lista Distritos</a>
                    <a href="Setorizacao_Distritos_Incluir.aspx?Id=NOVO" class="btn btn-info">Novo Distrito</a>
                    <input id="cmd_Save" type="submit" value="Gravar" class="btn btn-primary" />
                </div>
            </div>
        </div>
        <%-- OCULTOS Id --%>
        <div class="row g-2">
            <input runat="server" id="Id" type="hidden" class="form-control" placeholder="" value="" />
        </div>

    </div>
    <%-- BOTÕES --%>
    <%--CORPO DA PAGINA--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
</asp:Content>
