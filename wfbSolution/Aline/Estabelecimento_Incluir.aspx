<%@ Page Title="Estabelecimento" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Estabelecimento_Incluir.aspx.vb" Inherits="Estabelecimento_Incluir" %>

<%@ Register Src="~/Titulo_Pagina.ascx" TagPrefix="uc1" TagName="Titulo_Pagina" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
     <%--Titulo da Página--%>
    <uc1:Titulo_Pagina runat="server" ID="Titulo_Pagina" />
     <%--Data Sources--%>
    <asp:SqlDataSource ID="dts_CLASSES_ESTABELECIMENTOS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />

    <%-- LINKS --%>
    <div class="row g-3">
        <a class="link" data-bs-toggle="collapse" href="#div_CORPO_MEDICOS" role="button" aria-expanded="false" aria-controls="CORPO">Contatos</a>
    </div>
    <%-- LINKS --%>

    <div class="row g-3">
        <%-- CNPJ/NOME_FANTASIA--%>
        <div class="row g-2">
            <%-- CNPJ --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <input runat="server" id="CNPJ" type="text" class="form-control" value="" />
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
            <div class="col-md-10">
                <div class="form-floating">
                    <input runat="server" id="txt_RAZAO_SOCIAL" type="text" class="form-control" value="" disabled="disabled" />
                    <label for="txt_RAZAO_SOCIAL">Razão Social</label>
                </div>
            </div>
            <%-- CLASSE_ESTABELECIMENTO --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="COD_CLASSE_ESTABELECIMENTO" CssClass="form-select" DataSourceID="dts_CLASSES_ESTABELECIMENTOS" DataTextField="CLASSE_ESTABELECIMENTO" DataValueField="COD_CLASSE_ESTABELECIMENTO" required="required"></asp:DropDownList>
                    <label class="text-danger" for="COD_CLASSE_ESTABELECIMENTO">Classe</label>
                </div>
            </div>
        </div>
        <%-- RAZAO_SOCIAL--%>

        <%-- ENDERECO/NUMERO/COMPLEMENTO--%>
        <div class="row g-2">
            <%-- ENDERECO --%>
            <div class="col-md-6">
                <div class="form-floating">
                    <input runat="server" id="txt_ENDERECO" type="text" class="form-control" disabled="disabled" />
                    <label for="txt_ENDERECO">Endereço</label>
                </div>
            </div>
            <%-- NUMERO --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <input runat="server" id="txt_NUMERO" type="text" class="form-control" />
                    <label for="txt_NUMERO">Número</label>
                </div>
            </div>
            <%-- COMPLEMENTO --%>
            <div class="col-md-4">
                <div class="form-floating">
                    <input runat="server" id="txt_COMPLEMENTO" type="text" class="form-control" />
                    <label for="txt_COMPLEMENTO">Complemento</label>
                </div>
            </div>
        </div>
        <%-- ENDERECO/NUMERO/COMPLEMENTO--%>

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

         <%-- COD_CNAE/CNAE_DESCRICAO/COD_NATUREZA_JURIDICA/NATUREZA_JURIDICA_DESCRICAO/SITUACAO_RFB--%>
        <div class="row g-2">
            <%-- COD_CNAE --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <input runat="server" id="txt_COD_CNAE" type="text" class="form-control" value="" disabled="disabled" />
                    <label for="txt_COD_CNAE">Cod CNAE</label>
                </div>
            </div>
             <%-- CNAE --%>
            <div class="col-md-4">
                <div class="form-floating">
                    <input runat="server" id="txt_CNAE_DESCRICAO" type="text" class="form-control" value="" disabled="disabled" />
                    <label for="txt_CNAE_DESCRICAO">CNAE</label>
                </div>
            </div>

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
        </div>
         <%-- COD_CNAE/CNAE_DESCRICAO/COD_NATUREZA_JURIDICA/NATUREZA_JURIDICA_DESCRICAO/SITUACAO_RFB--%>

         <%-- TELEFONE/WHATS_APP/EMAIL/SITE--%>
        <div class="row g-2">
            <%-- TELEFONE --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <input runat="server" id="txt_TELEFONE" type="text" class="form-control" value="" />
                    <label for="txt_TELEFONE">Telefone</label>
                </div>
            </div>
             <%-- WHATS_APP --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <input runat="server" id="txt_WHATS_APP" type="text" class="form-control" value="" />
                    <label for="txt_WHATS_APP">Whats App</label>
                </div>
            </div>

            <%-- EMAIL --%>
            <div class="col-md-4">
                <div class="form-floating">
                    <input runat="server" id="txt_EMAIL" type="text" class="form-control" value=""/>
                    <label for="txt_EMAIL">E-mail</label>
                </div>
            </div>
             <%-- SITE --%>
            <div class="col-md-4">
                <div class="form-floating">
                    <input runat="server" id="txt_SITE" type="text" class="form-control" value=""/>
                    <label for="txt_SITE">Site</label>
                </div>
            </div>
        </div>
        <%-- TELEFONE/WHATS_APP/EMAIL/SITE--%>

        <%-- REPRESENTANTE --%>
        <div class="col-md-2">
            <div class="form-floating">
                <input runat="server" id="txt_REPRESENTANTE" type="text" class="form-control" value="" disabled="disabled" />
                <label for="txt_REPRESENTANTE">Representante</label>
            </div>
        </div>

    <%-- CNPJ/ESTABELECIMENTO/REPRESENTANTE--%>

    <%-- BOTÕES --%>
    <div class="row g-2">
        <div class="col-12">
            <button runat="server" id="cmd_Consultar" type="submit" class="btn btn-primary">Consultar</button>
            <button runat="server" id="cmd_CEP" type="button" class="btn btn-info">Consultar CEP</button>
        </div>
    </div>
    <%-- BOTÕES --%>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
</asp:Content>

