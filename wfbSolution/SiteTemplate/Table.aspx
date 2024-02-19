<%@ Page Title="" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Table.aspx.vb" Inherits="Table" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%Dim m As New clsMaster%>
    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />

    <div>
        <table class="table table-bordered table-hover"
            id="table"
            data-toggle="table"
            data-search="true"
            data-search-align="right"
            data-search-accent-neutralise="true"
            data-search-highlight="true"
            data-sortable="true"
            data-pagination="true"
            data-show-columns="true"
            data-show-columns-toggle-all="true"
            data-show-pagination-switch="true"
            data-show-toggle="true"
            data-show-multi-sort="true"
            data-mobile-responsive="true"
            data-check-on-init="true"
            data-filter-control="true"
            data-show-search-clear-button="true"
            
            data-detail-view="true"
  data-detail-formatter="detailFormatter"
  data-show-refresh="true">
            <thead>
                <tr>
                    <th data-field="CNPJ"  data-sortable="true" style="width: 10%">CNPJ</th>
                    <th data-field="Estabelecimento" data-sortable="true"  style="width: 40%">Cliente</th>
                    <th data-field="Representante" data-filter-control="select" data-sortable="true" style="width: 25%">Representante</th>
                    <th data-field="Cidade" data-filter-control="input" data-sortable="true" data-visible="false" style="width: 20%">Cidade</th>
                    <th data-field="UF" data-filter-control="select" data-sortable="true" data-visible="false" style="width: 5%">UF</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="dtr" runat="server" DataSourceID="dts">
                    <ItemTemplate>
                        <tr>
                            <td><a href='<%# "Establishment?Id" + "=" + DataBinder.Eval(Container.DataItem, "Id").ToString %>'><%# DataBinder.Eval(Container.DataItem, "CNPJ").ToString%></a></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "Estabelecimento").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "Representante").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "Cidade").ToString%></td>
                            <td><%# UCase(DataBinder.Eval(Container.DataItem, "UF").ToString)%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>

    </div>
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
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
    
</asp:Content>

