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
                    datos.setearQuery("SELECT IDUsuario, Rol, Email, Contraseña, Activo FROM Usuarios");
                    datos.ejecutarLectura();
                    while (datos.Lector.Read())
                    {
                        Usuarios aux = new Usuarios();

                        aux.IDUsuario = (int)datos.Lector["IDUsuario"];
                        aux.Rol = (string)datos.Lector["Rol"];
                        aux.Email = (string)datos.Lector["Email"];
                        aux.Contraseña = (string)datos.Lector["Contraseña"];
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

        public bool Login(Usuarios user)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearQuery("SELECT IDUsuario,Rol, Email, Contraseña FROM Usuarios Where Email = @Email and Contraseña = @Contraseña and Activo = 1");
                datos.setearParametro("@Email", user.Email);
                datos.setearParametro("@Contraseña", user.Contraseña);

                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    user.IDUsuario = (int)datos.Lector["IDUsuario"];
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

        public List<Usuarios> Filtrar(string filtro)
        {
            List<Usuarios> lista = new List<Usuarios>();
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("SELECT IDUsuario, Rol, Email, Contraseña, Activo FROM Usuarios WHERE Rol LIKE @filtro OR Email LIKE @filtro");
                datos.setearParametro("@filtro", "%" + filtro + "%");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuarios usu = new Usuarios();

                    usu.IDUsuario = (int)datos.Lector["IDUsuario"];
                    usu.Rol = (string)datos.Lector["Rol"];
                    usu.Email = (string)datos.Lector["Email"];
                    usu.Activo = bool.Parse(datos.Lector["Activo"].ToString());

                    lista.Add(usu);
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

        public void Eliminar(int Id, bool Estado)
        {
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("UPDATE Usuarios SET Activo = @Activo WHERE IDUsuario = @IDUsuario");
                datos.setearParametro("@Activo", Estado);
                datos.setearParametro("@IDUsuario", Id);
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

        public void Agregar(Usuarios nuevo)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearQuery("INSERT INTO Usuarios (Rol, Email, Contraseña, Activo) VALUES (@Rol, @Email, @Contraseña, @Activo)");
                datos.setearParametro("@Rol", nuevo.Rol);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Contraseña", nuevo.Contraseña);
                datos.setearParametro("@Activo", nuevo.Activo);
                datos.setearParametro("@IDUsuario", nuevo.IDUsuario);
                datos.ejecutarLectura();

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Modificar(Usuarios modificado)
        {
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("UPDATE Clientes SET Rol = @Rol , Email = @Email , Contraseña = @Contraseña, Activo = @Activo WHERE IDUsuario = @IDUsuario");

                datos.setearParametro("@Rol", modificado.Rol);
                datos.setearParametro("@Email", modificado.Email);
                datos.setearParametro("@Contraseña", modificado.Contraseña);
                datos.setearParametro("@Activo", modificado.Activo);
                datos.setearParametro("@IDUsuario", modificado.IDUsuario);

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

        public Usuarios ObtenerPorId(int id)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearQuery("SELECT * FROM Usuarios WHERE IDUsuario = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Usuarios usu = new Usuarios();
                    usu.IDUsuario = (int)datos.Lector["IDUsuario"];
                    usu.Rol = (string)datos.Lector["Rol"];
                    usu.Email = (string)datos.Lector["Email"];
                    usu.Contraseña= (string)datos.Lector["Contraseña"];
                    usu.Activo = (bool)datos.Lector["Activo"];

                    return usu;
                }

                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}

