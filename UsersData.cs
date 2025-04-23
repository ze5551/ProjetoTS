using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ProjetoTS
{
    internal class UsersData : DbContext
    {
        public DbSet<user> user { get; set; }
    }
}
