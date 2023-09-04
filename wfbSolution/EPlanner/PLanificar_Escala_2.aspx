<%@ Page Title="PLANEJAR ESCALA" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="PLanificar_Escala_2.aspx.vb" Inherits="EPlanner.PLanificar_Escala_2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">

    <%--CAIXA DE TEXTO PERIODO--%>
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

    <%--TABELA PARA PLANIFICAR--%>
    <div class="row">
        <table class="table table-bordered">
            <thead>
                <tr>
                    <asp:Repeater ID="dtr_Cabecalho" runat="server" DataSourceID="dts_Cabecalho">
                        <ItemTemplate>
                             <%#"<th style='background-color:" & DataBinder.Eval(Container.DataItem, "COR_FUNDO") & "; color:" & DataBinder.Eval(Container.DataItem, "COR_FONTE") & "; font-weight: bold; text-align: center; vertical-align: middle'><strong>" & DataBinder.Eval(Container.DataItem, "PLANNER_SIGLA") & "<strong>"%>

                                   <%-- <%# "<a href='DashBoard_Detail_Colaboradores.aspx?rptId=5&Id_Andar=" & DataBinder.Eval(Container.DataItem, "Id_Andar") & "&Id_Zona=" & DataBinder.Eval(Container.DataItem, "Id_Zona") & "&Id_Universo=" & DataBinder.Eval(Container.DataItem, "Id_Universo") & "' class='progress-bar text-white bg-primary' role='progressbar' style='font-size:large; width:" & Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Pct_Colaboradores_Presentes") * 100) & "%'>" & Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Qtd_Colaboradores_Presentes")) & " presente(s) </a>"%>--%>

                            </th>
                        </ItemTemplate>
                    </asp:Repeater>
                    
                </tr>

            </thead>


        </table>


    </div>
    

   <%-- CABECALHO DA TABELA COM DIA, EU E CORES--%>
    <asp:SqlDataSource ID="dts_Cabecalho" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM VIEW_PLANNER_SIGLAS_CABECALHO"></asp:SqlDataSource>
</asp:Content>
