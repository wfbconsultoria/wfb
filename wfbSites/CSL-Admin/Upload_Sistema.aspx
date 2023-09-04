<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Upload_Sistema.aspx.vb" Inherits="Upload_Sistema" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Upload de Arquivos de Sistema</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/MasterTheme/Master.css" />
    <style type="text/css">

        .auto-style1 {
            font-size: small;
        }
    </style>
    </head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Upload de Arquivos de Sistema</div>
    <div id ="Titulo_Pagina_Links"></div>
</div>    
<div id ="Corpo">
                <asp:Label ID="lbl_raiz" runat="server" Text="Nenhuma Pasta Selecionada" style="font-weight: 700" Visible="False"></asp:Label>
    <br/>
    <table width="100%" >
        <tr>
            <td width="20%" style="vertical-align: top;">
                <asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer" NodeIndent="15">
                    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                    <Nodes>
                        <asp:TreeNode Expanded="False" Text="Sistema" Value="Arquivos\Sistema">
                            <asp:TreeNode Text="Importadores" Value="Arquivos\Sistema\Importadores"></asp:TreeNode>
                        </asp:TreeNode>
                    </Nodes>
                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                    <ParentNodeStyle Font-Bold="False" />
                    <SelectedNodeStyle Font-Bold="True" Font-Italic="False" BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px" VerticalPadding="0px" />
                </asp:TreeView>
            </td>
            <td width="40%" aria-orientation="horizontal" style="vertical-align: top;">
                <asp:ListBox ID="lstArquivos" BorderThickness="0" Runat="server" Rows="6" style="text-align: left; color: #000000; font-size: small; border:0px;" Width="100%" Height="510px" />
            </td>
            <td width="40%" style="vertical-align: top;">

                Caminho:
                <asp:Label ID="lbl_Pasta" runat="server" Text="Nenhuma Pasta Selecionada" style="font-weight: 700"></asp:Label>
                <br />
    <span class="auto-style1">Obs: Só é aceito arquivos de no máximo 20MB!</span><br />
    
    <asp:FileUpload ID="fup_Mapas" runat="server" class="multi" />
    <br />
    Escreva alguma observação sobre o arquivo:<br />
    <asp:TextBox ID="txt_OBSERVACAO" runat="server" Rows="3" TextMode="MultiLine" Width="100%"></asp:TextBox>
    <br/>
    <asp:Button ID="btn_Upload_Enviar" runat="server" Text="Enviar" CssClass="buton_gravar" />
    
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
