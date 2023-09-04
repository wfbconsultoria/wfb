<%@ Page Title="PLANEJAR ESCALA" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Calendario_Mes.aspx.vb" Inherits="EPlanner.Calendario_Mes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">

    <div class="form-row">
        <div class="form-group col-md-12">
           <%-- <asp:Label ID="lbl_AnoMes" runat="server" Text="Label" AssociatedControlID="cmb_AnoMes">Período</asp:Label>--%>
            <asp:DropDownList ID="cmb_AnoMes" runat="server" CssClass="form-control" AutoPostBack="True">
                <asp:ListItem Value="202110">Outubro/2021 - Fechado</asp:ListItem>
                <asp:ListItem Selected="True" Value="202111">Novembro/2021 - Atual</asp:ListItem>
                <asp:ListItem Value="202112">Dezembro/2021 - Planificar </asp:ListItem>
            </asp:DropDownList>
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

   <h6 class="text-muted">Resumo minha loja</h6>
    <div class="row">
        <asp:Table ID="tb_CALENDARIO_LOJA" CssClass="table table-bordered table-hover" runat="server" Width="100%" HorizontalAlign="Center" Font-Size="Small">
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
     <hr />
</asp:Content>
