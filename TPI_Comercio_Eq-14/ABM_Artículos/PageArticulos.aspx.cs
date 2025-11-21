using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Comercio_Eq_14
{
    public partial class PageArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticulosNegocio negocio = new ArticulosNegocio();
                Session["listaArticulos"] = negocio.ListarART();
                gvArticulos.DataSource = Session["listaArticulos"];
                gvArticulos.DataBind();

                ActualizarEstadoBotones(); // 👈 aquí


            }
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulos> lista = (List<Articulos>)Session["listaArticulos"];
            List<Articulos> listaFiltrada;

            if (string.IsNullOrWhiteSpace(txtFiltro.Text))
                listaFiltrada = lista;
            else
                listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));

            gvArticulos.DataSource = listaFiltrada;
            gvArticulos.DataBind();

            ActualizarEstadoBotones(); // 👈 aquí

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageAgregarART.aspx", false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            var seleccionados = ObtenerSeleccionados();
            if (seleccionados.Count == 1)
            {
                Response.Redirect("PageModificarART.aspx?id=" + seleccionados[0], false);
            }
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            var seleccionados = ObtenerSeleccionados();
            if (seleccionados.Count > 0)
            {
                Session["ArticulosSeleccionados"] = seleccionados;
                Response.Redirect("PageCompraVenta.aspx", false);
            }
        }

        protected void btnVender_Click(object sender, EventArgs e)
        {
            var seleccionados = ObtenerSeleccionados();
            if (seleccionados.Count > 0)
            {
                Session["ArticulosSeleccionados"] = seleccionados;
                Response.Redirect("PageVenta.aspx", false);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var seleccionados = ObtenerSeleccionados();
            ArticulosNegocio negocio = new ArticulosNegocio();

            foreach (int id in seleccionados)
                negocio.Eliminar(id, false);

            Session["listaArticulos"] = negocio.ListarART();
            gvArticulos.DataSource = Session["listaArticulos"];
            gvArticulos.DataBind();

            ActualizarEstadoBotones();

        }

        private List<int> ObtenerSeleccionados()
        {
            List<int> seleccionados = new List<int>();

            foreach (GridViewRow row in gvArticulos.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkSeleccionado");
                if (chk != null && chk.Checked)
                {
                    int id = Convert.ToInt32(gvArticulos.DataKeys[row.RowIndex].Value);
                    seleccionados.Add(id);
                }
            }

            return seleccionados;
        }


        private void ActualizarEstadoBotones()
        {
            var seleccionados = ObtenerSeleccionados();

            // Habilitar solo si hay exactamente 1 seleccionado
            btnModificar.Enabled = (seleccionados.Count < 2);


        }

    }
}

