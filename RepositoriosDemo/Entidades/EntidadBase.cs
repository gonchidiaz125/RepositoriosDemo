namespace RepositoriosDemo.Entidades
{
    /// <summary>
    ///  Es una clase abstracta que contiene las propiedades comunes a todas las entidades. Todas las entidades que heredan de esta clase tendrán estas propiedades.
    ///  Una clase abstracta en C# es como un plano o plantilla para otras clases. No se puede crear una instancia directamente de una clase abstracta; en cambio, se utiliza como base para que otras clases la hereden y utilicen o personalicen sus funcionalidades.
    /// </summary>
    public abstract class EntidadBase
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; } = string.Empty;
        public DateTime? FechaModificacion { get; set; }
        public string? UsuarioModificacion { get; set; }
        public DateTime? FechaBaja { get; set; }
        public string? UsuarioBaja { get; set; }

        public virtual void MostrarDetalles()
        {
            Console.WriteLine($"ID: {Id}, Nombre: {Nombre}, Activo: {Activo}");
        }
    }

}
