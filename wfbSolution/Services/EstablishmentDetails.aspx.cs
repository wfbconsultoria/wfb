using svcCDC;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EstablishmentDetails : System.Web.UI.Page
{
    //Instanciando classe master
    clsMaster m = new clsMaster();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Atribuindo nome aos botões     
        btnReturn.InnerText = ConfigurationManager.AppSettings["btnReturn"];

        //Verificando a query string
        if (Request.Params["documento"] == null || Request.Params["documento"].ToString() == "")
        {
            m.alertRedirect("Erro ao verificar documento", "Establishment.aspx?session=" + Request.Params["session"].ToString());
        }
        else if (m.onlyNumbers(Request.Params["documento"].ToString()).Length != 14)
        {
            m.alertRedirect("Número de documento inválido", "Establishment.aspx?session=" + Request.Params["session"].ToString());
        }
        else
        {
            //Consultando no SOA
            //Instanciando classes a serem usadas
            CDCSoapClient objCdc = new CDCSoapClient();
            Credenciais objCredenciais = new Credenciais();
            PessoaJuridicaNFe objRetorno = new PessoaJuridicaNFe();

            //Configurando credenciais
            objCredenciais.Email = "miro@wfbconsultoria.com.br";
            objCredenciais.Senha = "mepm2412!";

            try
            {
                //Usando serviço do SOA
                objRetorno = objCdc.PessoaJuridicaNFe(objCredenciais, m.onlyNumbers(Request.Params["documento"].ToString()));

                //Atribuindo valores as labels
                lblRazaoSocial.InnerText = objRetorno.RazaoSocial;
                lblNomeFantasia.InnerText = objRetorno.NomeFantasia;
                lblDocumento.InnerText = objRetorno.Documento;
                lblCapital.InnerText = objRetorno.Capital;
                lblDataFundacao.InnerText = objRetorno.DataFundacao;
                lblCodNatJuridica.InnerText = objRetorno.CodigoNaturezaJuridica;
                lblDesNatJuridica.InnerText = objRetorno.CodigoNaturezaJuridicaDescricao;
                lblSituacaoRFB.InnerText = objRetorno.SituacaoRFB;
                lblDataSitRFB.InnerText = objRetorno.DataSituacaoRFB;
                lblConSitRFB.InnerText = objRetorno.DataConsultaRFB;
                lblMotSitRFB.InnerText = objRetorno.MotivoEspecialSituacaoRFB;
                lblDataMotEspSitRFB.InnerText = objRetorno.DataMotivoEspecialSituacaoRFB;
                lblCodCNAE.InnerText = objRetorno.CodigoAtividadeEconomica;
                lblDesCNAE.InnerText = objRetorno.CodigoAtividadeEconomicaDescricao;
                lblTelefone.InnerText = objRetorno.Telefone;
                lblEmail.InnerText = objRetorno.Email;
                lblStatus.InnerText = objRetorno.Status.ToString();

                //Resgatando Endereço
                foreach (Endereco2 item in objRetorno.Enderecos) {
                    lblTipo.InnerText = item.Tipo.ToString();
                    lblNumero.InnerText = item.Numero;
                    lblLogradouro.InnerText = item.Logradouro;
                    lblComplemento.InnerText = item.Complemento;
                    lblBairro.InnerText = item.Bairro;
                    lblCidade.InnerText = item.Cidade;
                    lblEstado.InnerText = item.Estado;
                    lblCep.InnerText = item.CEP;
                    lblCodIbge.InnerText = item.CodigoIBGE.ToString();
                    lblDataAtualizacao.InnerText = item.DataAtualizacao.ToString();

                    //Longitude & Latitude
                    lblLatitude.InnerText = item.GeoLocalizacao.Latitude.ToString();
                    lblLongitude.InnerText = item.GeoLocalizacao.Longitude.ToString();
                }
                
            }
            catch
            {
                m.alert("Erro ao consultar estabelecimento");
            }
        }
    }

    //Retornar para as pesquisas
    public void btnReturn_Click(Object sender, EventArgs e)
    {
        Response.Redirect("Establishment.aspx?session=" + Request.Params["session"].ToString());
    }
}