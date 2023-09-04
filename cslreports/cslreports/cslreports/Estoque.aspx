<%@ Page Title="Estoque" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Estoque.aspx.vb" Inherits="cslreports.Estoque" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">

    <asp:GridView ID="gdv_Estoque" runat="server" AutoGenerateColumns="False" DataKeyNames="#PK-Id-Grupo-Distribuidor" DataSourceID="dts_Estoque">
        <Columns>
            <asp:BoundField DataField="Ultima-Data" HeaderText="Ultima-Data" SortExpression="Ultima-Data" />
            <asp:BoundField DataField="#PK-Id-Grupo-Distribuidor" HeaderText="#PK-Id-Grupo-Distribuidor" ReadOnly="True" SortExpression="#PK-Id-Grupo-Distribuidor" />
            <asp:BoundField DataField="Grupo-Distribuidor" HeaderText="Grupo-Distribuidor" SortExpression="Grupo-Distribuidor" />
            <asp:BoundField DataField="Regiao-Atendimento" HeaderText="Regiao-Atendimento" SortExpression="Regiao-Atendimento" />
            <asp:CheckBoxField DataField="@-Delivery" HeaderText="@-Delivery" SortExpression="@-Delivery" />
            <asp:CheckBoxField DataField="@-Atende-PF" HeaderText="@-Atende-PF" SortExpression="@-Atende-PF" />
            <asp:CheckBoxField DataField="AC" HeaderText="AC" SortExpression="AC" />
            <asp:CheckBoxField DataField="AM" HeaderText="AM" SortExpression="AM" />
            <asp:CheckBoxField DataField="AL" HeaderText="AL" SortExpression="AL" />
            <asp:CheckBoxField DataField="AP" HeaderText="AP" SortExpression="AP" />
            <asp:CheckBoxField DataField="BA" HeaderText="BA" SortExpression="BA" />
            <asp:CheckBoxField DataField="CE" HeaderText="CE" SortExpression="CE" />
            <asp:CheckBoxField DataField="DF" HeaderText="DF" SortExpression="DF" />
            <asp:CheckBoxField DataField="ES" HeaderText="ES" SortExpression="ES" />
            <asp:CheckBoxField DataField="GO" HeaderText="GO" SortExpression="GO" />
            <asp:CheckBoxField DataField="MA" HeaderText="MA" SortExpression="MA" />
            <asp:CheckBoxField DataField="MG" HeaderText="MG" SortExpression="MG" />
            <asp:CheckBoxField DataField="MS" HeaderText="MS" SortExpression="MS" />
            <asp:CheckBoxField DataField="MT" HeaderText="MT" SortExpression="MT" />
            <asp:CheckBoxField DataField="PA" HeaderText="PA" SortExpression="PA" />
            <asp:CheckBoxField DataField="PB" HeaderText="PB" SortExpression="PB" />
            <asp:CheckBoxField DataField="PE" HeaderText="PE" SortExpression="PE" />
            <asp:CheckBoxField DataField="PI" HeaderText="PI" SortExpression="PI" />
            <asp:CheckBoxField DataField="PR" HeaderText="PR" SortExpression="PR" />
            <asp:CheckBoxField DataField="RJ" HeaderText="RJ" SortExpression="RJ" />
            <asp:CheckBoxField DataField="RN" HeaderText="RN" SortExpression="RN" />
            <asp:CheckBoxField DataField="RO" HeaderText="RO" SortExpression="RO" />
            <asp:CheckBoxField DataField="RR" HeaderText="RR" SortExpression="RR" />
            <asp:CheckBoxField DataField="RS" HeaderText="RS" SortExpression="RS" />
            <asp:CheckBoxField DataField="SC" HeaderText="SC" SortExpression="SC" />
            <asp:CheckBoxField DataField="SE" HeaderText="SE" SortExpression="SE" />
            <asp:CheckBoxField DataField="SP" HeaderText="SP" SortExpression="SP" />
            <asp:CheckBoxField DataField="TO" HeaderText="TO" SortExpression="TO" />
        </Columns>
</asp:GridView>

<asp:SqlDataSource ID="dts_Estoque" runat="server" ConnectionString="<%$ ConnectionStrings:CslConnection %>" SelectCommand="SELECT * FROM [vw_Estoque_Informado_Ultimo_Lancamento]"></asp:SqlDataSource>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
