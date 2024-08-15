using RepositoriosDemo.RepositoriosAdoNet;


namespace RepositoriosDemo.Servicios
{
    public class CentroDeAtencionService
    {
        public readonly ICentroDeAtencionRepository _centroDeAtencionRepository;

        public CentroDeAtencionService(ICentroDeAtencionRepository centroDeAtencionRepository) { 
            _centroDeAtencionRepository = centroDeAtencionRepository;
        }

        public void MostrarTodos()
        {
            var medicos = _centroDeAtencionRepository.GetAll();

            foreach (var t in medicos)
            {                
                t.MostrarDetalles();
            }
            Console.WriteLine("");
        }
    }
}
