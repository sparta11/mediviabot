using MediviaBot.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.bot.core.mousesimulator
{
    interface MouseSimulator
    {
        void MoveItems(int itemId, string to, string from = "");
        void UseItem(int itemId, string location = "");
        void UseItem(int itemId, int containerIndex);
        void UseItemOn(int itemID, string location);
        void UseItemOn(int itemID, Location location);

        void LeftCLick(string location, bool ctrl = false, bool shift = false, bool alt = false);
        void LeftCLick(Location location, bool ctrl = false, bool shift = false, bool alt = false);
        void RightCLick(string location, bool ctrl = false, bool shift = false, bool alt = false);
        void RightCLick(Location location, bool ctrl = false, bool shift = false, bool alt = false);

    }
}
