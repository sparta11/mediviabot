using MediviaBot.util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.client.gui
{
    interface ClientGui
    {

        Point GroundPosition(string location);
        Point GroundPosition(Location location);
        Point ContainerPosition(int slot, int containerIndex);
        Point InventoryPosition(int slotId);
        string GetClientHotkey(string text);
        string GetStatusMessage();

    }
}
