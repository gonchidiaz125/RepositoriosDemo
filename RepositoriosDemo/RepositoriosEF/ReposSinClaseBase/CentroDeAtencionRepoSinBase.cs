using RepositoriosDemo.Entidades;


namespace RepositoriosDemo.RepositoriosEF.ReposSinClaseBase
{
    public class CentroDeAtencionRepoSinBase
    {
        private readonly AppDbContext _context;

        public CentroDeAtencionRepoSinBase(AppDbContext context)
        {
            _context = context;
        }

        public CentroDeAtencion GetById(Guid id)
        {
            // return _context.Set<CentroDeAtencion>().FirstOrDefault(c => c.Id == id);
            return _context.Set<CentroDeAtencion>().Find(id);
        }

        public List<CentroDeAtencion> GetAll()
        {
            return _context.Set<CentroDeAtencion>().ToList();
        }

        public void Create(CentroDeAtencion centroDeAtencion)
        {
            _context.Set<CentroDeAtencion>().Add(centroDeAtencion);
            _context.SaveChanges();
        }

        public void Update(CentroDeAtencion centroDeAtencion)
        {
            _context.Set<CentroDeAtencion>().Update(centroDeAtencion);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var centroDeAtencion = GetById(id);
            if (centroDeAtencion != null)
            {
                _context.Set<CentroDeAtencion>().Remove(centroDeAtencion);
                _context.SaveChanges();
            }
        }

        public void DarDeBaja(Guid id, string usuarioBaja)
        {
            var centroDeAtencion = GetById(id);
            if (centroDeAtencion != null)
            {
                centroDeAtencion.Activo = false;
                centroDeAtencion.FechaBaja = DateTime.Now;
                centroDeAtencion.UsuarioBaja = usuarioBaja;
                Update(centroDeAtencion);
            }
        }

        public void Reactivar(Guid id)
        {
            var centroDeAtencion = GetById(id);
            if (centroDeAtencion != null)
            {
                centroDeAtencion.Activo = true;
                centroDeAtencion.FechaBaja = null;
                centroDeAtencion.UsuarioBaja = null;
                Update(centroDeAtencion);
            }
        }

    }
}
