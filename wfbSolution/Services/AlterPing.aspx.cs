using System;
using MySql.Data.MySqlClient;
using System.Configuration;

public partial class AlterPing : System.Web.UI.Page
{
    //Instanciando classe master
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
            btnDelete.Value = ConfigurationManager.AppSettings["btnDelete"];
            btnReturn.InnerText = ConfigurationManager.AppSettings["btnReturn"];            

            //Carregando informações do registro
            string sql = "SELECT Nome, Ip, Descricao, Email_responsavel FROM tb_ping WHERE Id = '" + Request.Params["id"].ToString() + "';";
            MySqlDataReader dtr = m.ExecuteSelect(sql);

            if (dtr.HasRows) {
                //Atribuindo informações do registro aos campos
                dtr.Read();

                txtName.Value = dtr["Nome"].ToString();
                txtIp.Value = dtr["Ip"].ToString();
                txtEmail.Value = dtr["Email_responsavel"].ToString();
                txtDescription.InnerText = dtr["Descricao"].ToString();

                dtr.Close();
            }
            else
            {
                //Fechando dtr
                dtr.Close();

                //Redirecionando para lista
                m.alertRedirect("Erro ao carregar informações do registro", "ListPing.aspx?session=" + Request.Params["session"].ToString());
            }
        }
    }

    //Aplicando alterações
    public void btnUpdate_Click(object sender, EventArgs e) {
        //Verificando se o IP está sendo usado
        string sql = "SELECT Ip FROM tb_ping WHERE Ip = '" + m.ConverText(clsMaster.TextKeyOption.TextCase, txtIp.Value) + "' AND Id <> '" + Request.Params["id"].ToString() + "';";
        MySqlDataReader dtr = m.ExecuteSelect(sql);

        if (dtr.HasRows)
        {
            //Fechando dtr
            dtr.Close();

            //Ip já está sendo usado
            m.alert("o endereço de IP já está sendo utilizado");
        }
        else
        {
            //Fechando dtr
            dtr.Close();
            //Montando query
            sql = "";
            sql = "UPDATE tb_ping SET ";
            sql += "Nome = '" + m.ConverText(clsMaster.TextKeyOption.TextCase, txtName.Value) + "', ";
            sql += "Ip = '" + m.ConverText(clsMaster.TextKeyOption.TextCase, txtIp.Value) + "', ";
            sql += "Email_responsavel = '" + m.ConverText(clsMaster.TextKeyOption.LowerCase, txtEmail.Value) + "', ";
            sql += "Descricao = '" + m.ConverText(clsMaster.TextKeyOption.LowerCase, txtDescription.InnerText) + "' ";
            sql += "WHERE Id = '" + Request.Params["id"].ToString() + "';";


            if (m.ExecuteSQL(sql) == true)
            {
                //Atualizado
                m.alert("Informações alteradas com sucesso");
            }
            else
            {
                //Erro ao atualizar
                m.alert("Erro ao atualizar");
            }
        }
    }

    //apagar registro
    public void btnDelete_Click(object sender, EventArgs e)
    {
        string sql = "DELETE FROM tb_ping WHERE Id = '" + Request.Params["id"].ToString() + "';";

        if (m.ExecuteSQL(sql) == true)
        {
            //apagado com succeso
            m.alertRedirect("Registro apagado com sucesso","ListPing.aspx?session=" + Request.Params["session"].ToString());
        }else
        {
            //erro ao apagar registro
            m.alert("Erro ao apagar registro");
        }
    }

    //Retornar para lista de pings
    public void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListPing.aspx?session=" + Request.Params["session"].ToString());
    }

}