<%@ Page Title="Incluir Médico" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="_Templates_Form.aspx.vb" Inherits="_Templates_Form" %>

<%@ Register Src="~/Titulo_Pagina.ascx" TagPrefix="uc1" TagName="Titulo_Pagina" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%--Titulo da Página--%>
    <uc1:Titulo_Pagina runat="server" ID="Titulo_Pagina" />
    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts_ESTABELECIMENTO" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_UF" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_ESPECIALIDADES" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_TIPOS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />

    <%--DIV PRINCIPAL--%>
    <div class="row g-3">

        <%--Conteudo--%>
       <%-- <asp:Repeater ID="dtr_ESTABELECIMENTO" runat="server" DataSourceID="dts_ESTABELECIMENTO">
            <ItemTemplate>--%>

                <%-- CNPJ/ESTABELECIMENTO/REPRESENTANTE--%>
                <div class="row g-2">

                    <%-- ESTABELECIMENTO --%>
                    <div class="col-md-6">
                        <div class="form-floating">
                            <input runat="server" id="ESTABELECIMENTO" type="text" class="form-control" value="" disabled="disabled" />
                            <label for="ESTABELECIMENTO">Estabelecimento</label>
                        </div>
                    </div>
                    <%-- REPRESENTANTE --%>
                    <div class="col-md-4">
                        <div class="form-floating">
                            <input runat="server" id="REPRESENTANTE" type="text" class="form-control" value="" disabled ="disabled" />
                            <label for="REPRESENTANTE">Representante</label>
                        </div>
                    </div>
                    <%-- CNPJ --%>
                    <div class="col-md-2">
                        <div class="form-floating">
                            <input runat="server" id="CNPJ" type="text" class="form-control" placeholder="" value="" disabled="disabled" />
                            <label for="CNPJ">CNPJ</label>
                        </div>
                    </div>

                </div>
                <%-- CNPJ/ESTABELECIMENTO/REPRESENTANTE--%>
           <%-- </ItemTemplate>
        </asp:Repeater>--%>

        <%-- UF/CRM/ESPECIALDADE/TIPO--%>
        <div class="row g-2">

            <%-- UF do CRM --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="UF_CRM" CssClass="form-select" DataSourceID="dts_UF" DataTextField="ESTADO" DataValueField="UF" required="required"></asp:DropDownList>
                    <label class="text-danger" for="UF_CRM">*UF do CRM</label>
                </div>
            </div>
            <%-- CRM --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <input runat="server" id="CRM" type="text" class="form-control" maxlength="8" placeholder="00000000" required="required" onfocus="this.value='';" onkeypress="return somenteNumeros(event)" />
                    <label class="text-danger" for="*CRM">CRM</label>
                </div>
            </div>
            <%-- ESPECIALIDADE --%>
            <div class="col-md-4">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="ID_ESPECIALIDADE" CssClass="form-select" DataSourceID="dts_ESPECIALIDADES" DataTextField="ESPECIALIDADE" DataValueField="ID_ESPECIALIDADE" required="required"></asp:DropDownList>
                    <label class="text-danger" for="ID_ESPECIALIDADE">*Especialidade</label>
                </div>
            </div>
            <%-- TIPO --%>
            <div class="col-md-4">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="ID_TIPO" CssClass="form-select" DataSourceID="dts_TIPOS" DataTextField="TIPO" DataValueField="ID_TIPO" required="required"></asp:DropDownList>
                    <label class="text-danger" for="ID_TIPO">*Tipo</label>
                </div>
            </div>

        </div>
        <%-- UF/CRM/ESPECIALDADE/TIPO--%>


        <%-- NOME/SOBRENOME--%>
        <div class="row g-2">

            <%-- NOME --%>
            <div class="col-md-4">
                <div class="form-floating">
                    <input runat="server" id="NOME" type="text" class="form-control" placeholder="" value="" required="required" />
                    <label class="text-danger" for="NOME">*Nome</label>
                </div>
            </div>
            <%-- SOBRENOME --%>
            <div class="col-md-8">
                <div class="form-floating">
                    <input runat="server" id="SOBRENOME" type="text" class="form-control" value="" placeholder="" />
                    <label for="SOBRENOME">Sobrenome</label>
                </div>
            </div>

        </div>
        <%-- NOME/SOBRENOME--%>


        <%-- EMAIL/CELULAR/TELEFONE--%>
        <div class="row g-2">

            <%-- EMAIL --%>
            <div class="col-md-4">
                <div class="form-floating">
                    <input runat="server" id="EMAIL" type="email" class="form-control" placeholder="" value=""/>
                    <label for="EMAIL">E-Mail</label>
                </div>
            </div>
            <%-- CELULAR --%>
            <div class="col-md-4">
                <div class="form-floating">
                    <input runat="server" id="CELULAR" type="tel" class="form-control" placeholder="" value="" />
                    <label for="CELULAR">Celular</label>
                </div>
            </div>
            <%-- TELEFONE --%>
            <div class="col-md-4">
                <div class="form-floating">
                    <input runat="server" id="TELEFONE" type="text" class="form-control" placeholder="" value="" />
                    <label for="TELEFONE">Telefone</label>
                </div>
            </div>

        </div>
        <%-- EMAIL/CELULAR/TELEFONE--%>


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
                    <input runat="server" id="ENDERECO" type="text" class="form-control" placeholder="" value="" disabled="disabled" />
                    <label for="ENDERECO">Endereço</label>
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


        <%-- OBSERVAÇÕES --%>
        <div class="row g-2">
            <div class="col-md-12">
                <div class="form-floating">
                    <textarea runat="server" id="OBSERVACOES" class="form-control" placeholder="" maxlength="2048"></textarea>
                    <label for="OBSERVACOES">Observações</label>
                </div>
            </div>
        </div>
        <%-- OBSERVAÇÕES --%>

        <%-- BOTÕES --%>
        <div class="row g-2">
            <div class="col-12">
                <button runat="server" id="cmd_Gravar" type="submit" class="btn btn-primary">Incluir</button>
                <button runat="server" id="cmd_CEP" type="button" class="btn btn-info">CEP</button>
            </div>
            <%-- BOTÕES --%>
        </div>

    </div>
    <%--DIV PRINCIPAL--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
    
</asp:Content>

