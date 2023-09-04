<%@ Page Title="Estabelecimentos" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EstablishmentDetails.aspx.cs" Inherits="EstablishmentDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head_Content" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body_Content" runat="Server">
    <div class="container">
        <!-- Titulo -->
        <h2 class="pt-2 text-center"><%: Page.Title %></h2>

        <div class="row mt-5">
            <div class="col-md-12">
                <!-- Razão Social -->
                <b>Razão Social:</b><br />
                <label id="lblRazaoSocial" runat="server"></label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <!-- Nome Fantasia -->
                <b>Nome Fantasia:</b><br />
                <label id="lblNomeFantasia" runat="server"></label>
            </div>
        </div>
    <div class="row">
        <div class="col-md-4">
            <!-- Documento -->
            <b>Documento:</b><br />
            <label id="lblDocumento" runat="server"></label>
        </div>
        <div class="col-md-4">
            <!-- Capital -->
            <b>Capital:</b><br />
            <label id="lblCapital" runat="server"></label>
        </div>
        <div class="col-md-4">
            <!-- Data Fundação -->
            <b>Data Fundação:</b><br />
            <label id="lblDataFundacao" runat="server"></label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <!-- Código Natureza Juridica -->
            <b>Código Natureza Juridica:</b><br />
            <label id="lblCodNatJuridica" runat="server"></label>
        </div>
        <div class="col-md-8">
            <!-- Descrição Natureza Juridica -->
            <b>Descrição Natureza Juridica:</b><br />
            <label id="lblDesNatJuridica" runat="server"></label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <!-- Situação RFB -->
            <b>Situação RFB:</b><br />
            <label id="lblSituacaoRFB" runat="server"></label>
        </div>
        <div class="col-md-4">
            <!-- Data Situação RFB -->
            <b>Data Situação RFB:</b><br />
            <label id="lblDataSitRFB" runat="server"></label>
        </div>
        <div class="col-md-4">
            <!-- Consulta Situação RFB -->
            <b>Consulta Situação RFB:</b><br />
            <label id="lblConSitRFB" runat="server"></label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <!-- Motivo Situação RFB -->
            <b>Motivo Situação RFB:</b><br />
            <label id="lblMotSitRFB" runat="server"></label>
        </div>
        <div class="col-md-4">
            <!-- Motivo Especial Situação RFB -->
            <b>Motivo Especial Situação RFB:</b><br />
            <label id="lblMotEspSitRFB" runat="server"></label>
        </div>
        <div class="col-md-4">
            <!-- Data Motivo Especial Situacao RFB -->
            <b>Data Motivo Esp. Situação RFB:</b><br />
            <label id="lblDataMotEspSitRFB" runat="server"></label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <!-- Código CNAE -->
            <b>Código CNAE:</b><br />
            <label id="lblCodCNAE" runat="server"></label>
        </div>
        <div class="col-md-9">
            <!-- Descrição CNAE -->
            <b>Descrição CNAE</b><br />
            <label id="lblDesCNAE" runat="server"></label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-8">
            <!-- Logradouro -->
            <b>Logradouro:</b><br />
            <label id="lblLogradouro" runat="server"></label>
        </div>
        <div class="col-md-4">
            <!-- Tipo -->
            <b>Tipo:</b> <br />
            <label id="lblTipo" runat="server"></label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-8">
             <!-- Complemento -->
            <b>Complemento:</b><br />
            <label id="lblComplemento" runat="server"></label>
        </div>
        <div class="col-md-4">
            <!-- Número -->
            <b>Número:</b> <br />
            <label id="lblNumero" runat="server"></label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <!-- CEP -->
            <b>CEP:</b><br />
            <label id="lblCep" runat="server"></label>
        </div>
        <div class="col-md-6">
            <!-- Bairro -->
            <b>Bairro:</b><br />
            <label id="lblBairro" runat="server"></label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <!-- Cidade -->
            <b>Cidade:</b><br />
            <label id="lblCidade" runat="server"></label>
        </div>
        <div class="col-md-6">
            <!-- Estado -->
            <b>Estado:</b><br />
            <label id="lblEstado" runat="server"></label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <!-- Data de Atualização -->
            <b>Data de Atualização:</b><br />
            <label id="lblDataAtualizacao" runat="server"></label>
        </div>
        <div class="col-md-6">
            <!-- Código IBGE -->
            <b>Código IBGE:</b><br />
            <label id="lblCodIbge" runat="server"></label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <!-- Latitude -->
            <b>Latitude:</b><br />
            <label id="lblLatitude" runat="server"></label>
        </div>
        <div class="col-md-6">
            <!-- Longitude -->
            <b>Longitude:</b><br />
            <label id="lblLongitude" runat="server"></label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <!-- E-mail -->
            <b>E-mail:</b><br />
            <label id="lblEmail" runat="server"></label>
        </div>
        <div class="col-md-6">
            <!-- Telefone -->
            <b>Telefone:</b><br />
            <label id="lblTelefone" runat="server"></label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <!-- Status -->
            <b>Status:</b><br />
            <label id="lblStatus" runat="server"></label>
        </div>
    </div>
    
    <!-- Botões -->
    <div class="row">
        <div class="col-md-12">
            <!-- Imprimir -->
            <a id="btnPrint" class="btn btn-sm btn-primary text-light" onclick="window.print()" title="Clique aqui para imprimir as informações do estabelecimento">Imprimir</a>
            <!-- Voltar -->
            <a id="btnReturn" runat="server" class="btn btn-sm btn-secondary" onserverclick="btnReturn_Click" title="Clique para voltar e pesquisar outros estabelecimentos"></a>
        </div>
    </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer_Content" runat="Server">
</asp:Content>

