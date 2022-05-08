using System;
using System.Collections.Generic;

#nullable disable

namespace CoffeApi.Models
{
    public partial class Paquete
    {
        public Paquete()
        {
            ElementoEnPaquetes = new HashSet<ElementoEnPaquete>();
        }

        public string Id { get; set; }
        public string Nombre { get; set; }
        public decimal Costo { get; set; }
        public bool EstaEnVenta { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<ElementoEnPaquete> ElementoEnPaquetes { get; set; }
    }
}
