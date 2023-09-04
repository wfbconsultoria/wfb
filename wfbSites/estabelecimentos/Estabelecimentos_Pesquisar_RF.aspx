<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Estabelecimentos_Pesquisar_RF.aspx.vb" Inherits="Estabelecimentos_Pesquisar" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pesquisa Estabelecimento</title>
</head>
<body>
    <div class="container">
        <div class="jumbotron">
            <form id="form1" runat="server">
                <uc1:Cabecalho runat="server" ID="Cabecalho" />
                <h1 style="font-size: 30px;">Pesquisa de Estabelecimentos</h1>
                <div>
                    <h2>Incluir um novo estabelecimento:</h2>
                    <p style="font-size: 15px; text-align: center;">A consulta é efetuada na Receita Federal do Brasil
                        Somente pode ser incluído CNPJ válido</p><br />

                    <table>
                        
                        <tr>
                            <td style="width: 40%;">2 - Digite o número do CNPJ</td>
                            <td class="txtbox">
                                <asp:TextBox CssClass="campos" ID="txt_DOCUMENTO" runat="server" MaxLength="14" Style="font-weight: 700"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 40%;">3 - Clique em: </td>
                            <td class="txtbox">
                                <asp:Button CssClass="btn btn-primary" ID="cmd_Consultar" runat="server" Text="Consultar" /></td>
                        </tr>
                   </table>
                   
                </div>
            </form>
        </div>
    </div>
</body>
</html>
