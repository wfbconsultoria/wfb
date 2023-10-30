<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Contatos_Ficha.aspx.vb" Inherits="Contatos_Ficha" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Ficha do Contato</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">FICHA DO CONTATO</div>
    <div id ="Titulo_Pagina_Links">
        <!--<a href="Contatos_Alterar.aspx?ID_CONTATO=<%=Session("ID_CONTATO")%>">Alterar</a>&nbsp;-->
        <a href="Estabelecimentos_Ficha2.aspx?CNPJ=<%=Session("CNPJ")%>">Ficha do Estabelecimento</a>
    </div>
</div>
<br />
<div id ="Corpo">
    <br />
    <asp:FormView ID="frm_FICHA_CONTATO" runat="server" DataSourceID="dts_CONTATOS_FICHA">
        <EditItemTemplate>
            NOME:
            <asp:TextBox ID="NOMETextBox" runat="server" Text='<%# Bind("NOME") %>' />
            <br />
            ENDERECO:
            <asp:TextBox ID="ENDERECOTextBox" runat="server" Text='<%# Bind("ENDERECO") %>' />
            <br />
            MUNICIPIO:
            <asp:TextBox ID="MUNICIPIOTextBox" runat="server" Text='<%# Bind("MUNICIPIO") %>' />
            <br />
            ESTADO:
            <asp:TextBox ID="ESTADOTextBox" runat="server" Text='<%# Bind("ESTADO") %>' />
            <br />
            BAIRRO:
            <asp:TextBox ID="BAIRROTextBox" runat="server" Text='<%# Bind("BAIRRO") %>' />
            <br />
            TELEFONE:
            <asp:TextBox ID="TELEFONETextBox" runat="server" Text='<%# Bind("TELEFONE") %>' />
            <br />
            CELULAR:
            <asp:TextBox ID="CELULARTextBox" runat="server" Text='<%# Bind("CELULAR") %>' />
            <br />
            EMAIL:
            <asp:TextBox ID="EMAILTextBox" runat="server" Text='<%# Bind("EMAIL") %>' />
            <br />
            DIA_NUMERO_TEXTO:
            <asp:TextBox ID="DIA_NUMERO_TEXTOTextBox" runat="server" Text='<%# Bind("DIA_NUMERO_TEXTO") %>' />
            <br />
            MES_EXTENSO:
            <asp:TextBox ID="MES_EXTENSOTextBox" runat="server" Text='<%# Bind("MES_EXTENSO") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <InsertItemTemplate>
            NOME:
            <asp:TextBox ID="NOMETextBox" runat="server" Text='<%# Bind("NOME") %>' />
            <br />
            ENDERECO:
            <asp:TextBox ID="ENDERECOTextBox" runat="server" Text='<%# Bind("ENDERECO") %>' />
            <br />
            MUNICIPIO:
            <asp:TextBox ID="MUNICIPIOTextBox" runat="server" Text='<%# Bind("MUNICIPIO") %>' />
            <br />
            ESTADO:
            <asp:TextBox ID="ESTADOTextBox" runat="server" Text='<%# Bind("ESTADO") %>' />
            <br />
            BAIRRO:
            <asp:TextBox ID="BAIRROTextBox" runat="server" Text='<%# Bind("BAIRRO") %>' />
            <br />
            TELEFONE:
            <asp:TextBox ID="TELEFONETextBox" runat="server" Text='<%# Bind("TELEFONE") %>' />
            <br />
            CELULAR:
            <asp:TextBox ID="CELULARTextBox" runat="server" Text='<%# Bind("CELULAR") %>' />
            <br />
            EMAIL:
            <asp:TextBox ID="EMAILTextBox" runat="server" Text='<%# Bind("EMAIL") %>' />
            <br />
            DIA_NUMERO_TEXTO:
            <asp:TextBox ID="DIA_NUMERO_TEXTOTextBox" runat="server" Text='<%# Bind("DIA_NUMERO_TEXTO") %>' />
            <br />
            MES_EXTENSO:
            <asp:TextBox ID="MES_EXTENSOTextBox" runat="server" Text='<%# Bind("MES_EXTENSO") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            <asp:Label ID="NOMELabel" runat="server" Text='<%# Bind("NOME") %>' style="font-weight: 700" />
            <br />
            <asp:Label ID="lbl_Estabelecimento" runat="server" Text='<%# Bind("ESTABELECIMENTO_CNPJ") %>' />
            <br />
            Cargo:
            <asp:Label ID="lbl_cargo" runat="server" Text='<%# Eval("CARGO") %>'></asp:Label>
            <br />
            Area:
            <asp:Label ID="lbl_area" runat="server" Text='<%# Eval("AREA") %>'></asp:Label>
            <br />
            Telefone:
            <asp:Label ID="TELEFONELabel" runat="server" Text='<%# Bind("TELEFONE") %>' />
            <br />
            Celular:
            <asp:Label ID="CELULARLabel" runat="server" Text='<%# Bind("CELULAR") %>' />
            <br />
            E-mail:
            <asp:Label ID="EMAILLabel" runat="server" Text='<%# Bind("EMAIL") %>' />
            <br />
            Visitas Neste Ano:
            <asp:Label ID="lbl_visitas_ano" runat="server" Text='<%# Eval("VISITAS_ANO_ATUAL") %>'></asp:Label>
            <br />
            Visitas Neste Mês:
            <asp:Label ID="lbl_visitas_mes" runat="server" Text='<%# Eval("VISITAS_MES_ATUAL") %>'></asp:Label>
            <br />
            Aniversário:
            <asp:Label ID="DIA_NUMERO_TEXTOLabel" runat="server" Text='<%# Bind("DIA_NUMERO_TEXTO") %>' />
            /
            <asp:Label ID="MES_EXTENSOLabel" runat="server" Text='<%# Bind("MES_EXTENSO") %>' />
            <br />
            Inclusão:
            <asp:Label ID="INCLUSAOLabel" runat="server" Text='<%# Bind("INCLUSAO") %>' />
            <br />
        </ItemTemplate>
    </asp:FormView>
    <hr />
    <strong>Lista de Visitas<asp:GridView ID="gdv_VISITAS" runat="server" AutoGenerateColumns="False" DataSourceID="dts_VISITAS_CONTATO" DataKeyNames="ID_VISITA" AllowSorting="True">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="ID_VISITA" DataNavigateUrlFormatString="Visita_Ficha.aspx?ID_VISITA={0}&amp;PAGINA=3" DataTextField="ID_VISITA" HeaderText="ID" SortExpression="ID_VISITA" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:HyperLinkField>
            <asp:BoundField DataField="DATA" HeaderText="Data" SortExpression="DATA" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="PERIODO" HeaderText="Período" SortExpression="PERIODO" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="PROXIMA_VISITA" HeaderText="Próxima Visita" SortExpression="PROXIMA_VISITA" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    </strong>
    <asp:SqlDataSource ID="dts_VISITAS_CONTATO" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_VISITAS_GERAL] WHERE ([ID] = @ID)">
        <SelectParameters>
            <asp:QueryStringParameter Name="ID" QueryStringField="ID" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_CONTATOS_FICHA" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_CONTATOS] WHERE ([ID_CONTATO] = @ID_CONTATO)">
        <SelectParameters>
            <asp:QueryStringParameter Name="ID_CONTATO" QueryStringField="ID" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>



</div>
</form>
</body>
</html>
