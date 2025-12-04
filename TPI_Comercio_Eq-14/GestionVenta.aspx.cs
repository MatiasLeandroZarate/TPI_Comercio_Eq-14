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
        private const string SESSION_KEY = "ClienteSeleccionado";
        private ClientesNegocio clieNegocio = new ClientesNegocio();
        public int SelectedClienteID
        {
            get
            {
                if (Session[SESSION_KEY] == null)
                    return 0;

                return (int)Session[SESSION_KEY];
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

            Session[SESSION_KEY] = idCliente;

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
            if (Session[SESSION_KEY] == null) return;

            int seleccionado = (int)Session[SESSION_KEY];

            foreach (GridViewRow row in gvClientes.Rows)
            {
                int id = Convert.ToInt32(gvClientes.DataKeys[row.RowIndex].Value);
                RadioButton rb = row.FindControl("rbElegir") as RadioButton;
                if (rb != null) rb.Checked = (id == seleccionado);
            }

            if (Session["NombreClienteSeleccionado"] != null)
                lblClienteSeleccionado.Text = "Cliente elegido: " + Session["NombreClienteSeleccionado"].ToString();
        }

        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            GridViewRow row = (GridViewRow)txt.NamingContainer;
            RecalcularFila(row);
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
                if (Session[SESSION_KEY] != null)
                    int.TryParse(Session[SESSION_KEY].ToString(), out idCliente);

                if (idCliente == 0)
                {
                    lblMensaje.Text = "Debe seleccionar un Cliente.";
                    return;
                }

                //Usuarios usuarioActual = (Usuarios)Session["usuario"];
                //bool esAdmin = Seguridad.esAdmin(usuarioActual);
                //bool requiereAutorizacion = false;


                Ventas venta = new Ventas();
                venta.IdCliente = idCliente;
                venta.Fecha = DateTime.Now;

                decimal subtotal = 0;
                List<VentaDetalle> detalles = new List<VentaDetalle>();

                foreach (GridViewRow row in gvGestionVenta.Rows)
                {
                    TextBox txtCant = (TextBox)row.FindControl("txtCantidad");
                    TextBox txtPrecioMod = (TextBox)row.FindControl("txtPrecioModificado");

                    string strCant = txtCant.Text.Trim();
                    string strPrecioMod = txtPrecioMod.Text.Trim();


                    if (string.IsNullOrEmpty(strCant))
                    {
                        lblMensaje.Text = "Debe ingresar cantidad en todos los artículos listados.";
                        return;
                    }

                    int cantidad;
                    if (!int.TryParse(strCant, out cantidad) || cantidad <= 0)
                    {
                        lblMensaje.Text = "La cantidad debe ser un número mayor a 0.";
                        return;
                    }

                    decimal precioModificado = 0;
                    bool precioModEsValido = true;

                    if (!string.IsNullOrEmpty(strPrecioMod))
                    {
                        precioModEsValido = decimal.TryParse(
                            strPrecioMod.Replace(",", "."),
                            System.Globalization.NumberStyles.AllowDecimalPoint,
                            System.Globalization.CultureInfo.InvariantCulture,
                            out precioModificado);

                        if (!precioModEsValido || precioModificado < 0)
                        {
                            lblMensaje.Text = "El precio modificado debe ser un número válido y no negativo.";
                            return;
                        }
                    }

                    int idArticulo = int.Parse(gvGestionVenta.DataKeys[row.RowIndex].Values["IDArticulo"].ToString());
                    decimal precioOriginal = decimal.Parse(gvGestionVenta.DataKeys[row.RowIndex].Values["PrecioVenta"].ToString());
                    int stockActual = int.Parse(gvGestionVenta.DataKeys[row.RowIndex].Values["StockActual"].ToString());

                    if (cantidad > stockActual)
                    {
                        lblMensaje.Text = "La cantidad vendida no debe ser mayor al stock actual.";
                        return;
                    }

                    decimal precioFinal = (!string.IsNullOrEmpty(strPrecioMod) && precioModEsValido)
                                          ? precioModificado
                                          : precioOriginal;

                    //if (!esAdmin && !string.IsNullOrEmpty(strPrecioMod))
                    //{
                    //    requiereAutorizacion = true;
                    //}

                    if (!string.IsNullOrEmpty(strPrecioMod) && precioModEsValido)
                    {
                        ArticulosNegocio artNeg = new ArticulosNegocio();
                        artNeg.ModificarPrecioVenta(idArticulo, precioModificado);
                    }
                    subtotal += cantidad * precioFinal;

                    detalles.Add(new VentaDetalle
                    {
                        IDArticulo = idArticulo,
                        Cantidad = cantidad,   // en ventas NO va negativo
                        PrecioUnitario = precioFinal
                    });
                }

                //if (requiereAutorizacion)
                //{
                //    txtCodigoAutorizacion.Visible = true;
                //    if (string.IsNullOrEmpty(txtCodigoAutorizacion.Text))
                //    {
                //        lblMensaje.Text = "Falta autorización para modificar el precio.";
                //        return;
                //    }

                //    if (txtCodigoAutorizacion.Text.Trim() != "admin")
                //    {
                //        lblMensaje.Text = "Código de autorización incorrecto.";
                //        return;
                //    }
                //}


                int totalUnidades = detalles.Sum(d => d.Cantidad);
                decimal descuento = 0;

                if (totalUnidades >= 1000)
                    descuento = subtotal * 0.10m;
                else if (totalUnidades >= 100)
                    descuento = subtotal * 0.05m;

                venta.Descuentos = descuento;
                venta.SubTotal = subtotal;
                venta.Total = subtotal - descuento;

                EfectuarVentaNegocio negocio = new EfectuarVentaNegocio();
                int ultimo = negocio.ObtenerUltimoNroComprobante();
                venta.NroComprobante = ultimo + 1;

                negocio.EfectuarVenta(venta, detalles);

                lblMensaje.Text = "Venta efectuada correctamente. Nº " + venta.NroComprobante;
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("~/Error.aspx");
            }
        }
                        protected void txtPrecioModificado_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            GridViewRow fila = (GridViewRow)txt.NamingContainer;
            RecalcularFila(fila);
        }

        private void RecalcularFila(GridViewRow row)
        {
            TextBox txtCant = (TextBox)row.FindControl("txtCantidad");
            int cant = 0;
            int.TryParse(txtCant.Text, out cant);

            decimal precioOriginal = Convert.ToDecimal(gvGestionVenta.DataKeys[row.RowIndex]["PrecioVenta"]);

            TextBox txtMod = (TextBox)row.FindControl("txtPrecioModificado");
            decimal precioMod;
            bool tieneMod = decimal.TryParse(txtMod.Text.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out precioMod);

            decimal precio = tieneMod ? precioMod : precioOriginal;

            decimal subtotal = cant * precio;

            ((Label)row.FindControl("lblSubtotal")).Text = subtotal.ToString("N2");
            ((Label)row.FindControl("lblTotal")).Text = subtotal.ToString("N2");

        }
    }
}