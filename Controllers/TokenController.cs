using AuthApi.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApi.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class TokenControler : ControllerBase
    {
        private readonly TokenService _tokenService;

        public TokenControler(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet]
        public string GetToken()
        {
            var usuario = new Usuario();
            usuario.NomeUsuario = "batima";
            usuario.Email = "Batima@email";
            usuario.Roles = "fodao";
            string retorno = _tokenService.GeradorDeToken(usuario);
            return retorno;
        }    
    }

}

