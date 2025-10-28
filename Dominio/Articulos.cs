using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulos
    {
        public int IdArticulo { get; set; }
        public string CodigoBarra { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta{ get; set; }
        public int Stock { get; set; }
        public int IDMarca { get; set; }
        public Marcas Marca { get; set; }
        public int IDCategoria { get; set; }
        public Categorias Categoria { get; set; }
        public bool Activo { get; set; }
        public Articulos()
        {
            Marca = new Marcas();
            Categoria = new Categorias();
        }
    }
}
