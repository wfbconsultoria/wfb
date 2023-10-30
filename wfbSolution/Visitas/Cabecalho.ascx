<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Cabecalho.ascx.vb" Inherits="Header" %>
<%@ Import Namespace="System.Globalization" %>
<link href="App_Themes/MasterTheme/Master.css" rel="stylesheet" />
<script src="JavaScript.js"></script>

 <style type="text/css">
     .auto-style1 {
         width: 92px;
     }
     .auto-style2 {
         height: 37px;
     }
 </style>

 <div style="width:100%;  "vertical-align: middle; border-bottom-style: solid; border-bottom-width: 5px; border-bottom-color: #5a3988; margin-top:0;">
   <div id ="Corpo">
    
       <table style="width: 100%">
           <tr>
               <td rowspan="2" style="vertical-align: middle; text-align: center;" class="auto-style1"><img  src="Images/pfizer_logo.jpg" style="height: 69px; width: 106px"/></td>
               <td class="auto-style2">
                   
                   <asp:Label ID="lbl_Login" runat="server" Text="Label" Font-Size="x-Small" ForeColor="Gray" ></asp:Label>&nbsp;
                   <a href="Login.aspx" style="font-size: small; color: #FF0000;">sair</a>
               </td>
           </tr>
           <tr>
               <td style="font-size: medium; text-transform: uppercase;">
                   <a class="linkcolorido" href="Default.aspx">Início</a>&nbsp;                   
                   <a class="linkcolorido" href="Estabelecimentos_Localizar.aspx">Meus Estabelecimentos</a>&nbsp;
                   <a class="linkcolorido" href="Menu_relatórios.aspx">Relatórios</a>&nbsp;
                   <a class="linkcolorido" href="Menu_operações.aspx">Operações</a>&nbsp;
                   <% If Session("SISTEMA") = True Then%>
                     <a href="Menu_sistema.aspx">Sistema</a>&nbsp;
                   <% End If%>
               </td>
           </tr>
       </table>
       <hr />
   </div>
 </div>