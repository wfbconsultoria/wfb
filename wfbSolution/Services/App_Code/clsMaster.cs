using System;
using System.Configuration;
using System.Web;
//using System.Data.SqlClient;
using System.Net.Mail;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

//Clase que contém as funções mais usadas ao decorrer da aplicação

public class clsMaster
{
    // Banco de Dados ---------------------------------------------------------------------------------------------

    // String de conexão 
    string cnnStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString.ToString();
    MySqlConnection CNN;

    //Função para abrir e verificar conexão
    public void DatabaseConnect()
    {
        try
        {
            //Se a CNN Estiver vazia
            if (CNN == null)
            {
                CNN = new MySqlConnection(cnnStr);
                CNN.Open();
            }
            //Se a CNN não estiver aberta
            else if (CNN.State != System.Data.ConnectionState.Open)
            {
                CNN.Open();
            }
        }
        catch (Exception ex)
        {
            //Caso houver erro em abrir a conexão
            SystemError("0001", "Falha ao abrir conexão", ex.Message, "clsMaster: DatabaseConect()");
        }
    }

    //Função para executar query no banco
    public bool ExecuteSQL(string SQL)
    {
        try
        {
            //Verificando se a conexão está aberta
            DatabaseConnect();
            //Instanciando e executando comando
            MySqlCommand CMD = new MySqlCommand(SQL, CNN);
            CMD.ExecuteNonQuery();
            CMD.Dispose();
            return true;
        }
        catch (Exception ex)
        {
            SystemError("0002", "Falha ao executar query", ex.Message, "clsMaster: ExecuteSQL()");
            return false;
        }
    }

    //Função para ler a base de dados
    public MySqlDataReader ExecuteSelect(string SQL)
    {
        try
        {
            //Verificando se a conexão está aberta
            DatabaseConnect();
            //Instanciando e executando comando
            MySqlCommand CMD = new MySqlCommand(SQL, CNN);
            return CMD.ExecuteReader();
        }

        catch (Exception ex)
        {
            SystemError("0003", "Falha ao executar select", ex.Message, "clsMaster: ExecuteSelect()");
            return null;
        }
    }

    //Outras funções ---------------------------------------------------------------------------------------------------------------------

    //Função para erros
    public void SystemError(string errNumber, string errName, string errDescription, string errLocation) {
        string urlError = "";
        urlError = "errNumber=" + errNumber + "&errName=" + errName + "&errDescription=" + errDescription + "&errLocation=" + errLocation;
        urlError = urlError.Replace("\r", " ");
        urlError = urlError.Replace("\n", " ");
        HttpContext.Current.Response.Redirect(HttpContext.Current.Request.ApplicationPath + "/ErrorPage.aspx?" + urlError);
    }

