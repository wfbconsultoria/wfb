<%@ Page Title="Medico Incluir" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Medico_Incluir.aspx.vb" Inherits="Medico_Incluir" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts_UF" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_ESPECIALIDADES" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_TIPOS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />

    <%--Titulo da Pagina--%>
    <h4 class="text-secondary text-uppercase" style="padding-top: 5px"><%:Page.Title %></h4>

    <%-- UF/CRM/ESPECIALDADE/TIPO--%>
    <div class="row">

        <%-- UF --%>
        <div class="form-group col-md-2">
            <label for="cmb_UF_CRM">UF do CRM</label>
            <asp:DropDownList runat="server" ID="cmb_CRM_UF" CssClass="form-select" DataSourceID="dts_UF" DataTextField="ESTADO" DataValueField="UF" Enabled="true"></asp:DropDownList>
        </div>

        <%-- CRM --%>
        <div class="form-group col-md-2">
            <label for="txt_CRM">CRM</label>
            <input runat="server" id="txt_CRM" type="text" class="form-control" maxlength="7" placeholder="0000000" required="required" onfocus="this.value='';" onkeypress="return somenteNumeros(event)" />
        </div>

        <%-- ESPECIALIDADE --%>
        <div class="form-group col-md-4">
            <label for="cmb_ID_ESPECIALIDADE">Especialidade</label>
            <asp:DropDownList runat="server" ID="cmb_ID_ESPECIALIDADE" CssClass="form-select" DataSourceID="dts_ESPECIALIDADES" DataTextField="ESPECIALIDADE" DataValueField="ID_ESPECIALIDADE" Enabled="true"></asp:DropDownList>
        </div>

        <%-- TIPO --%>
        <div class="col-md-4">
            <label for="CMB_ID_TIPO">Tipo</label>
            <asp:DropDownList runat="server" ID="CMB_ID_TIPO" CssClass="form-select" DataSourceID="dts_TIPOS" DataTextField="TIPO" DataValueField="ID_TIPO" Enabled="true"></asp:DropDownList>
        </div>

    </div>
    <%-- UF/CRM/ESPECIALDADE/TIPO--%>


    <%--NOME/SOBRENOME --%>
    <div class="row g-3">

        <div class="col-md-4">
            <label for="txt_NOME" class="form-label">Nome</label>
            <input runat="server" id="txt_NOME" type="text" class="form-control" value="" required>
        </div>

        <div class="col-md-8">
            <label for="txt_SOBRENOME" class="form-label">Sobrenome</label>
            <input runat="server" type="text" class="form-control" id="txt_SOBRENOME" value="" required>
        </div>

    </div>
    <%-- nome e sobrenome --%>

    <%-- cep e endereço --%>
    <div class="row g-3 needs-validation">

        <div class="col-md-2">
            <label for="validationDefault05" class="form-label">CEP</label>
            <input type="text" class="form-control" id="txt_CEP" required>
        </div>

        <div class="col-md-8">
            <label for="txt_LOGRADOURO" class="form-label">Endereco</label>
            <input runat="server" type="text" class="form-control" id="txt_ENDERECO" required>
        </div>
        <div class="col-md-2">
            <label for="txt_NUMERO" class="form-label">Número</label>
            <input runat="server" type="text" class="form-control" id="txt_NUMERO" required>
        </div>

    </div>
    <%-- cep e endereço --%>

    <%-- bairro complemento --%>
    <div class="row g-3">

        <div class="col-md-4">
            <label for="txt_BAIRRO" class="form-label">Bairro</label>
            <input type="text" class="form-control" id="txt_BAIRRO">
        </div>

        <div class="col-md-8">
            <label for="txt_COMPLEMENTO" class="form-label">Complemento</label>
            <input type="text" class="form-control" id="txt_COMPLEMENTO">
        </div>

    </div>
    <%-- bairro complemento --%>

    <%-- cod IBGE cidade uf --%>
    <div class="row">

        <div class="col-md-2">
            <label for="txt_COD_IBGE_7" class="form-label">Cod IBGE</label>
            <input runat="server" type="text" class="form-control" id="Text1" required>
        </div>

        <div class="col-md-8">
            <label for="txt_CIDADE" class="form-label">Cidade</label>
            <input runat="server" type="text" class="form-control" id="txt_CIDADE" required>
        </div>

        <div class="col-md-2">
            <label for="txt_UF" class="form-label">UF</label>
            <input runat="server" type="text" class="form-control" id="txt_UF" required>
        </div>

    </div>
    <%-- cod IBGE cidade uf --%>



    <div class="row g-3">

        <%-- BOTÃO--%>
        <div class="col-md-2">
            <button runat="server" id="cmd_Incluir" type="submit" class="form-control btn btn-primary">Incluir</button>
        </div>
    </div>
  

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
</asp:Content>

