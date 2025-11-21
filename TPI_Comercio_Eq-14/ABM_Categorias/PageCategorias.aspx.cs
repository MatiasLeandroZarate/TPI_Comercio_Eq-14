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
            if (!IsPostBack)
            {
                try
                {
                    CategoriasNegocio negocio = new CategoriasNegocio();
                    List<Categorias> lista = negocio.ListarCAT();

                    gvCategorias.DataSource = lista;
                    gvCategorias.DataBind();
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex);
                    Response.Redirect("../Error.aspx");
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageAgregarCAT.aspx", false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (gvCategorias.SelectedDataKey != null)
            {
                int idCategoria = Convert.ToInt32(gvCategorias.SelectedDataKey.Value);
                Response.Redirect("PageModificarCAT.aspx?id=" + idCategoria, false);
            }
            else
            {
                Response.Redirect("PageModificarCAT.aspx", false);
            }
        }
    }
}
