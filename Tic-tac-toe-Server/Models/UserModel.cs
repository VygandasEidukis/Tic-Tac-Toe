using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Tic_tac_toe_Server.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public NetworkStream stream { get; set; }
    }
}
