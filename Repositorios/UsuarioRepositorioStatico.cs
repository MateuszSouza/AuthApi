using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApi.Repositorios
{
    public class UsuarioRepositorioStatico : IUsuarioRepositorio
    {
        List<Usuario> usuarios = new List<Usuario>();

        public UsuarioRepositorioStatico()
        {
            var usuario1 = new Usuario();
            usuario1.Senha = BCrypt.Net.BCrypt.HashPassword("senha");
            usuario1.NomeUsuario = "batima";
            usuario1.Email = "batimaMail@maill";
            usuario1.Roles = "gerente";
            var usuario2 = new Usuario();
            usuario2.Senha = "senhaRobin";
            usuario2.NomeUsuario = "robin";
            usuarios.Add(usuario1);
            usuarios.Add(usuario2);
        }

        public Usuario GetUsuarioPorEmailESenha(string email, string senha)
        {
            

            foreach (Usuario usuario in usuarios ){
                if (usuario.Email.Equals(email) && BCrypt.Net.BCrypt.Verify(senha, usuario.Senha))
                {
                    return usuario;
                }
            }
            //var resposta = usuarios.Where(u => u.NomeUsuario.Equals(nome) && u.Senha.Equals(senha));
            //return (Usuario)resposta;
            return null;

        }

        public void IsereUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public Usuario GetUsuarioPorEmail(string email)
        {
            return (Usuario) usuarios.Where(u => u.Email.Equals(email) == true );
        }

    }
}
