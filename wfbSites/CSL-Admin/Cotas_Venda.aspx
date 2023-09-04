<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Cotas_Venda.aspx.vb" Inherits="Cotas_Venda" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Manutenção de Cotas de Vendas</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style3 {
            text-align: left;
            height: 28px;
        }
        .auto-style4 {
            color: #73598C;
        }
        .auto-style5 {
            text-align: center;
            color: #5A388C;
        }
        .auto-style8 {
            height: 28px;
            text-align: center;
        }
        .auto-style9 {
            font-weight: bold;
        }
        .text-center {
            text-align:center;
        }
    </style>
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">
        Manutenção de Cotas de Venda
        &nbsp;Ano&nbsp;<asp:DropDownList ID="cmb_Anos" runat="server" DataSourceID="dts_Anos" DataTextField="ANO_VALOR" DataValueField="ANO_VALOR" AutoPostBack="True"></asp:DropDownList>
        &nbsp;Representante&nbsp;<asp:DropDownList ID="cmb_Usuarios" runat="server" DataSourceID="dts_Usuarios" DataTextField="NOME" DataValueField="EMAIL" AutoPostBack="True"></asp:DropDownList>
    </div>
    <div id ="Titulo_Pagina_Links"></div>
</div>    
<br />
<div id ="Corpo">
    <br />
        <table  id="tbl_Cotas_01" style="border: 1px solid #C0C0C0; width: 100%">
            <tr>
                <td class="auto-style3" colspan="12">
                    Divisão de Produtos 
                    <asp:DropDownList ID="cmb_Divisao_Produtos_01" runat="server" DataSourceID="dts_Divisao_Produto_01" DataTextField="PRODUTO_DIVISAO" DataValueField="COD_PRODUTO_DIVISAO" AutoPostBack="True" CssClass="auto-style9"></asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
                    <span style="font-size: small">*Cotas de Venda em BRL. Utilizar a virgula como separador de centavos.</span>
                </td>
            </tr>
            <tr class="auto-style4">
                <td class="auto-style5">JAN</td>
                <td class="auto-style5">FEV</td>
                <td class="auto-style5">MAR</td>
                <td class="auto-style5">ABR</td>
                <td class="auto-style5">MAI</td>
                <td class="auto-style5">JUN</td>
                <td class="auto-style5">JUL</td>
                <td class="auto-style5">AGO</td>
                <td class="auto-style5">SET</td>
                <td class="auto-style5">OUT</td>
                <td class="auto-style5">NOV</td>
                <td class="auto-style5">DEZ</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JAN_01" runat="server" Width="90%" CssClass="text-center"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JAN_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Currency" ControlToValidate="txt_JAN_01" ForeColor="Red"></asp:RangeValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_FEV_01" runat="server" Width="90%" CssClass="text-center"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_FEV_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Currency" ControlToValidate="txt_FEV_01" ForeColor="Red"></asp:RangeValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAR_01" runat="server" Width="90%" CssClass="text-center"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAR_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Currency" ControlToValidate="txt_MAR_01" ForeColor="Red"></asp:RangeValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_ABR_01" runat="server" Width="90%" CssClass="text-center"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_ABR_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Currency" ControlToValidate="txt_ABR_01" ForeColor="Red"></asp:RangeValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAI_01" runat="server" Width="90%" CssClass="text-center"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAI_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Currency" ControlToValidate="txt_MAI_01" ForeColor="Red"></asp:RangeValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUN_01" runat="server" Width="90%" CssClass="text-center"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUN_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Currency" ControlToValidate="txt_JUN_01" ForeColor="Red"></asp:RangeValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUL_01" runat="server" Width="90%" CssClass="text-center"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUL_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Currency" ControlToValidate="txt_JUL_01" ForeColor="Red"></asp:RangeValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_AGO_01" runat="server" Width="90%" CssClass="text-center"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_AGO_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Currency" ControlToValidate="txt_AGO_01" ForeColor="Red"></asp:RangeValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_SET_01" runat="server" Width="90%" CssClass="text-center"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_SET_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Currency" ControlToValidate="txt_SET_01" ForeColor="Red"></asp:RangeValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_OUT_01" runat="server" Width="90%" CssClass="text-center"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_OUT_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Currency" ControlToValidate="txt_OUT_01" ForeColor="Red"></asp:RangeValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_NOV_01" runat="server" Width="90%" CssClass="text-center"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_NOV_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Currency" ControlToValidate="txt_NOV_01" ForeColor="Red"></asp:RangeValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_DEZ_01" runat="server" Width="90%" CssClass="text-center"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_DEZ_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Currency" ControlToValidate="txt_DEZ_01" ForeColor="Red"></asp:RangeValidator>
                </td>
            </tr>
        </table>
        <br />
    <asp:Button Class="buton_gravar" ID="cmd_Gravar" runat="server" Text="Gravar" />
   </div>
        <asp:SqlDataSource ID="dts_Anos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [tbl_DATAS_ANOS] WHERE ([ANO_FECHADO_COTAS] = @ANO_FECHADO_COTAS) ORDER BY [ANO_VALOR] DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="False" Name="ANO_FECHADO_COTAS" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_Usuarios" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [tbl_USUARIOS] WHERE ([COD_PERFIL] = @COD_PERFIL) ORDER BY [NOME]">
            <SelectParameters>
                <asp:Parameter DefaultValue="4" Name="COD_PERFIL" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_Divisao_Produto_01" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_PRODUTOS_DIVISAO] WHERE ([COD_PRODUTO_DIVISAO] = @COD_PRODUTO_DIVISAO)">
            <SelectParameters>
                <asp:Parameter DefaultValue="9" Name="COD_PRODUTO_DIVISAO" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
</form>
</body>
</html>