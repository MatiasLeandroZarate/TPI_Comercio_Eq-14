using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VentaDetalleNegocio
    {
        public List<VentaDetalle> ListarDetalles(int idVenta)
        {
            List<VentaDetalle> lista = new List<VentaDetalle>();
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery(@"
                    SELECT vd.IDDetalleVenta, vd.IDVenta, vd.IDArticulo, a.Nombre as NombreArticulo, 
                           vd.Cantidad, vd.PrecioUnitario, (vd.Cantidad * vd.PrecioUnitario) as Subtotal
                    FROM VentasDetalle vd
                    INNER JOIN Articulos a ON vd.IDArticulo = a.IDArticulo
                    WHERE vd.IDVenta = @idVenta");

                datos.setearParametro("@idVenta", idVenta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    VentaDetalle aux = new VentaDetalle();
                    aux.IDDetalleVenta = (int)datos.Lector["IDDetalleVenta"];
                    aux.IDVenta = (int)datos.Lector["IDVenta"];
                    aux.IDArticulo = (int)datos.Lector["IDArticulo"];
                    aux.NombreArticulo = datos.Lector["NombreArticulo"].ToString();
                    aux.Cantidad = (int)datos.Lector["Cantidad"];
                    aux.PrecioUnitario = (decimal)datos.Lector["PrecioUnitario"];
                    aux.Subtotal = (decimal)datos.Lector["Subtotal"];

                    lista.Add(aux);
                }

                return lista;
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
    }
}
