<%@ Page Title="Médico" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Medico_Incluir.aspx.vb" Inherits="Medico_Incluir" %>

<%@ Register Src="~/Titulo_Pagina.ascx" TagPrefix="uc1" TagName="Titulo_Pagina" %>
<%@ Register Src="~/Estabelecimento_Cabecalho.ascx" TagPrefix="uc1" TagName="Estabelecimento_Cabecalho" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%--Titulo da Página--%>
    <uc1:Titulo_Pagina runat="server" ID="Titulo_Pagina" />

    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts_ESPECIALIDADES" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_TIPOS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_FUNCOES" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_VISITAS_AVALIACOES" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_VISITAS_FORMAS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_VISITAS_OBJETIVOS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_VISITAS_LINHA" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_VISITAS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />

    <%--Conteudo--%>
    <uc1:Estabelecimento_Cabecalho runat="server" ID="Estabelecimento_Cabecalho" />
    <%--DIV PRINCIPAL--%>
    <div class="row g-3">

        <%-- UF/CRM/ESPECIALDADE/TIPO--%>
        <div class="row g-2">

            <%-- UF do CRM --%>
            <div class="col-md-1">
                <div class="form-floating">
                    <input runat="server" id="UF_CRM" type="text" class="form-control" maxlength="2" required="required" disabled="disabled" />
                    <label class="text-danger" for="UF_CRM">*UF do CRM</label>
                </div>
            </div>
            <%-- CRM --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <input runat="server" id="CRM" type="text" class="form-control" maxlength="8" required="required" disabled="disabled" />
                    <label class="text-danger" for="*CRM">CRM</label>
                </div>
            </div>
            <%-- ESPECIALIDADE --%>
            <div class="col-md-3">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="ID_ESPECIALIDADE" CssClass="form-select" DataSourceID="dts_ESPECIALIDADES" DataTextField="ESPECIALIDADE" DataValueField="ID_ESPECIALIDADE" required="required"></asp:DropDownList>
                    <label class="text-danger" for="ID_ESPECIALIDADE">*Especialidade de formação</label>
                </div>
            </div>
            <%-- TIPO --%>
            <div class="col-md-3">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="ID_TIPO" CssClass="form-select" DataSourceID="dts_TIPOS" DataTextField="TIPO" DataValueField="ID_TIPO" required="required"></asp:DropDownList>
                    <label class="text-danger" for="ID_TIPO">*Tipo</label>
                </div>
            </div>

            <%-- FUNCAO --%>
            <div class="col-md-3">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="ID_FUNCAO" CssClass="form-select" DataSourceID="dts_FUNCOES" DataTextField="FUNCAO" DataValueField="ID_FUNCAO" required="required"></asp:DropDownList>
                    <label class="text-danger" for="ID_TIPO">*Função no Estabelecimento</label>
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
                    <input runat="server" id="EMAIL" type="email" class="form-control" placeholder="" value="" />
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
        
        
        <div class="row g-2">
            <div class="col-md-12">
                <a class="link" data-bs-toggle="collapse" href="#div_MEDICO_ENDERECO" role="button" aria-expanded="false" aria-controls="div_MEDICO_ENDERECO">Endereço do Médico</a>
            </div>
        </div>
        <div id="div_MEDICO_ENDERECO" class=" row g-2 collapse">

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
        
        </div>

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

        <%-- DIAS DE ATENDIMENTO --%>
        <div class="row g-2">
            <div class="col-md-12">
                <label class="text-muted">Dias Atendimento</label>
            </div>
        </div>
        <div class="row g-2">
            <div class="col-md-12">

                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" value="" id="ATENDE_SEG" runat="server">
                    <label class="form-check-label" for="ATENDE_SEG">SEG</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" value="" id="ATENDE_TER" runat="server">
                    <label class="form-check-label" for="ATENDE_TER">TER</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" value="" id="ATENDE_QUA" runat="server">
                    <label class="form-check-label" for="ATENDE_QUA">QUA</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" value="" id="ATENDE_QUI" runat="server">
                    <label class="form-check-label" for="ATENDE_QUI">QUI</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" value="" id="ATENDE_SEX" runat="server">
                    <label class="form-check-label" for="ATENDE_SEX">SEX</label>
                </div>
            </div>

        </div>
        <%-- DIAS DE ATENDIMENTO --%>

        <%-- BOTÕES --%>
        <div class="row g-2">
            <div class="col-12">
                <button runat="server" id="cmd_Gravar" type="submit" class="btn btn-primary">Gravar</button>
                <button runat="server" id="cmd_CEP" type="button" class="btn btn-info">Consultar CEP</button>
            </div>
        </div>
        <%-- BOTÕES --%>

        <%-- VISITAR --%>
        <!-- Button trigger modal -->
        <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#VISITAR">
            VISITAR
        </button>

        <!-- Modal -->
        <div class="modal fade" id="VISITAR" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="VISITAR" aria-hidden="true">
            <div class="modal-dialog modal-dialog-scrollable">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5" id="staticBackdropLabel">Visitar</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="container container-fluid">

                            <div class="form-floating">
                                <input runat="server" id="VISITA_ESTABELECIMENTO" type="text" class="form-control text-primary" placeholder="" value="" disabled="disabled" />
                                <label for="VISITA_ESTABELECIMENTO">Estabelecimento</label>
                            </div>

                            <div class="form-floating">
                                <input runat="server" id="VISITA_MEDICO" type="text" class="form-control text-primary" placeholder="" value="" disabled="disabled" />
                                <label for="VISITA_MEDICO">Médico</label>
                            </div>

                            <div class="form-floating">
                                <input runat="server" id="VISITA_DATA" type="date" class="form-control" placeholder="" value="<%:Now()%>" />
                                <label for="VISITA_DATA">Data Visita</label>
                            </div>

                            <div class="form-floating">
                                <asp:DropDownList runat="server" ID="VISITA_FORMA" CssClass="form-select" DataSourceID="dts_VISITAS_FORMAS" DataTextField="FORMA" DataValueField="COD_FORMA"></asp:DropDownList>
                                <label class="text-danger" for="VISITA_FORMA">Objetivo</label>
                            </div>

                            <div class="form-floating">
                                <asp:DropDownList runat="server" ID="VISITA_OBJETIVO" CssClass="form-select" DataSourceID="dts_VISITAS_OBJETIVOS" DataTextField="OBJETIVO" DataValueField="COD_OBJETIVO"></asp:DropDownList>
                                <label class="text-danger" for="VISITA_OBJETIVO">Objetivo</label>
                            </div>

                            <div class="form-floating">
                                <asp:DropDownList runat="server" ID="VISITA_LINHA" CssClass="form-select" DataSourceID="dts_VISITAS_LINHA" DataTextField="LINHA" DataValueField="COD_LINHA"></asp:DropDownList>
                                <label class="text-danger" for="VISITA_LINHA">Produto Foco</label>
                            </div>

                            <div class="form-floating">
                                <asp:DropDownList runat="server" ID="VISITA_AVALIACAO" CssClass="form-select" DataSourceID="dts_VISITAS_AVALIACOES" DataTextField="AVALIACAO" DataValueField="COD_AVALIACAO"></asp:DropDownList>
                                <label class="text-danger" for="VISITA_AVALIACAO">Avaliação</label>
                            </div>


                            <div class="form-floating">
                                <textarea runat="server" id="VISITA_OBSERVACOES" class="form-control" maxlength="2048" cols="30" rows="50" wrap="soft"></textarea>
                                <label for="VISITA_OBSERVACOES">Observações</label>
                            </div>


                            <hr />
                            <h5 class="">Agendar Próxima Visita</h5>
                             <div class="form-floating">
                                <input runat="server" id="VISITA_PROXIMA" type="date" class="form-control" placeholder=""  value="<%:Now()%>" />
                                <label for="VISITA_PROXIMA">Próxima Visita</label>
                            </div>


                            <div class="form-floating">
                                <asp:DropDownList runat="server" ID="VISITA_OBJETIVO_PROXIMA" CssClass="form-select" DataSourceID="dts_VISITAS_OBJETIVOS" DataTextField="OBJETIVO" DataValueField="COD_OBJETIVO"></asp:DropDownList>
                                <label class="text-danger" for="VISITA_OBJETIVO_PROXIMA">Objetivo Próxima</label>
                            </div>

                            <div class="form-floating">
                                <textarea runat="server" id="VISITA_OBSERVACOES_PROXIMA" class="form-control" maxlength="2048" cols="30" rows="50" wrap="soft"></textarea>
                                <label for="VISITA_OBSERVACOES_PROXIMA">Observações Próxima</label>
                            </div>

                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="RESET" class="btn btn-secondary">Limpar</button>
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                        <button runat="server" id="cmd_Gravar_Visita" type="submit" class="btn btn-primary">Gravar</button>
                    </div>
                </div>
            </div>
        </div>
        <%-- VISITAR --%>

        <%-- ATIVAR/INATIVAR --%>
        <a class="link" data-bs-toggle="collapse" href="#ATIVAR" role="button" aria-expanded="false" aria-controls="ATIVAR">Ativar/Inativar Médico</a>
        <div class="collapse" id="ATIVAR">

            <input runat="server" class="form-check-input" type="checkbox" value="" id="ATIVO">
            <label class="form-check-label" for="ATIVO">ATIVO</label>
        </div>
        <%-- ATIVAR/INATIVAR --%>
    </div>
    <%--DIV PRINCIPAL--%>
    <script>
        $('#VISITAR').on('show.bs.modal', function () {
            $('#VISITAR input').val = '';
        })</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
    
    
</asp:Content>

