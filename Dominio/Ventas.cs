using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Ventas
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public Clientes Cliente { get; set; }
        public int NroComprobante { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Descuentos { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public Ventas()
        {
            Cliente = new Clientes();
        }
    }
}
