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
            if (!IsPostBack)
            {
                string idClienteStr = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(idClienteStr))
                {
                    int idCliente = int.Parse(idClienteStr);
                    ClientesNegocio negocio = new ClientesNegocio();
                    Clientes clientes = negocio.ObtenerPorId(idCliente);

                    if (clientes != null)
                    {

                        txtIDCliente.Text = clientes.IdCliente.ToString();
                        txtDNI.Text = clientes.DNI;
                        txtCUIT.Text = clientes.CUIT;
                        txtApellido.Text = clientes.Apellido;
                        txtNombre.Text = clientes.Nombre;
                        txtTelefono.Text = clientes.Telefono;
                        txtEmail.Text = clientes.Email;
                        txtDireccion.Text = clientes.Direccion;
                        txtActivo.Text = clientes.Activo.ToString();
                    }
                }
            }
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageClientes.aspx", false);
        }

        //protected void Identificador_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox campo = (TextBox)sender;
        //    Clientes cli = null;

        //    if (campo.ID == "txtDNI" && !string.IsNullOrWhiteSpace(txtDNI.Text))
        //    {
        //        cli = ClienteEncontrado("DNI", txtDNI.Text);
        //    }

        //    else if (campo.ID == "txtIDCliente" && !string.IsNullOrWhiteSpace(txtIDCliente.Text))
        //    {
        //        cli = ClienteEncontrado("IDCliente", txtIDCliente.Text);
        //    }


        //    if (cli == null)
        //    {
        //        LimpiarFormulario();
        //        return;
        //    }

        //    txtIDCliente.Text = cli.IdCliente.ToString();
        //    txtDNI.Text = cli.DNI;
        //    txtCUIT.Text = cli.CUIT;
        //    txtApellido.Text = cli.Apellido;
        //    txtNombre.Text = cli.Nombre;
        //    txtTelefono.Text = cli.Telefono;
        //    txtEmail.Text = cli.Email;
        //    txtDireccion.Text = cli.Direccion;
        //}

      

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Clientes modificado = new Clientes();
            ClientesNegocio negocio = new ClientesNegocio();

            try
            {
                

                modificado.DNI = txtDNI.Text;
                modificado.CUIT = string.IsNullOrWhiteSpace(txtCUIT.Text) ? "Sin Datos" : txtCUIT.Text;
                modificado.Apellido = string.IsNullOrWhiteSpace(txtApellido.Text) ? "Sin Datos" : txtApellido.Text;
                modificado.Nombre = string.IsNullOrWhiteSpace(txtNombre.Text) ? "Sin Datos" : txtNombre.Text;
                modificado.Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? "Sin Datos" : txtTelefono.Text;
                modificado.Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? "Sin Datos" : txtEmail.Text;
                modificado.Direccion = string.IsNullOrWhiteSpace(txtDireccion.Text) ? "Sin Datos" : txtDireccion.Text;

                string valor = txtActivo.Text.Trim().ToLower();

                if (valor == "si" || valor == "1" || valor == "true")
                    modificado.Activo = true;
                else if (valor == "no" || valor == "0" || valor == "false")
                    modificado.Activo = false;
                else
                    modificado.Activo = false;

                negocio.Modificar(modificado);
                Response.Redirect("PageClientes.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("~/Error.aspx");
            }
        }

    }
}