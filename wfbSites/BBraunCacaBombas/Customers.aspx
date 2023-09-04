<%@ Page Title="Meus Estabelecimentos" Language="VB" MasterPageFile="~/_Logged.master" AutoEventWireup="false" CodeFile="Customers.aspx.vb" Inherits="Customers" %>

<%@ Register Src="~/_PageTitle_Logged.ascx" TagPrefix="uc1" TagName="_PageTitle_Logged" %>

<%--PAGINA RESTRITA REQUER CONTROLE DE ACESSO E LOGIN--%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <div class="row d-flex flex-column flex-md-row align-items-center p-3 px-md-4 mb-3 bg-white border-bottom">
        <uc1:_PageTitle_Logged runat="server" ID="_PageTitle_Logged" />
        <%--Page Title--%>

        <%--Links e comandos da página, caso não seja utilizados comentar este trecho de código--%>
        <%--<nav class="my-2 my-md-0 mr-md-3">
            <a class="p-2" href="#">Page Link</a>
            <asp:LinkButton ID="cmd_01" runat="server" CssClass="p-2 text-dark">Commnad</asp:LinkButton>
            <asp:LinkButton ID="cmd_02" runat="server" CssClass="p-2 text-info">Action</asp:LinkButton>
            <asp:LinkButton ID="cmd_03" runat="server" CssClass="p-2 text-success">Sucess</asp:LinkButton>
            <asp:LinkButton ID="cmd_04" runat="server" CssClass="p-2 text-danger">Danger</asp:LinkButton>
        </nav>--%>
        <%--END Links e comandos--%>
    </div>

    <%--Conteudo da página--%>
    <div>

        <div class="col-sm-12">
            <div class="row">
                <div class="col-sm-12">
                    <%--<div class="card table-responsive">
                        <div class="card-body">--%>

                    <table id="datatable" class="table table-striped table-bordered dt-responsive" style="border-collapse: collapse; border-spacing: 0; width: 100%;">
                        <%--<thead>
                            <tr>
                                <th>Estabelecimento</th>
                            </tr>
                        </thead>--%>

                        <tbody>
                            <asp:Repeater ID="rpr_Table" runat="server" DataSourceID="dts_Table">
                                <ItemTemplate>
                                    <tr>
                                        <td><a href='<%# "../Customer.aspx?ID" + "=" + DataBinder.Eval(Container.DataItem, "Customer_Id").ToString%>'><%# DataBinder.Eval(Container.DataItem, "Customer_Name")%></a></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>

                        </tbody>
                    </table>

                </div>
                <!-- end col -->
            </div>
            <!-- end row -->
        </div>

    </div>
    <!--Data Sources -->
    <asp:SqlDataSource ID="dts_Table" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT * FROM [vw_Customers] ORDER BY [Customer_Name] "></asp:SqlDataSource>

    <%--END Conteudo da página--%>
</asp:Content>
