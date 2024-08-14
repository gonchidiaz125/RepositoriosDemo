namespace RepositoriosDemo.Entidades
{
    public class Servicio : EntidadBase
    {
        // Propiedades adicionales específicas de Servicio
        public string? Email { get; set; }
        public string? Observaciones { get; set; }

        public override void MostrarDetalles()
        {
            base.MostrarDetalles();
            Console.WriteLine($"Email: {Email}, Observaciones: {Observaciones}");
            Console.WriteLine("");
        }
    }
}
