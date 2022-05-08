using System;
using System.Collections.Generic;

#nullable disable

namespace CoffeApi.Models
{
    public partial class ElementoEnMenu
    {
        public string Id { get; set; }
        public string IdMenuComidaCorrida { get; set; }
        public string IdProducto { get; set; }

        public virtual MenuComidaCorridum IdMenuComidaCorridaNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
