using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class RegisterBackupDatabase : System.Web.UI.Page
{
    //instanciando classe master
    clsMaster m = new clsMaster();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Carregando nome dos botões
        btnRegister.Value = ConfigurationManager.AppSettings["btnRegister"];
        btnTestConnection.Value = ConfigurationManager.AppSettings["btnTestConnection"];
        btnReturn.InnerText = ConfigurationManager.AppSettings["btnReturn"];

        //Encher select
        if (!IsPostBack)
        {
            string sql = "SELECT Id, Tipo FROM tb_tipo_banco";
            MySqlDataReader dtr = m.ExecuteSelect(sql);
            while (dtr.Read())
            {
                ListItem listI = new ListItem();
                listI.Value = dtr["Id"].ToString();
                listI.Text = dtr["Tipo"].ToString();
                selType.Items.Add(listI);
            }
            dtr.Close();
        }
    }
    
    //Cadastrando registro
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        //Verificando se o "Tipo" de banco de dados foi selecionado
        if (selType.Value == "0")
        {
            m.alert("Selecione o tipo de banco de dados");
            selType.Focus();
        }
        else
        {
            //Verificando se o banco já está cadastrado
            string name = m.ConverText(clsMaster.TextKeyOption.TextCase, txtName.Value);
            string sql = "SELECT Banco FROM tb_backup_banco WHERE Banco = '" + name + "'";
            MySqlDataReader dtr = m.ExecuteSelect(sql);

            if (dtr.HasRows)
            {
                //Banco de dados já cadastrado
                m.alert("Banco de dados já está cadastrado para backup");

                //Fechando dtr
                dtr.Close();
            }
            else
            {
                //Fechando dtr
                dtr.Close();

                //instanciando restante das variaveis
                string email = m.ConverText(clsMaster.TextKeyOption.LowerCase, txtEmail.Value);
                int type = int.Parse(selType.Value);
                string database = m.ConverText(clsMaster.TextKeyOption.TextCase, txtName.Value);
                string server = m.ConverText(clsMaster.TextKeyOption.TextCase, txtServer.Value);
                string user = m.ConverText(clsMaster.TextKeyOption.TextCase, txtUser.Value);
                string password = m.ConverText(clsMaster.TextKeyOption.TextCase, txtPassword.Value);
                string cnnStr = "";
                //Montando caminho para que não conflite no banco
                string destiny = txtDestiny.Value.Replace("'", "");
                destiny = destiny.Replace("\\", "\\\\") + @"\\";


                //montando query de conexão de acordo com o tipo selecionado
                if (type == 1)
                {
                    //MySQL
                    cnnStr = "Server=" + server + ";";
                    cnnStr += "Database=" + database + ";";
                    cnnStr += "Uid=" + user + ";";
                    cnnStr += "Pwd=" + password + ";";
                    cnnStr += "pooling=false";
                }
                else
                {
                    //SQL Server
                    cnnStr = "Data Source=" + server + ";";
                    cnnStr += "Initial Catalog=" + database + ";";
                    cnnStr += "Persist Security Info=True;";
                    cnnStr += "User ID=" + user + ";";
                    cnnStr += "Password=" + password + ";";
                    cnnStr += "MultipleActiveResultSets=True";
                }

                //Montando query para salvar no banco
                sql = "";
                sql = "INSERT INTO tb_backup_banco(Banco, Servidor, Usuario, Senha, Email_Responsavel, Destino, Conexao, Tipo) ";
                sql += "VALUES (";
                sql += "'" + database + "', ";
                sql += "'" + server + "', ";
                sql += "'" + user + "', ";
                sql += "'" + password + "', ";
                sql += "'" + email + "', ";
                sql += "'" + @destiny + "', ";
                sql += "'" + cnnStr + "', ";
                sql += "'" + type + "');";

                //Salvando no banco de dados
                if (m.ExecuteSQL(sql) == true)
                {
                    //cadastrado com sucesso
                    m.alertRedirect("Backup cadastrado com sucesso", "ListBackupDatabase.aspx?session=" + Request.Params["session"].ToString());
                }
                else
                {
                    //erro ao cadastrar
                    m.alert("Erro ao cadastrar backup");
                }
            }
        }
    }

    //Testando conexão 
    protected void btnTestConnection_Click(object sender, EventArgs e)
    {
        //Verificando se foi escolhida uma opção no campo "Tipo"
        if (selType.Value == "0") {
            m.alert("Escolha o tipo de banco de dados");
            selType.Focus();
        }
        //Banco de dados MySQL
        else if (selType.Value == "1")
        {
            //String de conexão
            string strMySQL = "Server=" + m.ConverText(clsMaster.TextKeyOption.TextCase, txtServer.Value) + ";";
            strMySQL += "Database=" + m.ConverText(clsMaster.TextKeyOption.TextCase, txtName.Value) + ";";
            strMySQL += "Uid=" + m.ConverText(clsMaster.TextKeyOption.TextCase, txtUser.Value) + ";";
            strMySQL += "Pwd=" + m.ConverText(clsMaster.TextKeyOption.TextCase, txtPassword.Value) + ";";
            strMySQL += "pooling=false";

            //Função de conexao
            MySqlConnection cnnMySQL = new MySqlConnection(strMySQL);

            try
            {
                //Abrindo conexao
                cnnMySQL.Open();
                //Conexão estabelecida
                m.alert("Conexão estabelecida com sucesso!");
            }
            catch (Exception ex)
            {
                //erro ao conectar
                m.alert("Erro ao conectar");
            }
            finally
            {
                //Fechando conexao
                cnnMySQL.Close();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "document.getElementById('Body_Content_txtPassword').value = '" + m.ConverText(clsMaster.TextKeyOption.TextCase, txtPassword.Value) + "';", true);
            }
        }
        //Banco de dados SQL Server
        else if (selType.Value == "2")
        {
            //String de conexão
            string strSQL = "Data Source=" + m.ConverText(clsMaster.TextKeyOption.TextCase, txtServer.Value) + ";";
            strSQL += "Initial Catalog=" + m.ConverText(clsMaster.TextKeyOption.TextCase, txtName.Value) + ";";
            strSQL += "Persist Security Info=True;";
            strSQL += "User ID=" + m.ConverText(clsMaster.TextKeyOption.TextCase, txtUser.Value) + ";";
            strSQL += "Password=" + m.ConverText(clsMaster.TextKeyOption.TextCase, txtPassword.Value) + ";";
            strSQL += "MultipleActiveResultSets=True";

            //Função de conexao
            SqlConnection cnnSQL = new SqlConnection(strSQL);

            try
            {
                //Abrindo conexao
                cnnSQL.Open();
                //Conexão estabelecida
                m.alert("Conexão estabelecida com sucesso!");
            }
            catch (Exception ex)
            {
                //erro ao conectar
                m.alert("Erro ao conectar");
            }
            finally
            {
                //Fechando conexao
                cnnSQL.Close();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "document.getElementById('Body_Content_txtPassword').value = '" + m.ConverText(clsMaster.TextKeyOption.TextCase, txtPassword.Value) + "';", true);
            }
        }
    }

    //Voltar
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListBackupDatabase.aspx?session=" + Request.Params["session"].ToString());
    }
}