<%@ Page Title="Novo Estabelecimento" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Estabelecimento_Incluir.aspx.vb" Inherits="Estabelecimento_Incluir" %>

<%@ Register Src="~/Titulo_Pagina.ascx" TagPrefix="uc1" TagName="Titulo_Pagina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%--Titulo da Página--%>
    <uc1:Titulo_Pagina runat="server" ID="Titulo_Pagina" />
    <%--Data Sources--%>

    <%-- LINKS --%>
    <div class="row g-3">
    </div>
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

        <%-- ENDERECO/COMPLEMENTO--%>
        <div class="row g-2">
            <%-- ENDERECO --%>
            <div class="col-md-8">
                <div class="form-floating">
                    <input runat="server" id="txt_ENDERECO" type="text" class="form-control" disabled="disabled" />
                    <label for="txt_ENDERECO">Endereço</label>
                </div>
            </div>
            <%-- NUMERO --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <input runat="server" id="txt_NUMERO" type="text" class="form-control" disabled="disabled" />
                    <label for="txt_NUMERO">Numero</label>
                </div>
            </div>
            <%-- COMPLEMENTO --%>
            <div class="col-md-2">
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


        <%-- LATITUDE/LONGITUDE/PLUSCODE --%>
        <div class="row g-2">
            <%-- LATITUDE --%>
            <div class="col-md-4">
                <div class="form-floating">
                    <input runat="server" id="txt_LATITUDE" type="text" class="form-control" value="" disabled="disabled" />
                    <label for="txt_LATITUDE">Geo Latitude</label>
                </div>
            </div>
            <%-- LONGITUDE --%>
            <div class="col-md-4">
                <div class="form-floating">
                    <input runat="server" id="txt_LONGITUDE" type="text" class="form-control" value="" disabled="disabled" />
                    <label for="txt_LONGITUDE">Geo Longitude</label>
                </div>
            </div>
            <%-- PLUS_CODE --%>
            <div class="col-md-4">
                <div class="form-floating">
                    <input runat="server" id="txt_PLUSCODE" type="text" class="form-control" value="" disabled="disabled" />
                    <label for="txt_PLUSCODE">Geo Plus Code</label>
                </div>
            </div>
        </div>
        <%-- LATITUDE/LONGITUDE/PLUSCODE --%>

        <%-- COD_NATUREZA_JURIDICA/NATUREZA_JURIDICA_DESCRICAO/CNAE/CNAE_DESCRICAO --%>
        <div class="row g-2">
            <%-- COD_NATUREZA_JURIDICA --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <input runat="server" id="txt_COD_NATUREZA_JURIDICA" type="text" class="form-control" value="" disabled="disabled" />
                    <label for="txt_COD_NATUREZA_JURIDICA">Cod Natureza</label>
                </div>
            </div>
            <%-- NATUREZA_JURIDICA_DESCRICAO --%>
            <div class="col-md-4">
                <div class="form-floating">
                    <input runat="server" id="txt_NATUREZA_JURIDICA_DESCRICAO" type="text" class="form-control" value="" disabled="disabled" />
                    <label for="txt_NATUREZA_JURIDICA_DESCRICAO">Natureza Jurídica</label>
                </div>
            </div>
            <%-- CNAE --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <input runat="server" id="txt_CNAE" type="text" class="form-control" value="" disabled="disabled" />
                    <label for="txt_cnae">CNAE</label>
                </div>
            </div>
            <%-- CNAE_DESCRICAO --%>
            <div class="col-md-4">
                <div class="form-floating">
                    <input runat="server" id="txt_CNAE_DESCRICAO" type="text" class="form-control" value="" disabled="disabled" />
                    <label for="txt_CNAE_DESCRICAO">CNAE Descrição</label>
                </div>
            </div>
        </div>
        <%-- COD_NATUREZA_JURIDICA/NATUREZA_JURIDICA_DESCRICAO --%>

        <%-- ATIVIDADE_ECONOMICA_ID/ATIVIDADE_ECONOMICA_DESCRICAO/DATA_FUNDACAO/SITUACAO --%>
        <div class="row g-2">
            <%-- COD_ATIVIDADE_ECONOMICA --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <input runat="server" id="txt_COD_ATIVIDADE_ECONOMICA" type="text" class="form-control" value="" disabled="disabled" />
                    <label for="txt_COD_ATIVIDADE_ECONOMICA">Cod Atividade</label>
                </div>
            </div>
            <%-- ATIVIDADE_ECONOMICA --%>
            <div class="col-md-6">
                <div class="form-floating">
                    <input runat="server" id="txt_ATIVIDADE_ECONOMICA" type="text" class="form-control" value="" disabled="disabled" />
                    <label for="txt_ATIVIDADE_ECONOMICA">Atividade</label>
                </div>
            </div>
            <%-- DATA_FUNDACAO --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <input runat="server" id="txt_DATA_FUNDACAO" type="text" class="form-control" value="" disabled="disabled" />
                    <label for="txt_ DATA_FUNDACAO">Fundacao</label>
                </div>
            </div>
            <%-- SITUACAO_RFB --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <input runat="server" id="txt_SITUACAO_RFB" type="text" class="form-control" value="" disabled="disabled" />
                    <label for="txt_SITUACAO_RFB">Situacao</label>
                </div>
            </div>
        </div>
        <%-- ATIVIDADE_ECONOMICA_ID/ATIVIDADE_ECONOMICA_DESCRICAO/DATA_FUNDACAO/SITUACAO --%>

        <%-- BOTÕES --%>
        <div class="row g-2">
            <div class="col-12">
                <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#CONSULTAR_CNPJ">Novo</button>
                <button runat="server" id="cmd_Gravar" type="submit" class="btn btn-info">Gravar</button>
            </div>
        </div>
        <%-- BOTÕES --%>

        <!-- Modal CONSULTAR_CNPJ -->
        <div class="modal fade" id="CONSULTAR_CNPJ" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="CONSULTAR _CNPJ" aria-hidden="true">
            <div class="modal-dialog modal-dialog-scrollable">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5" id="staticBackdropLabel">Consultar CNPJ</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="container container-fluid">
                            <div class="form-floating">
                                <input runat="server" id="CNPJ_CONSULTAR" type="text" class="form-control text-primary" placeholder="" value="" required="required" />
                                <label for="CNPJ_CONSULTAR">CNPJ</label>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="RESET" class="btn btn-secondary">Limpar</button>
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                        <button runat="server" id="cmd_Consultar_CNPJ" type="submit" class="btn btn-primary">Consultar CNPJ</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- Modal CONSULTAR_CNPJ -->
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
</asp:Content>

