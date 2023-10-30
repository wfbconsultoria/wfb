<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Estabelecimentos_Ficha_Oportunidades.aspx.vb" Inherits="Estabelecimentos_Ficha_Oportunidades" enableeventvalidation="false"%>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Oportunidades</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style2 {
            color: #FF0000;
        }
    </style>
</head>
<body>
<uc1:cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
   <div id ="Titulo_Pagina_Cabecalho">Oportunidades</div>
   <div id ="Titulo_Pagina_Links">
       <!--<a href="Oportunidades_Cadastro.aspx?CNPJ=<%=Session("CNPJ")%>">Nova <%=Year(Now()) %></a>-->
       <a href="Estabelecimentos_Ficha.aspx?CNPJ=<%=Session("CNPJ")%>">Voltar</a>
   </div>
</div>    
<br />
    <div id ="Corpo">
        <br />
        <asp:FormView ID="frm_Estabelecimento_Ficha" runat="server"  DataSourceID="dts_Estabelecimento" Width="100%">
            <EditItemTemplate></EditItemTemplate>
            <InsertItemTemplate></InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="ESTABELECIMENTOLabel" runat="server" Text='<%# Bind("ESTABELECIMENTO_CNPJ") %>' style="font-weight: 700" />
            </ItemTemplate>
        </asp:FormView>
        
    <asp:GridView ID="gdv_Oportunidades" runat="server" AutoGenerateColumns="False" 
     DataSourceID="dts_Oportunidades" Width="100%" GridLines="Horizontal" BorderStyle="None">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="ID_OPORTUNIDADE,CNPJ,ANO_OPORTUNIDADE" DataNavigateUrlFormatString="Oportunidades_Manutencao.aspx?PAGINA_ORIGEM=Estabelecimentos_Ficha&amp;ID_OPORTUNIDADE={0}&amp;CNPJ={1}&amp;ANO={2}" DataTextField="ID_OPORTUNIDADE" HeaderText="ID" SortExpression="ID_OPORTUNIDADE">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:HyperLinkField>
            <asp:BoundField DataField="ANO_OPORTUNIDADE" HeaderText="Ano" SortExpression="ANO_OPORTUNIDADE" />
            <asp:BoundField DataField="MES_SIGLA" HeaderText="Mês" SortExpression="MES_SIGLA" />
            <asp:BoundField DataField="FASE" HeaderText="Fase" 
                SortExpression="FASE">
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="LINHA" HeaderText="Linha" 
                SortExpression="LINHA">
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="JAN" HeaderText="JAN" 
                SortExpression="JAN" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="FEV" HeaderText="FEV" 
                SortExpression="FEV" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="MAR" HeaderText="MAR" SortExpression="MAR" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="ABR" HeaderText="ABR" SortExpression="ABR" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="MAI" HeaderText="MAI" SortExpression="MAI" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="JUN" HeaderText="JUN" SortExpression="JUN" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="JUL" HeaderText="JUL" SortExpression="JUL" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="AGO" HeaderText="AGO" SortExpression="AGO" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="SET" HeaderText="SET" SortExpression="SET" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="OUT" HeaderText="OUT" SortExpression="OUT" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="NOV" HeaderText="NOV" SortExpression="NOV" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="DEZ" HeaderText="DEZ" SortExpression="DEZ" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="TOTAL" HeaderText="TOTAL" SortExpression="TOTAL" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="FASE_ATUAL_QTD_PREVISTA" HeaderText="Qtd Inicial" 
                SortExpression="FASE_ATUAL_QTD_PREVISTA" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
        </Columns>
                        <EmptyDataTemplate>
                            <span class="style17">Nenhuma oportunidade cadastrada</span>
                        </EmptyDataTemplate>
        <HeaderStyle 
            HorizontalAlign="Center" VerticalAlign="Middle" />
        <RowStyle HorizontalAlign="Center" 
            VerticalAlign="Middle" />
    </asp:GridView>  
    </div>
        <asp:SqlDataSource ID="dts_Oportunidades" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [VIEW_OPORTUNIDADES_FINAL] WHERE ([CNPJ] = @CNPJ)">
            <SelectParameters>
                <asp:SessionParameter Name="CNPJ" SessionField="CNPJ" Type="Decimal" />
            </SelectParameters>
    </asp:SqlDataSource>
        
        
    <asp:SqlDataSource ID="dts_Estabelecimento" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS] WHERE ([CNPJ] = @CNPJ)">
        <SelectParameters>
            <asp:SessionParameter Name="CNPJ" SessionField="CNPJ" Type="Decimal" />  
        </SelectParameters>
    </asp:SqlDataSource>
</form>
</body>
</html>