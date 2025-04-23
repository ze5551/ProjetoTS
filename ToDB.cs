using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace ProjetoTS
{
    internal class ToDB : DbContext
    {
        public DbSet Users user { get; set; }
        public DbSet users password { get; set; }


	

    }
