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
    public partial class PageVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    VentasNegocio negocio = new VentasNegocio();
                    List<Ventas> lista = negocio.ListarVEN();

                    gvVentas.DataSource = lista;
                    gvVentas.DataBind();
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
