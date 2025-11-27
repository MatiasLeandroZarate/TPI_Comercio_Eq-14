using Dominio;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Negocio
{
    public class ComprasNegocio
    {
        public List<Compras> ListarCOM()
        {
            List<Compras> lista = new List<Compras>();
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("SELECT c.IDCompra, c.IDProveedor, p.RazonSocial, c.NroComprobante, c.Fecha, c.Descuentos, c.Subtotal, c.Total " +
                                  "FROM Compra c " +
                                  "INNER JOIN Proveedores p ON c.IDProveedor = p.IDProveedor;");
                datos.ejecutarLectura();

                int iIDCompra = datos.Lector.GetOrdinal("IDCompra");
                int iIDProveedor = datos.Lector.GetOrdinal("IDProveedor");
                int iRazonSocial = datos.Lector.GetOrdinal("RazonSocial");
                int iNroComprobante = datos.Lector.GetOrdinal("NroComprobante");
                int iFecha = datos.Lector.GetOrdinal("Fecha");
                int iDescuentos = datos.Lector.GetOrdinal("Descuentos");
                int iSubtotal = datos.Lector.GetOrdinal("Subtotal");
                int iTotal = datos.Lector.GetOrdinal("Total");

                while (datos.Lector.Read())
                {
                    Compras aux = new Compras();
                    aux.IdCompra = datos.Lector.IsDBNull(iIDCompra) ? 0 : Convert.ToInt32(datos.Lector[iIDCompra]);
                    aux.IdProveedor = datos.Lector.IsDBNull(iIDProveedor) ? 0 : Convert.ToInt32(datos.Lector[iIDProveedor]);
                    aux.RazonSocial = datos.Lector.IsDBNull(iRazonSocial) ? "" : datos.Lector[iRazonSocial].ToString();
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
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
