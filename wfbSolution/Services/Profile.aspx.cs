using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Web.UI.WebControls;

public partial class Models_Profile : System.Web.UI.Page
{
    clsMaster m = new clsMaster();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Atribuindo nome aos botões
            btnUpdate.Value = ConfigurationManager.AppSettings["btnUpdate"];
            btnReturn.InnerText = ConfigurationManager.AppSettings["btnReturn"];

            //Encher select
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

            //trazer informações do usuário
            sessionInfo s = new sessionInfo();
            s = m.sessionInformation(clsMaster.InformationOptions.All);

            txtName.Value = s.Nome;
            txtLastname.Value = s.Sobrenome;
            txtEmail.Value = s.Email;
            selDdd.Value = s.Ddd;
            txtCellphone.Value = s.Celular;
            txtCEP.Value = s.Cep;
            txtNumber.Value = s.Numero;
            txtUf.Value = s.Uf;
            txtCity.Value = s.Cidade;
            txtNeighborhood.Value = s.Bairro;
            txtAddress.Value = s.Endereco;
            txtComplement.Value = s.Complemento;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        //Verificando se o e-mail e celular já existem
        string email = m.ConverText(clsMaster.TextKeyOption.LowerCase, txtEmail.Value);
        string sql = "SELECT Email FROM tb_usuario WHERE Email = '" + email + "' AND Sessao <> '" + Request.Params["session"].ToString() + "';";
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
            sql = "SELECT Ddd, Celular FROM tb_usuario WHERE Ddd = '" + selDdd.Value + "' AND Celular = '" + m.onlyNumbers(txtCellphone.Value) + "' AND  Sessao <> '" + Request.Params["session"].ToString() + "';";
            dtr = m.ExecuteSelect(sql);

            if (dtr.HasRows)
            {
                //Celular já cadastrado
                m.alert("O Celular já esta sendo usado por outro usuário");
                txtCellphone.Focus();
            }
            else
            {

                //Declarando variaveis
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

                //Montando update
                sql = "";
                sql = "UPDATE tb_usuario SET ";
                sql += "Nome = '" + name + "', ";
                sql += "Sobrenome = '" + lastName + "', ";
                sql += "Email = '" + email + "', ";
                sql += "Ddd = '" + ddd + "', ";
                sql += "Celular = '" + cellphone + "', ";
                sql += "Cep = '" + cep + "', ";
                sql += "Endereco = '" + address + "', ";
                sql += "Numero = '" + number + "', ";
                sql += "Complemento = '" + complement + "', ";
                sql += "Bairro = '" + neighborhood + "', ";
                sql += "Cidade = '" + city + "', ";

                //Verificando se o usuário desejou trocar a senha
                if (txtPassword.Value != "" || txtNewPassword.Value != "" || txtConfirmPassword.Value != "")
                {
                    //Verificando se a senha atual foi preenchida
                    if (txtPassword.Value == "")
                    {
                        m.alert("Insira sua senha atual");
                        txtPassword.Focus();
                    }
                    //Verificando se a nova senha foi preenchida
                    else if (txtNewPassword.Value == "")
                    {
                        m.alert("Insira sua nova senha");
                        txtPassword.Focus();
                    }
                    //Verificando se a confirmação de senha foi preenchida
                    else if (txtConfirmPassword.Value == "")
                    {
                        m.alert("Confirme sua nova senha");
                        txtPassword.Focus();
                    }
                    //Verificando se a confirmação de senha está certa
                    else if (txtConfirmPassword.Value != txtNewPassword.Value)
                    {
                        m.alert("Confirmação de senha errada, verifique se digitou corretamente");
                        txtPassword.Focus();
                    }
                    //Verificando se a senha antiga coincide
                    else
                    {
                        //Fechando dtr
                        dtr.Close();

                        //Montando query para verificar senha antiga
                        sql = "";
                        sql = "SELECT Senha FROM tb_usuario WHERE Sessao = '" + Request.Params["session"].ToString() + "' AND Senha = '" + m.ConverText(clsMaster.TextKeyOption.TextCase,txtPassword.Value) + "';";

                        dtr = m.ExecuteSelect(sql);

                        if (dtr.HasRows)
                        {
                            //Fechando data reader
                            dtr.Close();
                            //alterando senha do usuário
                            sql = "";
                            sql = "UPDATE tb_usuario SET Senha = '" + m.ConverText(clsMaster.TextKeyOption.TextCase, txtPassword.Value) + "' WHERE Sessao = '" + Request.Params["session"].ToString() + "';";

                            if (m.ExecuteSQL(sql) == true) {
                                //sucesso
                                m.alert("Informações alteradas com sucesso!");
                            }else
                            {
                                //erro
                                m.alert("Erro ao atualizar senha!");
                            }
                        }
                        else
                        {
                            //Fechando data reader
                            dtr.Close();
                            //Mensagem
                            m.alert("Senha atual inválida");
                            txtPassword.Focus();
                        }

                    }
                }
                else
                {
                    dtr.Close();
                    //Não alterar a senha 
                    sql += "Uf = '" + uf + "' ";
                    sql += "WHERE Sessao = '" + Request.Params["session"].ToString() + "';";
                    m.alert(sql);
                    if (m.ExecuteSQL(sql) == true)
                    {
                        m.alertRedirect("Informações alteradas com sucesso!", "profile.aspx?session=" + Request.Params["session"].ToString());
                    }
                }
            }
            dtr.Close();
        }
    }

    public void btnReturn_Click(Object sender, EventArgs e)
    {
        //retornar ao principal
        Response.Redirect("Index.aspx?session="+ Request.Params["session"].ToString());
    }
}