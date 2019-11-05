using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Tic_tac_toe_Server.Handlers;
using System.IO;

namespace Tic_tac_toe_Server.Models
{
    public class Server
    {
        public List<UserModel> Users { get; set; }
        public Thread ListeningThread { get; set; }
        public int Port { get; private set; } = 25565;
        public IPAddress Host { get; private set; }
        public TcpClient Client { get; private set; }
        public TcpListener Listener { get; private set; }

        public Server(string Host = "localhost", int Port = 25565)
        {
            this.Host = Dns.GetHostEntry(Host).AddressList[0];
            this.Port = Port;
            Users = new List<UserModel>();

            ListeningThread = new Thread(Listen);
            
            SetUp();
        }

        private void SetUp()
        {
            Listener = new TcpListener(Host, Port);
            Client = default(TcpClient);
        }

        public void Start()
        {
            try
            {
                Listener.Start();
                ListeningThread.Start();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void Listen()
        {
            while(true)
            {
                Client = Listener.AcceptTcpClient();

                List<byte> test = new List<byte>();

                byte[] recieveBuffer = new byte[100];
                NetworkStream stream = Client.GetStream();

                //add user to list
                if (AddUser(stream))
                {
                    Console.WriteLine($"Added player {Users.Count()} to server");
                }else
                {
                    Console.WriteLine("Server is full");
                }

                foreach(UserModel user in Users)
                {
                        string message = ProcessMessage(user.stream);
                        RecievedDataHandler.HandleRecievedData(message);
                }
            }
        }

        private string ProcessMessage(NetworkStream stream)
        {
            StringBuilder RecievedMessage = new StringBuilder();
            do
            {
                byte[] b = new byte[3];
                stream.Read(b, 0, b.Length);
                RecievedMessage.Append(Encoding.ASCII.GetString(b, 0, b.Length));
            }
            while (stream.DataAvailable);
            return RecievedMessage.ToString().Substring(0,RecievedMessage.ToString().Length-1);
        }

        private bool AddUser(NetworkStream stream)
        {
            if(Users.Count <= 2)
            {
                UserModel user = new UserModel();
                user.stream = stream;
                user.UserID = Users.Count();
                Users.Add(user);
                Console.WriteLine("Added user");
                return true;
            }
            return false;
        }

        public void SendData(byte[] data, UserModel user)
        {
            user.stream.Write(data, 0, data.Length);
        }
    }
}
