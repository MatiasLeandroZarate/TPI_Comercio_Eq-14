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
    public partial class PageModificarPRO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string idProvedorStr = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(idProvedorStr))
                {
                    int idProveedor = int.Parse(idProvedorStr);
                    ProveedoresNegocio negocio = new ProveedoresNegocio();
                    Proveedores proveedor = negocio.ObtenerPorId(idProveedor);

                    if (proveedor != null)
                    {
                        txtIdProveedor.Text = proveedor.IdProveedor.ToString();

                        txtRazonSocial.Text = proveedor.RazonSocial;
                        txtCUIT.Text = proveedor.CUIT;
                        txtTelefono.Text = proveedor.Telefono;
                        txtEmail.Text = proveedor.Email;
                        txtDireccion.Text = proveedor.Direccion;
                        txtActivo.Text = proveedor.Activo.ToString();
                    }
                }
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PageProveedores.aspx", false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Proveedores modificado = new Proveedores();
            ProveedoresNegocio negocio = new ProveedoresNegocio();

            try
            {
                modificado.IdProveedor = int.Parse(txtIdProveedor.Text);

                modificado.RazonSocial = string.IsNullOrWhiteSpace(txtRazonSocial.Text) ? "Sin Datos" : txtRazonSocial.Text;
                modificado.CUIT = string.IsNullOrWhiteSpace(txtCUIT.Text) ? "Sin Datos" : txtCUIT.Text;
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