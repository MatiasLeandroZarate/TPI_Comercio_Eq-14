using System;
using System.Collections.Generic;
using System.Linq;
using Dominio;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CompraDetalleNegocio
    {
        public List<CompraDetalle> ListarDetalles(int idCompra)
        {
            List<CompraDetalle> lista = new List<CompraDetalle>();
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery(@"
                    SELECT cd.IDDetalleCompra, cd.IDCompra, cd.IDArticulo, a.Nombre as NombreArticulo, 
                           cd.Cantidad, cd.PrecioUnitario, (cd.Cantidad * cd.PrecioUnitario) as Subtotal
                    FROM ComprasDetalle cd
                    INNER JOIN Articulos a ON cd.IDArticulo = a.IDArticulo
                    WHERE cd.IDCompra = @idCompra");

                datos.setearParametro("@idCompra", idCompra);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    CompraDetalle aux = new CompraDetalle();
                    aux.IDDetalleCompra = (int)datos.Lector["IDDetalleCompra"];
                    aux.IDCompra = (int)datos.Lector["IDCompra"];
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
