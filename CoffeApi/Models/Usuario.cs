using System;
using System.Collections.Generic;

#nullable disable

namespace CoffeApi.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            VentumIdClienteNavigations = new HashSet<Ventum>();
            VentumIdVendedorNavigations = new HashSet<Ventum>();
        }

        public string Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Foto { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string IdTipoUsuario { get; set; }
        public decimal Credito { get; set; }
        public string Nota { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Ventum> VentumIdClienteNavigations { get; set; }
        public virtual ICollection<Ventum> VentumIdVendedorNavigations { get; set; }
    }
}
