using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediviaBot.util;
using MediviaBot.memory.gui;
using memory.gui;

namespace MediviaBot.client.gui
{
    class ClientGuiImpl : ClientGui
    {

        private ContainerManager container = new ContainerManager();
        private GameMapManager gameMap = new GameMapManager();
        private GuiReader guiReader = new GuiMemoryReader();

        public Point ContainerPosition(int slot, int containerIndex)
        {
            return container.GetInventoryPosition(slot, containerIndex);
        }

        public string GetClientHotkey(string text)
        {
            List<ClientHotkey> hotkeys = guiReader.GetHotkeys();
            foreach(ClientHotkey h in hotkeys)
            {
                if (h.Text.Equals(text, StringComparison.InvariantCultureIgnoreCase))
                    return h.Keys;
            }
            return "not found";
        }

        public string GetStatusMessage()
        {
            return guiReader.GetStatusMessage();
        }

        public Point GroundPosition(Location location)
        {
            return gameMap.GetGroundPosition(location);
        }

        public Point GroundPosition(string location)
        {
            return gameMap.GetGroundPosition(location);
        }

        public Point InventoryPosition(int slotId)
        {
            string slotID = "slot" + slotId;
            List<UIWidget> slots = guiReader.GetInventorySlotsUIWidgets();
            foreach (UIWidget slot in slots)
            {
                if (slot.Id.Equals(slotID))
                    return ClientGuiHelper.GetRandomCenterPos(slot.Rect);
            }
            return new Point(-1, -1);
        }


    }
}
