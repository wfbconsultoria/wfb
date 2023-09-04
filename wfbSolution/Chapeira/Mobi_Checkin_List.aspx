<%@ Page Title="Mobi Lista" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Mobi_Checkin_List.aspx.vb" Inherits="Chapeira.Mobi_Checkin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
        <h4 class="text-secondary text-uppercase"><%:Page.Title %></h4>
    
    <div class="input-group">
        <input id="filter" type="text" maxlength="128" class="form-control" placeholder="Localizar" style="font-size: xx-large" />
        <div class="input-group-append">
            <span class="input-group-text text-primary" style="font-size:large""><a href="#">Mobi</a></span>
         
        </div>
    </div>
    <br />

    <table class="table demo table-bordered table-hover " data-filter="#filter" data-paging="true" data-filter-text-only="true" data-page-size="1000">
        <thead class="navbar-default">
            <tr>
                <th>Mobi</th>
                <th>Disponivel</th>
                <th>Nome</th>
                <th class="text-center d-none d-md-block">Ação</th>
            </tr>
        </thead>
        <tbody>
           
             <tr>
               <td class="text-center" style="text-align: center; width:10%;"><img src="Images/Mobi.png" style=" height: 50px;" /><span></span></td>
               <td class="text-white" style="font-size: x-large; width: 10%; text-align:center; background: #28a745">Sim</td>
               <td class="text-primary " style="text-align: center;"><a  href='#'>Nome Do Mobi</a></td>
               <td class="text-center" style="text-align: center; width: 10%"><button class="btn btn-success"><a  href='Mobi_Checkin' class="text-white" >CkeckIn</a></button></td>
              </tr>

            <tr>
               <td class="text-center" style="text-align: center; width:10%;"><img src="Images/Mobi.png" style=" height: 50px;" /><span></span></td>
               <td class="text-white" style="font-size: x-large; width: 10%; text-align:center; background: #dc3545">Não</td>
               <td class="text-primary " style="text-align: center;"><a  href='#'>Nome Do Mobi</a></td>
               <td class="text-center" style="text-align: center; width: 10%"><button class="btn btn-danger"><a  href='#' class="text-white">CkeckOut</a></button></td>
             </tr>
           
        </tbody>
        <tfoot>
            <tr>
                <td colspan="12">
                    <div class="pagination pagination-centered"></div>
                </td>
            </tr>
        </tfoot>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
