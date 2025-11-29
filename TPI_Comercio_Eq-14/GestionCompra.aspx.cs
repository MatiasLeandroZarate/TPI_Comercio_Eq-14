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

            int cantidad = 0;
            int.TryParse(txt.Text, out cantidad);

            decimal precioCompra = Convert.ToDecimal(gvGestionCompra.DataKeys[row.RowIndex]["PrecioCompra"]);

            decimal subtotal = cantidad * precioCompra;
            decimal total = subtotal;

            ((Label)row.FindControl("lblSubtotal")).Text = subtotal.ToString("N2");
            ((Label)row.FindControl("lblTotal")).Text = total.ToString("N2");
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

                // Preparar compra y detalles
                Compras compra = new Compras();
                compra.IdProveedor = idProveedor;
                compra.Fecha = DateTime.Now;

                decimal subtotal = 0;
                List<CompraDetalle> detalles = new List<CompraDetalle>();

                foreach (GridViewRow row in gvGestionCompra.Rows)
                {
                    TextBox txtCant = (TextBox)row.FindControl("txtStockSolicitado");
                    if (!string.IsNullOrEmpty(txtCant.Text))
                    {
                        int cant = 0;
                        if (!int.TryParse(txtCant.Text, out cant)) continue;
                        if (cant <= 0) continue;

                        int idArticulo = int.Parse(gvGestionCompra.DataKeys[row.RowIndex].Values["IDArticulo"].ToString());
                        decimal precio = decimal.Parse(gvGestionCompra.DataKeys[row.RowIndex].Values["PrecioCompra"].ToString());

                        subtotal += precio * cant;
                        detalles.Add(new CompraDetalle { IDArticulo = idArticulo, Cantidad = cant, PrecioUnitario = precio });
                    }
                }

                // Calculo de descuentos según cantidad total de unidades
                int totalUnidades = detalles.Sum(d => d.Cantidad);
                decimal descuento = 0m;
                if (totalUnidades >= 1000)
                    descuento = subtotal * 0.10m;
                else if (totalUnidades >= 100)
                    descuento = subtotal * 0.05m;

                compra.Descuentos = descuento;
                compra.SubTotal = subtotal;
                compra.Total = subtotal - descuento;

                // OBTENER NRO DE COMPROBANTE: USAR LA CAPA DE NEGOCIO (mejor) o AccesoBD directo
                EfectuarCompraNegocio negocio = new EfectuarCompraNegocio();
                // Obtener último (max) y sumar 1:
                int ultimo = negocio.ObtenerUltimoNroComprobante(); // en tu clase devuelve MAX(NroComprobante)
                compra.NroComprobante = ultimo + 1;

                // Ejecutar compra
                negocio.EfectuarCompra(compra, detalles);

                lblMensaje.Text = "Compra efectuada correctamente. Nº " + compra.NroComprobante;
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("~/Error.aspx");
            }
        }

    }
}
