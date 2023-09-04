<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Cadastrar_Manual.aspx.vb" Inherits="Cadastrar_Manual" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastro Manual</title>
    <style>

    </style>
</head>
<body>
    <uc1:Cabecalho runat="server" ID="Cabecalho" />
    <form id="frm_cadastrom" runat="server">
        <div class="container">
            <div class="jumbotron">
                <!----------------------------------------------------------------------------------------------------------------------------- Campos -------------------------------------------------------------------------------------------------------------------------------------->
                <h1 style="font-size: 30px;">Cadastro Manual de Estabelecimentos</h1>
                <h2>Todos os campos com <span style="color: rgba(255, 0, 0,.7)">*</span> ao lado são obrigatórios</h2>
                <table style="margin-left: 10%;">
                    <!-- CNPJ -->
                    <tr>
                        <td class="nomes">CNPJ OU CPF</td>
                        <td class="txtbox">
                            <asp:TextBox ID="txt_cnpj" runat="server" type='number' Style="color: black; width: 80%; height: 30px; border: 1px solid rgba(0,0,0,.5); border-radius: 3px; margin-bottom: 1%;" placeholder="  Preencher com o CNPJ do Cliente (Não coloque zero como primeiro número)"></asp:TextBox>
                            &nbsp&nbsp *  
                        </td>
                    </tr>
                    <!-- TIPO de Pessoa -->
                    <tr>
                        <td class="nomes">Tipo de Pessoa</td>
                        <td class="txtbox">
                            <select id="slc_tipo_pessoa" runat="server" class="campos" disabled="disabled">
                                <option value="">Escolha uma opção</option>
                                <option value="1">Jurídica</option>
                                <option value="2">Física</option>
                            </select>
                            &nbsp&nbsp * &nbsp<asp:Button ID="btn_verificar" CssClass="btn btn-primary" runat="server" Text="Verificar" style="margin-right: 1%;"/>
                        </td>
                    </tr>
                    <!-- Campos Pessoa Fisica -->
                    <asp:Panel ID="Painel_PF" runat="server">

                    <!-- Razao Social -->
                    <tr class="esconder">
                        <td class="nomes">Razão Social</td>
                        <td class="txtbox">
                            <asp:TextBox ID="txt_razao_social" runat="server" class="campos" placeholder="  Digite a razão social da empresa"></asp:TextBox>
                            &nbsp&nbsp *
                        </td>
                    </tr>

                    <!-- Estado -->
                    <tr class="esconder">
                        <td class="nomes">Estado</td>
                        <td class="txtbox">
                            <asp:DropDownList ID="dpd_estados" runat="server" DataSourceID="dts_estados" DataTextField="UF" DataValueField="UF" CssClass="campos" AutoPostBack="True"></asp:DropDownList>
                            &nbsp&nbsp *
                            <asp:SqlDataSource runat="server" ID="dts_estados" ConnectionString='<%$ ConnectionStrings:cnnStr %>' SelectCommand="SELECT [UF], [ESTADO] FROM [TBL_MUNICIPIOS_ESTADOS] ORDER BY [ESTADO]"></asp:SqlDataSource>
                        </td>
                    </tr>
                    <!-- CIDADE -->
                    <tr class="esconder">
                        <td class="nomes">Cidade</td>
                        <td class="txtbox">
                            <asp:DropDownList ID="dpd_cidades" runat="server" DataSourceID="dts_cidades" DataTextField="MUNICIPIO" DataValueField="COD_MUNICIPIO" CssClass="campos" AutoPostBack="True"></asp:DropDownList>
                            &nbsp&nbsp *
                            <asp:SqlDataSource runat="server" ID="dts_cidades" ConnectionString='<%$ ConnectionStrings:cnnStr %>' SelectCommand="SELECT [COD_MUNICIPIO], [MUNICIPIO] FROM [TBL_MUNICIPIOS] WHERE ([UF] = @IBGE_UF) ORDER BY [CAPITAL] DESC, [MUNICIPIO]">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="dpd_estados" PropertyName="SelectedValue" Name="IBGE_UF" Type="String"></asp:ControlParameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <!-- COD IBGE -->
                    <tr class="esconder">
                        <td class="nomes">Código IBGE</td>
                        <td class="txtbox">
                        <asp:TextBox ID="txt_cod_ibge" runat="server" class="campos" Enabled="false" Style="width: 80%; height: 30px; border: 1px solid rgba(0,0,0,.5); border-radius: 3px; color: black;  margin-bottom: 1%;"></asp:TextBox>
                        &nbsp&nbsp *
                        </td>
                    </tr>
                    </asp:Panel>

                    <!--- Campos Pessoa Juridica -->
                    <asp:Panel ID="pnl_cadastrar" runat="server">


                    <!-- Nome Fantasia -->
                    <tr class="esconder">
                        <td class="nomes">Nome Fantasia</td>
                        <td class="txtbox">
                            <asp:TextBox ID="txt_nome_fantasia" runat="server" class="campos" placeholder="  Digite o nome fantasia da empresa"></asp:TextBox>
                            &nbsp&nbsp *
                        </td>
                    </tr>

                    <!-- Data Fundacao -->
                    <tr class="esconder">
                        <td class="nomes">Data Fundação</td>
                        <td class="txtbox">
                            <asp:TextBox ID="txt_data_fundacao" runat="server" class="campos" type='number' placeholder="Digite a data de fundação da empresa, Somente Numeros"></asp:TextBox>
                        </td>
                    </tr>

                    <!-- Logradouro -->
                    <tr class="esconder">
                        <td class="nomes">Logradouro</td>
                        <td class="txtbox">
                            <asp:TextBox ID="txt_logradouro" runat="server" class="campos" placeholder="  Digite o logradouro onde a empresa reside"></asp:TextBox>
                            &nbsp&nbsp *
                        </td>
                    </tr>

                    <!-- Numero -->
                    <tr class="esconder">
                        <td class="nomes">Número</td>
                        <td class="txtbox">
                            <asp:TextBox ID="txt_numero" runat="server" type='number' class="campos" placeholder="  Digite o número do local onde a empresa reside"></asp:TextBox>
                            &nbsp&nbsp *
                        </td>
                    </tr>

                    <!-- Complemento -->
                    <tr class="esconder">
                        <td class="nomes">Complemento</td>
                        <td><asp:TextBox ID="txt_complemento" runat="server" class="campos" placeholder="  Caso não tenha complemento manter vazio"></asp:TextBox></td>
                    </tr>

                    <!-- Bairro -->
                    <tr class="esconder">
                        <td class="nomes">Bairro</td>
                        <td class="txtbox">
                            <asp:TextBox ID="txt_bairro" runat="server" class="campos" placeholder="  Digite o bairro em que a empresa reside"></asp:TextBox>
                            &nbsp&nbsp *
                        </td>
                    </tr>

                    <!-- CEP -->
                    <tr class="esconder">
                        <td class="nomes">CEP</td>
                        <td class="txtbox">
                                <asp:TextBox ID="txt_cep" runat="server" type='number' class="campos" placeholder="  Digite a CEP onde a empresa reside Ex: 08596000"></asp:TextBox> &nbsp&nbsp *
                        </td>
                    </tr>


                    <!-- Natureza Juridica Descrição -->
                    <tr class="esconder">
                    <td class="nomes">Natureza Jurídica Descrição</td>
                        <td class="txtbox">
                            <asp:DropDownList ID="dpd_Natura_Descricao" runat="server" DataSourceID="dts_Natureza_descricao" DataTextField="NATUREZA_JURIDICA" DataValueField="NATUREZA_JURIDICA" CssClass="campos" AutoPostBack="True"></asp:DropDownList>
                            <asp:SqlDataSource runat="server" ID="dts_Natureza_descricao" ConnectionString='<%$ ConnectionStrings:cnnStr %>' SelectCommand="SELECT NATUREZA_JURIDICA, COD_NATUREZA_JURIDICA  FROM TBL_RF_NATUREZA_JURIDICA ORDER BY NATUREZA_JURIDICA"></asp:SqlDataSource>
                        </td>
                    </tr>
                        

                    <!-- COD Natureza Juridica -->
                    <tr class="esconder">
                        <td class="nomes">Código Natureza Jurídica</td>
                        <td class="txtbox">
                            <asp:TextBox ID="txt_cod_natureza_juridica" runat="server" class="campos" Enabled="false" ></asp:TextBox>&nbsp&nbsp *
                        </td>
                    </tr>


                    <!-- COD CNAE -->
                    <tr class="esconder">
                    <td class="nomes">Código CNAE</td>
                        <td class="txtbox">
                            <asp:TextBox ID="txt_cod_cnae" runat="server" class="campos" placeholder="  Digite o código CNAE(Classificação nacional de atividades ecônomicas) da empresa"></asp:TextBox> &nbsp&nbsp *
                        </td>
                    </tr>

                    <!-- CNAE Descricao -->
                    <tr class="esconder">
                        <td class="nomes">CNAE Descrição</td>
                        <td class="txtbox">
                            <asp:TextBox ID="txt_cnae_descricao" runat="server" class="campos" placeholder="  Digite a descrição CNAE da empresa"></asp:TextBox> &nbsp&nbsp *
                        </td>
                    </tr>

                    <!-- Inclusão e-mail -->
                    <tr class="esconder">
                        <td class="nomes">Inclusão E-mail</td>
                        <td class="txtbox">
                            <asp:DropDownList ID="dpd_inclusao_email" runat="server" DataSourceID="dts_inclusao_email" DataTextField="EMAIL" DataValueField="EMAIL" CssClass="campos" AutoPostBack="True"></asp:DropDownList>
                            <asp:SqlDataSource runat="server" ID="dts_inclusao_email" ConnectionString='<%$ ConnectionStrings:cnnStr %>' SelectCommand="SELECT EMAIL FROM VW_USUARIOS"></asp:SqlDataSource>
                        </td>
                    </tr>

                    </asp:Panel>
                    <!-- Botões -->
                    <tr class="esconder">
                        <td><asp:Button ID="btn_cadastrar" CssClass="btn btn-primary" runat="server" Text="Cadastrar" class="botoes" Style="margin: 10px auto" /></td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
    <asp:Literal ID="ltr_teste" runat="server"></asp:Literal>
</body>
</html>