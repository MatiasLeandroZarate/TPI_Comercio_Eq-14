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
        

    }
}
