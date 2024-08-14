using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriosDemo.Entidades
{
    public class Medico : EntidadBase
    {
        // Propiedades adicionales específicas de Medico
        public string? Matricula { get; set; }
        public string? Email { get; set; }

        public string? Telefono { get; set; }

        public bool TieneLinked { get; set; }
        public string? LinkedInURL { get; set; }

        public override void MostrarDetalles()
        {
            base.MostrarDetalles();
            Console.WriteLine($"Matrícula: {Matricula}, Email: {Email}, Teléfono: {Telefono}, LinkedIn: {(TieneLinked ? LinkedInURL : "No tiene")}");
            Console.WriteLine("");
        }
    }
}
