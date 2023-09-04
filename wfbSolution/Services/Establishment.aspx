<%@ Page Title="Estabelecimentos" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Establishment.aspx.cs" Inherits="Establishment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head_Content" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Body_Content" Runat="Server">
    <div class="container">
        <!-- Titulo -->
        <div class="row text-center pt-3">
            <div class="col-md-12">
                <h3><%:Page.Title%></h3>
                <span class="text-muted">Está página é voltada á uma consulta simples de cnpj na receita federal.</span>
            </div>
        </div>

        <!-- CNPJ -->
        <div class="row mt-4">
            <div class="col-md-12">
                <label class="mb-2">CNPJ do Estabelecimento:</label>
                <input type="number" id="txtCnpj" runat="server" class="form-control" required="required" placeholder="Digite apenas os números" max="99999999999999" />
            </div>
        </div>

        <!-- Botão -->
        <div class="row">
            <div class="col-md-12">
                <input type="submit" id="btnSearch" runat="server" class="btn btn-sm btn-primary" title="clique para pesquisar o estabelecimento" onserverclick="btnSearch_Click" value="Pesquisar"/>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Footer_Content" Runat="Server">
</asp:Content>

