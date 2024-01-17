using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace AuthApi.Repositorios
{
    class BaseRepository
    {
        private readonly IConfiguration _configuration;
        protected SqlConnection connection;
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = new SqlConnection(_configuration.GetSection("connection").Value);
        }
    }
}
