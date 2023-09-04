<%@ Page Title="CSL Reports" Language="VB" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="cslreports._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">

    <table class="table table table-condensed">
        <thead>
            <tr>
                <th>Meus Relatórios</th>
            </tr>
        </thead>
        <asp:Repeater ID="dtrDefault" runat="server" DataSourceID="dtsDefault">
            <ItemTemplate>
                <tr>
                    <td style="text-align: left;"><a href='<%# "PBI.aspx?rptId" + "=" + DataBinder.Eval(Container.DataItem, "REPORT_STRING").ToString%>' title="Visualizar"><%# DataBinder.Eval(Container.DataItem, "REPORT_NAME")%></a></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>

    <asp:SqlDataSource ID="dtsDefault" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [vw_pbi_Reports_Users]"></asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>

