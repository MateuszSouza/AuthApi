using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApi.Request
{
    public class CadastrarUsuarioRequest
    {
        public string NomeDeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }

    }
}
