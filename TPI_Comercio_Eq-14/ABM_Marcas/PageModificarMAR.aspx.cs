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
    public partial class PageModificarMAR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idMarcaStr = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(idMarcaStr))
                {
                    int idMarca = int.Parse(idMarcaStr);
                    CargarMarca(idMarca);
                }
            }
        }

        private void CargarMarca(int idMarca)
        {
            MarcasNegocio negocio = new MarcasNegocio();
            Marcas mar = negocio.ObtenerPorId(idMarca);

            if (mar != null)
            {
                txtIDMarca.Text = mar.IdMarca.ToString();
                txtNombre.Text = mar.Nombre;
            }
            else
            {
                txtIDMarca.Text = "";
                txtNombre.Text = "";
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageMarcas.aspx", false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Marcas modificado = new Marcas();
            MarcasNegocio negocio = new MarcasNegocio();

            try
            {
                modificado.IdMarca = int.Parse(txtIDMarca.Text);
                modificado.Nombre = txtNombre.Text;

                negocio.Modificar(modificado);
                Response.Redirect("PageMarcas.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("../Error.aspx");
            }
        }
    }
}
