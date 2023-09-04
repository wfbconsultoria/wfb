<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Medico.aspx.vb" Inherits="DoutorCRM.Medico" %>

<%@ Register Src="~/App_Controls/ScriptsHeader.ascx" TagPrefix="uc1" TagName="ScriptsHeader" %>
<%@ Register Src="~/App_Controls/ScriptsFooter.ascx" TagPrefix="uc1" TagName="ScriptsFooter" %>
<%@ Register Src="~/App_Controls/PageHeader.ascx" TagPrefix="uc1" TagName="PageHeader" %>
<%@ Register Src="~/App_Controls/PageFooter.ascx" TagPrefix="uc1" TagName="PageFooter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <uc1:ScriptsHeader runat="server" ID="ScriptsHeader" />
    <title>Médico</title>
</head>
<body class="container">
    <form id="form1" runat="server">
        <uc1:PageHeader runat="server" ID="PageHeader" />
        <h4 class="text-secondary text-uppercase"><%:Page.Title %></h4>
        <!-- Conteudo da pagina -->
        <div id="PageContent">
            
            <asp:SqlDataSource ID="dts_UF" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [UF], [ESTADO] FROM [TBL_UF] ORDER BY [ESTADO]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dts_ESPECIALIDADES" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [ESPECIALIDADE] FROM [TBL_MEDICOS_ESPECIALIDADES] ORDER BY [ESPECIALIDADE]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dts_PERFIS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [PERFIL] FROM [TBL_MEDICOS_PERFIS] ORDER BY [PERFIL]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dts_USUARIOS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [EMAIL], [NOME] FROM [TBL_USUARIOS] ORDER BY [NOME]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dts_PERIODOS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [PERIODO] FROM [TBL_PERIODOS_ATENDIMENTO] ORDER BY [PERIODO]"></asp:SqlDataSource>

            <%--UF/CRM/ESPECIALIDADE/PERFIL--%>
            <div class="form-row">
                 <%-- CRMUF--%>
                <div class="form-group col-sm-4">
                    <label class="text-danger">CRM-UF</label>
                    <input runat="server" id="CRMUF" type="text" maxlength="10" class="form-control" readonly="readonly" />
                </div>
                
                <%-- UF--%>
                <%--<div class="form-group col-sm-2">
                    <label class="text-danger">*UF</label>
                    <asp:DropDownList ID="UF_CRM" runat="server" CssClass="form-control" DataSourceID="dts_UF" DataTextField="UF" DataValueField="UF" Enabled="False"></asp:DropDownList>
                </div>--%>
                <%-- CRM--%>
                <%--<div class="form-group col-sm-2">
                    <label class="text-danger">*CRM</label>
                    <input runat="server" id="CRM" type="text" maxlength="7" class="form-control" required="required" placeholder="CRM 0000000" onfocus="this.value='';" onkeypress="return somenteNumeros(event)" />
                </div>--%>
                <%-- Especialidade--%>
                <div class="form-group col-sm-4">
                    <label>Especialidade</label>
                    <asp:DropDownList ID="ESPECIALIDADE" runat="server" class="form-control" DataSourceID="dts_ESPECIALIDADES" DataTextField="ESPECIALIDADE" DataValueField="ESPECIALIDADE"></asp:DropDownList>
                </div>
                <%-- Perfil--%>
                <div class="form-group col-sm-4">
                    <label>Perfil</label>
                    <asp:DropDownList ID="PERFIL" runat="server" class="form-control" DataSourceID="dts_PERFIS" DataTextField="PERFIL" DataValueField="PERFIL"></asp:DropDownList>
                </div>
            </div>
            <%--/UF/CRM/ESPECIALIDADE/PERFIL--%>

            <%--NOME/DATA NASCIMENTO--%>
            <div class="form-row">
                <%-- Nome--%>
                <div class="form-group col-sm-10">
                    <label class="text-danger">*Nome</label>
                    <input runat="server" id="NOME" type="text" maxlength="256" class="form-control" required="required" />
                </div>
                <%--Data Nascimento--%>
                <div class="form-group col-md-2">
                    <label>Nascimento</label>
                    <input id="DATA_NASCIMENTO" runat="server" type="text" autocomplete="off" maxlength="10" class="form-control" placeholder="Data dd/mm/aaaa" onkeypress="formatar('##/##/####', this);" onblur="validaDat(this,this.value);" />
                </div>
            </div>
            <%--/NOME/DATA NASCIMENTO--%>

            <%--CPF/CPF_STATUS/NOME_CPF--%>
            <div class="form-row">
                <%--CPF--%>
                <div class="form-group col-md-4">
                    <label>CPF</label>
                    <div class="input-group">
                        <div class="custom-file">
                            <input id="CPF" runat="server" type="text" autocomplete="off" maxlength="14" class="form-control" placeholder="CPF 000.000.000-00" onkeypress="formatar('###.###.###-##', this)" />
                        </div>
                        <div class="input-group-append">
                            <input runat="server" type="button" id="cmd_ConsultaCPF" value="Validar" class="btn btn-secondary" />
                        </div>
                    </div>
                </div>
                <%--CPF Status--%>
                <div class="form-group col-md-2">
                    <label>Situação</label>
                    <input id="CPF_STATUS" runat="server" type="text" autocomplete="off" class="form-control" placeholder="INVALIDO" readonly="readonly" />
                </div>
                <%--Nome no CPF--%>
                <div class="form-group col-md-6">
                    <label>Nome no CPF</label>
                    <input id="NOME_CPF" runat="server" type="text" autocomplete="off" maxlength="256" class="form-control" placeholder="Nome valido conforme CPF" readonly="readonly" />
                </div>
            </div>
            <%--/CPF/CPF_STATUS/NOME_CPF--%>

            <%--EMAIL/TELEFONE/CELULAR--%>
            <div class="form-row">
                <%--Email--%>
                <div class="form-group col-md-4">
                    <label>E-mail</label>
                    <input id="EMAIL" runat="server" type="email" autocomplete="off" maxlength="256" class="form-control" placeholder="E-mail" />
                </div>
                <%--Telefone--%>
                <div class="form-group col-md-4">
                    <label>Telefone</label>
                    <input id="TELEFONE" runat="server" type="text" autocomplete="off" maxlength="64" class="form-control" placeholder="Telefone" />
                </div>
                <%--Celular--%>
                <div class="form-group col-md-4">
                    <label>Celular</label>
                    <input id="CELULAR" runat="server" type="text" autocomplete="off" maxlength="64" class="form-control" placeholder="Celular" />
                </div>
            </div>
            <%--/EMAIL/TELEFONE/CELULAR--%>

            <%--CEP/ENDERECO--%>
            <div class="form-row">
                <%--CEP--%>
                <div class="form-group col-md-2">
                    <label>CEP</label>
                    <div class="input-group">
                        <div class="custom-file">
                            <input id="CEP" runat="server" type="text" autocomplete="off" maxlength="8" class="form-control" placeholder="00000000" onkeypress="return somenteNumeros(event)" />
                        </div>
                        <div class="input-group-append">
                            <input runat="server" type="button" id="cmd_ConsultaCEP" value="Busca" class="btn btn-secondary" />
                        </div>
                    </div>
                </div>
                <%--Endereço--%>
                <div class="form-group col-md-10">
                    <label>Endereço</label>
                    <input id="ENDERECO" runat="server" type="text" autocomplete="off" maxlength="512" class="form-control" placeholder="Endereço" readonly="readonly" />
                </div>
            </div>
            <%--/CEP/ENDERECO--%>

            <%--NUMERO/COMPLEMENTO/BAIRRO--%>
            <div class="form-row">
                <%--Numero--%>
                <div class="form-group col-md-2">
                    <label>Número</label>
                    <input id="NUMERO" runat="server" type="text" autocomplete="off" maxlength="32" class="form-control" placeholder="Número" />
                </div>
                <%--Complemento--%>
                <div class="form-group col-md-4">
                    <label>Complemento</label>
                    <input id="COMPLEMENTO" runat="server" type="text" autocomplete="off" maxlength="128" class="form-control" placeholder="Complemento" />
                </div>
                <%--Bairro--%>
                <div class="form-group col-md-6">
                    <label>Bairro</label>
                    <input id="BAIRRO" runat="server" type="text" autocomplete="off" maxlength="256" class="form-control" placeholder="Bairro" readonly="readonly" />
                </div>
            </div>
            <%--/NUMERO/COMPLEMENTO/BAIRRO--%>

            <%--CIDADE/ESTADO--%>
            <div class="form-row">
                <%--Cidade--%>
                <div class="form-group col-md-10">
                    <label>Cidade</label>
                    <input id="CIDADE" runat="server" type="text" autocomplete="off" maxlength="256" class="form-control" placeholder="Cidade" readonly="readonly" />
                </div>
                <%--UF--%>
                <div class="form-group col-md-2">
                    <label>UF</label>
                    <input id="UF" runat="server" type="text" autocomplete="off" class="form-control" placeholder="UF" readonly="readonly" />
                </div>
            </div>
            <%--/CIDADE/ESTADO--%>

            <%--PERIODOS ATENDIMENTO--%>
            <div class="form-row">
                <%-- SEGUNDA--%>
                <div class="form-group col-sm-2">
                    <label>Segunda</label>
                    <asp:DropDownList ID="ATENDE_SEGUNDA" runat="server" CssClass="form-control" DataSourceID="dts_PERIODOS" DataTextField="PERIODO" DataValueField="PERIODO"></asp:DropDownList>
                </div>
                <%-- TERCA--%>
                <div class="form-group col-sm-2">
                    <label>Terça</label>
                    <asp:DropDownList ID="ATENDE_TERCA" runat="server" CssClass="form-control" DataSourceID="dts_PERIODOS" DataTextField="PERIODO" DataValueField="PERIODO"></asp:DropDownList>
                </div>
                <%-- QUARTA--%>
                <div class="form-group col-sm-2">
                    <label>Quarta</label>
                    <asp:DropDownList ID="ATENDE_QUARTA" runat="server" CssClass="form-control" DataSourceID="dts_PERIODOS" DataTextField="PERIODO" DataValueField="PERIODO"></asp:DropDownList>
                </div>
                <%-- QUINTA--%>
                <div class="form-group col-sm-2">
                    <label>Quinta</label>
                    <asp:DropDownList ID="ATENDE_QUINTA" runat="server" CssClass="form-control" DataSourceID="dts_PERIODOS" DataTextField="PERIODO" DataValueField="PERIODO"></asp:DropDownList>
                </div>
                <%-- SEXTA--%>
                <div class="form-group col-sm-2">
                    <label>Sexta</label>
                    <asp:DropDownList ID="ATENDE_SEXTA" runat="server" CssClass="form-control" DataSourceID="dts_PERIODOS" DataTextField="PERIODO" DataValueField="PERIODO"></asp:DropDownList>
                </div>
                <%-- SABADO--%>
                <div class="form-group col-sm-2">
                    <label>Sábado</label>
                    <asp:DropDownList ID="ATENDE_SABADO" runat="server" CssClass="form-control" DataSourceID="dts_PERIODOS" DataTextField="PERIODO" DataValueField="PERIODO"></asp:DropDownList>
                </div>
            </div>
            <%--/PERIODOS ATENDIMENTO--%>

            <%--COMENTARIOS--%>
            <div class="form-row">
                <%-- Comentários--%>
                <div class="form-group col-sm-12">
                    <label>Observações</label>
                    <textarea runat="server" id="COMENTARIOS" type="text" class="form-control" rows="2" maxlength="2048" />
                </div>
            </div>

            <%--REPRESENTANTE/DATA CADASTRO--%>
            <div class="form-row">
                <%--EMAIL REPRESENTANTE--%>
                <div class="form-group col-sm-6">
                    <label>Atendido por</label>
                    <input runat="server" id="EMAIL_REPRESENTANTE" type="text" maxlength="256" class="form-control" readonly="readonly" />
                </div>
                <%--DATA CADASTRO--%>
                <div class="form-group col-sm-6">
                    <label>Data Inclusão</label>
                    <input runat="server" id="DATA_CADASTRO" type="text" maxlength="128" class="form-control" readonly="readonly" />
                </div>
            </div>
            <%--/REPRESENTANTE/DATA CADASTRO--%>

            <%-- botoes de de comando--%>
            <input runat="server" id="cmd_Save" type="submit" value="Gravar" class="btn btn-primary" />&nbsp;
            <input id="cmd_Cancel" type="reset" value="Cancelar" class="btn btn-light" />&nbsp;
            <a href="Medicos_Lista.aspx" class="btn btn-link btn-light">Lista</a>
            <a href="Medico_Consulta_CRM.aspx" class="btn btn-link btn-light">Novo</a>
            
        </div>
        <!-- Conteudo da pagina -->

        <uc1:PageFooter runat="server" ID="PageFooter" />
    </form>
    <uc1:ScriptsFooter runat="server" ID="ScriptsFooter" />
</body>
</html>
