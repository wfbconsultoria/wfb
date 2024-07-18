<%@ Page Title="" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Usuario_Incluir.aspx.vb" Inherits="Usuario_Incluir" %>

<%@ Register Src="~/Titulo_Pagina.ascx" TagPrefix="uc1" TagName="Titulo_Pagina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%--Titulo da Página--%>
    <uc1:Titulo_Pagina runat="server" ID="Titulo_Pagina" />
    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />

    <%--CORPO DA PAGINA--%>
    <div class="row g-3">
        <%-- NOME --%>
        <div class="row g-2">
            <div class="col-md-4">
                <div class="form-floating">
                    <input runat="server" id="NOME" type="text" class="form-control" placeholder="" value="" required="required" />
                    <label class="text-danger" for="NOME">Nome</label>
                </div>
            </div>
        </div>
        <%-- EMAIL --%>
        <div class="row g-2">
            <div class="col-md-4">
                <div class="form-floating">
                    <input runat="server" id="EMAIL" type="email" class="form-control" placeholder="" value="" required="required" />
                    <label for="EMAIL">E-Mail</label>
                </div>
            </div>
        </div>
        <%-- CELULAR --%>
        <div class="row g-2">
            <div class="col-md-4">
                <div class="form-floating">
                    <input runat="server" id="CELULAR" type="tel" class="form-control" placeholder="" value="" required="required" />
                    <label for="CELULAR">Celular</label>
                </div>
            </div>
        </div>
        <%-- FUNCAO --%>
        <div class="row g-2">
            <div class="col-md-4">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="NIVEL" CssClass="form-select" DataSourceID="dts" DataTextField="DESCRICAO" DataValueField="NIVEL" required="required"></asp:DropDownList>
                    <label class="text-danger" for="NIVEL">Nivel</label>
                </div>
            </div>
        </div>
        
        <%-- BOTÕES --%>
        <div class="row g-2">
            <div class="col-md-4">
                <div class="input-group">
                    <input runat="server" id="cmd_Save" type="submit" value="Gravar1" class="btn btn-primary" />
                    <button runat="server" id="cmd_Gravar" type="submit" class="btn btn-primary form-control">Gravar</button>
                </div>
            </div>
        </div>
    </div>
    <%-- BOTÕES --%>
    <%--CORPO DA PAGINA--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
</asp:Content>

