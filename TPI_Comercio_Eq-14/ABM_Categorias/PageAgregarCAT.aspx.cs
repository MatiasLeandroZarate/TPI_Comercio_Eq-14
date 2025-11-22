using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Comercio_Eq_14.ABM_Categorias
{
    public partial class PageAgregarCAT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageCategorias.aspx", false);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Categorias nuevo = new Categorias();
            CategoriasNegocio negocio = new CategoriasNegocio();

            try
            {
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;

                negocio.Agregar(nuevo);
                Response.Redirect("PageCategorias.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("../Error.aspx");
            }
        }
    }
}