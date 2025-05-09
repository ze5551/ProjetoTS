using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoTS
{
    public partial class BaseApp : Form
    {
        private List<Message> Messages;
        public BaseApp()
        {
            InitializeComponent();
            Messages = new List<Message>();
            bool isLoggedIn = true;
            if (isLoggedIn)
            {
                
            }


        }
        private void BaseApp_Load(object sender, EventArgs e)
        {

        }

        private void listBoxContacts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LBChat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BTNSend_Click(object sender, EventArgs e)
        {
                
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
