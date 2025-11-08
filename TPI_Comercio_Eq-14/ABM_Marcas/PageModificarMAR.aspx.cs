using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Comercio_Eq_14.ABM_Marcas
{
    public partial class PageModificarMAR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtIDMarca_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIDMarca.Text))
            {
                return;
            }

            var mar = MarcaEncontrada(txtIDMarca.Text);

            if (mar == null)
            {
                LimpiarFormulario();
                return;
            }

            txtNombre.Text = mar.Nombre ?? string.Empty;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageMarcas.aspx", false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Marcas modificado = new Marcas();
            MarcasNegocio negocio = new MarcasNegocio();

            try
            {
                modificado.IdMarca = int.Parse(txtIDMarca.Text);
                modificado.Nombre = txtNombre.Text;

                negocio.Modificar(modificado);
                Response.Redirect("PageMarcas.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Marcas MarcaEncontrada(string IDMarca)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearQuery("SELECT IDMarca, Nombre FROM Marcas WHERE IDMarca = @IDMarca");
                datos.setearParametro("@IDMarca", IDMarca);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    var m = new Marcas();

                    m.IdMarca = Convert.ToInt32(datos.Lector["IDMarca"]);
                    m.Nombre = datos.Lector["Nombre"] == DBNull.Value ? string.Empty : (string)datos.Lector["Nombre"];

                    return m;
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
        }
    }
}