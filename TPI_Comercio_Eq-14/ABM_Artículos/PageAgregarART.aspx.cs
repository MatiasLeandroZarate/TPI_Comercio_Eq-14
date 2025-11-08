using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_Comercio_Eq_14
{
    public partial class PageAgregarART : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMarcas();
                CargarCategorias();
            }
        }
        
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageArticulos.aspx", false);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Articulos nuevo = new Articulos();
            ArticulosNegocio negocio = new ArticulosNegocio();

            try
            {
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.PrecioCompra = string.IsNullOrWhiteSpace(txtPrecioCompra.Text) ? 0 : decimal.Parse(txtPrecioCompra.Text);
                nuevo.PrecioVenta = string.IsNullOrWhiteSpace(txtPrecioVenta.Text) ? 0 : decimal.Parse(txtPrecioVenta.Text);
                nuevo.Stock = int.Parse(txtStock.Text);
                nuevo.IDMarca = int.Parse(ddlMarca.SelectedValue);
                nuevo.IDCategoria = int.Parse(ddlCategoria.SelectedValue);
                nuevo.Activo = true;

                negocio.Agregar(nuevo);
                Response.Redirect("PageArticulos.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarMarcas()
        {
            MarcasNegocio negocio = new MarcasNegocio();
            ddlMarca.DataSource = negocio.ListarMAR();
            ddlMarca.DataTextField = "Nombre";
            ddlMarca.DataValueField = "IdMarca";
            ddlMarca.DataBind();
            ddlMarca.Items.Insert(0, new ListItem("Seleccione una marca", ""));
        }

        private void CargarCategorias()
        {
            CategoriasNegocio negocio = new CategoriasNegocio();
            ddlCategoria.DataSource = negocio.ListarCAT();
            ddlCategoria.DataTextField = "Nombre";
            ddlCategoria.DataValueField = "IdCategoria";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new ListItem("Seleccione una categoría", ""));
        }
    }
}