<%@ Page Title="Distribuidores" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Distribuidores.aspx.vb" Inherits="CSL_2020.Distribuidores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">

    <!--Ferramnetas da tabela, filtrar, incluir novo -->
    <div class="input-group mb-3">
        <input id="txt_Search1" onkeyup="searchTable1()" type="text" placeholder="Localizar distribuidor" class="form-control" />
    </div>
   
    <!--Tabela -->
    <table id="tb_Main" class="table table-bordered" style="width: 100%; table-layout: fixed">
        <thead>
            <tr>
                <th style="width: 100%" onclick="sortTable(0)"><a href="#">Distribuidor</a></th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="dtrTable" runat="server" DataSourceID="dtsTable">
                <ItemTemplate>
                    <tr>
                        <td>
                            <div class="_LIMITA_CELULA"><a href='<%# "Distribuidor_Ficha.aspx?ID_GRUPO_DISTRIBUIDOR" + "=" + DataBinder.Eval(Container.DataItem, "ID_GRUPO_DISTRIBUIDOR").ToString  %>'><%# DataBinder.Eval(Container.DataItem, "GRUPO_DISTRIBUIDOR").ToString %></a></div>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>

     <!--Datasources -->
    <asp:SqlDataSource ID="dtsTable" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT * FROM [TBL_DISTRIBUIDORES_GRUPOS] WHERE ([ATIVO] = @ATIVO)">
        <SelectParameters>
            <asp:Parameter DefaultValue="TRUE" Name="ATIVO" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
