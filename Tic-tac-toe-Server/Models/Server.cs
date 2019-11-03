using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Tic_tac_toe_Server.Models
{
    public class Server
    {
        public Thread ListeningThread { get; set; }
        public int Port { get; private set; } = 25565;
        public IPAddress Host { get; private set; }
        public TcpClient Client { get; private set; }
        public TcpListener Listener { get; private set; }

        public Server(string Host = "localhost", int Port = 25565)
        {
            this.Host = Dns.GetHostEntry(Host).AddressList[0];
            this.Port = Port;
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

                byte[] recieveBuffer = new byte[100];
                NetworkStream stream = Client.GetStream();

                stream.Read(recieveBuffer, 0, recieveBuffer.Length);

                string message = Encoding.ASCII.GetString(recieveBuffer);
            }
        }
    }
}
