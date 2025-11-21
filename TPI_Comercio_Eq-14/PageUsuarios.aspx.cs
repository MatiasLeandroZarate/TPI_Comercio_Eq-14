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
    public partial class PageUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["user"]))
            {
                Session.Add("Error", "Acceso denegado. Se requiere privilegios de administrador.");
                Response.Redirect("Error.aspx", false);
            }

            if (!IsPostBack)
            {
                try
                {
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    List<Usuarios> lista = negocio.ListarUSU();

                    gvUsuarios.DataSource = lista;
                    gvUsuarios.DataBind();
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