using System.Data.SqlClient;

namespace RepositoriosDemo.RepositoriosAdoNet
{
    public abstract class RepositorioBase
    {
        protected readonly string _connectionString;
        protected string _nombreDeTabla;

        public RepositorioBase(string nombreDeTabla)
        {
            var config = new ConfiguracionBD();
            _connectionString = config.ObtenerStringConexion();
            _nombreDeTabla = nombreDeTabla;
        }

        public void Delete(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand($"DELETE FROM {_nombreDeTabla} WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
