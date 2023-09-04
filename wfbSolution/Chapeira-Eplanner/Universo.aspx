<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Universo.aspx.vb" Inherits="Chapeira_Eplanner.Universo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <h4 class="text-secondary text-uppercase"><%:Page.Title %></h4>
    <div class="form-row">
                <%-- Sigla--%>
                <div class="form-group col-sm-2">
                    <label class="text-primary">Sigla</label>
                    <input runat="server" id="txt_Loja_Sigla" type="text" maxlength="8" class="form-control" required="required" disabled="disabled" />
                </div>

                <%-- Loja--%>
                <div class="form-group col-sm-10">
                    <label class="text-primary">Loja</label>
                    <input runat="server" id="txt_Loja" type="text" maxlength="128" class="form-control" required="required" disabled="disabled" />
                </div>
            </div>
            
            <%-- Universo--%>
            <div class="form-row">
                <div class="form-group col-sm-1">
                    <label class="text-primary">Id</label>
                    <input runat="server" id="txt_Id" class="form-control" disabled="disabled" />
                </div>

                <div class="form-group col-sm-9">
                    <label class="text-primary">Universo</label>
                    <input runat="server" id="txt_Universo" type="text" maxlength="128" class="form-control" required="required" />
                </div>

                <div class="form-group col-sm-1">
                    <label class="text-primary">Andar</label>
                    <input runat="server" id="txt_Andar" type="number" class="form-control" required="required" />
                </div>

                <div class="form-group col-sm-1">
                    <label class="text-primary">Zona</label>
                    <input runat="server" id="txt_Zona" type="number" class="form-control" required="required" />
                </div>
            </div>
            <%-- botoes de de comando--%>
            <input runat="server" id="cmd_Save" type="submit" value="Gravar" class="btn btn-primary" />
            &nbsp;<a href="Universo.aspx?IdUniverso=NOVO" class=" btn btn-primary">Novo</a>
            &nbsp;<input id="cmd_Cancel" type="reset" value="Cancelar" class="btn btn-light" />
            &nbsp; <a href="Universos.aspx" class="btn btn-link btn-light">Lista</a>
            &nbsp;<a class="text-danger" href="<%:"?IdUniverso=" & txt_Id.Value & "&Acao=EXCLUIR"%>">Excluir</a>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
