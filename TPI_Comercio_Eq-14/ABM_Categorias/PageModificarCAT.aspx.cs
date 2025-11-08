using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Comercio_Eq_14.ABM_Categorias
{
    public partial class PageModificarCAT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtIDCategoria_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIDCategoria.Text))
            {
                return;
            }

            var cat = CategoriaEncontrada(txtIDCategoria.Text);

            if (cat == null)
            {
                LimpiarFormulario();
                return;
            }

            txtNombre.Text = cat.Nombre ?? string.Empty;
            txtDescripcion.Text = cat.Descripcion ?? string.Empty;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageCategorias.aspx", false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Categorias modificado = new Categorias();
            CategoriasNegocio negocio = new CategoriasNegocio();

            try
            {
                modificado.IdCategoria = int.Parse(txtIDCategoria.Text);
                modificado.Nombre = txtNombre.Text;
                modificado.Descripcion = txtDescripcion.Text;

                negocio.Modificar(modificado);
                Response.Redirect("PageCategorias.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Categorias CategoriaEncontrada(string IDCategoria)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearQuery("SELECT IDCategoria, Nombre, Descripcion FROM Categorias WHERE IDCategoria = @IDCategoria");
                datos.setearParametro("@IDCategoria", IDCategoria);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    var c = new Categorias();

                    c.IdCategoria = Convert.ToInt32(datos.Lector["IDCategoria"]);
                    c.Nombre = datos.Lector["Nombre"] == DBNull.Value ? string.Empty : (string)datos.Lector["Nombre"];
                    c.Descripcion = datos.Lector["Descripcion"] == DBNull.Value ? string.Empty : (string)datos.Lector["Descripcion"];

                    return c;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
        }
    }
}