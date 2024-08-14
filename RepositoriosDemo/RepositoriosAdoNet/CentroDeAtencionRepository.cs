using RepositoriosDemo.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriosDemo.RepositoriosAdoNet
{
    public class CentroDeAtencionRepository
    {
        private readonly string _connectionString;

        public CentroDeAtencionRepository()
        {
            var config = new ConfiguracionBD();
            _connectionString = config.ObtenerStringConexion();
        }

        public void Create(CentroDeAtencion entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO CentroDeAtencion (Id, Nombre, Activo, FechaAlta, UsuarioAlta, FechaModificacion, UsuarioModificacion, FechaBaja, UsuarioBaja, Direccion, Telefono, Email) " +
                                             "VALUES (@Id, @Nombre, @Activo, @FechaAlta, @UsuarioAlta, @FechaModificacion, @UsuarioModificacion, @FechaBaja, @UsuarioBaja, @Direccion, @Telefono, @Email)", connection);

                command.Parameters.AddWithValue("@Id", entity.Id);
                command.Parameters.AddWithValue("@Nombre", entity.Nombre);
                command.Parameters.AddWithValue("@Activo", entity.Activo);
                command.Parameters.AddWithValue("@FechaAlta", entity.FechaAlta);
                command.Parameters.AddWithValue("@UsuarioAlta", entity.UsuarioAlta);
                command.Parameters.AddWithValue("@FechaModificacion", (object)entity.FechaModificacion ?? DBNull.Value);
                command.Parameters.AddWithValue("@UsuarioModificacion", (object)entity.UsuarioModificacion ?? DBNull.Value);
                command.Parameters.AddWithValue("@FechaBaja", (object)entity.FechaBaja ?? DBNull.Value);
                command.Parameters.AddWithValue("@UsuarioBaja", (object)entity.UsuarioBaja ?? DBNull.Value);
                command.Parameters.AddWithValue("@Direccion", entity.Direccion ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Telefono", entity.Telefono ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Email", entity.Email ?? (object)DBNull.Value);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public CentroDeAtencion GetById(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM CentroDeAtencion WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new CentroDeAtencion
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
                            Direccion = reader.IsDBNull(reader.GetOrdinal("Direccion")) ? null : reader.GetString(reader.GetOrdinal("Direccion")),
                            Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? null : reader.GetString(reader.GetOrdinal("Telefono")),
                            Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email"))
                        };
                    }

                    return null;
                }
            }
        }

        public IEnumerable<CentroDeAtencion> GetAll()
        {
            var centros = new List<CentroDeAtencion>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM CentroDeAtencion", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var centro = new CentroDeAtencion
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
                            Direccion = reader.GetString(reader.GetOrdinal("Direccion")),
                            Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                            Email = reader.GetString(reader.GetOrdinal("Email"))
                        };

                        centros.Add(centro);
                    }
                }
            }

            return centros;
        }


        public void Update(CentroDeAtencion entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("UPDATE CentroDeAtencion SET Nombre = @Nombre, Activo = @Activo, FechaModificacion = @FechaModificacion, UsuarioModificacion = @UsuarioModificacion, " +
                                             "FechaBaja = @FechaBaja, UsuarioBaja = @UsuarioBaja, Direccion = @Direccion, Telefono = @Telefono, Email = @Email WHERE Id = @Id", connection);

                command.Parameters.AddWithValue("@Id", entity.Id);
                command.Parameters.AddWithValue("@Nombre", entity.Nombre);
                command.Parameters.AddWithValue("@Activo", entity.Activo);
                command.Parameters.AddWithValue("@FechaModificacion", entity.FechaModificacion ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@UsuarioModificacion", entity.UsuarioModificacion ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@FechaBaja", entity.FechaBaja ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@UsuarioBaja", entity.UsuarioBaja ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Direccion", entity.Direccion ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Telefono", entity.Telefono ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Email", entity.Email ?? (object)DBNull.Value);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("DELETE FROM CentroDeAtencion WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
