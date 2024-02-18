<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Estabelecimento_Cabecalho.ascx.vb" Inherits="Estabelecimento_Cabecalho" %>

<asp:SqlDataSource ID="dts_MEDICOS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />

<div class="col-md-12">
    <a class="link" data-bs-toggle="collapse" href="#div_CORPO_ESTABELECIMENTO" role="button" aria-expanded="false" aria-controls="CORPO">Exibir/Ocultar Endereço</a>
    <a class="link" data-bs-toggle="collapse" href="#div_CORPO_MEDICOS" role="button" aria-expanded="false" aria-controls="CORPO">Exibir/Ocultar Medicos</a>
</div>

<%-- DIV MENSAGEM --%>
<div runat="server" id="div_MENSAGEM_ESTABELECIMENTO" class="row g-3 card card-body">
    <div class="row g-2">
        <div class="col-md-12">
            <h4 class="text-danger">Você deve selecionar um estabelecimento na página Meus Estabelecimentos</h4>
            <a href="Estabelecimentos.aspx">Ir para Meus EStabelecimentos</a>
        </div>
    </div>
</div>
<%-- DIV MENSAGEM --%>

<%-- DIV PRINCIPAL --%>
<div runat="server" id="div_PRINCIPAL_ESTABELECIMENTO" class="row g-3">

    <%-- CNPJ/ESTABELECIMENTO/REPRESENTANTE--%>
    <div id="div_CABECALHO_ESTABELECIMENTO" class="row g-2">

        <%-- ESTABELECIMENTO --%>
        <div class="col-md-8">
            <div class="form-floating">
                <input runat="server" id="txt_ESTABELECIMENTO" type="text" class="form-control" value="" disabled="disabled" />
                <label for="txt_ESTABELECIMENTO">Estabelecimento</label>
            </div>
        </div>
        <%-- REPRESENTANTE --%>
        <div class="col-md-2">
            <div class="form-floating">
                <input runat="server" id="txt_REPRESENTANTE" type="text" class="form-control" value="" disabled="disabled" />
                <label for="txt_REPRESENTANTE">Representante</label>
            </div>
        </div>
        <%-- CNPJ --%>
        <div class="col-md-2">
            <div class="form-floating">
                <input runat="server" id="txt_CNPJ" type="text" class="form-control" value="" disabled="disabled" />
                <label for="txt_CNPJ">CNPJ</label>
            </div>
        </div>
    </div>
    <%-- CNPJ/ESTABELECIMENTO/REPRESENTANTE--%>

    <%-- CORPO ESTABELECIMENTO --%>
    <div id="div_CORPO_ESTABELECIMENTO" class="collapse">
        <%-- CEP/ENDERECO/BAIRRO/CIDADE/UF--%>
        <div id="div_ENDERECO" class="row g-2">

            <%-- ENDERECO --%>
            <div class="col-md-5">
                <div class="form-floating">
                    <input runat="server" id="txt_ENDERECO" type="text" class="form-control" disabled="disabled" />
                    <label for="txt_ENDERECO">Endereço</label>
                </div>
            </div>
            <%-- BAIRRO --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <input runat="server" id="txt_BAIRRO" type="text" class="form-control" disabled="disabled" />
                    <label for="txt_BAIRRO">Bairro</label>
                </div>
            </div>
            <%-- CEP --%>
            <div class="col-md-1">
                <div class="form-floating">
                    <input runat="server" id="txt_CEP" type="text" class="form-control" disabled="disabled" />
                    <label for="txt_CEP">CEP</label>
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
        <%-- CEP/ENDERECO/BAIRRO/CIDADE/UF--%>
    </div>
    <%-- CORPO ESTABELECIMENTO --%>

    <%-- CORPO MEDICOS --%>
    <div id="div_CORPO_MEDICOS" class="collapse">
        <%-- DIV MEDICOS --%>
        <div class="row g-3">

            <table class="table table-bordered table-hover"
                id="table"
                <%--data-toolbar="#toolbar"--%>
                data-toggle="table"
                data-search="true"
                data-search-align="left"
                data-search-accent-neutralise="true"
                data-search-highlight="true"
                data-sortable="true"
                data-show-toggle="true"
                data-show-columns="true"
                data-mobile-responsive="true">
                <thead>
                    <tr>
                        <th data-field="CRM" data-sortable="true" style="width: 10%">CRM</th>
                        <th data-field="NOME" data-sortable="true" style="width: 65%">Medico</th>
                        <th data-field="FUNCAO" data-sortable="true" style="width: 20%">Função</th>
                        <%--<th data-field="VISITAR" data-sortable="true" style="width: 5%">Visitar</th>--%>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="dtr" runat="server" DataSourceID="dts_MEDICOS">
                        <ItemTemplate>
                            <tr>
                                <td><a href='<%# "Medico_Incluir.aspx?IdEstabelecimento" + "=" + DataBinder.Eval(Container.DataItem, "IdEstabelecimento").ToString + "&CRM_UF" + "=" + DataBinder.Eval(Container.DataItem, "CRM_UF") %>'><%# DataBinder.Eval(Container.DataItem, "CRM_UF").ToString%></a></td>
                                <td><%# DataBinder.Eval(Container.DataItem, "NOME_SOBRENOME").ToString%></td>
                                <td><%# DataBinder.Eval(Container.DataItem, "FUNCAO").ToString%></td>
                                <%--<td><a href='<%# "Medico.aspx?idMedico" + "=" + DataBinder.Eval(Container.DataItem, "IdMedico").ToString %>'>Visitar</a></td>--%>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <%-- DIV MEDICOS --%>
    </div>
    <%-- CORPO MEDICOS --%>
</div>
<%-- DIV PRINCIPAL --%>
<hr />



