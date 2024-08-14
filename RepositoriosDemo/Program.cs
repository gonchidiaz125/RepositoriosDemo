// See https://aka.ms/new-console-template for more information
using RepositoriosDemo.Entidades;
using RepositoriosDemo.RepositoriosAdoNet;

Console.WriteLine("Hello, World!");


// Crear instancias de las entidades
var centroDeAtencion = new CentroDeAtencion
{
    Id = Guid.NewGuid(),
    Nombre = "Centro Médico ABC",
    Activo = true,
    FechaAlta = DateTime.Now,
    UsuarioAlta = "admin",
    Direccion = "Calle 123",
    Telefono = "555-1234",
    Email = "centroabc@example.com"
};

var medico = new Medico
{
    Id = Guid.NewGuid(),
    Nombre = "Dr. Juan Pérez",
    Activo = true,
    FechaAlta = DateTime.Now,
    UsuarioAlta = "admin",
    Matricula = "123456",
    Telefono = "555-5678",
    Email = "jperez@example.com",
    TieneLinked = true,
    LinkedInURL = "https://linkedin.com/in/juanperez"
};

var servicio = new Servicio
{
    Id = Guid.NewGuid(),
    Nombre = "Consulta General",
    Activo = true,
    FechaAlta = DateTime.Now,
    UsuarioAlta = "admin",
    Email = "consultageneral@example.com",
    Observaciones = "Este servicio incluye consultas generales con médicos clínicos."
};

// Crear instancias de los repositorios
var centroDeAtencionRepository = new CentroDeAtencionRepository();
var medicoRepository = new MedicoRepository();
var servicioRepository = new ServicioRepository();

// Insertar las entidades en la base de datos
centroDeAtencionRepository.Create(centroDeAtencion);
medicoRepository.Create(medico);
servicioRepository.Create(servicio);

var todosLosCentros = centroDeAtencionRepository.GetAll();
var todosLosServicios = servicioRepository.GetAll();
var todosLosMedicos = medicoRepository.GetAll();

Console.WriteLine("Centros de Atencion");
foreach (var centro in  todosLosCentros)
{
    Console.WriteLine($"Id:{centro.Id} - {centro.Nombre}");
}
Console.WriteLine("");

Console.WriteLine("Servicios");
foreach (var unServicio in todosLosServicios)
{
    Console.WriteLine($"Id:{unServicio.Id} - {unServicio.Nombre}");
}
Console.WriteLine("");


Console.WriteLine("Medicos");
ImprimirEntidades(todosLosMedicos);
Console.ReadLine();



void ImprimirEntidades<T>(IEnumerable<T> lista) where T : EntidadBase
{
    foreach (var t in lista)
    {
        Console.WriteLine($"Id:{t.Id} - {t.Nombre}");
    }
    Console.WriteLine("");
}