    //Função para mandar E-mail
    public bool SendEmail(MailFromOptions mailFrom, string MailTo, string Subject, string MailDescription) {
        //Instanciando variaveis
        SmtpClient objSmtp = new SmtpClient();
        MailMessage objEmail = new MailMessage();
        string mailSignature = "", mailFromName = "", html = "";

        //Definir o nome de quem está enviando a mensagem
        mailFromName = ConfigurationManager.AppSettings["ApplicationName"] + " - ";
        if (mailFrom == MailFromOptions.System) { mailFromName += ConfigurationManager.AppSettings["Mail.Name.System"].ToString(); }
        if (mailFrom == MailFromOptions.Support) { mailFromName += ConfigurationManager.AppSettings["Mail.Name.Support"].ToString(); }
        if (mailFrom == MailFromOptions.Security) { mailFromName += ConfigurationManager.AppSettings["Mail.Name.Security"].ToString(); }

        //Montando assinatura do E-mail
        mailSignature = "<br/> <br/>";
        mailSignature += "Site: " + ConfigurationManager.AppSettings["ApplicationURL"].ToString() + "<br/>";
        mailSignature += "Mensagem enviada automaticamente por ";
        mailSignature += mailFromName;
        mailSignature += ", por favor não responda este e-mail. ";


        //Montando html do e-mail        
        html = "<html>";
        //Cabeçalho
        html += "   <head>";
        html += "		<meta charset='utf - 8'>";
        html += "		<title>" + ConfigurationManager.AppSettings["ApplicationName"].ToString() + "</title>";
        html += "       <style>";
        html += "               .conteudo,.rodape,.title{padding:20px}body{font-family:arial}.container{width:100%;border-radius:20px;background-color:#f2f2f2;max-width: 800px;margin: 0 auto;}.title{color:#fff;background-color:#80bdff;border-top-left-radius:20px;border-top-right-radius:20px}.conteudo{min-height:250px}.rodape{text-align:center;border-top:1px solid rgba(0,0,0,.05);margin-bottom:0}";
        html += "       </style>";
        html += "	</head>";
        //Corpo
        html += "	<body>";
        html += "		<div class='container'>";
        html += "			<h3 class='title'>" + ConfigurationManager.AppSettings["ApplicationName"].ToString() + "</h3>";
        html += "			<div class='conteudo'>";
        html += "				<p>" + MailDescription + mailSignature + "</p>";
        html += "			</div>";
        html += "			<div class='rodape'>";
        html += "					<small> &copy " + ConfigurationManager.AppSettings["Developer"].ToString() + " - " + DateTime.Now.Year + "</small>";
        html += "			</div>";
        html += "		</div>";
        html += "	</body>";
        html += "</html>";

        //Configurações do E-mail
        objEmail.From = new MailAddress(ConfigurationManager.AppSettings["Mail"].ToString(), mailFromName);
        objEmail.Subject = Subject;
        objEmail.Body = html;
        objEmail.Priority = MailPriority.Normal;
        objEmail.IsBodyHtml = true;
        objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
        objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
        objEmail.To.Add(MailTo);

        //Enviando E-mail
        try
        {
            System.Net.NetworkCredential objCredentials = new System.Net.NetworkCredential();
            objCredentials.Password = ConfigurationManager.AppSettings["Mail.SMTP.Password"].ToString();
            objCredentials.UserName = ConfigurationManager.AppSettings["Mail.SMTP.UserName"].ToString();
            objSmtp.UseDefaultCredentials = false;
            objSmtp.Credentials = objCredentials;
            objSmtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            objSmtp.EnableSsl = true;
            objSmtp.Port = int.Parse(ConfigurationManager.AppSettings["Mail.SMTP.Port"].ToString());
            objSmtp.Host = ConfigurationManager.AppSettings["Mail.SMTP.Host"].ToString();
            objSmtp.Send(objEmail);
            return true;
        }
        catch (Exception ex) {
            SystemError("0004", "Falha ao enviar E-mail", ex.Message, "clsMaster: SendEmail()");
            return false;
        }
    }

    //Função para limpar caracteres
    public string ConverText(TextKeyOption textCase, string text)
    {
        //Verificando se a váriavel esta vazia
        if (text.Replace(" ", "") == "" || text == string.Empty)
        {
            text = "";
        }

        //Removendo caracteres
        if (text != "")
        {
            text = text.Trim();
            text = text.Replace("á", "a");
            text = text.Replace("â", "a");
            text = text.Replace("ã", "a");
            text = text.Replace("é", "e");
            text = text.Replace("ê", "e");
            text = text.Replace("è", "e");
            text = text.Replace("í", "i");
            text = text.Replace("ì", "i");
            text = text.Replace("ó", "o");
            text = text.Replace("ò", "o");
            text = text.Replace("ô", "o");
            text = text.Replace("õ", "o");
            text = text.Replace("ú", "u");
            text = text.Replace("ù", "u");
            text = text.Replace("û", "u");
            text = text.Replace("ç", "c");
            text = text.Replace("~", "");
            text = text.Replace("^", "");
            text = text.Replace("'", "");
            text = text.Replace("\n", "");
            text = text.Replace("\r", "");

            //Verificando a formatação que o texto deve voltar
            if (textCase == TextKeyOption.LowerCase) { text.ToLower(); }
            if (textCase == TextKeyOption.UpperCase) { text.ToUpper(); }
            text = text.Trim();
        }

        return text;
    }

