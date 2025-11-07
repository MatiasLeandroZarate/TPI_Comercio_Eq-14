using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compras
    {
        public int IdCompra { get; set; }
        public int IdProveedor { get; set; }
        public Proveedores Proveedor { get; set; }
        public int NroComprobante { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Descuentos { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }

         public Compras()
        {
            Proveedor = new Proveedores();
        }
    }
}
