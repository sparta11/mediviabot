using MediviaBot.game.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.util.item
{
    class ItemLocationContainer  : ItemLocation
    {

        public int ContainerIndex { get; set; }
        public int Slot { get; set; }

        public ItemLocationContainer(Item item, int containerIndex, int slot) : base(ItemLocationType.Container, item)
        {
            ContainerIndex = containerIndex;
            Slot = slot;
        }

        internal static int GetContainerIndex(string location)
        {
            try
            {
                int indexInt = Convert.ToInt32(location);
                if (indexInt < 0 || indexInt > 50)
                    throw new Exception();
                else
                    return indexInt;
            }
            catch (Exception)
            {
                Console.WriteLine("Error from parse the string " + location + " from container index (int).");
                return -1;
            }



        }
    }
}
