<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Upload.aspx.vb" Inherits="Upload" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Upload de Arquivos</title>
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
    <div id ="Titulo_Pagina_Cabecalho">Upload de Arquivos</div>
    <div id ="Titulo_Pagina_Links"></div>
</div>    
<div id ="Corpo">
    <asp:Label ID="lbl_raiz" runat="server" style="font-weight: 700" Text="Nenhuma Pasta Selecionada" Visible="False"></asp:Label>
    <br/>
    <table width="100%" >
        <tr>
            <td width="20%" style="vertical-align: top;">
                <asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer" NodeIndent="15">
                    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                    <Nodes>
                        <asp:TreeNode Text="Arquivos" Value="Arquivos" Expanded="False">
                            <asp:TreeNode Expanded="False" Text="Bombas" Value="Arquivos\Bombas">
                                <asp:TreeNode Text="2008" Value="Arquivos\Bombas\2008"></asp:TreeNode>
                                <asp:TreeNode Text="2009" Value="Arquivos\Bombas\2009"></asp:TreeNode>
                                <asp:TreeNode Text="2010" Value="Arquivos\Bombas\2010"></asp:TreeNode>
                                <asp:TreeNode Text="2011" Value="Arquivos\Bombas\2011"></asp:TreeNode>
                                <asp:TreeNode Text="2012" Value="Arquivos\Bombas\2012"></asp:TreeNode>
                                <asp:TreeNode Text="2013" Value="Arquivos\Bombas\2013"></asp:TreeNode>
                                <asp:TreeNode Text="2014" Value="Arquivos\Bombas\2014"></asp:TreeNode>
                                <asp:TreeNode Text="2015" Value="Arquivos\Bombas\2015"></asp:TreeNode>
                                <asp:TreeNode Text="Bombas" Value="Arquivos\Bombas\Bombas"></asp:TreeNode>
                            </asp:TreeNode>
                            <asp:TreeNode Expanded="False" Text="Mapas" Value="Arquivos\Mapas">
                                <asp:TreeNode Expanded="False" Text="Bombas" Value="Arquivos\Mapas\Bombas">
                                    <asp:TreeNode Expanded="False" Text="2012" Value="Arquivos\Mapas\Bombas\2012">
                                        <asp:TreeNode Expanded="False" Text="201207" Value="Arquivos\Mapas\Bombas\2012\201207"></asp:TreeNode>
                                        <asp:TreeNode Expanded="False" Text="201208" Value="Arquivos\Mapas\Bombas\2012\201208"></asp:TreeNode>
                                        <asp:TreeNode Expanded="False" Text="201211" Value="Arquivos\Mapas\Bombas\2012\201211"></asp:TreeNode>
                                    </asp:TreeNode>
                                    <asp:TreeNode Expanded="False" Text="2013" Value="Arquivos\Mapas\Bombas\2013"></asp:TreeNode>
                                    <asp:TreeNode Expanded="False" Text="2014" Value="Arquivos\Mapas\Bombas\2014"></asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode Expanded="False" Text="Cotas" Value="Arquivos\Mapas\Cotas">
                                    <asp:TreeNode Expanded="False" Text="2012" Value="Arquivos\Mapas\Cotas\2012"></asp:TreeNode>
                                    <asp:TreeNode Expanded="False" Text="2013" Value="Arquivos\Mapas\Cotas\2013"></asp:TreeNode>
                                    <asp:TreeNode Expanded="False" Text="2014" Value="Arquivos\Mapas\Cotas\2014"></asp:TreeNode>
                                    <asp:TreeNode Expanded="False" Text="2015" Value="Arquivos\Mapas\Cotas\2015"></asp:TreeNode>
                                    <asp:TreeNode Expanded="False" Text="2016" Value="Arquivos\Mapas\Cotas\2016"></asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode Expanded="False" Text="Demanda" Value="Arquivos\Mapas\Demanda">
                                    <asp:TreeNode Text="2012" Value="Arquivos\Mapas\Demanda\2012" Expanded="False">
                                        <asp:TreeNode Expanded="False" Text="201201" Value="Arquivos\Mapas\Demanda\2012\201201"></asp:TreeNode>
                                        <asp:TreeNode Expanded="False" Text="201202" Value="Arquivos\Mapas\Demanda\2012\201202"></asp:TreeNode>
                                        <asp:TreeNode Expanded="False" Text="201203" Value="Arquivos\Mapas\Demanda\2012\201203"></asp:TreeNode>
                                        <asp:TreeNode Expanded="False" Text="201204" Value="Arquivos\Mapas\Demanda\2012\201204"></asp:TreeNode>
                                        <asp:TreeNode Expanded="False" Text="201205" Value="Arquivos\Mapas\Demanda\2012\201205"></asp:TreeNode>
                                        <asp:TreeNode Expanded="False" Text="201206" Value="Arquivos\Mapas\Demanda\2012\201206"></asp:TreeNode>
                                        <asp:TreeNode Expanded="False" Text="201207" Value="Arquivos\Mapas\Demanda\2012\201207"></asp:TreeNode>
                                        <asp:TreeNode Expanded="False" Text="201208" Value="Arquivos\Mapas\Demanda\2012\201208"></asp:TreeNode>
                                        <asp:TreeNode Expanded="False" Text="201209" Value="Arquivos\Mapas\Demanda\2012\201209"></asp:TreeNode>
                                        <asp:TreeNode Expanded="False" Text="201210" Value="Arquivos\Mapas\Demanda\2012\201210"></asp:TreeNode>
                                        <asp:TreeNode Expanded="False" Text="201211" Value="Arquivos\Mapas\Demanda\2012\201211"></asp:TreeNode>
                                        <asp:TreeNode Expanded="False" Text="201212" Value="Arquivos\Mapas\Demanda\2012\201212"></asp:TreeNode>
                                    </asp:TreeNode>
                                    <asp:TreeNode Text="2013" Value="Arquivos\Mapas\Demanda\2013" Expanded="False">
                                        <asp:TreeNode Text="201301" Value="Arquivos\Mapas\Demanda\2013\201301"></asp:TreeNode>
                                        <asp:TreeNode Text="201302" Value="Arquivos\Mapas\Demanda\2013\201302"></asp:TreeNode>
                                        <asp:TreeNode Text="201303" Value="Arquivos\Mapas\Demanda\2013\201303"></asp:TreeNode>
                                        <asp:TreeNode Text="201304" Value="Arquivos\Mapas\Demanda\2013\201304"></asp:TreeNode>
                                        <asp:TreeNode Text="201305" Value="Arquivos\Mapas\Demanda\2013\201305"></asp:TreeNode>
                                        <asp:TreeNode Text="201306" Value="Arquivos\Mapas\Demanda\2013\201306"></asp:TreeNode>
                                        <asp:TreeNode Text="201307" Value="Arquivos\Mapas\Demanda\2013\201307"></asp:TreeNode>
                                        <asp:TreeNode Text="201308" Value="Arquivos\Mapas\Demanda\2013\201308"></asp:TreeNode>
                                        <asp:TreeNode Text="201309" Value="Arquivos\Mapas\Demanda\2013\201309"></asp:TreeNode>
                                        <asp:TreeNode Text="201310" Value="Arquivos\Mapas\Demanda\2013\201310"></asp:TreeNode>
                                        <asp:TreeNode Text="201311" Value="Arquivos\Mapas\Demanda\2013\201311"></asp:TreeNode>
                                        <asp:TreeNode Text="201312" Value="Arquivos\Mapas\Demanda\2013\201312"></asp:TreeNode>
                                    </asp:TreeNode>
                                    <asp:TreeNode Text="2014" Value="Arquivos\Mapas\Demanda\2014" Expanded="False">
                                        <asp:TreeNode Text="201401" Value="Arquivos\Mapas\Demanda\2014\201401"></asp:TreeNode>
                                        <asp:TreeNode Text="201402" Value="Arquivos\Mapas\Demanda\2014\201402"></asp:TreeNode>
                                        <asp:TreeNode Text="201403" Value="Arquivos\Mapas\Demanda\2014\201403"></asp:TreeNode>
                                        <asp:TreeNode Text="201404" Value="Arquivos\Mapas\Demanda\2014\201404"></asp:TreeNode>
                                        <asp:TreeNode Text="201405" Value="Arquivos\Mapas\Demanda\2014\201405"></asp:TreeNode>
                                        <asp:TreeNode Text="201406" Value="Arquivos\Mapas\Demanda\2014\201406"></asp:TreeNode>
                                        <asp:TreeNode Text="201407" Value="Arquivos\Mapas\Demanda\2014\201407"></asp:TreeNode>
                                        <asp:TreeNode Text="201408" Value="Arquivos\Mapas\Demanda\2014\201408"></asp:TreeNode>
                                        <asp:TreeNode Text="201409" Value="Arquivos\Mapas\Demanda\2014\201409"></asp:TreeNode>
                                        <asp:TreeNode Text="201410" Value="Arquivos\Mapas\Demanda\2014\201410"></asp:TreeNode>
                                        <asp:TreeNode Text="201411" Value="Arquivos\Mapas\Demanda\2014\201411"></asp:TreeNode>
                                        <asp:TreeNode Text="201412" Value="Arquivos\Mapas\Demanda\2014\201412"></asp:TreeNode>
                                    </asp:TreeNode>
                                    <asp:TreeNode Text="2015" Value="Arquivos\Mapas\Demanda\2015" Expanded="False">
                                        <asp:TreeNode Text="201501" Value="Arquivos\Mapas\Demanda\2015\201501"></asp:TreeNode>
                                        <asp:TreeNode Text="201502" Value="Arquivos\Mapas\Demanda\2015\201502"></asp:TreeNode>
                                        <asp:TreeNode Text="201503" Value="Arquivos\Mapas\Demanda\2015\201503"></asp:TreeNode>
                                        <asp:TreeNode Text="201504" Value="Arquivos\Mapas\Demanda\2015\201504"></asp:TreeNode>
                                        <asp:TreeNode Text="201505" Value="Arquivos\Mapas\Demanda\2015\201505"></asp:TreeNode>
                                        <asp:TreeNode Text="201506" Value="Arquivos\Mapas\Demanda\2015\201506"></asp:TreeNode>
                                        <asp:TreeNode Text="201507" Value="Arquivos\Mapas\Demanda\2015\201507"></asp:TreeNode>
                                        <asp:TreeNode Text="201508" Value="Arquivos\Mapas\Demanda\2015\201508"></asp:TreeNode>
                                        <asp:TreeNode Text="201509" Value="Arquivos\Mapas\Demanda\2015\201509"></asp:TreeNode>
                                        <asp:TreeNode Text="201510" Value="Arquivos\Mapas\Demanda\2015\201510"></asp:TreeNode>
                                        <asp:TreeNode Text="201511" Value="Arquivos\Mapas\Demanda\2015\201511"></asp:TreeNode>
                                        <asp:TreeNode Text="201512" Value="Arquivos\Mapas\Demanda\2015\201512"></asp:TreeNode>
                                    </asp:TreeNode>
                                    <asp:TreeNode Text="2016" Value="Arquivos\Mapas\Demanda\2016" Expanded="False">
                                        <asp:TreeNode Text="201601" Value="Arquivos\Mapas\Demanda\2016\201601"></asp:TreeNode>
                                        <asp:TreeNode Text="201602" Value="Arquivos\Mapas\Demanda\2016\201602"></asp:TreeNode>
                                        <asp:TreeNode Text="201603" Value="Arquivos\Mapas\Demanda\2016\201603"></asp:TreeNode>
                                        <asp:TreeNode Text="201604" Value="Arquivos\Mapas\Demanda\2016\201604"></asp:TreeNode>
                                        <asp:TreeNode Text="201605" Value="Arquivos\Mapas\Demanda\2016\201605"></asp:TreeNode>
                                        <asp:TreeNode Text="201606" Value="Arquivos\Mapas\Demanda\2016\201606"></asp:TreeNode>
                                        <asp:TreeNode Text="201607" Value="Arquivos\Mapas\Demanda\2016\201607"></asp:TreeNode>
                                        <asp:TreeNode Text="201608" Value="Arquivos\Mapas\Demanda\2016\201608"></asp:TreeNode>
                                        <asp:TreeNode Text="201609" Value="Arquivos\Mapas\Demanda\2016\201609"></asp:TreeNode>
                                        <asp:TreeNode Text="201610" Value="Arquivos\Mapas\Demanda\2016\201610"></asp:TreeNode>
                                        <asp:TreeNode Text="201611" Value="Arquivos\Mapas\Demanda\2016\201611"></asp:TreeNode>
                                        <asp:TreeNode Text="201612" Value="Arquivos\Mapas\Demanda\2016\201612"></asp:TreeNode>
                                    </asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode Expanded="False" Text="Estoque" Value="Arquivos\Mapas\Estoque">
                                    <asp:TreeNode Expanded="False" Text="2012" Value="Arquivos\Mapas\Estoque\2012">
                                        <asp:TreeNode Text="201207" Value="Arquivos\Mapas\Estoque\2012\201207"></asp:TreeNode>
                                        <asp:TreeNode Text="201208" Value="Arquivos\Mapas\Estoque\2012\201208"></asp:TreeNode>
                                        <asp:TreeNode Text="201209" Value="Arquivos\Mapas\Estoque\2012\201209"></asp:TreeNode>
                                        <asp:TreeNode Text="201210" Value="Arquivos\Mapas\Estoque\2012\201210"></asp:TreeNode>
                                        <asp:TreeNode Text="201211" Value="Arquivos\Mapas\Estoque\2012\201211"></asp:TreeNode>
                                        <asp:TreeNode Text="201212" Value="Arquivos\Mapas\Estoque\2012\201212"></asp:TreeNode>
                                    </asp:TreeNode>
                                    <asp:TreeNode Expanded="False" Text="2013" Value="Arquivos\Mapas\Estoque\2013">
                                        <asp:TreeNode Text="201301" Value="Arquivos\Mapas\Estoque\2013\201301"></asp:TreeNode>
                                        <asp:TreeNode Text="201302" Value="Arquivos\Mapas\Estoque\2013\201302"></asp:TreeNode>
                                        <asp:TreeNode Text="201303" Value="Arquivos\Mapas\Estoque\2013\201303"></asp:TreeNode>
                                        <asp:TreeNode Text="201304" Value="Arquivos\Mapas\Estoque\2013\201304"></asp:TreeNode>
                                        <asp:TreeNode Text="201305" Value="Arquivos\Mapas\Estoque\2013\201305"></asp:TreeNode>
                                        <asp:TreeNode Text="201306" Value="Arquivos\Mapas\Estoque\2013\201306"></asp:TreeNode>
                                        <asp:TreeNode Text="201307" Value="Arquivos\Mapas\Estoque\2013\201307"></asp:TreeNode>
                                        <asp:TreeNode Text="201308" Value="201308"></asp:TreeNode>
                                        <asp:TreeNode Text="201309" Value="Arquivos\Mapas\Estoque\2013\201309"></asp:TreeNode>
                                        <asp:TreeNode Text="201310" Value="Arquivos\Mapas\Estoque\2013\201310"></asp:TreeNode>
                                        <asp:TreeNode Text="201311" Value="Arquivos\Mapas\Estoque\2013\201311"></asp:TreeNode>
                                        <asp:TreeNode Text="201312" Value="Arquivos\Mapas\Estoque\2013\201312"></asp:TreeNode>
                                    </asp:TreeNode>
                                    <asp:TreeNode Expanded="False" Text="2014" Value="Arquivos\Mapas\Estoque\2014">
                                        <asp:TreeNode Text="201401" Value="Arquivos\Mapas\Estoque\2014\201401"></asp:TreeNode>
                                        <asp:TreeNode Text="201402" Value="Arquivos\Mapas\Estoque\2014\201402"></asp:TreeNode>
                                        <asp:TreeNode Text="201403" Value="Arquivos\Mapas\Estoque\2014\201403"></asp:TreeNode>
                                        <asp:TreeNode Text="201404" Value="Arquivos\Mapas\Estoque\2014\201404"></asp:TreeNode>
                                        <asp:TreeNode Text="201405" Value="Arquivos\Mapas\Estoque\2014\201405"></asp:TreeNode>
                                        <asp:TreeNode Text="201406" Value="Arquivos\Mapas\Estoque\2014\201406"></asp:TreeNode>
                                        <asp:TreeNode Text="201407" Value="Arquivos\Mapas\Estoque\2014\201407"></asp:TreeNode>
                                        <asp:TreeNode Text="201408" Value="Arquivos\Mapas\Estoque\2014\201408"></asp:TreeNode>
                                        <asp:TreeNode Text="201409" Value="Arquivos\Mapas\Estoque\2014\201409"></asp:TreeNode>
                                        <asp:TreeNode Text="201410" Value="Arquivos\Mapas\Estoque\2014\201410"></asp:TreeNode>
                                        <asp:TreeNode Text="201411" Value="Arquivos\Mapas\Estoque\2014\201411"></asp:TreeNode>
                                        <asp:TreeNode Text="201412" Value="Arquivos\Mapas\Estoque\2014\201412"></asp:TreeNode>
                                    </asp:TreeNode>
                                    <asp:TreeNode Expanded="False" Text="2015" Value="Arquivos\Mapas\Estoque\2015">
                                        <asp:TreeNode Text="201501" Value="Arquivos\Mapas\Estoque\2015\201501"></asp:TreeNode>
                                        <asp:TreeNode Text="201502" Value="Arquivos\Mapas\Estoque\2015\201502"></asp:TreeNode>
                                        <asp:TreeNode Text="201503" Value="Arquivos\Mapas\Estoque\2015\201503"></asp:TreeNode>
                                        <asp:TreeNode Text="201504" Value="Arquivos\Mapas\Estoque\2015\201504"></asp:TreeNode>
                                        <asp:TreeNode Text="201505" Value="Arquivos\Mapas\Estoque\2015\201505"></asp:TreeNode>
                                        <asp:TreeNode Text="201506" Value="Arquivos\Mapas\Estoque\2015\201506"></asp:TreeNode>
                                        <asp:TreeNode Text="201507" Value="Arquivos\Mapas\Estoque\2015\201507"></asp:TreeNode>
                                        <asp:TreeNode Text="201508" Value="Arquivos\Mapas\Estoque\2015\201508"></asp:TreeNode>
                                        <asp:TreeNode Text="201509" Value="Arquivos\Mapas\Estoque\2015\201509"></asp:TreeNode>
                                        <asp:TreeNode Text="201510" Value="Arquivos\Mapas\Estoque\2015\201510"></asp:TreeNode>
                                        <asp:TreeNode Text="201511" Value="Arquivos\Mapas\Estoque\2015\201511"></asp:TreeNode>
                                        <asp:TreeNode Text="201512" Value="Arquivos\Mapas\Estoque\2015\201512"></asp:TreeNode>
                                    </asp:TreeNode>
                                    <asp:TreeNode Expanded="False" Text="2016" Value="Arquivos\Mapas\Estoque\2016">
                                        <asp:TreeNode Text="201601" Value="Arquivos\Mapas\Estoque\2016\201601"></asp:TreeNode>
                                        <asp:TreeNode Text="201602" Value="Arquivos\Mapas\Estoque\2016\201602"></asp:TreeNode>
                                        <asp:TreeNode Text="201603" Value="Arquivos\Mapas\Estoque\2016\201603"></asp:TreeNode>
                                        <asp:TreeNode Text="201604" Value="Arquivos\Mapas\Estoque\2016\201604"></asp:TreeNode>
                                        <asp:TreeNode Text="201605" Value="Arquivos\Mapas\Estoque\2016\201605"></asp:TreeNode>
                                        <asp:TreeNode Text="201606" Value="Arquivos\Mapas\Estoque\2016\201606"></asp:TreeNode>
                                        <asp:TreeNode Text="201607" Value="Arquivos\Mapas\Estoque\2016\201607"></asp:TreeNode>
                                        <asp:TreeNode Text="201608" Value="Arquivos\Mapas\Estoque\2016\201608"></asp:TreeNode>
                                        <asp:TreeNode Text="201609" Value="Arquivos\Mapas\Estoque\2016\201609"></asp:TreeNode>
                                        <asp:TreeNode Text="201610" Value="Arquivos\Mapas\Estoque\2016\201610"></asp:TreeNode>
                                        <asp:TreeNode Text="201611" Value="Arquivos\Mapas\Estoque\2016\201611"></asp:TreeNode>
                                        <asp:TreeNode Text="201612" Value="Arquivos\Mapas\Estoque\2016\201612"></asp:TreeNode>
                                    </asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode Text="Venda" Value="Arquivos\Mapas\Venda" Expanded="False">
                                    <asp:TreeNode Text="2014" Value="Arquivos\Mapas\Venda\2014"></asp:TreeNode>
                                    <asp:TreeNode Text="2015" Value="Arquivos\Mapas\Venda\2015"></asp:TreeNode>
                                    <asp:TreeNode Text="2016" Value="Arquivos\Mapas\Venda\2016"></asp:TreeNode>
                                </asp:TreeNode>
                            </asp:TreeNode>
                            <asp:TreeNode Text="Master Report" Value="Arquivos\Master Report" Expanded="False">
                                <asp:TreeNode Text="2013" Value="Arquivos\Master Report\2013"></asp:TreeNode>
                                <asp:TreeNode Text="2014" Value="Arquivos\Master Report\2014"></asp:TreeNode>
                            </asp:TreeNode>
                            <asp:TreeNode Text="Relatorios" Value="Arquivos\Relatorios" Expanded="False">
                                <asp:TreeNode Text="2013" Value="Arquivos\Relatorios\2013" Expanded="False"></asp:TreeNode>
                                <asp:TreeNode Text="2014" Value="Arquivos\Relatorios\2014"></asp:TreeNode>
                                <asp:TreeNode Text="2015" Value="Arquivos\Relatorios\2015"></asp:TreeNode>
                                <asp:TreeNode Text="2016" Value="Arquivos\Relatorios\2016"></asp:TreeNode>
                                <asp:TreeNode Text="Estoque" Value="Arquivos\Relatorios\Estoque" Expanded="False">
                                    <asp:TreeNode Text="2014" Value="Arquivos\Relatorios\Estoque\2014"></asp:TreeNode>
                                    <asp:TreeNode Text="2015" Value="Arquivos\Relatorios\Estoque\2015"></asp:TreeNode>
                                    <asp:TreeNode Text="2016" Value="Arquivos\Relatorios\Estoque\2016"></asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode Text="Sales Price" Value="Arquivos\Relatorios\Sales Price" Expanded="False">
                                    <asp:TreeNode Text="Mapas" Value="Arquivos\Relatorios\Sales Price\Mapas"></asp:TreeNode>
                                </asp:TreeNode>
                            </asp:TreeNode>
                            <asp:TreeNode Expanded="False" Text="Recursos Humanos" Value="Recursos Humanos">
                                <asp:TreeNode Text="Apresentação IV" Value="Arquivos\Recursos Humanos\Apresentação IV"></asp:TreeNode>
                                <asp:TreeNode Text="Calculo incentivo GEMDEX " Value="Arquivos\Recursos Humanos\Calculo incentivo GEMDEX ">
                                    <asp:TreeNode Text="2013" Value="Arquivos\Recursos Humanos\Calculo incentivo GEMDEX\2013"></asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode Text="Calculo incentivo MMS" Value="Arquivos\Recursos Humanos\Calculo incentivo MMS">
                                    <asp:TreeNode Text="2012" Value="Arquivos\Recursos Humanos\Calculo incentivo MMS\2012">
                                        <asp:TreeNode Text="1ºTrimestre" Value="Arquivos\Recursos Humanos\Calculo incentivo MMS\2012\1ºTrimestre"></asp:TreeNode>
                                        <asp:TreeNode Text="2º Trimestre" Value="Arquivos\Recursos Humanos\Calculo incentivo MMS\2012\2º Trimestre"></asp:TreeNode>
                                        <asp:TreeNode Text="3° Trimestre" Value="Arquivos\Recursos Humanos\Calculo incentivo MMS\2012\3° Trimestre"></asp:TreeNode>
                                        <asp:TreeNode Text="4º Trimestre" Value="Arquivos\Recursos Humanos\Calculo incentivo MMS\2012\4º Trimestre"></asp:TreeNode>
                                    </asp:TreeNode>
                                    <asp:TreeNode Text="2013" Value="Arquivos\Recursos Humanos\Calculo incentivo MMS\2013">
                                        <asp:TreeNode Text="1º Trimestre" Value="Arquivos\Recursos Humanos\Calculo incentivo MMS\2013\1º Trimestre"></asp:TreeNode>
                                        <asp:TreeNode Text="2º Trimestre" Value="Arquivos\Recursos Humanos\Calculo incentivo MMS\2013\2º Trimestre"></asp:TreeNode>
                                        <asp:TreeNode Text="3° Trimestre" Value="Arquivos\Recursos Humanos\Calculo incentivo MMS\2013\3° Trimestre"></asp:TreeNode>
                                        <asp:TreeNode Text="4º Trimestre" Value="Arquivos\Recursos Humanos\Calculo incentivo MMS\2013\4º Trimestre"></asp:TreeNode>
                                    </asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode Text="Performance IV" Value="Arquivos\Recursos Humanos\Performance IV">
                                    <asp:TreeNode Text="2014" Value="Arquivos\Recursos Humanos\Performance IV\2014"></asp:TreeNode>
                                    <asp:TreeNode Text="2015" Value="Arquivos\Recursos Humanos\Performance IV\2015"></asp:TreeNode>
                                    <asp:TreeNode Text="2016" Value="Arquivos\Recursos Humanos\Performance IV\2016"></asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode Text="Planilha BDO" Value="Arquivos\Recursos Humanos\Planilha BDO"></asp:TreeNode>
                            </asp:TreeNode>
                            <asp:TreeNode Expanded="False" Text="Sales Force" Value="Arquivos\Sales Force">
                                <asp:TreeNode Text="Connections" Value="Arquivos\Sales Force\Connections"></asp:TreeNode>
                                <asp:TreeNode Text="Implantação" Value="Arquivos\Sales Force\Implantação">
                                    <asp:TreeNode Text="HSP_CLIENTES_201403_arquivos" Value="Arquivos\Sales Force\Implantação\HSP_CLIENTES_201403_arquivos"></asp:TreeNode>
                                </asp:TreeNode>
                            </asp:TreeNode>
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
