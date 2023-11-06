<%@ Page Title="Usuario" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master.Master" CodeBehind="User.aspx.vb" Inherits="BiHospitalar2020.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%--Máscara de entrada--%>
    <script type="text/javascript">
        // mascara entrada
        function formatar(mascara, documento) {
            let i = documento.value.length;
            let saida = mascara.substring(0, 1);
            let texto = mascara.substring(i)

            if (texto.substring(0, 1) != saida) {
                documento.value += texto.substring(0, 1);
            }
        }

 <%--Somente Numeros--%>
        function somenteNumeros(e) {
            var charCode = e.charCode ? e.charCode : e.keyCode;
            // charCode 8 = backspace   
            // charCode 9 = tab
            if (charCode != 8 && charCode != 9) {
                // charCode 48 equivale a 0   
                // charCode 57 equivale a 9
                if (charCode < 48 || charCode > 57) {
                    return false;
                }
            }
        }

     <%--Valida Data--%>
        function validaDat(campo, valor) {
            var date = valor;
            var ardt = new Array;
            var ExpReg = new RegExp("(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[12][0-9]{3}");
            ardt = date.split("/");
            erro = false;
            if (date.search(ExpReg) == -1) {
                erro = true;
            }
            else if (((ardt[1] == 4) || (ardt[1] == 6) || (ardt[1] == 9) || (ardt[1] == 11)) && (ardt[0] > 30))
                erro = true;
            else if (ardt[1] == 2) {
                if ((ardt[0] > 28) && ((ardt[2] % 4) != 0))
                    erro = true;
                if ((ardt[0] > 29) && ((ardt[2] % 4) == 0))
                    erro = true;
            }
            if (date == "") erro = false;
            if (erro) {
                alert("DATA Formato inválido (dd/mm/aaaa");
                campo.value = "";
                return false;
            }
            return true;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource ID="dts_Users_Status" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [User_Status] FROM [sys_User_Status] ORDER BY [User_Status]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Users_Profiles" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [User_Profile_Code], [User_Profile] FROM [sys_Users_Profiles] ORDER BY [User_Profile_Code]"></asp:SqlDataSource>
     <asp:SqlDataSource ID="dts_Users_Administrators" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Email], [Name] FROM [sys_Users] ORDER BY [Name]"></asp:SqlDataSource>
    <%--Titulo da Pagina--%>
    <h4 class="text-secondary text-uppercase" style="padding-top: 5px"><%:Page.Title %></h4>
    
    <%--status/profile--%>
    <div class="form-row">
       
        <%-- Status--%>
        <div class="form-group col-sm-4">
            <label>Status</label>
            <asp:DropDownList ID="cmb_User_Status" runat="server" class="form-control" DataSourceID="dts_Users_Status" DataTextField="User_Status" DataValueField="User_Status" AutoPostBack="True"></asp:DropDownList>
        </div>
        <%-- Perfil--%>
        <div class="form-group col-sm-4">
            <label>Perfil</label>
            <asp:DropDownList ID="cmb_User_Profile_Code" runat="server" class="form-control" DataSourceID="dts_Users_Profiles" DataTextField="User_Profile" DataValueField="User_Profile_Code"></asp:DropDownList>
        </div>
    </div>
   
    <div class="form-row">
        <%-- Nome--%>
        <div class="form-group col-sm-12">
            <label>Nome</label>
            <input runat="server" id="txt_Name" type="text" maxlength="128" class="form-control" required="required" onfocus="this.value='';" disabled="disabled"/>
        </div>
    </div>

    <%--EMAIL/CPF/DATA NASCIMENTO--%>
    <div class="form-row">
        <%--Email--%>
        <div class="form-group col-md-8">
            <label>E-mail</label>
            <input id="txt_Email" runat="server" type="email" autocomplete="off" maxlength="128" class="form-control" placeholder="Email" disabled="disabled" />
        </div>
         <%--Data Nascimento--%>
        <div class="form-group col-md-2">
            <label>Nascimento</label>
            <input id="txt_Birth_Date" runat="server" type="text" autocomplete="off" maxlength="10" class="form-control" placeholder="Data dd/mm/aaaa" onfocus="this.value=''" onkeypress="formatar('##/##/####', this);" onblur="validaDat(this,this.value);" disabled="disabled" />
        </div>
        <%--CPF--%>
        <div class="form-group col-md-2">
            <label>CPF</label>
            <div class="input-group">
                <div class="custom-file">
                    <input id="txt_Document" runat="server" type="text" autocomplete="off" maxlength="14" class="form-control" placeholder="CPF 000.000.000-00" onfocus="this.value='';ResetMessage()" onkeypress="formatar('###.###.###-##', this)" disabled="disabled"/>
                </div>
            </div>
        </div>
    </div>
    <%--/EMAIL/CPF/DATA NASCIMENTO--%>

    <%--TELEFONE/CELULAR/WHATS-APP--%>
    <div class="form-row">
        <%--Phone--%>
        <div class="form-group col-md-4">
            <label>Telefone</label>
            <input id="txt_Phone" runat="server" type="text" autocomplete="off" maxlength="32" class="form-control" placeholder="Telefone" />
        </div>
        <%--Mobile--%>
        <div class="form-group col-md-4">
            <label>Celular</label>
            <input id="txt_Mobile" runat="server" type="text" autocomplete="off" maxlength="32" class="form-control" placeholder="Telefone" />
        </div>
        <%--WhatsApp--%>
        <div class="form-group col-md-4">
            <label>Whats App</label>
            <input id="txt_WhatsApp" runat="server" type="text" autocomplete="off" maxlength="32" class="form-control" placeholder="Telefone" />
        </div>
    </div>
    <%--TELEFONE/CELULAR/WHATS-APP--%>

    <%--CEP/ENDERECO--%>
    <%--<div class="form-row">--%>
        <%--CEP--%>
        <%--<div class="form-group col-md-3">
            <label>CEP</label>
            <div class="input-group">
                <div class="custom-file">
                    <input id="txt_Address_ZIP" runat="server" type="text" autocomplete="off" maxlength="8" class="form-control" placeholder="00000000" onfocus="this.value=''" onkeypress="return somenteNumeros(event)" />
                </div>
                <div class="input-group-append">
                    <input runat="server" type="button" id="cmd_ConsultaCEP" value="Busca" />
                </div>
            </div>
        </div>--%>
        <%--Endereço--%>
        <%--<div class="form-group col-md-9">
            <label>Endereço</label>
            <input id="txt_Address" runat="server" type="text" autocomplete="off" maxlength="200" class="form-control" placeholder="Endereço" readonly="readonly" />
        </div>--%>
    <%--</div>--%>
    <%--CEP/ENDERECO--%>

    <%--NUMERO/COMPLEMENTO/BAIRRO--%>
   <%-- <div class="form-row">--%>
        <%--Numero--%>
        <%--<div class="form-group col-md-2">
            <label>Número</label>
            <input id="txt_Address_Number" runat="server" type="text" autocomplete="off" maxlength="30" class="form-control" placeholder="Número" />
        </div>--%>
        <%--Complemento--%>
       <%-- <div class="form-group col-md-4">
            <label>Complemento</label>
            <input id="txt_Address_Complement" runat="server" type="text" autocomplete="off" maxlength="50" class="form-control" placeholder="Complemento" />
        </div>--%>
        <%--Bairro--%>
        <%--<div class="form-group col-md-6">
            <label>Bairro</label>
            <input id="txt_Address_District" runat="server" type="text" autocomplete="off" class="form-control" placeholder="Bairro" readonly="readonly" />
        </div>--%>
   <%-- </div>--%>
    <%--/NUMERO/COMPLEMENTO/BAIRRO--%>

    <%--CIDADE/ESTADO/PAIS--%>
   <%-- <div class="form-row">--%>
        <%--Cidade--%>
        <%--<div class="form-group col-md-6">
            <label>Cidade</label>
            <input id="txt_Address_City" runat="server" type="text" autocomplete="off" class="form-control" placeholder="Cidade" readonly="readonly" />
        </div>--%>
        <%--UF--%>
        <%--<div class="form-group col-md-2">
            <label>UF</label>
            <input id="txt_Address_State" runat="server" type="text" autocomplete="off" class="form-control" placeholder="UF" readonly="readonly" />
        </div>--%>
        <%--Pais--%>
        <%--<div class="form-group col-md-4">
            <label>País</label>
            <input id="txt_Address_Country" runat="server" type="text" autocomplete="off" class="form-control" placeholder="País" readonly="readonly" />
        </div>--%>
    <%--</div>--%>
    <%--/CIDADE/ESTADO/PAIS--%>

    <div class="form-row">
        <%-- Observações--%>
        <div class="form-group col-sm-12">
            <label>Observações</label>
            <textarea runat="server" id="txt_Notes" type="text"  class="form-control" rows="2" maxlength="2048" />
        </div>
    </div>

    <div class="form-row">
        <%-- liberado por--%>
        <%--<div class="form-group col-sm-6">
            <label>Liberado por</label>
             <asp:DropDownList ID="cmb_User_Administrator" runat="server" CssClass="form-control" DataSourceID="dts_Users_Administrators" DataTextField="Name" DataValueField="Email"></asp:DropDownList>
        </div>
        <div class="form-group col-sm-3">
            <label>Data Inclusão</label>
            <input runat="server" id="txt_Insert_Date" type="text" maxlength="128" class="form-control" readonly="readonly" />
        </div>--%>
        <div class="form-group col-sm-3">
            <label>Último Acesso</label>
            <input runat="server" id="txt_Last_Login_Date" type="text" maxlength="128" class="form-control" readonly="readonly" />
        </div>
    </div>

    <%-- botoes de de comando--%>
    <input runat="server" id="cmd_Save" type="submit" value="Gravar" class="btn btn-success" />
    &nbsp;<input id="cmd_Cancel" type="reset" value="Cancelar" class="btn btn-light" />
    &nbsp; <a href="ManagePassword.aspx" class="btn btn-primary">Alterar Senha</a>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
