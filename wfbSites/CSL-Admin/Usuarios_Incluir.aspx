<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Usuarios_Incluir.aspx.vb" Inherits="Usuarios" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Incluir Usuário</title>
    <script src="JavaScript.js" type="text/javascript"></script>
</head>
<body>
    <form id="frmUsuarios" runat="server">
        <uc1:Cabecalho runat="server" id="Cabecalho" />
        <div id="Titulo_Pagina">
                <div id ="Titulo_Pagina_Cabecalho">Inclusão de Usuário</div>
                <div id ="Titulo_Pagina_Links">
                    &nbsp;<a href="Usuarios_Localizacao.aspx">Voltar</a>
                </div>
           </div>
           <br />
        <div id="Corpo">
           <asp:TextBox ID="txt_Acao" runat="server" AutoPostBack="True" Width="100%" BorderStyle="None" EnableTheming="True"></asp:TextBox>
            <table id="tblUsuarios" width="100%">
                <tr>
                    <td width="8%" style="text-align: right"></td>
                    <td>
                        &nbsp;<asp:LinkButton ID="cmdGravar" runat="server">Gravar</asp:LinkButton>
                        &nbsp;<a href="Usuarios_Localizacao.aspx">Cancelar</a>
                        &nbsp;<asp:HyperLink ID="lnk_Limpar" runat="server" NavigateUrl="~/Usuarios_Incluir.aspx">Limpar</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td width="8%" style="text-align: right">Email</td>
                    <td>
                        <asp:TextBox ID="txt_EMAIL" runat="server" 
                            Font-Bold="True" MaxLength="100" 
                            Width="50%"></asp:TextBox>
                        &nbsp;<asp:RegularExpressionValidator ID="rev_EMAIL" runat="server" 
                            ErrorMessage="EMAIL INVÁLIDO" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                            ControlToValidate="txt_EMAIL" Display="Dynamic" style="color: #FF0000;"></asp:RegularExpressionValidator>
                        &nbsp;<asp:RequiredFieldValidator ID="rfv_EMAIL" runat="server" 
                            ControlToValidate="txt_EMAIL" ErrorMessage="OBRIGATÓRIO" style="color: #FF0000"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Nome</td>
                    <td >
                        <asp:TextBox ID="txt_NOME" runat="server" 
                            MaxLength="100" 
                            Width="50%"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="rfv_NOME" runat="server" 
                            ControlToValidate="txt_NOME" ErrorMessage="OBRIGATÓRIO" style="color: #FF0000"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Perfil</td>
                    <td>
                        <asp:DropDownList ID="cmb_PERFIL" runat="server" 
                            Width="25%" DataSourceID="dts_Perfis" DataTextField="PERFIL" 
                            DataValueField="COD_PERFIL">
                        </asp:DropDownList>
                    &nbsp;<asp:RangeValidator ID="rfv_cmb_Perfil" runat="server" ControlToValidate="cmb_PERFIL" ErrorMessage="RangeValidator" MinimumValue="0" style="color: #FF0000" Type="Double">SELECIONE O PERFIL</asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Função</td>
                    <td>
                        <asp:DropDownList ID="cmb_Funcao" runat="server" 
                            Width="25%" DataSourceID="dts_Funcoes" DataTextField="DESCRICAO" 
                            DataValueField="COD_FUNCAO">
                        </asp:DropDownList>
                    &nbsp;<asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="cmb_Funcao" ErrorMessage="RangeValidator" MinimumValue="0" style="color: #FF0000" Type="Double">SELECIONE A FUNÇÃO</asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Equipe</td>
                    <td>
                        <asp:DropDownList ID="cmb_Equipe" runat="server" 
                            Width="25%" DataSourceID="dts_Equipe" DataTextField="EQUIPE" 
                            DataValueField="ID_EQUIPE">
                        </asp:DropDownList>
                        <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="cmb_Equipe" ErrorMessage="RangeValidator" MinimumValue="0" style="color: #FF0000" Type="Double">SELECIONE A EQUIPE</asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Cód Interno</td>
                    <td>
                        <asp:TextBox ID="txt_COD_INTERNO" runat="server" Width="25%"></asp:TextBox>
                    &nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style1">Telefone Celular</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txt_TELEFONE" runat="server" Width="25%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style1">Telefone Fixo</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txt_FIXO" runat="server" Width="25%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Nascimento</td>
                    <td id="tdNascimento">
                        &nbsp;Ano
                        <asp:TextBox ID="txt_ANO_NASCIMENTO" runat="server" 
                            MaxLength="4" 
                            Width="5%" style="text-align: center"></asp:TextBox>
                        &nbsp;&nbsp;Mês
                        <asp:DropDownList ID="cmb_MES_NASCIMENTO" runat="server" 
                            DataSourceID="dts_Meses" DataTextField="MES_SIGLA" 
                            DataValueField="MES">
                        </asp:DropDownList>
                        &nbsp; Dia
                        <asp:TextBox ID="txt_DIA_NASCIMENTO" runat="server" MaxLength="2" 
                            style="text-align: center" Width="5%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Ger. Nacional</td>
                    <td>
                        <asp:DropDownList ID="cmb_EMAIL_DIRETOR" runat="server" 
                            Width="50%" DataSourceID="dts_Diretores" DataTextField="NOME" 
                            DataValueField="EMAIL">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Ger. Regional</td>
                    <td>
                        <asp:DropDownList ID="cmb_EMAIL_GERENTE" runat="server" 
                            Width="50%" DataSourceID="dts_Gerentes" DataTextField="NOME" 
                            DataValueField="EMAIL">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">Ger. Distrital</td>
                    <td>
                        <asp:DropDownList ID="cmb_EMAIL_COORDENADOR" runat="server" 
                            Width="50%" DataSourceID="dts_Coordenadores" DataTextField="NOME" 
                            DataValueField="EMAIL">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" class="auto-style1">&nbsp;</td>
                    <td class="auto-style1">
                        <asp:CheckBox ID="opt_Ativo" runat="server" Text="Ativo" /><br/>
                        <asp:CheckBox ID="opt_Bloqueado" runat="server" Text="Bloqueado" /><br/>
                        <asp:CheckBox ID="opt_Login" runat="server" Text="Login" /><br/>                        
                        <asp:CheckBox ID="opt_Administrador_Setorizacao" runat="server" Text="Administrador de Setorização" /><br />
                        <asp:CheckBox ID="opt_Administrador_Cotas" runat="server" Text="Administrador de Cotas" />
                        <br />
                        <asp:CheckBox ID="opt_calculo_Incentivo" runat="server" Text="Cálculo de Incentivo" /><br/>
                        <asp:CheckBox ID="opt_Download" runat="server" Text="Download" /><br/>
                        <asp:CheckBox ID="opt_Upload_Mapas" runat="server" Text="Upload de Mapas"/><br/>
                        <asp:CheckBox ID="opt_Upload" runat="server" Text="Upload" Visible="false" /><br/>
                        <asp:CheckBox ID="opt_Sistema" runat="server" Text="Sistema" Visible="false" /><br/>
                    </td>
                </tr>
        </table>
    </div>
    <asp:SqlDataSource ID="dts_Meses" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>"  SelectCommand="SELECT * FROM [TBL_DATAS_MESES] ORDER BY [MES]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Gerentes" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT '# Selecione' as NOME, '@' AS EMAIL UNION ALL SELECT [NOME], [EMAIL] FROM [VIEW_USUARIOS] WHERE [COD_PERFIL] = 2 OR [COD_PERFIL] = -1 ORDER BY [NOME]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Diretores" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT '# Selecione' as NOME, '@' AS EMAIL UNION ALL SELECT [NOME], [EMAIL] FROM [VIEW_USUARIOS] WHERE [COD_PERFIL] = 1 OR [COD_PERFIL] = -1 ORDER BY [NOME]">
    </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_Equipe" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_PRODUTOS_LINHAS_EQUIPES] ORDER BY [EQUIPE]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Funcoes" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT '-1' AS COD_FUNCAO, '# Selecione' AS DESCRICAO UNION ALL SELECT COD_FUNCAO, DESCRICAO  FROM [TBL_USUARIOS_FUNCOES] ORDER BY [COD_FUNCAO]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Coordenadores" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT '# Selecione' as NOME, '@' AS EMAIL UNION ALL SELECT [NOME], [EMAIL] FROM [VIEW_USUARIOS] WHERE [COD_PERFIL] = 3 OR [COD_PERFIL] = -1 ORDER BY [NOME]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Perfis" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="Select '-1' as COD_PERFIL, '# Selecione' as PERFIL UNION ALL SELECT COD_PERFIL, PERFIL  FROM [TBL_USUARIOS_PERFIS] ORDER BY [COD_PERFIL]">
    </asp:SqlDataSource>
</form>
</body>
</html>