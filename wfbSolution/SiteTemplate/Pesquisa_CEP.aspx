<%@ Page Title="Pesquisa CEP" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Pesquisa_CEP.aspx.vb" Inherits="Pesquisa_CEP" %>

<%@ Register Src="~/Titulo_Pagina.ascx" TagPrefix="uc1" TagName="Titulo_Pagina" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%--Titulo da Página--%>
    <uc1:Titulo_Pagina runat="server" ID="Titulo_Pagina" />

    <%--Data Sources--%>

    <div class="row g-3">

        <%-- LINKS --%>
        <div class="row g-2">
        </div>
        <%-- LINKS --%>

        <%-- CEP/ENDERECO/NUMERO--%>
        <div class="row g-2">
            <%-- CEP --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <input runat="server" id="CEP" type="text" class="form-control" maxlength="8" placeholder="00000000" onfocus="limpa_endereco();" onkeypress="return somenteNumeros(event)" />
                    <label for="CEP">CEP</label>
                </div>
            </div>
            <%-- ENDERECO --%>
            <div class="col-md-8">
                <div class="form-floating">
                    <input runat="server" id="LOGRADOURO" type="text" class="form-control" placeholder="" value="" disabled="disabled" />
                    <label for="LOGRADOURO">Endereço</label>
                </div>
            </div>
            <%-- NUMERO --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <input runat="server" id="NUMERO" type="text" class="form-control" placeholder="" value="" />
                    <label for="NUMERO">Número</label>
                </div>
            </div>
        </div>
        <%-- CEP/ENDERECO/NUMERO--%>

        <%-- COMPLEMENTO/BAIRRO--%>
        <div class="row g-2">
            <%-- COMPLEMENTO --%>
            <div class="col-md-6">
                <div class="form-floating">
                    <input runat="server" id="COMPLEMENTO" type="text" class="form-control" placeholder="" value="" />
                    <label for="COMPLEMENTO">Complemento</label>
                </div>
            </div>
            <%-- BAIRRO --%>
            <div class="col-md-6">
                <div class="form-floating">
                    <input runat="server" id="BAIRRO" type="text" class="form-control" placeholder="" disabled="disabled" />
                    <label for="BAIRRO">Bairro</label>
                </div>
            </div>
        </div>
        <%-- COMPLEMENTO/BAIRRO --%>

        <%-- COD_IBGE_7/CIDADE/UF --%>
        <div class="row g-2">

            <%-- COD_IBGE_7 --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <input runat="server" id="COD_IBGE_7" type="text" class="form-control" placeholder="" value="" disabled="disabled" />
                    <label for="COD_IBGE_7">Cod IBGE</label>
                </div>
            </div>
            <%-- CIDADE --%>
            <div class="col-md-8">
                <div class="form-floating">
                    <input runat="server" id="CIDADE" type="text" class="form-control" placeholder="" value="" disabled="disabled" />
                    <label for="CIDADE">Cidade</label>
                </div>
            </div>
            <%-- UF --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <input runat="server" id="UF" type="text" class="form-control" placeholder="" value="" disabled="disabled" />
                    <label for="UF">UF</label>
                </div>
            </div>
        </div>
        <%-- COD_IBGE_7/CIDADE/UF --%>

        <%-- BOTÕES --%>
        <div class="row g-2">
            <div class="col-md-12">
                <div class="input-group">
                    <button runat="server" id="cmd_CEP" type="button" class="btn btn-info form-control">Consultar CEP</button>
                </div>
            </div>
        </div>
        <%-- BOTÕES --%>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
</asp:Content>

