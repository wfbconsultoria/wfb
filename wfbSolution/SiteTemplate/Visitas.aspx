<%@ Page Title="Visitas" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Visitas.aspx.vb" Inherits="Visitas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts_VISITAS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_REPRESENTANTES" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_ANOS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_MESES" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_TIPOS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />

    <%--Titulo da Pagina--%>
    <h4 class="text-secondary text-uppercase" style="padding-top: 5px"><%:Page.Title %></h4>

    <%--FILTROS--%>
    <div class="row g-3">
        <div class="row g-2">
            <%-- REPRESENTANTE --%>
            <div class="col-md-3">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="EMAIL_REPRESENTANTE" CssClass="form-select" DataSourceID="dts_REPRESENTANTES" DataTextField="REPRESENTANTE" DataValueField="EMAIL_REPRESENTANTE" AutoPostBack="True"></asp:DropDownList>
                    <label class="text-danger" for="EMAIL_REPRESENTANTE">*Representante</label>
                </div>
            </div>

            <%-- TIPO --%>
            <div class="col-md-3">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="COD_TIPO" CssClass="form-select" DataSourceID="dts_TIPOS" DataTextField="TIPO" DataValueField="COD_TIPO" AutoPostBack="True"></asp:DropDownList>
                    <label class="" for="COD_TIPO">Tipo</label>
                </div>
            </div>

            <%-- ANO --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="ANO" CssClass="form-select" DataSourceID="dts_ANOS" DataTextField="ANO_DESC" DataValueField="ANO" AutoPostBack="True"></asp:DropDownList>
                    <label class="" for="ANO">Ano</label>
                </div>
            </div>

            <%-- MES --%>
            <div class="col-md-2">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="MES" CssClass="form-select" DataSourceID="dts_MESES" DataTextField="MES_SIGLA" DataValueField="MES" AutoPostBack="True"></asp:DropDownList>
                    <label class="" for="MES">Mês</label>
                </div>
            </div>

        </div>
    </div>
    <%-- FILTROS--%>

    <%-- DIV VISITAS --%>
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
            data-mobile-responsive="true"
            data-filter-control="true"
            data-show-search-clear-button="true"
            data-detail-view="true"
            data-detail-formatter="detailFormatter"
            data-show-refresh="true">

            <thead>
                <tr>
                    <th data-field="Data" data-sortable="true" style="width: 5%">Data</th>
                    <th data-field="Tipo Visita" data-sortable="true" style="width: 10%">Tipo Visita</th>
                    <th data-field="Estabelecimento" data-sortable="true" style="width: 45%">Estabelecimento</th>
                    <th data-field="Contato" data-sortable="true" style="width: 40%">Contato</th>
                    
                    <th data-field="CRM" data-sortable="true" data-visible="false" style="width: 100%">CRM</th>
                    <th data-field="Especialidade" data-sortable="true" data-visible="false" style="width: 100%">Especialidade</th>
                    <th data-field="Funcao" data-sortable="true" data-visible="false" style="width: 100%">Funcao</th>
                    <th data-field="Tipo" data-sortable="true" data-visible="false" style="width: 100%">Tipo</th>
                    <th data-field="Representante" data-sortable="true" data-visible="false" style="width: 100%">Representante</th>
                    <th data-field="Forma" data-sortable="true" data-visible="false" style="width: 100%">Forma</th>
                    <th data-field="Objetivo" data-sortable="true" data-visible="false" style="width: 100%">Objetivo</th>
                    <th data-field="Produto" data-sortable="true" data-visible="false" style="width: 100%">Produto</th>
                    <th data-field="Avaliacao" data-sortable="true" data-visible="false" style="width: 100%">Avaliação</th>
                    <th data-field="Observacoes" data-sortable="true" data-visible="false" style="width: 100%">Observacoes</th>
                    <th data-field="Proxima" data-sortable="true" data-visible="false" style="width: 100%">Proxima</th>
                    <th data-field="Objetivo_Proxima" data-sortable="true" data-visible="false" style="width: 100%">Proxima Objetivo</th>
                    <th data-field="Observacoes_Proxima" data-sortable="true" data-visible="false" style="width: 100%">Proxima Observações</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="dtr" runat="server" DataSourceID="dts_VISITAS">
                    <ItemTemplate>
                        <tr>
                            <%--<td><a href='<%# "Medico_Incluir.aspx?IdEstabelecimento" + "=" + DataBinder.Eval(Container.DataItem, "IdEstabelecimento").ToString + "&CRM_UF" + "=" + DataBinder.Eval(Container.DataItem, "CRM_UF") %>'><%# DataBinder.Eval(Container.DataItem, "CRM_UF").ToString%></a></td>--%>
                            <td><%# DataBinder.Eval(Container.DataItem, "DATA").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "VISITA_TIPO").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "ESTABELECIMENTO").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "NOME").ToString%></td>
                            
                            <td><%# DataBinder.Eval(Container.DataItem, "CRM_UF").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "ESPECIALIDADE").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "FUNCAO").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "TIPO").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "REPRESENTANTE").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "VISITA_FORMA").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "OBJETIVO").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "LINHA").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "AVALIACAO").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "OBSERVACOES").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "DATA_PROXIMA").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "OBJETIVO_PROXIMA").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "OBSERVACOES_PROXIMA").ToString%></td>

                            <%--<td><a href='<%# "Medico.aspx?idMedico" + "=" + DataBinder.Eval(Container.DataItem, "IdMedico").ToString %>'>Visitar</a></td>--%>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
    <%-- DIV VISITASS --%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">

    <script>
        function detailFormatter(index, row) {
            var html = []
            var indexs = 0

            //here columnC matches with data-field value.
            html.push('<p><b> Data :</b> ' + row['Data'] + '</p>')
            html.push('<p><b> Tipo Visita :</b> ' + row['Tipo Visita'] + '</p>')
            html.push('<p><b> Estabelecimento :</b> ' + row['Estabelecimento'] + '</p>')
            html.push('<p><b> Contato :</b> ' + row['Contato'] + '</p>')
            html.push('<p><b> CRM :</b> ' + row['CRM'] + '</p>')
            html.push('<p><b> Especialidade :</b> ' + row['Especialidade'] + '</p>')
            html.push('<p><b> Funcao :</b> ' + row['Funcao'] + '</p>')
            html.push('<p><b> Tipo :</b> ' + row['Tipo'] + '</p>')
            html.push('<p><b> Representante :</b> ' + row['Representante'] + '</p>')
            html.push('<p><b> Forma :</b> ' + row['Forma'] + '</p>')
            html.push('<p><b> Objetivo :</b> ' + row['Objetivo'] + '</p>')
            html.push('<p><b> Produto :</b> ' + row['Produto'] + '</p>')
            html.push('<p><b> Avaliação :</b> ' + row['Avaliacao'] + '</p>')
            html.push('<p><b> Observações :</b> ' + row['Observacoes'] + '</p>')
            html.push('<p><b> Próxima :</b> ' + row['Proxima'] + '</p>')
            html.push('<p><b> Objetivo Próxima :</b> ' + row['Objetivo_Proxima'] + '</p>')
            html.push('<p><b> Observações Próxima :</b> ' + row['Observacoes_Proxima'] + '</p>')


            return html;
        }
    </script>
</asp:Content>

