using MySql.Data.MySqlClient;
using System;
using System.Net.NetworkInformation;

public partial class Index : System.Web.UI.Page
{
    //Instanciando classe master
    clsMaster m = new clsMaster();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Esvaziando div 
        dvServidores.InnerHtml = "";
        //Instanciando classe de ping
        Ping p = new Ping();
        PingReply pr;

        //Regatando ip´s da base de dados
        string sql = "SELECT Nome, Ip, Descricao, Email_responsavel FROM tb_ping WHERE Ativo = '1'";
        MySqlDataReader dtr = m.ExecuteSelect(sql);

        if (dtr.HasRows)
        {
            while (dtr.Read())
            {
                //Executando ping
                pr = p.Send(dtr["Ip"].ToString());

                if (pr.Status == IPStatus.Success)
                {
                    //Servidor funcionando
                    dvServidores.InnerHtml += dtr["Nome"].ToString() + ": Funcionando <i class='fas fa-check text-success'></i> <br/><br/>";
                }
                else
                {
                    //Servidor fora do ar
                    dvServidores.InnerHtml += dtr["Nome"].ToString() + ": Indisponível <i class='fas fa-times text-danger'></i> <br/><br/>";
                    //Enviando e-mail para o responsavel
                    string message = "Servidor Indisponível <br/>";
                    message += "O " + dtr["Nome"].ToString() + " esta indisponível, por favor verifique as configurações do servidor. <br/>";
                    message += "Esta mensagem será enviada até o servidor retornar a normalidade <br/>";

                    m.SendEmail(clsMaster.MailFromOptions.Support, dtr["Email_responsavel"].ToString(), dtr["Nome"].ToString(), message);
                }
            }
            dtr.Close();
        }
        else
        {
            //Erro ao resgatar ip´s
            dvServidores.InnerHtml = "<strong class='text-danger'>Erro ao resgatar ip´s da base de dados!</strong><br/>";
        }

        //Recuperando data da ultima atualização
        dvServidores.InnerHtml += "<br/> <small class='text-right text-muted'> Atualizado em: " + DateTime.Now.ToString() + "</small>";

        //liberando recursos do ping
        p.Dispose();
    }
}