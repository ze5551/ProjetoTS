using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTS
{
    internal class TryLogin : DbContext
    {
        public DbSet<user> user { get; set; }
        
    }
}
