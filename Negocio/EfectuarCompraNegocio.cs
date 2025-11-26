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

                datos.setearQuery(
                    "INSERT INTO Compra (IDProveedor, NroComprobante, Fecha, Descuentos, Subtotal, Total) " +
                    "OUTPUT INSERTED.IDCompra " +
                    "VALUES (@IDProveedor, @NroComprobante, @Fecha, @Descuentos, @Subtotal, @Total)"
                );

                datos.setearParametro("@IDProveedor", compra.IdProveedor);
                datos.setearParametro("@NroComprobante", compra.NroComprobante);
                datos.setearParametro("@Fecha", compra.Fecha);
                datos.setearParametro("@Descuentos", compra.Descuentos);
                datos.setearParametro("@Subtotal", compra.SubTotal);
                datos.setearParametro("@Total", compra.Total);

                int idCompraGenerado = Convert.ToInt32(datos.ejecutarScalar());
                compra.IdCompra = idCompraGenerado;

                foreach (var det in detalles)
                {
                    datos.setearQuery(
                        "INSERT INTO ComprasDetalle (IDCompra, IDArticulo, Cantidad, Fecha, PrecioUnitario) " +
                        "VALUES (@IDCompra, @IDArticulo, @Cantidad, GETDATE(), @PrecioUnitario)"
                    );

                    datos.setearParametro("@IDCompra", idCompraGenerado);
                    datos.setearParametro("@IDArticulo", det.IDArticulo);
                    datos.setearParametro("@Cantidad", det.Cantidad);
                    datos.setearParametro("@PrecioUnitario", det.PrecioUnitario);

                    datos.ejecutarAccion(); 

                    datos.setearQuery(
                        "UPDATE Articulos SET Stock = Stock + @Cantidad WHERE IDArticulo = @IDArticulo"
                    );

                    datos.setearParametro("@Cantidad", det.Cantidad);
                    datos.setearParametro("@IDArticulo", det.IDArticulo);

                    datos.ejecutarAccion(); 
                }

                datos.commitTransaccion();
            }
            catch (Exception ex)
            {
                datos.rollbackTransaccion();
                throw ex;
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
                    "INSERT INTO Compra (IDProveedor, NroComprobante, Fecha, Descuentos, Subtotal, Total) " +
                    "OUTPUT INSERTED.IDCompra " +
                    "VALUES (@prov, @nro, @fecha, @desc, @sub, @tot)"
                );

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