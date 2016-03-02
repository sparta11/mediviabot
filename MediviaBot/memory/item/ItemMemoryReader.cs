using MediviaBot.game;
using MediviaBot.game.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MediviaBot.memory.item
{
    class ItemMemoryReader : MemoryManager , ItemReader
    {

        protected const uint idAdr = 0x1a;
        protected const uint countAdr = 0x1e;
        private Game game = GameImpl.Instance;

        public Item ReadItem(uint itemAddr)
        {
            if (itemAddr == 0)
                return null;

            int itemId = ReadUInt16(itemAddr + idAdr);
            int itemCount = ReadByte(itemAddr + countAdr);

            Item i = game.GetItemById(itemId);
            if (i != null)
            {
                i.Count = itemCount;
                return i;
            }

            Item item = new Item(new string[] { "" }, itemId, null);
            item.Count = itemCount;       
            return item;
        }

    }
}
