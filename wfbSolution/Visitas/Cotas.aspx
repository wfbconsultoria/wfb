<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Cotas.aspx.vb" Inherits="Cotas" enableeventvalidation="false"%>
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
    <div id ="Titulo_Pagina_Cabecalho">Manutenção de Cotas Ano
         <asp:DropDownList ID="cmb_ANOS_Filtro" runat="server" DataSourceID="dts_Anos" 
              DataTextField="ANO_VALOR" 
              DataValueField="ANO_VALOR" AutoPostBack="True" Enabled="False">
        </asp:DropDownList></div>
    <div id ="Titulo_Pagina_Links">
         <asp:LinkButton ID="cmd_Excel" runat="server">Exportar para Excel</asp:LinkButton>
    </div>    
</div>

<div id ="Corpo">   
    
     <asp:FormView ID="frv_Cotas" runat="server" DataKeyNames="ID" 
         DataSourceID="dts_Cotas_Inclusao" 
         Width="100%" CellPadding="4" ForeColor="#333333">
         <EditItemTemplate>
             <table class="style3" width = "100%">
                 <tr>
                     <td>
                         ID:
                         <asp:Label ID="IDLabel1" runat="server" Text='<%# Eval("ID") %>' />
                         &nbsp; Ano:
                         <asp:DropDownList ID="cmb_ANOS" runat="server" DataSourceID="dts_Anos" 
                             SelectedValue='<%# Bind("ANO") %>' DataTextField="ANO_VALOR" 
                             DataValueField="ANO_VALOR">
                         </asp:DropDownList>
                         &nbsp; Colaborador:
                         <asp:DropDownList ID="cmb_EMAIL" runat="server" DataSourceID="dts_Usuarios" 
                             DataTextField="NOME" DataValueField="EMAIL" 
                             SelectedValue='<%# Bind("EMAIL") %>'>
                         </asp:DropDownList>
                     </td>
                     <td style="text-align: right">
                         <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                             CommandName="Update" Text="Gravar" />
                         &nbsp;
                         <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" 
                             CommandName="Cancel" Text="Cancelar" />
                     </td>
                 </tr>
             </table>
             <table class="style3">
                 <tr>
                     <td class="style5">
                         JAN</td>
                     <td class="style5">
                         FEV</td>
                     <td class="style5">
                         MAR</td>
                     <td class="style5">
                         ABR</td>
                     <td class="style5">
                         MAI</td>
                     <td class="style5">
                         JUN</td>
                     <td class="style5">
                         JUL</td>
                     <td class="style5">
                         AGO</td>
                     <td class="style5">
                         SET</td>
                     <td class="style5">
                         OUT</td>
                     <td class="style5">
                         NOV</td>
                     <td class="style5">
                         DEZ</td>
                 </tr>
                 <tr>
                     <td align="center">
                         <asp:TextBox ID="JANTextBox" runat="server" style="text-align: center" 
                             Text='<%# Bind("JAN") %>' Width="80px" Enabled="False" />
                     </td>
                     <td align="center">
                         <asp:TextBox ID="FEVTextBox" runat="server" style="text-align: center" 
                             Text='<%# Bind("FEV") %>' Width="80px" Enabled="False" />
                     </td>
                     <td align="center">
                         <asp:TextBox ID="MARTextBox" runat="server" style="text-align: center" 
                             Text='<%# Bind("MAR") %>' Width="80px" Enabled="False" />
                     </td>
                     <td align="center">
                         <asp:TextBox ID="ABRTextBox" runat="server" style="text-align: center" 
                             Text='<%# Bind("ABR") %>' Width="80px" />
                     </td>
                     <td align="center">
                         <asp:TextBox ID="MAITextBox" runat="server" style="text-align: center" 
                             Text='<%# Bind("MAI") %>' Width="80px" />
                     </td>
                     <td align="center">
                         <asp:TextBox ID="JUNTextBox" runat="server" style="text-align: center" 
                             Text='<%# Bind("JUN") %>' Width="80px" />
                     </td>
                     <td align="center">
                         <asp:TextBox ID="JULTextBox" runat="server" style="text-align: center" 
                             Text='<%# Bind("JUL") %>' Width="80px" />
                     </td>
                     <td align="center">
                         <asp:TextBox ID="AGOTextBox" runat="server" style="text-align: center" 
                             Text='<%# Bind("AGO") %>' Width="80px" />
                     </td>
                     <td align="center">
                         <asp:TextBox ID="SETTextBox" runat="server" style="text-align: center" 
                             Text='<%# Bind("SET") %>' Width="80px" />
                     </td>
                     <td align="center">
                         <asp:TextBox ID="OUTTextBox" runat="server" style="text-align: center" 
                             Text='<%# Bind("OUT") %>' Width="80px" />
                     </td>
                     <td align="center">
                         <asp:TextBox ID="NOVTextBox" runat="server" style="text-align: center" 
                             Text='<%# Bind("NOV") %>' Width="80px" />
                     </td>
                     <td align="center">
                         <asp:TextBox ID="DEZTextBox" runat="server" style="text-align: center" 
                             Text='<%# Bind("DEZ") %>' Width="80px" />
                     </td>
                 </tr>
             </table>
         </EditItemTemplate>
         <EditRowStyle BackColor="#999999" />
         <EmptyDataTemplate>
             <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
                 CommandName="New" Text="Incluir" Enabled="False" />
         </EmptyDataTemplate>
         <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
         <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
         <InsertItemTemplate>
             <table class="style3">
                 <tr>
                     <td class="style8">
                         Ano:
                         <asp:DropDownList ID="cmb_ANOS_inclusao" runat="server" DataSourceID="dts_Anos" 
                             DataTextField="ANO_VALOR" DataValueField="ANO_VALOR" 
                             SelectedValue='<%# Bind("ANO") %>'>
                         </asp:DropDownList>
                         &nbsp; Colaborador:
                         <asp:DropDownList ID="cmb_EMAIL_inclusao" runat="server" 
                             DataSourceID="dts_Usuarios" DataTextField="NOME" DataValueField="EMAIL" 
                             SelectedValue='<%# Bind("EMAIL") %>'>
                         </asp:DropDownList>
                     </td>
                     <td class="style7">
                         <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                             CommandName="Insert" Text="Gravar" />
                         &nbsp;
                         <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" 
                             CommandName="Cancel" Text="Cancelar" />
                     </td>
                 </tr>
             </table>
             <table class="style3" width = "100%">
                 <tr>
                     <td align="center"><b>JAN</b></td>
                     <td align="center"><b>FEV</b></td>
                     <td align="center"><b>MAR</b></td>
                     <td align="center"><b>ABR</b></td>
                     <td align="center"><b>MAI</b></td>
                     <td align="center"><b>JUN</b></td>
                     <td align="center"><b>JUL</b></td>
                     <td align="center"><b>AGO</b></td>
                     <td align="center"><b>SET</b></td>
                     <td align="center"><b>OUT</b></td>
                     <td align="center"><b>NOV</b></td>
                     <td align="center"><b>DEZ</b></td>
                 </tr>
                 <tr>
                     <td align="center">
                         <asp:TextBox ID="JANTextBox" runat="server" Text='<%# Bind("JAN") %>' 
                             Width="80px" />
                     </td>
                     <td align="center">
                         <asp:TextBox ID="FEVTextBox" runat="server" Text='<%# Bind("FEV") %>' 
                             Width="80px" />
                     </td>
                     <td align="center">
                         <asp:TextBox ID="MARTextBox" runat="server" Text='<%# Bind("MAR") %>' 
                             Width="80px" />
                     </td>
                     <td align="center">
                         <asp:TextBox ID="ABRTextBox" runat="server" Text='<%# Bind("ABR") %>' 
                             Width="80px" />
                     </td>
                     <td align="center">
                         <asp:TextBox ID="MAITextBox" runat="server" Text='<%# Bind("MAI") %>' 
                             Width="80px" />
                     </td>
                     <td align="center">
                         <asp:TextBox ID="JUNTextBox" runat="server" Text='<%# Bind("JUN") %>' 
                             Width="80px" />
                     </td>
                     <td align="center">
                         <asp:TextBox ID="JULTextBox" runat="server" Text='<%# Bind("JUL") %>' 
                             Width="80px" />
                     </td>
                     <td align="center">
                         <asp:TextBox ID="AGOTextBox" runat="server" Text='<%# Bind("AGO") %>' 
                             Width="80px" />
                     </td>
                     <td align="center">
                         <asp:TextBox ID="SETTextBox" runat="server" Text='<%# Bind("SET") %>' 
                             Width="80px" />
                     </td>
                     <td align="center">
                         <asp:TextBox ID="OUTTextBox" runat="server" Text='<%# Bind("OUT") %>' 
                             Width="80px" />
                     </td>
                     <td align="center">
                         <asp:TextBox ID="NOVTextBox" runat="server" Text='<%# Bind("NOV") %>' 
                             Width="80px" />
                     </td>
                     <td align="center">
                         <asp:TextBox ID="DEZTextBox" runat="server" Text='<%# Bind("DEZ") %>' 
                             Width="80px" />
                     </td>
                 </tr>
             </table>
         </InsertItemTemplate>
         <ItemTemplate>
             <table class="style3" width="100%">
                 <tr>
                     <td>
                         <strong>ID:</strong>
                         <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                         &nbsp;<strong>Ano: </strong>
                         <asp:Label ID="ANOLabel" runat="server" Text='<%# Bind("ANO") %>' />
                         &nbsp;<strong>Colaborador:</strong>
                         <asp:DropDownList ID="cmb_Representante" runat="server" DataSourceID="dts_Usuarios" 
                             DataTextField="NOME" DataValueField="EMAIL" Enabled="False" 
                             SelectedValue='<%# Bind("EMAIL") %>'>
                         </asp:DropDownList>
                     </td>
                     <td style="text-align: right">
                         <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
                             CommandName="Edit" Text="Alterar" />
                         &nbsp;
                         <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
                             CommandName="New" Text="Incluir" />
                         &nbsp;
                         <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
                             CommandName="Delete" Text="Excluir" />
                     </td>
                 </tr>
             </table>
             <table cellpadding="0" cellspacing="0" class="style4" width = "100%">
                 <tr>
                     <td class="style9">
                         <b>JAN</b></td>
                     <td class="style10">
                         FEV</td>
                     <td class="style10">
                         MAR</td>
                     <td class="style10">
                         ABR</td>
                     <td class="style10">
                         MAI</td>
                     <td class="style10">
                         JUN</td>
                     <td class="style10">
                         JUL</td>
                     <td class="style10">
                         AGO</td>
                     <td class="style10">
                         SET</td>
                     <td class="style10">
                         OUT</td>
                     <td class="style10">
                         NOV</td>
                     <td class="style9">
                         DEZ</b></td>
                 </tr>
                 <tr>
                     <td class="style10">
                         <asp:Label ID="JANLabel" runat="server" style="text-align: center" 
                             Text='<%# Bind("JAN") %>' />
                     </td>
                     <td class="style10">
                         <asp:Label ID="FEVLabel" runat="server" style="text-align: center" 
                             Text='<%# Bind("FEV") %>' />
                     </td>
                     <td class="style10">
                         <asp:Label ID="MARLabel" runat="server" style="text-align: center" 
                             Text='<%# Bind("MAR") %>' />
                     </td>
                     <td class="style10">
                         <asp:Label ID="ABRLabel" runat="server" Text='<%# Bind("ABR") %>' />
                     </td>
                     <td class="style10">
                         <asp:Label ID="MAILabel" runat="server" Text='<%# Bind("MAI") %>' />
                     </td>
                     <td class="style10">
                         <asp:Label ID="JUNLabel" runat="server" Text='<%# Bind("JUN") %>' />
                     </td>
                     <td class="style10">
                         <asp:Label ID="JULLabel" runat="server" 
                             style="text-align: center; font-weight: 700" Text='<%# Bind("JUL") %>' />
                     </td>
                     <td class="style10">
                         <asp:Label ID="AGOLabel" runat="server" style="text-align: center" 
                             Text='<%# Bind("AGO") %>' />
                     </td>
                     <td class="style10">
                         <asp:Label ID="SETLabel" runat="server" style="text-align: center" 
                             Text='<%# Bind("SET") %>' />
                     </td>
                     <td class="style10">
                         <asp:Label ID="OUTLabel" runat="server" style="text-align: center" 
                             Text='<%# Bind("OUT") %>' />
                     </td>
                     <td class="style10">
                         <asp:Label ID="NOVLabel" runat="server" style="text-align: center" 
                             Text='<%# Bind("NOV") %>' />
                     </td>
                     <td class="style10">
                         <asp:Label ID="DEZLabel" runat="server" style="text-align: center" 
                             Text='<%# Bind("DEZ") %>' />
                     </td>
                 </tr>
             </table>
             &nbsp;<br />
         </ItemTemplate>
         <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
     </asp:FormView>
     <br />
     <asp:GridView ID="gdv_Cotas" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="dts_Cotas" HorizontalAlign="Right" 
         Width="100%" AllowSorting="True">
         <Columns>
             <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                 ReadOnly="True" SortExpression="ID">
             <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
             <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
             <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
             </asp:BoundField>
             <asp:BoundField DataField="ANO" HeaderText="Ano" SortExpression="ANO">
             <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
             <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
             </asp:BoundField>
             <asp:BoundField DataField="NOME" HeaderText="Representante" SortExpression="NOME" >
             <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
             </asp:BoundField>
             <asp:BoundField DataField="LINHA_PRODUTO" HeaderText="Linha de Produtos" SortExpression="LINHA_PRODUTO">
             <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
             <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
             </asp:BoundField>
             <asp:BoundField DataField="JAN" HeaderText="JAN" SortExpression="JAN" 
                 ReadOnly="True" />
             <asp:BoundField DataField="FEV" HeaderText="FEV" SortExpression="FEV" 
                 ReadOnly="True" />
             <asp:BoundField DataField="MAR" HeaderText="MAR" SortExpression="MAR" 
                 ReadOnly="True" />
             <asp:BoundField DataField="ABR" HeaderText="ABR" ReadOnly="True" 
                 SortExpression="ABR" />
             <asp:BoundField DataField="MAI" HeaderText="MAI" ReadOnly="True" 
                 SortExpression="MAI" />
             <asp:BoundField DataField="JUN" HeaderText="JUN" ReadOnly="True" 
                 SortExpression="JUN" />
             <asp:BoundField DataField="JUL" HeaderText="JUL" ReadOnly="True" 
                 SortExpression="JUL" />
             <asp:BoundField DataField="AGO" HeaderText="AGO" ReadOnly="True" 
                 SortExpression="AGO" />
             <asp:BoundField DataField="SET" HeaderText="SET" ReadOnly="True" 
                 SortExpression="SET" />
             <asp:BoundField DataField="OUT" HeaderText="OUT" ReadOnly="True" 
                 SortExpression="OUT" />
             <asp:BoundField DataField="NOV" HeaderText="NOV" ReadOnly="True" 
                 SortExpression="NOV" />
             <asp:BoundField DataField="DEZ" HeaderText="DEZ" ReadOnly="True" 
                 SortExpression="DEZ" />
             <asp:BoundField DataField="TOTAL" HeaderText="TOTAL" ReadOnly="True" 
                 SortExpression="TOTAL" />
         </Columns>
         <HeaderStyle 
             HorizontalAlign="Center" VerticalAlign="Middle" />
         <RowStyle HorizontalAlign="Center" 
             VerticalAlign="Middle" />
     </asp:GridView>
    </div>
    </form>
    
    <asp:SqlDataSource ID="dts_Usuarios" runat="server" 
    ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
    SelectCommand="SELECT [EMAIL], [NOME] FROM [VIEW_USUARIOS] ORDER BY [PERFIL],[USUARIO]">
</asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Cotas" runat="server" 
         ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
         OldValuesParameterFormatString="original_{0}" 
         
        SelectCommand="SELECT * FROM [VIEW_COTAS] WHERE ([ANO] = @ANO) ORDER BY [PERFIL], [NOME], [ANO]">
    <SelectParameters>
        <asp:ControlParameter ControlID="cmb_ANOS_Filtro" Name="ANO" 
            PropertyName="SelectedValue" Type="Decimal" />
    </SelectParameters>
     </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Anos" runat="server" 
         ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
         SelectCommand="SELECT * FROM [TBL_DATAS_ANOS] WHERE [ANO_PERIODO] = 'PASSADO' OR  [ANO_PERIODO] = 'ATUAL' OR [ANO_PERIODO] = 'PROXIMO'  ORDER BY [ANO_VALOR] DESC">
     </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Cotas_Inclusao" runat="server" 
         ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
         DeleteCommand="DELETE FROM [TBL_COTAS] WHERE [ID] = @original_ID" 
         InsertCommand="INSERT INTO [TBL_COTAS] ([EMAIL], [ANO], [JAN], [FEV], [MAR], [ABR], [MAI], [JUN], [JUL], [AGO], [SET], [OUT], [NOV], [DEZ], [INCLUSAO_EMAIL], [INCLUSAO_DATA], [ALTERACAO_EMAIL], [ALTERACAO_DATA], [EXCLUSAO_EMAIL], [EXCLUSAO_DATA]) VALUES (@EMAIL, @ANO, @JAN, @FEV, @MAR, @ABR, @MAI, @JUN, @JUL, @AGO, @SET, @OUT, @NOV, @DEZ, @INCLUSAO_EMAIL, @INCLUSAO_DATA, @ALTERACAO_EMAIL, @ALTERACAO_DATA, @EXCLUSAO_EMAIL, @EXCLUSAO_DATA)" 
         OldValuesParameterFormatString="original_{0}" 
         SelectCommand="SELECT * FROM [TBL_COTAS] WHERE ([ID] = @ID) ORDER BY [EMAIL], [ANO]" 
         
         UpdateCommand="UPDATE [TBL_COTAS] SET [EMAIL] = @EMAIL, [ANO] = @ANO, [JAN] = @JAN, [FEV] = @FEV, [MAR] = @MAR, [ABR] = @ABR, [MAI] = @MAI, [JUN] = @JUN, [JUL] = @JUL, [AGO] = @AGO, [SET] = @SET, [OUT] = @OUT, [NOV] = @NOV, [DEZ] = @DEZ, [INCLUSAO_EMAIL] = @INCLUSAO_EMAIL, [INCLUSAO_DATA] = @INCLUSAO_DATA, [ALTERACAO_EMAIL] = @ALTERACAO_EMAIL, [ALTERACAO_DATA] = @ALTERACAO_DATA, [EXCLUSAO_EMAIL] = @EXCLUSAO_EMAIL, [EXCLUSAO_DATA] = @EXCLUSAO_DATA WHERE [ID] = @original_ID">
         <DeleteParameters>
             <asp:Parameter Name="original_ID" Type="Decimal" />
         </DeleteParameters>
         <InsertParameters>
             <asp:Parameter Name="EMAIL" Type="String" />
             <asp:Parameter Name="ANO" Type="Decimal" />
             <asp:Parameter Name="JAN" Type="Decimal" />
             <asp:Parameter Name="FEV" Type="Decimal" />
             <asp:Parameter Name="MAR" Type="Decimal" />
             <asp:Parameter Name="ABR" Type="Decimal" />
             <asp:Parameter Name="MAI" Type="Decimal" />
             <asp:Parameter Name="JUN" Type="Decimal" />
             <asp:Parameter Name="JUL" Type="Decimal" />
             <asp:Parameter Name="AGO" Type="Decimal" />
             <asp:Parameter Name="SET" Type="Decimal" />
             <asp:Parameter Name="OUT" Type="Decimal" />
             <asp:Parameter Name="NOV" Type="Decimal" />
             <asp:Parameter Name="DEZ" Type="Decimal" />
             <asp:Parameter Name="INCLUSAO_EMAIL" Type="String" />
             <asp:Parameter Name="INCLUSAO_DATA" Type="Decimal" />
             <asp:Parameter Name="ALTERACAO_EMAIL" Type="String" />
             <asp:Parameter Name="ALTERACAO_DATA" Type="Decimal" />
             <asp:Parameter Name="EXCLUSAO_EMAIL" Type="String" />
             <asp:Parameter Name="EXCLUSAO_DATA" Type="Decimal" />
         </InsertParameters>
         <SelectParameters>
             <asp:ControlParameter ControlID="gdv_Cotas" Name="ID" 
                 PropertyName="SelectedValue" Type="Decimal" />
         </SelectParameters>
         <UpdateParameters>
             <asp:Parameter Name="EMAIL" Type="String" />
             <asp:Parameter Name="ANO" Type="Decimal" />
             <asp:Parameter Name="JAN" Type="Decimal" />
             <asp:Parameter Name="FEV" Type="Decimal" />
             <asp:Parameter Name="MAR" Type="Decimal" />
             <asp:Parameter Name="ABR" Type="Decimal" />
             <asp:Parameter Name="MAI" Type="Decimal" />
             <asp:Parameter Name="JUN" Type="Decimal" />
             <asp:Parameter Name="JUL" Type="Decimal" />
             <asp:Parameter Name="AGO" Type="Decimal" />
             <asp:Parameter Name="SET" Type="Decimal" />
             <asp:Parameter Name="OUT" Type="Decimal" />
             <asp:Parameter Name="NOV" Type="Decimal" />
             <asp:Parameter Name="DEZ" Type="Decimal" />
             <asp:Parameter Name="INCLUSAO_EMAIL" Type="String" />
             <asp:Parameter Name="INCLUSAO_DATA" Type="Decimal" />
             <asp:Parameter Name="ALTERACAO_EMAIL" Type="String" />
             <asp:Parameter Name="ALTERACAO_DATA" Type="Decimal" />
             <asp:Parameter Name="EXCLUSAO_EMAIL" Type="String" />
             <asp:Parameter Name="EXCLUSAO_DATA" Type="Decimal" />
             <asp:Parameter Name="original_ID" Type="Decimal" />
         </UpdateParameters>
     </asp:SqlDataSource>
     
</body>
</html>
