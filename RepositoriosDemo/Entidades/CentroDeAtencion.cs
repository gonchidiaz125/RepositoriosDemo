using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriosDemo.Entidades
{
    public class CentroDeAtencion : EntidadBase
    {
        // Propiedades adicionales específicas de CentroDeAtencion
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }

        public string? Email { get; set; }

        public override void MostrarDetalles()
        {
            base.MostrarDetalles();
            Console.WriteLine($"Dirección: {Direccion}, Teléfono: {Telefono}, Email: {Email}");
            Console.WriteLine("");
        }

    }
}
