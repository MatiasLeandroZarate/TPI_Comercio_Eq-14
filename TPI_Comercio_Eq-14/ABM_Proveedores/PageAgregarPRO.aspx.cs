using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Comercio_Eq_14.ABM_Proveedores
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageProveedores.aspx", false);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Proveedores nuevo = new Proveedores();
            ProveedoresNegocio negocio = new ProveedoresNegocio();

            try
            {
                nuevo.RazonSocial = txtRazonSocial.Text;
                nuevo.CUIT = string.IsNullOrWhiteSpace(txtCUIT.Text) ? "Sin Datos" : txtCUIT.Text;
                nuevo.Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? "Sin Datos" : txtTelefono.Text;
                nuevo.Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? "Sin Datos" : txtEmail.Text;
                nuevo.Direccion = string.IsNullOrWhiteSpace(txtDireccion.Text) ? "Sin Datos" : txtDireccion.Text;
                nuevo.Activo = true;

                negocio.Agregar(nuevo);
                Response.Redirect("PageProveedores.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("~/Error.aspx");
            }
        }
    }
}