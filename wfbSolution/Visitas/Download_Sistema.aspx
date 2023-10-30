<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Download_Sistema.aspx.vb" Inherits="Download_Sistema" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Download de Arquivos de Sistema</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/MasterTheme/Master.css" />
    </head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Download de Arquivos de Sistema</div>
    <div id ="Titulo_Pagina_Links"></div>
</div>    
<div id ="Corpo">
    <br/>
    <table width="100%" >
        <tr>
            <td width="20%" style="vertical-align: top;">
                <asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer" NodeIndent="15">
                    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                    <Nodes>
                        <asp:TreeNode Expanded="False" Text="Sistema" Value="Arquivos\Sistema">
                            <asp:TreeNode Expanded="False" Text="Connections" Value="Arquivos\Sistema\Connections"></asp:TreeNode>
                            <asp:TreeNode Text="Importadores" Value="Arquivos\Sistema\Importadores"></asp:TreeNode>
                            <asp:TreeNode Text="Importadores Sales Price" Value="Arquivos\Sistema\Importadores Sales Price"></asp:TreeNode>
                        </asp:TreeNode>
                    </Nodes>
                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                    <ParentNodeStyle Font-Bold="False" />
                    <SelectedNodeStyle Font-Bold="True" Font-Italic="False" BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px" VerticalPadding="0px" />
                </asp:TreeView>
            </td>
            <td width="50%" aria-orientation="horizontal" style="vertical-align: top;">
                Selecione o arquivo desejado e clique em &quot;Baixar&quot;.<br />
                <input id="btnDownload" runat="server" type="button" value="Baixar" style="float:left; margin-top: 0px;" onserverclick="btnDownload_ServerClick" class="buton_gravar" /><br />
                <asp:ListBox ID="lstArquivos" BorderThickness="0" Runat="server" Rows="6" style="text-align: left; color: #000000; font-size: small; border:0px;" Width="100%" Height="510px" AutoPostBack="True" />
            </td>
            <td width="30%" style="vertical-align: top;">

                Informações do arquivo:<br />
                <strong>Caminho:</strong>
                <asp:Label ID="lbl_Pasta" runat="server" Text="Nenhuma Pasta Selecionada"></asp:Label>
                <br />
                        <strong>Tamanho:</strong>
                        <asp:Label ID="lbl_TAMANHO" runat="server" />
                        &nbsp;Bytes<br /> <strong>Extensão:</strong>
                        <asp:Label ID="lbl_EXTENCAO" runat="server" />
                <asp:FormView ID="frv_Arquivo" runat="server" DataSourceID="dts_ARQUIVO" DataKeyNames="ID">
                    <ItemTemplate>
                        <strong>Observação:</strong>
                        <asp:Label ID="OBSERVACAOLabel" runat="server" Text='<%# Bind("OBSERVACAO") %>' />
                    </ItemTemplate>
                </asp:FormView>
                <br />

                Últimos 50 Downloads do arquivo selecionado.<asp:GridView ID="gdv_LOG_DOWNLOAD" runat="server" AutoGenerateColumns="False" DataSourceID="dts_LOG_DOWNLOAD" Width="100%" Height="100%">
                    <Columns>
                        <asp:BoundField DataField="USUARIO" HeaderText="Usuário" SortExpression="USUARIO">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DATA_EXTENSO" HeaderText="Data" ReadOnly="True" SortExpression="DATA_EXTENSO">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                    </Columns>
                    <EmptyDataTemplate>
                        <strong>Nenhum log de download para o arquivo selecionado! </strong>
                    </EmptyDataTemplate>
                </asp:GridView>

            </td>
        </tr>
    </table>
    <br />
    </div>
    <asp:SqlDataSource ID="dts_LOG_DOWNLOAD" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT TOP (50) ARQUIVO, USUARIO, DATA_EXTENSO, DATA FROM VIEW_LOG_DOWNLOAD WHERE (ARQUIVO = @ARQUIVO) ORDER BY DATA DESC">
        <SelectParameters>
            <asp:ControlParameter ControlID="lbl_Pasta" Name="ARQUIVO" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_ARQUIVO" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_ARQUIVOS] WHERE ([CAMINHO] = @CAMINHO)">
        <SelectParameters>
            <asp:ControlParameter ControlID="lstArquivos" Name="CAMINHO" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</form>
</body>
</html>