<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Lojas.aspx.vb" Inherits="SiteEmpty.Lojas" %>
<%@ Register Src="~/_Header_Scripts.ascx" TagPrefix="uc1" TagName="_Header_Scripts" %>
<%@ Register Src="~/_Header.ascx" TagPrefix="uc1" TagName="_Header" %>
<%@ Register Src="~/_Footer_Scripts.ascx" TagPrefix="uc1" TagName="_Footer_Scripts" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Lojas</title>
</head>
<body>
    <form id="frm_Main" runat="server">
        <uc1:_Header runat="server" ID="_Header" />
        <uc1:_Header_Scripts runat="server" ID="_Header_Scripts" />
        <div class="container form">
            <h3 class="text-primary">Lojas</h3>
            <asp:FormView ID="frm_Loja" runat="server" AllowPaging="True" DataKeyNames="Loja_Sigla" DataSourceID="dts_Loja" Height="265px" Width="80%" HorizontalAlign="Center">
                <EditItemTemplate>
                    Id:
                    <asp:Label ID="IdLabel1" runat="server" Text='<%# Eval("Id") %>' />
                    <br />
                    Loja_Sigla:
                    <asp:Label ID="Loja_SiglaLabel1" runat="server" Text='<%# Eval("Loja_Sigla") %>' />
                    <br />
                    Loja:
                    <asp:TextBox ID="LojaTextBox" runat="server" Text='<%# Bind("Loja") %>' />
                    <br />
                    Loja_Endereco:
                    <asp:TextBox ID="Loja_EnderecoTextBox" runat="server" Text='<%# Bind("Loja_Endereco") %>' />
                    <br />
                    Loja_Cidade:
                    <asp:TextBox ID="Loja_CidadeTextBox" runat="server" Text='<%# Bind("Loja_Cidade") %>' />
                    <br />
                    Loja_UF:
                    <asp:TextBox ID="Loja_UFTextBox" runat="server" Text='<%# Bind("Loja_UF") %>' />
                    <br />
                    Loja_Telefone:
                    <asp:TextBox ID="Loja_TelefoneTextBox" runat="server" Text='<%# Bind("Loja_Telefone") %>' />
                    <br />
                    Insert_Date:
                    <asp:TextBox ID="Insert_DateTextBox" runat="server" Text='<%# Bind("Insert_Date") %>' />
                    <br />
                    Insert_User:
                    <asp:TextBox ID="Insert_UserTextBox" runat="server" Text='<%# Bind("Insert_User") %>' />
                    <br />
                    Update_Date:
                    <asp:TextBox ID="Update_DateTextBox" runat="server" Text='<%# Bind("Update_Date") %>' />
                    <br />
                    Update_User:
                    <asp:TextBox ID="Update_UserTextBox" runat="server" Text='<%# Bind("Update_User") %>' />
                    <br />
                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Atualizar" />
                    &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    Loja_Sigla:
                    <asp:TextBox ID="Loja_SiglaTextBox" runat="server" Text='<%# Bind("Loja_Sigla") %>' />
                    <br />
                    Loja:
                    <asp:TextBox ID="LojaTextBox" runat="server" Text='<%# Bind("Loja") %>' />
                    <br />
                    Loja_Endereco:
                    <asp:TextBox ID="Loja_EnderecoTextBox" runat="server" Text='<%# Bind("Loja_Endereco") %>' />
                    <br />
                    Loja_Cidade:
                    <asp:TextBox ID="Loja_CidadeTextBox" runat="server" Text='<%# Bind("Loja_Cidade") %>' />
                    <br />
                    Loja_UF:
                    <asp:TextBox ID="Loja_UFTextBox" runat="server" Text='<%# Bind("Loja_UF") %>' />
                    <br />
                    Loja_Telefone:
                    <asp:TextBox ID="Loja_TelefoneTextBox" runat="server" Text='<%# Bind("Loja_Telefone") %>' />
                    <br />
                    Insert_Date:
                    <asp:TextBox ID="Insert_DateTextBox" runat="server" Text='<%# Bind("Insert_Date") %>' />
                    <br />
                    Insert_User:
                    <asp:TextBox ID="Insert_UserTextBox" runat="server" Text='<%# Bind("Insert_User") %>' />
                    <br />
                    Update_Date:
                    <asp:TextBox ID="Update_DateTextBox" runat="server" Text='<%# Bind("Update_Date") %>' />
                    <br />
                    Update_User:
                    <asp:TextBox ID="Update_UserTextBox" runat="server" Text='<%# Bind("Update_User") %>' />
                    <br />
                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Inserir" />
                    &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
                </InsertItemTemplate>
                <ItemTemplate>
                    Id:
                    <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                    <br />
                    Loja_Sigla:
                    <asp:Label ID="Loja_SiglaLabel" runat="server" Text='<%# Eval("Loja_Sigla") %>' />
                    <br />
                    Loja:
                    <asp:Label ID="LojaLabel" runat="server" Text='<%# Bind("Loja") %>' />
                    <br />
                    Loja_Endereco:
                    <asp:Label ID="Loja_EnderecoLabel" runat="server" Text='<%# Bind("Loja_Endereco") %>' />
                    <br />
                    Loja_Cidade:
                    <asp:Label ID="Loja_CidadeLabel" runat="server" Text='<%# Bind("Loja_Cidade") %>' />
                    <br />
                    Loja_UF:
                    <asp:Label ID="Loja_UFLabel" runat="server" Text='<%# Bind("Loja_UF") %>' />
                    <br />
                    Loja_Telefone:
                    <asp:Label ID="Loja_TelefoneLabel" runat="server" Text='<%# Bind("Loja_Telefone") %>' />
                    <br />
                    Insert_Date:
                    <asp:Label ID="Insert_DateLabel" runat="server" Text='<%# Bind("Insert_Date") %>' />
                    <br />
                    Insert_User:
                    <asp:Label ID="Insert_UserLabel" runat="server" Text='<%# Bind("Insert_User") %>' />
                    <br />
                    Update_Date:
                    <asp:Label ID="Update_DateLabel" runat="server" Text='<%# Bind("Update_Date") %>' />
                    <br />
                    Update_User:
                    <asp:Label ID="Update_UserLabel" runat="server" Text='<%# Bind("Update_User") %>' />
                    <br />
                    <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar" />
                    &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Excluir" />
                    &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="Novo" />
                </ItemTemplate>
                <PagerSettings Position="Top" />
                <PagerStyle VerticalAlign="Middle" />
            </asp:FormView>


            <asp:SqlDataSource ID="dts_Loja" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" 
                DeleteCommand="DELETE FROM [tb_Lojas] WHERE [Loja_Sigla] = @original_Loja_Sigla" 
                InsertCommand="INSERT INTO [tb_Lojas] ([Loja_Sigla], [Loja], [Loja_Endereco], [Loja_Cidade], [Loja_UF], [Loja_Telefone], [Insert_User], [Update_User]) VALUES (@Loja_Sigla, @Loja, @Loja_Endereco, @Loja_Cidade, @Loja_UF, @Loja_Telefone,  @Insert_User,  @Update_User)" 
                OldValuesParameterFormatString="original_{0}" 
                SelectCommand="SELECT * FROM [tb_Lojas] ORDER BY [Loja]" 
                UpdateCommand="UPDATE [tb_Lojas] SET  [Loja] = @Loja, [Loja_Endereco] = @Loja_Endereco, [Loja_Cidade] = @Loja_Cidade, [Loja_UF] = @Loja_UF, [Loja_Telefone] = @Loja_Telefone, [Insert_User] = @Insert_User,  [Update_User] = @Update_User WHERE [Loja_Sigla] = @original_Loja_Sigla">
                <DeleteParameters>
                    <asp:Parameter Name="original_Loja_Sigla" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Loja_Sigla" Type="String" />
                    <asp:Parameter Name="Loja" Type="String" />
                    <asp:Parameter Name="Loja_Endereco" Type="String" />
                    <asp:Parameter Name="Loja_Cidade" Type="String" />
                    <asp:Parameter Name="Loja_UF" Type="String" />
                    <asp:Parameter Name="Loja_Telefone" Type="String" />
                    <asp:Parameter Name="Insert_Date" Type="DateTime" />
                    <asp:Parameter Name="Insert_User" Type="String" />
                    <asp:Parameter Name="Update_Date" Type="DateTime" />
                    <asp:Parameter Name="Update_User" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Id" Type="Decimal" />
                    <asp:Parameter Name="Loja" Type="String" />
                    <asp:Parameter Name="Loja_Endereco" Type="String" />
                    <asp:Parameter Name="Loja_Cidade" Type="String" />
                    <asp:Parameter Name="Loja_UF" Type="String" />
                    <asp:Parameter Name="Loja_Telefone" Type="String" />
                    <asp:Parameter Name="Insert_Date" Type="DateTime" />
                    <asp:Parameter Name="Insert_User" Type="String" />
                    <asp:Parameter Name="Update_Date" Type="DateTime" />
                    <asp:Parameter Name="Update_User" Type="String" />
                    <asp:Parameter Name="original_Loja_Sigla" Type="String" />
                    <asp:Parameter Name="original_Id" Type="Decimal" />
                    <asp:Parameter Name="original_Loja" Type="String" />
                    <asp:Parameter Name="original_Loja_Endereco" Type="String" />
                    <asp:Parameter Name="original_Loja_Cidade" Type="String" />
                    <asp:Parameter Name="original_Loja_UF" Type="String" />
                    <asp:Parameter Name="original_Loja_Telefone" Type="String" />
                    <asp:Parameter Name="original_Insert_Date" Type="DateTime" />
                    <asp:Parameter Name="original_Insert_User" Type="String" />
                    <asp:Parameter Name="original_Update_Date" Type="DateTime" />
                    <asp:Parameter Name="original_Update_User" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>


        </div>
        <uc1:_Footer_Scripts runat="server" ID="_Footer_Scripts" />
    </form>
</body>
</html>
