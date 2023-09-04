<%@ Page Title="Editar Ping" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AlterPing.aspx.cs" Inherits="AlterPing" %>

<%--Referencias com css--%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head_Content" runat="Server">
</asp:Content>

<%--Conteudo da página--%>
<asp:Content ID="Content2" ContentPlaceHolderID="Body_Content" runat="Server">
    <div class="container mt-5">

        <!-- Titulo -->
        <div class="row pt-2 text-center">
            <div class="col-md-12">
                <h3><%:Page.Title%></h3>
                <span class="text-muted">Todos os campos com <span class="text-danger">*</span> são obrigatórios</span>
            </div>
        </div>

        <!--Nome-->
        <div class="row">
            <div class="col-md-8 mt-3">
                <label>Nome: </label>
                <span class="text-danger">*</span>
                <input type="text" id="txtName" runat="server" class="form-control" required="required" placeholder="Insira o hostname da máquina" maxlength="50" />
            </div>

            <!--IP-->
            <div class="col-md-4 mt-3">
                <label>Endereço Ipv4: </label>
                <span class="text-danger">*</span>
                <input type="text" id="txtIp" runat="server" class="form-control" required="required" placeholder="Insira o ip da máquina" maxlength="15" />
            </div>
        </div>

        <!--Email do responsavel-->
        <div class="row">
            <div class="col-md-12 mt-2">
                <label>E-mail do responsável: </label>
                <span class="text-danger">*</span>
                <input type="email" id="txtEmail" runat="server" class="form-control" required="required" placeholder="Responsável caso houver alguma falha" maxlength="50" />
            </div>
        </div>

        <!--Descrição -->
        <div class="row">
            <div class="col-md-12 mt-2">
                <label>Descrição: </label>
                <textarea id="txtDescription" runat="server" class="form-control" placeholder="Descreva as caracteristicas da máquina" maxlength="100" rows="3"></textarea>
            </div>
        </div>

        <!-- Botões -->
        <div class="row">
            <div class="col-md-12">
                <input type="submit" id="btnUpdate" runat="server" class="btn btn-sm btn-primary" title="clique para alterar o registro" onserverclick="btnUpdate_Click" />
                <a id="btnReturn" runat="server" class="btn btn-sm btn-secondary text-light" title="clique para voltar"></a>

                <!-- apagar registro -->
                <div class="float-right">
                    <input type="submit" id="btnDelete" runat="server" class="btn btn-sm btn-danger" title="clique para apagar o registro" onserverclick="btnDelete_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<%--Referencias com js--%>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer_Content" runat="Server">
</asp:Content>

