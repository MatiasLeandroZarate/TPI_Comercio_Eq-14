using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Comercio_Eq_14.ABM_Clientes
{
    public partial class PageAgregarCLI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageClientes.aspx", false);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Clientes nuevo = new Clientes();
            ClientesNegocio negocio = new ClientesNegocio();
            try
            {
             
                if (string.IsNullOrWhiteSpace(txtDNI.Text) ||
                    string.IsNullOrWhiteSpace(txtApellido.Text) ||
                    string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtDireccion.Text))
                {
                    lblError.Text = "Complete los datos obligatorios.";
                    lblError.Visible = true;
                    return;
                }

                nuevo.DNI = txtDNI.Text;
                nuevo.CUIT = txtCUIT.Text;
                nuevo.Apellido = txtApellido.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Telefono = txtTelefono.Text;
                nuevo.Email = txtEmail.Text;
                nuevo.Direccion = txtDireccion.Text;
                nuevo.Activo = true;

              
                negocio.Agregar(nuevo);

              
                Response.Redirect("PageClientes.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}