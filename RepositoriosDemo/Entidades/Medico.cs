using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriosDemo.Entidades
{
    [Table("Medico")]
    public class Medico : EntidadBase
    {
        // Propiedades adicionales específicas de Medico
        [MaxLength(50)]
        public string? Matricula { get; set; }

        [MaxLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [MaxLength(20)]
        public string? Telefono { get; set; }

        public bool TieneLinked { get; set; }

        [MaxLength(200)]
        [Url]
        public string? LinkedInURL { get; set; }

        public override void MostrarDetalles()
        {
            base.MostrarDetalles();
            Console.WriteLine($"Matrícula: {Matricula}, Email: {Email}, Teléfono: {Telefono}, LinkedIn: {(TieneLinked ? LinkedInURL : "No tiene")}");
            Console.WriteLine("");
        }
    }
}
