using MySql.Data.MySqlClient;
using System;
using System.Configuration;

public partial class Account_RecoverPassword : System.Web.UI.Page
{
    //Classe master
    clsMaster m = new clsMaster();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Atribuindo nome aos botões
        btnRecoverPassword.Value = ConfigurationManager.AppSettings["btnRecoverPassword"];
        btnReturn.InnerText = ConfigurationManager.AppSettings["btnReturn"];

    }

    //Voltar para o login
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    //Enviar senha para o e-mail do usuário
    protected void btnRecoverPassword_Click(object sender, EventArgs e)
    {
        //Verificando se o e-mail está cadastrado
        string sql = "SELECT Email, Nome, Sobrenome, Senha FROM tb_usuario Where Email = '" + m.ConverText(clsMaster.TextKeyOption.LowerCase, txtEmail.Value) + "';";
        MySqlDataReader dtr = m.ExecuteSelect(sql);

        if (dtr.HasRows)
        {
            //Montando e-mail para usuário
            dtr.Read();
            string message = "De acordo com a solicitação feita pelo usuário(a) " + dtr["Nome"].ToString() + ", segue informações de sua conta no sistema " + ConfigurationManager.AppSettings["ApplicationName"] + "<br/>";
            message += "Nome: " + dtr["Nome"].ToString() + " " + dtr["Sobrenome"].ToString() + " <br/>";
            message += "Senha: " + dtr["Senha"].ToString();

            if (m.SendEmail(clsMaster.MailFromOptions.Support, dtr["Email"].ToString(), "Recuperar senha", message))
            {
                //Recuperar com sucesso
                m.alertRedirect("Sua senha foi enviada para o seu e-mail, verifique sua caixa de mensagens ou spam", "Login.aspx");
            }
            else
            {
                //erro ao enviar senha
                m.alert("Erro ao recuperar senha do usuário, contate o adminitrador!");
            }
        }
        else
        {
            //Usuário não cadastrado
            m.alert("E-mail não cadastrado!");
        }
        //Fechando data reader
        dtr.Close();
    }
}