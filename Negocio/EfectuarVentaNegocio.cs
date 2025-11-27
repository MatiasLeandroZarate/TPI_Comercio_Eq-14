using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EfectuarVentaNegocio
    {
        public void EfectuarVenta(Ventas venta, List<VentaDetalle> detalles)
        {
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.iniciarTransaccion();
                datos.setearQuery("SELECT ISNULL(MAX(NroComprobante), 0) + 1 FROM Venta WITH (UPDLOCK, HOLDLOCK)");
                datos.comando.Connection = datos.conexion;
                datos.comando.Transaction = datos.transaccion;
                int siguienteNro = Convert.ToInt32(datos.comando.ExecuteScalar());
                venta.NroComprobante = siguienteNro;
                datos.limpiarParametros();

                // 1) INSERT VENTA
                datos.setearQuery(@"INSERT INTO Venta 
                            (IDCliente, NroComprobante, Fecha, Descuentos, Subtotal, Total)
                            VALUES (@cliente, @nro, @fecha, @desc, @sub, @total);
                            SELECT SCOPE_IDENTITY();");

                datos.setearParametro("@cliente", venta.IdCliente);
                datos.setearParametro("@nro", venta.NroComprobante);
                datos.setearParametro("@fecha", venta.Fecha);
                datos.setearParametro("@desc", venta.Descuentos);
                datos.setearParametro("@sub", venta.SubTotal);
                datos.setearParametro("@total", venta.Total);

                datos.comando.Connection = datos.conexion;
                datos.comando.Transaction = datos.transaccion;

                object result = datos.comando.ExecuteScalar();
                int idVenta = Convert.ToInt32(result);
                venta.IdVenta = idVenta;

                datos.limpiarParametros();

                // 2) INSERT DETALLES
                foreach (VentaDetalle det in detalles)
                {
                    datos.limpiarParametros();

                    datos.setearQuery(@"INSERT INTO VentasDetalle
                                (IDVenta, IDArticulo, Cantidad, PrecioUnitario)
                                VALUES (@idv, @idart, @cant, @precio)");

                    datos.setearParametro("@idv", idVenta);
                    datos.setearParametro("@idart", det.IDArticulo);
                    datos.setearParametro("@cant", det.Cantidad);
                    datos.setearParametro("@precio", det.PrecioUnitario);

                    datos.comando.Connection = datos.conexion;
                    datos.comando.Transaction = datos.transaccion;

                    datos.comando.ExecuteNonQuery();
                }

                // 3) UPDATE STOCK
                foreach (VentaDetalle det in detalles)
                {
                    datos.limpiarParametros();

                    datos.setearQuery(@"UPDATE Articulos 
                                SET Stock = Stock + @cant 
                                WHERE IDArticulo = @idart");

                    datos.setearParametro("@cant", det.Cantidad);
                    datos.setearParametro("@idart", det.IDArticulo);

                    datos.comando.Connection = datos.conexion;
                    datos.comando.Transaction = datos.transaccion;

                    datos.comando.ExecuteNonQuery();
                }

                datos.commitTransaccion();
            }
            catch (Exception)
            {
                datos.rollbackTransaccion();
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int ObtenerUltimoNroComprobante()
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearQuery("SELECT ISNULL(MAX(NroComprobante), 0) FROM Venta");
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                    return Convert.ToInt32(datos.Lector[0]);

                return 0;
            }
            finally
            {
                datos.cerrarLector();
                datos.cerrarConexion();
            }
        }

        public void GuardarVenta(Ventas venta)
        {
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.iniciarTransaccion();

                datos.setearQuery(
                    "INSERT INTO Venta (IDCliente, NroComprobante, Fecha, Descuentos, Subtotal, Total) OUTPUT INSERTED.IDVenta VALUES (@cliente, @nro, @fecha, @desc, @sub, @tot)");

                datos.setearParametro("@cliente", venta.IdCliente);
                datos.setearParametro("@nro", venta.NroComprobante);
                datos.setearParametro("@fecha", venta.Fecha);
                datos.setearParametro("@desc", venta.Descuentos);
                datos.setearParametro("@sub", venta.SubTotal);
                datos.setearParametro("@tot", venta.Total);

                int idVenta = Convert.ToInt32(datos.ejecutarScalar());
                venta.IdVenta = idVenta;

                foreach (var det in venta.Detalles)
                {

                    datos.setearQuery(
                        "INSERT INTO VentasDetalle (IDVenta, IDArticulo, Cantidad, Fecha, PrecioUnitario) VALUES (@idv, @art, @cant, @fecha, @precio)"
                    );

                    datos.setearParametro("@idv", idVenta);
                    datos.setearParametro("@art", det.IDArticulo);
                    datos.setearParametro("@cant", det.Cantidad);
                    datos.setearParametro("@fecha", det.Fecha);
                    datos.setearParametro("@precio", det.PrecioUnitario);

                    datos.ejecutarAccion();

                    datos.setearQuery("UPDATE Articulos SET Stock = Stock + @cant WHERE IDArticulo = @id");

                    datos.setearParametro("@cant", det.Cantidad);
                    datos.setearParametro("@id", det.IDArticulo);

                    datos.ejecutarAccion();
                }

                datos.commitTransaccion();
            }
            catch (Exception)
            {
                try { datos.rollbackTransaccion(); } catch { }
                throw;
            }
            finally
            {

                datos.cerrarConexion();
            }
        }
    }
}
