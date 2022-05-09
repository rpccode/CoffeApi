using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeApi.Models
{
    public class TokenModel
    {
        public string Token { get; set; }
        public Usuario Usuario { get; set; }
    }
}
