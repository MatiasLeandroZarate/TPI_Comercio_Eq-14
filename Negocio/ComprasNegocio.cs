using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ComprasNegocio
    {
            List<Compras> lista = new List<Compras>();
        public List<Compras> ListarCOM()
        {

            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("SELECT IDCompra, IDProveedor, NroComprobante, Fecha, Descuentos, Subtotal, Total FROM Compra");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Compras aux = new Compras();

                    aux.IdCompra = (int)datos.Lector["IDCompra"];
                    aux.IdProveedor = (int)datos.Lector["IDProveedor"];
                    aux.NroComprobante = (string)datos.Lector["NroComprobante"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.Descuentos = (decimal)datos.Lector["Descuentos"];
                    aux.SubTotal = (decimal)datos.Lector["Subtotal"];
                    aux.Total = (decimal)datos.Lector["Total"];

                    lista.Add(aux);
                }
                datos.cerrarLector();

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
