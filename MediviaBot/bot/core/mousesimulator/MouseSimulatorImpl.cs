using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediviaBot.util;

namespace MediviaBot.bot.core.mousesimulator
{
    class MouseSimulatorImpl : MouseSimulator
    {

        private MouseMover mover = new MouseMover();
        private MouseUser user = new MouseUser();

        public void LeftCLick(string location, bool ctrl = false, bool shift = false, bool alt = false)
        {
            throw new NotImplementedException();
        }

        public void LeftCLick(Location location, bool ctrl = false, bool shift = false, bool alt = false)
        {
            user.LeftClick(location, ctrl, shift, alt);
        }

        public void RightCLick(string location, bool ctrl = false, bool shift = false, bool alt = false)
        {
            throw new NotImplementedException();
        }

        public void RightCLick(Location location, bool ctrl = false, bool shift = false, bool alt = false)
        {
            user.RightClick(location, ctrl, shift, alt);
        }

        public void MoveItems(int itemId, string to, string from = "")
        {
            mover.MoveItems(itemId, to, from);
        }

        public void UseItem(int itemId, int containerIndex)
        {
            user.UseItem(itemId, containerIndex);
        }

        public void UseItem(int itemId, string location = "")
        {
            user.UseItem(itemId, location);
        }

        public void UseItemOn(int itemId, string ground)
        {
            user.UseItemOn(itemId, ground);
        }

        public void UseItemOn(int itemId, Location location)
        {
            user.UseItemOn(itemId, location);
        }
    }
}
