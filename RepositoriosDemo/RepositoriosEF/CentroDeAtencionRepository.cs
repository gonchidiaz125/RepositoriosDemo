using RepositoriosDemo.Entidades;
using RepositoriosDemo.RepositoriosAdoNet;

namespace RepositoriosDemo.RepositoriosEF
{
    public class CentroDeAtencionRepository : RepositoryEFBase<CentroDeAtencion>, ICentroDeAtencionRepository
    {
        public CentroDeAtencionRepository(AppDbContext context) : base(context)
        {
        }
    }

}
