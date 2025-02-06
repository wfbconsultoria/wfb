<%@ Page Title="Logins" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Usuarios_Lista.aspx.vb" Inherits="Usuarios_Lista" %>

<%@ Register Src="~/Titulo_Pagina.ascx" TagPrefix="uc1" TagName="Titulo_Pagina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">

    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />

    <%--CORPO DA PAGINA--%>
    <uc1:Titulo_Pagina runat="server" ID="Titulo_Pagina" />

    <%--BOTOES--%>
    <div>
        <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#NOVO">Novo</button>
    </div>
    <%--TABELA LISTA USUARIOS--%>
    <div>
        <table id="table"
            class="table table-bordered table-hover"
            data-toggle="table"
            data-search="true"
            data-search-align="left"
            data-search-accent-neutralise="true"
            data-search-highlight="true"
            <%--data-show-search-clear-button="true"--%>
            data-show-toggle="true"
            data-show-columns="true"
            <%--data-show-columns-toggle-all="true"--%>
            <%--data-show-fullscreen="true"--%>
            <%--data-show-pagination-switch="true"--%>
            data-sortable="true"
            <%--data-pagination="true"--%>
            data-mobile-responsive="true">
            <thead>
                <tr>
                    <th data-field="EMAIL" data-sortable="true" style="width: 25%">Email</th>
                    <th data-field="NOME" data-sortable="true" style="width: 40%">Nome</th>
                    <th data-field="CELULAR" data-sortable="true" style="width: 25%">Celular</th>
                    <th data-field="NIVEL" data-sortable="true" style="width: 5%">Nivel</th>
                    <th data-field="STATUS" data-sortable="true" style="width: 5%">Status</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="dtr" runat="server" DataSourceID="dts">
                    <ItemTemplate>
                        <tr>
                            <td><a href='<%# "Usuario_Incluir.aspx?EMAIL" + "=" + DataBinder.Eval(Container.DataItem, "EMAIL").ToString %>'><%# DataBinder.Eval(Container.DataItem, "EMAIL").ToString%></a></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "NOME").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "CELULAR").ToString%></td>
                            <td><%# UCase(DataBinder.Eval(Container.DataItem, "NIVEL_DESCRICAO").ToString)%></td>
                            <td><%# UCase(DataBinder.Eval(Container.DataItem, "STATUS").ToString)%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>

    <!-- Modal NOVO -->
    <div class="modal fade" id="NOVO" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="NOVO" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="staticBackdropLabel">Novo Login</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="container container-fluid">

                        <div class="form-floating">
                            <input runat="server" id="EMAIL" type="email" class="form-control text-primary" placeholder="" value="" required="required" />
                            <label for="EMAIL">EMAIL</label>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="reset" class="btn btn-secondary">Limpar</button>
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <button type="submit" class="btn btn-primary">Incluir</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal VISITAR -->


    <%--CORPO DA PAGINA--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
</asp:Content>

