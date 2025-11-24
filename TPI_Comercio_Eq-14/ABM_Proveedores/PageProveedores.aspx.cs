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
        private const string SESSION_KEY = "SeleccionadosProvedores";

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
            
        }
        private void CargarGrilla(string filtro = "")
        {
            ProveedoresNegocio negocio = new ProveedoresNegocio();

            if (string.IsNullOrWhiteSpace(filtro))
                gvProveedores.DataSource = negocio.ListarPRO();
            else
                gvProveedores.DataSource = negocio.Filtrar(filtro);

            gvProveedores.DataBind();


            List<int> seleccionados = CheckFiltradosNegocio.ObtenerSeleccionados(SESSION_KEY);
            RestaurarSeleccionados(seleccionados);
        }
        private void RestaurarSeleccionados(List<int> seleccionados)
        {
            foreach (GridViewRow row in gvProveedores.Rows)
            {
                CheckBox chk = row.FindControl("chkSeleccion") as CheckBox;

                if (chk != null)
                {
                    int id = (int)gvProveedores.DataKeys[row.RowIndex].Value;
                    chk.Checked = seleccionados.Contains(id);
                }
            }
        }
        protected void chkSeleccion_CheckedChanged(object sender, EventArgs e)
        {
            CheckFiltradosNegocio.GuardarSeleccionados(gvProveedores, SESSION_KEY);
        }
        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            CheckFiltradosNegocio.GuardarSeleccionados(gvProveedores, SESSION_KEY);
            CargarGrilla(txtFiltro.Text);
        }
        protected void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            CheckFiltradosNegocio.GuardarSeleccionados(gvProveedores, SESSION_KEY);
            txtFiltro.Text = "";
            CargarGrilla();
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageAgregarPRO.aspx");
        }
      
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            CheckFiltradosNegocio.GuardarSeleccionados(gvProveedores, SESSION_KEY);

            List<int> seleccionados = CheckFiltradosNegocio.ObtenerSeleccionados(SESSION_KEY);

            if (seleccionados.Count == 1)
                Response.Redirect("PageModificarPRO.aspx?id=" + seleccionados[0]);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            CheckFiltradosNegocio.GuardarSeleccionados(gvProveedores, SESSION_KEY);

            List<int> seleccionados = CheckFiltradosNegocio.ObtenerSeleccionados(SESSION_KEY);

            if (seleccionados != null)
            {
                ProveedoresNegocio negocio = new ProveedoresNegocio();
                foreach (int id in seleccionados)
                    negocio.Eliminar(id, false);
            }

            CargarGrilla();
        }
        protected void gvProveedores_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            List<int> seleccionados = CheckFiltradosNegocio.ObtenerSeleccionados(SESSION_KEY);
            CheckFiltradosNegocio.MarcarSeleccionados(e.Row, gvProveedores, seleccionados);
        }

        protected void btnQuitarSeleccion_Click(object sender, EventArgs e)
        {
            string sessionKey = SESSION_KEY;


            HttpContext.Current.Session[sessionKey] = new List<int>();


            foreach (GridViewRow row in gvProveedores.Rows)
            {
                CheckBox chk = row.FindControl("chkSeleccion") as CheckBox;
                if (chk != null)
                    chk.Checked = false;
            }
            CargarGrilla();
        }
    }
}
