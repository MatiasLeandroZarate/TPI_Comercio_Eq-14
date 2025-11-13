using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class Seguridad
    {
        public static bool sesionActiva(object user)
        {
            Usuarios usuarios = user != null ? (Usuarios)user : null;
            if (usuarios != null && usuarios.IdUsuario != 0)
                return true;
            else
                return false;
        }
        public static bool esAdmin(object user)
        {
            Usuarios usuarios = user != null ? (Usuarios)user : null;
            if (usuarios != null && usuarios.Rol == "Admin")
                return true;
            else
                return false;
        }
    }
}
