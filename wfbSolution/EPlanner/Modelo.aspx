<%@ Page Title="Modelos" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Modelo.aspx.vb" Inherits="EPlanner.Modelo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    
    <div class="row">

        <div class="form-row">
            <div class="form-group col-md-3">
                <label for="txt_ANO">Ano</label>
                <input runat="server" type="number" class="form-control" id="txt_ANO" placeholder="ANO" />
            </div>
            <div class="form-group col-md-3">
                <label for="txt_MES">Mês</label>
                <input runat="server" type="number" class="form-control" id="txt_MES" placeholder="MÊS" />
            </div>
        </div>
    </div>
    <div class="row">
        <asp:Table ID="tb_CALENDARIO" CssClass="table table-bordered table-hover" runat="server" Width="100%" HorizontalAlign="Center" Font-Size="Small">
            <asp:TableHeaderRow HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableHeaderCell Font-Size="Smaller" Text="SEG" HorizontalAlign="Center" VerticalAlign="Middle" />
                <asp:TableHeaderCell Font-Size="Smaller" Text="TER" HorizontalAlign="Center" VerticalAlign="Middle" />
                <asp:TableHeaderCell Font-Size="Smaller" Text="QUA" HorizontalAlign="Center" VerticalAlign="Middle" />
                <asp:TableHeaderCell Font-Size="Smaller" Text="QUI" HorizontalAlign="Center" VerticalAlign="Middle" />
                <asp:TableHeaderCell Font-Size="Smaller" Text="SEX" HorizontalAlign="Center" VerticalAlign="Middle" />
                <asp:TableHeaderCell Font-Size="Smaller" Text="SAB" HorizontalAlign="Center" VerticalAlign="Middle" />
                <asp:TableHeaderCell Font-Size="Smaller" Text="DOM" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TableHeaderRow>
        </asp:Table>
    </div>



</asp:Content>
