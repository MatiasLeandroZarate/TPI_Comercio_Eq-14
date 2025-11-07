using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VentasNegocio
    {
        public List<Ventas> ListarVEN()
        {
            List<Ventas> lista = new List<Ventas>();
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("SELECT IDVenta, IDCliente, NroComprobante, Fecha, Descuentos, Subtotal, Total FROM Venta");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Ventas aux = new Ventas();

                    aux.IdVenta = (int)datos.Lector["IDVenta"];
                    aux.IdCliente = (int)datos.Lector["IDCliente"];
                    aux.NroComprobante = (int)datos.Lector["NroComprobante"];
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
