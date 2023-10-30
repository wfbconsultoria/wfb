<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Cotas_Relatorios.aspx.vb" Inherits="Cotas_Relatorios" %>
<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Manutenção de Cotas</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />

<form id="form1" runat="server">

<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Relatório de Cotas &nbsp;
        
    </div>
    <div id ="Titulo_Pagina_Links">
    </div>    
</div>
<div id ="Corpo">
    <br/><br/>
    Ano &nbsp;<asp:DropDownList ID="cmb_Anos" runat="server" DataSourceID="dts_Anos" DataTextField="ANO" DataValueField="ANO" AutoPostBack="True"></asp:DropDownList>
        Representante &nbsp;<asp:DropDownList ID="cmb_Usuarios" runat="server" DataSourceID="dts_Usuarios" DataTextField="NOME" DataValueField="EMAIL" AutoPostBack="True"></asp:DropDownList>
    <br /><br />
    
    <asp:GridView ID="gdv_Cotas_Relatorio" runat="server" AutoGenerateColumns="False" DataSourceID="dts_Cota_Linha_01">
        <Columns>
            <asp:BoundField DataField="LINHA_PRODUTO" HeaderText="Linha de Produto" SortExpression="LINHA_PRODUTO" />
            <asp:BoundField DataField="JAN" HeaderText="JAN" ReadOnly="True" SortExpression="JAN" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="FEV" HeaderText="FEV" ReadOnly="True" SortExpression="FEV" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="MAR" HeaderText="MAR" ReadOnly="True" SortExpression="MAR" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="ABR" HeaderText="ABR" ReadOnly="True" SortExpression="ABR" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="MAI" HeaderText="MAI" ReadOnly="True" SortExpression="MAI" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="JUN" HeaderText="JUN" ReadOnly="True" SortExpression="JUN" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="JUL" HeaderText="JUL" ReadOnly="True" SortExpression="JUL" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="AGO" HeaderText="AGO" ReadOnly="True" SortExpression="AGO" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="SET" HeaderText="SET" ReadOnly="True" SortExpression="SET" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="OUT" HeaderText="OUT" ReadOnly="True" SortExpression="OUT" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="NOV" HeaderText="NOV" ReadOnly="True" SortExpression="NOV" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="DEZ" HeaderText="DEZ" ReadOnly="True" SortExpression="DEZ" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="TRI1" HeaderText="TRI 1" ReadOnly="True" SortExpression="TRI1" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="TRI2" HeaderText="TRI 2" ReadOnly="True" SortExpression="TRI2" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="TRI3" HeaderText="TRI 3" ReadOnly="True" SortExpression="TRI3" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="TRI4" HeaderText="TRI 4" ReadOnly="True" SortExpression="TRI4" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="TOTAL" HeaderText="Total" ReadOnly="True" SortExpression="TOTAL" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>

    
    </div>
       <asp:SqlDataSource ID="dts_Anos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT DISTINCT ANO FROM VIEW_COTAS ORDER BY ANO DESC">
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Cota_Linha_01" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT [JAN], [FEV], [MAR], [ABR], [MAI], [JUN], [JUL], [AGO], [SET], [OUT], [NOV], [DEZ], [TRI1], [TRI2], [TRI3], [TRI4], [TOTAL], [LINHA_PRODUTO] FROM [VIEW_COTAS] WHERE (([EMAIL] = @EMAIL) AND ([ANO] = @ANO)) ORDER BY [LINHA_PRODUTO]">
        <SelectParameters>
            <asp:ControlParameter ControlID="cmb_Usuarios" Name="EMAIL" PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="cmb_Anos" Name="ANO" PropertyName="SelectedValue" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Usuarios" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [tbl_USUARIOS] WHERE ([COD_PERFIL] = @COD_PERFIL) ORDER BY [NOME]">
            <SelectParameters>
                <asp:Parameter DefaultValue="4" Name="COD_PERFIL" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
