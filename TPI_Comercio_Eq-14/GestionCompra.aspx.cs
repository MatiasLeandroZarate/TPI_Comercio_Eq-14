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
    public partial class GestionCompra : System.Web.UI.Page
    {
        private const string SESSION_KEY = "ProveedorSeleccionado";
        private ProveedoresNegocio provNegocio = new ProveedoresNegocio();
        public int SelectedProveedorID
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
                CargarProveedores();

                List<int> seleccionados = Session["IDsSeleccionados"] as List<int>;
                if (seleccionados == null || seleccionados.Count == 0)
                    return;

                CargarArticulos(seleccionados);
            }
        }

        private void CargarArticulos(List<int> ids)
        {
            ArticuloCompraNegocio negocio = new ArticuloCompraNegocio();
            List<ArticuloCompra> lista = negocio.ObtenerArticulosPorIds(ids);

            gvGestionCompra.DataSource = lista;
            gvGestionCompra.DataBind();
        }

        private void CargarProveedores(string filtro = "")
        {
            gvProveedores.DataSource = provNegocio.ListarConFiltro(filtro);
            gvProveedores.DataBind();
            RestaurarSeleccionProveedor();
        }

        protected void txtFiltroProv_TextChanged(object sender, EventArgs e)
        {
            CargarProveedores(txtFiltroProv.Text.Trim());
        }

        protected void rbElegir_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            GridViewRow fila = (GridViewRow)rb.NamingContainer;

            int idProveedor = Convert.ToInt32(gvProveedores.DataKeys[fila.RowIndex].Value);

            Session[SESSION_KEY] = idProveedor;

            string razon = fila.Cells[1].Text;
            Session["NombreProveedorSeleccionado"] = razon;

            lblProveedorSeleccionado.Text = "Proveedor elegido: " + razon;

            foreach (GridViewRow row in gvProveedores.Rows)
            {
                RadioButton otro = row.FindControl("rbElegir") as RadioButton;
                if (otro != null && otro != rb) otro.Checked = false;
            }
        }

        private void RestaurarSeleccionProveedor()
        {
            if (Session[SESSION_KEY] == null) return;

            int seleccionado = (int)Session[SESSION_KEY];

            foreach (GridViewRow row in gvProveedores.Rows)
            {
                int id = Convert.ToInt32(gvProveedores.DataKeys[row.RowIndex].Value);
                RadioButton rb = row.FindControl("rbElegir") as RadioButton;
                if (rb != null) rb.Checked = (id == seleccionado);
            }

            if (Session["NombreProveedorSeleccionado"] != null)
                lblProveedorSeleccionado.Text = "Proveedor elegido: " + Session["NombreProveedorSeleccionado"].ToString();
        }

        protected void txtStockSolicitado_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            GridViewRow row = (GridViewRow)txt.NamingContainer;

            RecalcularFila(row);

        }


        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ABM_Artículos/PageArticulos.aspx", false);
        }
        protected void btnComprar_Click(object sender, EventArgs e)
        {
            try
            {
                int idProveedor = 0;
                if (Session[SESSION_KEY] != null)
                    int.TryParse(Session[SESSION_KEY].ToString(), out idProveedor);

                if (idProveedor == 0)
                {
                    lblMensaje.Text = "Debe seleccionar un proveedor.";
                    return;
                }

                Compras compra = new Compras();
                compra.IdProveedor = idProveedor;
                compra.Fecha = DateTime.Now;

                decimal subtotal = 0;
                List<CompraDetalle> detalles = new List<CompraDetalle>();

                bool hayAlMenosUnArticulo = false;

                foreach (GridViewRow row in gvGestionCompra.Rows)
                {
                    TextBox txtCant = (TextBox)row.FindControl("txtStockSolicitado");

                    if (!string.IsNullOrEmpty(txtCant.Text))
                    {
                        int cant = 0;
                        if (!int.TryParse(txtCant.Text, out cant))
                        {
                            lblMensaje.Text = "La cantidad solicitada debe ser un número entero.";
                            return;
                        }
                        if (cant <= 0)
                            continue;

                        hayAlMenosUnArticulo = true;

                        int idArticulo = int.Parse(gvGestionCompra.DataKeys[row.RowIndex].Values["IDArticulo"].ToString());
                        decimal precioOriginal = decimal.Parse(gvGestionCompra.DataKeys[row.RowIndex].Values["PrecioCompra"].ToString());

                        TextBox txtPrecioMod = (TextBox)row.FindControl("txtPrecioModificado");
                        decimal precioModificado = 0;
                        bool tieneMod = true;

                        if (!string.IsNullOrWhiteSpace(txtPrecioMod.Text))
                        {
                            tieneMod = decimal.TryParse(
                                txtPrecioMod.Text.Replace(",", "."),
                                System.Globalization.NumberStyles.AllowDecimalPoint,
                                System.Globalization.CultureInfo.InvariantCulture,
                                out precioModificado
                            );

                            if (!tieneMod)
                            {
                                lblMensaje.Text = "El precio modificado debe ser numérico.";
                                return;
                            }

                            if (precioModificado < 0)
                            {
                                lblMensaje.Text = "El precio modificado no puede ser negativo.";
                                return;
                            }
                        }

                        decimal precio = (!string.IsNullOrWhiteSpace(txtPrecioMod.Text) && tieneMod)
                         ? precioModificado
                         : precioOriginal;

                        subtotal += precio * cant;

                        detalles.Add(new CompraDetalle
                        {
                            IDArticulo = idArticulo,
                            Cantidad = cant,
                            PrecioUnitario = precio
                        });

                        if (!string.IsNullOrWhiteSpace(txtPrecioMod.Text) && tieneMod)
                        {
                            ArticulosNegocio artNeg = new ArticulosNegocio();
                            artNeg.ModificarPrecioCompra(idArticulo, precioModificado);
                        }
                    }
                }

                if (!hayAlMenosUnArticulo)
                {
                    lblMensaje.Text = "Debe ingresar al menos un artículo para efectuar la compra.";
                    return;
                }

                int totalUnidades = detalles.Sum(d => d.Cantidad);
                decimal descuento = 0m;

                if (totalUnidades >= 1000)
                    descuento = subtotal * 0.10m;
                else if (totalUnidades >= 100)
                    descuento = subtotal * 0.05m;

                compra.Descuentos = descuento;
                compra.SubTotal = subtotal;
                compra.Total = subtotal - descuento;


                EfectuarCompraNegocio negocio = new EfectuarCompraNegocio();
                int ultimo = negocio.ObtenerUltimoNroComprobante();
                compra.NroComprobante = ultimo + 1;

                negocio.EfectuarCompra(compra, detalles);

                lblMensaje.Text = "Compra efectuada correctamente. Nº " + compra.NroComprobante;
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
            GridViewRow row = (GridViewRow)txt.NamingContainer;

            RecalcularFila(row);
        }
        private void RecalcularFila(GridViewRow row)
        {
            TextBox txtCant = (TextBox)row.FindControl("txtStockSolicitado");
            int cant = 0;
            int.TryParse(txtCant.Text, out cant);
            
            decimal precioOriginal = Convert.ToDecimal(gvGestionCompra.DataKeys[row.RowIndex]["PrecioCompra"]);

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
