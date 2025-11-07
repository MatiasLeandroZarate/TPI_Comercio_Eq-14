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
            VentasNegocio negocio = new VentasNegocio();
            List<Ventas> lista = new List<Ventas>();
            if (!IsPostBack)
            {
                try
                {
                    lista = negocio.ListarVEN();

                    rptVentas.DataSource = lista;
                    rptVentas.DataBind();

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