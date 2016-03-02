using MediviaBot.bot.core.mousesimulator;
using MediviaBot.client;
using MediviaBot.game;
using MediviaBot.game.model;
using MediviaBot.input;
using MediviaBot.player;
using MediviaBot.util;
using MediviaBot.util.item;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace core.itemuser.mover
{
    class FromInventory 
    {

        private Client client = ClientImpl.Instance;
        private Game game = GameImpl.Instance;
        private Player player = PlayerImpl.Instance;
        private InputSender inputSender = InputSenderImpl.Instance;

        internal void ToInventory(int itemID, string to, string from)
        {
            //Console.WriteLine("moveItem: Trying to move item: from Inventory " + from + " to Inventory " + to);
            Item item = null;
            int fromSlot = ItemLocationInventory.GetInventorySlotId(from);
            if (fromSlot < 0)
                return;
            else
            {
                item = player.GetEquipment(from);
                if (item == null)
                    return;
                else
                {
                    if (item.Id != itemID)
                    {
                        Console.WriteLine("ItemMove: The item id on slot: " + fromSlot + " does not match with " + itemID);
                    }
                }
            }

            int toSlot = ItemLocationInventory.GetInventorySlotId(to);
            if (toSlot < 0)
            {
                Console.WriteLine("ItemMove: Invalid slot location " + to);
                return;
            }

            moveItemToInventory(item, fromSlot, toSlot);
        }

        internal void ToContainer(int itemID, string to, string from)
        {

            //Console.WriteLine("moveItem: Trying to move item: from Inventory " + from + " to container " + to);
            Item item = null;
            int inventorySlot = ItemLocationInventory.GetInventorySlotId(from);
            if (inventorySlot < 0)
                return;
            else
            {
                item = player.GetEquipment(from);
                if (item == null)
                    return;
                else
                {
                    if (item.Id != itemID)
                    {
                        Console.WriteLine("ItemMove: The item id on slot: " + inventorySlot + " does not match with " + itemID);
                    }
                }
            }

            Container destination = game.GetContainer(Convert.ToInt32(to));
            if (destination == null)
            {
                Console.WriteLine("moveItem: Could not found a container with index: " + to);
                return;
            }

            moveItemToContainer(item, inventorySlot, destination);
        }

        internal void ToGround(int itemID, string to, string from)
        {
            //Console.WriteLine("moveItem: Trying to move item: from Inventory " + from + " to ground " + to);
            Item item = null;
            int inventorySlot = ItemLocationInventory.GetInventorySlotId(from);
            if (inventorySlot < 0)
                return;
            else
            {
                item = player.GetEquipment(from);
                if (item == null)
                    return;
                else
                {
                    if (item.Id != itemID)
                    {
                        Console.WriteLine("ItemMove: The item id on slot: " + inventorySlot + " does not match with " + itemID);
                    }
                }
            }

            Location toGameLocation = Location.Parse(to);

            moveItemToGround(item, inventorySlot, toGameLocation);
            return;
        }

        private void moveItemToInventory(Item item, int slotFrom, int slotTo)
        {
            Point from = client.InventoryPosition(slotFrom);
            Point to = client.InventoryPosition(slotTo);
            inputSender.SendDragEvent(from, to);

            if (item.Count == 1)
            {
                Console.WriteLine("Count is 1, NO CTRL:");
                inputSender.SendDragEvent(from, to);
            }
            else
            {
                Console.WriteLine("Count is more than 1, using ctrl:");
                inputSender.SendDragEvent(from, to, true);
            }
        }

        private void moveItemToContainer(Item item, int slot, Container container)
        {
            Point from = client.InventoryPosition(slot);
            int slotIndex = container.GetAvailableSlotFor(item);
            Point to = client.ContainerPosition(slotIndex, container.Index);
            if (item.Count == 1)
            {
                Console.WriteLine("Count is 1, NO CTRL:");
                inputSender.SendDragEvent(from, to);
            }
            else
            {
                Console.WriteLine("Count is more than 1, using ctrl:");
                inputSender.SendDragEvent(from, to, true);
            }
        }

        private void moveItemToGround(Item item, int inventorySlot, Location toGameLocation)
        {
            Point from = client.InventoryPosition(inventorySlot);
            Point to = client.GroundPosition(toGameLocation);
            if (item.Count == 1)
            {
                Console.WriteLine("Count is 1, NO CTRL:");
                inputSender.SendDragEvent(from, to);
            }
            else
            {
                Console.WriteLine("Count is more than 1, using ctrl:");
                inputSender.SendDragEvent(from, to, true);
            }
        }
    }
}
