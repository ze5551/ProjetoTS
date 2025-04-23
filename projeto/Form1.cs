using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto
{
    
    public partial class Form1 : Form
    {
        List<user> nowuser;
        public Form1()
        {
            nowuser = new List<user>();
            InitializeComponent();
            

            
            






        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            string login = "";
            string password = "";
            user u = new user(login, password);
            bool IsLoggedIn = false;
            DateTime dtaLogin = DateTime.Now;
            


            if (u.checkLoggin() == true)
            {
                IsLoggedIn = false;
                Form2 app = new Form2();
                u.password = "";
                u.login = "";
                this.Hide();
                Application.Run(new Form2());

            }
            else
            {
                IsLoggedIn = true;
            }
            this.Hide();

        }
    }
}
