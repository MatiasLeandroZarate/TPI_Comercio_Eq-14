using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Comercio_Eq_14.ABM_Marcas
{
    public partial class PageAgregarMAR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageMarcas.aspx", false);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Marcas nuevo = new Marcas();
            MarcasNegocio negocio = new MarcasNegocio();

            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    return;
                }

                nuevo.Nombre = txtNombre.Text.Trim();

                negocio.Agregar(nuevo);
                Response.Redirect("PageMarcas.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("~/Error.aspx");
            }
        }
    }
}
