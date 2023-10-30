<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Estabelecimentos_Cotas.aspx.vb" Inherits="Estabelecimentos_Cotas" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Cotas de Estabelecimento</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style3 {
            text-align: left;
            height: 28px;
        }
        .auto-style4 {
            color: #006bb7;
        }
        .auto-style5 {
            text-align: center;
            color: #006bb7;
        }
        .auto-style6 {
            color: #FF0000;
        }
        .auto-style7 {
            color: #5A388C;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style8 {
            text-align: center;
            width: 115px;
        }
        </style>
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">
        Cotas de Estabelecimento
        &nbsp;Ano&nbsp;<asp:DropDownList ID="cmb_Anos" runat="server" DataSourceID="dts_Anos" DataTextField="ANO_TEXTO" DataValueField="ANO_VALOR" AutoPostBack="True"></asp:DropDownList>
        &nbsp;<asp:RangeValidator ID="rfv_Anos" runat="server" ControlToValidate="cmb_Anos" CssClass="auto-style6" ErrorMessage="Selecione o Ano!" MaximumValue="9998" MinimumValue="1000"></asp:RangeValidator>
    </div>
    <div id ="Titulo_Pagina_Links">
        <a href="Estabelecimentos_Ficha.aspx?CNPJ=<%=Session("CNPJ")%>">Ficha do Estabelecimento</a>&nbsp;
    </div>
