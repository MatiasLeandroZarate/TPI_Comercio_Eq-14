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
