<%@ Page Title="Consultar CEP" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Address_Search.aspx.vb" Inherits="BiPh.Address_Search" %>

<%@ Register Src="~/Page_Header.ascx" TagPrefix="uc1" TagName="Page_Header" %>
<%@ Register Src="~/Page_Footer.ascx" TagPrefix="uc1" TagName="Page_Footer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head_Content" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Body_Content" runat="server">
    <!--Cabeçalho da página -->
    <uc1:Page_Header runat="server" ID="Page_Header" />

    <%--Conteudo da página--%>
    <div>

        <%--Mensagens--%>
        <p runat="server" id="PageMessages" class="text-info"></p>
        <%--Mensagens--%>

        <%--CEP/ENDERECO/NUMERO--%>
        <div class="form-row">

            <%--CEP--%>
            <div class="form-group col-md-2">
                <label for="txt_Address_ZIP" class="text-danger">CEP</label>
                <input id="txt_Address_ZIP" runat="server" type="text" required="required" autocomplete="off" maxlength="9" class="form-control" placeholder="CEP 00000-000" onfocus="this.value=''" onkeypress="formatar('#####-###', this)" />
            </div>
            <%--/CEP--%>

            <%--Endereço--%>
            <div class="form-group col-md-8">
                <label for="txt_Address">Endereço</label>
                <input id="txt_Address" runat="server" type="text" autocomplete="off" maxlength="200" class="form-control" placeholder="Endereço" readonly="readonly" />
            </div>
            <%--/Endereço--%>

            <%--Numero--%>
            <div class="form-group col-md-2">
                <label for="txt_Address_Number">Número</label>
                <input id="txt_Address_Number" runat="server" type="text" required="required" autocomplete="off" maxlength="30" class="form-control" placeholder="Número" />
            </div>
            <%--/Numero--%>
        </div>
        <%--CEP/ENDERECO/NUMERO--%>

        <%--COMPLEMENTO/BAIRRO--%>
        <div class="form-row">

            <%--Complemento--%>
            <div class="form-group col-md-6">
                <label for="txt_Address_Complement">Complemento</label>
                <input id="txt_Address_Complement" runat="server" type="text" autocomplete="off" maxlength="50" class="form-control" placeholder="Complemento" />
            </div>
            <%--/Complemento--%>

            <%--Bairro--%>
            <div class="form-group col-md-6">
                <label for="txt_Address_District">Bairro</label>
                <input id="txt_Address_District" runat="server" type="text" autocomplete="off" class="form-control" placeholder="Bairro" readonly="readonly" />
            </div>
            <%--/Bairro--%>
        </div>
        <%--/COMPLEMENTO/BAIRRO--%>

        <%--CIDADE/ESTADO--%>
        <div class="form-row">

            <%--Cod Cidade IBGE--%>
            <div class="form-group col-md-2">
                <label for="txt_Address_City_Code">Cod Cidade</label>
                <input id="txt_Address_City_Code" runat="server" type="text" autocomplete="off" class="form-control" placeholder="Cod IBGE" readonly="readonly" />
            </div>
            <%--/Cod Cidade IBGE--%>

            <%--Cidade--%>
            <div class="form-group col-md-8">
                <label for="txt_Address_City">Cidade</label>
                <input id="txt_Address_City" runat="server" type="text" autocomplete="off" class="form-control" placeholder="Cidade" readonly="readonly" />
            </div>
            <%--/Cidade--%>

            <%--UF--%>
            <div class="form-group col-md-2">
                <label for="txt_Address_State">UF</label>
                <input id="txt_Address_State" runat="server" type="text" autocomplete="off" class="form-control" placeholder="UF" readonly="readonly" />
            </div>
            <%--/UF--%>

        </div>
        <%--/CIDADE/ESTADO--%>

        <%--Botões e links--%>
        <div class="text-right">
            <input runat="server" type="button" id="cmd_ConsultaCEP" value="Consultar CEP" class="btn btn-secondary" />
            <input runat="server" type="button" id="cmd_Save" value="Gravar" class="btn btn-success" />
        </div>
        <%--/Botões e links--%>
    </div>
    <%--END Conteudo da página--%>

    <uc1:Page_Footer runat="server" ID="Page_Footer" />
    <!--Datasources -->
    <asp:SqlDataSource ID="dtsUser" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>'></asp:SqlDataSource>
</asp:Content>
