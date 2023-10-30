<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Menu_sistema.aspx.vb" Inherits="Menu_sistema" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menu de Sistema</title>
    
    <style type="text/css">
        .auto-style2 {
            font-size: x-large;
        }
    </style>
    
</head>
<uc1:Cabecalho runat="server" ID="Cabecalho" />
<body>
    <form id="form1" runat="server">
<div id ="Corpo">

    <h3><asp:HyperLink ID="lnk_Estoque_12meses_Produto_Distribuidor" runat="server" CssClass="link_submenu" NavigateUrl="~/rpt_Estoque_12meses_Produto_Distribuidor.aspx">Estoque 12 meses Produto Distribuidor</asp:HyperLink></h3>
    <div class="subtitulo">EM TESTE</div>

    <!--<h3><asp:HyperLink ID="lnk_Estoque_12meses_Distribuidor_Produto" runat="server" CssClass="link_submenu" NavigateUrl="~/rpt_Estoque_12meses_Distribuidor_Produto.aspx">Estoque 12 meses Distribuidor Produto</asp:HyperLink></h3>
    <div class="subtitulo">EM TESTE</div>-->

    <h3><asp:HyperLink ID="lnk_Usuarios_Localizacao" runat="server" NavigateUrl="~/Usuarios_Localizacao.aspx" CssClass="link_submenu">Administrar Usuários</asp:HyperLink></h3>
    <div class="subtitulo">Incluir, alterar, inativar as pessoas autorizadasa utilizar o sistema</div>

    <h3><asp:HyperLink ID="Estabelecimentos_Pesquisa_RF" runat="server" NavigateUrl="~/Estabelecimentos_Pesquisa_RF.aspx" CssClass="link_submenu">Incluir novo cliente</asp:HyperLink></h3>
    <div class="subtitulo"></div>

    <h3><asp:HyperLink ID="lnk_Download_Sistema" runat="server" CssClass="link_submenu" NavigateUrl="~/Download_Sistema.aspx">Download de Arquivos de Sistema</asp:HyperLink></h3>
    <div class="subtitulo">Página para download de arquivos (Mapas/Relatórios/etc).</div>

    <h3><asp:HyperLink ID="lnk_Upload_Sistema" runat="server" CssClass="link_submenu" NavigateUrl="~/Upload_Sistema.aspx">Upload de Arquivos de Sistema</asp:HyperLink></h3>
    <div class="subtitulo">Página para upload de arquivos de Sistema</div>
    
    <h3><asp:HyperLink ID="lnk_Upload_Mapas" runat="server" CssClass="link_submenu" NavigateUrl="~/Upload_Mapas.aspx">Upload de Mapas</asp:HyperLink></h3>
    <div class="subtitulo">Página para Upload dos Mapas de Demanda/Estoque/Venda </div>

    <h3><asp:HyperLink ID="lnk_Upload" runat="server" CssClass="link_submenu" NavigateUrl="~/Upload.aspx">Upload de Arquivos</asp:HyperLink></h3>
    <div class="subtitulo">Página para Upload de Arquivos </div>

    <h3><asp:HyperLink ID="lnk_Digitacao_Demanda" runat="server" NavigateUrl="~/Digitacao_Demanda.aspx" CssClass="link_submenu">Digitar demanda</asp:HyperLink></h3>
    <div class="subtitulo"></div>

    <h3><asp:HyperLink ID="lnk_Digitacao_Estoque" runat="server" NavigateUrl="~/Digitacao_Estoque.aspx" CssClass="link_submenu">Digitar estoque</asp:HyperLink></h3>
    <div class="subtitulo"></div>
     
    <h3><asp:HyperLink ID="lnk_Digitacao_Demanda_Manutencao" runat="server" NavigateUrl="~/Digitacao_Demanda_Manutencao.aspx" CssClass="link_submenu">Manutenção na demanda</asp:HyperLink></h3>
    <div class="subtitulo"></div>
   
    <h3><asp:HyperLink ID="lnk_Digitacao_Demanda_Transferencia" runat="server" NavigateUrl="~/Digitacao_Demanda_Transferencia.aspx" CssClass="link_submenu">Transferir demanda e oportunidades entre estabelecimentos</asp:HyperLink></h3>
    <div class="subtitulo"></div>

    <h3><asp:HyperLink ID="Estabelecimentos_Atualizacao_Receita" runat="server" NavigateUrl="~/Estabelecimentos_Atualizacao_Receita.aspx" CssClass="link_submenu">Estabelecimentos Atualização RF</asp:HyperLink></h3>
    <div class="subtitulo"></div>

    <h3><asp:HyperLink ID="lnk_Estabelecimentos_Alterar_Sistema" runat="server" NavigateUrl="~/Estabelcimentos_Alterar_Sistema.aspx" CssClass="link_submenu">Estabelecimentos Manutenção (Sistema)</asp:HyperLink></h3>
    <div class="subtitulo"></div>
    

    
    <h3><asp:HyperLink ID="lnk_Estabelecimentos_Grupos2" runat="server" NavigateUrl="~/Estabelecimentos_Grupos2.aspx" CssClass="link_submenu">Estabelecimentos Grupos 2</asp:HyperLink></h3>
    <div class="subtitulo"></div>

    <h3><asp:HyperLink ID="lnk_Estabelecimentos_Associar_Grupo2" runat="server" NavigateUrl="~/Estabelecimentos_Associar_Grupo2.aspx" CssClass="link_submenu">Estabelecimentos Associar Grupo 2</asp:HyperLink></h3>
    <div class="subtitulo"></div>

    <h3><asp:HyperLink ID="lnk_Estabelecimentos_Pesquisa_Geral" runat="server" NavigateUrl="~/Estabelecimentos_Pesquisa_Geral.aspx" CssClass="link_submenu">Estabelecimentos Pesquisa Geral</asp:HyperLink></h3>
    <div class="subtitulo"></div>
        
    <h3><asp:HyperLink ID="lnk_Setorizacao_Atualizacao_dexXmms" runat="server" NavigateUrl="~/Setorizacao_Atualizacao_dexXmms.aspx" CssClass="link_submenu">Estabelecimentos Atualização de setorização de KA Dex x MMS</asp:HyperLink></h3>
    <div class="subtitulo"></div>    

    

</div>
    </form>
</body>
</html>
