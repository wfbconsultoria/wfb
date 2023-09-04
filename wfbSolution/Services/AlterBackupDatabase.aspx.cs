using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class AlterBackupDatabase : System.Web.UI.Page
{
    //instanciando classe master
    clsMaster m = new clsMaster();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Verificando query string
        if (Request.Params["id"] == null || Request.Params["id"].ToString() == "" || Request.Params["id"].ToString() == String.Empty)
        {
            //Redirecionando para lista
            m.alertRedirect("Erro ao carregar informações do registro", "ListPing.aspx?session=" + Request.Params["session"].ToString());
        }
        else if (!IsPostBack)
        {
            //Carregando nome dos botões
            btnUpdate.Value = ConfigurationManager.AppSettings["btnUpdate"];
            btnTestConnection.Value = ConfigurationManager.AppSettings["btnTestConnection"];
            btnReturn.InnerText = ConfigurationManager.AppSettings["btnReturn"];
            btnDelete.InnerText = ConfigurationManager.AppSettings["btnDelete"];

            //Enchendo select (Tipo de banco de dados)
            string sql = "SELECT Id, Tipo FROM tb_tipo_banco WHERE Id != '0'";
            MySqlDataReader dtr = m.ExecuteSelect(sql);
            while (dtr.Read())
            {
                ListItem listI = new ListItem();
                listI.Value = dtr["Id"].ToString();
                listI.Text = dtr["Tipo"].ToString();
                selType.Items.Add(listI);
            }
            dtr.Close();

            //Recuperando dados do registro
            sql = "SELECT Banco, Servidor, Usuario, Senha, Email_Responsavel, Destino, Tipo FROM tb_backup_banco WHERE Id = '" + Request.Params["Id"].ToString() + "';";
            dtr = m.ExecuteSelect(sql);

            if (dtr.HasRows)
            {
                //atribuindo valores
                dtr.Read();

                txtName.Value = dtr["Banco"].ToString();
                txtServer.Value = dtr["Servidor"].ToString();
                txtUser.Value = dtr["Usuario"].ToString();
                txtEmail.Value = dtr["Email_Responsavel"].ToString();
                selType.Value = dtr["Tipo"].ToString();
                txtDestiny.Value = @dtr["Destino"].ToString();

                //Senha
                txtPassword.Value = dtr["Senha"].ToString();
                txtPassword.Attributes["type"] = "password";

                //Fechar dtr
                dtr.Close();
            }
            else
            {
                //Fechar dtr
                dtr.Close();

                //erro ao restar informações
                m.alertRedirect("Erro ao resgatar informações", "ListBackupDatabase.aspx?session=" + Request.Params["session"].ToString());
            }
        }
    }

    //Alterar registro
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //Verificando se o banco já está cadastrado
        string database = m.ConverText(clsMaster.TextKeyOption.TextCase, txtName.Value);
        string sql = "SELECT Banco FROM tb_backup_banco WHERE Banco = '" + database + "' AND Id != '" + Request.Params["id"].ToString() + "';";
        MySqlDataReader dtr = m.ExecuteSelect(sql);

        if (dtr.HasRows)
        {
            //banco já cadastrado
            m.alert("Banco de dados já cadastrado");
            dtr.Close();
        }
        else
        {
            //Fechando dtr
            dtr.Close();
            //instanciando variaveis
            string email = m.ConverText(clsMaster.TextKeyOption.LowerCase, txtEmail.Value);
            int type = int.Parse(selType.Value);
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
            sql = "UPDATE tb_backup_banco SET ";
            sql += "Banco = '" + database + "', ";
            sql += "Servidor = '" + server + "', ";
            sql += "Usuario = '" + user + "', ";
            sql += "Senha = '" + password + "', ";
            sql += "Email_Responsavel = '" + email + "', ";
            sql += "Destino = '" + destiny + "', ";
            sql += "Conexao = '" + cnnStr + "', ";
            sql += "Tipo = '" + type + "' ";
            sql += "WHERE Id = '" + Request.Params["id"].ToString() + "'";

            //Alterando registro
            if (m.ExecuteSQL(sql) == true)
            {
                //cadastrado com sucesso
                m.alert("backup alterado com sucesso");
            }
            else
            {
                //erro ao cadastrar
                m.alert("Erro ao alterar backup");
            }
        }
    }

    //Testando conexão 
    protected void btnTestConnection_Click(object sender, EventArgs e)
    {
        //Verificando se foi escolhida uma opção no campo "Tipo"
        if (selType.Value == "0")
        {
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
            }
        }
    }

    //Excluir registro
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string sql = "DELETE FROM tb_backup_banco WHERE Id = '" + Request.Params["id"] + "';";

        if(m.ExecuteSQL(sql) == true)
        {
            //Registro apagado
            m.alertRedirect("Registro apagado com sucesso","ListBackupDatabase.aspx?session=" + Request.Params["session"].ToString());
        }
        else
        {
            //Erro ao apagar registro
            m.alert("Erro ao apagar registro");
        }
    }

    //Voltar
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListBackupDatabase.aspx?session=" + Request.Params["session"].ToString());
    }
}