using MediviaBot.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace memory.gui
{
    class HotkeyReader : GuiMemoryReader
    {

        internal List<ClientHotkey> getAllHotkeys()
        {

            uint hotkeysAddr = findChildAddressByID("currentHotkeys", hotkeysWindowAdr);
            //Console.WriteLine("currentHotkeys addres: " + Convert.ToUInt32(hotkeysAddr).ToString("X"));
            List<uint> childsAddr = findAllChildsAddress(hotkeysAddr);

            List<ClientHotkey> hotkeys = new List<ClientHotkey>();
            foreach (uint addr in childsAddr)
            {

                uint lockedChildrensAddr = ReadUInt32(addr + addresses.GetUIWidgetLockedChildrensAdrress());

                //0x0 offset
                lockedChildrensAddr = ReadUInt32(lockedChildrensAddr);
                string text = ReadString(lockedChildrensAddr + 0x224);
                if (string.IsNullOrEmpty(text) || !text.Contains(":"))
                {
                    //sometimes the string is on 0x224, if the string is big then its a pointer from the string
                    lockedChildrensAddr = ReadUInt32(lockedChildrensAddr + 0x224);
                    text = ReadString(lockedChildrensAddr);
                }

                ClientHotkey hotkey = readHotkey(text);
                if (hotkey != null)
                    hotkeys.Add(hotkey);
            }

            return hotkeys;

        }

        private ClientHotkey readHotkey(string text)
        {

            try
            {
                string[] tokens = text.Split(':');

                if (tokens.Length < 2)
                    return null;

                string hotkeyText = getHotkeyText(tokens[1]);
                return new ClientHotkey(hotkeyText, tokens[0]);
            }
            catch (Exception)
            {
                Console.WriteLine("Error on readHotkey");
                return null;
            }

        }

        private string getHotkeyText(string text)
        {
            text = text.ToLower().Trim();
            return text;
        }

        //private List<Key> getHotkeys(string text)
        //{

        //    string[] tokens = text.Split('+');

        //    List<Key> keys = new List<Key>();
        //    foreach (string s in tokens)
        //    {


        //        KeyConverter k = new KeyConverter();
        //        Key key = (Key)k.ConvertFromString(s.Trim());
        //        keys.Add(key);
        //    }

        //    return keys;

        //}


    }
}
