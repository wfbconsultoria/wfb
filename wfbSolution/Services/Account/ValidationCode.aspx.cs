using MySql.Data.MySqlClient;
using System;
using System.Configuration;

public partial class Account_ValidationCode : System.Web.UI.Page
{
    clsMaster m = new clsMaster();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Atribuindo nome aos botões
        btnValidate.Value = ConfigurationManager.AppSettings["btnValidationCode"];
        btnReturn.InnerText = ConfigurationManager.AppSettings["btnReturn"];
        txtCode.Focus();

        //Verificando se a query string foi enviada
        if (Request.Params["email"] == null)
        {
            //Sem query string
            m.alertRedirect("Erro ao recuperar e-mail do usuário","Login.aspx");
        }
        else if (Request.Params["email"].ToString() == string.Empty || Request.Params["email"].ToString() == "")
        {
            //Query string vazia
            m.alertRedirect("Erro ao recuperar e-mail do usuário", "Login.aspx");
        }else
        {
            //recuperando e-mail
            txtEmail.Value = Request.Params["email"].ToString();
        }
    }

    //Voltar para o login
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    //Validar conta
    protected void btnValidate_Click(object sender, EventArgs e) {
        string sql = "SELECT Nome, CodigoAcesso FROM tb_usuario WHERE Email = '" + txtEmail.Value + "' AND Valido = '0';";
        MySqlDataReader dtr = m.ExecuteSelect(sql);

        if (dtr.HasRows){
            dtr.Read();
            //Verificando se o código está correto
            if(txtCode.Value == dtr["CodigoAcesso"].ToString())
            {
                //Código certo
                sql = "";
                sql = "UPDATE tb_usuario SET Valido = '1' WHERE Email = '" + txtEmail.Value + "';";
                dtr.Close();

                //Tornando cliente valido
                if (m.ExecuteSQL(sql) == true) {                    
                    m.alertRedirect("Bem vindo ","../index.aspx?session=" + m.createSession(txtEmail.Value));
                }else
                {
                    //Erro ao validar usuário
                    m.alert("Atenção: Não foi possivel validar a conta, contate o administrador");
                }
                
            }
            else
            {
                //Código inválido
                m.alert("Código inválido!");
                txtCode.Value = "";
                txtCode.Focus();
            }
        }else
        {
            m.alert("Erro ao recuperar informações do usuário!");
        }

        //Fechando data reader
        dtr.Close();
    }
}