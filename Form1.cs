using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EI.SI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ProjetoTS
{
    public partial class Form1: Form
    {
        private const int PORT = 10001;
        NetworkStream networkStream;
        ProtocolSI protocolSI;
        TcpClient client;




        /*
        private const string UsernameLabel = "Enter User Name";
        private const string passwordLabel = "Password";
        private const string PasswordSignUp = "Password";
        private const string UserNameSignUp = "Enter Username";
        private const string ConfirmPassword = "Confirm Password";
        */
        int pw;
        bool hided;

        public Form1()
        {
            InitializeComponent();

            
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Loopback, PORT);
            client = new TcpClient();
            client.Connect(endpoint);
            networkStream = client.GetStream();
            protocolSI = new ProtocolSI();






            /*
            textBoxUsername.Text = UsernameLabel;
            textBoxPassword.Text = passwordLabel;
            textBoxUserSignUp.Text = UserNameSignUp;
            textBoxPasswordSignUp.Text = PasswordSignUp;
            textBoxCPasswordSignUp.Text = ConfirmPassword;   
            */
        }
        void IncreaseOpacity(object sender, EventArgs e)
        {
            if (this.Opacity <= 1)
            {
                this.Opacity += 0.01;
            }
            if (this.Opacity == 1)
            {
                timer.Stop();
            }
        }
        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            /*atualizado
            try
            {
                if(textBoxUsername.Text == "")
                {
                    textBoxUsername.Text = "Enter Username";
                    return;
                }
                textBoxUsername.ForeColor = Color.White;
                lblinvalidUser.Visible = false;
            }
            catch { }
            */
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            /*
            try
            {
                if (textBoxPassword.Text == "")
                {
                    textBoxPassword.Text = "Password";
                    return;
                }
                textBoxPassword.ForeColor = Color.White;
                textBoxPassword.PasswordChar = '*';
                lblinvalidPass.Visible = false;
            }
            catch { }
            */
        }
        private void textBoxUsername_Click(object sender, EventArgs e)
        {
            textBoxUsername.SelectAll();
        }

        private void textBoxPassword_CLick(object sender, EventArgs e)
        {
            textBoxPassword.SelectAll();
        }

        private void button1_MouseEnter(object sender, EventArgs e) //botão login
        {
            btnLogin.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e) //botão login
        {
            btnLogin.ForeColor = Color.White;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            
            //UsersData UsersData = new UsersData();

            //var userdb = new UsersData();
            var username = textBoxUsername.Text;
            var password = textBoxPassword.Text;
            


            int clientCounter = 0;
            string logintxt = username + "," + password+","+"1";
            // bool isLoggedIn = user.SetLogginTrue();
            byte[] packet = protocolSI.Make(ProtocolSICmdType.DATA,logintxt);
            networkStream.Write(packet, 0, packet.Length);
            // Definição das variáveis na função principal.
            
            
            MessageBox.Show("SERVER READY");
            bool var = true;
            
            while (var)
            {
                // Definição da variável client do tipo TcpClient
                string MSG;

                // Incrementação do contador, de forma a que vá sempre somando 1 (+1)
                clientCounter++;
                // Apresentação da mensagem indicative do nº do client na linha de comandos 
                MessageBox.Show("Client {0} connected "+ clientCounter);
                int bytesRead = networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                
                MSG = protocolSI.GetStringFromData();
                MessageBox.Show("U..; "+protocolSI.GetStringFromData());
                // Definição da variável clientHandler do tipo TcpClient
                ClientHandler clientHandler = new ClientHandler(client, clientCounter);
                clientHandler.Handle();
                if(MSG != null)
                {
                    var = false;
                   BaseApp temp = new BaseApp();
                    temp.Region = this.Region;
                    temp.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid User or Password");
                }
            }

            // Iniciar o listener; apresentação da primeira mensagem na linha de comandos e inicialização do contador.
            





            //var user = UsersData.user.FirstOrDefault(u => u.Username == username && u.Password == password);
            /*    
            if (user == null)
            {
                lblinvalidUser.Visible = true;
                lblinvalidPass.Visible = true;
                textBoxUsername.Focus();
                return;
            }
            else
            {
                //MessageBox.Show("Login successful" + user.Username + "passwrd: " + user.Password);
               BaseApp temp = new BaseApp();
                temp.Region = this.Region;
                temp.Show();
                this.Hide();
                
            }
            */






            /*
            if (textBoxUsername.Text== UsernameLabel)
            {
                lblinvalidUser.Visible = true;
                textBoxUsername.Focus();
                return;
            }

            if (textBoxPassword.Text == passwordLabel)
            {
                lblinvalidPass.Visible = true;
                textBoxPassword.Focus();
                return;
            }
            */
        }



        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void button1_MouseDown(object sender, MouseEventArgs e) //botão login
        {
            
        }

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        private void button1_MouseLeave_1(object sender, EventArgs e) //botão login
        {
            btnLogin.ForeColor = Color.White;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            /*
            if(textBoxUserSignUp.Text == UserNameSignUp)
            {
                pnlUsername.Visible = true;
                textBoxUserSignUp.SelectAll();
                textBoxUserSignUp.Focus();
                return;
            }
            if (textBoxPasswordSignUp.Text == PasswordSignUp)
            {
                pnlPassword.Visible = true;
                textBoxPasswordSignUp.SelectAll();
                textBoxPasswordSignUp.Focus();
                return;
            }
            if (textBoxCPasswordSignUp.Text == ConfirmPassword)
            {
                pnlCPassword.Visible = true;
                textBoxCPasswordSignUp.Focus();
                textBoxCPasswordSignUp.SelectAll();
                return;
            }
            */
            var username = textBoxUserSignUp.Text;
            var password = textBoxPasswordSignUp.Text;
            int clientCounter = 0;
            string registertxt = username + "," + password + "," + "0";
            // bool isLoggedIn = user.SetLogginTrue();
            byte[] packet = protocolSI.Make(ProtocolSICmdType.DATA, registertxt);
            networkStream.Write(packet, 0, packet.Length);
            // Definição das variáveis na função principal.


            MessageBox.Show("SERVER READY/regisar");
            bool var = true;
            
            while (var)
            {
                // Definição da variável client do tipo TcpClient
                string MSG;

                // Incrementação do contador, de forma a que vá sempre somando 1 (+1)
                clientCounter++;
                // Apresentação da mensagem indicative do nº do client na linha de comandos 
                MessageBox.Show("Client {0} connected " + clientCounter);
                int bytesRead = networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);

                MSG = protocolSI.GetStringFromData();
                MessageBox.Show("regs; " + protocolSI.GetStringFromData());
                // Definição da variável clientHandler do tipo TcpClient
                ClientHandler clientHandler = new ClientHandler(client, clientCounter);
                clientHandler.Handle();
                if (MSG != null)
                {
                    var = false;
                    pnlLogin.Visible = true;
                    pnlLogin.Dock = DockStyle.Fill;
                    pnlSignUp.Visible = false;
                    pnlLogo.Dock = DockStyle.Left;
                }
                else
                {
                    MessageBox.Show("Invalid User or Password");
                }
            
            }





            using (var userdb = new UsersData())
            {
                /*
                var user = new user { Username = textBoxUserSignUp.Text, Password = textBoxPasswordSignUp.Text, SingUpDate = DateTime.Now };
                userdb.user.Add(user);


                userdb.SaveChanges();

                */
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pnlUsername.Visible = pnlPassword.Visible = pnlCPassword.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Opacity = .01;
            timer.Interval = 10;
            timer.Tick += IncreaseOpacity;
            timer.Start();

        }

        private void textBoxUserSignUp_TextChanged(object sender, EventArgs e)
        {
            textBoxUserSignUp.ForeColor = Color.White;
        }

        private void textBoxPasswordSignUp_TextChanged(object sender, EventArgs e)
        {
            textBoxUserSignUp.ForeColor = Color.White;
        }

        private void textBoxCPasswordSignUp_TextChanged(object sender, EventArgs e)
        {
            textBoxUserSignUp.ForeColor = Color.White;
        }

        private void btnSignUp_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.Black;
        } 

        private void linkLabelCreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlLogin.Visible = false;
            pnlSignUp.Visible = true;
            pnlLogo.Dock = DockStyle.Right;

            pnlSignUp.Dock = DockStyle.Fill;
            
        }

        private void linkLabelAlreadyHaveAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlLogin.Visible = true;
            pnlLogin.Dock = DockStyle.Fill;
            pnlSignUp.Visible = false;
            pnlLogo.Dock = DockStyle.Left;
        }

        private void panelNavbar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); // Move o formulário
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            this.Opacity = 0.5;
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            
            this.Opacity = 0.5;
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void pnlSignUp_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    class ClientHandler
    {
        // Definição das variáveis client e clientID.
        private TcpClient client;
        private int clientID;
        public ClientHandler(TcpClient client, int clientID)
        {
            this.client = client;
            this.clientID = clientID;
        }
        public void Handle()
        {
            // Definição da variável thread e arranque da mesma
            // Para relembrar: Threads são unidades de execução dentro de um processo; um conjunto de instruções.
            Thread thread = new Thread(threadHandler);
            thread.Start();
        }
        private void threadHandler()
        {
            // Definição das variáveis networkStream e protocolSI
            NetworkStream networkStream = this.client.GetStream();
            ProtocolSI protocolSI = new ProtocolSI();


            // Ciclo a ser executado até ao fim da transmissão.
            while (protocolSI.GetCmdType() != ProtocolSICmdType.EOT)
            {
                int bytesRead = networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                byte[] ack;

                // "Alteração"/mudança entre a apresentação da mensagem e o fim da tranmissão.
                switch (protocolSI.GetCmdType())
                {
                    //Dica do ALT
                    case ProtocolSICmdType.DATA:
                        Console.WriteLine("Client " + clientID + ": " + protocolSI.GetStringFromData());
                        ack = protocolSI.Make(ProtocolSICmdType.ACK);
                        networkStream.Write(ack, 0, ack.Length);
                        break;

                    case ProtocolSICmdType.EOT:
                        Console.WriteLine("Ending Thread from Client {0}", clientID);
                        ack = protocolSI.Make(ProtocolSICmdType.ACK);
                        networkStream.Write(ack, 0, ack.Length);
                        break;
                }
            }

            // Fecho do networkStream e do cliente (TcpClient)
            networkStream.Close();
            client.Close();
        }
    }

}
