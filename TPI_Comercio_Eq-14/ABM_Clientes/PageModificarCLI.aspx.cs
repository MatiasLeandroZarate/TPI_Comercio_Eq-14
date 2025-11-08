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
    public partial class PageModificarCLI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack){ }
        }

        protected void Identificador_TextChanged(object sender, EventArgs e)
        {
            TextBox campo = (TextBox)sender;
            Clientes cli = null;

            if (campo.ID == "txtDNI" && !string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                cli = ClienteEncontrado("DNI", txtDNI.Text);
            }

            else if(campo.ID == "txtIDCliente" && !string.IsNullOrWhiteSpace(txtIDCliente.Text))
            {
                cli = ClienteEncontrado("IDCliente", txtIDCliente.Text);
            }


            if (cli == null)
            {
                LimpiarFormulario();
                return;
            }

            txtIDCliente.Text = cli.IdCliente.ToString();
            txtDNI.Text = cli.DNI;
            txtCUIT.Text = cli.CUIT;
            txtApellido.Text = cli.Apellido;
            txtNombre.Text = cli.Nombre;
            txtTelefono.Text = cli.Telefono;
            txtEmail.Text = cli.Email;
            txtDireccion.Text = cli.Direccion;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageClientes.aspx", false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Clientes modificado = new Clientes();
            ClientesNegocio negocio = new ClientesNegocio();

            try
            {
                modificado.DNI = txtDNI.Text;
                modificado.CUIT = txtCUIT.Text;
                modificado.Apellido = txtApellido.Text;
                modificado.Nombre = txtNombre.Text;
                modificado.Telefono = txtTelefono.Text;
                modificado.Email = txtEmail.Text;
                modificado.Direccion = txtDireccion.Text;

                negocio.Modificar(modificado);
                Response.Redirect("PageClientes.aspx", false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Clientes ClienteEncontrado(string campo, string valor)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearQuery($"SELECT IDCliente, DNI, CUIT, Apellido, Nombre, Telefono, Email, Direccion FROM Clientes WHERE {campo} = @valor");
                datos.setearParametro("@valor", valor);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    var c = new Clientes();

                    c.IdCliente = Convert.ToInt32(datos.Lector["IDCliente"]);
                    c.DNI = datos.Lector["DNI"].ToString();
                    c.CUIT = datos.Lector["CUIT"].ToString();
                    c.Apellido = datos.Lector["Apellido"].ToString();
                    c.Nombre = datos.Lector["Nombre"].ToString();
                    c.Telefono = datos.Lector["Telefono"].ToString();
                    c.Email = datos.Lector["Email"].ToString();
                    c.Direccion = datos.Lector["Direccion"].ToString();

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
            txtIDCliente.Text = "";
            txtDNI.Text = "";
            txtCUIT.Text = "";
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtDireccion.Text = "";
        }
    }
}