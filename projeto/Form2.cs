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
    public partial class Form2 : Form
    {
        List<user> nowuser;
        public Form2()
        {
            InitializeComponent();
            nowuser = new List<user>();
            
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            

            
            bool IsLoggedIn = false;
            string login = tblogin.Text;
            string password = tbpassword.Text;
            DateTime dtaLogin = DateTime.Now;
            user u = new user(login, password);
            if (u.checkLoggin() == true)
            {
                IsLoggedIn = true;
                Form1 app = new Form1();
                app.Show();
                this.Hide();
               

            }
            else
            {
                IsLoggedIn = false;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
