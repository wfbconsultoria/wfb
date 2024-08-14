<%@ Page Title="Grupo Distribuidor" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Distribuidores_Grupos_Incluir.aspx.vb" Inherits="Distribuidores_Grupos_Incluir" %>

<%@ Register Src="~/Titulo_Pagina.ascx" TagPrefix="uc1" TagName="Titulo_Pagina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%--Titulo da Página--%>
    <uc1:Titulo_Pagina runat="server" ID="Titulo_Pagina" />
    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts_EMAIL_RESPONSAVEL" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_ATIVO" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />

    <%--CORPO DA PAGINA--%>
    <div class="row g-3">
        <%-- REGIONAL --%>
        <div class="row g-2">
            <div class="col-md-4">
                <div class="form-floating">
                    <input runat="server" id="GRUPO_DISTRIBUIDOR" type="text" class="form-control" placeholder="" value="" required="required" />
                    <label for="REGIONAL">Grupo Distribuidor</label>
                </div>
            </div>
        </div>

        <%-- EMAIL_RESPONSAVEL --%>
        <div class="row g-2">
            <div class="col-md-4">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="EMAIL_RESPONSAVEL" CssClass="form-select" DataSourceID="dts_EMAIL_RESPONSAVEL" DataTextField="NOME" DataValueField="EMAIL" required="required"></asp:DropDownList>
                    <label for="EMAIL_RESPONSAVEL">Responsavel</label>
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
                    <a href="Distribuidores_Grupos_Lista.aspx" class="btn btn-info">Lista</a>
                    <a href="Distribuidores_Grupos_Incluir.aspx?Id=NOVO" class="btn btn-info">Novo</a>
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
