using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class CategoriasNegocio
    {
        public List<Categorias> ListarCAT()
        {
        List<Categorias> lista = new List<Categorias>();

            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("SELECT IDCategoria, Nombre, Descripcion FROM Categorias");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Categorias aux = new Categorias();

                    aux.IdCategoria = (int)datos.Lector["IDCategoria"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    

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

        public void Agregar(Categorias nuevo)
        {
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("INSERT INTO Categorias (Nombre, Descripcion) VALUES (@Nombre, @Descripcion)");
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);

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
        public List<Categorias> Filtrar(string filtro)
        {
            List<Categorias> lista = new List<Categorias>();
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("SELECT IDCategoria, Nombre, Descripcion FROM Categorias WHERE Nombre LIKE @filtro OR Descripcion LIKE @filtro");
                datos.setearParametro("@filtro", "%" + filtro + "%");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categorias aux = new Categorias();

                    aux.IdCategoria = (int)datos.Lector["IDCategoria"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }

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

        public Categorias ObtenerPorId(int id)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearQuery("SELECT * FROM Categorias Where IDCategoria = @IDCategoria");
                datos.setearParametro("@IDCategoria", id);
                datos.ejecutarLectura();
                if(datos.Lector.Read())
                {
                    Categorias cat = new Categorias();
                    cat.IdCategoria = (int)datos.Lector["IDCategoria"];
                    cat.Nombre = (string)datos.Lector["Nombre"];
                    cat.Descripcion = (string)datos.Lector["Descripcion"];
                    return cat;
                }

                return null;

            }
           finally { datos.cerrarConexion(); }
        }
        public void Modificar(Categorias modificado)
        {
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("UPDATE Categorias SET Nombre = @Nombre, Descripcion = @Descripcion WHERE IDCategoria = @IDCategoria");
                datos.setearParametro("@Nombre", modificado.Nombre);
                datos.setearParametro("@Descripcion", modificado.Descripcion);
                datos.setearParametro("@IDCategoria", modificado.IdCategoria);
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
      
    }
}