    //Função para deixar apenas números
    public string onlyNumbers(string textcontent){
        string resultString = string.Empty;

        // Função para deixar apenas números
        Regex objRegex = new Regex(@"[^\d]");
        resultString = objRegex.Replace(textcontent, "");

        return resultString;
    }

    //Função para mandar alertas em javascript
    public void alert(string textcontent) {
        string script = "<script type='text/javascript'>alert('" + textcontent + "');</script>";
        HttpContext.Current.Response.Write(script);
    }

    //Função para mandar alertas e redirecionar com javascript
    public void alertRedirect(string textcontent, string page)
    {
        string script = "<script type='text/javascript'>alert('" + textcontent + "');window.location.href='" + page + "'</script>";
        HttpContext.Current.Response.Write(script);
    }

    //Gerar chaves
    public string GenerateKey(KeyOptions keyOption)
    {
        //Declarando variaveis
        int keyLenght = 0;
        int[] numbers = new int[10];
        string[] letters = new string[26];
        string key = "";
        Random rdn = new Random();
        //Atribuindo números de zero a nove
        for (int cont = 0; cont <= 9; cont++)
        {
            numbers[cont] = cont;
        }
        //Atribuindo letras de A a Z
        letters[0] = "A";
        letters[1] = "B";
        letters[2] = "C";
        letters[3] = "D";
        letters[4] = "E";
        letters[5] = "F";
        letters[6] = "G";
        letters[7] = "H";
        letters[8] = "I";
        letters[9] = "J";
        letters[10] = "K";
        letters[11] = "L";
        letters[12] = "M";
        letters[13] = "N";
        letters[14] = "O";
        letters[15] = "P";
        letters[16] = "Q";
        letters[17] = "R";
        letters[18] = "S";
        letters[19] = "T";
        letters[20] = "U";
        letters[21] = "V";
        letters[22] = "X";
        letters[23] = "W";
        letters[24] = "Y";
        letters[25] = "Z";

        //Determinando o tamanho da chave
        if (keyOption == KeyOptions.LongKey) { keyLenght = 16; };
        if (keyOption == KeyOptions.MediumKey) { keyLenght = 8; };
        if (keyOption == KeyOptions.ShortKey) { keyLenght = 4; };

        //Montando chave
        for (int i = 0; i <= keyLenght; i++)
        {
            key += numbers[rdn.Next(10)];
            key += letters[rdn.Next(26)];
        }

        return key;
    }

    //Função para criar chave da sessão
    public string createSession(string userEmail) {
        string session = string.Empty;
        //Resgatar Id do usuário de acordo com e-mail
        string sql = "SELECT Id FROM tb_usuario WHERE Email = '" + ConverText(TextKeyOption.LowerCase,userEmail) + "';";
        MySqlDataReader dtr = ExecuteSelect(sql);
        if (dtr.HasRows)
        {
            dtr.Read();
            //Gerando chave
            session = GenerateKey(KeyOptions.MediumKey);
            session += "_";
            session += dtr["Id"].ToString();
            //Gravando sessão no registro do usuário
            sql = "";
            sql = "UPDATE tb_usuario SET Sessao = '" + session +  "', UltimoAcesso = '" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "' WHERE Id = '" + dtr["Id"].ToString() + "';";
            //Fechando dtr
            dtr.Close();

            //Gravando sessão no registro do usuário
            if (ExecuteSQL(sql) == true)
            {                
                return session;
            }
            else
            {
                SystemError("0006", "Erro ao gravar sessão", "Ocorreu um erro ao gravar a sessão do usuário na base de dados", "clsMaster: createSession();");
                return string.Empty;
            }
        }
        else
        {            
            SystemError("0005", "Erro ao iniciar Sessão", "Ocorreu um erro ao resgatar código de identificação do usuário na base de dados", "clsMaster: createSession();");
            return string.Empty;
        }
    }

