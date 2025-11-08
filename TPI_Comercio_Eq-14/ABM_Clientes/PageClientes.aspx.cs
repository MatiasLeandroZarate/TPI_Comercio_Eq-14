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
            ClientesNegocio negocio = new ClientesNegocio();
            List<Clientes> lista = new List<Clientes>();
            if (!IsPostBack)
            {
                try
                {
                    lista = negocio.ListarCLI();

                    rptClientes.DataSource = lista;
                    rptClientes.DataBind();

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
            Response.Redirect("PageModificarCLI.aspx", false);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageEliminarCLI.aspx", false);
        }
    }
}