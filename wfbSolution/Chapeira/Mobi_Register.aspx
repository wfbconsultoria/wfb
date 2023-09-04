<%@ Page Title="Registro de Mobi" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Mobi_Register.aspx.vb" Inherits="Chapeira.MobI_Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <h4 class="text-secondary text-uppercase"><%:Page.Title %></h4>

     <form>
         <div class="row">
             <div class="col">
               <div class="mb-3">
                <label for="exampleInputEmail1" class="form-label">Nome Mobi</label>
                <input type="text" class="form-control"  aria-describedby="Nome Mobi">
               </div>
             </div>

             <div class="col">
               <div class="mb-3">
                <label for="exampleInputPassword1" class="form-label">Numero de identificação </label>
                <input type="text" class="form-control">
               </div>
             </div>
           
         </div>

         <div class"row">
             <div class="col"><button type="submit" class="btn btn-primary">Gravar</button></div>
         </div>
      
    </form>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
