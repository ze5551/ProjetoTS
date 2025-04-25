using EI.SI;
using ProjetoTS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    

public partial class Server
    {
        //Criar novamente uma constante, tal como feito do lado do cliente.
        private const int PORT = 10000;

        //private List<UserDServer> userDataServers;
        //private List<UserServer> UserServer;
        
        public bool checkLogin()
        {
            
            //UserServer u;
            string Password;
            string Username;
            //UsersDataServer UsersDataServer = new UsersDataServer();
            // var userdb = new UsersDataServer();
            // UserServer  = new List<UserServer>();
            /*using (var UserServerdb = new UsersDataServer())
            {
                
                
                UserServerdb.UserServer.Add(UserServer);


                UserServerdb.SaveChanges();

                
                        // Verifica se o login e a password estão corretos
            UsersDataServer UsersDataServer = new UsersDataServer();
            //var username = UserServer.Username;
            //var password = UserServer.Password;
            var userserverdb = new UsersDataServer();
            var UserServer = UsersDataServer.UserServer.FirstOrDefault(u => u.Username == user && u.Password == password);

            
            if (UserServer.Username == UserServer.Username && Password == UserServer.Password)
            {
                return true;
            }
            else
            {
                
            }*/return false;
        }

            static void Main(string[] args)
        {
           //UserServer UsersData = new UsersData();
           //var userdb = new UsersData();
           //var username = UserServer.Username;
           //var password = UserServer.Password;
           // var user = UsersData.user.FirstOrDefault(u => u.Username == username && u.Password == password);



            // Definição das variáveis na função principal.
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, PORT);
            TcpListener listener = new TcpListener(endpoint);
            bool LogedIN = false;
        // Iniciar o listener; apresentação da primeira mensagem na linha de comandos e inicialização do contador.
             listener.Start();
            Console.WriteLine("SERVER READY");
            int clientCounter = 0;
            //Criação do ciclo infinito de forma a que este esteja sempre em execução até ordem em contrário
            while (!LogedIN)
            {
                // Definição da variável client do tipo TcpClient
                TcpClient client = listener.AcceptTcpClient();

                // Incrementação do contador, de forma a que vá sempre somando 1 (+1)
                clientCounter++;
                

                // Apresentação da mensagem indicative do nº do client na linha de comandos 
                Console.WriteLine("Client {0} connected", clientCounter);

                // Definição da variável clientHandler do tipo TcpClient
                ClientHandler clientHandler = new ClientHandler(client, clientCounter);
                clientHandler.Handle();
                // separar a mensagem em loggin e password
                

            }
        }
    }

    class ClientHandler
    {
        public int logreceived = 0;
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
                        string received = protocolSI.GetStringFromData();
                        string[] dados = received.Split(',');
                        string Username = dados[0];
                        string Password = dados[1];

                        int Var = 0;
                        UsersDataServer UsersDataServer = new UsersDataServer();
                        var UserServerDB = new UsersDataServer();

                        //verifica base de dados
                        
                        var user = UsersDataServer.UserServer.FirstOrDefault(u => u.Username ==Username && u.Password == Password);
                        if (user == null)
                        {
                            
                            Var = 0;
                        }
                        else
                        {
                            //MessageBox.Show("Login successful" + user.Username + "passwrd: " + user.Password);
                            Var = 1;


                        }
                        //servidor envia um "1" para autentificar login ou 0 para credenciais erradas
                        byte[] packet = protocolSI.Make(ProtocolSICmdType.DATA, Var);



                        //UserServer.Username = Username;
                        //UserServer.Password = Password;
                        //Console.WriteLine(UserServer.Username+ " Password: "+UserServer.Password);
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