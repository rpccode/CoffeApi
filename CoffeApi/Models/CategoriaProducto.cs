using System;
using System.Collections.Generic;

#nullable disable

namespace CoffeApi.Models
{
    public partial class CategoriaProducto
    {
        public CategoriaProducto()
        {
            Productos = new HashSet<Producto>();
        }

        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
