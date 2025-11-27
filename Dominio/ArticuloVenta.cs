using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ArticuloVenta
    {
        public int IDArticulo { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioVenta { get; set; }
        public int StockActual { get; set; }
        public int StockSolicitado { get; set; }
        public decimal Descuento { get; set; } = 0;
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
    }
}
