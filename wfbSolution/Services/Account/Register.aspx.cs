using System;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;

public partial class Account_Register : System.Web.UI.Page
{
    //Classe master
    clsMaster m = new clsMaster();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Atribuindo nome aos botões
        btnRegister.Value = ConfigurationManager.AppSettings["btnRegister"];
        btnReturn.InnerText = ConfigurationManager.AppSettings["btnReturn"];

        //Encher select
        if (!IsPostBack)
        {
            string sql = "SELECT Ddd, Descricao FROM tb_ddd";
            MySqlDataReader dtr = m.ExecuteSelect(sql);
            while (dtr.Read())
            {
                ListItem listI = new ListItem();
                listI.Value = dtr["Ddd"].ToString();
                listI.Text = dtr["Descricao"].ToString();
                selDdd.Items.Add(listI);
            }
            dtr.Close();
        }
    }

    //Cadastrar usuário
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        //Verificando se o e-mail e celular já existem
        string email = m.ConverText(clsMaster.TextKeyOption.LowerCase, txtEmail.Value);
        string sql = "SELECT Email FROM tb_usuario WHERE Email = '" + email + "';";
        MySqlDataReader dtr = m.ExecuteSelect(sql);
        //Email ou celular já cadastrado
        if (dtr.HasRows)
        {
            //E-mail já cadastrado
            m.alert("O e-mail já esta sendo usado por outro usuário");
            txtEmail.Focus();
            dtr.Close();        
        }
        else
        {
            //Verificando Celular
            dtr.Close();
            sql = "";
            sql = "SELECT Ddd, Celular FROM tb_usuario WHERE Ddd = '" + selDdd.Value + "' AND Celular = '" + m.onlyNumbers(txtCellphone.Value) + "'";
            dtr = m.ExecuteSelect(sql);

            if (dtr.HasRows)
            {
                //Celular já cadastrado
                m.alert("O Celular já esta sendo usado por outro usuário");
                txtCellphone.Focus();
                dtr.Close();
            }
            else
            {
                //Validando domínio 
                dtr.Close();
                if (m.validateDomain(email) == false)
                {
                    m.alert("Domínio inválido, contate o administrador do sistema");
                }
                else
                {

                    //Cadastrando usuário
                    dtr.Close();
                    //Declarando váriaveis
                    string name = m.ConverText(clsMaster.TextKeyOption.TextCase, txtName.Value);
                    string lastName = m.ConverText(clsMaster.TextKeyOption.TextCase, txtLastname.Value);
                    string password = m.ConverText(clsMaster.TextKeyOption.TextCase, txtPassword.Value);
                    string ddd = selDdd.Value;
                    string cellphone = m.onlyNumbers(txtCellphone.Value);
                    string cep = m.ConverText(clsMaster.TextKeyOption.LowerCase, txtCEP.Value);
                    string address = m.ConverText(clsMaster.TextKeyOption.LowerCase, txtAddress.Value);
                    string number = m.ConverText(clsMaster.TextKeyOption.LowerCase, txtNumber.Value);
                    string complement = m.ConverText(clsMaster.TextKeyOption.LowerCase, txtComplement.Value);
                    string neighborhood = m.ConverText(clsMaster.TextKeyOption.LowerCase, txtNeighborhood.Value);
                    string city = m.ConverText(clsMaster.TextKeyOption.LowerCase, txtCity.Value);
                    string uf = m.ConverText(clsMaster.TextKeyOption.LowerCase, txtUf.Value);
                    string key = m.GenerateKey(clsMaster.KeyOptions.ShortKey);

                    sql = "";
                    sql = "INSERT INTO tb_usuario(Nome, Sobrenome, Email, Ddd, Celular, Senha, Cep, Endereco, Numero, Complemento, Bairro, Cidade, Uf,CodigoAcesso, Valido) ";
                    sql += "VALUES (";
                    sql += "'" + name + "', ";
                    sql += "'" + lastName + "', ";
                    sql += "'" + email + "', ";
                    sql += "'" + ddd + "', ";
                    sql += "'" + cellphone + "', ";
                    sql += "'" + password + "', ";
                    sql += "'" + cep + "', ";
                    sql += "'" + address + "', ";
                    sql += "'" + number + "', ";
                    sql += "'" + complement + "', ";
                    sql += "'" + neighborhood + "', ";
                    sql += "'" + city + "', ";
                    sql += "'" + uf + "',  ";
                    sql += "'" + key + "',  ";
                    sql += "'0');";

                    if (m.ExecuteSQL(sql) == true)
                    {
                        string message = "Bem vindo ao " + ConfigurationManager.AppSettings["ApplicationName"].ToString() + "! <br/>";
                        message += name + " sua conta foi criada com sucesso, para ter acesso ao sistema volte para o site e insira a chave a seguir ao logar. <br/>";
                        message += "Chave de acesso: " + key + "<br/>";

                        //Enviando e-mai
                        if (m.SendEmail(clsMaster.MailFromOptions.Support, email, "Chave de acesso", message) == true)
                        {
                            m.alertRedirect("O código de verificação foi mandado para seu e-mail, insira ele ao fazer o login para validar a conta!", "login.aspx");
                        }
                        else
                        {
                            m.alertRedirect("Contate o administrador para liberar seu acesso ao sistema!", "login.aspx");
                        }
                    }
                }
            }
        }
    }

    //Voltar para o login
    protected void Login(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}