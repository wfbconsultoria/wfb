<%@ Page Title="DashBoard" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="DashBoard.aspx.vb" Inherits="Chapeira.DashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <h4 class="text-secondary text-uppercase"><%:Page.Title %></h4>

    <%--QUADRO DE COLABORADORES E BRIGADISTAS DA LOJA (Total de colaboradores/ brigadistas presentes e ausentes na loja)--%>
    <div class="row">
        <%--COLABORADORES POR LOJA--%>
        <div class="card col-md-6">
            <img class="rounded mx-auto d-block" src="Images/Decathlon_Colaboradores.png" />
            <%--Colaboradores--%>
            <div class="card-body">
                <h5 class="text-center badge-primary">Colaboradores</h5>
                <%--Colaboradores Total--%>
                <div class="input-group">
                    <%--link Lista todos os colaboradores--%>
                    <a href="DashBoard_Detail_Colaboradores.aspx?rptId=1&Id_Andar=0&Id_Zona=0&Id_Universo=0" class="form-control">Total</a>
                    <div class="input-group-append">
                        <span class="input-group-text badge-primary">
                            <asp:Literal ID="txt_Colaboradores" runat="server"></asp:Literal></span>
                    </div>
                </div>

                <%--Colaboradores Presentes--%>
                <div class="input-group">
                    <%--link Lista colaboradores presentes--%>
                    <a href="DashBoard_Detail_Colaboradores.aspx?rptId=2&Id_Andar=0&Id_Zona=0&Id_Universo=0" class="form-control">Presentes</a>
                    <div class="input-group-append">
                        <span class="input-group-text badge-success">
                            <asp:Literal ID="txt_Colaboradores_Presentes_Percent" runat="server"></asp:Literal></span>
                        <span class="input-group-text badge-success">
                            <asp:Literal ID="txt_Colaboradores_Presentes" runat="server"></asp:Literal></span>
                    </div>
                </div>
                <%--Colaboradores Ausentes--%>
                <div class="input-group">
                    <%--link Lista colaboradores ausentes--%>
                    <a href="DashBoard_Detail_Colaboradores.aspx?rptId=3&Id_Andar=0&Id_Zona=0&Id_Universo=0" class="form-control">Ausentes</a>
                    <div class="input-group-append">
                        <span class="input-group-text badge-light">
                            <asp:Literal ID="txt_Colaboradores_Ausentes_Percent" runat="server"></asp:Literal></span>
                        <span class="input-group-text badge-light">
                            <asp:Literal ID="txt_Colaboradores_Ausentes" runat="server"></asp:Literal></span>
                    </div>
                </div>
            </div>
        </div>

        <%--BRIGADISTAS POR LOJA--%>
        <div class="card col-md-6">
            <img class="rounded mx-auto d-block" src="Images/Decathlon_Brigadista_Small.png" />
            <div class="card-body">
                <h5 class="text-center badge-danger" style="color: yellow">Brigadistas</h5>
                <%--Brigadistas Total--%>
                <div class="input-group">
                    <%--link Lista todos os brigadistas--%>
                    <a href="DashBoard_Detail_Brigadistas.aspx?rptId=1&Id_Andar=0&Id_Zona=0&Id_Universo=0" class="form-control">Total</a>
                    <div class="input-group-append">
                        <span class="input-group-text badge-danger">
                            <asp:Literal ID="txt_Brigadistas" runat="server"></asp:Literal></span>
                    </div>
                </div>
                <%--Brigadistas Presentes--%>
                <div class="input-group">
                    <%--link Lista brigadistas presentes--%>
                    <a href="DashBoard_Detail_Brigadistas.aspx?rptId=2&Id_Andar=0&Id_Zona=0&Id_Universo=0" class="form-control">Presentes</a>
                    <div class="input-group-append">
                        <span class="input-group-text badge-success">
                            <asp:Literal ID="txt_Brigadistas_Presentes_Percent" runat="server"></asp:Literal></span>
                        <span class="input-group-text badge-success">
                            <asp:Literal ID="txt_Brigadistas_Presentes" runat="server"></asp:Literal></span>
                    </div>
                </div>
                <%--Brigadistas Ausentes--%>
                <div class="input-group">
                    <%--link Lista brigadistas ausentes--%>
                    <a href="DashBoard_Detail_Brigadistas.aspx?rptId=3&Id_Andar=0&Id_Zona=0&Id_Universo=0" class="form-control">Ausentes</a>
                    <div class="input-group-append">
                        <span class="input-group-text badge-light">
                            <asp:Literal ID="txt_Brigadistas_Ausentes_Percent" runat="server"></asp:Literal></span>
                        <span class="input-group-text badge-light">
                            <asp:Literal ID="txt_Brigadistas_Ausentes" runat="server"></asp:Literal></span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--/**************************************************************************************************************************************--%>


    <%--PERCENTUAL DA EQUIPE FORMADA TOTAL LOJA (Total de colaboradores por Loja/Zona que estão formados como brigadistas)--%>
    <br />
    <div class="card">
        <a href="DashBoard_Detail_Formados.aspx?rptId=1&Id_Andar=0&Id_Zona=0&Id_Universo=0">
            <h6 class="card-header bg-danger text-uppercase" style="color: white"><strong>PERCENTUAL DE BRIGADISTAS FORMADOS</strong></h6>
        </a>

        <div class="card-body">
            <div class="text-right">
                <h5><a href="DashBoard_Detail_Formados.aspx?rptId=2&Id_Andar=0&Id_Zona=0&Id_Universo=0"><span class="badge badge-danger text-white">Bigadistas Formados</span></a>&nbsp;
                <a href="DashBoard_Detail_Formados.aspx?rptId=3&Id_Andar=0&Id_Zona=0&Id_Universo=0"><span class="badge badge-warning text-white">Não Brigadistas</span></a></h5>
            </div>
            <%--Percentual equipe formada por loja--%>
            <asp:Repeater ID="dtr_Lojas" runat="server" DataSourceID="dtsLojas">
                <ItemTemplate>
                    <div class="row" style="padding-top: 10px">
                        <div class="col-md-3 text-nowrap text-uppercase"><a href="DashBoard_Detail_Formados.aspx?rptId=1&Id_Andar=0&Id_Zona=0&Id_Universo=0"><strong>Total Loja </strong></a></div>
                        <div class="col-sm-9">
                            <div class="progress" style="height: 50px">
                            <%# "<a href='DashBoard_Detail_Formados.aspx?rptId=2&Id_Andar=0&Id_Zona=0&Id_Universo=0 ' class='progress-bar bg-danger' role='progressbar' style='font-size:large; width:" & Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Pct_Brigadistas") * 100) & "%'>" & Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Pct_Brigadistas") * 100) & "% (" & Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Qtd_Brigadistas")) & " brigadistas) </a>"%>
                            <%# "<a href='DashBoard_Detail_Formados.aspx?rptId=3&Id_Andar=0&Id_Zona=0&Id_Universo=0 ' class='progress-bar bg-warning' role='progressbar' style='font-size:large; width:" & Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Pct_Nao_Brigadistas") * 100) & "%'>" & Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Pct_Nao_Brigadistas") * 100) & "% (" & Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Qtd_Nao_Brigadistas")) & ") </a>"%></a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <%--Percentual equipe formada por zona--%>
            <asp:Repeater ID="dtrZonas" runat="server" DataSourceID="dtsZonas">
                <ItemTemplate>
                    <div class="row" style="padding-top: 5px">
                        <a href="DashBoard_Detail_Formados.aspx?rptId=4&Id_Andar=<%#DataBinder.Eval(Container.DataItem, "Id_Andar")%>&Id_Zona=<%#DataBinder.Eval(Container.DataItem, "Id_Zona")%>&Id_Universo=0" class="col-md-3 text-nowrap text-uppercase text-dark"><strong><%#  DataBinder.Eval(Container.DataItem, "Zona") %></strong></a>
                        <div class="col-sm-9">
                            <div class="progress" style="height: 35px">
                                <%# "<a href='DashBoard_Detail_Formados.aspx?rptId=5&Id_Andar=" & DataBinder.Eval(Container.DataItem, "Id_Andar") & "&Id_Zona=" & DataBinder.Eval(Container.DataItem, "Id_Zona") & "&Id_Universo=0" & "' class='progress-bar bg-danger' role='progressbar' style='font-size:large; width:" & Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Pct_Brigadistas") * 100) & "%'>" & Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Pct_Brigadistas") * 100) & "% (" & Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Qtd_Brigadistas")) & " brigadistas) </a>"%>
                                <%# "<a href='DashBoard_Detail_Formados.aspx?rptId=6&Id_Andar=" & DataBinder.Eval(Container.DataItem, "Id_Andar") & "&Id_Zona=" & DataBinder.Eval(Container.DataItem, "Id_Zona") & "&Id_Universo=0" & "' class='progress-bar bg-warning' role='progressbar' style='font-size:large; width:" & Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Pct_Nao_Brigadistas") * 100) & "%'>" & Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Pct_Nao_Brigadistas") * 100) & "% (" & Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Qtd_Nao_Brigadistas")) & ") </a>"%></a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <%--/**************************************************************************************************************************************--%>


    <%--BRIGADISTAS PRESENTES POR ZONA--%>
    <%--Total de colaboradores brigadistas formados presentes por zona na loja--%>
    <br />
    <div class="card">
        <a href="DashBoard_Detail_Brigadistas.aspx?rptId=2&Id_Andar=0&Id_Zona=0&Id_Universo=0">
            <h6 class="card-header bg-danger text-uppercase" style="color: white"><strong>Brigadistas Presentes por Zona</strong></h6>
        </a>
        <div class="card-body">
            <div class="text-right">
                <h5>
                    <a href="DashBoard_Detail_Brigadistas.aspx?rptId=2&Id_Andar=0&Id_Zona=0&Id_Universo=0"><span class="badge badge-danger tex-white">Brigadistas Presentes</span></a>&nbsp;
                    <a href="DashBoard_Detail_Brigadistas.aspx?rptId=3&Id_Andar=0&Id_Zona=0&Id_Universo=0"><span class="badge badge-light text-muted">Brigadistas Ausentes</span></a>
                </h5>
            </div>
            <asp:Repeater ID="dtrBrigadistasPresentesPorZona" runat="server" DataSourceID="dtsZonas">
                <ItemTemplate>
                    <div class="row" style="padding-top: 5px">
                        <a href="DashBoard_Detail_Brigadistas.aspx?rptId=4&Id_Andar=<%#DataBinder.Eval(Container.DataItem, "Id_Andar")%>&Id_Zona=<%#DataBinder.Eval(Container.DataItem, "Id_Zona")%>&Id_Universo=0" class="col-md-3 text-nowrap text-uppercase text-dark"><strong><%#  DataBinder.Eval(Container.DataItem, "Zona") %></strong></a>
                        <div class="col-sm-9">
                            <div class="progress" style="height: 35px">
                                <%# "<a href='DashBoard_Detail_Brigadistas.aspx?rptId=5&Id_Andar=" & DataBinder.Eval(Container.DataItem, "Id_Andar") & "&Id_Zona=" & DataBinder.Eval(Container.DataItem, "Id_Zona") & "&Id_Universo=0" & "' class='progress-bar text-white bg-danger' role='progressbar' style='font-size:large; width:" & Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Pct_Brigadistas_Presentes") * 100) & "%'>" & Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Qtd_Brigadistas_Presentes")) & " presente(s) </a>"%>
                                <%# "<a href='DashBoard_Detail_Brigadistas.aspx?rptId=6&Id_Andar=" & DataBinder.Eval(Container.DataItem, "Id_Andar") & "&Id_Zona=" & DataBinder.Eval(Container.DataItem, "Id_Zona") & "&Id_Universo=0" & "' class='progress-bar text-dark bg-light' role='progressbar' style='font-size:large; width:" & Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Pct_Brigadistas_Ausentes") * 100) & "%'>" & Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Qtd_Brigadistas_Ausentes")) & " ausentes(s) </a>"%>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <%--/**************************************************************************************************************************************--%>


    <%--QUADRO DE COLABORADORES E TERCEIROS PRESENTES POR UNIVERSO--%>
    <%--Quantidade de colaboradores presentes por universo na loja--%>
    <br />
    <div class="card">
        <a href="DashBoard_Detail_Colaboradores.aspx?rptId=2&Id_Andar=0&Id_Zona=0&Id_Universo=0">
            <h6 class="card-header bg-primary text-uppercase" style="color: white"><strong>Presentes por Universo</strong></h6>
        </a>
        <div class="card-body">
            <div class="text-right">
                <h5>
                    <a href="DashBoard_Detail_Colaboradores.aspx?rptId=2&Id_Andar=0&Id_Zona=0&Id_Universo=0"><span class="badge badge-primary">Colaboradores Presentes</span></a>&nbsp;
                    <a href="DashBoard_Detail_Colaboradores.aspx?rptId=3&Id_Andar=0&Id_Zona=0&Id_Universo=0"><span class="badge badge-light text-muted">Colaboradores Ausentes</span></a>&nbsp;
                    <span class="badge badge-info">Serviços Presentes</span>
                </h5>
            </div>
            <asp:Repeater ID="dtrColaboradoresPresentes_Universo" runat="server" DataSourceID="dtsUniversos">
                <ItemTemplate>
                    <div class="row" style="padding-top: 10px">
                        <a href="DashBoard_Detail_Colaboradores.aspx?rptId=4&Id_Andar=<%#DataBinder.Eval(Container.DataItem, "Id_Andar")%>&Id_Zona=<%#DataBinder.Eval(Container.DataItem, "Id_Zona")%>&Id_Universo=<%#DataBinder.Eval(Container.DataItem, "Id_Universo")%>" class="col-md-3 text-nowrap text-uppercase text-primary"><strong><%#  DataBinder.Eval(Container.DataItem, "Universo") %></strong></a>
                        <div class="col-sm-9">
                            <div class="progress" style="height: 40px">
                                <%# "<a href='DashBoard_Detail_Colaboradores.aspx?rptId=5&Id_Andar=" & DataBinder.Eval(Container.DataItem, "Id_Andar") & "&Id_Zona=" & DataBinder.Eval(Container.DataItem, "Id_Zona") & "&Id_Universo=" & DataBinder.Eval(Container.DataItem, "Id_Universo") & "' class='progress-bar text-white bg-primary' role='progressbar' style='font-size:large; width:" & Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Pct_Colaboradores_Presentes") * 100) & "%'>" & Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Qtd_Colaboradores_Presentes")) & " presente(s) </a>"%>
                                <%# "<a href='DashBoard_Detail_Colaboradores.aspx?rptId=6&Id_Andar=" & DataBinder.Eval(Container.DataItem, "Id_Andar") & "&Id_Zona=" & DataBinder.Eval(Container.DataItem, "Id_Zona") & "&Id_Universo=" & DataBinder.Eval(Container.DataItem, "Id_Universo") & "' class='progress-bar text-dark  bg-light'  role='progressbar' style='font-size:large; width:" & Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Pct_Colaboradores_Ausentes") * 100) & "%'>" & Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Qtd_Colaboradores_Ausentes")) & " ausentes(s) </a>"%>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <%--Quantidade de Terceiros presentes na loja--%>
            <asp:Repeater ID="dtrTerceiros" runat="server" DataSourceID="dtsTerceiros">
                <ItemTemplate>
                    <div class="row" style="padding-top: 10px">
                        <div class="col-md-3 text-nowrap text-uppercase"><strong>Serviços </strong></div>
                        <div class="col-sm-9">
                            <div class="progress" style="height: 40px">
                                <%# "<h6 class='progress-bar bg-info' role='progressbar' style='width:" & Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Pct_Terceiros_Presentes") * 100) & "%'>" & Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Qtd_Terceiros_Presentes")) & " presente(s) </h6>"%>
                                <%# "<h6 class='progress-bar bg-light text-secondary text-muted' role='progressbar' style='width:" & Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Pct_Terceiros_Ausentes") * 100) & "%'>" & Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Qtd_Terceiros_Ausentes")) & " ausente(s) </h6>"%>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <%--Quantidade de Visitantes presentes na loja--%>
            <asp:Repeater ID="dtrVisitantes" runat="server" DataSourceID="dtsVisitantes">
                <ItemTemplate>
                    <div class="row" style="padding-top: 10px">
                        <div class="col-md-3 text-nowrap text-uppercase"><strong>Visitantes </strong></div>
                        <div class="col-sm-9">
                            <div class="progress" style="height: 40px">
                                <%# "<h6 class='progress-bar bg-dark' role='progressbar' style='width:100%'>" & Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Qtd_Visitantes_Presentes")) & " presente(s) </h6>"%>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>
    </div>
    <%--/**************************************************************************************************************************************--%>

    <%--DATA SOURCES--%>
    <asp:SqlDataSource ID="dtsLojas" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dtsAndares" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dtsZonas" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dtsUniversos" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dtsVisitantes" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dtsTerceiros" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"></asp:SqlDataSource>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
