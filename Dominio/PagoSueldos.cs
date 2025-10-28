using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PagoSueldos
    {
        public int IdPagoSueldo { get; set; }
        public Empleados Empleado { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime FechaPago { get; set; }
        public DateTime Periodo { get; set; }
        public decimal MontoPagado { get; set; }
        public FormasdePago FormaPago { get; set; }
        public int IdFormaPago { get; set; }
        public PagoSueldos()
        {
            Empleado = new Empleados();
            FormaPago = new FormasdePago();
        }
    }
}
