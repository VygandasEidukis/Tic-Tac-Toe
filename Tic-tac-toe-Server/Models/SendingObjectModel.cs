using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_tac_toe_Server.Models
{
    public class SendingObjectModel
    {
        public int PacketID { get; set; }
        public object PacketData { get; set; }
        public SendingObjectModel()
        {

        }
    }
}
