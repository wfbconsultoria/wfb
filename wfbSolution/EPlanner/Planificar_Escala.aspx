<%@ Page Title="PLANEJAR ESCALA" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Planificar_Escala.aspx.vb" Inherits="EPlanner.Planificar_Escala" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">

    <link href="assets/css/_Planner_Table_Scroll.css" rel="stylesheet" />
    <div class="form-row">
        <div class="form-group col-md-12">
            <asp:Label ID="lbl_Ano" runat="server" Text="Label" AssociatedControlID="cmb_Ano">Ano</asp:Label>
            <asp:DropDownList ID="cmb_Ano" runat="server" CssClass="form-control">
                <asp:ListItem>Outubro/2021 - Fechado </asp:ListItem>
                <asp:ListItem Selected="True">Novembro/2021 - Atual</asp:ListItem>
                <asp:ListItem>Dezembro/2021 - Planificar </asp:ListItem>
                <asp:ListItem>Janeiro/2022 - Aberto </asp:ListItem>
                <asp:ListItem>Fevereiro/2022 - Aberto </asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>


    <div class="table table-overflow">
        <asp:Table ID="tbl_Planner" runat="server" CssClass="table" GridLines="Both" HorizontalAlign="Center" Width="100%">
            <asp:TableHeaderRow HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True">
                <asp:TableHeaderCell>Dia</asp:TableHeaderCell>
                <asp:TableHeaderCell>Eu</asp:TableHeaderCell>
                <asp:TableHeaderCell BackColor="#FF6600" ForeColor="White">PA</asp:TableHeaderCell>
                <asp:TableHeaderCell BackColor="Red" ForeColor="White">PF</asp:TableHeaderCell>
                <asp:TableHeaderCell BackColor="Lime" ForeColor="Black">A</asp:TableHeaderCell>
                <asp:TableHeaderCell BackColor="#99FF99" ForeColor="Black">I</asp:TableHeaderCell>
                <asp:TableHeaderCell BackColor="#009900" ForeColor="White">F</asp:TableHeaderCell>
                <asp:TableHeaderCell BackColor="#66CCFF" ForeColor="White">FG</asp:TableHeaderCell>
            </asp:TableHeaderRow>

            <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell Font-Bold="True"><a href="Planificar_Atividades.aspx" class="dropdown-item notify-item">1-SEG</a></asp:TableCell>
                <asp:TableCell BackColor="Lime" ForeColor="Black" Font-Bold="True">A</asp:TableCell>
                <asp:TableCell BackColor="#FF6600" ForeColor="White">1</asp:TableCell>
                <asp:TableCell BackColor="Red" ForeColor="White">1</asp:TableCell>
                <asp:TableCell BackColor="Lime" ForeColor="Black">2</asp:TableCell>
                <asp:TableCell BackColor="#99FF99" ForeColor="Black">3</asp:TableCell>
                <asp:TableCell BackColor="#009900" ForeColor="White">1</asp:TableCell>
                <asp:TableCell BackColor="#66CCFF" ForeColor="White">3</asp:TableCell>
            </asp:TableRow>

            <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell Font-Bold="True"><a href="Planificar_Atividades.aspx" class="dropdown-item notify-item">2-TER</a></asp:TableCell>
                <asp:TableCell BackColor="White" Font-Bold="True">&nbsp</asp:TableCell>
                <asp:TableCell BackColor="#FF6600" ForeColor="White">1</asp:TableCell>
                <asp:TableCell BackColor="Red" ForeColor="White">1</asp:TableCell>
                <asp:TableCell BackColor="Lime" ForeColor="Black">2</asp:TableCell>
                <asp:TableCell BackColor="#99FF99" ForeColor="Black">3</asp:TableCell>
                <asp:TableCell BackColor="#009900" ForeColor="White">1</asp:TableCell>
                <asp:TableCell BackColor="#66CCFF" ForeColor="White">3</asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell Font-Bold="True"><a href="Planificar_Atividades.aspx" class="dropdown-item notify-item">4-QUA</a></asp:TableCell>
                <asp:TableCell BackColor="#FF6600" ForeColor="White" Font-Bold="True">PA</asp:TableCell>
               <asp:TableCell BackColor="#FF6600" ForeColor="White">1</asp:TableCell>
                <asp:TableCell BackColor="Red" ForeColor="White">1</asp:TableCell>
                <asp:TableCell BackColor="Lime" ForeColor="Black">2</asp:TableCell>
                <asp:TableCell BackColor="#99FF99" ForeColor="Black">3</asp:TableCell>
                <asp:TableCell BackColor="#009900" ForeColor="White">1</asp:TableCell>
                <asp:TableCell BackColor="#66CCFF" ForeColor="White">3</asp:TableCell>
            </asp:TableRow>

            
            <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell Font-Bold="True"><a href="Planificar_Atividades.aspx" class="dropdown-item notify-item">5-QUI</a></asp:TableCell>
                <asp:TableCell BackColor="#FF6600" ForeColor="White" Font-Bold="True">PA</asp:TableCell>
                <asp:TableCell BackColor="#FF6600" ForeColor="White">1</asp:TableCell>
                <asp:TableCell BackColor="Red" ForeColor="White">1</asp:TableCell>
                <asp:TableCell BackColor="Lime" ForeColor="Black">2</asp:TableCell>
                <asp:TableCell BackColor="#99FF99" ForeColor="Black">3</asp:TableCell>
                <asp:TableCell BackColor="#009900" ForeColor="White">1</asp:TableCell>
                <asp:TableCell BackColor="#66CCFF" ForeColor="White">3</asp:TableCell>
            </asp:TableRow>

            
            <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell Font-Bold="True"><a href="Planificar_Atividades.aspx" class="dropdown-item notify-item">6-SEX</a></asp:TableCell>
                <asp:TableCell BackColor="#FF6600" ForeColor="White" Font-Bold="True">PA</asp:TableCell>
                <asp:TableCell BackColor="#FF6600" ForeColor="White">1</asp:TableCell>
                <asp:TableCell BackColor="Red" ForeColor="White">1</asp:TableCell>
                <asp:TableCell BackColor="Lime" ForeColor="Black">2</asp:TableCell>
                <asp:TableCell BackColor="#99FF99" ForeColor="Black">3</asp:TableCell>
                <asp:TableCell BackColor="#009900" ForeColor="White">1</asp:TableCell>
                <asp:TableCell BackColor="#66CCFF" ForeColor="White">3</asp:TableCell>
            </asp:TableRow>

            
            <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell Font-Bold="True" BackColor="#FFFF99" ForeColor="#0000CC"><a href="Planificar_Atividades.aspx" class="dropdown-item notify-item">7-SAB</a></asp:TableCell>
                <asp:TableCell BackColor="#FF6600" ForeColor="White" Font-Bold="True">PA</asp:TableCell>
                <asp:TableCell BackColor="#FF6600" ForeColor="White">1</asp:TableCell>
                <asp:TableCell BackColor="Red" ForeColor="White">1</asp:TableCell>
                <asp:TableCell BackColor="Lime" ForeColor="Black">2</asp:TableCell>
                <asp:TableCell BackColor="#99FF99" ForeColor="Black">3</asp:TableCell>
                <asp:TableCell BackColor="#009900" ForeColor="White">1</asp:TableCell>
                <asp:TableCell BackColor="#66CCFF" ForeColor="White">3</asp:TableCell>
            </asp:TableRow>

            
            <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell Font-Bold="True" ForeColor="White" BackColor="Red"><a href="Planificar_Atividades.aspx" class="dropdown-item notify-item">8-DOM</a></asp:TableCell>
                <asp:TableCell BackColor="#FF6600" ForeColor="White" Font-Bold="True">PA</asp:TableCell>
                <asp:TableCell BackColor="#FF6600" ForeColor="White">1</asp:TableCell>
                <asp:TableCell BackColor="Red" ForeColor="White">1</asp:TableCell>
                <asp:TableCell BackColor="Lime" ForeColor="Black">2</asp:TableCell>
                <asp:TableCell BackColor="#99FF99" ForeColor="Black">3</asp:TableCell>
                <asp:TableCell BackColor="#009900" ForeColor="White">1</asp:TableCell>
                <asp:TableCell BackColor="#66CCFF" ForeColor="White">3</asp:TableCell>
            </asp:TableRow>



            <asp:TableFooterRow>
                <asp:TableCell VerticalAlign="Middle" HorizontalAlign="Center" ColumnSpan="8">ultima atualização</asp:TableCell>
            </asp:TableFooterRow>

        </asp:Table>
    </div>

</asp:Content>
