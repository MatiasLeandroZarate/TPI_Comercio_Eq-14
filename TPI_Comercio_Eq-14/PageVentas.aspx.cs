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
    public partial class PageVentas : System.Web.UI.Page
    {
        private const string SESSION_KEY = "VentaSeleccionada";
        VentasNegocio negocio = new VentasNegocio();
        VentaDetalleNegocio detalleNeg = new VentaDetalleNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (!IsPostBack)
                    CargarVentas();
            }
        }
        private void CargarVentas()
        {
            string filtro = txtFiltroTexto.Text.Trim();
            DateTime? desde = string.IsNullOrEmpty(txtFechaDesde.Text) ? (DateTime?)null : DateTime.Parse(txtFechaDesde.Text);
            DateTime? hasta = string.IsNullOrEmpty(txtFechaHasta.Text) ? (DateTime?)null : DateTime.Parse(txtFechaHasta.Text);

            gvVentas.DataSource = negocio.ListarConFiltro(filtro, desde, hasta);
            gvVentas.DataBind();

            RestaurarSeleccion();
        }
        private void RestaurarSeleccion()
        {
            if (Session[SESSION_KEY] == null) return;

            int seleccionado = (int)Session[SESSION_KEY];
            bool encontrado = false;

            foreach (GridViewRow row in gvVentas.Rows)
            {
                int id = Convert.ToInt32(gvVentas.DataKeys[row.RowIndex].Value);
                RadioButton rb = row.FindControl("rbElegirVenta") as RadioButton;

                if (rb != null)
                {
                    rb.Checked = (id == seleccionado);
                    if (rb.Checked) encontrado = true;
                }
            }

            if (encontrado)
            {
                lblSeleccion.Text = "Venta seleccionada: " + seleccionado;
                gvDetalles.DataSource = detalleNeg.ListarDetalles(seleccionado);
                gvDetalles.DataBind();
            }
            else
            {
                lblSeleccion.Text = "";
                gvDetalles.DataSource = null;
                gvDetalles.DataBind();
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarVentas();
        }

        protected void btnQuitarFiltros_Click(object sender, EventArgs e)
        {
            txtFiltroTexto.Text = "";
            txtFechaDesde.Text = "";
            txtFechaHasta.Text = "";
            CargarVentas();
        }


        protected void rbElegirVenta_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            GridViewRow fila = (GridViewRow)rb.NamingContainer;

            int idVenta = Convert.ToInt32(gvVentas.DataKeys[fila.RowIndex].Value);

            Session[SESSION_KEY] = idVenta;

            // Desactivar otros
            foreach (GridViewRow row in gvVentas.Rows)
            {
                RadioButton otro = row.FindControl("rbElegirVenta") as RadioButton;
                if (otro != null && otro != rb)
                    otro.Checked = false;
            }

            lblSeleccion.Text = "Compra seleccionada: " + idVenta;

            // Cargar detalle
            gvDetalles.DataSource = detalleNeg.ListarDetalles(idVenta);
            gvDetalles.DataBind();
        }
    }
}
