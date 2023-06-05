using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo10_APIToken.Modelo
{
    public class AuthResponse
    {
        public string AppId { get; set; }
        public double Expiration { get; set; }
        public string Token { get; set; }
        public DateTime Expirationate { get; set; }
    }

    public class AuthRequest
    {
        public Guid App { get; set; }
        public string Token { get; set; }
    }
}
