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
                if (string.IsNullOrWhiteSpace(txtRazonSocial.Text) ||
                    string.IsNullOrWhiteSpace(txtCUIT.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtDireccion.Text))
                {
                    lblError.Text = "Complete los datos obligatorios.";
                    lblError.Visible = true;
                    return;
                }
                nuevo.RazonSocial = txtRazonSocial.Text;
                nuevo.CUIT = txtCUIT.Text;
                nuevo.Telefono = txtTelefono.Text;
                nuevo.Email = txtEmail.Text;
                nuevo.Direccion = txtDireccion.Text;
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