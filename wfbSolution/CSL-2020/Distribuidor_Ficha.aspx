<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Distribuidor_Ficha.aspx.vb" Inherits="CSL_2020.Distribuidor_Ficha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <asp:Repeater ID="dtrFicha" runat="server" DataSourceID="dtsFicha">
        <ItemTemplate>

            <%--Informações do distribuidor selecionado--%>
            <h2 class="container text-center">Atualização dos Distribuidores</h2>
            <hr />
            <p class="font-weight-bold">Grupo Distribuidor</p>
            <div class="form-row border border-light rounded bg-light" style="padding-top: 10px; padding-left: 10px">
                <div class="form-group col-md-1">
                    <label for="Id Grupo">Id Grupo</label>
                    <input disabled="disabled" type="Number" class="form-control" id="txt_id_grupo" value="<%# DataBinder.Eval(Container.DataItem, "ID_GRUPO_DISTRIBUIDOR").ToString  %>" />
                </div>
                <div class="form-group col-md-3">
                    <label for="Id Grupo">Nome Distribuidor</label>
                    <input disabled="disabled" type="text" class="form-control" id="Number1" value="<%# DataBinder.Eval(Container.DataItem, "GRUPO_DISTRIBUIDOR").ToString  %>" />
                </div>
                <div class="form-group col-md-2">
                    <label for="cnpj_distribuidor">CNPJ</label>
                    <input type="text" class="form-control" id="txt_cnpj" value="<%# DataBinder.Eval(Container.DataItem, "CNPJ_MOVIMENTO").ToString  %>" />
                </div>
                <div class="form-group col-md-1">
                    <label for="cnpj_distribuidor">Status</label>
                    <input disabled="disabled" type="text" class="form-control" id="txt_Status" value="<%# DataBinder.Eval(Container.DataItem, "ATIVO" ).ToString %>" />
                </div>

                <div class="form-group col-md-3">
                    <label for="representante">E-mail Representante <i class="fas fa-envelope"></i></label>
                    <input type="text" class="form-control" id="txt_rep" value="<%# DataBinder.Eval(Container.DataItem, "EMAIL_RESPONSAVEL").ToString %>" />
                </div>
            </div>

            <br />
            <%--  Atualização do distribuidor--%>
            <p class="font-weight-bold">Informações Distribuidor</p>
            <div class="form-row border border-light rounded bg-light" style="padding-top: 10px; padding-left: 10px">
                <div class="form-group col-md-3">
                    <label for="Data_Inicio">Ano/Mês Início</label>
                    <input type="month" class="form-control" id="txt_data_inicio" />
                </div>
                <div class="form-group col-md-3">
                    <label for="Data_Fim">Ano/Mês Fim</label>
                    <input type="month" class="form-control" id="txt_data_fim" />
                </div>
                <div class="form-group col-md-1">
                    <label for="distribuidor">Demanda</label>
                    <select id="cbo_captar_demanda" class="form-control">
                        <option value="0">Não</option>
                        <option value="1">Sim</option>
                    </select>
                </div>
                <div class="form-group col-md-1">
                    <label for="distribuidor">Estoque</label>
                    <select id="cbo_captar_estoque" class="form-control">
                        <option value="0">Não</option>
                        <option value="1">Sim</option>
                    </select>
                </div>
                <div class="form-group col-md-1">
                    <label for="distribuidor">Lote</label>
                    <select id="cbo_captar_lote" class="form-control">
                        <option value="0">Não</option>
                        <option value="1">Sim</option>
                    </select>
                </div>
                <div class="form-group col-md-1">
                    <label for="distribuidor">Delivery</label>
                    <select id="cbo_captar_delivery" class="form-control">
                        <option value="0">Não</option>
                        <option value="1">Sim</option>
                    </select>
                </div>
            </div>
            <br />
            <p class="font-weight-bold">Contato Mapa</p>
            <div class="form-row border border-light rounded bg-light" style="padding-top: 10px; padding-left: 10px">
                <div class="form-group col-md-4">
                    <label for="Nome Contato mapa">Nome</label>
                    <input type="text" class="form-control" id="txt_nome_contato_mapa" value="<%# DataBinder.Eval(Container.DataItem, "CONTATO").ToString %>" />
                </div>
                <div class="form-group col-md-5">
                    <label for="e-mail_notificacao">E-mail de Notificação <i class="fas fa-envelope"></i></label>
                    <input type="text" class="form-control" id="txt_email_contato_mapa" value="<%# DataBinder.Eval(Container.DataItem, "CONTATO_EMAIL").ToString %>" />
                </div>
                <div class="form-group col-md-3">
                    <label for="Telefone_contato">Telefone <i class="fas fa-phone-alt"></i></label>
                    <input type="text" class="form-control" id="txt_tel_mapa" value="<%# DataBinder.Eval(Container.DataItem, "CONTATO_TELEFONE").ToString %>" />
                </div>
            </div>
            <br />

            <p class="font-weight-bold">Contato Vendas a Consumidores</p>
            <div class="form-row border border-light rounded bg-light" style="padding-top: 10px; padding-left: 10px">
                <div class="form-group col-md-4">
                    <label for="Nome Contato de venda">Nome <i class="fas fa-user-alt"></i></label>
                    <input type="text" class="form-control" id="txt_nome_contato_vendas" value="<%# DataBinder.Eval(Container.DataItem, "CONTATO_SAC").ToString %>" />
                </div>
                <div class="form-group col-md-5">
                    <label for="e-mail de vendas">E-mail <i class="fas fa-envelope"></i></label>
                    <input type="text" class="form-control" id="txt_email_contato_vendas" value="<%# DataBinder.Eval(Container.DataItem, "CONTATO_SAC_EMAIL").ToString %>" />
                </div>
                <div class="form-group col-md-3">
                    <label for="Telefone_Contato_Vendas">Telefone <i class="fas fa-phone-alt"></i></label>
                    <input type="text" class="form-control" id="txt_tel_Vendas" value="<%# DataBinder.Eval(Container.DataItem, "CONTATO_SAC_TELEFONE").ToString %>" />
                </div>
            </div>
            <br />
            <p class="font-weight-bold">Região de Atendimento</p>
            <div class="form-row border border-light rounded bg-light" style="padding-top: 10px; padding-left: 10px">
                <div class="form-group col-md-2">
                    <label for="Telefone_Contato_Vendas">Aréa de atendimento <i class="fas fa-map-marked-alt"></i></label>
                    <input type="text" class="form-control" id="txt_area_atendimento" value="<%# DataBinder.Eval(Container.DataItem, "REGIAO_ATENDIMENTO").ToString %>" />
                </div>
            </div>
            <div class="form-row border border-light rounded bg-light" style="padding-left: 30px">
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="check_ac" value="1">
                    <label class="form-check-label" for="inlineCheckbox1">AC</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="check_al" value="1">
                    <label class="form-check-label" for="inlineCheckbox2">AL</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="check_ap" value="1">
                    <label class="form-check-label" for="inlineCheckbox2">AP</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="check_am" value="1">
                    <label class="form-check-label" for="inlineCheckbox2">AM</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="check_ba" value="1">
                    <label class="form-check-label" for="inlineCheckbox2">BA</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="check_ce" value="1">
                    <label class="form-check-label" for="inlineCheckbox2">CE</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="check_df" value="1">
                    <label class="form-check-label" for="inlineCheckbox2">DF</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="check_es" value="1">
                    <label class="form-check-label" for="inlineCheckbox2">ES</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="check_go" value="1">
                    <label class="form-check-label" for="inlineCheckbox2">GO</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="check_ma" value="1">
                    <label class="form-check-label" for="inlineCheckbox2">MA</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="check_mt" value="1">
                    <label class="form-check-label" for="inlineCheckbox2">MT</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="check_ms" value="1">
                    <label class="form-check-label" for="inlineCheckbox2">MS</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="check_mg" value="1">
                    <label class="form-check-label" for="inlineCheckbox2">MG</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="check_pa" value="1">
                    <label class="form-check-label" for="inlineCheckbox2">PA</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="check_pb" value="1">
                    <label class="form-check-label" for="inlineCheckbox2">PB</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="check_pr" value="1">
                    <label class="form-check-label" for="inlineCheckbox2">PR</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="check_pe" value="1">
                    <label class="form-check-label" for="inlineCheckbox2">PE</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="check_pi" value="1">
                    <label class="form-check-label" for="inlineCheckbox2">PI</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="check_rj" value="1">
                    <label class="form-check-label" for="inlineCheckbox2">RJ</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="check_rn" value="1">
                    <label class="form-check-label" for="inlineCheckbox2">RN</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="check_rs" value="1">
                    <label class="form-check-label" for="inlineCheckbox2">RS</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="check_ro" value="1">
                    <label class="form-check-label" for="inlineCheckbox2">RO</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="check_rr" value="1">
                    <label class="form-check-label" for="inlineCheckbox2">RR</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="check_SC" value="1">
                    <label class="form-check-label" for="inlineCheckbox2">SC</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="check_sp" value="1">
                    <label class="form-check-label" for="inlineCheckbox2">SP</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="check_se" value="1">
                    <label class="form-check-label" for="inlineCheckbox2">SE</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="checkbox" id="check_to" value="1">
                    <label class="form-check-label" for="inlineCheckbox2">TO</label>
                </div>
            </div>
            <hr />
            <button runat="server" id="cmd_OK" type="button" class="btn btn-primary">Atualizar</button>
            <br />
            <br />


            <%-- <p>Id:<%# DataBinder.Eval(Container.DataItem, "ID_GRUPO_DISTRIBUIDOR").ToString  %></p>
            <p>Grupo:<%# DataBinder.Eval(Container.DataItem, "GRUPO_DISTRIBUIDOR").ToString  %></p>--%>
        </ItemTemplate>
    </asp:Repeater>
    <%--<asp:DropDownList ID="cmb_Distribuidores" runat="server" CssClass="form-control" DataSourceID="dtsDistribuidores" DataTextField="GRUPO_DISTRIBUIDOR" DataValueField="ID_GRUPO_DISTRIBUIDOR"></asp:DropDownList>--%>
    <asp:SqlDataSource ID="dtsDistribuidores" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [TBL_DISTRIBUIDORES_GRUPOS] WHERE ([ATIVO] = @ATIVO)">
        <SelectParameters>
            <asp:Parameter DefaultValue="TRUE" Name="ATIVO" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
    <!--Datasources -->
    <asp:SqlDataSource ID="dtsFicha" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [TBL_DISTRIBUIDORES_GRUPOS] WHERE ([ID_GRUPO_DISTRIBUIDOR] = @ID_GRUPO_DISTRIBUIDOR)">
        <SelectParameters>
            <asp:QueryStringParameter Name="ID_GRUPO_DISTRIBUIDOR" QueryStringField="ID_GRUPO_DISTRIBUIDOR" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">

    <!-- Scripts Jquery, popper, bootstrap -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"></script>
    <!-- Scripts Jquery, popper, bootstrap -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"></script>

</asp:Content>
