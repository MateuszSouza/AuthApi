using AuthApi.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApi.Mappers
{
    public static class UsuarioMapper
    {
        public static Usuario Map(this CadastrarUsuarioRequest cadastrarUsuarioRequest)
        {
            return new Usuario()
            {
                Email = cadastrarUsuarioRequest.Email,
                NomeUsuario = cadastrarUsuarioRequest.NomeDeUsuario,
                Senha = BCrypt.Net.BCrypt.HashPassword(cadastrarUsuarioRequest.Senha),
                Id = Guid.NewGuid()
            };
        }
    }
}
