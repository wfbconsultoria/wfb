<%@ Page Title="Meus Estabelecimentos" Language="VB" CodeFile="Estabelecimentos_Localizar.aspx.vb" Inherits="Estabelecimentos_Localizar" %>

<%@ Register Src="~/ScriptsFooter.ascx" TagPrefix="uc1" TagName="ScriptsFooter" %>
<%@ Register Src="~/ScriptsHeader.ascx" TagPrefix="uc1" TagName="ScriptsHeader" %>
<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- Cabeçalho -->
        <uc1:Cabecalho runat="server" ID="Cabecalho" />
        <!-- Java script -->
        <uc1:ScriptsHeader runat="server" ID="ScriptsHeader" />
        <script>
            /* função para recuperar query string com js */
            function GetQueryString(a) {
                a = a || window.location.search.substr(1).split('&').concat(window.location.hash.substr(1).split("&"));

                if (typeof a === "string")
                    a = a.split("#").join("&").split("&");

                // se não há valores, retorna um objeto vazio
                if (!a) return {};

                var b = {};
                for (var i = 0; i < a.length; ++i) {
                    // obtem array com chave/valor
                    var p = a[i].split('=');

                    // se não houver valor, ignora o parametro
                    if (p.length != 2) continue;

                    // adiciona a propriedade chave ao objeto de retorno
                    // com o valor decodificado, substituindo `+` por ` `
                    // para aceitar URLs codificadas com `+` ao invés de `%20`
                    b[p[0]] = decodeURIComponent(p[1].replace(/\+/g, " "));
                }
                // retorna o objeto criado
                return b;
            }

            /* função para atualizar página */
            function atualizar(valor) {
                //Variavel para pegar query string
                var qs = GetQueryString();
                //Redirecionando
                window.location.href = 'Estabelecimentos_Localizar.aspx?de=' + qs['de'] + '&ate=' + valor;
            }
        </script>

        <!-- Conteudo -->
        <div class="container">

            <!-- titulo -->
            <div class="row">
                <div class="col-md-12">
                    <div id="Titulo_Pagina_Cabecalho">Clientes</div>

                    <div id="Titulo_Pagina_Links">
                        <asp:HyperLink ID="lnk_Estabelecimentos_Pesquisa_RF" runat="server" NavigateUrl="~/Estabelecimentos_Pesquisa_RF.aspx">Incluir Cliente</asp:HyperLink>&nbsp;
                        <asp:HyperLink ID="lnk_Estabelecimentos_Localizar_Nao_Setorizado" runat="server" NavigateUrl="~/Estabelecimentos_Localizar_Nao_Setorizado.aspx" ToolTip="Lista de clientes que não estão alocados para nehum representante">Clientes Orfãos</asp:HyperLink>&nbsp;
                        <asp:LinkButton ID="cmd_Excel" runat="server">Excel</asp:LinkButton>&nbsp;
                    </div>
                </div>
            </div>

            <!-- Filtros da tabela -->
            <div class="row" style="margin-bottom: 15px; margin-top: 20px;">
                <div class="col-md-3">
                    Pesquisar:
                    <input id="filter" type="text" class="form-control" placeholder="Filtre os resultados dessa página" />
                </div>

            <!-- Quantidade -->
            <div class="col-md-4">
                Quantidade de registros:
                    <asp:DropDownList ID="cmb_Quantidade" runat="server" CssClass="form-control" onchange="atualizar(this.value);">
                        <asp:ListItem Selected="True">10</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>100</asp:ListItem>
                    </asp:DropDownList>
            </div>
            </div>

            <!-- Tabela de estabelecimentos -->
            <div class="row">
                <div class="col-md-12">
                    <asp:Panel ID="pnl_Tabela" runat="server">
                        <table class="table footable-toggle footable" data-filter="#filter" data-filter-text-only="true" data-page-size="100" style="margin-bottom: 15px;">
                            <!-- Cabeçalho -->
                            <thead class="navbar-default" >
                                <tr>
                                    <th data-toggle="true">CNPJ</th>
                                    <th data-toggle="true">Cliente</th>
                                    <th data-hide="all">Cidade</th>
                                    <th data-hide="all">UF</th>
                                    <th data-hide="phone,tablet">Esfera adm.</th>
                                    <th data-hide="phone">Representante</th>
                                </tr>
                            </thead>
                            <!-- Corpo -->
                            <tbody id="teste">
                                <asp:Repeater ID="rpt_Estabelecimentos_Localizar" runat="server" DataSourceID="dts_Localizar">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# DataBinder.Eval(Container.DataItem, "CNPJ") %></td>
                                            <td><%# DataBinder.Eval(Container.DataItem, "ESTABELECIMENTO") %></td>
                                            <td><%# DataBinder.Eval(Container.DataItem, "MUNICIPIO") %></td>
                                            <td><%# DataBinder.Eval(Container.DataItem, "UF") %></td>
                                            <td><%# DataBinder.Eval(Container.DataItem, "ESFERA") %></td>
                                            <td><%# DataBinder.Eval(Container.DataItem, "REPRESENTANTE") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                            <!-- Rodapé -->
                            <tfoot>
                                <tr class="text-center" style="background-color: rgba(0,0,0,0)">
                                    <td colspan="6">
                                        <!-- Grupo de botões -->
                                        <div class="btn-group" role="group" aria-label="...">
                                            <button id="btn_Anterior" type="button" class="btn btn-sm btn-primary" runat="server" title="Página anterior"><span class="glyphicon glyphicon-chevron-left"></span></button>
                                            <button id="btn_Proximo" type="button" class="btn btn-sm btn-primary" runat="server" title="Próxima página"><span class="glyphicon glyphicon-chevron-right"></span></button>
                                        </div>
                                    </td>
                                </tr>
                            </tfoot>
                        </table>
                    </asp:Panel>
                </div>
            </div>
        </div>
        <!-- javaScript -->
        <uc1:ScriptsFooter runat="server" ID="ScriptsFooter" />

        <!-- Data source -->
        <asp:SqlDataSource ID="dts_Localizar" runat="server"
            ConnectionString="<%$ ConnectionStrings:cnnStr %>"
            SelectCommand="SELECT VIEW_ESTABELECIMENTOS_001_DETALHADO.CNPJ, VIEW_ESTABELECIMENTOS_001_DETALHADO.CNPJ_FORMATADO, VIEW_ESTABELECIMENTOS_001_DETALHADO.CNES, VIEW_ESTABELECIMENTOS_001_DETALHADO.COD_INTERNO, VIEW_ESTABELECIMENTOS_001_DETALHADO.ID_GRUPO_ESTABELECIMENTO, VIEW_ESTABELECIMENTOS_001_DETALHADO.GRUPO_ESTABELECIMENTO, VIEW_ESTABELECIMENTOS_001_DETALHADO.ESTABELECIMENTO, VIEW_ESTABELECIMENTOS_001_DETALHADO.ESTABELECIMENTO_CNPJ, VIEW_ESTABELECIMENTOS_001_DETALHADO.RAZAO_SOCIAL, VIEW_ESTABELECIMENTOS_001_DETALHADO.NOME_FANTASIA, VIEW_ESTABELECIMENTOS_001_DETALHADO.ENDERECO, VIEW_ESTABELECIMENTOS_001_DETALHADO.LOGRADOURO, VIEW_ESTABELECIMENTOS_001_DETALHADO.NUMERO, VIEW_ESTABELECIMENTOS_001_DETALHADO.COMPLEMENTO, VIEW_ESTABELECIMENTOS_001_DETALHADO.BAIRRO, VIEW_ESTABELECIMENTOS_001_DETALHADO.CEP, VIEW_ESTABELECIMENTOS_001_DETALHADO.COD_MUNICIPIO, VIEW_ESTABELECIMENTOS_001_DETALHADO.MUNICIPIO, VIEW_ESTABELECIMENTOS_001_DETALHADO.UF, VIEW_ESTABELECIMENTOS_001_DETALHADO.ESTADO, VIEW_ESTABELECIMENTOS_001_DETALHADO.REGIAO, VIEW_ESTABELECIMENTOS_001_DETALHADO.MICRO_REGIAO_SAUDE, VIEW_ESTABELECIMENTOS_001_DETALHADO.REGIAO_SAUDE, VIEW_ESTABELECIMENTOS_001_DETALHADO.COD_TIPO_PESSOA, VIEW_ESTABELECIMENTOS_001_DETALHADO.TIPO_PESSOA, VIEW_ESTABELECIMENTOS_001_DETALHADO.COD_ESFERA_ADMINISTRATIVA, VIEW_ESTABELECIMENTOS_001_DETALHADO.ESFERA, VIEW_ESTABELECIMENTOS_001_DETALHADO.GESTAO, VIEW_ESTABELECIMENTOS_001_DETALHADO.COD_NATUREZA_JURIDICA, VIEW_ESTABELECIMENTOS_001_DETALHADO.NATUREZA_JURIDICA_DESCRICAO, VIEW_ESTABELECIMENTOS_001_DETALHADO.COD_CNAE, VIEW_ESTABELECIMENTOS_001_DETALHADO.CNAE_DESCRICAO, VIEW_ESTABELECIMENTOS_001_DETALHADO.DATA_FUNDACAO, VIEW_ESTABELECIMENTOS_001_DETALHADO.DATA_SITUACAORFB, VIEW_ESTABELECIMENTOS_001_DETALHADO.SITUACAORFB, VIEW_ESTABELECIMENTOS_001_DETALHADO.SETORIZADO, VIEW_ESTABELECIMENTOS_001_DETALHADO.QTD_SETORIZACOES, VIEW_ESTABELECIMENTOS_001_DETALHADO.SETORIZADO_VALOR, VIEW_ESTABELECIMENTOS_001_DETALHADO.INCLUSAO, VIEW_ESTABELECIMENTOS_001_DETALHADO.ALTERACAO, VIEW_ESTABELECIMENTOS_001_DETALHADO.EXCLUSAO, VIEW_ESTABELECIMENTOS_001_DETALHADO.INCLUSAO_DATA, VIEW_ESTABELECIMENTOS_001_DETALHADO.INCLUSAO_EMAIL, VIEW_ESTABELECIMENTOS_001_DETALHADO.ALTERACAO_DATA, VIEW_ESTABELECIMENTOS_001_DETALHADO.ALTERACAO_EMAIL, VIEW_ESTABELECIMENTOS_001_DETALHADO.EXCLUSAO_DATA, VIEW_ESTABELECIMENTOS_001_DETALHADO.EXCLUSAO_EMAIL, VIEW_ESTABELECIMENTOS_001_DETALHADO.ATUALIZACAO_RECEITA_DATA, VIEW_ESTABELECIMENTOS_001_DETALHADO.ATUALIZACAO_RECEITA_EMAIL, VIEW_ESTABELECIMENTOS_001_DETALHADO.ATUALIZACAO_RECEITA_CHECK, VIEW_ESTABELECIMENTOS_001_DETALHADO.ULTIMA_ATUALIZACAO_RECEITA, VIEW_ESTABELECIMENTOS_001_DETALHADO.APELIDO, VIEW_USUARIOS.EMAIL_DIRETOR, VIEW_USUARIOS.DIRETOR, VIEW_USUARIOS.EMAIL_GERENTE, VIEW_USUARIOS.GERENTE, VIEW_USUARIOS.EMAIL_COORDENADOR, VIEW_USUARIOS.COORDENADOR, VIEW_USUARIOS.EMAIL AS EMAIL_REPRESENTANTE, VIEW_USUARIOS.NOME AS REPRESENTANTE FROM TBL_SETORIZACAO LEFT OUTER JOIN VIEW_USUARIOS ON TBL_SETORIZACAO.EMAIL = VIEW_USUARIOS.EMAIL RIGHT OUTER JOIN VIEW_ESTABELECIMENTOS_001_DETALHADO ON TBL_SETORIZACAO.CNPJ = VIEW_ESTABELECIMENTOS_001_DETALHADO.CNPJ ORDER BY VIEW_ESTABELECIMENTOS_001_DETALHADO.ESTABELECIMENTO_CNPJ"></asp:SqlDataSource>

        <!-- Data source para exportar grid no excel -->
        <asp:SqlDataSource ID="dts_Exportar" runat="server"
            ConnectionString="<%$ ConnectionStrings:cnnStr %>"
            SelectCommand="SELECT VIEW_ESTABELECIMENTOS_001_DETALHADO.CNPJ AS cnpj, VIEW_ESTABELECIMENTOS_001_DETALHADO.ESTABELECIMENTO AS Cliente,  VIEW_ESTABELECIMENTOS_001_DETALHADO.MUNICIPIO AS Cidade, VIEW_ESTABELECIMENTOS_001_DETALHADO.UF AS UF,  VIEW_ESTABELECIMENTOS_001_DETALHADO.ESFERA AS Esfera, VIEW_ESTABELECIMENTOS_001_DETALHADO.QTD_SETORIZACOES AS 'Qtd. Setorizações', VIEW_USUARIOS.NOME AS Representantes FROM TBL_SETORIZACAO LEFT OUTER JOIN VIEW_USUARIOS ON TBL_SETORIZACAO.EMAIL = VIEW_USUARIOS.EMAIL RIGHT OUTER JOIN VIEW_ESTABELECIMENTOS_001_DETALHADO ON TBL_SETORIZACAO.CNPJ = VIEW_ESTABELECIMENTOS_001_DETALHADO.CNPJ ORDER BY VIEW_ESTABELECIMENTOS_001_DETALHADO.ESTABELECIMENTO_CNPJ"></asp:SqlDataSource>
    </form>
</body>
</html>
