// See https://aka.ms/new-console-template for more information
using RepositoriosDemo.Entidades;
using RepositoriosDemo.RepositoriosAdoNet;
using RepositoriosDemo.RepositoriosEF;
using RepositoriosDemo.Servicios;

Console.WriteLine("Hello, World!");


/*
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
//centroDeAtencionRepository.Create(centroDeAtencion);
//medicoRepository.Create(medico);
//servicioRepository.Create(servicio);

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


Guid guidValue = Guid.Parse("3398403A-B873-45AD-B9C2-EE00D05EF54C");
medicoRepository.Delete(guidValue);


todosLosMedicos = medicoRepository.GetAll();
Console.WriteLine("Medicos");
ImprimirEntidades(todosLosMedicos);


// Dar de baja un Centro
Guid centroId = Guid.Parse("88ACB961-B349-4149-B35D-43967D2647EA");
centroDeAtencionRepository.DarDeBaja(centroId, "Gonchi");

todosLosCentros = centroDeAtencionRepository.GetAll();
Console.WriteLine("Centros luego de DarDeBaja");
ImprimirEntidades(todosLosCentros);

*/

// EjemploConEntityFramework();

EjemploDeInjeccionDeDependencias();

void EjemploDeInjeccionDeDependencias()
{
    var repoCentrosDeAtencionAdoNet = new RepositoriosDemo.RepositoriosAdoNet.CentroDeAtencionRepository();
    var servicio = new CentroDeAtencionService(repoCentrosDeAtencionAdoNet);

    Console.WriteLine("Mostrar todos los Centros De Atencion con ADO NET");
    servicio.MostrarTodos();
    Console.WriteLine("");

    using(var context = new AppDbContext())
    {
        var repoCentrosDeAtencionEF = new RepositoriosDemo.RepositoriosEF.CentroDeAtencionRepository(context);
        servicio = new CentroDeAtencionService(repoCentrosDeAtencionEF);

        Console.WriteLine("Mostrar todos los  Centros De Atencion con EF Core");
        servicio.MostrarTodos();
        Console.WriteLine("");
    }
    Console.ReadLine();
}

Console.ReadLine();

void ImprimirEntidades<T>(IEnumerable<T> lista) where T : EntidadBase
{
    foreach (var t in lista)
    {
        // Console.WriteLine($"Id:{t.Id} - {t.Nombre} - Activo:{t.Activo}");
        t.MostrarDetalles();
    }
    Console.WriteLine("");
}


void EjemploConEntityFramework()
{
    // var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
    // optionsBuilder.UseSqlServer("TuCadenaDeConexionAqui");

    using (var context = new AppDbContext())
    {
        // Crear y agregar CentroDeAtencion
        
        var centroDeAtencion = new CentroDeAtencion
        {
            Id = Guid.NewGuid(),
            Nombre = "Centro de Salud con EF 8",
            Direccion = "123 Calle Principal",
            Telefono = "123-456-7890",
            Email = "contacto@centrodesalud.com",
            FechaAlta = DateTime.UtcNow,
            UsuarioAlta = "admin"
        };

        var repoDeCentros = new RepositoriosDemo.RepositoriosEF.CentroDeAtencionRepository(context);
        repoDeCentros.Create(centroDeAtencion);

        var centros = repoDeCentros.GetAll();

        ImprimirEntidades(centros);


        // Crear y agregar Medico

        var medico = new Medico
        {
            Id = Guid.NewGuid(),
            Nombre = "Dr. Juan Pérez con EF 8",
            Activo = true,
            FechaAlta = DateTime.Now,
            UsuarioAlta = "admin",
            Matricula = "123456",
            Telefono = "555-5678",
            Email = "jperez@example.com",
            TieneLinked = true,
            LinkedInURL = "https://linkedin.com/in/juanperez"
        };

        var repoDeMedicos = new RepositoriosDemo.RepositoriosEF.MedicoRepository(context);
        repoDeMedicos.Create(medico);

        var medicos = repoDeMedicos.GetAll();
        ImprimirEntidades(medicos);

        // Crear y agregar Servicio

        var servicio = new Servicio
        {
            Id = Guid.NewGuid(),
            Nombre = "Clinica Medica con EF 8",
            Activo = true,
            FechaAlta = DateTime.Now,
            UsuarioAlta = "admin",
            Email = "consultageneral@example.com",
            Observaciones = "Este servicio incluye consultas generales con médicos clínicos."
        };
        
        var repoDeServicios = new RepositoriosDemo.RepositoriosEF.ServicioRepository(context);
        repoDeServicios.Create(servicio);

        var servicios = repoDeServicios.GetAll();
        ImprimirEntidades(servicios);


        Console.ReadLine();

        //// context.CentrosDeAtencion.Add(centroDeAtencion);

        //// Crear y agregar Medico
        //var medico = new Medico
        //{
        //    Id = Guid.NewGuid(),
        //    Nombre = "Dr. John Doe",
        //    Matricula = "MED123456",
        //    Email = "john.doe@hospital.com",
        //    Telefono = "321-654-0987",
        //    TieneLinked = true,
        //    LinkedInURL = "https://www.linkedin.com/in/johndoe",
        //    FechaAlta = DateTime.UtcNow,
        //    UsuarioAlta = "admin"
        //};
        //context.Medicos.Add(medico);

        //// Crear y agregar Servicio
        //var servicio = new Servicio
        //{
        //    Id = Guid.NewGuid(),
        //    Nombre = "Consulta General",
        //    Email = "consulta@hospital.com",
        //    Observaciones = "Atención de Lunes a Viernes",
        //    FechaAlta = DateTime.UtcNow,
        //    UsuarioAlta = "admin"
        //};
        //context.Servicios.Add(servicio);

        // Guardar todos los cambios en la base de datos
        context.SaveChanges();
    }

    Console.WriteLine("Entidades agregadas exitosamente.");
}

