using MediviaBot.addresses;
using MediviaBot.client;
using MediviaBot.memory;
using MediviaBot.memory.gui;
using MediviaBot.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memory.gui
{
    class GuiMemoryReader : MemoryManager, GuiReader
    {

        protected GuiAddress addresses = GuiAddressRepository.Instance;
        private StructureHelper structHelper = new StructureHelper();

        protected uint rootAdr = 0;
        //game panels
        protected uint gameRootPanelAdr = 0;
        protected uint gameMapPanelAdr = 0;
        protected uint gameBottomPanelAdr = 0;
        protected uint gameLeftPanelAdr = 0;
        protected uint gameRightPanelAdr = 0;
        protected uint bottomSplitterAdr = 0;
        //hotkey
        protected uint hotkeysWindowAdr = 0;

        public GuiMemoryReader()
        {
            this.rootAdr = ReadUInt32(GetBaseAddress() + addresses.GetGuiStartAddress());
            //game panels
            this.gameRootPanelAdr = findChildAddressByID("gameRootPanel", rootAdr);
            this.gameMapPanelAdr = findChildAddressByID("gameMapPanel", gameRootPanelAdr);
            this.gameBottomPanelAdr = findChildAddressByID("gameBottomPanel", gameRootPanelAdr);
            this.gameRightPanelAdr = findChildAddressByID("gameRightPanel", gameRootPanelAdr);
            this.gameLeftPanelAdr = findChildAddressByID("gameLeftPanel", gameRootPanelAdr);
            this.bottomSplitterAdr = findChildAddressByID("bottomSplitter", gameRootPanelAdr);
            //hotkey
            this.hotkeysWindowAdr = findChildAddressByID("hotkeysWindow", rootAdr);
        }

        public Rect GetGameMapRect()
        {
            Rect rect = new Rect();
            rect.Left = ReadInt32(gameMapPanelAdr + addresses.GetGameMapLeftPosAdrress());
            rect.Top = ReadInt32(gameMapPanelAdr + addresses.GetGameMapTopPosAdrress());
            rect.Right = ReadInt32(gameMapPanelAdr + addresses.GetGameMapRightPosAdrress());
            rect.Bottom = ReadInt32(gameMapPanelAdr + addresses.GetGameMapBottomPosAdrress());
            return rect;
        }

        public List<ClientHotkey> GetHotkeys()
        {
            return new HotkeyReader().getAllHotkeys();
        }

        public List<UIWidget> GetInventorySlotsUIWidgets()
        {
            return new InventoryReader().FindAllInventorySlotsUIWidgets();
        }

        public List<UIWidget> GetContainerUIWidgets()
        {
            return new GuiContainerReader().GetAllContainers();
        }

        protected UIWidget ReadUIWidget(uint widgetAddress)
        {

            string id = getWidgetID(widgetAddress);
            Rect rect = new Rect();
            rect.Left = ReadInt32(widgetAddress + addresses.GetUIWidgetLeftPosAdrress());
            rect.Top = ReadInt32(widgetAddress + addresses.GetUIWidgetTopPosAdrress());
            rect.Right = ReadInt32(widgetAddress + addresses.GetUIWidgetRightPosAdrress());
            rect.Bottom = ReadInt32(widgetAddress + addresses.GetUIWidgetBottomPosAdrress());

            UIWidget w = new UIWidget(id);
            w.Rect = rect;
            return w;
        }

        protected string getWidgetID(uint addr)
        {
            uint idOffset = addresses.GetUIWidgetIDAdrress();
            addr = ReadUInt32(addr + idOffset);
            return ReadString(addr, 24);
        }

        protected uint findChildAddressByID(string widgetID, uint parent)
        {
            List<uint> childsAddress = this.findAllChildsAddress(parent);

            foreach (uint childAdr in childsAddress)
            {
                string id = getWidgetID(childAdr);
                if (id.Equals(widgetID))
                    return childAdr;
            }
            return 0;
        }

        protected List<UIWidget> findAllChilds(uint parentAdr)
        {
            List<uint> childsAddrs = this.findAllChildsAddress(parentAdr);
            List<UIWidget> childs = new List<UIWidget>();
            foreach (uint childAdr in childsAddrs)
            {
                UIWidget widget = ReadUIWidget(childAdr);
                childs.Add(widget);
            }

            return childs;
        }

        protected List<uint> findAllChildsAddress(uint parent)
        {
            uint dequeStart = ReadUInt32(parent + addresses.GetUIWidgetChildrensAdrress());
            int dequeSize = ReadInt32(parent + addresses.GetUIWidgetChildrensSizeAdrress());
            int firstIndex = ReadInt32(parent + +addresses.GetUiWidgetChildrenFirstIndexAddress());
            return this.structHelper.iterateDeque(parent, dequeStart, dequeSize, firstIndex);
        }

        public string GetStatusMessage()
        {
            return new StatusMessageReader().readMessage();
        }
    }
}

