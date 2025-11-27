using Dominio;
using Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Comercio_Eq_14
{
    public partial class PageMarcas : System.Web.UI.Page
    {
        private const string SESSION_KEY = "MarcaSeleccionada";
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
                gvMarcas.Columns[0].Visible = false;
            }
        }
        
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageAgregarMAR.aspx", false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session[SESSION_KEY] == null)
                return;

            int idMarca = (int)HttpContext.Current.Session[SESSION_KEY];
            Response.Redirect("PageModificarMAR.aspx?id=" + idMarca, false);
          
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
            MarcasNegocio negocio = new MarcasNegocio();

            if (string.IsNullOrWhiteSpace(filtro))
                gvMarcas.DataSource = negocio.ListarMAR();
            else
                gvMarcas.DataSource = negocio.Filtrar(filtro);
            gvMarcas.DataBind();

            if (Session[SESSION_KEY] != null)
            {
                int seleccionado = (int)Session[SESSION_KEY];
                RestaurarSeleccion(seleccionado);
            }

        }
        
        private void RestaurarSeleccion(int seleccionado)
        {
            foreach (GridViewRow row in gvMarcas.Rows)
            {
                int id = (int)gvMarcas.DataKeys[row.RowIndex].Value;

                RadioButton rb = row.FindControl("rbSeleccion") as RadioButton;
                if (rb != null)
                    rb.Checked = (id == seleccionado);
            }
        }
        
        protected void rbSeleccion_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            GridViewRow row = (GridViewRow)rb.NamingContainer;

            int idSeleccionado = (int)gvMarcas.DataKeys[row.RowIndex].Value;

            Session[SESSION_KEY] = idSeleccionado;

            DeseleccionarOtros(idSeleccionado);
        }
        
        protected void gvMarcas_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
       
        private void DeseleccionarOtros(int idSeleccionado)
        {
            foreach (GridViewRow row in gvMarcas.Rows)
            {
                int id = (int)gvMarcas.DataKeys[row.RowIndex].Value;

                if (id != idSeleccionado)
                {
                    RadioButton rb = row.FindControl("rbSeleccion") as RadioButton;
                    if (rb != null) rb.Checked = false;
                }
            }
        }
    }
}
