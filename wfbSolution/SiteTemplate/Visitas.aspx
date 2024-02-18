<%@ Page Title="" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Visitas.aspx.vb" Inherits="Visitas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" Runat="Server">
    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts_VISITAS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />

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
                data-mobile-responsive="true">
                <thead>
                    <tr>
                        <th data-field="CRM" data-sortable="true" style="width: 10%">Data</th>
                        <th data-field="ESTABELECIMENTO_CNPJ" data-sortable="true" style="width: 25%">Estabelecimento</th>
                        <th data-field="NOME" data-sortable="true" style="width: 25%">Médico</th>
                        <th data-field="REPRESENTANTE" data-sortable="true" style="width: 10%">Representante</th>
                        <th data-field="OBJETIVO" data-sortable="true" style="width: 10%">Objetivo</th>
                        <th data-field="AVALIACAO" data-sortable="true" style="width: 10%">Avaliação</th>
                        <th data-field="DATA_PROXIMA" data-sortable="true" style="width: 10%">Próxima</th>
                         <th data-field="OBSERVACOES" data-sortable="true" style="width: 10%">Observacoes</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="dtr" runat="server" DataSourceID="dts_VISITAS">
                        <ItemTemplate>
                            <tr>
                                <%--<td><a href='<%# "Medico_Incluir.aspx?IdEstabelecimento" + "=" + DataBinder.Eval(Container.DataItem, "IdEstabelecimento").ToString + "&CRM_UF" + "=" + DataBinder.Eval(Container.DataItem, "CRM_UF") %>'><%# DataBinder.Eval(Container.DataItem, "CRM_UF").ToString%></a></td>--%>
                                <td><%# DataBinder.Eval(Container.DataItem, "DATA_VISITA").ToString%></td>
                                <td><%# DataBinder.Eval(Container.DataItem, "ESTABELECIMENTO_CNPJ").ToString%></td>
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
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" Runat="Server">
</asp:Content>

