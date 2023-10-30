<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Medicos_Ficha.aspx.vb" Inherits="Medicos_Ficha" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Ficha do Médico</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">FICHA DO MÉDICO</div>
    <div id ="Titulo_Pagina_Links">
        <a id="A1" runat="server" href="Medicos_Lista.aspx">Lista de Médicos</a>&nbsp;
        <!--<a id="HyperLink3" runat="server" href="Medicos_Editar.aspx">Alterar</a>-->
        <%--<% If Session("PAGINA") = 1 Then%>
        <a href="Estabelecimentos_Ficha2.aspx?CNPJ=<%=Session("CNPJ")%>">Voltar</a>
        <% ElseIf Session("PAGINA") = 2 Then%>
        <a href="Medicos_Lista.aspx">Voltar</a>
        <% End If%>--%>
         
    </div>
</div>
<br />
<div id ="Corpo">
    <br />
    <asp:FormView ID="frv_MEDICO" runat="server" 
        DataSourceID="VIEW_MEDICOS" Width="100%" 
        DataKeyNames="CRMUF">
        <EditItemTemplate>
        </EditItemTemplate>
        <InsertItemTemplate></InsertItemTemplate>
        <ItemTemplate>
            <strong>
            <asp:Label ID="NOMELabel" runat="server" Text='<%# Bind("MEDICO") %>' />
            &nbsp;</strong><br />
            Celular:
            <asp:Label ID="CELEULARLabel" runat="server" 
                Text='<%# Bind("CELEULAR") %>' />
            <br />
            Telefone:
            <asp:Label ID="CELEULARLabel0" runat="server" Text='<%# Bind("TELEFONE")%>' />
            <br />
            Email:
            <asp:Label ID="EMAILLabel" runat="server" Text='<%# Bind("EMAIL") %>' />
            <br />
            Aniversário:
            <asp:Label ID="DIA_ANIVERSARIOLabel" runat="server" 
                Text='<%# Bind("DIA_ANIVERSARIO") %>' />
            /<asp:Label ID="MES_ANIVERSARIOLabel" runat="server" 
                Text='<%# Bind("MES_ANIVERSARIO") %>' />
            <br />
            Inclusão:
            <asp:Label ID="INCLUSAOLabel" runat="server" Text='<%# Bind("INCLUSAO") %>' />
            <br />

        </ItemTemplate>
    </asp:FormView>
    <hr />
    <strong>Estabelecimentos onde este médico trabalha</strong><br />
    <asp:GridView ID="gdv_Medicos_Estabelecimentos" runat="server" 
        AutoGenerateColumns="False" 
        DataSourceID="dts_Medicos_Estabelecimentos" Width="100%" AllowSorting="True">
        <Columns>
            <asp:BoundField DataField="ID_MEDICO_ESTABELECIMENTO" HeaderText="ID" 
                SortExpression="ID_MEDICO_ESTABELECIMENTO" />
            <asp:HyperLinkField DataNavigateUrlFields="CNPJ" DataNavigateUrlFormatString="Estabelecimentos_Ficha2.aspx?CNPJ={0}" DataTextField="ESTABELECIMENTO_CNPJ" HeaderText="Estabelecimento" SortExpression="ESTABELECIMENTO_CNPJ" />
            <asp:BoundField DataField="ESPECIALIDADE_MEDICO_NO_ESTABELECIMENTO" 
                HeaderText="Especialidade" 
                SortExpression="ESPECIALIDADE_MEDICO_NO_ESTABELECIMENTO" />
            <asp:BoundField DataField="CARGO_MEDICO_NO_ESTABELECIMENTO" HeaderText="Cargo" 
                SortExpression="CARGO_MEDICO_NO_ESTABELECIMENTO" />
            <asp:BoundField DataField="AREA_MEDICO_NO_ESTABELECIMENTO" HeaderText="Area" 
                SortExpression="AREA_MEDICO_NO_ESTABELECIMENTO" />
            <asp:BoundField DataField="PERFIL_MEDICO_NO_ESTABELECIMENTO" 
                HeaderText="Perfil" SortExpression="PERFIL_MEDICO_NO_ESTABELECIMENTO" />
            <asp:BoundField DataField="REPRESENTANTE" HeaderText="Representante" 
                SortExpression="REPRESENTANTE" />
            <asp:BoundField DataField="TELEFONE_MEDICO_NO_ESTABELECIMENTO" 
                HeaderText="Telefone" SortExpression="TELEFONE_MEDICO_NO_ESTABELECIMENTO" />
            <asp:BoundField DataField="ATIVO_MEDICO_NO_ESTABELECIMENTO" HeaderText="Ativo" 
                SortExpression="ATIVO_MEDICO_NO_ESTABELECIMENTO" />
            <asp:HyperLinkField DataNavigateUrlFields="ID_MEDICO_ESTABELECIMENTO" DataNavigateUrlFormatString="Medico_Estabelecimento_Editar.aspx?ID_MEDICO_ESTABELECIMENTO={0}" Text="Alterar" Visible="False" />
        </Columns>
        <HeaderStyle 
            HorizontalAlign="Center" VerticalAlign="Middle" />
        <RowStyle HorizontalAlign="Center" 
            VerticalAlign="Middle" />
    </asp:GridView>
        <br />
    <strong>Lista de Visitas<asp:GridView ID="gdv_VISITAS" runat="server" AutoGenerateColumns="False" DataKeyNames="ID_VISITA" DataSourceID="dts_VISITAS_LISTAS" AllowSorting="True">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="ID_VISITA" DataNavigateUrlFormatString="Visita_Ficha.aspx?ID_VISITA={0}&amp;PAGINA=2" DataTextField="ID_VISITA" HeaderText="ID" SortExpression="ID_VISITA" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:HyperLinkField>
            <asp:BoundField DataField="DATA" HeaderText="Data" ReadOnly="True" SortExpression="DATA" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="ESTABELECIMENTO_CNPJ" HeaderText="Estabelecimento" SortExpression="ESTABELECIMENTO_CNPJ" ReadOnly="True" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="VISITANTE" HeaderText="Visitante" SortExpression="VISITANTE" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="PERIODO" HeaderText="Período" SortExpression="PERIODO" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="PROXIMA_VISITA" HeaderText="Próxima Visita" ReadOnly="True" SortExpression="PROXIMA_VISITA" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    </strong>
</div>
    <asp:SqlDataSource ID="dts_VISITAS_LISTAS" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT ID_VISITA, VISITANTE, ESTABELECIMENTO_CNPJ, DATA, PERIODO, STATUS_VISITA, COMENTARIOS, PROXIMA_VISITA, ACAO_PROXIMA_VISITA FROM VIEW_VISITAS_GERAL WHERE (CRMUF = @CRMUF)">
        <SelectParameters>
            <asp:SessionParameter Name="CRMUF" SessionField="CRMUF" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="VIEW_MEDICOS" runat="server" 
    ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
    SelectCommand="SELECT * FROM [VIEW_MEDICOS] WHERE ([CRMUF] = @CRMUF)">
    <SelectParameters>
        <asp:SessionParameter Name="CRMUF" SessionField="CRMUF" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>


</form>


<asp:SqlDataSource ID="dts_Medicos_Estabelecimentos" runat="server" 
    ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
    SelectCommand="SELECT * FROM [VIEW_MEDICOS_ESTABELECIMENTOS] WHERE ([CRMUF] = @CRMUF) ORDER BY [ESTABELECIMENTO_CNPJ]">
    <SelectParameters>
        <asp:SessionParameter Name="CRMUF" SessionField="CRMUF" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>
</body>
</html>
