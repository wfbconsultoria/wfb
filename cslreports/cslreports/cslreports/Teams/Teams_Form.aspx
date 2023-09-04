<%@ Page Title="Equipe" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Teams_Form.aspx.vb" Inherits="cslreports.Teams_Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    
    <div class="form-row">
        <%-- Team_Code --%>
        <div class="form-group col-md-2">
            <label>Cod Equipe</label>
            <input runat="server" id="txt_Team_Code" type="text" maxlength="8" class="form-control" required="required" placeholder="" onfocus="this.value='';" onkeyup="this.value=retira_acentos(this.value);" />
        </div>
        <%-- Team --%>
        <div class="form-group col-md-10">
            <label>Equipe</label>
            <input runat="server" id="txt_CRM" type="text" maxlength="128" class="form-control" required="required" placeholder="" onfocus="this.value='';" onkeyup="this.value=retira_acentos(this.value);" />
        </div>
    </div>

        <%-- Buttons --%>
        <div class="form-group col-md-12">
            <input runat="server" id="btn_Save" type="submit" value="Salvar" class="btn btn-primary rounded" onclick="Salvar"/>
            <input runat="server" id="btn_Reset" type="reset" value="Limpar" class="btn btn-light rounded" />
        </div>
       
     

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
