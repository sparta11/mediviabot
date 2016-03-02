using MediviaBot.client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memory.gui
{
    class InventoryReader : GuiMemoryReader
    {
        internal List<UIWidget> FindAllInventorySlotsUIWidgets()
        {
            //uint rootAdr = GetRootPanelAdr();

            //uint rightPanelAdr = findChildAddressByID("gameRightPanel", rootAdr);
            uint inventoryAdr = findChildAddressByID("inventoryWindow", gameRightPanelAdr);
            if (inventoryAdr == 0)
                inventoryAdr = findChildAddressByID("inventoryWindow", gameLeftPanelAdr);

            uint contentsPanel = findChildAddressByID("contentsPanel", inventoryAdr);
            List<uint> slots = findAllChildsAddress(contentsPanel);

            List<UIWidget> slotsList = new List<UIWidget>();
            foreach (uint slot in slots)
            {
                UIWidget slotWidget = ReadUIWidget(slot);
                if (slotWidget.Id.StartsWith("slot"))
                    slotsList.Add(slotWidget);
            }

            return slotsList;
        }
    }
}
