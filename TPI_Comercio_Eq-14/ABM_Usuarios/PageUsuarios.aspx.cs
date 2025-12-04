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
        private const string SESSION_KEY = "SeleccionadosUsuarios";

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
                    CargarGrilla();
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex);
                    Response.Redirect("~/Error.aspx");
                }
            }
        }

        private void CargarGrilla(string filtro = "")
        {
            UsuarioNegocio negocio = new UsuarioNegocio();

            var lista = string.IsNullOrWhiteSpace(filtro) ? negocio.ListarUSU() : negocio.Filtrar(filtro);

            if (chkMostrarActivos.Checked)
                lista = lista.Where(p => p.Activo).ToList();

            gvUsuarios.DataSource = lista;
            gvUsuarios.DataBind();


            List<int> seleccionados = CheckFiltradosNegocio.ObtenerSeleccionados(SESSION_KEY);
            RestaurarSeleccionados(seleccionados);
        }

        private void RestaurarSeleccionados(List<int> seleccionados)
        {
            foreach (GridViewRow row in gvUsuarios.Rows)
            {
                CheckBox chk = row.FindControl("chkSeleccion") as CheckBox;

                if (chk != null)
                {
                    int id = (int)gvUsuarios.DataKeys[row.RowIndex].Value;
                    chk.Checked = seleccionados.Contains(id);
                }
            }
        }

        protected void chkSeleccion_CheckedChanged(object sender, EventArgs e)
        {
            CheckFiltradosNegocio.GuardarSeleccionados(gvUsuarios, SESSION_KEY);
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            CheckFiltradosNegocio.GuardarSeleccionados(gvUsuarios, SESSION_KEY);
            CargarGrilla(txtFiltro.Text);
        }

        protected void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            CheckFiltradosNegocio.GuardarSeleccionados(gvUsuarios, SESSION_KEY);
            txtFiltro.Text = "";
            CargarGrilla();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageAgregarUSU.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            CheckFiltradosNegocio.GuardarSeleccionados(gvUsuarios, SESSION_KEY);

            List<int> seleccionados = CheckFiltradosNegocio.ObtenerSeleccionados(SESSION_KEY);

            if (seleccionados.Count != 1) { return; }

            Session["ValidarUsuario"] = seleccionados[0];

            pnlConfirmarPassword.Visible = true;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            CheckFiltradosNegocio.GuardarSeleccionados(gvUsuarios, SESSION_KEY);

            List<int> seleccionados = CheckFiltradosNegocio.ObtenerSeleccionados(SESSION_KEY);

            if (seleccionados != null)
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                foreach (int id in seleccionados)
                    negocio.Eliminar(id, false);
            }

            CargarGrilla();
        }

        protected void gvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            List<int> seleccionados = CheckFiltradosNegocio.ObtenerSeleccionados(SESSION_KEY);
            CheckFiltradosNegocio.MarcarSeleccionados(e.Row, gvUsuarios, seleccionados);
        }

        protected void btnQuitarSeleccion_Click(object sender, EventArgs e)
        {
            string sessionKey = SESSION_KEY;

            HttpContext.Current.Session[sessionKey] = new List<int>();

            foreach (GridViewRow row in gvUsuarios.Rows)
            {
                CheckBox chk = row.FindControl("chkSeleccion") as CheckBox;
                if (chk != null)
                    chk.Checked = false;
            }

            CargarGrilla();
        }

        protected void chkMostrarActivos_ServerChange(object sender, EventArgs e)
        {
            CargarGrilla(txtFiltro.Text.Trim());
        }

        protected void btnConfirmarPassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["ValidarUsuario"] == null)
                    return;

                int idUsuario = (int)Session["ValidarUsuario"];
                string passwordIngresada = txtConfirmarPassword.Text;

                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuarios usuario = negocio.ObtenerPorId(idUsuario);

                if (usuario == null)
                    return;

                if (usuario.Contraseña == passwordIngresada)
                {
                    Response.Redirect("PageModificarUSU.aspx?id=" + idUsuario, false);
                }
                else
                {
                    lblErrorPassword.Text = "La contraseña ingresada es incorrecta.";
                    lblErrorPassword.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void btnCancelarPassword_Click(object sender, EventArgs e)
        {
            pnlConfirmarPassword.Visible = false;
            txtConfirmarPassword.Text = "";
            lblErrorPassword.Visible = false;
            Session.Remove("ValidarUsuario");
        }
    }
}