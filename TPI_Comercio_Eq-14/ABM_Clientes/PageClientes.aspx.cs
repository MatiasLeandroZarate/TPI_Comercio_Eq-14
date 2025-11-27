using Dominio;
using Microsoft.Ajax.Utilities;
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
        private const string SESSION_KEY = "SeleccionadosClientes";

        protected void Page_Load(object sender, EventArgs e)
        {
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

            AplicarPermisos();

        }

        private void AplicarPermisos()
        {
            if (!Seguridad.esAdmin(Session["user"]))
            {
                btnAgregar.Visible = false;
                btnModificar.Visible = false;
                btnEliminar.Visible = false;
                gvClientes.Columns[0].Visible = false;
            }
        }

        private void CargarGrilla(string filtro = "")
        {
            ClientesNegocio negocio = new ClientesNegocio();

            var lista = string.IsNullOrWhiteSpace(filtro) ? negocio.ListarCLI() : negocio.Filtrar(filtro);

            if (chkMostrarActivos.Checked)
                lista = lista.Where(p => p.Activo).ToList();

            gvClientes.DataSource = lista;
            gvClientes.DataBind();


            List<int> seleccionados = CheckFiltradosNegocio.ObtenerSeleccionados(SESSION_KEY);
            RestaurarSeleccionados(seleccionados);
        }

        private void RestaurarSeleccionados(List<int> seleccionados)
        {
            foreach (GridViewRow row in gvClientes.Rows)
            {
                CheckBox chk = row.FindControl("chkSeleccion") as CheckBox;

                if (chk != null)
                {
                    int id = (int)gvClientes.DataKeys[row.RowIndex].Value;
                    chk.Checked = seleccionados.Contains(id);
                }
            }
        }

        protected void chkSeleccion_CheckedChanged(object sender, EventArgs e)
        {
            CheckFiltradosNegocio.GuardarSeleccionados(gvClientes, SESSION_KEY);
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            CheckFiltradosNegocio.GuardarSeleccionados(gvClientes, SESSION_KEY);
            CargarGrilla(txtFiltro.Text);
        }

        protected void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            CheckFiltradosNegocio.GuardarSeleccionados(gvClientes, SESSION_KEY);
            txtFiltro.Text = "";
            CargarGrilla();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageAgregarCLI.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            CheckFiltradosNegocio.GuardarSeleccionados(gvClientes, SESSION_KEY);

            List<int> seleccionados = CheckFiltradosNegocio.ObtenerSeleccionados(SESSION_KEY);

            if (seleccionados.Count == 1)
                Response.Redirect("PageModificarCLI.aspx?id=" + seleccionados[0]);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            CheckFiltradosNegocio.GuardarSeleccionados(gvClientes, SESSION_KEY);

            List<int> seleccionados = CheckFiltradosNegocio.ObtenerSeleccionados(SESSION_KEY);

            if (seleccionados != null)
            {
                ClientesNegocio negocio = new ClientesNegocio();
                foreach (int id in seleccionados)
                    negocio.Eliminar(id, false);
            }

            CargarGrilla();
        }

        protected void gvClientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            List<int> seleccionados = CheckFiltradosNegocio.ObtenerSeleccionados(SESSION_KEY);
            CheckFiltradosNegocio.MarcarSeleccionados(e.Row, gvClientes, seleccionados);
        }

        protected void btnQuitarSeleccion_Click(object sender, EventArgs e)
        {
            string sessionKey = SESSION_KEY;


            HttpContext.Current.Session[sessionKey] = new List<int>();


            foreach (GridViewRow row in gvClientes.Rows)
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
    }
}
