using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CompraDetalle
    {
        public int IDDetalleCompra { get; set; }
        public int IDCompra { get; set; }
        public int IDArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public DateTime Fecha { get; set; }
    }

}
