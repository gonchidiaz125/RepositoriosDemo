using RepositoriosDemo.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriosDemo.RepositoriosAdoNet
{

    public class MedicoRepository
    {
        private readonly string _connectionString;

        public MedicoRepository()
        {
            var config = new ConfiguracionBD();
            _connectionString = config.ObtenerStringConexion();
        }

        public void Create(Medico entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO Medico (Id, Nombre, Activo, FechaAlta, UsuarioAlta, FechaModificacion, UsuarioModificacion, FechaBaja, UsuarioBaja, Matricula, Email, Telefono, TieneLinked, LinkedInURL) " +
                                             "VALUES (@Id, @Nombre, @Activo, @FechaAlta, @UsuarioAlta, @FechaModificacion, @UsuarioModificacion, @FechaBaja, @UsuarioBaja, @Matricula, @Email, @Telefono, @TieneLinked, @LinkedInURL)", connection);

                command.Parameters.AddWithValue("@Id", entity.Id);
                command.Parameters.AddWithValue("@Nombre", entity.Nombre);
                command.Parameters.AddWithValue("@Activo", entity.Activo);
                command.Parameters.AddWithValue("@FechaAlta", entity.FechaAlta);
                command.Parameters.AddWithValue("@UsuarioAlta", entity.UsuarioAlta);
                command.Parameters.AddWithValue("@FechaModificacion", (object)entity.FechaModificacion ?? DBNull.Value);
                command.Parameters.AddWithValue("@UsuarioModificacion", (object)entity.UsuarioModificacion ?? DBNull.Value);
                command.Parameters.AddWithValue("@FechaBaja", (object)entity.FechaBaja ?? DBNull.Value);
                command.Parameters.AddWithValue("@UsuarioBaja", (object)entity.UsuarioBaja ?? DBNull.Value);
                command.Parameters.AddWithValue("@Matricula", entity.Matricula ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Email", entity.Email ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Telefono", entity.Telefono ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@TieneLinked", entity.TieneLinked);
                command.Parameters.AddWithValue("@LinkedInURL", entity.LinkedInURL ?? (object)DBNull.Value);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Medico GetById(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Medico WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Medico
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            Activo = reader.GetBoolean(reader.GetOrdinal("Activo")),
                            FechaAlta = reader.GetDateTime(reader.GetOrdinal("FechaAlta")),
                            UsuarioAlta = reader.GetString(reader.GetOrdinal("UsuarioAlta")),
                            FechaModificacion = reader.IsDBNull(reader.GetOrdinal("FechaModificacion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaModificacion")),
                            UsuarioModificacion = reader.IsDBNull(reader.GetOrdinal("UsuarioModificacion")) ? null : reader.GetString(reader.GetOrdinal("UsuarioModificacion")),
                            FechaBaja = reader.IsDBNull(reader.GetOrdinal("FechaBaja")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaBaja")),
                            UsuarioBaja = reader.IsDBNull(reader.GetOrdinal("UsuarioBaja")) ? null : reader.GetString(reader.GetOrdinal("UsuarioBaja")),
                            Matricula = reader.IsDBNull(reader.GetOrdinal("Matricula")) ? null : reader.GetString(reader.GetOrdinal("Matricula")),
                            Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                            Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? null : reader.GetString(reader.GetOrdinal("Telefono")),
                            TieneLinked = reader.GetBoolean(reader.GetOrdinal("TieneLinked")),
                            LinkedInURL = reader.IsDBNull(reader.GetOrdinal("LinkedInURL")) ? null : reader.GetString(reader.GetOrdinal("LinkedInURL"))
                        };
                    }

                    return null;
                }
            }
        }

        public IEnumerable<Medico> GetAll()
        {
            var medicos = new List<Medico>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Medico", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var medico = new Medico
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            Activo = reader.GetBoolean(reader.GetOrdinal("Activo")),
                            FechaAlta = reader.GetDateTime(reader.GetOrdinal("FechaAlta")),
                            UsuarioAlta = reader.GetString(reader.GetOrdinal("UsuarioAlta")),
                            FechaModificacion = reader.IsDBNull(reader.GetOrdinal("FechaModificacion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaModificacion")),
                            UsuarioModificacion = reader.IsDBNull(reader.GetOrdinal("UsuarioModificacion")) ? null : reader.GetString(reader.GetOrdinal("UsuarioModificacion")),
                            FechaBaja = reader.IsDBNull(reader.GetOrdinal("FechaBaja")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaBaja")),
                            UsuarioBaja = reader.IsDBNull(reader.GetOrdinal("UsuarioBaja")) ? null : reader.GetString(reader.GetOrdinal("UsuarioBaja")),
                            Matricula = reader.GetString(reader.GetOrdinal("Matricula")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                            TieneLinked = reader.GetBoolean(reader.GetOrdinal("TieneLinked")),
                            LinkedInURL = reader.IsDBNull(reader.GetOrdinal("LinkedInURL")) ? null : reader.GetString(reader.GetOrdinal("LinkedInURL"))
                        };

                        medicos.Add(medico);
                    }
                }
            }

            return medicos;
        }


        public void Update(Medico entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("UPDATE Medico SET Nombre = @Nombre, Activo = @Activo, FechaModificacion = @FechaModificacion, UsuarioModificacion = @UsuarioModificacion, " +
                                             "FechaBaja = @FechaBaja, UsuarioBaja = @UsuarioBaja, Matricula = @Matricula, Email = @Email, Telefono = @Telefono, TieneLinked = @TieneLinked, LinkedInURL = @LinkedInURL WHERE Id = @Id", connection);

                command.Parameters.AddWithValue("@Id", entity.Id);
                command.Parameters.AddWithValue("@Nombre", entity.Nombre);
                command.Parameters.AddWithValue("@Activo", entity.Activo);
                command.Parameters.AddWithValue("@FechaModificacion", entity.FechaModificacion ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@UsuarioModificacion", entity.UsuarioModificacion ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@FechaBaja", entity.FechaBaja ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@UsuarioBaja", entity.UsuarioBaja ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Matricula", entity.Matricula ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Email", entity.Email ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Telefono", entity.Telefono ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@TieneLinked", entity.TieneLinked);
                command.Parameters.AddWithValue("@LinkedInURL", entity.LinkedInURL ?? (object)DBNull.Value);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("DELETE FROM Medico WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

}
