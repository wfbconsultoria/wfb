<%@ Page Title="Usuario" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Usuario_Incluir.aspx.vb" Inherits="Usuario_Incluir" %>

<%@ Register Src="~/Titulo_Pagina.ascx" TagPrefix="uc1" TagName="Titulo_Pagina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%--Titulo da Página--%>
    <uc1:Titulo_Pagina runat="server" ID="Titulo_Pagina" />
    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts_NIVEL" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_ATIVO" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_REGIONAIS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_DISTRITOS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_SETORES" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    

    <%--CORPO DA PAGINA--%>
    <div class="row g-3">
        <%-- NOME --%>
        <div class="row g-2">
            <div class="col-md-4">
                <div class="form-floating">
                    <input runat="server" id="NOME" type="text" class="form-control" placeholder="" value="" required="required" />
                    <label for="NOME">Nome</label>
                </div>
            </div>
        </div>
        <%-- EMAIL --%>
        <div class="row g-2">
            <div class="col-md-4">
                <div class="form-floating">
                    <input runat="server" id="EMAIL" type="email" class="form-control" placeholder="" value="" required="required" disabled="disabled" />
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
        <%-- NIVEL --%>
        <div class="row g-2">
            <div class="col-md-4">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="NIVEL" CssClass="form-select" DataSourceID="dts_NIVEL" DataTextField="DESCRICAO" DataValueField="NIVEL" required="required"></asp:DropDownList>
                    <label for="NIVEL">Nivel</label>
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
                    <input id="cmd_Save" type="submit" value="Gravar" class="btn btn-primary" />
                    <select runat="server" name ="RESET_SENHA" id="RESET_SENHA" class="btn btn-info">
                        <option value="0">Manter Senha</option>
                        <option value="1">Criar nova senha</option>
                    </select>
                    <input id="cmd_Delete" type="submit" value="Excluir" class="btn btn-danger" />
                </div>
            </div>
        </div>
    </div>
    <%-- BOTÕES --%>
    <%--CORPO DA PAGINA--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
</asp:Content>

