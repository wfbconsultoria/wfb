<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Digitacao_Demanda_Transferencia.aspx.vb" Inherits="Digitacao_Demanda_Transferencia" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Transferir Demanda</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Transferir Demanda</div>
    <div id ="Titulo_Pagina_Links">
        
    </div>
</div>
<br />
<div id ="Corpo">
    <br />
                    <p>Movimento de <strong>DEMANDA E OPORTUNIDADES</strong> de um estabelecimento para outro</p>
                <br />
      
                
                    <p><strong>DE:</strong></p>
                    <p>(A demanda sai deste estabelecimento)</p>
               
                    <p><asp:DropDownList 
                        ID="cmb_CNPJ_ESTABELECIMENTO_DE" runat="server" 
                        DataSourceID="dts_Estabelecimentos" DataTextField="ESTABELECIMENTO_CNPJ" 
                        DataValueField="CNPJ" 
                        style="font-weight: 700; color: #FF0000; font-size: medium" Width="75%">
                    </asp:DropDownList></p>
                    <br />
                    <p><strong>PARA:</strong></p>
                    <p>(A demanda virá para)</p>
                   <p><strong><asp:DropDownList 
                     ID="cmb_CNPJ_ESTABELECIMENTO_PARA" runat="server" 
                     DataSourceID="dts_Estabelecimentos0" DataTextField="ESTABELECIMENTO_CNPJ" 
                     DataValueField="CNPJ" style="color: #0000FF; font-size: medium" Width="75%">
                    </asp:DropDownList>
                    </strong>
                    <asp:SqlDataSource ID="dts_Estabelecimentos0" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
                    SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS_001_DETALHADO] ORDER BY [ESTABELECIMENTO_CNPJ]">
                    </asp:SqlDataSource></p><br />
                    
     <strong><p style="background-color:#ffd800"><span style="color:#FF0000">ATENÇÃO !!</span>
     ESTE PROCEDIMENTO TRANSFERE TODA A DEMANDA E TODAS AS OPORTUNIDADES ENTRE OS 
        ESTABELECIMENTOS VERIFIQUE E CONFIRA SE ESTÁ FAZENDO O PROCEDIMENTO CORRETO, E SE OS 
     ESTABELECIMENTOS ESTÃO CORRETOS<br /></p></strong><br />
               
              
   <asp:Button ID="cmd_Gravar" runat="server" CssClass="buton_gravar" Text="Gravar" />
                           
    </div>

</form>
    <asp:SqlDataSource ID="dts_Estabelecimentos" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
                        SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS_001_DETALHADO] ORDER BY [ESTABELECIMENTO_CNPJ]">
                    </asp:SqlDataSource>
</body>
    
</html>
