using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticulosNegocio
    {
        public List<Articulos> ListarART()
        {
            List<Articulos> lista = new List<Articulos>();
            List<Imagenes> imagenes = new List<Imagenes>();

            AccesoBD datos = new AccesoBD();

            try
            {
                //datos.setearStoreProcedure("storeListarART");
                datos.setearQuery("SELECT IDArticulo, CodigoBarra, Nombre, Descripcion, PrecioCompra, PrecioVenta, Stock, IDMarca, IDCategoria, Activo  FROM Articulos");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();

                    aux.IdArticulo = (int)datos.Lector["Id"];
                    aux.CodigoBarra = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.PrecioCompra = (decimal)datos.Lector["PrecioCompra"];
                    aux.PrecioVenta = (decimal)datos.Lector["PrecioVenta"];
                    aux.Stock = (int)datos.Lector["Stock"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    aux.Activo = (bool)datos.Lector["Activo"];



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
    }
}
