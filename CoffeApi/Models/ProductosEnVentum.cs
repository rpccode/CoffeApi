using System;
using System.Collections.Generic;

#nullable disable

namespace CoffeApi.Models
{
    public partial class ProductosEnVentum
    {
        public string Id { get; set; }
        public string IdVenta { get; set; }
        public string IdProducto { get; set; }
        public string IdMenu { get; set; }
        public string IdPaquete { get; set; }
        public byte Cantidad { get; set; }
        public decimal Costo { get; set; }
        public bool Preparando { get; set; }
        public bool Preparado { get; set; }
        public bool Entregado { get; set; }

        public virtual MenuComidaCorridum IdMenuNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Ventum IdVentaNavigation { get; set; }
    }
}
