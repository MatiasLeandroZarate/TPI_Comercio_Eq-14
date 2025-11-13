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
                Session.Add("Error", "Acceso denegado. Se requiere privilegios de administrados.");
                Response.Redirect("Error.aspx",false);
            }    
            UsuarioNegocio negocio = new UsuarioNegocio();
            List<Usuarios> lista = new List<Usuarios>();

            if (!IsPostBack)
            {
                try
                {
                    lista = negocio.ListarUSU();

                    rptUsuarios.DataSource = lista;
                    rptUsuarios.DataBind();

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