using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    datos.setearQuery("SELECT IDUsuario,Rol, Email, Contraseña FROM Usuarios");
                    datos.ejecutarLectura();
                    while (datos.Lector.Read())
                    {
                    Usuarios aux = new Usuarios();

                        aux.IdUsuario = (int)datos.Lector["IDUsuario"];
                        aux.Rol = (string)datos.Lector["Rol"];
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
        public bool Login(Usuarios user)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearQuery("SELECT IDUsuario,Rol, Email, Contraseña FROM Usuarios Where Email = @Email and Contraseña = @Contraseña");
                datos.setearParametro("@Email", user.Email);
                datos.setearParametro("@Contraseña", user.Contraseña);

                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    user.IdUsuario = (int)datos.Lector["IDUsuario"];
                    user.Rol = (string)datos.Lector["Rol"];
                    return true;
                }
                                
                    return false;

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

