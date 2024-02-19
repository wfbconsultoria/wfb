<%@ Page Title="Meus Médicos" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Medicos.aspx.vb" Inherits="Medicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />

    <%--Titulo da Pagina--%>
    <h4 class="text-secondary text-uppercase" style="padding-top: 5px"><%:Page.Title %></h4>

    <div>
        
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
                    <th data-field="NOME" data-sortable="true" style="width: 40%">Medico</th>
                    <th data-field="ESPECIALIDADE" data-sortable="true" style="width: 15%">Função</th>
                     <th data-field="ESTABELECIMENTO" data-sortable="true" style="width: 30%">Estabelecimento</th>
                    <%--<th data-field="VISITAR" data-sortable="true" style="width: 5%">Visitar</th>--%>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="dtr" runat="server" DataSourceID="dts">
                    <ItemTemplate>
                        <tr>
                            <td><a href='<%# "Medico_Incluir.aspx?IdEstabelecimento" + "=" + DataBinder.Eval(Container.DataItem, "IdEstabelecimento").ToString + "&CRM_UF" + "=" + DataBinder.Eval(Container.DataItem, "CRM_UF") %>'><%# DataBinder.Eval(Container.DataItem, "CRM_UF").ToString%></a></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "NOME_SOBRENOME").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "FUNCAO").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "ESTABELECIMENTO_CNPJ").ToString%></td>
                            <%--<td><a href='<%# "Medico.aspx?idMedico" + "=" + DataBinder.Eval(Container.DataItem, "IdMedico").ToString %>'>Visitar</a></td>--%>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
</asp:Content>

