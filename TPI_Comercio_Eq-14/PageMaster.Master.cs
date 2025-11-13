using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TPC_Comercio_Eq_14;

namespace TPI_Comercio_Eq_14
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!(Page is Default || Page is Error ))
            { 
                if (!Seguridad.sesionActiva(Session["user"]))
                    Response.Redirect("Default.aspx", false); 
            }
        }
        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx");
        }
    }

}