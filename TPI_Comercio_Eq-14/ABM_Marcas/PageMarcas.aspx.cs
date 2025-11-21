using Dominio;
using Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Comercio_Eq_14
{
    public partial class PageMarcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    MarcasNegocio negocio = new MarcasNegocio();
                    List<Marcas> lista = negocio.ListarMAR();

                    gvMarcas.DataSource = lista;
                    gvMarcas.DataBind();
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
            Response.Redirect("PageAgregarMAR.aspx", false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            
            if (gvMarcas.SelectedDataKey != null)
            {
                int idMarca = Convert.ToInt32(gvMarcas.SelectedDataKey.Value);
                Response.Redirect("PageModificarMAR.aspx?id=" + idMarca, false);
            }
            else
            {
                Response.Redirect("PageModificarMAR.aspx", false);
            }
        }
    }
}
