using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.addresses
{
    class GuiAddressRepository : GuiAddress
    {

        private uint clientWidth = 0x527980;
        private uint clientHeight = 0x527984;

        private uint guiStart = 0x57B820;

        private uint uiWidgetId = 0x0C;

        private uint uiWidgetLeftPos = 0x24;
        private uint uiWidgetTopPos = 0x28;
        private uint uiWidgetRightPos = 0x2c;
        private uint uiWidgetBottomPos = 0x30;
        private uint uiWidgetIsVisible = 0x3D;

        private uint uiWidgetLockedChildrens = 0x4C;
        private uint uiWidgetChildrens = 0x50;
        private uint uiWidgetChildrenFirstIndex = 0x58;
        private uint uiWidgetChildrensSize = 0x5C;

        private uint gameMapLeftPos = 0x2A8;
        private uint gameMapTopPos = 0x2AC;
        private uint gameMapRightPos = 0x2B0;
        private uint gameMapBottomPos = 0x2B4;

        private uint[] hotkeyOffsets = { 0x0, 0x224 };

        //singleton instance
        private static GuiAddressRepository instance;

        private GuiAddressRepository() { }

        public static GuiAddressRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GuiAddressRepository();
                }
                return instance;
            }
        }



        public uint GetGuiStartAddress()
        {
            return this.guiStart;
        }

        public uint GetUIWidgetIDAdrress()
        {
            return this.uiWidgetId;
        }

        public uint GetUIWidgetLockedChildrensAdrress()
        {
            return this.uiWidgetLockedChildrens;
        }

        public uint GetUIWidgetChildrensAdrress()
        {
            return uiWidgetChildrens;
        }

        public uint GetUIWidgetChildrensSizeAdrress()
        {
            return uiWidgetChildrensSize;
        }

        public uint GetUIWidgetLeftPosAdrress()
        {
            return this.uiWidgetLeftPos;
        }

        public uint GetUIWidgetTopPosAdrress()
        {
            return this.uiWidgetTopPos;
        }

        public uint GetUIWidgetRightPosAdrress()
        {
            return this.uiWidgetRightPos;
        }

        public uint GetUIWidgetBottomPosAdrress()
        {
            return this.uiWidgetBottomPos;
        }

        public uint GetUiWidgetChildrenFirstIndexAddress()
        {
            return this.uiWidgetChildrenFirstIndex;
        }

        public uint GetGameMapLeftPosAdrress()
        {
            return this.gameMapLeftPos;
        }

        public uint GetGameMapTopPosAdrress()
        {
            return this.gameMapTopPos;
        }

        public uint GetGameMapRightPosAdrress()
        {
            return this.gameMapRightPos;
        }

        public uint GetGameMapBottomPosAdrress()
        {
            return this.gameMapBottomPos;
        }

        public uint GetClientWidthAddress()
        {
            return this.clientWidth;
        }

        public uint GetClientHeightAddress()
        {
            return this.clientHeight;
        }

        public uint[] GetHotkeysOffsetsAddress()
        {
            return this.hotkeyOffsets;
        }

        public uint GetUIWidgetIsVisibleAdrress()
        {
            return this.uiWidgetIsVisible;
        }
    }
}
