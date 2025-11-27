using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ClientesNegocio
    {
        public List<Clientes> ListarCLI()
        {

            List<Clientes> lista = new List<Clientes>();
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("SELECT IDCliente, DNI, CUIT, Apellido, Nombre, Telefono, Email, Direccion,Activo  FROM Clientes");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Clientes aux = new Clientes();

                    aux.IdCliente = (int)datos.Lector["IdCliente"];
                    aux.DNI = (string)datos.Lector["DNI"];
                    aux.CUIT = datos.Lector["CUIT"] == DBNull.Value ? null : (string)datos.Lector["CUIT"];
                    aux.Apellido = datos.Lector["Apellido"] == DBNull.Value ? null : (string)datos.Lector["Apellido"];
                    aux.Nombre = datos.Lector["Nombre"] == DBNull.Value ? null : (string)datos.Lector["Nombre"];
                    aux.Telefono = datos.Lector["Telefono"] == DBNull.Value ? null : (string)datos.Lector["Telefono"];
                    aux.Email = datos.Lector["Email"] == DBNull.Value ? null : (string)datos.Lector["Email"];
                    aux.Direccion = datos.Lector["Direccion"] == DBNull.Value ? null : (string)datos.Lector["Direccion"];
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
        public Clientes ObtenerPorId(int id)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearQuery("SELECT * FROM Clientes WHERE IdCliente = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Clientes cli = new Clientes();
                    cli.IdCliente = (int)datos.Lector["IdCliente"];
                    cli.DNI = (string)datos.Lector["DNI"];
                    cli.CUIT = datos.Lector.IsDBNull(datos.Lector.GetOrdinal("CUIT")) ? null : (string)datos.Lector["CUIT"];
                    cli.Apellido = (string)datos.Lector["Apellido"];
                    cli.Nombre = (string)datos.Lector["Nombre"];
                    cli.Telefono = (string)datos.Lector["Telefono"];
                    cli.Email = (string)datos.Lector["Email"];
                    cli.Direccion = (string)datos.Lector["Direccion"];
                    cli.Activo = (bool)datos.Lector["Activo"];

                    return cli;
                }

                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Agregar(Clientes nuevo)
        {
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("INSERT INTO Clientes (DNI, CUIT, Apellido, Nombre, Telefono, Email, Direccion, Activo) VALUES (@DNI, @CUIT, @Apellido, @Nombre, @Telefono, @Email, @Direccion, @Activo)");
                datos.setearParametro("@DNI", nuevo.DNI);
                datos.setearParametro("@CUIT", nuevo.CUIT);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Telefono", nuevo.Telefono);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Direccion", nuevo.Direccion);
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

        public void Modificar(Clientes modificado)
        {
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("UPDATE Clientes SET DNI = @DNI, CUIT = @CUIT, Apellido = @Apellido, Nombre = @Nombre, Telefono = @Telefono, Email = @Email, Direccion = @Direccion, Activo = @Activo WHERE DNI = @DNI");
                datos.setearParametro("@DNI", modificado.DNI);
                datos.setearParametro("@CUIT", modificado.CUIT);
                datos.setearParametro("@Apellido", modificado.Apellido);
                datos.setearParametro("@Nombre", modificado.Nombre);
                datos.setearParametro("@Telefono", modificado.Telefono);
                datos.setearParametro("@Email", modificado.Email);
                datos.setearParametro("@Direccion", modificado.Direccion);
                datos.setearParametro("@Activo", 1);
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

        public void Eliminar(int IdCliente, bool Estado)
        {
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("UPDATE Clientes SET Activo = @Activo WHERE IdCliente = @IdCliente");
                datos.setearParametro("@Activo", Estado);
                datos.setearParametro("IdCLiente",IdCliente);
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

        public List<Clientes> Filtrar(string filtro)
        {
            List<Clientes> lista = new List<Clientes>();
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("SELECT IDCliente, DNI, CUIT, Apellido, Nombre, Telefono, Email,Direccion, Activo FROM Clientes WHERE Apellido LIKE @filtro OR Nombre LIKE @filtro");
                datos.setearParametro("@filtro", "%" + filtro + "%");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Clientes cli = new Clientes();

                    cli.IdCliente = (int)datos.Lector["IdCliente"];
                    cli.DNI = (string)datos.Lector["DNI"];
                    cli.CUIT = datos.Lector["CUIT"] == DBNull.Value ? null : (string)datos.Lector["CUIT"];
                    cli.Apellido = datos.Lector["Apellido"] == DBNull.Value ? null : (string)datos.Lector["Apellido"];
                    cli.Nombre = datos.Lector["Nombre"] == DBNull.Value ? null : (string)datos.Lector["Nombre"];
                    cli.Telefono = datos.Lector["Telefono"] == DBNull.Value ? null : (string)datos.Lector["Telefono"];
                    cli.Email = datos.Lector["Email"] == DBNull.Value ? null : (string)datos.Lector["Email"];
                    cli.Direccion = datos.Lector["Direccion"] == DBNull.Value ? null : (string)datos.Lector["Direccion"];
                    cli.Activo = bool.Parse(datos.Lector["Activo"].ToString());

                    lista.Add(cli);
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

        public List<Clientes> ListarConFiltro(string filtro)
        {
            List<Clientes> lista = new List<Clientes>();
            AccesoBD datos = new AccesoBD();

            try
            {
                string query = @"SELECT IDCliente, DNI, CUIT, Apellido, Nombre, Telefono, Email, Direccion, Activo FROM Clientes WHERE Activo = 1";

                if (!string.IsNullOrEmpty(filtro))
                {
                    query += " AND (Apellido LIKE @filtro OR Nombre LIKE @filtro OR DNI LIKE @filtro)";
                }

                datos.setearQuery(query);

                if (!string.IsNullOrEmpty(filtro))
                    datos.setearParametro("@filtro", "%" + filtro + "%");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Clientes cli = new Clientes();

                    cli.IdCliente = (int)datos.Lector["IdCliente"];
                    cli.DNI = (string)datos.Lector["DNI"];
                    cli.CUIT = datos.Lector["CUIT"] == DBNull.Value ? null : (string)datos.Lector["CUIT"];
                    cli.Apellido = datos.Lector["Apellido"] == DBNull.Value ? null : (string)datos.Lector["Apellido"];
                    cli.Nombre = datos.Lector["Nombre"] == DBNull.Value ? null : (string)datos.Lector["Nombre"];
                    cli.Telefono = datos.Lector["Telefono"] == DBNull.Value ? null : (string)datos.Lector["Telefono"];
                    cli.Email = datos.Lector["Email"] == DBNull.Value ? null : (string)datos.Lector["Email"];
                    cli.Direccion = datos.Lector["Direccion"] == DBNull.Value ? null : (string)datos.Lector["Direccion"];
                    cli.Activo = bool.Parse(datos.Lector["Activo"].ToString());

                    lista.Add(cli);
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

