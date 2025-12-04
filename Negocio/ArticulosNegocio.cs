using System;
using System.Collections.Generic;
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
                datos.setearQuery("SELECT IDArticulo, Nombre, Descripcion, PrecioCompra, PrecioVenta, Stock, IDMarca, IDCategoria, Activo FROM Articulos");
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
                    aux.Activo = bool.Parse(datos.Lector["Activo"].ToString());

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

        public Articulos ObtenerPorId(int id)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearQuery("SELECT * FROM Articulos WHERE IDArticulo = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Articulos art = new Articulos();
                    art.IdArticulo = (int)datos.Lector["IDArticulo"];
                    art.Nombre = (string)datos.Lector["Nombre"];
                    art.Descripcion = (string)datos.Lector["Descripcion"];
                    art.PrecioCompra = (decimal)datos.Lector["PrecioCompra"];
                    art.PrecioVenta = (decimal)datos.Lector["PrecioVenta"];
                    art.Stock = (int)datos.Lector["Stock"];
                    art.IDMarca = (int)datos.Lector["IDMarca"];
                    art.IDCategoria = (int)datos.Lector["IDCategoria"];
                    art.Activo = bool.Parse(datos.Lector["Activo"].ToString());

                    return art;
                }

                return null;
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
                datos.setearParametro("@Activo", nuevo.Activo);
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
            catch (Exception ex)
            {
                throw ex;
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

        public List<Articulos> Filtrar(string filtro)
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("SELECT IDArticulo, Nombre, Descripcion, PrecioCompra, PrecioVenta, Stock, IDMarca, IDCategoria, Activo FROM Articulos WHERE Nombre LIKE @filtro OR Descripcion LIKE @filtro");
                datos.setearParametro("@filtro", "%" + filtro + "%");
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
                    aux.Activo = bool.Parse(datos.Lector["Activo"].ToString());

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
        public void ModificarPrecioCompra(int idArticulo, decimal nuevoPrecio)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearQuery("UPDATE Articulos SET PrecioCompra = @precio WHERE IDArticulo = @id");
                datos.setearParametro("@precio", nuevoPrecio);
                datos.setearParametro("@id", idArticulo);
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
        public void ModificarPrecioVenta(int idArticulo, decimal nuevoPrecio)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearQuery("UPDATE Articulos SET PrecioVenta = @precio WHERE IDArticulo = @id");
                datos.setearParametro("@precio", nuevoPrecio);
                datos.setearParametro("@id", idArticulo);
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