    //Função para validar se a sessão está ativa
    public bool validateSession() {
        //Resgatando sessão atual
        string session = HttpContext.Current.Request.Params["session"].ToString();
        //Montando query
        string sql = "SELECT UltimoAcesso FROM tb_usuario WHERE Sessao = '" + ConverText(TextKeyOption.TextCase, session) + "'";
        MySqlDataReader dtr = ExecuteSelect(sql);

        //Validando
        if (dtr.HasRows) {
            dtr.Close();
            return true;
        }else
        {
            dtr.Close();
            return false;
        }
    }

    //Informações da sessão
    public sessionInfo sessionInformation(InformationOptions infoOption)
    {
        //Resgatando sessão
        string session = HttpContext.Current.Request.Params["session"].ToString();
        //Montando select
        string sql = "SELECT ";
        //Verificando o tipo de informação
        if (infoOption == InformationOptions.Basic){ sql += "Nome, Sobrenome, Email, Ddd, Celular, UltimoAcesso"; };
        if (infoOption == InformationOptions.All) { sql += "Nome, Sobrenome, Email, Ddd, Celular, Cep, Endereco, Numero, Complemento, Bairro, Cidade, Uf, UltimoAcesso"; };
        sql += " FROM tb_usuario WHERE Sessao = '" + session +"';";

        //Criando o objeto de retorno
        sessionInfo s = new sessionInfo();

        //Executando select
        MySqlDataReader dtr = ExecuteSelect(sql);

        if (dtr.HasRows)
        {
            dtr.Read();

            //atribuindo
            s.Nome = dtr["Nome"].ToString();
            s.Sobrenome = dtr["Sobrenome"].ToString();
            s.Email = dtr["Email"].ToString();
            s.Ddd = dtr["Ddd"].ToString();
            s.Celular = dtr["Celular"].ToString();
            s.Ip = HttpContext.Current.Request.UserHostAddress;
            s.UltimoAcesso = dtr["UltimoAcesso"].ToString();

            if (infoOption == InformationOptions.All)
            {
                s.Cep = dtr["Cep"].ToString();
                s.Endereco = dtr["Endereco"].ToString();
                s.Numero = dtr["Numero"].ToString();
                s.Complemento = dtr["Complemento"].ToString();
                s.Bairro = dtr["Bairro"].ToString();
                s.Cidade = dtr["Cidade"].ToString();
                s.Uf = dtr["Uf"].ToString();
            };

            dtr.Close();
            return s;
        }
        else
        {
            dtr.Close();
            //Erro ao resgatar sessão
            alertRedirect("Sessão expirada, realize o login novamente","Account/Login.aspx");
            return s;
        }
    } 

    //Funcão para validar dominio
    public bool validateDomain(string email)
    {
        int size = email.Length;
        char[] chars = email.ToCharArray();
        bool domain = false;
        email = "";

        //Lendo campos do array
        for (int cont = 0; cont < size; cont++)
        {
            //Verificando o @
            if (chars[cont].ToString() == "@")
            {
                domain = true;
            }

            if (domain == true)
            {
                email += chars[cont].ToString();
            }
        }

        //Se não encontrar o @ retorna falso
        if (domain == false)
        {
            return false;
        }else
        {
            //Verificando se o domínio é válido
            string sql = "SELECT dominio FROM tb_dominios WHERE dominio = '" + email + "'";
            MySqlDataReader dtr = ExecuteSelect(sql);

            if (dtr.HasRows)
            {
                dtr.Close();
                return true;
            }
            else
            {
                dtr.Close();
                return false;
            }
        }
    }

    // Enum para funções -----------------------------------------------------------------------------------------------------------------

    //Envio de e-mail
    public enum MailFromOptions { System, Support, Security };

    //Formatação de texto
    public enum TextKeyOption { UpperCase, LowerCase, TextCase };

    //Criação de chaves
    public enum KeyOptions { ShortKey, MediumKey, LongKey };

    //Informações da sessão
    public enum InformationOptions { Basic, All }

}

//Classe que servirá como referencia pra resgatar informações da sessão
public class sessionInfo
{
    public string Nome = "", Sobrenome = "", Email = "", Ddd = "", Celular = "", Cep = "", Endereco = "", Numero = "", Complemento = "", Bairro = "", Cidade = "", Uf = "", UltimoAcesso = "", Ip = "";
}
