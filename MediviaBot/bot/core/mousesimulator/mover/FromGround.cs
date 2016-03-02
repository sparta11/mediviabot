using MediviaBot.bot.core.mousesimulator;
using MediviaBot.client;
using MediviaBot.game;
using MediviaBot.input;
using MediviaBot.util;
using MediviaBot.util.item;
using System;
using System.Drawing;
using System.Windows.Input;

namespace core.itemuser.mover
{
    class FromGround 
    {
        private Client client = ClientImpl.Instance;
        private MediviaBot.game.Game game = GameImpl.Instance;
        private InputSender inputSender = InputSenderImpl.Instance;

        internal void ToContainer(int itemID, string to, string from)
        {
            //Console.WriteLine("moveItem: Trying to move item: from ground " + from + " to container " + to);
            Location fromGameLocation = Location.Parse(from);

            int containerIndex = ItemLocationContainer.GetContainerIndex(to);
            if (containerIndex < 0)
            {
                Console.WriteLine("moveItem: Invalid container index");
                return;
            }

            //should check the item id on ground
            //if ground item.id == itemID

            moveItemToContainer(fromGameLocation, containerIndex);
        }

        internal void ToInventory(int itemID, string to, string from)
        {
            //Console.WriteLine("moveItem: Trying to move item: from ground " + from + " to inventory " + to);
            Location fromGameLocation = Location.Parse(from);

            int inventorySlot = ItemLocationInventory.GetInventorySlotId(to);
            if (inventorySlot < 0)
            {
                Console.WriteLine("moveItem: Invalid inventory slot: " + inventorySlot);
                return;
            }

            //should check the item id on ground
            //if ground item.id == itemID

            moveItemToInventory(fromGameLocation, inventorySlot);
        }



        internal void ToGround(int itemID, string to, string from)
        {
            //Console.WriteLine("moveItem: Trying to move item: from ground " + from + " to ground " + to);
            Location fromGameLocation = Location.Parse(from);

            Location toGameLocation = Location.Parse(to);

            //should check the item id on ground
            //if ground item.id == itemID
            moveItemToGround(fromGameLocation, toGameLocation);
        }

        private void moveItemToContainer(Location gameLocation, int containerIndex)
        {
            Point from = client.GroundPosition(gameLocation);
            Point to = client.ContainerPosition(0, containerIndex);
            inputSender.SendDragEvent(from, to, true);

        }

        private void moveItemToInventory(Location fromGameLocation, int inventorySlot)
        {
            Point from = client.GroundPosition(fromGameLocation);
            Point to = client.InventoryPosition(inventorySlot);
            inputSender.SendDragEvent(from, to, true);

        }

        private void moveItemToGround(Location fromGameLocation, Location toGameLocation)
        {
            Point from = client.GroundPosition(toGameLocation);
            Point to = client.GroundPosition(toGameLocation);
            inputSender.SendDragEvent(from, to, true);
        }

    }
}
