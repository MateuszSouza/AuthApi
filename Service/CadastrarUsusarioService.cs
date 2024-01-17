using AuthApi.Mappers;
using AuthApi.Repositorios;
using AuthApi.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApi.Service
{
    public class CadastrarUsusarioService
    {
        readonly IUsuarioRepositorio _usuarioRepositorio;

        public CadastrarUsusarioService(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public void Cadastrar(CadastrarUsuarioRequest cadastrarUsuarioRequest)
        {
            Usuario usuario = _usuarioRepositorio.GetUsuarioPorEmail(cadastrarUsuarioRequest.Email);
            if(usuario == null)
            {
                throw new Exception("Usuario já Cadastrado");
            }
            usuario = cadastrarUsuarioRequest.Map();
            _usuarioRepositorio.IsereUsuario(usuario);
        }
    }
}
