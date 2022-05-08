using System;
using System.Collections.Generic;

#nullable disable

namespace CoffeApi.Models
{
    public partial class ElementoEnPaquete
    {
        public string Id { get; set; }
        public string IdPaquete { get; set; }
        public string Foto { get; set; }
        public byte Cantidad { get; set; }
        public string IdProducto { get; set; }
        public string IdMenuComidaCorrida { get; set; }
        public string Descripcion { get; set; }

        public virtual MenuComidaCorridum IdMenuComidaCorridaNavigation { get; set; }
        public virtual Paquete IdPaqueteNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
