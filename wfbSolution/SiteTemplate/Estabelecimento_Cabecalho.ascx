<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Estabelecimento_Cabecalho.ascx.vb" Inherits="Estabelecimento_Cabecalho" %>

<%-- DIV MENSAGEM --%>
<div runat="server" id="div_MENSAGEM_ESTABELECIMENTO" class="row g-3 card card-body">
    <div class="row g-2">
        <div class="col-md-12">
            <h4 class="text-danger">Você deve selecionar um estabelecimento na página Meus Estabelecimentos</h4>
            <a href="Estabelecimentos.aspx">Ir para Meus EStabelecimentos</a>
        </div>
    </div>
</div>

<%-- DIV PRINCIPAL --%>
<div runat="server" id="div_PRINCIPAL_ESTABELECIMENTO" class="row g-3">

    <%-- CNPJ/ESTABELECIMENTO/REPRESENTANTE--%>
    <div id="div_CABECALHO_ESTABELECIMENTO" class="row g-2">

        <%-- ESTABELECIMENTO --%>
        <div class="col-md-8">
            <div class="form-floating">
                <input runat="server" id="txt_ESTABELECIMENTO" type="text" class="form-control" value="" disabled="disabled" />
                <label for="txt_ESTABELECIMENTO">Estabelecimento</label>
            </div>
        </div>
        <%-- REPRESENTANTE --%>
        <div class="col-md-2">
            <div class="form-floating">
                <input runat="server" id="txt_REPRESENTANTE" type="text" class="form-control" value="" disabled="disabled" />
                <label for="txt_REPRESENTANTE">Representante</label>
            </div>
        </div>
        <%-- CNPJ --%>
        <div class="col-md-2">
            <div class="form-floating">
                <input runat="server" id="txt_CNPJ" type="text" class="form-control" value="" disabled="disabled" />
                <label for="txt_CNPJ">CNPJ</label>
            </div>
        </div>
    </div>
    <%-- CNPJ/ESTABELECIMENTO/REPRESENTANTE--%>

    <div class="col-md-12">
        <a class="link" data-bs-toggle="collapse" href="#div_CORPO_ESTABELECIMENTO" role="button" aria-expanded="false" aria-controls="CORPO">Exibir/Ocultar Endereço</a>
    </div>

    <%-- CORPO --%>
    <div id="div_CORPO_ESTABELECIMENTO" class="collapse">
        <%-- CEP/ENDERECO/BAIRRO/CIDADE/UF--%>
        <div id="div_ENDERECO" class="row g-2">

            <%-- ENDERECO --%>
            <div class="col-md-5">
                <div class="form-floating">
                    <input runat="server" id="txt_ENDERECO" type="text" class="form-control" disabled="disabled" />
                    <label for="txt_ENDERECO">Endereço</label>
                </div>
            </div>
            <%-- BAIRRO --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <input runat="server" id="txt_BAIRRO" type="text" class="form-control" disabled="disabled" />
                    <label for="txt_BAIRRO">Bairro</label>
                </div>
            </div>
            <%-- CEP --%>
            <div class="col-md-1">
                <div class="form-floating">
                    <input runat="server" id="txt_CEP" type="text" class="form-control" disabled="disabled" />
                    <label for="txt_CEP">CEP</label>
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
        <%-- CEP/ENDERECO/BAIRRO/CIDADE/UF--%>
    </div>
    <%-- CORPO --%>
</div>
<%-- DIV PRINCIPAL --%>
<hr />



