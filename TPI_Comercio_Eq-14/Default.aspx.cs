using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TPC_Comercio_Eq_14
{
    public partial class Default : System.Web.UI.Page
    {
        Usuarios usuarios = new Usuarios();
        public string user { get; set; }
        public string passw { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            ViewState["Contraseña"] = txtContraseña.Text;

            txtContraseña.TextMode = chkVerContraseña.Checked ? TextBoxMode.SingleLine : TextBoxMode.Password;
            if (ViewState["Contraseña"] != null)
            {
                txtContraseña.Attributes["value"] = ViewState["Contraseña"].ToString();
            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                user.Email = txtEmail.Text;
                user.Contraseña = txtContraseña.Text;
                if (negocio.Login(user))
                {
                    Session.Add("user", user);
                    Response.Redirect("PageInicio.aspx", false);
                }
                else
                {
                    Session.Add("Error", "Email y/o contraseña incorrectas");
                    Response.Redirect("Error.aspx", false);
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
                
            }
        }

    }
}