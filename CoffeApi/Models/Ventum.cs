using System;
using System.Collections.Generic;

#nullable disable

namespace CoffeApi.Models
{
    public partial class Ventum
    {
        public Ventum()
        {
            ProductosEnVenta = new HashSet<ProductosEnVentum>();
        }

        public string Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string IdCliente { get; set; }
        public string IdVendedor { get; set; }
        public bool EsVentaMovil { get; set; }
        public decimal Monto { get; set; }

        public virtual Usuario IdClienteNavigation { get; set; }
        public virtual Usuario IdVendedorNavigation { get; set; }
        public virtual ICollection<ProductosEnVentum> ProductosEnVenta { get; set; }
    }
}
