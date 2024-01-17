using AuthApi;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace AuthApi.Repositorios
{
    class UsuarioRepositorioDapper : BaseRepository, IUsuarioRepositorio
    {
        public UsuarioRepositorioDapper(IConfiguration configuration) : base(configuration)
        {
        }

        public Usuario GetUsuarioPorEmail(string email)
        {
            var comand = @"SELECT * FROM usuario WHERE Email = @email";
            //connection.Open();
            return (Usuario) connection.Query<Usuario>(comand,new { email});
        }

        public Usuario GetUsuarioPorEmailESenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public void IsereUsuario(Usuario usuario)
        {
            string command = @"INSERT INTO Usuario 
                        (
                           id,NomeUsuario,Email,Senha,Role
                        )
                           values
                        (
                          @NomeUsuario,@Email,@Senha,@role";

            connection.Execute(command, usuario);

        }
    }
}
