using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPC_Comercio_Eq_14
{
    public partial class PageCategorias : System.Web.UI.Page
    {
        private const string SESSION_KEY = "CategoriaSeleccionada";

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
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageAgregarCAT.aspx", false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session[SESSION_KEY] == null)
                return;

            int id = (int)HttpContext.Current.Session[SESSION_KEY];
            Response.Redirect("PageModificarCAT.aspx?id=" + id, false);
        }
        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            CargarGrilla(txtFiltro.Text);
        }

        protected void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = "";
            CargarGrilla();
        }

        private void CargarGrilla(string filtro = "")
        {
            CategoriasNegocio negocio = new CategoriasNegocio();

            if (string.IsNullOrWhiteSpace(filtro))
                gvCategorias.DataSource = negocio.ListarCAT();
            else
                gvCategorias.DataSource = negocio.Filtrar(filtro);
            gvCategorias.DataBind();

            if (Session[SESSION_KEY] != null)
            {
                int seleccionado = (int)Session[SESSION_KEY];
                RestaurarSeleccion(seleccionado);
            }

        }

        private void RestaurarSeleccion(int seleccionado)
        {
            foreach (GridViewRow row in gvCategorias.Rows)
            {
                int id = (int)gvCategorias.DataKeys[row.RowIndex].Value;

                RadioButton rb = row.FindControl("rbSeleccion") as RadioButton;
                if (rb != null)
                    rb.Checked = (id == seleccionado);
            }
        }

        protected void rbSeleccion_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            GridViewRow row = (GridViewRow)rb.NamingContainer;

            int idSeleccionado = (int)gvCategorias.DataKeys[row.RowIndex].Value;

            Session[SESSION_KEY] = idSeleccionado;

            DeseleccionarOtros(idSeleccionado);
        }
        protected void gvCategorias_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        private void DeseleccionarOtros(int idSeleccionado)
        {
            foreach (GridViewRow row in gvCategorias.Rows)
            {
                int id = (int)gvCategorias.DataKeys[row.RowIndex].Value;

                if (id != idSeleccionado)
                {
                    RadioButton rb = row.FindControl("rbSeleccion") as RadioButton;
                    if (rb != null) rb.Checked = false;
                }
            }
        }
    }
}
