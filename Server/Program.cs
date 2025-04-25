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
    

    class Server
    {
        //Criar novamente uma constante, tal como feito do lado do cliente.
       

        private const int PORT = 10001;
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
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, PORT);
            TcpListener listener = new TcpListener(endpoint);
            listener.Start();
            Console.WriteLine("SERVER READY");
            int clientCounter = 0;

            // Definição das variáveis na função principal.

            bool LogedIN = false;
        // Iniciar o listener; apresentação da primeira mensagem na linha de comandos e inicialização do contador.
            
            //Criação do ciclo infinito de forma a que este esteja sempre em execução até ordem em contrário
            
            do{
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
                

            }while (!LogedIN);
        }
    }

    class ClientHandler
    {
        public int logreceived = 0;
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
            bool isLogedIn = false;
            // Ciclo a ser executado até ao fim da transmissão.

            do
            {
                int bytesRead = networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                byte[] ack;

                // "Alteração"/mudança entre a apresentação da mensagem e o fim da tranmissão.

                //Dica do ALT

                UsersDataServer UsersDataServer = new UsersDataServer();
                var UserServerDB = new UsersDataServer();
                Console.WriteLine("Client " + clientID + ": " + protocolSI.GetStringFromData());
                string received = protocolSI.GetStringFromData();
                string[] dados = received.Split(',');
                string Username = dados[0];
                string Password = dados[1];
                string LoginOrRegister = dados[2];
                int Var = 0;
                var user = UsersDataServer.UserServer.FirstOrDefault(u => u.Username == Username && u.Password == Password);
                switch (LoginOrRegister)
                {
                    case "1":
                        
                        if (user == null)
                        {

                            Var = 0;
                            isLogedIn = false;
                            byte[] packet = protocolSI.Make(ProtocolSICmdType.DATA, Var);
                            networkStream.Write(packet, 0, packet.Length);

                            break;


                            
                        }
                        else
                        {
                            //MessageBox.Show("Login successful" + user.Username + "passwrd: " + user.Password);
                            Var = 1;
                            isLogedIn = true;
                            byte[] packet = protocolSI.Make(ProtocolSICmdType.DATA, Var);
                            networkStream.Write(packet, 0, packet.Length);

                        }
                        //Login

                        break;
                    case "0":
                        using (var UserServerdb = new UsersDataServer())
                        {
                            
                            var UserServer = new UserServer { Username = Username, Password = Password, SingUpDate = DateTime.Now };
                            UserServerdb.UserServer.Add(UserServer);


                            UserServerdb.SaveChanges();
                           

                        }
                        //Registo
                        isLogedIn = false;
                        break;
                }
                

                
                Console.WriteLine("Client " + clientID + ": " + protocolSI.GetStringFromData());

            } while (!isLogedIn);



                        /*
                        UsersDataServer UsersDataServer = new UsersDataServer();
                        var UserServerDB = new UsersDataServer();
                        switch (LoginOrRegister)
                        {
                            case "1":
                                var user = UsersDataServer.UserServer.FirstOrDefault(u => u.Username == Username && u.Password == Password);
                                if (user == null)
                                {

                                    Var = 0;
                                    byte[] packet = protocolSI.Make(ProtocolSICmdType.DATA, Var);
                                    networkStream.Write(packet, 0, packet.Length);
                                }
                                else
                                {
                                    //MessageBox.Show("Login successful" + user.Username + "passwrd: " + user.Password);
                                    Var = 1;


                                }
                                //Login

                                break;
                            case "0":
                                //Registo
                                break;
                        }*/


                    //verifica base de dados


                    //servidor envia um "1" para autentificar login ou 0 para credenciais erradas




                    //UserServer.Username = Username;
                    //UserServer.Password = Password;
                    //Console.WriteLine(UserServer.Username+ " Password: "+UserServer.Password);





            

            // Fecho do networkStream e do cliente (TcpClient)
            //networkStream.Close();
            //client.Close();
        }
    }
}