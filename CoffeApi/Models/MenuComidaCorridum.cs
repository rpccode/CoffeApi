using System;
using System.Collections.Generic;

#nullable disable

namespace CoffeApi.Models
{
    public partial class MenuComidaCorridum
    {
        public MenuComidaCorridum()
        {
            ElementoEnMenus = new HashSet<ElementoEnMenu>();
            ElementoEnPaquetes = new HashSet<ElementoEnPaquete>();
            ProductosEnVenta = new HashSet<ProductosEnVentum>();
        }

        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Foto { get; set; }
        public decimal Costo { get; set; }
        public bool EstaEnVenta { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<ElementoEnMenu> ElementoEnMenus { get; set; }
        public virtual ICollection<ElementoEnPaquete> ElementoEnPaquetes { get; set; }
        public virtual ICollection<ProductosEnVentum> ProductosEnVenta { get; set; }
    }
}
