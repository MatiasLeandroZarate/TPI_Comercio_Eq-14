using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ArticuloCompraNegocio
    {
        public List<ArticuloCompra> ObtenerArticulosPorIds(List<int> ids)
        {
            if (ids == null || ids.Count == 0)
                return new List<ArticuloCompra>();

            List<ArticuloCompra> lista = new List<ArticuloCompra>();
            AccesoBD datos = new AccesoBD();

            try
            {
                string parametros = string.Join(",", ids.Select((id, i) => "@id" + i));

                datos.setearQuery($@"SELECT IDArticulo, Nombre, PrecioCompra, Stock FROM Articulos WHERE IDArticulo IN ({parametros})");

                for (int i = 0; i < ids.Count; i++)
                    datos.setearParametro("@id" + i, ids[i]);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    ArticuloCompra aux = new ArticuloCompra
                    {
                        IDArticulo = (int)datos.Lector["IDArticulo"],
                        Nombre = datos.Lector["Nombre"].ToString(),
                        PrecioCompra = (decimal)datos.Lector["PrecioCompra"],
                        StockActual = (int)datos.Lector["Stock"],
                    };

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
