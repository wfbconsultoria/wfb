using MySql.Data.MySqlClient;
using System;
using System.Configuration;

public partial class RegisterPing : System.Web.UI.Page
{
    clsMaster m = new clsMaster();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Carregando nome dos botões
        btnRegister.Value = ConfigurationManager.AppSettings["btnRegister"];
        btnReturn.InnerText = ConfigurationManager.AppSettings["btnReturn"];
    }

    //Cadastrando ping
    public void btnRegister_Click(object sender, EventArgs e)
    {
        //Verificando se o IP já foi cadastrado
        string ip = m.ConverText(clsMaster.TextKeyOption.LowerCase, txtIp.Value);
        string sql = "SELECT Ip FROM tb_ping WHERE Ip = '" + ip + "';";
        MySqlDataReader dtr = m.ExecuteSelect(sql);

        if (dtr.HasRows)
        {
            //A máquina já está cadastrada
            m.alert("A máquina já está cadastrada");
            txtIp.Focus();
        }else
        {
            //Cadastrando máquina
            dtr.Close();

            string name = m.ConverText(clsMaster.TextKeyOption.TextCase, txtName.Value);
            string description = m.ConverText(clsMaster.TextKeyOption.TextCase, txtDescription.InnerText);
            string email = m.ConverText(clsMaster.TextKeyOption.TextCase, txtEmail.Value);

            sql = "";
            sql = "INSERT INTO tb_ping (Nome, Ip, Descricao, Email_responsavel, Ativo) VALUES (";
            sql += "'" + name + "', ";
            sql += "'" + ip + "', ";
            sql += "'" + description + "', ";
            sql += "'" + email + "', ";
            sql += "'1'); ";

            if (m.ExecuteSQL(sql) == true) {
                //Ping cadastrado
                m.alertRedirect("Ping cadastrado com sucesso", "ListPing.aspx?session=" + Request.Params["session"].ToString());
            }
            else
            {
                //Erro ao cadastrar ping
                m.alert("Erro ao cadastrar ping");
            }
        }

        //Fechando data reader
        dtr.Close();
    }

    //Voltar
    public void btnReturn_Click(object sender, EventArgs e)
    {
        //Carregando nome dos botões
        Response.Redirect("listPing.aspx?session=" + Request.Params["session"].ToString());
    }
}