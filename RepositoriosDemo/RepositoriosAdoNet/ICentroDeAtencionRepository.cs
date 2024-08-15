using RepositoriosDemo.Entidades;

namespace RepositoriosDemo.RepositoriosAdoNet
{
    public interface ICentroDeAtencionRepository
    {
        void Create(CentroDeAtencion entity);
        CentroDeAtencion GetById(Guid id);
        List<CentroDeAtencion> GetAll();

        void Update(CentroDeAtencion entity);
    }
}
