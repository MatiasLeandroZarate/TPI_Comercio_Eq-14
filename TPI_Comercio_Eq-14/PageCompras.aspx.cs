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
    public partial class PageCompras : System.Web.UI.Page
    {
        private const string SESSION_KEY = "CompraSeleccionada";
        ComprasNegocio negocio = new ComprasNegocio();
        CompraDetalleNegocio detalleNeg = new CompraDetalleNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarCompras();
        }

        private void CargarCompras()
        {
            string filtro = txtFiltroTexto.Text.Trim();
            DateTime? desde = string.IsNullOrEmpty(txtFechaDesde.Text) ? (DateTime?)null : DateTime.Parse(txtFechaDesde.Text);
            DateTime? hasta = string.IsNullOrEmpty(txtFechaHasta.Text) ? (DateTime?)null : DateTime.Parse(txtFechaHasta.Text);

            gvCompras.DataSource = negocio.ListarConFiltro(filtro, desde, hasta);
            gvCompras.DataBind();

            RestaurarSeleccion();
        }

        private void RestaurarSeleccion()
        {
            if (Session[SESSION_KEY] == null) return;

            int seleccionado = (int)Session[SESSION_KEY];
            bool encontrado = false;

            foreach (GridViewRow row in gvCompras.Rows)
            {
                int id = Convert.ToInt32(gvCompras.DataKeys[row.RowIndex].Value);
                RadioButton rb = row.FindControl("rbElegirCompra") as RadioButton;

                if (rb != null)
                {
                    rb.Checked = (id == seleccionado);
                    if (rb.Checked) encontrado = true;
                }
            }

            if (encontrado)
            {
                lblSeleccion.Text = "Compra seleccionada: " + seleccionado;
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
            CargarCompras();
        }

        protected void btnQuitarFiltros_Click(object sender, EventArgs e)
        {
            txtFiltroTexto.Text = "";
            txtFechaDesde.Text = "";
            txtFechaHasta.Text = "";
            CargarCompras();
        }

        protected void rbElegirCompra_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            GridViewRow fila = (GridViewRow)rb.NamingContainer;

            int idCompra = Convert.ToInt32(gvCompras.DataKeys[fila.RowIndex].Value);

            Session[SESSION_KEY] = idCompra;

            // Desactivar otros
            foreach (GridViewRow row in gvCompras.Rows)
            {
                RadioButton otro = row.FindControl("rbElegirCompra") as RadioButton;
                if (otro != null && otro != rb)
                    otro.Checked = false;
            }

            lblSeleccion.Text = "Compra seleccionada: " + idCompra;

            // Cargar detalle
            gvDetalles.DataSource = detalleNeg.ListarDetalles(idCompra);
            gvDetalles.DataBind();
        }
    }
}
