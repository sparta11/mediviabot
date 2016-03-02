using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.util
{
    class Hotkey
    {

        public string Id { get; private set; }
        public string Key { get; private set; }
        public HotkeyType Type { get; private set; }
        public int ItemId { get; set; }
        public string InventoryLocation { get; set; }

        public Hotkey(string id, string key, HotkeyType type)
        {
            Id = id;
            Key = key;
            Type = type;
        }

    }
}
