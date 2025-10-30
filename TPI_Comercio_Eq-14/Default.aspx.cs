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
            if (!IsPostBack)
                return;
            ViewState["Contraseña"] = txtContraseña.Text;

            txtContraseña.TextMode = chkVerContraseña.Checked ? TextBoxMode.SingleLine : TextBoxMode.Password;
            if (ViewState["Contraseña"] != null)
            {
                txtContraseña.Attributes["value"] = ViewState["Contraseña"].ToString();
            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            usuarios.Email = txtEmail.Text.ToUpper();
            usuarios.Contraseña = txtContraseña.Text;

            if (CompararUsuario(usuarios.Email, usuarios.Contraseña))
            {

                Session.Add("Email", user);
                Response.Redirect("PageInicio.aspx", false);

            }
            else
            {
                string mensaje = "Email y/o la contraseña invalido";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", $"alert('{mensaje}');", true);

            }


        }


        public bool CompararUsuario(string user, string pass)
        {
            string auxuser = user.ToUpper();
            string auxpass = pass;
            AccesoBD acceso = new AccesoBD();
            Usuarios aux = new Usuarios();

            try
            {
                acceso.setearQuery("SELECT Email , Contraseña FROM Usuarios WHERE Email = @Email and Contraseña = @pass");
                acceso.setearParametro("@Email", user);
                acceso.setearParametro("@pass", pass);
                acceso.ejecutarLectura();
                    

                if (acceso.Lector.Read())
                {
                    aux.Email = (string)acceso.Lector["Email"].ToString().ToUpper();
                    aux.Contraseña = (string)acceso.Lector["Contraseña"].ToString();

                    if (auxuser == aux.Email && auxpass == aux.Contraseña )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                acceso.cerrarConexion();
            }
        }
    }
}