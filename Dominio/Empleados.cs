using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Empleados
    { public int IdEmpleado { get; set; }
        public string DNI { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public int IDCargo { get; set; }
        public Cargos Cargo { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaDesvinculacion { get; set; }
        public decimal Sueldo { get; set; }
        public Empleados()
        {
            Cargo = new Cargos();
        }
    }
}
