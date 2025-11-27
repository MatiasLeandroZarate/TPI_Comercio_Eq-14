using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ArticuloVentaNegocio
    {
        public List<ArticuloVenta> ObtenerArticulosPorIds(List<int> ids)
        {
            if (ids == null || ids.Count == 0)
                return new List<ArticuloVenta>();

            List<ArticuloVenta> lista = new List<ArticuloVenta>();
            AccesoBD datos = new AccesoBD();

            try
            {
                string parametros = string.Join(",", ids.Select((id, i) => "@id" + i));

                datos.setearQuery($@"SELECT IDArticulo, Nombre, PrecioVenta, Stock FROM Articulos WHERE IDArticulo IN ({parametros})");

                for (int i = 0; i < ids.Count; i++)
                    datos.setearParametro("@id" + i, ids[i]);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    ArticuloVenta aux = new ArticuloVenta
                    {
                        IDArticulo = (int)datos.Lector["IDArticulo"],
                        Nombre = datos.Lector["Nombre"].ToString(),
                        PrecioVenta = (decimal)datos.Lector["PrecioVenta"],
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
        public List<Clientes> ListarConFiltro(string filtro)
        {
            List<Clientes> lista = new List<Clientes>();
            AccesoBD datos = new AccesoBD();

            try
            {
                string query = "SELECT IdCliente, Apellido, Nombre, DNI FROM Clientes WHERE Activo = 1";

                if (!string.IsNullOrEmpty(filtro))
                {
                    query += " AND (Apellido LIKE @filtro OR Nombre LIKE @filtro OR DNI LIKE @filtro)";
                }

                datos.setearQuery(query);

                if (!string.IsNullOrEmpty(filtro))
                    datos.setearParametro("@filtro", "%" + filtro + "%");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Clientes aux = new Clientes();
                    aux.IdCliente = (int)datos.Lector["IdCliente"];
                    aux.Apellido = datos.Lector["Apellido"].ToString();
                    aux.Nombre = datos.Lector["Nombre"].ToString();
                    aux.DNI = datos.Lector["DNI"].ToString();

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
