using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPC_Comercio_Eq_14
{
    public partial class PageCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriasNegocio negocio = new CategoriasNegocio();
            List<Categorias> lista = new List<Categorias>();

            if (!IsPostBack)
            {
                try
                {
                    lista = negocio.ListarCAT();

                    rptCategorias.DataSource = lista;
                    rptCategorias.DataBind();

                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex);
                    Response.Redirect("Error.aspx");
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageAgregarCAT.aspx", false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageModificarCAT.aspx", false);
        }
    }
}