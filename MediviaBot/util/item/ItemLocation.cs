using MediviaBot.game.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.util.item
{
    class ItemLocation
    {
        public ItemLocationType Type { get; private set; }
        public Item item { get; set; }

        public ItemLocation(ItemLocationType type, Item item)
        {
            Type = type;
            this.item = item;
        }

        //check if it is digit, '1', '5', or , '14'
        public static bool IsContainer(string location)
        {
            int n;
            bool isNumeric = int.TryParse(location, out n);
            if (isNumeric)
                return true;
            return false;
        }

        public static bool IsInventory(string location)
        {

            if (ItemLocationInventory.GetInventorySlotId(location) > 0)
                return true;

            return false;

        }

        public static bool IsGround(string location)
        {

            string[] split = location.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (split.Length != 3)
                return false;

            string s = split[0];
            if (!s.Trim().StartsWith("x:"))
                return false;

            string[] strs;
            int n = 0;
            bool isNumeric = false;

            strs = split[0].Split(new char[] { ':' });
            if (strs.Length != 2)
                return false;

            isNumeric = int.TryParse(strs[1], out n);
            if (!isNumeric)
                return false;

            if (n < 0 || n > 65000)
                return false;

            s = split[1];
            if (!s.Trim().StartsWith("y:"))
                return false;

            strs = split[1].Split(new char[] { ':' });
            if (strs.Length != 2)
                return false;

            isNumeric = int.TryParse(strs[1], out n);
            if (!isNumeric)
                return false;

            if (n < 0 || n > 65000)
                return false;

            s = split[2];
            if (!s.Trim().StartsWith("z:"))
                return false;

            strs = split[2].Split(new char[] { ':' });
            if (strs.Length != 2)
                return false;

            isNumeric = int.TryParse(strs[1], out n);
            if (!isNumeric)
                return false;

            if (n < 0 || n > 15)
                return false;

            return true;

        }




    }

    public enum ItemLocationType
    {
        Container,
        Inventory,
        Ground
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
        Belt = 10

    }


}
