<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Pagina_link.aspx.vb" Inherits="CSL_2020.Pagina_link" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">

    <div class="input-group mb-3">
        <input id="txt_Search1" onkeyup="searchTable1()" type="text" placeholder="Localizar distribuidor" class="form-control" />
    </div>

    <!--Tabela -->
    <table id="tb_Main" class="table table-bordered" style="width: 100%; table-layout: fixed">
        <thead>
              <tr class="thead-light">
              <th scope="col" onclick="sortTable(0)">Loja</th>
              <th scope="col">Sigla Loja</th>
              <th scope="col">Uf</th>
              
            </tr>
      </thead>
        <tbody>
            <asp:Repeater ID="dtrTable" runat="server" DataSourceID="dtsTable">
                <ItemTemplate>
               
                    <tr>
                    <td class="table-ligh"><div class="_LIMITA_CELULA"><a href='<%# DataBinder.Eval(Container.DataItem, "URL").ToString  %>'><i class="fas fa-external-link-alt"></i> <%# DataBinder.Eval(Container.DataItem, "loja").ToString %></a></div></td>
                    <td><p class="_LIMITA_CELULA"><%# DataBinder.Eval(Container.DataItem, "loja_Sigla").ToString %></p></td>
                    <td><p class="_LIMITA_CELULA"><%# DataBinder.Eval(Container.DataItem, "loja_UF").ToString %></p></></td>
                    
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>

    <!--Datasources -->
    <asp:SqlDataSource ID="dtsTable" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString_Decathlon_Chapeira %>' SelectCommand="SELECT * FROM [tb_Lojas] ORDER BY [Loja]" />


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
