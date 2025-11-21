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
    public partial class PageClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    ClientesNegocio negocio = new ClientesNegocio();
                    List<Clientes> lista = negocio.ListarCLI();

                    gvClientes.DataSource = lista;
                    gvClientes.DataBind();
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
            Response.Redirect("PageAgregarCLI.aspx", false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            // Si querés que el botón Modificar funcione sobre la fila seleccionada:
            if (gvClientes.SelectedDataKey != null)
            {
                int idCliente = Convert.ToInt32(gvClientes.SelectedDataKey.Value);
                Response.Redirect("PageModificarCLI.aspx?id=" + idCliente, false);
            }
            else
            {
                Response.Redirect("PageModificarCLI.aspx", false);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gvClientes.SelectedDataKey != null)
            {
                int idCliente = Convert.ToInt32(gvClientes.SelectedDataKey.Value);
                Response.Redirect("PageEliminarCLI.aspx?id=" + idCliente, false);
            }
            else
            {
                Response.Redirect("PageEliminarCLI.aspx", false);
            }
        }
    }
}
