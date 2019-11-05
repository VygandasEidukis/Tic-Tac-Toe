using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tic_tac_toe_Server.Handlers;
using Tic_tac_toe_Server.Models;

namespace Tic_tac_toe_Client.Models
{
    public class Client
    {
        private Thread ClientThread { get; set; }
        public int Port { get; set; } = 25565;
        public string Host { get; set; } = "localhost";
        public TcpClient ServerClient { get; set; }
        public NetworkStream Stream { get; private set; }
        public Client(int Port = 25565, string Host = "localhost")
        {
            this.Port = Port;
            this.Host = Host;
            ClientThread = new Thread(Listen);
            SetUp();
        }

        private void SetUp()
        {
            ServerClient = new TcpClient(Host, Port);
            Stream = ServerClient.GetStream();

            ClientThread.Start();
        }

        private void Listen()
        {
            while(true)
            {
                if(Stream.DataAvailable)
                {
                    //read data
                }
            }
        }

        public void SendObject(SendingObjectModel obj)
        {
            SendingDataHandler.SendPacket(obj, Stream);
        }
    }
}
