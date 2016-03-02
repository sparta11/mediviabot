using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.game.model
{
    class Food : Item
    {
        public uint RegenerationTime { get; set; }

        public Food(string[] properties, int id, string name, uint regenerationTime) : base(properties, id, name)
        {
            RegenerationTime = regenerationTime;
        }
    }
}
