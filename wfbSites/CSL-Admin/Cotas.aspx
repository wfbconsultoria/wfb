<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Cotas.aspx.vb" Inherits="Cotas" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Manutenção de Cotas</title>
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
            height: 5px;
            text-align: center;
        }
        .auto-style9 {
            font-weight: bold;
        }
        .text-center {
            text-align:center;
        }
        .auto-style10 {
            font-size: medium;
        }
    </style>
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">
        Manutenção de Cotas
        &nbsp;Ano Fiscal &nbsp;<asp:DropDownList ID="cmb_Anos" runat="server" DataSourceID="dts_Anos" DataTextField="ANO_FISCAL" DataValueField="ANO_FISCAL" AutoPostBack="True"></asp:DropDownList>
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
                    <strong>Cota de Venda em Reais da CSL</strong>&nbsp;&nbsp;&nbsp;
                    <span class="auto-style10">(*Cotas de Venda em BRL. Utilizar a virgula como separador de centavos.)</span></td>
            </tr>
            <tr class="auto-style4">
                <td class="auto-style5">01</td>
                <td class="auto-style5">02</td>
                <td class="auto-style5">03</td>
                <td class="auto-style5">04</td>
                <td class="auto-style5">05</td>
                <td class="auto-style5">06</td>
                <td class="auto-style5">07</td>
                <td class="auto-style5">08</td>
                <td class="auto-style5">09</td>
                <td class="auto-style5">10</td>
                <td class="auto-style5">11</td>
                <td class="auto-style5">12</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JAN_01" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JAN_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Double" ControlToValidate="txt_JAN_01" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_JAN_01" runat="server" ControlToValidate="txt_JAN_01" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_FEV_01" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_FEV_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Double" ControlToValidate="txt_FEV_01" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_FEV_01" runat="server" ControlToValidate="txt_FEV_01" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAR_01" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAR_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Double" ControlToValidate="txt_MAR_01" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_MAR_01" runat="server" ControlToValidate="txt_MAR_01" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_ABR_01" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_ABR_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Double" ControlToValidate="txt_ABR_01" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_ABR_01" runat="server" ControlToValidate="txt_ABR_01" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAI_01" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAI_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Double" ControlToValidate="txt_MAI_01" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_MAI_01" runat="server" ControlToValidate="txt_MAI_01" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUN_01" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUN_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Double" ControlToValidate="txt_JUN_01" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_JUN_01" runat="server" ControlToValidate="txt_JUN_01" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUL_01" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUL_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Double" ControlToValidate="txt_JUL_01" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_JUL_01" runat="server" ControlToValidate="txt_JUL_01" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_AGO_01" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_AGO_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Double" ControlToValidate="txt_AGO_01" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_AGO_01" runat="server" ControlToValidate="txt_AGO_01" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_SET_01" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_SET_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Double" ControlToValidate="txt_SET_01" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_SET_01" runat="server" ControlToValidate="txt_SET_01" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_OUT_01" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_OUT_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Double" ControlToValidate="txt_OUT_01" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_OUT_01" runat="server" ControlToValidate="txt_OUT_01" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_NOV_01" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_NOV_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Double" ControlToValidate="txt_NOV_01" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_NOV_01" runat="server" ControlToValidate="txt_NOV_01" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_DEZ_01" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_DEZ_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Double" ControlToValidate="txt_DEZ_01" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_DEZ_01" runat="server" ControlToValidate="txt_DEZ_01" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <br />
        <table  id="tbl_Cotas_02" style="border: 1px solid #C0C0C0; width: 100%">
            <tr>
                <td class="auto-style3" colspan="12">
                    <b>Cota de Venda em Reais -
                    Linha de
                    Produto
                    </b>
                    <asp:DropDownList ID="cmb_Tipo_Produto_02" runat="server" DataSourceID="dts_Tipo_Produto_02" DataTextField="PRODUTO_LINHA" DataValueField="COD_PRODUTO_LINHA" AutoPostBack="True" CssClass="auto-style9"></asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
                    <span class="auto-style10">(*Cotas de Venda em BRL. Utilizar a virgula como separador de centavos.)</span></td>
            </tr>
            <tr class="auto-style4">
                <td class="auto-style5">01</td>
                <td class="auto-style5">02</td>
                <td class="auto-style5">03</td>
                <td class="auto-style5">04</td>
                <td class="auto-style5">05</td>
                <td class="auto-style5">06</td>
                <td class="auto-style5">07</td>
                <td class="auto-style5">08</td>
                <td class="auto-style5">09</td>
                <td class="auto-style5">10</td>
                <td class="auto-style5">11</td>
                <td class="auto-style5">12</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JAN_02" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JAN_02" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Double" ControlToValidate="txt_JAN_02" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_JAN_2" runat="server" ControlToValidate="txt_JAN_02" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_FEV_02" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_FEV_02" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Double" ControlToValidate="txt_FEV_02" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_FEV_2" runat="server" ControlToValidate="txt_FEV_02" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAR_02" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAR_02" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Double" ControlToValidate="txt_MAR_02" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_MAR_2" runat="server" ControlToValidate="txt_MAR_02" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_ABR_02" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_ABR_02" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Double" ControlToValidate="txt_ABR_02" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_ABR_2" runat="server" ControlToValidate="txt_ABR_02" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAI_02" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAI_02" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Double" ControlToValidate="txt_MAI_02" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_MAI_2" runat="server" ControlToValidate="txt_MAI_02" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUN_02" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUN_02" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Double" ControlToValidate="txt_JUN_02" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_JUN_2" runat="server" ControlToValidate="txt_JUN_02" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUL_02" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUL_02" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Double" ControlToValidate="txt_JUL_02" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_JUL_2" runat="server" ControlToValidate="txt_JUL_02" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_AGO_02" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_AGO_02" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Double" ControlToValidate="txt_AGO_02" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_AGO_2" runat="server" ControlToValidate="txt_AGO_02" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_SET_02" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_SET_02" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Double" ControlToValidate="txt_SET_02" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_SET_2" runat="server" ControlToValidate="txt_SET_02" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_OUT_02" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_OUT_02" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Double" ControlToValidate="txt_OUT_02" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_OUT_2" runat="server" ControlToValidate="txt_OUT_02" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_NOV_02" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_NOV_02" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Double" ControlToValidate="txt_NOV_02" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_NOV_2" runat="server" ControlToValidate="txt_NOV_02" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_DEZ_02" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_DEZ_02" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999999999" Type="Double" ControlToValidate="txt_DEZ_02" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_DEZ_2" runat="server" ControlToValidate="txt_DEZ_02" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <br />
        <table  id="tbl_Cotas_03" style="border: 1px solid #C0C0C0; width: 100%">
            <tr>
                <td class="auto-style3" colspan="12">
                    &nbsp;<b>Cota de Demanda em Unidade Equivalente - Linha de Produto </b> <asp:DropDownList ID="cmb_Tipo_Produto_03" runat="server" DataSourceID="dts_Tipo_Produto_03" DataTextField="PRODUTO_LINHA" DataValueField="COD_PRODUTO_LINHA" AutoPostBack="True" CssClass="auto-style9"></asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
                    <span class="auto-style10">(*Cotas de Demanda. Não utilizar ponto.</span>)</td>
            </tr>
            <tr class="auto-style4">
                <td class="auto-style5">01</td>
                <td class="auto-style5">02</td>
                <td class="auto-style5">03</td>
                <td class="auto-style5">04</td>
                <td class="auto-style5">05</td>
                <td class="auto-style5">06</td>
                <td class="auto-style5">07</td>
                <td class="auto-style5">08</td>
                <td class="auto-style5">09</td>
                <td class="auto-style5">10</td>
                <td class="auto-style5">11</td>
                <td class="auto-style5">12</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JAN_03" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JAN_03" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="99999999" Type="Double" ControlToValidate="txt_JAN_03" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_JAN_3" runat="server" ControlToValidate="txt_JAN_03" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_FEV_03" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_FEV_03" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_FEV_03" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_FEV_3" runat="server" ControlToValidate="txt_FEV_03" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAR_03" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAR_03" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_MAR_03" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_MAR_3" runat="server" ControlToValidate="txt_MAR_03" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_ABR_03" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_ABR_03" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_ABR_03" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_ABR_3" runat="server" ControlToValidate="txt_ABR_03" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAI_03" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAI_03" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_MAI_03" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_MAI_3" runat="server" ControlToValidate="txt_MAI_03" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUN_03" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUN_03" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_JUN_03" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_JUN_3" runat="server" ControlToValidate="txt_JUN_03" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUL_03" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUL_03" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_JUL_03" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_JUL_3" runat="server" ControlToValidate="txt_JUL_03" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_AGO_03" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_AGO_03" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_AGO_03" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_AGO_3" runat="server" ControlToValidate="txt_AGO_03" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_SET_03" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_SET_03" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_SET_03" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_SET_3" runat="server" ControlToValidate="txt_SET_03" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_OUT_03" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_OUT_03" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_OUT_03" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_OUT_3" runat="server" ControlToValidate="txt_OUT_03" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_NOV_03" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_NOV_03" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_NOV_03" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_NOV_3" runat="server" ControlToValidate="txt_NOV_03" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_DEZ_03" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_DEZ_03" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_DEZ_03" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_DEZ_3" runat="server" ControlToValidate="txt_DEZ_03" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <br />
        <table  id="tbl_Cotas_04" style="border: 1px solid #C0C0C0; width: 100%">
            <tr>
                <td class="auto-style3" colspan="12">
                    <b>Cota de Demanda em Unidade Equivalente -
                    Linha de&nbsp;Produto </b> <asp:DropDownList ID="cmb_Tipo_Produto_04" runat="server" DataSourceID="dts_Tipo_Produto_04" DataTextField="PRODUTO_LINHA" DataValueField="COD_PRODUTO_LINHA" AutoPostBack="True" CssClass="auto-style9"></asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
                    <span class="auto-style10">(*Cotas de Demanda. Não utilizar ponto.</span>)
                </td>
            </tr>
            <tr class="auto-style4">
                <td class="auto-style5">01</td>
                <td class="auto-style5">02</td>
                <td class="auto-style5">03</td>
                <td class="auto-style5">04</td>
                <td class="auto-style5">05</td>
                <td class="auto-style5">06</td>
                <td class="auto-style5">07</td>
                <td class="auto-style5">08</td>
                <td class="auto-style5">09</td>
                <td class="auto-style5">10</td>
                <td class="auto-style5">11</td>
                <td class="auto-style5">12</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JAN_04" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JAN_04" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="99999999" Type="Double" ControlToValidate="txt_JAN_04" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_JAN_4" runat="server" ControlToValidate="txt_JAN_04" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_FEV_04" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_FEV_04" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_FEV_04" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_FEV_4" runat="server" ControlToValidate="txt_FEV_04" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAR_04" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAR_04" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_MAR_04" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_MAR_4" runat="server" ControlToValidate="txt_MAR_04" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_ABR_04" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_ABR_04" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_ABR_04" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_ABR_4" runat="server" ControlToValidate="txt_ABR_04" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAI_04" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAI_04" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_MAI_04" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_MAI_4" runat="server" ControlToValidate="txt_MAI_04" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUN_04" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUN_04" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_JUN_04" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_JUN_4" runat="server" ControlToValidate="txt_JUN_04" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUL_04" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUL_04" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_JUL_04" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_JUL_4" runat="server" ControlToValidate="txt_JUL_04" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_AGO_04" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_AGO_04" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_AGO_04" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_AGO_4" runat="server" ControlToValidate="txt_AGO_04" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_SET_04" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_SET_04" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_SET_04" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_SET_4" runat="server" ControlToValidate="txt_SET_04" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_OUT_04" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_OUT_04" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_OUT_04" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_OUT_4" runat="server" ControlToValidate="txt_OUT_04" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_NOV_04" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_NOV_04" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_NOV_04" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_NOV_4" runat="server" ControlToValidate="txt_NOV_04" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_DEZ_04" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_DEZ_04" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_DEZ_04" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_DEZ_4" runat="server" ControlToValidate="txt_DEZ_04" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <br />
    <table  id="tbl_Cotas_05" style="border: 1px solid #C0C0C0; width: 100%">
            <tr>
                <td class="auto-style3" colspan="12">
                    &nbsp;<b>Cota de Demanda em Unidade Equivalente - Linha de Produto </b> <asp:DropDownList ID="cmb_Tipo_Produto_05" runat="server" DataSourceID="dts_Tipo_Produto_05" DataTextField="PRODUTO_LINHA" DataValueField="COD_PRODUTO_LINHA" AutoPostBack="True" CssClass="auto-style9"></asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
                    <span class="auto-style10">(*Cotas de Demanda. Não utilizar ponto.</span>)
                </td>
            </tr>
            <tr class="auto-style4">
                <td class="auto-style5">01</td>
                <td class="auto-style5">02</td>
                <td class="auto-style5">03</td>
                <td class="auto-style5">04</td>
                <td class="auto-style5">05</td>
                <td class="auto-style5">06</td>
                <td class="auto-style5">07</td>
                <td class="auto-style5">08</td>
                <td class="auto-style5">09</td>
                <td class="auto-style5">10</td>
                <td class="auto-style5">11</td>
                <td class="auto-style5">12</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JAN_05" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JAN_05" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="99999999" Type="Double" ControlToValidate="txt_JAN_05" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_JAN_5" runat="server" ControlToValidate="txt_JAN_05" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_FEV_05" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_FEV_05" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_FEV_05" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_FEV_5" runat="server" ControlToValidate="txt_FEV_05" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAR_05" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAR_05" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_MAR_05" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_MAR_5" runat="server" ControlToValidate="txt_MAR_05" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_ABR_05" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_ABR_05" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_ABR_05" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_ABR_5" runat="server" ControlToValidate="txt_ABR_05" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAI_05" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAI_05" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_MAI_05" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_MAI_5" runat="server" ControlToValidate="txt_MAI_05" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUN_05" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUN_05" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_JUN_05" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_JUN_5" runat="server" ControlToValidate="txt_JUN_05" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUL_05" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUL_05" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_JUL_05" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_JUL_5" runat="server" ControlToValidate="txt_JUL_05" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_AGO_05" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_AGO_05" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_AGO_05" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_AGO_5" runat="server" ControlToValidate="txt_AGO_05" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_SET_05" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_SET_05" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_SET_05" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_SET_5" runat="server" ControlToValidate="txt_SET_05" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_OUT_05" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_OUT_05" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_OUT_05" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_OUT_5" runat="server" ControlToValidate="txt_OUT_05" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_NOV_05" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_NOV_05" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_NOV_05" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_NOV_5" runat="server" ControlToValidate="txt_NOV_05" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_DEZ_05" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_DEZ_05" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_DEZ_05" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_DEZ_5" runat="server" ControlToValidate="txt_DEZ_05" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    <br />
        <table  id="tbl_Cotas_06" style="border: 1px solid #C0C0C0; width: 100%">
            <tr>
                <td class="auto-style3" colspan="12">
                    &nbsp;<b>Cota de Demanda em Unidade Equivalente - Linha de Produto </b> <asp:DropDownList ID="cmb_Tipo_Produto_06" runat="server" DataSourceID="dts_Tipo_Produto_06" DataTextField="PRODUTO_LINHA" DataValueField="COD_PRODUTO_LINHA" AutoPostBack="True" CssClass="auto-style9"></asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
                    <span class="auto-style10">(*Cotas de Demanda. Não utilizar ponto.</span>)
                </td>
            </tr>
            <tr class="auto-style4">
                <td class="auto-style5">01</td>
                <td class="auto-style5">02</td>
                <td class="auto-style5">03</td>
                <td class="auto-style5">04</td>
                <td class="auto-style5">05</td>
                <td class="auto-style5">06</td>
                <td class="auto-style5">07</td>
                <td class="auto-style5">08</td>
                <td class="auto-style5">09</td>
                <td class="auto-style5">10</td>
                <td class="auto-style5">11</td>
                <td class="auto-style5">12</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JAN_06" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JAN_06" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="99999999" Type="Double" ControlToValidate="txt_JAN_06" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_JAN_6" runat="server" ControlToValidate="txt_JAN_06" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_FEV_06" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_FEV_06" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_FEV_06" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_FEV_6" runat="server" ControlToValidate="txt_FEV_06" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAR_06" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAR_06" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_MAR_06" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_MAR_6" runat="server" ControlToValidate="txt_MAR_06" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_ABR_06" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_ABR_06" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_ABR_06" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_ABR_6" runat="server" ControlToValidate="txt_ABR_06" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAI_06" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAI_06" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_MAI_06" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_MAI_6" runat="server" ControlToValidate="txt_MAI_06" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUN_06" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUN_06" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_JUN_06" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_JUN_6" runat="server" ControlToValidate="txt_JUN_06" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUL_06" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUL_06" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_JUL_06" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_JUL_6" runat="server" ControlToValidate="txt_JUL_06" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_AGO_06" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_AGO_06" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_AGO_06" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_AGO_6" runat="server" ControlToValidate="txt_AGO_06" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_SET_06" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_SET_06" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_SET_06" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_SET_6" runat="server" ControlToValidate="txt_SET_06" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_OUT_06" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_OUT_06" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_OUT_06" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_OUT_6" runat="server" ControlToValidate="txt_OUT_06" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_NOV_06" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_NOV_06" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_NOV_06" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_NOV_6" runat="server" ControlToValidate="txt_NOV_06" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_DEZ_06" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_DEZ_06" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_DEZ_06" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_DEZ_6" runat="server" ControlToValidate="txt_DEZ_06" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    <br />
            <table  id="tbl_Cotas_07" style="border: 1px solid #C0C0C0; width: 100%;">
            <tr>
                <td class="auto-style3" colspan="12">
                    &nbsp;<b>Cota de Demanda em Unidade Equivalente - Linha de Produto </b> <asp:DropDownList ID="cmb_Tipo_Produto_07" runat="server" DataSourceID="dts_Tipo_Produto_07" DataTextField="PRODUTO_LINHA" DataValueField="COD_PRODUTO_LINHA" AutoPostBack="True" CssClass="auto-style9"></asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
                    <span class="auto-style10">(*Cotas de Demanda. Não utilizar ponto.</span>)</td>
            </tr>
            <tr class="auto-style4">
                <td class="auto-style5">01</td>
                <td class="auto-style5">02</td>
                <td class="auto-style5">03</td>
                <td class="auto-style5">04</td>
                <td class="auto-style5">05</td>
                <td class="auto-style5">06</td>
                <td class="auto-style5">07</td>
                <td class="auto-style5">08</td>
                <td class="auto-style5">09</td>
                <td class="auto-style5">10</td>
                <td class="auto-style5">11</td>
                <td class="auto-style5">12</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JAN_07" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JAN_07" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="99999999" Type="Double" ControlToValidate="txt_JAN_07" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_JAN_7" runat="server" ControlToValidate="txt_JAN_07" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_FEV_07" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_FEV_07" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_FEV_07" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_FEV_7" runat="server" ControlToValidate="txt_FEV_07" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAR_07" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAR_07" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_MAR_07" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_MAR_7" runat="server" ControlToValidate="txt_MAR_07" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_ABR_07" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_ABR_07" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_ABR_07" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_ABR_7" runat="server" ControlToValidate="txt_ABR_07" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAI_07" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAI_07" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_MAI_07" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_MAI_7" runat="server" ControlToValidate="txt_MAI_07" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUN_07" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUN_07" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_JUN_07" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_JUN_7" runat="server" ControlToValidate="txt_JUN_07" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUL_07" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUL_07" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_JUL_07" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_JUL_7" runat="server" ControlToValidate="txt_JUL_07" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_AGO_07" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_AGO_07" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_AGO_07" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_AGO_7" runat="server" ControlToValidate="txt_AGO_07" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_SET_07" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_SET_07" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_SET_07" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_SET_7" runat="server" ControlToValidate="txt_SET_07" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_OUT_07" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_OUT_07" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_OUT_07" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_OUT_7" runat="server" ControlToValidate="txt_OUT_07" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_NOV_07" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_NOV_07" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_NOV_07" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_NOV_7" runat="server" ControlToValidate="txt_NOV_07" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_DEZ_07" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_DEZ_07" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_DEZ_07" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_DEZ_7" runat="server" ControlToValidate="txt_DEZ_07" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    <br/>
        <table  id="tbl_Cotas_08" style="border: 1px solid #C0C0C0; width: 100%;">
            <tr>
                <td class="auto-style3" colspan="12">
                    &nbsp;<b>Cota de Demanda em Unidade Equivalente - Linha de Produto </b> <asp:DropDownList ID="cmb_Tipo_Produto_08" runat="server" DataSourceID="dts_Tipo_Produto_08" DataTextField="PRODUTO_LINHA" DataValueField="COD_PRODUTO_LINHA" AutoPostBack="True" CssClass="auto-style9"></asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
                    <span class="auto-style10">(*Cotas de Demanda. Não utilizar ponto.</span>)</td>
            </tr>
            <tr class="auto-style4">
                <td class="auto-style5">01</td>
                <td class="auto-style5">02</td>
                <td class="auto-style5">03</td>
                <td class="auto-style5">04</td>
                <td class="auto-style5">05</td>
                <td class="auto-style5">06</td>
                <td class="auto-style5">07</td>
                <td class="auto-style5">08</td>
                <td class="auto-style5">09</td>
                <td class="auto-style5">10</td>
                <td class="auto-style5">11</td>
                <td class="auto-style5">12</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JAN_08" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JAN_08" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="99999999" Type="Double" ControlToValidate="txt_JAN_08" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_JAN_8" runat="server" ControlToValidate="txt_JAN_08" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_FEV_08" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_FEV_08" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_FEV_08" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_FEV_8" runat="server" ControlToValidate="txt_FEV_08" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAR_08" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAR_08" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_MAR_08" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_MAR_8" runat="server" ControlToValidate="txt_MAR_08" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_ABR_08" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_ABR_08" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_ABR_08" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_ABR_8" runat="server" ControlToValidate="txt_ABR_08" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAI_08" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAI_08" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_MAI_08" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_MAI_8" runat="server" ControlToValidate="txt_MAI_08" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUN_08" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUN_08" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_JUN_08" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_JUN_8" runat="server" ControlToValidate="txt_JUN_08" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUL_08" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUL_08" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_JUL_08" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_JUL_8" runat="server" ControlToValidate="txt_JUL_08" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_AGO_08" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_AGO_08" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_AGO_08" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_AGO_8" runat="server" ControlToValidate="txt_AGO_08" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_SET_08" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_SET_08" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_SET_08" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_SET_8" runat="server" ControlToValidate="txt_SET_08" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_OUT_08" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_OUT_08" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_OUT_08" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_OUT_8" runat="server" ControlToValidate="txt_OUT_08" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_NOV_08" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_NOV_08" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_NOV_08" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_NOV_8" runat="server" ControlToValidate="txt_NOV_08" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_DEZ_08" runat="server" Width="90%" CssClass="text-center" Enabled="False"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_DEZ_08" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Double" ControlToValidate="txt_DEZ_08" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfv2_txt_DEZ_8" runat="server" ControlToValidate="txt_DEZ_08" Display="Dynamic" ErrorMessage="Preencha o Campo" style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    <br />
    <asp:Button Class="buton_gravar" ID="cmd_Gravar" runat="server" Text="Gravar" />
   </div>
        <asp:SqlDataSource ID="dts_Anos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT DISTINCT [ANO_FISCAL] FROM [VIEW_DATAS] WHERE ([ANO] = @ANO)">
            <SelectParameters>
                <asp:Parameter DefaultValue="2014" Name="ANO" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_Usuarios" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [tbl_USUARIOS] WHERE ([COD_PERFIL] = @COD_PERFIL) ORDER BY [NOME]">
            <SelectParameters>
                <asp:Parameter DefaultValue="4" Name="COD_PERFIL" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_Tipo_Produto_01" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_PRODUTOS_DIVISAO] WHERE ([COD_PRODUTO_DIVISAO] = @COD_PRODUTO_DIVISAO)">
            <SelectParameters>
                <asp:Parameter DefaultValue="9" Name="COD_PRODUTO_DIVISAO" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_Tipo_Produto_02" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_PRODUTOS_LINHAS] WHERE ([COD_PRODUTO_LINHA] = @COD_PRODUTO_LINHA)">
            <SelectParameters>
                <asp:Parameter DefaultValue="45" Name="COD_PRODUTO_LINHA" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_Tipo_Produto_03" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT [COD_PRODUTO_LINHA], [PRODUTO_LINHA] FROM [TBL_PRODUTOS_LINHAS] WHERE ([COD_PRODUTO_LINHA] = @COD_PRODUTO_LINHA)">
            <SelectParameters>
                <asp:Parameter DefaultValue="62" Name="COD_PRODUTO_LINHA" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_Tipo_Produto_04" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT [COD_PRODUTO_LINHA], [PRODUTO_LINHA] FROM [TBL_PRODUTOS_LINHAS] WHERE ([COD_PRODUTO_LINHA] = @COD_PRODUTO_LINHA)">
            <SelectParameters>
                <asp:Parameter DefaultValue="57" Name="COD_PRODUTO_LINHA" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_Tipo_Produto_05" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT  [COD_PRODUTO_LINHA], [PRODUTO_LINHA] FROM [TBL_PRODUTOS_LINHAS] WHERE ([COD_PRODUTO_LINHA] = @COD_PRODUTO_LINHA)">
            <SelectParameters>
                <asp:Parameter DefaultValue="47" Name="COD_PRODUTO_LINHA" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_Tipo_Produto_06" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT [COD_PRODUTO_LINHA], [PRODUTO_LINHA] FROM [TBL_PRODUTOS_LINHAS] WHERE ([COD_PRODUTO_LINHA] = @COD_PRODUTO_LINHA)">
            <SelectParameters>
                <asp:Parameter DefaultValue="50" Name="COD_PRODUTO_LINHA" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Tipo_Produto_07" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT [COD_PRODUTO_LINHA], [PRODUTO_LINHA] FROM [TBL_PRODUTOS_LINHAS] WHERE ([COD_PRODUTO_LINHA] = @COD_PRODUTO_LINHA)">
            <SelectParameters>
                <asp:Parameter DefaultValue="66" Name="COD_PRODUTO_LINHA" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_Tipo_Produto_08" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_PRODUTOS_LINHAS] WHERE ([COD_PRODUTO_LINHA] = @COD_PRODUTO_LINHA)">
            <SelectParameters>
                <asp:Parameter DefaultValue="45" Name="COD_PRODUTO_LINHA" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
</form>
</body>
</html>