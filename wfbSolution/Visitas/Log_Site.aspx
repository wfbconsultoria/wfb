<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Log_Site.aspx.vb" Inherits="Log_Site" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Log de Acesso</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Log de Acesso</div>
    <div id ="Titulo_Pagina_Links">
        <asp:LinkButton ID="cmd_Excel" runat="server">Exportar para Excel</asp:LinkButton>
    </div>
</div>    
<br />
<div id ="Corpo">
    <asp:GridView ID="gdv_Log_Site" runat="server" 
        AutoGenerateColumns="False" DataSourceID="dts_VIEW_LOG_SITE" Width="100%">
        <Columns>
            <asp:BoundField DataField="USUARIO" HeaderText="Usuário" ReadOnly="True" 
                SortExpression="USUARIO" >
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="DATA_EXTENSO" HeaderText="Data" 
                ReadOnly="True" SortExpression="DATA_EXTENSO" >
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="HORARIO" HeaderText="Horário" ReadOnly="True" 
                SortExpression="HORARIO" >
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="IP" HeaderText="IP computador" 
                SortExpression="IP" >
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
        </Columns>
        <HeaderStyle 
            HorizontalAlign="Left" VerticalAlign="Middle" Width="100%" />
    </asp:GridView>

</div>  
    <asp:SqlDataSource ID="dts_VIEW_LOG_SITE" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>"    
        SelectCommand="SELECT TOP (1000) USUARIO, DATA_EXTENSO, HORARIO, SESSION_ID, IP, DATA, CONTROLE FROM VIEW_LOG_SITE ORDER BY DATA DESC, CONTROLE DESC">
    </asp:SqlDataSource>
</form>
</body>
</html>
