using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApi.Repositorios
{
    public interface IUsuarioRepositorio
    {
        public Usuario GetUsuarioPorEmailESenha(string email, string senha);
        void IsereUsuario(Usuario usuario);
        Usuario GetUsuarioPorEmail(string email);
    }
}
