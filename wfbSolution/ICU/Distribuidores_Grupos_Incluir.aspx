﻿<%@ Page Title="Grupo de Distribuidores" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="Distribuidores_Grupos_Incluir.aspx.vb" Inherits="Distribuidores_Grupos_Incluir" %>

<%@ Register Src="~/Titulo_Pagina.ascx" TagPrefix="uc1" TagName="Titulo_Pagina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%--Titulo da Página--%>
    <uc1:Titulo_Pagina runat="server" ID="Titulo_Pagina" />
    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts_EMAIL_RESPONSAVEL" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <asp:SqlDataSource ID="dts_ATIVO" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />

    <%--CORPO DA PAGINA--%>
    <div class="row g-3">
        <%-- GRUPOP_DISTRIBUIDOR --%>
        <div class="row g-2">
            <div class="col-md-4">
                <div class="form-floating">
                    <input runat="server" id="GRUPO_DISTRIBUIDOR" type="text" class="form-control" placeholder="" value="" required="required" />
                    <label for="GRUPO_DISTRIBUIDOR">Grupo Distribuidor</label>
                </div>
            </div>
        </div>

        <%-- EMAIL_RESPONSAVEL --%>
        <div class="row g-2">
            <div class="col-md-4">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="EMAIL_RESPONSAVEL" CssClass="form-select" DataSourceID="dts_EMAIL_RESPONSAVEL" DataTextField="NOME" DataValueField="EMAIL" required="required"></asp:DropDownList>
                    <label for="EMAIL_RESPONSAVEL">Responsavel</label>
                </div>
            </div>
        </div>
        <%-- ATIVO INATIVO --%>
        <div class="row g-2">
            <div class="col-md-4">
                <div class="form-floating">
                    <asp:DropDownList runat="server" ID="ATIVO" CssClass="form-select" DataSourceID="dts_ATIVO" DataTextField="ATIVO_DESCRICAO" DataValueField="ATIVO"></asp:DropDownList>
                    <label for="ATIVO">Status</label>
                </div>
            </div>
        </div>
        <%-- BOTÕES --%>
        <div class="row g-2">
            <div class="col-md-4">
                <div class="input-group">
                    <a href="Distribuidores_Grupos_Lista.aspx" class="btn btn-info">Lista</a>
                    <a href="Distribuidores_Grupos_Incluir.aspx?Id=NOVO" class="btn btn-info">Novo</a>
                    <input id="cmd_Save" type="submit" value="Gravar" class="btn btn-primary" />
                </div>
            </div>
        </div>
        <%-- OCULTOS Id --%>
        <div class="row g-2">
            <input runat="server" id="Id" type="hidden" class="form-control" placeholder="" value="" />
        </div>

    </div>
    <%-- BOTÕES --%>
    <%--CORPO DA PAGINA--%>


    <div>
        <table id="table" 
            class="table table-bordered table-hover"
            data-toggle="table"
            data-search="true"
            data-search-align="left"
            data-search-accent-neutralise="true"
            data-search-highlight="true"
            <%--data-show-search-clear-button="true"--%>
            data-show-toggle="true"
            data-show-columns="true"
            <%--data-show-columns-toggle-all="true"--%>
            <%--data-show-fullscreen="true"--%>
            <%--data-show-pagination-switch="true"--%>
            data-sortable="true"                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     
            <%--data-pagination="true"--%>
            data-mobile-responsive="true">
            <thead>
                <tr>
                    <th data-field="CNPJ" data-sortable="true" style="width:10%">CNPJ</th>
                    <th data-field="NOME_FANTASIA" data-sortable="true"  style="width:35%">Cliente</th>
                    <th data-field="MUNICIPIO" data-sortable="true" style="width:15%">Cidade</th>
                    <th data-field="UF" data-sortable="true" style="width:5%">UF</th>
                    <th data-field="ESFERA" data-sortable="true" style="width:10%">Esfera</th>
                    <th data-field="TIPO" data-sortable="true" style="width:10%">Tipo</th>
                    <th data-field="GRUPO_DISTRIBUIDOR" data-sortable="true" style="width:15%">Grupo Distribuidor</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="dtr" runat="server" DataSourceID="dts">
                    <ItemTemplate>
                        <tr>
                            <td><a href='<%# "Estabelecimento_Editar.aspx?idEstabelecimento" + "=" + DataBinder.Eval(Container.DataItem, "Id").ToString %>'><%# DataBinder.Eval(Container.DataItem, "CNPJ").ToString%></a></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "NOME_FANTASIA").ToString%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "MUNICIPIO").ToString%></td>
                            <td><%# UCase(DataBinder.Eval(Container.DataItem, "UF").ToString)%></td>
                            <td><%# UCase(DataBinder.Eval(Container.DataItem, "ESFERA").ToString)%></td>
                            <td><%# UCase(DataBinder.Eval(Container.DataItem, "TIPO").ToString)%></td>
                            <td><%# UCase(DataBinder.Eval(Container.DataItem, "GRUPO_DISTRIBUIDOR").ToString)%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
</asp:Content>