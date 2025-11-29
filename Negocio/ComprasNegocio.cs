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
        public List<Compras> BuscarTexto(string filtro)
        {
            List<Compras> lista = new List<Compras>();
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery(@"SELECT c.IDCompra, c.IDProveedor, p.RazonSocial, c.NroComprobante, 
                            c.Fecha, c.Descuentos, c.SubTotal, c.Total
                            FROM Compra c
                            INNER JOIN Proveedores p ON c.IDProveedor = p.IDProveedor
                            WHERE p.RazonSocial LIKE '%' + @filtro + '%' 
                               OR c.NroComprobante LIKE '%' + @filtro + '%'");

                datos.setearParametro("@filtro", filtro);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Compras aux = new Compras();
                    aux.IdCompra = (int)datos.Lector["IDCompra"];
                    aux.RazonSocial = datos.Lector["RazonSocial"].ToString();
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
        public List<Compras> BuscarFecha(DateTime desde, DateTime hasta)
        {
            List<Compras> lista = new List<Compras>();
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery(@"SELECT c.IDCompra, c.IDProveedor, p.RazonSocial, c.NroComprobante, 
                            c.Fecha, c.Descuentos, c.SubTotal, c.Total
                            FROM Compra c
                            INNER JOIN Proveedores p ON c.IDProveedor = p.IDProveedor
                            WHERE c.Fecha BETWEEN @desde AND @hasta");

                datos.setearParametro("@desde", desde);
                datos.setearParametro("@hasta", hasta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Compras aux = new Compras();
                    aux.IdCompra = (int)datos.Lector["IDCompra"];
                    aux.RazonSocial = datos.Lector["RazonSocial"].ToString();
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
        public List<Compras> ListarConFiltro(string texto, DateTime? desde, DateTime? hasta)
        {
            List<Compras> lista = new List<Compras>();
            AccesoBD datos = new AccesoBD();

            try
            {
                string query = @"SELECT c.IDCompra, c.IDProveedor, p.RazonSocial,
                         c.NroComprobante, c.Fecha, c.Descuentos, c.Subtotal, c.Total
                         FROM Compra c
                         INNER JOIN Proveedores p ON c.IDProveedor = p.IDProveedor
                         WHERE 1=1";

                if (!string.IsNullOrEmpty(texto))
                {
                    query += " AND (p.RazonSocial LIKE @texto OR c.NroComprobante LIKE @texto)";
                }

                if (desde.HasValue)
                    query += " AND c.Fecha >= @desde";

                if (hasta.HasValue)
                    query += " AND c.Fecha <= @hasta";

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
                    Compras aux = new Compras();
                    aux.IdCompra = (int)datos.Lector["IDCompra"];
                    aux.IdProveedor = (int)datos.Lector["IDProveedor"];
                    aux.RazonSocial = datos.Lector["RazonSocial"].ToString();
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
