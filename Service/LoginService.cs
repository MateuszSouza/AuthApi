using AuthApi.Repositorios;
using AuthApi.Request;
using AuthApi.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApi.Service
{
    public class LoginService
    {
        readonly IUsuarioRepositorio _usuarioRepositorio;
        readonly TokenService _tokenService;

        public LoginService(IUsuarioRepositorio usuarioRepositorio, TokenService tokenService)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _tokenService = tokenService;
        }

        public Task<LoginResponse> login(LoginRequest loginRequest)
        {
            Usuario usuarioFromRepository = 
                _usuarioRepositorio.GetUsuarioPorEmailESenha(loginRequest.Email ,loginRequest.Password);

            if (usuarioFromRepository == null)
            {
                throw new Exception("Usuario não cadastrado");
            }
            return Task.FromResult( 
                new LoginResponse(_tokenService.GeradorDeToken(usuarioFromRepository), usuarioFromRepository));
        }
    }
}
