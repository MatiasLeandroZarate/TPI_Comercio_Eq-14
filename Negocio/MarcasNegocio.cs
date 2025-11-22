using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MarcasNegocio
    {
        public List<Marcas> ListarMAR()
        {
            List<Marcas> lista = new List<Marcas>();
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("SELECT IDMarca, Nombre FROM Marcas");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Marcas aux = new Marcas();

                    aux.IdMarca = (int)datos.Lector["IDMarca"];
                    aux.Nombre = (string)datos.Lector["Nombre"];

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
        public void Agregar(Marcas nuevo)
        {
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("INSERT INTO Marcas (Nombre) VALUES (@Nombre)");
                datos.setearParametro("@Nombre", nuevo.Nombre);

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
        public List<Marcas> Filtrar(string filtro)
        {
            List<Marcas> lista = new List<Marcas>();
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("SELECT IDMarca, Nombre FROM Marcas WHERE Nombre LIKE @filtro");
                datos.setearParametro("@filtro", "%" + filtro + "%");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marcas aux = new Marcas();

                    aux.IdMarca = (int)datos.Lector["IDMarca"];
                    aux.Nombre = (string)datos.Lector["Nombre"];

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
        public Marcas ObtenerPorId(int idMarca)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearQuery("SELECT IDMarca, Nombre FROM Marcas WHERE IDMarca = @IDMarca");
                datos.setearParametro("@IDMarca", idMarca);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Marcas m = new Marcas();
                    m.IdMarca = Convert.ToInt32(datos.Lector["IDMarca"]);
                    m.Nombre = datos.Lector["Nombre"].ToString();
                    return m;
                }
                return null;
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

        public void Modificar(Marcas modificado)
        {
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("UPDATE Marcas SET Nombre = @Nombre WHERE IDMarca = @IDMarca");
                datos.setearParametro("@Nombre", modificado.Nombre);
                datos.setearParametro("@IDMarca", modificado.IdMarca);
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
