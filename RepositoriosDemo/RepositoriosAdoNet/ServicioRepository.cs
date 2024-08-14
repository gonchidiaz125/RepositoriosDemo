using RepositoriosDemo.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriosDemo.RepositoriosAdoNet
{    
    public class ServicioRepository : RepositorioBase
    {
        public ServicioRepository() : base("Servicio")
        {
        }

        public void Create(Servicio servicio)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    @"INSERT INTO Servicio (Id, Nombre, Activo, FechaAlta, UsuarioAlta, FechaModificacion, UsuarioModificacion, FechaBaja, UsuarioBaja, Email, Observaciones)
              VALUES (@Id, @Nombre, @Activo, @FechaAlta, @UsuarioAlta, @FechaModificacion, @UsuarioModificacion, @FechaBaja, @UsuarioBaja, @Email, @Observaciones)",
                    connection);

                command.Parameters.AddWithValue("@Id", servicio.Id);
                command.Parameters.AddWithValue("@Nombre", servicio.Nombre);
                command.Parameters.AddWithValue("@Activo", servicio.Activo);
                command.Parameters.AddWithValue("@FechaAlta", servicio.FechaAlta);
                command.Parameters.AddWithValue("@UsuarioAlta", servicio.UsuarioAlta);
                command.Parameters.AddWithValue("@FechaModificacion", (object)servicio.FechaModificacion ?? DBNull.Value);
                command.Parameters.AddWithValue("@UsuarioModificacion", (object)servicio.UsuarioModificacion ?? DBNull.Value);
                command.Parameters.AddWithValue("@FechaBaja", (object)servicio.FechaBaja ?? DBNull.Value);
                command.Parameters.AddWithValue("@UsuarioBaja", (object)servicio.UsuarioBaja ?? DBNull.Value);
                command.Parameters.AddWithValue("@Email", servicio.Email ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Observaciones", servicio.Observaciones ?? (object)DBNull.Value);

                command.ExecuteNonQuery();
            }
        }


        public Servicio GetById(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Servicios WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Servicio
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
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            Observaciones = reader.IsDBNull(reader.GetOrdinal("Observaciones")) ? null : reader.GetString(reader.GetOrdinal("Observaciones"))
                        };
                    }

                    return null;
                }
            }
        }

        public IEnumerable<Servicio> GetAll()
        {
            var servicios = new List<Servicio>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Servicio", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var servicio = new Servicio
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
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            Observaciones = reader.IsDBNull(reader.GetOrdinal("Observaciones")) ? null : reader.GetString(reader.GetOrdinal("Observaciones"))
                        };

                        servicios.Add(servicio);
                    }
                }
            }

            return servicios;
        }

        public void Update(Servicio servicio)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    @"UPDATE Servicio 
              SET Nombre = @Nombre, Activo = @Activo, FechaAlta = @FechaAlta, UsuarioAlta = @UsuarioAlta, 
                  FechaModificacion = @FechaModificacion, UsuarioModificacion = @UsuarioModificacion, 
                  FechaBaja = @FechaBaja, UsuarioBaja = @UsuarioBaja, Email = @Email, Observaciones = @Observaciones
              WHERE Id = @Id",
                    connection);

                command.Parameters.AddWithValue("@Id", servicio.Id);
                command.Parameters.AddWithValue("@Nombre", servicio.Nombre);
                command.Parameters.AddWithValue("@Activo", servicio.Activo);
                command.Parameters.AddWithValue("@FechaAlta", servicio.FechaAlta);
                command.Parameters.AddWithValue("@UsuarioAlta", servicio.UsuarioAlta);
                command.Parameters.AddWithValue("@FechaModificacion", (object)servicio.FechaModificacion ?? DBNull.Value);
                command.Parameters.AddWithValue("@UsuarioModificacion", (object)servicio.UsuarioModificacion ?? DBNull.Value);
                command.Parameters.AddWithValue("@FechaBaja", (object)servicio.FechaBaja ?? DBNull.Value);
                command.Parameters.AddWithValue("@UsuarioBaja", (object)servicio.UsuarioBaja ?? DBNull.Value);
                command.Parameters.AddWithValue("@Email", servicio.Email ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Observaciones", servicio.Observaciones ?? (object)DBNull.Value);

                command.ExecuteNonQuery();
            }
        }

    }


}
