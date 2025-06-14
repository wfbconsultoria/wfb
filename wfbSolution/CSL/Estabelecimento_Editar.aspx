<%@ Page Title="Estabelecimento Editar" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Estabelecimento_Editar.aspx.vb" Inherits="Estabelecimento_Editar" %>

<%@ Register Src="~/Titulo_Pagina.ascx" TagPrefix="uc1" TagName="Titulo_Pagina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%--Titulo da Página--%>
    <uc1:Titulo_Pagina runat="server" ID="Titulo_Pagina" />

    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts_GRUPOS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_GRUPOS_DISTRIBUIDORES" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_CLASSES" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_SETORIZACAO_INCLUIR" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_SETORIZACAO_EXCLUIR" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_SETORIZACAO" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />

    <%-- LINKS --%>

    <%-- LINKS --%>
    <br />


    <div class="row g-3">
        <%-- CNPJ/NOME_FANTASIA--%>
        <div class="row g-2">
            <%-- CNPJ --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <input runat="server" id="CNPJ" type="text" class="form-control" value="" disabled="disabled" />
                    <label for="CNPJ">CNPJ</label>
                </div>
            </div>
            <%-- NOME_FANTASIA --%>
            <div class="col-md-10">
                <div class="form-floating">
                    <input runat="server" id="txt_NOME_FANTASIA" type="text" class="form-control" value="" />
                    <label for="txt_NOME_FANTASIA">Nome Fantasia</label>
                </div>
            </div>
            <%-- <div class="col-md-2">
                <a class=" form-control btn btn-outline-primary" data-bs-toggle="collapse" href="#CABECALHO" role="button" aria-expanded="false" aria-controls="CABECALHO">&nbsp mais... &nbsp</a>&nbsp&nbsp
            </div>--%>
        </div>
        <%-- CNPJ/NOME_FANTASIA--%>

        <%-- RAZAO_SOCIAL--%>
        <div class="row g-2">
            <div class="col-md-12">
                <div class="form-floating">
                    <input runat="server" id="txt_RAZAO_SOCIAL" type="text" class="form-control" value="" disabled="disabled" />
                    <label for="txt_RAZAO_SOCIAL">Razão Social</label>
                </div>
            </div>
        </div>
        <%-- RAZAO_SOCIAL--%>

        <%-- GRUPO/CLASSE --%>
        <div class="row g-2">
            <%-- GRUPO --%>
            <div class="col-md-4">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="GRUPO_ESTABELECIMENTO_ID" CssClass="form-select" DataSourceID="dts_GRUPOS" DataTextField="GRUPO_ESTABELECIMENTO" DataValueField="GRUPO_ESTABELECIMENTO_ID"></asp:DropDownList>
                    <label for="GRUPO_ESTABELECIMENTO_ID">Grupo</label>
                </div>
            </div>

            <%-- GRUPO DISTRIBUIDOR --%>
            <div class="col-md-4">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="GRUPO_DISTRIBUIDOR_ID" CssClass="form-select" DataSourceID="dts_GRUPOS_DISTRIBUIDORES" DataTextField="GRUPO_DISTRIBUIDOR" DataValueField="GRUPO_DISTRIBUIDOR_ID"></asp:DropDownList>
                    <label for="GRUPO_DISTRIBUIDOR_ID">Grupo Distribuidor</label>
                </div>
            </div>

            <%-- CLASSE --%>
            <div class="col-md-4">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="CLASSE_ESTABELECIMENTO_ID" CssClass="form-select" DataSourceID="dts_CLASSES" DataTextField="CLASSE_ESTABELECIMENTO" DataValueField="CLASSE_ESTABELECIMENTO_ID"></asp:DropDownList>
                    <label for="CLASSE_ESTABELECIMENTO_ID">Classe</label>
                </div>
            </div>
        </div>
        <%-- GRUPO/CLASSE --%>

        <%-- ENDERECO/COMPLEMENTO--%>
        <div class="row g-2">
            <%-- ENDERECO --%>
            <div class="col-md-8">
                <div class="form-floating">
                    <input runat="server" id="txt_ENDERECO" type="text" class="form-control" disabled="disabled" />
                    <label for="txt_ENDERECO">Endereço</label>
                </div>
            </div>
            <%-- COMPLEMENTO --%>
            <div class="col-md-4">
                <div class="form-floating">
                    <input runat="server" id="txt_COMPLEMENTO" type="text" class="form-control" disabled="disabled" />
                    <label for="txt_COMPLEMENTO">Complemento</label>
                </div>
            </div>
        </div>
        <%-- ENDERECO/COMPLEMENTO--%>

        <%-- CEP/BAIRRO/COD_IBGE_7/CIDADE/UF--%>
        <div class="row g-2">
            <%-- CEP --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <input runat="server" id="txt_CEP" type="text" class="form-control" disabled="disabled" />
                    <label for="txt_CEP">CEP</label>
                </div>
            </div>
            <%-- BAIRRO --%>
            <div class="col-md-4">
                <div class="form-floating">
                    <input runat="server" id="txt_BAIRRO" type="text" class="form-control" disabled="disabled" />
                    <label for="txt_BAIRRO">Bairro</label>
                </div>
            </div>
            <%-- COD_IBGE_7 --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <input runat="server" id="txt_COD_IBGE_7" type="text" class="form-control" disabled="disabled" />
                    <label for="txt_COD_IBGE_7">Cod IBGE(7)</label>
                </div>
            </div>
            <%-- CIDADE --%>
            <div class="col-md-3">
                <div class="form-floating">
                    <input runat="server" id="txt_CIDADE" type="text" class="form-control" disabled="disabled" />
                    <label for="txt_CIDADE">Cidade</label>
                </div>
            </div>
            <%-- UF --%>
            <div class="col-md-1">
                <div class="form-floating">
                    <input runat="server" id="txt_UF" type="text" class="form-control" disabled="disabled" />
                    <label for="txt_UF">UF</label>
                </div>
            </div>
        </div>
        <%-- CEP/BAIRRO/COD_IBGE_7/CIDADE/UF--%>

        <%-- ESFERA/NATUREZA_JURIDICA_DESCRICAO/CNAE --%>
        <div class="row g-2">
            <%-- ESFERA --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <input runat="server" id="txt_ESFERA" type="text" class="form-control" value="" disabled="disabled" />
                    <label for="txt_ESFERA">Esfera</label>
                </div>
            </div>
            <%-- NATUREZA_JURIDICA_DESCRICAO --%>
            <div class="col-md-4">
                <div class="form-floating">
                    <input runat="server" id="txt_NATUREZA_JURIDICA" type="text" class="form-control" value="" disabled="disabled" />
                    <label for="txt_NATUREZA_JURIDICA">Natureza Jurídica</label>
                </div>
            </div>
            <%-- CNAE --%>
            <div class="col-md-6">
                <div class="form-floating">
                    <input runat="server" id="txt_CNAE_COD" type="text" class="form-control" value="" disabled="disabled" />
                    <label for="txt_CNAE_COD">Atividade</label>
                </div>
            </div>
        </div>
        <%-- COD_NATUREZA_JURIDICA/NATUREZA_JURIDICA/CNAE --%>

        <hr />
        <h5>Setorização</h5>
        <%-- SETORIZACAO INCLUIR/EXCLUIR --%>
        <div class="row g-2">
            <%-- INCLUIR --%>
            <div class="col-md-6">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="SETORIZACAO_INCLUIR" CssClass="form-select" DataSourceID="dts_SETORIZACAO_INCLUIR" DataTextField="SETOR" DataValueField="Id"></asp:DropDownList>
                    <label for="SETORIZACAO_INCLUIR" class="text-primary">Incluir</label>
                </div>
            </div>
            <%-- EXCLUIR --%>
            <div class="col-md-6">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="SETORIZACAO_EXCLUIR" CssClass="form-select" DataSourceID="dts_SETORIZACAO_EXCLUIR" DataTextField="SETOR" DataValueField="Id"></asp:DropDownList>
                    <label for="SETORIZACAO_EXCLUIR" class="text-danger">Excluir</label>
                </div>
            </div>
        </div>
        <%-- SETORIZACAO INCLUIR/EXCLUIR --%>

        <%-- SETORIZACAO TABELA --%>
        <div class="row g-2">

            <table id="table"
                class="table table-bordered table-hover"
                data-toggle="table"
                <%--data-search="true"--%>
                <%--data-search-align="left"--%>
                <%--data-search-accent-neutralise="true"--%>
                <%--data-search-highlight="true"--%>
                <%--data-show-search-clear-button="true"--%>
                <%--data-show-toggle="true"--%>
                <%--data-show-columns="true"--%>
                <%--data-show-columns-toggle-all="true"--%>
                <%--data-show-fullscreen="true"--%>
                <%--data-show-pagination-switch="true"--%>
                data-sortable="true"
                <%--data-pagination="true"--%>
                data-mobile-responsive="true">
                <thead>
                    <tr>
                        <th data-field="Setor_SETOR" data-sortable="true" style="width: 40%">Setor</th>
                        <th data-field="Setor_RESPONSAVEL" data-sortable="true" style="width: 60%">Responsável</th>

                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="dtr_SETORIZACAO" runat="server" DataSourceID="dts_SETORIZACAO">
                        <ItemTemplate>
                            <tr>
                                <td><a href='<%# "Setorizacao_Representantes_Incluir.aspx?Id" + "=" + DataBinder.Eval(Container.DataItem, "Id_Setor").ToString %>'><%# DataBinder.Eval(Container.DataItem, "Setor_SETOR").ToString%></a></td>
                                <td><%# DataBinder.Eval(Container.DataItem, "Setor_RESPONSAVEL").ToString%></td>

                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <%-- SETORIZACAO TABELA --%>

        <%-- BOTÕES --%>
        <div class="row g-2">
            <div class="col-12">
                <input id="cmd_Save" type="submit" value="Gravar" class="btn btn-primary" />
                <a class="btn btn-info" href="Estabelecimentos.aspx">Lista</a>
            </div>
        </div>
         <a class="text-danger" data-bs-toggle="modal" href="#modalEXCLUIR">Excluir</a>
        <%-- BOTÕES --%>
    </div>
    <br />


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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
</asp:Content>

