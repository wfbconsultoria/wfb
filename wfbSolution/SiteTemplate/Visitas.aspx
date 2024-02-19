<%@ Page Title="" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Visitas.aspx.vb" Inherits="Visitas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts_VISITAS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_Representantes" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />

   
    
    <%--FILTROS--%>
    <div class="row g-3">
        <div class="row g-2">
            <%-- REPRESENTANTE --%>
            <div class="col-md-3">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="EMAIL_REPRESENTANTE" CssClass="form-select" DataSourceID="dts_REPRESENTANTES" DataTextField="REPRESENTANTE" DataValueField="EMAIL_REPRESENTANTE"></asp:DropDownList>
                    <label class="text-danger" for="EMAIL_REPRESENTANTE">REPRESENTANTE</label>
                </div>
            </div>
        </div>
        <%-- UF/CRM/ESPECIALDADE/TIPO--%>
    
    </div>
    
    
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
                    <th data-field="Estabelecimento" data-sortable="true" style="width: 55%">Estabelecimento</th>
                    <th data-field="Contato" data-sortable="true" style="width: 45%">Contato</th>
                    <th data-field="Representante" data-sortable="true" data-visible="false" style="width: 100%">Representante</th>
                    <th data-field="Objetivo" data-sortable="true" data-visible="false" style="width: 100%">Objetivo</th>
                    <th data-field="Avaliação" data-sortable="true" data-visible="false"  style="width: 100%">Avaliação</th>
                    <th data-field="DATA_PROXIMA" data-sortable="true" style="width: 10%">Próxima</th>
                    <th data-field="OBSERVACOES" data-sortable="true" style="width: 10%">Observacoes</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="dtr" runat="server" DataSourceID="dts_VISITAS">
                    <ItemTemplate>
                        <tr>
                            <%--<td><a href='<%# "Medico_Incluir.aspx?IdEstabelecimento" + "=" + DataBinder.Eval(Container.DataItem, "IdEstabelecimento").ToString + "&CRM_UF" + "=" + DataBinder.Eval(Container.DataItem, "CRM_UF") %>'><%# DataBinder.Eval(Container.DataItem, "CRM_UF").ToString%></a></td>--%>
                            <td><%# DataBinder.Eval(Container.DataItem, "DATA").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "ESTABELECIMENTO").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "NOME").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "REPRESENTANTE").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "OBJETIVO").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "AVALIACAO").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "DATA_PROXIMA").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "OBSERVACOES").ToString%></td>
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
            html.push('<p><b> UF :</b> ' + row['UF'] + '</p>')
            html.push('<p><b> Cidade :</b> ' + row['Cidade'] + '</p>')
            return html;
        }
    </script>
</asp:Content>

