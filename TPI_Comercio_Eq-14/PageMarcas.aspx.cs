using Dominio;
using Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Comercio_Eq_14
{
    public partial class PageMarcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MarcasNegocio negocio = new MarcasNegocio();
            List<Marcas> lista = new List<Marcas>();
            if (!IsPostBack)
            {
                try
                {
                    lista = negocio.ListarMAR();

                    rptMarcas.DataSource = lista;
                    rptMarcas.DataBind();

                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex);
                    Response.Redirect("Error.aspx");
                }
            }


        }
    }
}