using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Player
    {
        public static string name { get; set; }
        public static int turn { get; set; }
        public static int score { get; set; }
    }

    class OtherPlayers
    {
        public string name { get; set; }
        public string turn { get; set; }
        public string score { get; set; }
    }
}
