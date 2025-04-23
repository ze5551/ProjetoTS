using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto
{
    internal class user
    {
        
        public string login;
        public string password;

        public bool isLoggedIn = false;
        private string dtaLogin;

        public user(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
        public bool checkLoggin()
        {
            if (password == "admin" && login == "admin")
            {
                isLoggedIn = true;
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
