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

        public void DarDeBaja(Guid id, string usuarioBaja)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = $"UPDATE {_nombreDeTabla} " +
                               "SET Activo = 0, FechaBaja = @FechaBaja, UsuarioBaja = @UsuarioBaja " +
                               "WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FechaBaja", DateTime.Now);
                    command.Parameters.AddWithValue("@UsuarioBaja", usuarioBaja);
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Reactivar(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = $"UPDATE {_nombreDeTabla} " +
                               "SET Activo = 1, FechaBaja = NULL, UsuarioBaja = NULL " +
                               "WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
