using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Comercio_Eq_14
{
    public partial class GestionCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<int> seleccionados = Session["IDsSeleccionados"] as List<int>;

                if (seleccionados == null || seleccionados.Count == 0)
                {
                    Response.Write("<script>console.log('No llegaron IDs a GestionCompra');</script>");
                    return;
                }

                Response.Write("<script>console.log('IDs recibidos: " +
                               string.Join(",", seleccionados) + "');</script>");

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

        protected void txtStockSolicitado_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            GridViewRow row = (GridViewRow)txt.NamingContainer;

            int stockSolicitado = 0;
            int.TryParse(txt.Text, out stockSolicitado);

            decimal precioCompra = Convert.ToDecimal(gvGestionCompra.DataKeys[row.RowIndex]["PrecioCompra"]);

           
            decimal descuento = 0;

            
            decimal subtotal = stockSolicitado * precioCompra;
            decimal total = subtotal - descuento;

            Label lblSubtotal = (Label)row.FindControl("lblSubtotal");
            Label lblTotal = (Label)row.FindControl("lblTotal");

            lblSubtotal.Text = subtotal.ToString("N2");
            lblTotal.Text = total.ToString("N2");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ABM_Artículos/PageArticulos.aspx", false);
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
          
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e) { }
        protected void btnQuitarFiltro_Click(object sender, EventArgs e) { }
    }
}
