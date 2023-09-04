<%@ Page Title="Report Table Sample" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Report_Table_Sample.aspx.vb" Inherits="EPlanner.Report_Table_Sample" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">

    <asp:GridView ID="gdv_Colaboradores" runat="server" AutoGenerateColumns="False" DataSourceID="dts_Chapeira" CssClass="table table">
        <Columns>
            <asp:BoundField DataField="Loja" HeaderText="Loja" SortExpression="Loja" />
            <asp:BoundField DataField="Zona" HeaderText="Zona" ReadOnly="True" SortExpression="Zona" />
            <asp:BoundField DataField="Universo" HeaderText="Universo" ReadOnly="True" SortExpression="Universo" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" ReadOnly="True" SortExpression="Nome" />
            <asp:BoundField DataField="Brigadista" HeaderText="Brigadista" ReadOnly="True" SortExpression="Brigadista" />
            <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" SortExpression="Status" />
        </Columns>
</asp:GridView>
<asp:SqlDataSource ID="dts_Chapeira" runat="server" ConnectionString="<%$ ConnectionStrings:Decathlon_Chapeira_ConnectionString %>" SelectCommand="SELECT [Loja], [Zona], [Universo], [Nome], [Brigadista], [Status] FROM [vw_Colaboradores] WHERE ([Ativo] = @Ativo)">
    <SelectParameters>
        <asp:Parameter DefaultValue="Sim" Name="Ativo" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>
</asp:Content>
