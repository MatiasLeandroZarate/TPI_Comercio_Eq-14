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
    public partial class PageModificarUSU : System.Web.UI.Page
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
                    ddlRol.Items.Clear();
                    ddlRol.Items.Add(new ListItem("Admin", "Admin"));
                    ddlRol.Items.Add(new ListItem("Colaborador", "Colaborador"));

                    ddlActivo.Items.Clear();
                    ddlActivo.Items.Add(new ListItem("Activo", "1"));
                    ddlActivo.Items.Add(new ListItem("Inactivo", "0"));

                    string idUsuarioStr = Request.QueryString["id"];
                    if (!string.IsNullOrEmpty(idUsuarioStr))
                    {
                        int idUsuario = int.Parse(idUsuarioStr);
                        UsuarioNegocio negocio = new UsuarioNegocio();
                        Usuarios usuario = negocio.ObtenerPorId(idUsuario);

                        if (usuario != null)
                        {
                            txtIdUsuario.Text = usuario.IDUsuario.ToString();

                            txtEmail.Text = usuario.Email;
                            txtContra.Text = usuario.Contraseña;
                            txtRepetirContra.Text = usuario.Contraseña;
                            ddlRol.SelectedValue = usuario.Rol;
                            ddlActivo.SelectedValue = usuario.Activo ? "1" : "0";
                        }
                    }
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

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Usuarios modificado = new Usuarios();
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

                modificado.IDUsuario = int.Parse(txtIdUsuario.Text);
                modificado.Rol = ddlRol.SelectedValue;
                modificado.Email = txtEmail.Text;
                modificado.Contraseña = txtContra.Text;
                modificado.Activo = ddlActivo.SelectedValue == "1";

                negocio.Modificar(modificado);
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