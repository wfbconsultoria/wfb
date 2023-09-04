using System;
using svcCDC;
public partial class Establishment : System.Web.UI.Page
{
    clsMaster m = new clsMaster();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //Validar 
    public void btnSearch_Click(object sender, EventArgs e)
    {
        //Verificando a quantidade de digitos
        string documento = m.onlyNumbers(txtCnpj.Value);
        if (documento.Length != 14) {
            m.alert("Informe um CNPJ Válido");
        } else
        {
            Response.Redirect("EstablishmentDetails.aspx?session=" + Request.Params["session"].ToString() + "&documento=" + documento);
        }
    }
}