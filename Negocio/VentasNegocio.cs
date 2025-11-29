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
                datos.setearQuery("SELECT v.IDVenta, v.IDCliente,CONCAT( c.Apellido,', ',c.Nombre) AS Cliente, c.DNI , v.NroComprobante, v.Fecha, v.Descuentos, v.Subtotal, v.Total FROM Venta v INNER JOIN Clientes c ON v.IDCliente = c.IDCliente");
                datos.ejecutarLectura();

                int iIDVenta = datos.Lector.GetOrdinal("IDVenta");
                int iIDCliente = datos.Lector.GetOrdinal("IDCliente");
                int iCliente = datos.Lector.GetOrdinal("Cliente");
                int iDNI = datos.Lector.GetOrdinal("DNI");
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

                    string ncliente = datos.Lector.IsDBNull(iCliente) ? "" : datos.Lector[iCliente].ToString();
                    //string nombre = datos.Lector.IsDBNull(iNombre) ? "" : datos.Lector[iNombre].ToString();
                    
                    aux.Cliente = datos.Lector.IsDBNull(iCliente) ? "" : datos.Lector[iCliente].ToString();
                    aux.DNI = datos.Lector.IsDBNull(iDNI) ? "" : datos.Lector[iDNI].ToString();

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
        public List<Ventas> ListarConFiltro(string texto, DateTime? desde, DateTime? hasta)
        {
            List<Ventas> lista = new List<Ventas>();
            AccesoBD datos = new AccesoBD();

            try
            {
                string query = @"SELECT v.IDVenta, v.IDcliente, CONCAT( c.Apellido,', ',c.Nombre) AS Cliente, c.DNI,v.NroComprobante, v.Fecha, v.Descuentos, v.Subtotal, v.Total
                         FROM Venta v
                         INNER JOIN Clientes c ON v.IDCliente = c.IDcliente
                         WHERE 1=1";

                if (!string.IsNullOrEmpty(texto))
                {
                    query += " AND (c.nombre LIKE @texto OR c.Apellido LIKE @texto OR c.DNI LIKE @texto OR v.NroComprobante LIKE @texto)";
                }

                if (desde.HasValue)
                    query += " AND v.Fecha >= @desde";

                if (hasta.HasValue)
                    query += " AND v.Fecha <= @hasta";

                datos.setearQuery(query);

                if (!string.IsNullOrEmpty(texto))
                    datos.setearParametro("@texto", "%" + texto + "%");

                if (desde.HasValue)
                    datos.setearParametro("@desde", desde.Value);

                if (hasta.HasValue)
                    datos.setearParametro("@hasta", hasta.Value);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Ventas aux = new Ventas();
                    aux.IdVenta = (int)datos.Lector["IDVenta"];
                    aux.IdCliente = (int)datos.Lector["IDCliente"];
                    aux.Cliente = datos.Lector["Cliente"].ToString();
                    aux.DNI = datos.Lector["DNI"].ToString();
                    aux.NroComprobante = (int)datos.Lector["NroComprobante"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.Descuentos = (decimal)datos.Lector["Descuentos"];
                    aux.SubTotal = (decimal)datos.Lector["Subtotal"];
                    aux.Total = (decimal)datos.Lector["Total"];

                    lista.Add(aux);
                }

                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}
