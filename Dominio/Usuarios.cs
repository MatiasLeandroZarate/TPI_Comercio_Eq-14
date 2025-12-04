using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuarios
    {
        public int IDUsuario { get; set; }
        public string Rol { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public bool Activo { get; set; }
    }
}
