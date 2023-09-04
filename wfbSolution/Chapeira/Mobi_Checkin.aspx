<%@ Page Title="Mobi CheckIn" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Mobi_Checkin.aspx.vb" Inherits="Chapeira.Mobi_ChekIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <h4 class="text-secondary text-uppercase"><%:Page.Title %></h4>
    <div class="m-3">
  <label class="h3">Escolha o Mobi</label>
  <select class="custom-select custom-select-lg mb-3">
     <option selected>Selecione o Mobi</option>
        <option value="1">Mobi01</option>
        <option value="2">Mobi02</option>
        <option value="3">Mobi03</option>
   </select>
   <label class="h3">Selecione seu Universo</label>          
  <select class="custom-select custom-select-lg mb-3">
      <option selected>Selecione seu Universo</option>
         <option value="1">CICLISMO</option>
         <option value="2">CORRIDA</option>
         <option value="3">MONTANHA</option>
  </select>
  
   <label class="h3">Selecione seu Nome</label> 
  <select class="custom-select custom-select-lg mb-3">
     <option selected>Selecione Seu Nome</option>
        <option value="1">Renato Pereira</option>
        <option value="2">Silvia Gomes</option>
        <option value="3">Laura Teresa</option>
  </select>
 </div>        
            <div class="col"><button type="submit" class="btn btn-success btn-lg btn-block">CheckIn</button></div>
         



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
