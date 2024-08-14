using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriosDemo.RepositoriosAdoNet
{
    class ConfiguracionBD
    {
        public string ObtenerStringConexion()
        {
            return "Server=localhost;Database=RepositoriosDemo;Trusted_Connection=True;MultipleActiveResultSets=true";
        }
    }
}
