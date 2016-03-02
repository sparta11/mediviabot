using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memory.gui
{
    class StatusMessageReader : GuiMemoryReader
    {
        internal string readMessage2()
        {

            uint widget179Adr = findChildAddressByID("widget179", gameRootPanelAdr);
            uint statusLabelAdr = findChildAddressByID("statusLabel", widget179Adr);

            byte isVisible = ReadByte(statusLabelAdr + addresses.GetUIWidgetIsVisibleAdrress());
            if (isVisible == 1)
            {
                uint lockedChildrensAddr = ReadUInt32(statusLabelAdr + addresses.GetUIWidgetLockedChildrensAdrress());
                uint[] offsets = addresses.GetHotkeysOffsetsAddress();
                foreach (uint off in offsets)
                {
                    lockedChildrensAddr = ReadUInt32(lockedChildrensAddr + off);
                }
                string text = ReadString(lockedChildrensAddr);
                return text;
            }

            return "empty";
        }


        internal string readMessage()
        {
            uint widget179Adr = findChildAddressByID("widget179", gameRootPanelAdr);
            uint statusLabelAdr = findChildAddressByID("statusLabel", widget179Adr);


            byte isVisible = ReadByte(statusLabelAdr + addresses.GetUIWidgetIsVisibleAdrress());
            if (isVisible == 1)
            {
                uint lockedChildrensAddr = ReadUInt32(statusLabelAdr + addresses.GetUIWidgetLockedChildrensAdrress());

                //0x0 offset
                lockedChildrensAddr = ReadUInt32(lockedChildrensAddr);
                string text = ReadString(lockedChildrensAddr + 0x224);
                //Console.WriteLine("small text: " + text);
                if (isInvalidString(text))
                {
                    //sometimes the string is on 0x224, if the string is big then its a pointer from the string
                    lockedChildrensAddr = ReadUInt32(lockedChildrensAddr + 0x224);
                    text = ReadString(lockedChildrensAddr);
                    //Console.WriteLine("big text: " + text);

                }

                return text;
            }

            return "empty";

        }

        private bool isInvalidString(string text)
        {

            if (string.IsNullOrEmpty(text))
                return false;


            char firstChar = text[0];
            char lastChar = text[text.Length - 1];

            if (!Char.IsLetter(firstChar) || !Char.IsUpper(firstChar))
                return true;

            if (!Char.IsPunctuation(lastChar))
                return true;

            return false;
        }
    }


}
