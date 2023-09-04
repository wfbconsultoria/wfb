using System;

public partial class ErrorPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Resgatando informações do erro

        //Nome do erro
        lblErrNumber.InnerText = Request.Params["errNumber"].ToString();
        lblErrName.InnerText = Request.Params["errName"].ToString();

        //Descrição
        lblErrDescription.InnerText = Request.Params["errDescription"].ToString();

        //Local
        lblErrLocation.InnerText = Request.Params["errLocation"].ToString();
    }
}