using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;

namespace TPC_Comercio_Eq_14
{
    public partial class PageArticulos : System.Web.UI.Page
    {
        private const string SESSION_KEY = "SeleccionadosArticulos";

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

        private void CargarGrilla(string filtro = "")
        {
            ArticulosNegocio negocio = new ArticulosNegocio();

            var lista = string.IsNullOrWhiteSpace(filtro) ? negocio.ListarART() : negocio.Filtrar(filtro);

            if (chkMostrarActivos.Checked)
                lista = lista.Where(p => p.Activo).ToList();

            gvArticulos.DataSource = lista;
            gvArticulos.DataBind();


            List<int> seleccionados = CheckFiltradosNegocio.ObtenerSeleccionados(SESSION_KEY);
            RestaurarSeleccionados(seleccionados);
        }

        private void RestaurarSeleccionados(List<int> seleccionados)
        {
            foreach (GridViewRow row in gvArticulos.Rows)
            {
                CheckBox chk = row.FindControl("chkSeleccion") as CheckBox;

                if (chk != null)
                {
                    int id = (int)gvArticulos.DataKeys[row.RowIndex].Value;
                    chk.Checked = seleccionados.Contains(id);
                }
            }
        }

        protected void chkSeleccion_CheckedChanged(object sender, EventArgs e)
        {
            CheckFiltradosNegocio.GuardarSeleccionados(gvArticulos, SESSION_KEY);
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {

            CheckFiltradosNegocio.GuardarSeleccionados(gvArticulos, SESSION_KEY);


            CargarGrilla(txtFiltro.Text);
        }

        protected void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            CheckFiltradosNegocio.GuardarSeleccionados(gvArticulos, SESSION_KEY);

            txtFiltro.Text = "";
            CargarGrilla();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageAgregarART.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            CheckFiltradosNegocio.GuardarSeleccionados(gvArticulos, SESSION_KEY);

            List<int> seleccionados = CheckFiltradosNegocio.ObtenerSeleccionados(SESSION_KEY);

            if (seleccionados.Count == 1)
                Response.Redirect("PageModificarART.aspx?id=" + seleccionados[0]);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            CheckFiltradosNegocio.GuardarSeleccionados(gvArticulos, SESSION_KEY);

            List<int> seleccionados = CheckFiltradosNegocio.ObtenerSeleccionados(SESSION_KEY);

            if (seleccionados != null)
            {
                ArticulosNegocio negocio = new ArticulosNegocio();
                foreach (int id in seleccionados)
                    negocio.Eliminar(id, false);
            }

            CargarGrilla();
        }

        protected void gvArticulos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            List<int> seleccionados = CheckFiltradosNegocio.ObtenerSeleccionados(SESSION_KEY);
            CheckFiltradosNegocio.MarcarSeleccionados(e.Row, gvArticulos, seleccionados);
        }
        
        protected void btnQuitarSeleccion_Click(object sender, EventArgs e)
        {
            string sessionKey = SESSION_KEY;


            HttpContext.Current.Session[sessionKey] = new List<int>();


            foreach (GridViewRow row in gvArticulos.Rows)
            {
                CheckBox chk = row.FindControl("chkSeleccion") as CheckBox;
                if (chk != null)
                    chk.Checked = false;
            }
            CargarGrilla();
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            CheckFiltradosNegocio.GuardarSeleccionados(gvArticulos, SESSION_KEY);

        
            List<int> seleccionados = CheckFiltradosNegocio.ObtenerSeleccionados(SESSION_KEY);


            Session["IDsSeleccionados"] = seleccionados;

        
            Response.Redirect("~/GestionCompra.aspx", false);
        }

        protected void btnVender_Click(object sender, EventArgs e)
        {
            CheckFiltradosNegocio.GuardarSeleccionados(gvArticulos, SESSION_KEY);


            List<int> seleccionados = CheckFiltradosNegocio.ObtenerSeleccionados(SESSION_KEY);


            Session["IDsSeleccionados"] = seleccionados;


            Response.Redirect("~/GestionVenta.aspx", false);
        }

        protected void chkMostrarActivos_ServerChange(object sender, EventArgs e)
        {
            CargarGrilla(txtFiltro.Text.Trim());
        }
    }
}
