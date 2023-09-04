<%@ Page Title="Planificar" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Planificar.aspx.vb" Inherits="EPlanner.Planificar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <div class="row">

        <div class="form-group">
            <label for="txt_DATA">Data</label>
            <input runat="server" class="form-control text-center" id="txt_DATA" placeholder="Data" />
        </div>

        <div class="form-group">
            <label for="cmb_PLANNER">Planner</label>
            <asp:DropDownList ID="cmb_PLANNER_SIGLA" runat="server" DataSourceID="dts_PLANNER_SIGLAS" DataTextField="PLANNER" DataValueField="PLANNER_SIGLA" CssClass="form-control"></asp:DropDownList>
            <small id="toolTip_PLANNER" class="form-text text-muted">Selecione a sigla para planificar seu dia</small>
        </div>

        <asp:Button ID="cmd_PLANIFICAR" runat="server" Text="PLANIFICAR" CssClass="btn btn-primary  btn-block" />
        <asp:Button ID="cmd_CANCELAR" runat="server" Text="CANCELAR" CssClass="btn btn-danger  btn-block" />
    </div>


  <div class="accordion" id="accordionExample">
  <div class="card">
    <div class="card-header" id="headingOne">
      <h5 class="mb-0">
        <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
          Grupo de itens colapsável #1
        </button>
      </h5>
    </div>

    <div id="collapseOne" class="collapsed" aria-labelledby="headingOne" data-parent="#accordionExample">
      <div class="card-body">
        Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non alemanha 0 x 2 coreia do sul cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
      </div>
    </div>
  </div>
  
      
      <div class="card">
    <div class="card-header" id="headingTwo">
      <h5 class="mb-0">
        <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
          Grupo de itens colapsável #2
        </button>
      </h5>
    </div>
    <div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordionExample">
      <div class="card-body">
        Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
      </div>
    </div>
  </div>
  <div class="card">
    <div class="card-header" id="headingThree">
      <h5 class="mb-0">
        <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
          Grupo de itens colapsável #3
        </button>
      </h5>
    </div>
    <div id="collapseThree" class="collapse" aria-labelledby="headingThree" data-parent="#accordionExample">
      <div class="card-body">
        Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
      </div>
    </div>
  </div>
</div>
    <asp:SqlDataSource ID="dts_PLANNER_SIGLAS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [PLANNER_SIGLA], [PLANNER] FROM [VIEW_PLANNER_SIGLAS] ORDER BY [PLANNER_SIGLA]"></asp:SqlDataSource>
</asp:Content>
