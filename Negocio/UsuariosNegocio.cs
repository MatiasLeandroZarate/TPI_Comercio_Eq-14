using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public List<Usuarios> ListarUSU()
            {
                List<Usuarios> lista = new List<Usuarios>();

                AccesoBD datos = new AccesoBD();

                try
                {
                    datos.setearQuery("SELECT IDUsuario, Email, Contraseña FROM Usuarios");
                    datos.ejecutarLectura();
                    while (datos.Lector.Read())
                    {
                    Usuarios aux = new Usuarios();

                        aux.IdUsuario = (int)datos.Lector["IDUsuario"];
                        aux.Email = (string)datos.Lector["Email"];
                        aux.Contraseña = (string)datos.Lector["Contraseña"];


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

