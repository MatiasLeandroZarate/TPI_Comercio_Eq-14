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
    public partial class PageProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
            ProveedoresNegocio negocio = new ProveedoresNegocio();
            List<Proveedores> lista = new List<Proveedores>();
            if (!IsPostBack)
            {
                try
                {
                    lista = negocio.ListarPRO();

                    rptProveedores.DataSource = lista;
                    rptProveedores.DataBind();

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