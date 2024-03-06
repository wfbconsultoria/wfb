<%@ Page Title="Meus Médicos/Contatos" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Medicos.aspx.vb" Inherits="Medicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_TOTAIS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_REPRESENTANTES" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_TIPOS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_TIPOS_CONTATOS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_FUNCOES" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_ATIVO" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />

    <%--Titulo da Pagina--%>
    <h4 class="text-secondary text-uppercase" style="padding-top: 5px"><%:Page.Title %></h4>

    <div class="row g-3">
        <%--FILTROS--%>
        <div class="row g-2">

            <%-- REPRESENTANTE --%>
            <div class="col-md-3">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="EMAIL_REPRESENTANTE" CssClass="form-select" DataSourceID="dts_REPRESENTANTES" DataTextField="REPRESENTANTE" DataValueField="EMAIL_REPRESENTANTE" AutoPostBack="True"></asp:DropDownList>
                    <label class="text-danger" for="EMAIL_REPRESENTANTE">*Representante</label>
                </div>
            </div>
            <%-- TIPO_CONTATO --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="TIPO_CONTATO" CssClass="form-select" DataSourceID="dts_TIPOS_CONTATOS" DataTextField="TIPO_CONTATO" DataValueField="TIPO_CONTATO" AutoPostBack="True"></asp:DropDownList>
                    <label class="" for="TIPO_CONTATO">Tipo de Contato</label>
                </div>
            </div>
            <%-- FUNCAO --%>
            <div class="col-md-3">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="ID_FUNCAO" CssClass="form-select" DataSourceID="dts_FUNCOES" DataTextField="FUNCAO" DataValueField="ID_FUNCAO" AutoPostBack="True"></asp:DropDownList>
                    <label class="" for="ID_FUNCAO">Função</label>
                </div>
            </div>
            <%-- TIPO --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="ID_TIPO" CssClass="form-select" DataSourceID="dts_TIPOS" DataTextField="TIPO" DataValueField="ID_TIPO" AutoPostBack="True"></asp:DropDownList>
                    <label class="" for="ID_TIPO">Tipo</label>
                </div>
            </div>
            <%-- ATIVO/INATIVO --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="ATIVO" CssClass="form-select" DataSourceID="dts_ATIVO" DataTextField="ATIVO_DESCRICAO" DataValueField="ATIVO" AutoPostBack="True"></asp:DropDownList>
                    <label class="" for="ATIVO">Ativo</label>
                </div>
            </div>
        </div>
        <%--FILTROS--%>

        <%--TOTAIS--%>
        <div class="row g-2">
            <table class="table table-bordered" id="table_totais">
                <thead>
                    <asp:Repeater ID="dtr_TOTAIS" runat="server" DataSourceID="dts_MEDICOS">
                        <ItemTemplate>
                            <tr>
                                <th class="text-muted">Médicos/Contatos na lista: &nbsp<%# DataBinder.Eval(Container.DataItem, "MEDICOS").ToString%></th>
                            </tr>
                            <tr>
                                <th class="text-muted">Médicos/Contatos na lista: &nbsp<%# DataBinder.Eval(Container.DataItem, "ESTABELECIMENTOS").ToString%></th>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
            </table>
        </div>
        <%--TOTAIS--%>

        <%--LISTA MEDICOS--%>
        <div class="row g-2">
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
                        <th data-field="NOME" data-sortable="true" style="width: 35%">Nome</th>
                        <th data-field="ESPECIALIDADE" data-sortable="true" style="width: 15%">Função</th>
                        <th data-field="ESTABELECIMENTO" data-sortable="true" style="width: 30%">Local</th>
                        <th data-field="ULTIMA_VISITA_REALIZADA_BR" data-sortable="true" style="width: 5%">Última Visita</th>
                        <th data-field="ULTIMA_VISITA_AGENDADA_BR" data-sortable="true" style="width: 5%">Próxima Visita</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="dtr" runat="server" DataSourceID="dts">
                        <ItemTemplate>
                            <tr>
                                <td><a href='<%# "Medico_Incluir.aspx?IdEstabelecimento" + "=" + DataBinder.Eval(Container.DataItem, "IdEstabelecimento").ToString + "&CRM_UF" + "=" + DataBinder.Eval(Container.DataItem, "CRM_UF") %>'><%# LEFT(DataBinder.Eval(Container.DataItem, "CRM_UF").ToString, 10)%></a></td>
                                <td><%# DataBinder.Eval(Container.DataItem, "NOME_SOBRENOME").ToString%></td>
                                <td><%# DataBinder.Eval(Container.DataItem, "FUNCAO").ToString%></td>
                                <td><%# DataBinder.Eval(Container.DataItem, "ESTABELECIMENTO").ToString%></td>
                                <td><%# DataBinder.Eval(Container.DataItem, "ULTIMA_VISITA_ESTABELECIMENTO_REALIZADA_BR").ToString%></td>
                                <td><%# DataBinder.Eval(Container.DataItem, "ULTIMA_VISITA_ESTABELECIMENTO_AGENDADA_BR").ToString%></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <%--LISTA MEDICOS--%>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
</asp:Content>

