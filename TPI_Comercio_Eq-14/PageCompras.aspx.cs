using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Comercio_Eq_14
{
    public partial class PageCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ComprasNegocio negocio = new ComprasNegocio();
            List<Compras> lista = new List<Compras>();
            if (!IsPostBack)
            {
                try
                {
                    lista = negocio.ListarCOM();

                    rptCompras.DataSource = lista;
                    rptCompras.DataBind();

                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex);
                    Response.Redirect("Error.aspx");
                }
            }
        }
    }
}