using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Configuration;

public partial class BackupDatabase : System.Web.UI.Page
{
    //Instanciando classe master
    clsMaster m = new clsMaster();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Atribuindo nome ao botão
        btnBackup.Value = ConfigurationManager.AppSettings["btnBackup"].ToString();

        //Resgatando data do ultimo backup
        string sql = "SELECT Banco, Servidor, Usuario, Data FROM vw_backup_banco_log WHERE Status = 'Concluido' ORDER BY Id DESC Limit 1";
        MySqlDataReader dtr = m.ExecuteSelect(sql);

        if (dtr.HasRows)
        {
            //Se houver registro no banco
            dtr.Read();
            dvBackups.InnerHtml = "<br/> <small class='text-right text-muted'> Último backup feito em: " + dtr["Data"].ToString() + ", pelo usuário " + dtr["Usuario"].ToString() + "</small>";
        }
        else
        {
            //Se não houver registro no banco
            dvBackups.InnerHtml = "<br/> <small class='text-right text-muted'> Não houve backups feitos nesse sistema !</small>";
        }

        dtr.Close();
    }

    protected void btnBackup_Click(object sender, EventArgs e)
    {
        dvBackups.InnerHtml = "";
        //Instanciando classe master para usar dentro do dtr
        clsMaster m2 = new clsMaster();

        //Resgatando informações do usuário logado
        sessionInfo s = new sessionInfo();
        s = m.sessionInformation(clsMaster.InformationOptions.Basic);

        //Resgatando scripts de backup do banco
        string sql = "SELECT Banco, Servidor, Email_Responsavel, Destino, Conexao, Tipo FROM tb_backup_banco WHERE Ativo = 1 ";
        MySqlDataReader dtr = m.ExecuteSelect(sql);

        while (dtr.Read())
        {
            //Destino do backup
            string destiny = @dtr["Destino"].ToString();

            //Backup para MySQl
            if (dtr["Tipo"].ToString() == "1")
            {
                //Instanciando obj de conexão já com a string de conexão
                MySqlConnection objConnection = new MySqlConnection(dtr["conexao"].ToString());
                //Instanciando obj de comando ja com a conexao e o script a ser executado
                MySqlCommand objCommand = new MySqlCommand();
                objCommand.CommandTimeout = 1000;
                //Instanciando obj de backup 
                MySqlBackup objBackup = new MySqlBackup(objCommand);

                //Executando 
                try
                {
                    objCommand.Connection = objConnection;
                    objConnection.Open();
                    objBackup.ExportToFile(@destiny + dtr["Banco"].ToString() + ".sql");
                    objConnection.Close();

                    //Gravar na tabela de log as informações
                    string log = "INSERT tb_backup_banco_log(Banco, Servidor, Tipo, Usuario, Status, Descricao) VALUES (";
                    log += "'" + dtr["Banco"].ToString() + "', ";
                    log += "'" + dtr["Servidor"].ToString() + "', ";
                    log += "'" + dtr["Tipo"].ToString() + "', ";
                    log += "'" + s.Nome + " " + s.Sobrenome + "', ";
                    log += "'1', ";
                    log += "'Backup feito com sucesso');";
                    m2.ExecuteSQL(log);
                    //mostrando resultado para usuário
                    dvBackups.InnerHtml += dtr["Banco"].ToString() + ": Sucesso &nbsp <i class='fas fa-check text-success'></i> <br/><br/>";
                }
                //erro ao fazer backup
                catch (Exception ex)
                {
                    //Gravar na tabela de log as informações
                    string log = "INSERT tb_backup_banco_log(Banco, Servidor, Tipo, Usuario, Status, Descricao) VALUES (";
                    log += "'" + dtr["Banco"].ToString() + "', ";
                    log += "'" + dtr["Servidor"].ToString() + "', ";
                    log += "'" + dtr["Tipo"].ToString() + "', ";
                    log += "'" + s.Nome + " " + s.Sobrenome + "', ";
                    log += "'0', ";
                    log += "'" + m.ConverText(clsMaster.TextKeyOption.TextCase, ex.Message) + "');";

                    m2.ExecuteSQL(log);
                    //Enviando e-mail para o responsavel
                    string message = "Erro ao fazer backup do banco de dados. <br/>";
                    message += "O " + dtr["Banco"].ToString() + " não está fazendo backup, por favor verifique as configurações do script para backup. <br/>";
                    message += "Descrição do erro: <span style='color:red'>" +ex.Message + "</span> <br/>";

                    m2.SendEmail(clsMaster.MailFromOptions.Support, dtr["Email_Responsavel"].ToString(), dtr["Banco"].ToString(), message);

                    //mostrando resultado para usuário
                    dvBackups.InnerHtml += dtr["Banco"].ToString() + ": Erro &nbsp <i class='fas fa-times text-danger'></i> <br/><br/>";
                }


            }
            //Backup para SQL Server
            else
            {
                //Montar script de backup 
                string script = "BACKUP DATABASE [" + dtr["Banco"].ToString() + "] ";
                script += "TO  DISK = N'" + @destiny + dtr["Banco"].ToString() + ".bak" + "' ";
                script += "WITH NOFORMAT, INIT,  NAME = N'" + dtr["Banco"].ToString() + " Completo Banco de Dados Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                //Instanciando obj de conexão já com a string de conexão
                SqlConnection objConnection = new SqlConnection(dtr["conexao"].ToString());
                //Instaciando obj de comando já com a conexão e o script a ser executado
                SqlCommand objCommand = new SqlCommand(script, objConnection);
                objCommand.CommandTimeout = 1000;

                try
                {
                    //abrindo conexão
                    objCommand.Connection.Open();
                    //Executando comando
                    objCommand.ExecuteNonQuery();
                    //Fechando conexão
                    objCommand.Connection.Close();

                    //Gravar na tabela de log as informações
                    string log = "INSERT tb_backup_banco_log(Banco, Servidor, Tipo, Usuario, Status, Descricao) VALUES (";
                    log += "'" + dtr["Banco"].ToString() +"', ";
                    log += "'" + dtr["Servidor"].ToString() + "', ";
                    log += "'" + dtr["Tipo"].ToString() + "', ";
                    log += "'" + s.Nome + " " + s.Sobrenome + "', ";
                    log += "'1', ";
                    log += "'Backup feito com sucesso');";
                    m2.ExecuteSQL(log);
                    //mostrando resultado para usuário
                    dvBackups.InnerHtml += dtr["Banco"].ToString() + ": Sucesso &nbsp <i class='fas fa-check text-success'></i> <br/><br/>";
                }
                catch (Exception ex)
                {
                    //Fechando conexão
                    objCommand.Connection.Close();
                    //Gravar na tabela de log as informações
                    string log = "INSERT tb_backup_banco_log(Banco, Servidor, Tipo, Usuario, Status, Descricao) VALUES (";
                    log += "'" + dtr["Banco"].ToString() + "', ";
                    log += "'" + dtr["Servidor"].ToString() + "', ";
                    log += "'" + dtr["Tipo"].ToString() + "', ";
                    log += "'" + s.Nome + " " + s.Sobrenome + "', ";
                    log += "'0', ";
                    log += "'" + m.ConverText(clsMaster.TextKeyOption.TextCase,ex.Message) + "');";
                  
                    m2.ExecuteSQL(log);
                    //Enviando e-mail para o responsavel
                    string message = "Erro ao fazer backup do banco de dados. <br/>";
                    message += "O " + dtr["Banco"].ToString() + " não está fazendo backup, por favor verifique as configurações do script para backup. <br/>";

                    m2.SendEmail(clsMaster.MailFromOptions.Support, dtr["Email_Responsavel"].ToString(), dtr["Banco"].ToString(), message);

                    //mostrando resultado para usuário
                    dvBackups.InnerHtml += dtr["Banco"].ToString() + ": Erro &nbsp <i class='fas fa-times text-danger'></i> <br/><br/>";
                }
                finally
                {
                    //Encerrando obj de conexão e obj de comando
                    objConnection.Dispose();
                    objCommand.Dispose();
                }
            }
        }

        //Fechando dtr
        dtr.Close();

        dvBackups.InnerHtml += "<br/> <small class='text-right text-muted'> Atualizado em: " + DateTime.Now.ToString() + "</small>";

        //Enviando e-mail para avisar que o backup foi realizado
        string email = "<h3>Backup dos bancos de dados </h3>";
        email += dvBackups.InnerHtml;

        m.SendEmail(clsMaster.MailFromOptions.System, "vitor.santos@wfbconsultoria.com.br","Backup dos bancos de dados", email);
        m.SendEmail(clsMaster.MailFromOptions.System, "miro@wfbconsultoria.com.br", "Backup dos bancos de dados", email);
        m.SendEmail(clsMaster.MailFromOptions.System, "suporte@wfbconsultoria.com.br", "Backup dos bancos de dados", email);
        m.SendEmail(clsMaster.MailFromOptions.System, "murilo.lins@wfbconsultoria.com.br", "Backup dos bancos de dados", email);
    }
}