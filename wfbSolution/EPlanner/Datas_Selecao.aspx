<%@ Page Title="Selecionar Datas" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Datas_Selecao.aspx.vb" Inherits="EPlanner.Datas_Selecao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <script>
        $(document).ready(function () {
            $('.datepicker').datepicker({
                format: 'dd/mm/yyyy',
                language: 'pt-BR'
            });
        });

    </script>

    <div class="row">
        <div class="col-lg-8">
            <div>
                <div class="form-horizontal">
                    <div class="form-group row mb-3">
                        <label class="col-form-label col-sm-4">Multiple Date</label>
                        <div class="col-sm-8">
                            <div class="input-group">
                                <input type="text" class="form-control" placeholder="mm/dd/yyyy" data-provide="datepicker" data-date-multidate="true" />
                                <div class="input-group-append">
                                    <span class="input-group-text bg-primary b-0 text-white"><i class="ti-calendar"></i></span>
                                </div>
                            </div>
                            <!-- input-group -->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

   
    <input type="date" data-date-multidate="true" />

    <div class="input-group">
        <input type="text" class="form-control" placeholder="dd/mm/yyyy" data-provide="datepicker" data-date-multidate="true" />
        <div class="input-group-append">
            <span class="input-group-text bg-primary b-0 text-white"><i class="ti-calendar"></i></span>
        </div>
    </div>


</asp:Content>
