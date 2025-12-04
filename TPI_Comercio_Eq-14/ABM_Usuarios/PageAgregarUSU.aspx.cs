using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Comercio_Eq_14.ABM_Usuarios
{
    public partial class PageAgregarUSU : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["user"]))
            {
                Session.Add("Error", "Acceso denegado. Se requiere privilegios de administrador.");
                Response.Redirect("~/Error.aspx", false);
            }
            
            if (!IsPostBack)
            {
                try
                {
                    ddlRol.Items.Insert(1, new ListItem("Admin", "Admin"));
                    ddlRol.Items.Insert(2, new ListItem("Colaborador", "Colaborador"));
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex);
                    Response.Redirect("~/Error.aspx");
                }
            }

            ViewState["Contraseña"] = txtContra.Text;
            ViewState["RepetirContraseña"] = txtRepetirContra.Text;

            txtContra.TextMode = chkVerContraseña.Checked ? TextBoxMode.SingleLine : TextBoxMode.Password;
            txtRepetirContra.TextMode = chkVerContraseña.Checked ? TextBoxMode.SingleLine : TextBoxMode.Password;
            if (ViewState["Contraseña"] != null)
            {
                txtContra.Attributes["value"] = ViewState["Contraseña"].ToString();
            }

            if (ViewState["RepetirContraseña"] != null)
            {
                txtRepetirContra.Attributes["value"] = ViewState["RepetirContraseña"].ToString();
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageUsuarios.aspx", false);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Usuarios nuevo = new Usuarios();
            UsuarioNegocio negocio = new UsuarioNegocio();

            try
            {
                if (string.IsNullOrWhiteSpace(ddlRol.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtContra.Text))
                {
                    lblError.Text = "Complete los datos obligatorios.";
                    lblError.Visible = true;
                    return;
                }
                if (txtContra.Text != txtRepetirContra.Text)
                {
                    lblError.Text = "Las contraseñas no coinciden.";
                    lblError.Visible = true;
                    return;
                }
                nuevo.Rol = ddlRol.SelectedValue;
                nuevo.Email = txtEmail.Text;
                nuevo.Contraseña = txtContra.Text;
                nuevo.Activo = true;

                negocio.Agregar(nuevo);
                Response.Redirect("PageUsuarios.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("~/Error.aspx");
            }
        }
    }
}