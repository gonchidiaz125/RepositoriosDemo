using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RepositoriosDemo.Entidades
{
    [Table("CentroDeAtencion")]
    public class CentroDeAtencion : EntidadBase
    {
        // Propiedades adicionales específicas de CentroDeAtencion
        [MaxLength(200)]
        public string? Direccion { get; set; }

        [MaxLength(20)]
        public string? Telefono { get; set; }

        [MaxLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        public override void MostrarDetalles()
        {
            base.MostrarDetalles();
            Console.WriteLine($"Dirección: {Direccion}, Teléfono: {Telefono}, Email: {Email}");
            Console.WriteLine("");
        }

    }
}
