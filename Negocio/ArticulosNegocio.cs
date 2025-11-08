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

            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("SELECT IDArticulo, Nombre, Descripcion, PrecioCompra, PrecioVenta, Stock, IDMarca, IDCategoria, Activo  FROM Articulos");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();

                    aux.IdArticulo = (int)datos.Lector["IDArticulo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.PrecioCompra = (decimal)datos.Lector["PrecioCompra"];
                    aux.PrecioVenta = (decimal)datos.Lector["PrecioVenta"];
                    aux.Stock = (int)datos.Lector["Stock"];
                    aux.IDMarca = (int)datos.Lector["IDMarca"];
                    aux.IDCategoria = (int)datos.Lector["IDCategoria"];
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

        public void Agregar(Articulos nuevo)
        {
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("INSERT INTO Articulos (Nombre, Descripcion, PrecioCompra, PrecioVenta, Stock, IDMarca, IDCategoria, Activo) VALUES (@Nombre, @Descripcion, @PrecioCompra, @PrecioVenta, @Stock, @IDMarca, @IDCategoria, @Activo)");
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@PrecioCompra", nuevo.PrecioCompra);
                datos.setearParametro("@PrecioVenta", nuevo.PrecioVenta);
                datos.setearParametro("@Stock", nuevo.Stock);
                datos.setearParametro("@IDMarca", nuevo.IDMarca);
                datos.setearParametro("@IDCategoria", nuevo.IDCategoria);
                datos.setearParametro("@Activo", 1);
                datos.ejecutarAccion();
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

        public void Modificar(Articulos modificado)
        {
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("UPDATE Articulos SET Nombre = @Nombre, Descripcion = @Descripcion, PrecioCompra = @PrecioCompra, PrecioVenta = @PrecioVenta, Stock = @Stock, IDMarca = @IDMarca, IDCategoria = @IDCategoria, Activo = @Activo WHERE IDArticulo = @IDArticulo");
                datos.setearParametro("@Nombre", modificado.Nombre);
                datos.setearParametro("@Descripcion", modificado.Descripcion);
                datos.setearParametro("@PrecioCompra", modificado.PrecioCompra);
                datos.setearParametro("@PrecioVenta", modificado.PrecioVenta);
                datos.setearParametro("@Stock", modificado.Stock);
                datos.setearParametro("@IDMarca", modificado.IDMarca);
                datos.setearParametro("@IDCategoria", modificado.IDCategoria);
                datos.setearParametro("@Activo", modificado.Activo);
                datos.setearParametro("@IDArticulo", modificado.IdArticulo);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Eliminar(int Id, bool Estado)
        {
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("UPDATE Articulos SET Activo = @Activo WHERE IDArticulo = @IDArticulo");
                datos.setearParametro("@Activo", Estado);
                datos.setearParametro("@IDArticulo", Id);
                datos.ejecutarAccion();
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
