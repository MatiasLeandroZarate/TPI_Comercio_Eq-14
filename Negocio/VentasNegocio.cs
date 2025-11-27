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
                datos.setearQuery("SELECT v.IDVenta, v.IDCliente, c.Apellido, c.Nombre, v.NroComprobante, v.Fecha, v.Descuentos, v.Subtotal, v.Total " +
                                  "FROM Venta v " +
                                  "INNER JOIN Clientes c ON v.IDCliente = c.IDCliente");
                datos.ejecutarLectura();

                int iIDVenta = datos.Lector.GetOrdinal("IDVenta");
                int iIDCliente = datos.Lector.GetOrdinal("IDCliente");
                int iApellido = datos.Lector.GetOrdinal("Apellido");
                int iNombre = datos.Lector.GetOrdinal("Nombre");
                int iNroComprobante = datos.Lector.GetOrdinal("NroComprobante");
                int iFecha = datos.Lector.GetOrdinal("Fecha");
                int iDescuentos = datos.Lector.GetOrdinal("Descuentos");
                int iSubtotal = datos.Lector.GetOrdinal("Subtotal");
                int iTotal = datos.Lector.GetOrdinal("Total");

                while (datos.Lector.Read())
                {
                    Ventas aux = new Ventas();

                    aux.IdVenta = datos.Lector.IsDBNull(iIDVenta) ? 0 : Convert.ToInt32(datos.Lector[iIDVenta]);
                    aux.IdCliente = datos.Lector.IsDBNull(iIDCliente) ? 0 : Convert.ToInt32(datos.Lector[iIDCliente]);

                    string apellido = datos.Lector.IsDBNull(iApellido) ? "" : datos.Lector[iApellido].ToString();
                    string nombre = datos.Lector.IsDBNull(iNombre) ? "" : datos.Lector[iNombre].ToString();
                    
                    aux.Cliente = $"{apellido}, {nombre}".Trim(' ', ',');

                    aux.NroComprobante = datos.Lector.IsDBNull(iNroComprobante) ? 0 : Convert.ToInt32(datos.Lector[iNroComprobante]);
                    aux.Fecha = datos.Lector.IsDBNull(iFecha) ? DateTime.MinValue : Convert.ToDateTime(datos.Lector[iFecha]);
                    aux.Descuentos = datos.Lector.IsDBNull(iDescuentos) ? 0m : Convert.ToDecimal(datos.Lector[iDescuentos]);
                    aux.SubTotal = datos.Lector.IsDBNull(iSubtotal) ? 0m : Convert.ToDecimal(datos.Lector[iSubtotal]);
                    aux.Total = datos.Lector.IsDBNull(iTotal) ? 0m : Convert.ToDecimal(datos.Lector[iTotal]);

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
