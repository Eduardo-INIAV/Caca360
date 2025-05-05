using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caca360.Services
{
    public class AuthService
    {
        public string Token { get; private set; } = string.Empty;
        public void SetToken(string token) => Token = token;
    }
}
