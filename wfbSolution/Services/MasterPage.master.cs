using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    clsMaster m = new clsMaster();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["session"] == null)
        {
            //verificando se a sessão está na query string
            m.alertRedirect("Sessão expirada realize o login novamente", "Account/Login.aspx");
        }
        else if (Request.Params["session"].ToString() == String.Empty || Request.Params["session"].ToString() == "")
        {
            //verificando se a sessão está vazia
            m.alertRedirect("Sessão expirada realize o login novamente", "Account/Login.aspx");
        }
        else
        {
            //verificando se a sessão está ativa
            if (m.validateSession() == false)
            {
                m.alertRedirect("Sessão expirada realize o login novamente", "Account/Login.aspx");
            }
            else
            {
                //Resgatando nome do usuário
                sessionInfo s = new sessionInfo();
                s = m.sessionInformation(clsMaster.InformationOptions.Basic);
                lblUser.InnerText = s.Nome;
            }
        }
    }
}
