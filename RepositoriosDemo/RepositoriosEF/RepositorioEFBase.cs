using Microsoft.EntityFrameworkCore;
using RepositoriosDemo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriosDemo.RepositoriosEF
{
    public class RepositoryEFBase<TEntity> where TEntity : EntidadBase
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryEFBase(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public TEntity GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public List<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Create(TEntity entity)
        {
            try
            {
                _dbSet.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }            
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
        }

        public void DarDeBaja(Guid id, string usuarioBaja)
        {
            var entity = GetById(id);
            if (entity is EntidadBase entidadBase)
            {
                entidadBase.Activo = false;
                entidadBase.FechaBaja = DateTime.Now;
                entidadBase.UsuarioBaja = usuarioBaja;
                Update(entity);
            }
        }

        public void Reactivar(Guid id)
        {
            var entity = GetById(id);
            if (entity is EntidadBase entidadBase)
            {
                entidadBase.Activo = true;
                entidadBase.FechaBaja = null;
                entidadBase.UsuarioBaja = null;
                Update(entity);
            }
        }
    }

}
