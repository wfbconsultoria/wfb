<%@ Page Title="Estabelecimento" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Estabelecimento.aspx.vb" Inherits="Estabelecimento" %>

<%@ Register Src="~/Titulo_Pagina.ascx" TagPrefix="uc1" TagName="Titulo_Pagina" %>
<%@ Register Src="~/Estabelecimento_Cabecalho.ascx" TagPrefix="uc1" TagName="Estabelecimento_Cabecalho" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts_UF" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_FUNCAO" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_MEDICOS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <%--Titulo da Página--%>
    <uc1:Titulo_Pagina runat="server" ID="Titulo_Pagina" />

    <%--Conteudo--%>
    <uc1:Estabelecimento_Cabecalho runat="server" ID="Estabelecimento_Cabecalho" />

     <%-- LINKS --%>
    <div class="row g-3">
        <h5><a class="link" data-bs-toggle="collapse" href="#div_CORPO_MEDICOS" role="button" aria-expanded="false" aria-controls="CORPO">Contatos</a></h5>
    </div>
     <%-- LINKS --%>
    <hr />
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
                                <td><a href='<%# "Medico_Incluir.aspx?IdEstabelecimento" + "=" + DataBinder.Eval(Container.DataItem, "IdEstabelecimento").ToString + "&CRM_UF" + "=" + DataBinder.Eval(Container.DataItem, "CRM_UF") %>'><%# LEFT(DataBinder.Eval(Container.DataItem, "CRM_UF").ToString, 10)%></a></td>
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

    <%-- DIV PRINCIPAL --%>
    <div class="row g-3">

        <%-- Sub Titulo e instruções--%>
        <div class="row g-2">
            <br />
            <h5 class=" text-primary">Incluir novo médico</h5>
            <h6 class="text-muted">Selecione o UF e digite o CRM</h6>
        </div>
        <%-- Sub Titulo e instruções--%>

        <%-- UF_CRM/CRM/BOTÃO--%>
        <div class="row g-2">
            <div class="col-10">
                <div class="input-group mb-3">
                    <%-- UF_CRM --%>
                    <span class="input-group-text">UF</span>
                    <asp:DropDownList runat="server" ID="UF_CRM" CssClass="form-select" DataSourceID="dts_UF" DataTextField="UF" DataValueField="UF" required="required"></asp:DropDownList>
                    <%-- CRM --%>
                    <span class="input-group-text">CRM</span>
                    <input runat="server" id="CRM" type="text" class="form-control" maxlength="8" placeholder="00000000" required="required" onfocus="this.value='';" onkeypress="return somenteNumeros(event)" />
                </div>
            </div>
            <div class="col-2">
                <%-- BOTÃO INCLUIR --%>
                <button runat="server" id="cmd_Novo_CRM" type="button" class="form-control btn btn-primary">NOVO MÉDICO</button>
            </div>
        </div>
        <%-- UF_CRM/CRM/BOTÃO--%>

        <%-- CONTATO/BOTÃO--%>
        <div class="row g-2">

            <div class="col-12">
                <%-- BOTÃO INCLUIR NOVO CONTATP--%>
                <button runat="server" id="cmd_Novo_Contato" type="button" class="form-control btn btn-info">NOVO CONTATO</button>
            </div>
        </div>
        <%-- UF_CRM/CRM/BOTÃO--%>
    </div>
    <%-- DIV PRINCIPAL --%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
</asp:Content>

