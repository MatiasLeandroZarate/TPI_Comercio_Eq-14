using Dominio;
using Negocio;
using System;
using System.Web.UI;

namespace TPC_Comercio_Eq_14
{
    public partial class PageModificarART : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMarcas();
                CargarCategorias();

                string idArticuloStr = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(idArticuloStr))
                {
                    int idArticulo = int.Parse(idArticuloStr);
                    ArticulosNegocio negocio = new ArticulosNegocio();
                    Articulos articulo = negocio.ObtenerPorId(idArticulo);

                    if (articulo != null)
                    {
                        txtIdArticulo.Text = articulo.IdArticulo.ToString();
                      
                        txtNombre.Text = articulo.Nombre;
                        txtDescripcion.Text = articulo.Descripcion;
                        txtPrecioCompra.Text = articulo.PrecioCompra.ToString("0.##");
                        txtPrecioVenta.Text = articulo.PrecioVenta.ToString("0.##");
                        txtStock.Text = articulo.Stock.ToString();

                        if (ddlMarca.Items.FindByValue(articulo.IDMarca.ToString()) != null)
                            ddlMarca.SelectedValue = articulo.IDMarca.ToString();

                        if (ddlCategoria.Items.FindByValue(articulo.IDCategoria.ToString()) != null)
                            ddlCategoria.SelectedValue = articulo.IDCategoria.ToString();
                    }
                }
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageArticulos.aspx", false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Articulos modificado = new Articulos();
            ArticulosNegocio negocio = new ArticulosNegocio();

            try
            {
                modificado.IdArticulo = int.Parse(txtIdArticulo.Text);
                modificado.Nombre = txtNombre.Text;
                modificado.Descripcion = txtDescripcion.Text;
                modificado.PrecioCompra = string.IsNullOrWhiteSpace(txtPrecioCompra.Text) ? 0 : decimal.Parse(txtPrecioCompra.Text);
                modificado.PrecioVenta = string.IsNullOrWhiteSpace(txtPrecioVenta.Text) ? 0 : decimal.Parse(txtPrecioVenta.Text);
                modificado.Stock = string.IsNullOrWhiteSpace(txtStock.Text) ? 0 : int.Parse(txtStock.Text);
                modificado.IDMarca = int.Parse(ddlMarca.SelectedValue);
                modificado.IDCategoria = int.Parse(ddlCategoria.SelectedValue);
                modificado.Activo = true;

                negocio.Modificar(modificado);
                Response.Redirect("PageArticulos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("~/Error.aspx");
            }
        }

        private void CargarMarcas()
        {
            MarcasNegocio negocio = new MarcasNegocio();
            ddlMarca.DataSource = negocio.ListarMAR();
            ddlMarca.DataTextField = "Nombre";
            ddlMarca.DataValueField = "IdMarca";
            ddlMarca.DataBind();
            ddlMarca.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione una marca", ""));
        }

        private void CargarCategorias()
        {
            CategoriasNegocio negocio = new CategoriasNegocio();
            ddlCategoria.DataSource = negocio.ListarCAT();
            ddlCategoria.DataTextField = "Nombre";
            ddlCategoria.DataValueField = "IdCategoria";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione una categoría", ""));
        }
    }
}