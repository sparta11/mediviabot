using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.game.model
{
    class Container : Item
    {
        public int Index { get; set; }
        public int Capacity { get; set; }
        public bool HasParent { get; set; }
        public bool IsClosed { get; set; }
        private List<Item> items = new List<Item>();

        public Container(string[] properties, int index, int capacity, bool hasParent, bool isClosed, Item item) : base(properties, item.Id, item.Name)
        {
            Index = index;
            Capacity = capacity;
            HasParent = hasParent;
            IsClosed = isClosed;
        }

        public int ItemCount
        {
            get
            {
                return Items.Count;
            }
        }

        public List<Item> Items
        {
            get
            {
                return items;
            }

            set
            {
                items = value;
            }
        }

        public bool IsFull()
        {
            if (Capacity == ItemCount)
                return true;

            return false;
        }

        public bool IsEmpty()
        {
            return ItemCount == 0;
        }

        public Item GetItem(int slotId)
        {
            if (slotId <= ItemCount)
                return Items[slotId];

            return null;
        }

        public int FirstIndexOf(int itemId)
        {

            int itemIndex = -1;
            for (int i = (Items.Count - 1); i >= 0; i--)
            {
                if (this.Items[i].Id == itemId)
                    return i;
            }

            return itemIndex;

        }

        public int FirstEmptySlot()
        {
            if (IsFull())
                return -1;

            return ItemCount;
        }

        internal int FirstNoContainerIndex()
        {
            int i = 0;
            for (i = 0; i < Items.Count; i++)
            {
                if (!this.Items[i].IsContainer())
                    return i;
            }
            return i++;
        }

        internal int GetAvailableSlotFor(Item item)
        {
            if (IsFull())
                return -1;

            if (IsEmpty())
                return 0;

            int slot = -1;
            if (item.IsStackable())
            {
                slot = FirstIndexOf(item.Id);
                if (slot >= 0)
                    return slot;
            }

            slot = FirstNoContainerIndex();
            if (slot >= 0)
                return slot;
            else
                return 0; //fuck it
        }

        public void PrintInfo()
        {
            Console.WriteLine("|------------------ " + Name + " ------------------|");
            Console.WriteLine("| index: " + Index);
            Console.WriteLine("| Name: " + Name);
            Console.WriteLine("| hasParent: " + HasParent);
            Console.WriteLine("| isClosed: " + IsClosed);
            Console.WriteLine("| Items: " + ItemCount);
        }
    }
}
