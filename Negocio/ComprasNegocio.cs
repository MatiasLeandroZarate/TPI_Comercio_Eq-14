using Dominio;
using System;
using System.Collections.Generic;

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
                datos.setearQuery("SELECT IDCompra, IDProveedor, NroComprobante, Fecha, Descuentos, Subtotal, Total FROM Compra");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Compras aux = new Compras();
                    aux.IdCompra = (int)datos.Lector["IDCompra"];
                    aux.IdProveedor = (int)datos.Lector["IDProveedor"];
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
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
