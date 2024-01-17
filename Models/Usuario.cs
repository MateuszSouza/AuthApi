using System;


namespace AuthApi
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Roles { get; set; }
    }
}
