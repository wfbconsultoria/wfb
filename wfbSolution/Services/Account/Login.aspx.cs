using MySql.Data.MySqlClient;
using System;
using System.Configuration;

public partial class Account_Login : System.Web.UI.Page
{
    clsMaster m = new clsMaster();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Atribuindo nome aos botões
        btnLogin.Value = ConfigurationManager.AppSettings["btnLogin"];
        btnRegister.InnerText = ConfigurationManager.AppSettings["btnCreateAccount"];
        btnRecoverPassword.InnerText = ConfigurationManager.AppSettings["btnRecoverPassword"];
        btnReturn.InnerText = ConfigurationManager.AppSettings["btnReturn"];

    }

    //Redirecionar para cadastro
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }

    //Login
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //Verificando se o e-mail está cadastrado
        string email = m.ConverText(clsMaster.TextKeyOption.LowerCase, txtEmail.Value);
        string senha = m.ConverText(clsMaster.TextKeyOption.TextCase, txtPassword.Value);
        string sql = "SELECT Email, Nome, Sobrenome, Senha, Valido FROM tb_usuario Where Email = '" + email + "';";
        MySqlDataReader dtr = m.ExecuteSelect(sql);

        if (dtr.HasRows)
        {
            //Verificando se o código de validação já foi inserido
            dtr.Read();
                //Verificando se a senha condiz
                if (senha == dtr["Senha"].ToString())
                {
                if (dtr["Valido"].ToString() == "0" || dtr["Valido"].ToString() == "False")
                {
                    //Pedir código de validação
                    m.alertRedirect("Valide sua conta com o código enviado para seu e-mail!", "ValidationCode.aspx?email=" + dtr["Email"].ToString());
                }
                else
                {
                    dtr.Close();
                    //Logado
                    Response.Redirect("../index.aspx?session=" + m.createSession(email));
                }
            }
                else
                {
                    //Senha incorreta
                    m.alert("Usuário ou senha incorreta!");
                }
        }
        else
        {
            //Usuário não cadastrado
            m.alert("Usuário ou senha incorreta!");
        }
        //Fechando data reader
        dtr.Close();
    }
}