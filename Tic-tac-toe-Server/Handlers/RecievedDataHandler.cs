using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tic_tac_toe_Server.Models;

namespace Tic_tac_toe_Server.Handlers
{
    public static class RecievedDataHandler
    {
        public static void HandleRecievedData(string data)
        {
            RecievedObjectModel um = JsonConvert.DeserializeObject<RecievedObjectModel>(data);
            //JsonConvert.DeserializeObject<GameLogicModel>(um.PacketData.ToString())
            Console.WriteLine(data);
        }
    }
}
