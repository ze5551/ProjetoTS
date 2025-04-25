using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProjetoTS
{
    internal class UserServer
    {
        public int Id { get; set; }
        public string Username { get; set; } 
        public string Password { get; set; }
        public DateTime SingUpDate { get; set; }

        bool IsLoggedIn { get; set; }

        public String GetData(string Text)
        {
            SingUpDate = DateTime.Now;
            String Devolve = Text;
            return Devolve;
        }

        public bool SetLogginTrue()
        {
            IsLoggedIn = true;
            return IsLoggedIn;
        }

    }
}
