using RepositoriosDemo.Entidades;

namespace RepositoriosDemo.RepositoriosEF
{
    public class MedicoRepository : RepositoryEFBase<Medico>
    {
        public MedicoRepository(AppDbContext context) : base(context)
        {
        }
    }

}
