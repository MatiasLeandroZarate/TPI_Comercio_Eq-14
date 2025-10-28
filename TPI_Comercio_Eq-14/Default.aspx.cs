using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Comercio_Eq_14
{
    public partial class Default : System.Web.UI.Page
    {
        public string usuario { get; set; }
        public string Contraseña { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                return;
            ViewState["Contraseña"] = txtContraseña.Text;

            txtContraseña.TextMode = chkVerContraseña.Checked ? TextBoxMode.SingleLine : TextBoxMode.Password;
            if (ViewState["Contraseña"] != null)
            {
                txtContraseña.Attributes["value"] = ViewState["Contraseña"].ToString();
            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            usuario = txtEmail.Text.ToUpper();
            Contraseña = txtContraseña.Text.ToUpper();

            Response.Redirect("PageInicio.aspx",false);
        }
    }
}