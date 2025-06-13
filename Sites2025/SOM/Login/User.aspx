<%@ Page Title="" Language="VB" MasterPageFile="~/Shared/Master.master" AutoEventWireup="false" CodeFile="User.aspx.vb" Inherits="Login_User" %>

<%@ Register Src="~/Shared/Page_Title.ascx" TagPrefix="uc1" TagName="Page_Title" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%--Titulo da Página--%>
    <uc1:Page_Title runat="server" ID="Page_Title" />
    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts_NIVEL" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_ATIVO" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <%--BOTOES--%>
    <div>
        <a href="Users_List.aspx" class="btn btn-primary">Lista de Usuários</a>
    </div>
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
                    <select runat="server" name="RESET_SENHA" id="RESET_SENHA" class="btn btn-info">
                        <option value="0">Manter Senha</option>
                        <option value="1">Criar nova senha</option>
                    </select>

                </div>
            </div>
            <div class="row g-2">
                <a class="text-danger" data-bs-toggle="modal" href="#EXCLUIR">Excluir</a>
            </div>
        </div>
    </div>
    <%-- BOTÕES --%>

    <%--CORPO DA PAGINA--%>
    <!-- Modal EXCLUIR -->
    <div class="modal fade" id="EXCLUIR" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="EXCLUIR" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="staticBackdropLabel">Close</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="container container-fluid">
                        <div class="form-floating">
                            <input runat="server" id="EMAIL_EXCLUIR" type="text" class="form-control text-primary" placeholder="" value="" required="required" disabled="disabled" />
                            <label for="EMAIL_EXCLUIR">EXCLUIR?</label>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button runat="server" id="cmd_Excluir" type="button" class="btn btn-link, text-danger">EXCLUIR</button>
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal EXCLUIR -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
</asp:Content>

