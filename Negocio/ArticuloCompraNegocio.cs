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
        public List<Proveedores> ListarConFiltro(string filtro)
        {
            List<Proveedores> lista = new List<Proveedores>();
            AccesoBD datos = new AccesoBD();

            try
            {
                string query = "SELECT IdProveedor, RazonSocial, CUIT FROM Proveedores WHERE Activo = 1";

                if (!string.IsNullOrEmpty(filtro))
                {
                    query += " AND (RazonSocial LIKE @filtro OR CUIT LIKE @filtro)";
                }

                datos.setearQuery(query);

                if (!string.IsNullOrEmpty(filtro))
                    datos.setearParametro("@filtro", "%" + filtro + "%");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Proveedores aux = new Proveedores();
                    aux.IdProveedor = (int)datos.Lector["IdProveedor"];
                    aux.RazonSocial = datos.Lector["RazonSocial"].ToString();
                    aux.CUIT = datos.Lector["CUIT"].ToString();

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
