using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProveedoresNegocio
    {
        public List<Proveedores> ListarPRO()
        {

            List<Proveedores> lista = new List<Proveedores>();
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("SELECT IDProveedor, RazonSocial, CUIT, Telefono, Email, Direccion,Activo  FROM Proveedores");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Proveedores aux = new Proveedores();

                    aux.IdProveedor = (int)datos.Lector["IDProveedor"];
                    aux.RazonSocial = (string)datos.Lector["RazonSocial"];
                    aux.CUIT = (string)datos.Lector["CUIT"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Direccion = (string)datos.Lector["Direccion"];
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

        public Proveedores ObtenerPorId(int id)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearQuery("SELECT * FROM Proveedores WHERE IdProveedor = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Proveedores pro = new Proveedores();
                    pro.IdProveedor = (int)datos.Lector["IdProveedor"];
                    pro.RazonSocial = (string)datos.Lector["RazonSocial"];
                    pro.CUIT = (string)datos.Lector["CUIT"];
                    pro.Telefono = (string)datos.Lector["Telefono"];
                    pro.Email = (string)datos.Lector["Email"];
                    pro.Direccion = (string)datos.Lector["Direccion"];
                    pro.Activo = (bool)datos.Lector["Activo"];

                    return pro;
                }

                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Agregar(Proveedores nuevo)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearQuery("INSERT INTO Proveedores (RazonSocial, CUIT, Telefono, Email, Direccion,Activo) VALUES (@RazonSocial, @CUIT, @Telefono, @Email, @Direccion, @Activo)");
                datos.setearParametro("@RazonSocial", nuevo.RazonSocial);
                datos.setearParametro("@CUIT", nuevo.CUIT);
                datos.setearParametro("@Telefono", nuevo.Telefono);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Direccion", nuevo.Direccion);
                datos.setearParametro("@Activo", nuevo.Activo);
                datos.ejecutarLectura();

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Modificar(Proveedores modificado)
        {
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("UPDATE Proveedores SET RazonSocial = @RazonSocial , CUIT = @CUIT , Telefono = @Telefono , Email = @Email , Direccion = @Direccion , Activo = @Activo WHERE IDProveedor = @IdProveedor");

                datos.setearParametro("@RazonSocial", modificado.RazonSocial);
                datos.setearParametro("@CUIT", modificado.CUIT);
                datos.setearParametro("@Telefono", modificado.Telefono);
                datos.setearParametro("@Email", modificado.Email);
                datos.setearParametro("@Direccion", modificado.Direccion);
                datos.setearParametro("@Activo", modificado.Activo);
                datos.setearParametro("@IdProveedor", modificado.IdProveedor);

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
                datos.setearQuery("UPDATE Proveedores SET Activo = @Activo WHERE IDProveedor = @IDProveedor");
                datos.setearParametro("@Activo", Estado);
                datos.setearParametro("@IDProveedor", Id);
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
        public List<Proveedores> Filtrar(string filtro)
        {
            List<Proveedores> lista = new List<Proveedores>();
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("SELECT IDProveedor, RazonSocial, CUIT, Telefono, Email,Direccion, Activo FROM Proveedores WHERE RazonSocial LIKE @filtro");
                datos.setearParametro("@filtro", "%" + filtro + "%");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Proveedores pro = new Proveedores();

                    pro.IdProveedor = (int)datos.Lector["IdProveedor"];
                    pro.RazonSocial = (string)datos.Lector["RazonSocial"];
                    pro.CUIT = (string)datos.Lector["CUIT"];
                    pro.Telefono = (string)datos.Lector["Telefono"];
                    pro.Email = (string)datos.Lector["Email"];
                    pro.Direccion = (string)datos.Lector["Direccion"];
                    pro.Activo = bool.Parse(datos.Lector["Activo"].ToString());

                    lista.Add(pro);
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