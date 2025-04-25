using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoTS;

namespace Server
{
    internal class UsersDataServer : DbContext
    {
            public DbSet<UserServer> UserServer { get; set; }  
        
    }
}
