using MediviaBot.game.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.util.item
{
    class ItemLocationInventory : ItemLocation
    {

        public int SlotId { get; private set; }
        public string SlotName { get; private set; }
        public ItemLocationInventory(Item item, int slot, string slotName) : base(ItemLocationType.Inventory, item)
        {
            SlotId = slot;
            SlotName = slotName;
        }

        public static int GetInventorySlotId(string name)
        {

            //name = name.ToLower();
            //Console.WriteLine("GetInventorySlotId: " + name);

            if (name.Equals("head"))
                return (int) InventoryLocation.Head;
            
            if (name.Equals("neck"))         
                return (int)InventoryLocation.Neck;
            
            if (name.Equals("back") || name.Equals("backpack"))
                return (int)InventoryLocation.Back;
            
            if (name.Equals("armor"))
                return (int)InventoryLocation.Armor;
            
            if (name.Equals("rhand") || name.Equals("right hand"))
                return (int)InventoryLocation.RHand;
            
            if (name.Equals("lhand") || name.Equals("left hand"))
                return (int)InventoryLocation.LHand;
            
            if (name.Equals("legs"))
                return (int)InventoryLocation.Legs;
            
            if (name.Equals("feet") || name.Equals("boots"))
                return (int)InventoryLocation.Feet;
            
            if (name.Equals("finger") || name.Equals("ring"))
                return (int)InventoryLocation.Finger;
            
            if (name.Equals("belt") || name.Equals("arrow") || name.Equals("ammo"))
                return (int)InventoryLocation.Belt;
            
            return -1;

        }

        public static string GetInventorySlotName(int id)
        {
            int first = (int)InventoryLocation.First;
            int last = (int)InventoryLocation.Last;

            if (id < first || id > last)
                throw new InvalidOperationException("GetInventorySlotName must return a name: id is invalid: " + id);

            for (int i = first; i <= last; i++)
            {
                if (i == id)
                    return ((InventoryLocation)i).ToString().ToLower();
            }

            throw new InvalidOperationException("GetInventorySlotName must return a name");
        }

        public enum InventoryLocation
        {
            None = 0,
            Head = 1,
            Neck = 2,
            Back = 3,
            Armor = 4,
            RHand = 5,
            LHand = 6,
            Legs = 7,
            Feet = 8,
            Finger = 9,
            Belt = 10,
            First = Head,
            Last = Belt
        }

    }
}
