using MediviaBot.client;
using MediviaBot.game;
using MediviaBot.game.model;
using MediviaBot.input;
using MediviaBot.util;
using MediviaBot.util.item;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediviaBot.bot.core.mousesimulator
{
    class FromContainer 
    {

        private Client client = ClientImpl.Instance;
        private Game game = GameImpl.Instance;
        private InputSender inputSender = InputSenderImpl.Instance;

        internal void ToContainer(int itemID, string to, ItemLocationContainer containerLoc)
        {
            Container destination = game.GetContainer(Convert.ToInt32(to));
            if (destination == null)
            {
                //Console.WriteLine("moveItem: Could not found a container with index: " + to);
                return;
            }

            moveItemToContainer(containerLoc.item, containerLoc.Slot, containerLoc.ContainerIndex, destination);
        }

        internal void ToInventory(int itemID, string to, ItemLocationContainer containerLoc)
        {
            int toSlotId = ItemLocationInventory.GetInventorySlotId(to);
            if (toSlotId < 1)
            {
                //Console.WriteLine("moveItem: The inventory location: " + to + " is invalid.");
                return;
            }
            moveItemToInventory(containerLoc.item, containerLoc.Slot, containerLoc.ContainerIndex, toSlotId);
        }


        internal void ToGround(int itemID, string to, ItemLocationContainer containerLoc)
        {
            Location toGameLocation = Location.Parse(to);
            moveItemToGround(containerLoc.item, containerLoc.Slot, containerLoc.ContainerIndex, toGameLocation);
        }

        private void moveItemToContainer(Item item, int itemIndex, int containerIndex, Container destination)
        {


            Point from = client.ContainerPosition(itemIndex, containerIndex);
            int toSlot = destination.GetAvailableSlotFor(item);
            Point to = client.ContainerPosition(toSlot, destination.Index);
            //Console.WriteLine("Item count: " + item.Count);
            if (item.Count == 1)
            {
                //Console.WriteLine("Count is 1, NO CTRL:");
                inputSender.SendDragEvent(from, to);
            }
            else
            {
                //Console.WriteLine("Count is more than 1, using ctrl:");
                inputSender.SendDragEvent(from, to, true);
            }
        }

        private void moveItemToInventory(Item item, int itemIndex, int containerIndex, int toSlotId)
        {

            Point from = client.ContainerPosition(itemIndex, containerIndex);
            Point to = client.InventoryPosition(toSlotId);

            if (item.Count == 1)
            {
                //Console.WriteLine("Count is 1, NO CTRL:");
                inputSender.SendDragEvent(from, to);
            }
            else
            {
               // Console.WriteLine("Count is more than 1, using ctrl:");
                inputSender.SendDragEvent(from, to, true);
            }
        }



        private void moveItemToGround(Item item, int itemIndex, int containerIndex, Location toGameLocation)
        {
            Point from = client.ContainerPosition(itemIndex, containerIndex);
            Point to = client.GroundPosition(toGameLocation);


            if (item.Count == 1)
            {
                //Console.WriteLine("Count is 1, NO CTRL:");
                inputSender.SendDragEvent(from, to);
            }
            else
            {
                //Console.WriteLine("Count is more than 1, using ctrl:");
                inputSender.SendDragEvent(from, to, true);
            }
        }

    }
}
