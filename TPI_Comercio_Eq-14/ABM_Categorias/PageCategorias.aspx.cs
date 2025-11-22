using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPC_Comercio_Eq_14
{
    public partial class PageCategorias : System.Web.UI.Page
    {
        private const string SESSION_KEY = "CategoriaSeleccionada";

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
            CategoriasNegocio negocio = new CategoriasNegocio();

            if (string.IsNullOrWhiteSpace(filtro))
                gvCategorias.DataSource = negocio.ListarCAT();
            else
                gvCategorias.DataSource = negocio.Filtrar(filtro);
            gvCategorias.DataBind();

            if (Session["CategoriaSeleccionada"] != null)
            {
                int seleccionado = (int)Session["CategoriaSeleccionada"];
                RestaurarSeleccion(seleccionado);
            }

        }

        private void RestaurarSeleccion(int seleccionado)
        {
            foreach (GridViewRow row in gvCategorias.Rows)
            {
                int id = (int)gvCategorias.DataKeys[row.RowIndex].Value;

                RadioButton rb = row.FindControl("rbSeleccion") as RadioButton;
                if (rb != null)
                    rb.Checked = (id == seleccionado);
            }
        }

        protected void rbSeleccion_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            GridViewRow row = (GridViewRow)rb.NamingContainer;

            int idSeleccionado = (int)gvCategorias.DataKeys[row.RowIndex].Value;

            // Guarda la selección en Session
            Session["CategoriaSeleccionada"] = idSeleccionado;

            // Desmarca el resto
            DeseleccionarOtros(idSeleccionado);
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

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageAgregarCAT.aspx", false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session[SESSION_KEY] == null)
                return;

            int id = (int)HttpContext.Current.Session[SESSION_KEY];
            Response.Redirect("PageModificarCAT.aspx?id=" + id, false);
        }
        protected void gvCategorias_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }
        private void DeseleccionarOtros(int idSeleccionado)
        {
            foreach (GridViewRow row in gvCategorias.Rows)
            {
                int id = (int)gvCategorias.DataKeys[row.RowIndex].Value;

                if (id != idSeleccionado)
                {
                    RadioButton rb = row.FindControl("rbSeleccion") as RadioButton;
                    if (rb != null) rb.Checked = false;
                }
            }
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using Negocio;
//using Dominio;

//namespace TPC_Comercio_Eq_14
//{
//    public partial class PageCategorias : System.Web.UI.Page
//    {
//        private const string SESSION_KEY = "SeleccionadosCategorias";
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                try
//                {
//                    CargarGrilla();
//                    //CategoriasNegocio negocio = new CategoriasNegocio();
//                    //List<Categorias> lista = negocio.ListarCAT();

//                    //gvCategorias.DataSource = lista;
//                    //gvCategorias.DataBind();
//                }
//                catch (Exception ex)
//                {
//                    Session.Add("Error", ex);
//                    Response.Redirect("~/Error.aspx");
//                }
//            }
//        }
//        private void CargarGrilla(string filtro = "")
//        {
//            ArticulosNegocio negocio = new ArticulosNegocio();

//            if (string.IsNullOrWhiteSpace(filtro))
//                gvCategorias.DataSource = negocio.ListarART();
//            else
//                gvCategorias.DataSource = negocio.Filtrar(filtro);

//            gvCategorias.DataBind();


//            List<int> seleccionados = CheckFiltradosNegocio.ObtenerSeleccionados(SESSION_KEY);
//            RestaurarSeleccionados(seleccionados);
//        }
//        private void RestaurarSeleccionados(List<int> seleccionados)
//        {
//            foreach (GridViewRow row in gvCategorias.Rows)
//            {
//                CheckBox chk = row.FindControl("chkSeleccion") as CheckBox;

//                if (chk != null)
//                {
//                    int id = (int)gvCategorias.DataKeys[row.RowIndex].Value;
//                    chk.Checked = seleccionados.Contains(id);
//                }
//            }
//        }
//        protected void txtFiltro_TextChanged(object sender, EventArgs e)
//        {

//            CheckFiltradosNegocio.GuardarSeleccionados(gvCategorias, SESSION_KEY);


//            CargarGrilla(txtFiltro.Text);
//        }
//        protected void btnAgregar_Click(object sender, EventArgs e)
//        {
//            Response.Redirect("PageAgregarCAT.aspx", false);
//        }

//        protected void btnModificar_Click(object sender, EventArgs e)
//        {

//            CheckFiltradosNegocio.GuardarSeleccionados(gvCategorias, SESSION_KEY);

//            List<int> seleccionados = CheckFiltradosNegocio.ObtenerSeleccionados(SESSION_KEY);

//            if (seleccionados.Count == 1)
//                Response.Redirect("PageModificarART.aspx?id=" + seleccionados[0]);
//            //if (gvCategorias.SelectedDataKey != null)
//            //{
//            //    int idCategoria = Convert.ToInt32(gvCategorias.SelectedDataKey.Value);
//            //    Response.Redirect("PageModificarCAT.aspx?id=" + idCategoria, false);
//            //}
//            //else
//            //{
//            //    Response.Redirect("PageModificarCAT.aspx", false);
//            //}
//        }
//    }
//}
