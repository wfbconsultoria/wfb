<%@ Page Title="C" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Distribuidores_Cadastro.aspx.vb" Inherits="CSL_2020.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
   <%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Distribuidores_Cadastro.aspx.vb" Inherits="CSL_2020.Distribuidor" %>
  <h2 class="container text-center">Atualização dos Distribuidores</h2>
  <hr/>
  <p class="font-weight-bold">Grupo Distribuidor</p>
  <div class="form-row border border-light rounded bg-light" style="padding-top: 10px; padding-left: 10px">
    <div class="form-group col-md-1" >
      <label for="Id Grupo" >Id Grupo</label>
      <input disabled="disabled" runat="server" type="Number" class="form-control" id="txt_id_grupo" value="1" />
    </div>
    <div class="form-group col-md-3">
      <label for="distribuidor">Grupo distribuidor</label>
      <select id="cbo_distribuidor" class="form-control">
        <option value="1">Expressa</option>
        <option value="2">Rio Bahia</option>
        <option value="3">S3 Med</option>
        <option value="4">Victoria</option>
        <option value="10">Santa Cruz</option>
      </select>
    </div>
    <div class="form-group col-md-3">
      <label for="cnpj_distribuidor">CNPJ</label>
      <input type="text" class="form-control" id="txt_cnpj" value="10336845000106"/>
    </div>
  </div>
  <br/>



  <p class="font-weight-bold">Informações Distribuidor</p>
  <div class="form-row border border-light rounded bg-light" style="padding-top: 10px; padding-left: 10px">
    <div class="form-group col-md-1">
      <label for="distribuidor">Ativo</label>
      <select id="cbo_ativo" class="form-control">
        <option value="0">Sim</option>
        <option value="1">Não</option>
      </select>
    </div>
    <div class="form-group col-md-3">
      <label for="Data_Inicio">Ano/Mês Início</label>
      <input type="month" class="form-control" id="txt_data_inicio"/>
    </div>
    <div class="form-group col-md-3">
      <label for="Data_Fim">Ano/Mês Fim</label>
      <input type="month" class="form-control" id="txt_data_fim"/>
    </div>
    <div class="form-group col-md-1">
      <label for="distribuidor">Demanda</label>
      <select id="cbo_captar_demanda" class="form-control">
        <option value="0">Sim</option>
        <option value="1">Não</option>
      </select>
    </div>
    <div class="form-group col-md-1">
      <label for="distribuidor">Estoque</label>
      <select id="cbo_captar_estoque" class="form-control">
        <option value="0">Sim</option>
        <option value="1">Não</option>
      </select>
    </div>
    <div class="form-group col-md-1">
      <label for="distribuidor">Lote</label>
      <select id="cbo_captar_lote" class="form-control">
        <option value="0">Sim</option>
        <option value="1">Não</option>
      </select>
    </div>
    <div class="form-group col-md-1">
      <label for="distribuidor">Delivery</label>
      <select id="cbo_captar_delivery" class="form-control">
        <option value="0">Sim</option>
        <option value="1">Não</option>
      </select>
    </div>
  </div>
  <br/>
  <p class="font-weight-bold">Contato CSL</p>
  <div class="form-row border border-light rounded bg-light" style="padding-top: 10px; padding-left: 10px">
    <div class="form-group col-md-4" >
      <label for="Nome Contato" >Nome Contato</label>
      <input   type="text" class="form-control" id="txt_nome_contato" placeholder="Nome do contato CSL"/>
    </div>
    <div class="form-group col-md-4" >
      <label for="representante" >E-mail Representante</label>
      <input disabled="disabled"  type="text" class="form-control" id="txt_rep" value="bruna.claro@cslbehring.com" />
    </div>
    <div class="form-group col-md-3">
      <label for="Telefone_contato"><i class="fas fa-phone"></i>Telefone</label>
      <input type="text" class="form-control" id="txt_tel_csl" placeholder="(xx) xxxx-xxxx"/>
    </div>
  </div>
  <br/>
  <p class="font-weight-bold">Contato Mapa</p>
  <div class="form-row border border-light rounded bg-light" style="padding-top: 10px; padding-left: 10px">
    <div class="form-group col-md-4" >
      <label for="Nome Contato mapa" >Nome Contato</label>
      <input   type="text" class="form-control" id="txt_nome_contato_mapa" placeholder="Nome do responsavel que envia os mapas"/>
    </div>
    <div class="form-group col-md-5" >
      <label for="e-mail_notificacao" >E-mail de Notificação</label>
      <input   type="text" class="form-control" id="txt_email_contato_mapa" placeholder="E-mail que iremos cobrar os mapas"/>
    </div>
    <div class="form-group col-md-3">
      <label for="Telefone_contato">Telefone</label>
      <input type="text" class="form-control" id="txt_tel_mapa" placeholder="(xx) xxxx-xxxx"/>
    </div>
  </div>
  <br/>
  <p class="font-weight-bold">Contato Vendas a Consumidores</p>
  <div class="form-row border border-light rounded bg-light" style="padding-top: 10px; padding-left: 10px">
    <div class="form-group col-md-4" >
      <label for="Nome Contato de venda" >Nome Contato</label>
      <input  runat="server" type="text" class="form-control" id="txt_nome_contato_vendas" placeholder="Nome do responsavel"/>
    </div>
    <div class="form-group col-md-5" >
      <label for="e-mail de vendas" >E-mail</label>
      <input   type="text" class="form-control" id="txt_email_contato_vendas" placeholder="E-mail que iremos de atendimento"/>
    </div>
    <div class="form-group col-md-3">
      <label for="Telefone_Contato_Vendas">Telefone</label>
      <input type="text" class="form-control" id="txt_tel_Vendas" placeholder="(xx) xxxx-xxxx"/>
    </div>
  </div>
  <hr/>
  <button runat="server" id="cmd_OK" type="button" class="btn btn-primary">Atualizar</button>




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
<script type="text/javascript">

    document.getElementById('cbo_ativo').addEventListener('change', function () {
        //alert(1);
        if (this.value == '1') {
            document.getElementById("cbo_captar_demanda").disabled = true;
            document.getElementById("cbo_captar_estoque").disabled = true;
            document.getElementById("cbo_captar_lote").disabled = true;
            document.getElementById("cbo_captar_delivery").disabled = true;
            document.getElementById("txt_data_inicio").disabled = true;

        } else {
            document.getElementById("cbo_captar_demanda").disabled = false;
            document.getElementById("cbo_captar_estoque").disabled = false;
            document.getElementById("cbo_captar_lote").disabled = false;
            document.getElementById("cbo_captar_delivery").disabled = false;
            document.getElementById("txt_data_inicio").disabled = false;
        }
    });


</script>
</asp:Content>
