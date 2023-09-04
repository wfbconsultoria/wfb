<%@ Page Title="PLANEJAR ATIVIDADES" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Planificar_Atividades.aspx.vb" Inherits="EPlanner.Planificar_Atividades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">

    <link href="assets/css/_Planner_Table_Scroll.css" rel="stylesheet" />
    <div class="form-row">
        <div class="form-group col-md-12">
            <asp:Label ID="lbl_Data" runat="server" Text="Label" AssociatedControlID="txt_Data">Data</asp:Label>
                <asp:TextBox ID="txt_Data" runat="server" CssClass="form-control" Text="Segunda Feira 01/11/2021"></asp:TextBox>
        </div>
    </div>


    <div class="table table-overflow">
        <asp:Table ID="tbl_Planner" runat="server" CssClass="table" GridLines="Both" HorizontalAlign="Center" Width="100%">
            <asp:TableHeaderRow HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True">
                <asp:TableHeaderCell>Hora</asp:TableHeaderCell>
                <asp:TableHeaderCell>Atividade</asp:TableHeaderCell>
            </asp:TableHeaderRow>

            <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell Font-Bold="True">08:00</asp:TableCell>
                <asp:TableCell>OPERAÇÃO DE CAIXA</asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell Font-Bold="True">09:00</asp:TableCell>
                <asp:TableCell>&nbsp;</asp:TableCell>
            </asp:TableRow>

            <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell Font-Bold="True">10:00</asp:TableCell>
                <asp:TableCell>&nbsp;</asp:TableCell>
            </asp:TableRow>

            <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell Font-Bold="True">11:00</asp:TableCell>
                <asp:TableCell>&nbsp;</asp:TableCell>
            </asp:TableRow>

            <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell Font-Bold="True">12:00</asp:TableCell>
                <asp:TableCell>PROVADOR</asp:TableCell>
            </asp:TableRow>

             <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell Font-Bold="True">13:00</asp:TableCell>
                <asp:TableCell>&nbsp;</asp:TableCell>
            </asp:TableRow>

             <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell Font-Bold="True">14:00</asp:TableCell>
                <asp:TableCell>&nbsp;</asp:TableCell>
            </asp:TableRow>

             <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell Font-Bold="True">15:00</asp:TableCell>
                <asp:TableCell>&nbsp;</asp:TableCell>
            </asp:TableRow>

            <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell Font-Bold="True">16:00</asp:TableCell>
                <asp:TableCell>FORMAÇÃO/TREINAMENTO</asp:TableCell>
            </asp:TableRow>

            <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell Font-Bold="True">17:00</asp:TableCell>
                <asp:TableCell>&nbsp;</asp:TableCell>
            </asp:TableRow>

            <asp:TableFooterRow>
                <asp:TableCell VerticalAlign="Middle" HorizontalAlign="Center" ColumnSpan="3">ultima atualização</asp:TableCell>
            </asp:TableFooterRow>

        </asp:Table>
    </div>
    </asp:Content>