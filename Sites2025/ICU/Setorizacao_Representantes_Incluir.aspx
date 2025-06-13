<%@ Page Title="Setor" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Setorizacao_Representantes_Incluir.aspx.vb" Inherits="Setorizacao_Representantes_Incluir" %>

<%@ Register Src="~/Titulo_Pagina.ascx" TagPrefix="uc1" TagName="Titulo_Pagina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%--Titulo da Página--%>
    <uc1:Titulo_Pagina runat="server" ID="Titulo_Pagina" />
    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts_REGIONAIS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_ESTABELECIMENTOS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_EMAIL_RESPONSAVEL" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_ATIVO" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />

    <%--CORPO DA PAGINA--%>
    <div class="row g-3">
        <%-- SETOR --%>
        <div class="row g-2">
            <div class="col-md-4">
                <div class="form-floating">
                    <input runat="server" id="SETOR" type="text" class="form-control" placeholder="" value="" required="required" />
                    <label for="SETOR">Setor</label>
                </div>
            </div>
        </div>

        <%-- EMAIL_RESPONSAVEL --%>
        <div class="row g-2">
            <div class="col-md-4">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="EMAIL_RESPONSAVEL" CssClass="form-select" DataSourceID="dts_EMAIL_RESPONSAVEL" DataTextField="NOME" DataValueField="EMAIL" required="required"></asp:DropDownList>
                    <label for="NIVEL">Responsavel</label>
                </div>
            </div>
        </div>

        <%-- REGIONAL --%>
        <div class="row g-2">
            <div class="col-md-4">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="Id_REGIONAL" CssClass="form-select" DataSourceID="dts_REGIONAIS" DataTextField="REGIONAL" DataValueField="Id" required="required"></asp:DropDownList>
                    <label for="NIVEL">Regional</label>
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
                    <a href="Setorizacao_Representantes_Lista.aspx" class="btn btn-info">Lista</a>
                    <a href="Setorizacao_Representantes_Incluir.aspx?Id=NOVO" class="btn btn-info">Novo</a>
                    <input id="cmd_Save" type="submit" value="Gravar" class="btn btn-primary" />
                </div>
            </div>
        </div>
        <%-- OCULTOS Id --%>
        <div class="row g-2">
            <input runat="server" id="Id" type="hidden" class="form-control" placeholder="" value="" />
        </div>
        <a class="text-danger" data-bs-toggle="modal" href="#modalEXCLUIR">Excluir</a>
        <%-- BOTÕES --%>

        <%-- TABELA ESTABELECIMENTOS --%>

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
                        <th data-field="Estabelecimento_CNPJ" data-sortable="true" style="width: 10%">CNPJ</th>
                        <th data-field="Estabelecimento_NOME_FANTASIA" data-sortable="true" style="width: 35%">Cliente</th>
                        <th data-field="Estabelecimento_MUNICIPIO_UF" data-sortable="true" style="width: 15%">Cidade</th>
                        <th data-field="Estabelecimento_UF" data-sortable="true" style="width: 5%">UF</th>
                        <th data-field="Estabelecimento_ESFERA" data-sortable="true" style="width: 10%">Esfera</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="dtr" runat="server" DataSourceID="dts_ESTABELECIMENTOS">
                        <ItemTemplate>
                            <tr>
                                <td><a href='<%# "Estabelecimento_Editar.aspx?idEstabelecimento" + "=" + DataBinder.Eval(Container.DataItem, "Id_Estabelecimento").ToString %>'><%# DataBinder.Eval(Container.DataItem, "Estabelecimento_CNPJ").ToString%></a></td>
                                <td><%# DataBinder.Eval(Container.DataItem, "Estabelecimento_NOME_FANTASIA").ToString%></td>
                                <td><%# DataBinder.Eval(Container.DataItem, "Estabelecimento_MUNICIPIO_UF").ToString%></td>
                                <td><%# UCase(DataBinder.Eval(Container.DataItem, "Estabelecimento_UF").ToString)%></td>
                                <td><%# UCase(DataBinder.Eval(Container.DataItem, "Estabelecimento_ESFERA").ToString)%></td>
                                
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <%-- TABELA ESTABELECIMENTOS --%>
        </div>
        <%--CORPO DA PAGINA--%>

        <!-- Modal EXCLUIR -->
        <div class="modal fade" id="modalEXCLUIR" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="modalEXCLUIR" aria-hidden="true">
            <div class="modal-dialog modal-dialog-scrollable">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5" id="staticBackdropLabel">Close</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="container container-fluid">
                            <div class="form-floating">
                                <input runat="server" id="EXCLUIR" type="text" class="form-control text-primary" placeholder="" value="" required="required" disabled="disabled" />
                                <label for="EXCLUIR">EXCLUIR?</label>
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
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
</asp:Content>
