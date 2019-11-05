using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Tic_tac_toe_Client.Models;
using Tic_tac_toe_Server.Models;

namespace Tic_tac_toe_Client.ViewModels
{
    class MainViewModel : Conductor<object>
    {
        public Client client { get; set; }
        public MainViewModel()
        {
            client = new Client();
            client.SendObject(new SendingObjectModel() { PacketID = 1, PacketData = new GameLogicModel() { Place = new int[2] { 2,3 }, UserMark = 1 } });
        }
    }
}
