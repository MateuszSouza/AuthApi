using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApi.Response
{
    public class LoginResponse
    {
        public LoginResponse(string token, Usuario usuario)
        {
            Nome = usuario.NomeUsuario;
            Email = usuario.Email;
            Role = usuario.Roles;
            Id = usuario.Id;
            Token = token;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
