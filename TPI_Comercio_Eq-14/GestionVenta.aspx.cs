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
    public partial class GestionVenta : System.Web.UI.Page
    {
        private ClientesNegocio clieNegocio = new ClientesNegocio();
        public int SelectedClienteID
        {
            get
            {
                if (Session["ClienteSeleccionado"] == null)
                    return 0;

                return (int)Session["ClienteSeleccionado"];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();

                List<int> seleccionados = Session["IDsSeleccionados"] as List<int>;
                if (seleccionados == null || seleccionados.Count == 0)
                    return;

                CargarArticulos(seleccionados);
            }
        }

        private void CargarArticulos(List<int> ids)
        {
            ArticuloVentaNegocio negocio = new ArticuloVentaNegocio();
            List<ArticuloVenta> lista = negocio.ObtenerArticulosPorIds(ids);

            gvGestionVenta.DataSource = lista;
            gvGestionVenta.DataBind();
        }

        private void CargarClientes(string filtro = "")
        {
            gvClientes.DataSource = clieNegocio.ListarConFiltro(filtro);
            gvClientes.DataBind();
            RestaurarSeleccionCliente();
        }

        protected void txtFiltroCliente_TextChanged(object sender, EventArgs e)
        {
            CargarClientes(txtFiltroCliente.Text.Trim());
        }

        protected void rbElegir_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            GridViewRow fila = (GridViewRow)rb.NamingContainer;

            int idCliente = Convert.ToInt32(gvClientes.DataKeys[fila.RowIndex].Value);

            Session["ClienteSeleccionado"] = idCliente;

            string nombre = fila.Cells[1].Text + ", " + fila.Cells[2].Text;
            Session["NombreClienteSeleccionado"] = nombre;

            lblClienteSeleccionado.Text = "Cliente elegido: " + nombre;

            foreach (GridViewRow row in gvClientes.Rows)
            {
                RadioButton otro = row.FindControl("rbElegir") as RadioButton;
                if (otro != null && otro != rb) otro.Checked = false;
            }
        }

        private void RestaurarSeleccionCliente()
        {
            if (Session["ClienteSeleccionado"] == null) return;

            int seleccionado = (int)Session["ClienteSeleccionado"];

            foreach (GridViewRow row in gvClientes.Rows)
            {
                int id = Convert.ToInt32(gvClientes.DataKeys[row.RowIndex].Value);
                RadioButton rb = row.FindControl("rbElegir") as RadioButton;
                if (rb != null) rb.Checked = (id == seleccionado);
            }

            if (Session["NombreClienteSeleccionado"] != null)
                lblClienteSeleccionado.Text = "Cliente elegido: " + Session["NombreClienteSeleccionado"].ToString();
        }

        protected void txtStockSolicitado_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            GridViewRow row = (GridViewRow)txt.NamingContainer;

            int cantidad = 0;
            int.TryParse(txt.Text, out cantidad);

            decimal precioVenta = Convert.ToDecimal(gvGestionVenta.DataKeys[row.RowIndex]["PrecioVenta"]);

            decimal subtotal = cantidad * precioVenta;
            decimal total = subtotal;

            ((Label)row.FindControl("lblSubtotal")).Text = subtotal.ToString("N2");
            ((Label)row.FindControl("lblTotal")).Text = total.ToString("N2");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ABM_Artículos/PageArticulos.aspx", false);
        }

        protected void btnVenta_Click(object sender, EventArgs e)
        {
            try
            {
                int idCliente = 0;
                if (Session["ClienteSeleccionado"] != null)
                    int.TryParse(Session["ClienteSeleccionado"].ToString(), out idCliente);

                if (idCliente == 0)
                {
                    lblMensaje.Text = "Debe seleccionar un Cliente.";
                    return;
                }

                // Preparar venta y detalles
                Ventas venta = new Ventas();
                venta.IdCliente = idCliente;
                venta.Fecha = DateTime.Now;

                decimal subtotal = 0;
                List<VentaDetalle> detalles = new List<VentaDetalle>();

                foreach (GridViewRow row in gvGestionVenta.Rows)
                {
                    TextBox txtCant = (TextBox)row.FindControl("txtStockSolicitado");
                    if (!string.IsNullOrEmpty(txtCant.Text))
                    {
                        int cant = 0;
                        if (!int.TryParse(txtCant.Text, out cant)) continue;
                        if (cant <= 0) continue;

                        int idArticulo = int.Parse(gvGestionVenta.DataKeys[row.RowIndex].Values["IDArticulo"].ToString());
                        decimal precio = decimal.Parse(gvGestionVenta.DataKeys[row.RowIndex].Values["PrecioCompra"].ToString());

                        subtotal += precio * cant;
                        cant = cant * -1;
                        detalles.Add(new VentaDetalle { IDArticulo = idArticulo, Cantidad = cant, PrecioUnitario = precio });
                    }
                }

                // Calculo de descuentos según cantidad total de unidades
                int totalUnidades = detalles.Sum(d => d.Cantidad);
                decimal descuento = 0m;
                if (totalUnidades >= 1000)
                    descuento = subtotal * 0.10m;
                else if (totalUnidades >= 100)
                    descuento = subtotal * 0.05m;

                venta.Descuentos = descuento;
                venta.SubTotal = subtotal;
                venta.Total = subtotal - descuento;

                // OBTENER NRO DE COMPROBANTE: USAR LA CAPA DE NEGOCIO (mejor) o AccesoBD directo
                EfectuarVentaNegocio negocio = new EfectuarVentaNegocio();
                // Obtener último (max) y sumar 1:
                int ultimo = negocio.ObtenerUltimoNroComprobante(); // en tu clase devuelve MAX(NroComprobante)
                venta.NroComprobante = ultimo + 1;

                // Ejecutar venta
                negocio.EfectuarVenta(venta, detalles);

                lblMensaje.Text = "Venta efectuada correctamente. Nº " + venta.NroComprobante;
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("~/Error.aspx");
            }
        }
    }
}