</div>    
<br />
<div id ="Corpo">
        <asp:FormView ID="frm_Estabelecimento_Ficha" runat="server" DataSourceID="dts_Estabelecimento" Width="100%">
            <EditItemTemplate></EditItemTemplate>
            <InsertItemTemplate></InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="ESTABELECIMENTOLabel" runat="server" Text='<%# Bind("ESTABELECIMENTO_CNPJ") %>' style="font-weight: 700"/>
                <br />
            </ItemTemplate>
       </asp:FormView>
    <br />
        <table  id="tbl_Cotas_01" style="border: 1px solid #C0C0C0; width: 100%">
            <tr>
                <td class="auto-style3" colspan="12">Linha de Produtos <asp:DropDownList ID="cmb_linha_Produtos_01" runat="server" DataSourceID="dts_Linha_Produto_01" DataTextField="LINHA" DataValueField="COD" AutoPostBack="True">
        </asp:DropDownList>
                    <span style="font-size: small">*Não utilizar virgula e ponto.</span>
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
                    <asp:TextBox ID="txt_JAN_01" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JAN_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="99999999" Type="Currency" ControlToValidate="txt_JAN_01" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_JAN_01" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_JAN_01" Display="Dynamic"></asp:RequiredFieldValidator> 
               </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_FEV_01" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_FEV_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_FEV_01" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_FEV_01" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_FEV_01" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAR_01" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAR_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_MAR_01" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_MAR_01" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_MAR_01" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_ABR_01" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_ABR_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_ABR_01" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_ABR_01" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_ABR_01" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAI_01" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAI_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_MAI_01" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_MAI_01" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_MAI_01" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUN_01" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUN_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_JUN_01" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_JUN_01" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_JUN_01" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUL_01" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUL_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_JUL_01" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_JUL_01" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_JUL_01" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_AGO_01" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_AGO_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_AGO_01" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_AGO_01" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_AGO_01" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_SET_01" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_SET_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_SET_01" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_SET_01" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_SET_01" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_OUT_01" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_OUT_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_OUT_01" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_OUT_01" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_OUT_01" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_NOV_01" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_NOV_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_NOV_01" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_NOV_01" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_NOV_01" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_DEZ_01" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_DEZ_01" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_DEZ_01" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_DEZ_01" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_DEZ_01" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table  id="tbl_Cotas_02" style="border: 1px solid #C0C0C0; width: 100%">
            <tr>
                <td colspan="12">Linha de Produtos <asp:DropDownList ID="cmb_linha_Produtos_02" runat="server" DataSourceID="dts_Linha_Produto_02" DataTextField="LINHA" DataValueField="COD" AutoPostBack="True">
        </asp:DropDownList>
                   <span style="font-size: small">*Não utilizar virgula e ponto.</span>
                </td>
            </tr>
            <tr class="auto-style7">
                <td class="auto-style2">JAN</td>
                <td class="auto-style2">FEV</td>
                <td class="auto-style2">MAR</td>
                <td class="auto-style2">ABR</td>
                <td class="auto-style2">MAI</td>
                <td class="auto-style8">JUN</td>
                <td class="auto-style2">JUL</td>
                <td class="auto-style2">AGO</td>
                <td class="auto-style2">SET</td>
                <td class="auto-style2">OUT</td>
                <td class="auto-style2">NOV</td>
                <td class="auto-style2">DEZ</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JAN_02" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JAN_02" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="99999999" Type="Currency" ControlToValidate="txt_JAN_02" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_JAN_02" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_JAN_02" Display="Dynamic"></asp:RequiredFieldValidator> 
               </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_FEV_02" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_FEV_02" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_FEV_02" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_FEV_02" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_FEV_02" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAR_02" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAR_02" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_MAR_02" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_MAR_02" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_MAR_02" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_ABR_02" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_ABR_02" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_ABR_02" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_ABR_02" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_ABR_02" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAI_02" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAI_02" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_MAI_02" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_MAI_02" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_MAI_02" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUN_02" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUN_02" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_JUN_02" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_JUN_02" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_JUN_02" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUL_02" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUL_02" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_JUL_02" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_JUL_02" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_JUL_02" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_AGO_02" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_AGO_02" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_AGO_02" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_AGO_02" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_AGO_02" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_SET_02" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_SET_02" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_SET_02" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_SET_02" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_SET_02" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_OUT_02" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_OUT_02" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_OUT_02" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_OUT_02" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_OUT_02" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_NOV_02" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_NOV_02" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_NOV_02" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_NOV_02" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_NOV_02" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_DEZ_02" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_DEZ_02" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_DEZ_02" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_DEZ_02" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_DEZ_02" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
            </tr>
        </table>
        <br />
        <br />
            <table  id="tbl_Cotas_03" style="border: 1px solid #C0C0C0; width: 100%">
            <tr>
                <td colspan="12">Linha de Produtos <asp:DropDownList ID="cmb_linha_Produtos_03" runat="server" DataSourceID="dts_Linha_Produto_03" DataTextField="LINHA" DataValueField="COD" AutoPostBack="True">
        </asp:DropDownList>
                    <span style="font-size: small">*Não utilizar virgula e ponto.</span>
                </td>
            </tr>
            <tr class="auto-style7">
                <td class="auto-style2">JAN</td>
                <td class="auto-style2">FEV</td>
                <td class="auto-style2">MAR</td>
                <td class="auto-style2">ABR</td>
                <td class="auto-style2">MAI</td>
                <td class="auto-style2">JUN</td>
                <td class="auto-style2">JUL</td>
                <td class="auto-style2">AGO</td>
                <td class="auto-style2">SET</td>
                <td class="auto-style2">OUT</td>
                <td class="auto-style2">NOV</td>
                <td class="auto-style2">DEZ</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JAN_03" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JAN_03" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="99999999" Type="Currency" ControlToValidate="txt_JAN_03" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_JAN_03" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_JAN_03" Display="Dynamic"></asp:RequiredFieldValidator> 
               </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_FEV_03" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_FEV_03" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_FEV_03" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_FEV_03" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_FEV_03" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAR_03" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAR_03" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_MAR_03" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_MAR_03" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_MAR_03" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_ABR_03" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_ABR_03" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_ABR_03" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_ABR_03" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_ABR_03" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAI_03" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAI_03" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_MAI_03" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_MAI_03" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_MAI_03" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUN_03" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUN_03" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_JUN_03" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_JUN_03" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_JUN_03" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUL_03" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUL_03" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_JUL_03" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_JUL_03" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_JUL_03" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_AGO_03" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_AGO_03" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_AGO_03" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_AGO_03" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_AGO_03" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_SET_03" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_SET_03" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_SET_03" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_SET_03" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_SET_03" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_OUT_03" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_OUT_03" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_OUT_03" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_OUT_03" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_OUT_03" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_NOV_03" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_NOV_03" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_NOV_03" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_NOV_03" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_NOV_03" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_DEZ_03" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_DEZ_03" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_DEZ_03" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_DEZ_03" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_DEZ_03" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
            </tr>
        </table>
        <br />
        <br />

        <table  id="tbl_Cotas_04" style="border: 1px solid #C0C0C0; width: 100%">
            <tr>
                <td colspan="12">Linha de Produtos <asp:DropDownList ID="cmb_linha_Produtos_04" runat="server" DataSourceID="dts_Linha_Produto_04" DataTextField="LINHA" DataValueField="COD" AutoPostBack="True">
        </asp:DropDownList>
                    <span style="font-size: small">*Não utilizar virgula e ponto.</span>
                </td>
            </tr>
            <tr class="auto-style7">
                <td class="auto-style2">JAN</td>
                <td class="auto-style2">FEV</td>
                <td class="auto-style2">MAR</td>
                <td class="auto-style2">ABR</td>
                <td class="auto-style2">MAI</td>
                <td class="auto-style2">JUN</td>
                <td class="auto-style2">JUL</td>
                <td class="auto-style2">AGO</td>
                <td class="auto-style2">SET</td>
                <td class="auto-style2">OUT</td>
                <td class="auto-style2">NOV</td>
                <td class="auto-style2">DEZ</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JAN_04" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JAN_04" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="99999999" Type="Currency" ControlToValidate="txt_JAN_04" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_JAN_04" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_JAN_04" Display="Dynamic"></asp:RequiredFieldValidator> 
               </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_FEV_04" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_FEV_04" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_FEV_04" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_FEV_04" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_FEV_04" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAR_04" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAR_04" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_MAR_04" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_MAR_04" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_MAR_04" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_ABR_04" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_ABR_04" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_ABR_04" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_ABR_04" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_ABR_04" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAI_04" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAI_04" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_MAI_04" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_MAI_04" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_MAI_04" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUN_04" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUN_04" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_JUN_04" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_JUN_04" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_JUN_04" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUL_04" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUL_04" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_JUL_04" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_JUL_04" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_JUL_04" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_AGO_04" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_AGO_04" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_AGO_04" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_AGO_04" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_AGO_04" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_SET_04" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_SET_04" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_SET_04" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_SET_04" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_SET_04" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_OUT_04" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_OUT_04" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_OUT_04" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_OUT_04" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_OUT_04" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_NOV_04" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_NOV_04" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_NOV_04" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_NOV_04" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_NOV_04" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_DEZ_04" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_DEZ_04" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_DEZ_04" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_DEZ_04" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_DEZ_04" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
            </tr>
        </table>
        <br />
        <br />
    <table  id="tbl_Cotas_05" style="border: 1px solid #C0C0C0; width: 100%">
            <tr>
                <td colspan="12">Linha de Produtos <asp:DropDownList ID="cmb_linha_Produtos_05" runat="server" DataSourceID="dts_Linha_Produto_05" DataTextField="LINHA" DataValueField="COD" AutoPostBack="True">
        </asp:DropDownList>
                    <span style="font-size: small">*Não utilizar virgula e ponto.</span>
                </td>
            </tr>
            <tr class="auto-style7">
                <td class="auto-style2">JAN</td>
                <td class="auto-style2">FEV</td>
                <td class="auto-style2">MAR</td>
                <td class="auto-style2">ABR</td>
                <td class="auto-style2">MAI</td>
                <td class="auto-style2">JUN</td>
                <td class="auto-style2">JUL</td>
                <td class="auto-style2">AGO</td>
                <td class="auto-style2">SET</td>
                <td class="auto-style2">OUT</td>
                <td class="auto-style2">NOV</td>
                <td class="auto-style2">DEZ</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JAN_05" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JAN_05" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="99999999" Type="Currency" ControlToValidate="txt_JAN_05" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_JAN_05" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_JAN_05" Display="Dynamic"></asp:RequiredFieldValidator> 
               </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_FEV_05" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_FEV_05" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_FEV_05" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_FEV_05" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_FEV_05" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAR_05" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAR_05" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_MAR_05" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_MAR_05" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_MAR_05" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_ABR_05" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_ABR_05" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_ABR_05" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_ABR_05" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_ABR_05" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_MAI_05" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_MAI_05" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_MAI_05" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_MAI_05" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_MAI_05" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUN_05" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUN_05" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_JUN_05" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_JUN_05" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_JUN_05" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_JUL_05" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_JUL_05" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_JUL_05" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_JUL_05" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_JUL_05" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_AGO_05" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_AGO_05" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_AGO_05" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_AGO_05" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_AGO_05" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_SET_05" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_SET_05" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_SET_05" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_SET_05" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_SET_05" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_OUT_05" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_OUT_05" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_OUT_05" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_OUT_05" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_OUT_05" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_NOV_05" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_NOV_05" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_NOV_05" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_NOV_05" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_NOV_05" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txt_DEZ_05" runat="server" Width="90%" CssClass="text-center" style="text-align: center" TextMode="Number"></asp:TextBox>
                    <asp:RangeValidator ID="rfv_txt_DEZ_05" runat="server" ErrorMessage="Valor Invalido" MinimumValue="0" MaximumValue="999999" Type="Currency" ControlToValidate="txt_DEZ_05" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="rqfv_txt_DEZ_05" runat="server" ErrorMessage="Preencha o Campo" ControlToValidate="txt_DEZ_05" Display="Dynamic"></asp:RequiredFieldValidator> 
                </td>
            </tr>
        </table>
        <br />
        <br />
    <asp:Button Class="buton_gravar" ID="cmd_Gravar" runat="server" Text="Gravar" />
   </div>
        <asp:SqlDataSource ID="dts_Anos" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            SelectCommand="SELECT '9999' as ANO_VALOR, '@ Selecione' as ANO_TEXTO UNION ALL SELECT ANO_VALOR, ANO_TEXTO FROM [tbl_DATAS_ANOS] WHERE ([ANO_FECHADO_COTAS] = @ANO_FECHADO_COTAS) ORDER BY [ANO_VALOR] DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="False" Name="ANO_FECHADO_COTAS" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_Linha_Produto_01" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [tbl_PRODUTOS_LINHAS] WHERE (([COTA] = @COTA) AND ([COD] = @COD)) ORDER BY [LINHA]">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="COTA" Type="Boolean" />
                <asp:Parameter DefaultValue="1" Name="COD" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_Linha_Produto_02" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [tbl_PRODUTOS_LINHAS] WHERE (([COTA] = @COTA) AND ([COD] = @COD)) ORDER BY [LINHA]">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="COTA" Type="Boolean" />
                <asp:Parameter DefaultValue="2" Name="COD" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Linha_Produto_03" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [tbl_PRODUTOS_LINHAS] WHERE (([COTA] = @COTA) AND ([COD] = @COD)) ORDER BY [LINHA]">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="COTA" Type="Boolean" />
                <asp:Parameter DefaultValue="3" Name="COD" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_Linha_Produto_04" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [tbl_PRODUTOS_LINHAS] WHERE (([COTA] = @COTA) AND ([COD] = @COD)) ORDER BY [LINHA]">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="COTA" Type="Boolean" />
                <asp:Parameter DefaultValue="5" Name="COD" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
                <asp:SqlDataSource ID="dts_Linha_Produto_05" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [tbl_PRODUTOS_LINHAS] WHERE (([COTA] = @COTA) AND ([COD] = @COD)) ORDER BY [LINHA]">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="COTA" Type="Boolean" />
                <asp:Parameter DefaultValue="16" Name="COD" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_Estabelecimento" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS_001_DETALHADO] WHERE ([CNPJ] = @CNPJ)">
            <SelectParameters>
                <asp:QueryStringParameter Name="CNPJ" QueryStringField="CNPJ" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
</form>
</body>
</html>