using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Negocio
{
    public static class CheckFiltradosNegocio
    {
        public static void GuardarSeleccionados(GridView grid, string sessionKey)
        {
            List<int> seleccionados = ObtenerSeleccionados(sessionKey);

            foreach (GridViewRow row in grid.Rows)
            {
                CheckBox chk = row.FindControl("chkSeleccion") as CheckBox;
                int id = (int)grid.DataKeys[row.RowIndex].Value;

                if (chk != null && chk.Checked)
                {
                    if (!seleccionados.Contains(id))
                        seleccionados.Add(id);
                }
                else if (chk != null && !chk.Checked)
                {
                    if (seleccionados.Contains(id))
                        seleccionados.Remove(id);
                }
            }

            HttpContext.Current.Session[sessionKey] = seleccionados;
        }

        public static List<int> ObtenerSeleccionados(string sessionKey)
        {
            return HttpContext.Current.Session[sessionKey] as List<int>
                   ?? new List<int>();
        }

 
        public static void MarcarSeleccionados(GridViewRow row, GridView grilla, List<int> seleccionados)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                int id = Convert.ToInt32(grilla.DataKeys[row.RowIndex].Value);

                CheckBox chk = row.FindControl("chkSeleccion") as CheckBox;
                if (chk != null)
                {
                    chk.Checked = seleccionados.Contains(id);
                }
            }
        }


        public static void LimpiarSeleccion(string sessionKey)
        {
            System.Web.HttpContext.Current.Session.Remove(sessionKey);
        }
    }
}