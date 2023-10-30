<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Cotas_Editar.aspx.vb" Inherits="Cotas_Editar" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Manutenção de Cotas</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style2 {
            text-align: center;
        }
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
            height: 28px;
        }
        .auto-style6 {
            text-align: left;
        }
        .auto-style7 {
            color: #5A388C;
        }
        .text-center {
            text-align: center;
        }
    </style>
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">
        Manutenção de Cotas
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
                <td class="auto-style3" colspan="12">Linha de Produtos <asp:DropDownList ID="cmb_linha_Produtos_01" runat="server" DataSourceID="dts_Linha_Produto_01" DataTextField="LINHA" DataValueField="COD" AutoPostBack="True" style="font-weight: 700">
        </asp:DropDownList>
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
                <td class="auto-style2">
                    <asp:TextBox ID="txt_JAN_01" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False" ></asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txt_FEV_01" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txt_MAR_01" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txt_ABR_01" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txt_MAI_01" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txt_JUN_01" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txt_JUL_01" runat="server" CssClass="text-center" Width="90%"  TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txt_AGO_01" runat="server" CssClass="text-center" Width="90%"  TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txt_SET_01" runat="server" CssClass="text-center" Width="90%"  TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txt_OUT_01" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txt_NOV_01" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txt_DEZ_01" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table  id="tbl_Cotas_02" style="border: 1px solid #C0C0C0; width: 100%">
            <tr>
                <td class="auto-style6" colspan="12">Linha de Produtos <asp:DropDownList ID="cmb_linha_Produtos_02" runat="server" DataSourceID="dts_Linha_Produto_02" DataTextField="LINHA" DataValueField="COD" AutoPostBack="True">
        </asp:DropDownList>
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
                <td>
                    <asp:TextBox ID="txt_JAN_02" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_FEV_02" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_MAR_02" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_ABR_02" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_MAI_02" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_JUN_02" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_JUL_02" runat="server" CssClass="text-center" Width="90%"  TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_AGO_02" runat="server" CssClass="text-center" Width="90%"  TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_SET_02" runat="server" CssClass="text-center" Width="90%"  TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_OUT_02" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_NOV_02" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_DEZ_02" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <br />
            <table  id="tbl_Cotas_03" style="border: 1px solid #C0C0C0; width: 100%">
            <tr>
                <td colspan="12">Linha de Produtos <asp:DropDownList ID="cmb_linha_Produtos_03" runat="server" DataSourceID="dts_Linha_Produto_03" DataTextField="LINHA" DataValueField="COD" AutoPostBack="True">
        </asp:DropDownList>
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
                <td>
                    <asp:TextBox ID="txt_JAN_03" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_FEV_03" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_MAR_03" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_ABR_03" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_MAI_03" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_JUN_03" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_JUL_03" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_AGO_03" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_SET_03" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_OUT_03" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_NOV_03" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_DEZ_03" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
            </tr>
        </table>
        <!--
        <br />
        <br />

        <table  id="tbl_Cotas_04" style="border: 1px solid #C0C0C0; width: 100%">
            <tr>
                <td colspan="12">Linha de Produtos <asp:DropDownList ID="cmb_linha_Produtos_04" runat="server" DataSourceID="dts_Linha_Produto_04" DataTextField="LINHA" DataValueField="COD" AutoPostBack="True">
        </asp:DropDownList>
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
                <td>
                    <asp:TextBox ID="txt_JAN_04" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_FEV_04" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_MAR_04" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_ABR_04" runat="server" CssClass="text-center" Width="90%" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_MAI_04" runat="server" CssClass="text-center" Width="90%" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_JUN_04" runat="server" CssClass="text-center" Width="90%" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_JUL_04" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_AGO_04" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_SET_04" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_OUT_04" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_NOV_04" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_DEZ_04" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
            </tr>
        </table>
    -->
        <br />
        <br />
    <table  id="tbl_Cotas_05" style="border: 1px solid #C0C0C0; width: 100%">
            <tr>
                <td colspan="12">Linha de Produtos <asp:DropDownList ID="cmb_linha_Produtos_05" runat="server" DataSourceID="dts_Linha_Produto_05" DataTextField="LINHA" DataValueField="COD" AutoPostBack="True">
        </asp:DropDownList>
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
                <td>
                    <asp:TextBox ID="txt_JAN_05" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_FEV_05" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_MAR_05" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_ABR_05" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_MAI_05" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_JUN_05" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_JUL_05" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_AGO_05" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_SET_05" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_OUT_05" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_NOV_05" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txt_DEZ_05" runat="server" CssClass="text-center" Width="90%" TextMode="Number" Enabled="False"></asp:TextBox>
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
</form>
</body>
</html>
