using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

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

                    aux.IdProveedor= (int)datos.Lector["IDProveedor"];
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
    }
}
