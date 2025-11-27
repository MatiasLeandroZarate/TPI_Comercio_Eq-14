using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
    public class EfectuarCompraNegocio
    {

        public void EfectuarCompra(Compras compra, List<CompraDetalle> detalles)
        {
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.iniciarTransaccion();
                datos.setearQuery("SELECT ISNULL(MAX(NroComprobante), 0) + 1 FROM Compra WITH (UPDLOCK, HOLDLOCK)");
                datos.comando.Connection = datos.conexion;
                datos.comando.Transaction = datos.transaccion;
                int siguienteNro = Convert.ToInt32(datos.comando.ExecuteScalar());
                compra.NroComprobante = siguienteNro;
                datos.limpiarParametros();

                // 1) INSERT COMPRA
                datos.setearQuery(@"INSERT INTO Compra 
                            (IDProveedor, NroComprobante, Fecha, Descuentos, Subtotal, Total)
                            VALUES (@prov, @nro, @fecha, @desc, @sub, @total);
                            SELECT SCOPE_IDENTITY();");

                datos.setearParametro("@prov", compra.IdProveedor);
                datos.setearParametro("@nro", compra.NroComprobante);
                datos.setearParametro("@fecha", compra.Fecha);
                datos.setearParametro("@desc", compra.Descuentos);
                datos.setearParametro("@sub", compra.SubTotal);
                datos.setearParametro("@total", compra.Total);

                datos.comando.Connection = datos.conexion;
                datos.comando.Transaction = datos.transaccion;

                object result = datos.comando.ExecuteScalar();
                int idCompra = Convert.ToInt32(result);
                compra.IdCompra = idCompra;

                datos.limpiarParametros();

                // 2) INSERT DETALLES
                foreach (CompraDetalle det in detalles)
                {
                    datos.limpiarParametros();

                    datos.setearQuery(@"INSERT INTO ComprasDetalle
                                (IDCompra, IDArticulo, Cantidad, PrecioUnitario)
                                VALUES (@idc, @idart, @cant, @precio)");

                    datos.setearParametro("@idc", idCompra);
                    datos.setearParametro("@idart", det.IDArticulo);
                    datos.setearParametro("@cant", det.Cantidad);
                    datos.setearParametro("@precio", det.PrecioUnitario);

                    datos.comando.Connection = datos.conexion;
                    datos.comando.Transaction = datos.transaccion;

                    datos.comando.ExecuteNonQuery();
                }

                // 3) UPDATE STOCK
                foreach (CompraDetalle det in detalles)
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
                datos.setearQuery("SELECT ISNULL(MAX(NroComprobante), 0) FROM Compra");
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

        public void GuardarCompra(Compras compra)
        {
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.iniciarTransaccion();

                datos.setearQuery(
                    "INSERT INTO Compra (IDProveedor, NroComprobante, Fecha, Descuentos, Subtotal, Total) OUTPUT INSERTED.IDCompra VALUES (@prov, @nro, @fecha, @desc, @sub, @tot)");

                datos.setearParametro("@prov", compra.IdProveedor);
                datos.setearParametro("@nro", compra.NroComprobante);
                datos.setearParametro("@fecha", compra.Fecha); 
                datos.setearParametro("@desc", compra.Descuentos);
                datos.setearParametro("@sub", compra.SubTotal);
                datos.setearParametro("@tot", compra.Total);

                int idCompra = Convert.ToInt32(datos.ejecutarScalar());
                compra.IdCompra = idCompra;

                foreach (var det in compra.Detalles)
                {
                   
                    datos.setearQuery(
                        "INSERT INTO ComprasDetalle (IDCompra, IDArticulo, Cantidad, Fecha, PrecioUnitario) VALUES (@idc, @art, @cant, @fecha, @precio)"
                    );

                    datos.setearParametro("@idc", idCompra);
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
                try { datos.rollbackTransaccion(); } catch {  }
                throw;
            }
            finally
            {
               
                datos.cerrarConexion();
            }
        }
    }
}