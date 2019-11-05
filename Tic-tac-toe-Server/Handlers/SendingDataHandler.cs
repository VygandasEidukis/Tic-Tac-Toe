using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Tic_tac_toe_Server.Models;

namespace Tic_tac_toe_Server.Handlers
{
    public static class SendingDataHandler
    {
        public static void SendPacket(SendingObjectModel packet, NetworkStream stream)
        {
            string message = JsonConvert.SerializeObject(packet);
            byte[] dataToSend = Encoding.ASCII.GetBytes(message);
            stream.Write(dataToSend, 0, dataToSend.Length);
        }
    }
}
