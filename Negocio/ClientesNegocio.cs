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

                    aux.IdCliente = (int)datos.Lector["IDCliente"];
                    aux.DNI = (string)datos.Lector["DNI"];
                    aux.CUIT = (string)datos.Lector["CUIT"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
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
    }
}

