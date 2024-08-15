using RepositoriosDemo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriosDemo.RepositoriosEF
{

    public class ServicioRepository : RepositoryEFBase<Servicio>
    {
        public ServicioRepository(AppDbContext context) : base(context)
        {
        }
    }

}
