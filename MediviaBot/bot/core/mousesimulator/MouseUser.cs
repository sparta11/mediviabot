using MediviaBot.client;
using MediviaBot.game;
using MediviaBot.input;
using MediviaBot.util.item;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediviaBot.util;

namespace MediviaBot.bot.core.mousesimulator
{
    class MouseUser
    {

        private Client client = ClientImpl.Instance;
        private Game game = GameImpl.Instance;
        private InputSender inputSender = InputSenderImpl.Instance;

        internal void UseItem(int itemId, int containerIndex)
        {
            ItemLocationContainer itemLocation = game.FindItemOnContainers(itemId, containerIndex);
            if (itemLocation == null)
                return;
            Point point = client.ContainerPosition(itemLocation.Slot, itemLocation.ContainerIndex);
            inputSender.SendRightClick(point);
        }

        internal void LeftClick(Location location, bool ctrl, bool shift, bool alt)
        {
            Point point = client.GroundPosition(location);
            inputSender.SendLeftClick(point, ctrl, shift, alt);
        }

        internal void RightClick(Location location, bool ctrl, bool shift, bool alt)
        {
            Point point = client.GroundPosition(location);
            inputSender.SendRightClick(point, ctrl, shift, alt);
        }

        internal void UseItem(int itemId, string location)
        {
            Console.WriteLine("Using item: " + itemId + " ignoring the location....");
            Point point = findPointOfItem(itemId);
            if (point.X <= 0)
                return;

            inputSender.SendRightClick(point);
        }

        internal void UseItemOn(int itemId, string location)
        {
            this.UseItemOn(itemId, Location.Parse(location));
        }

        internal void UseItemOn(int itemId, Location location)
        {
            ItemLocationContainer itemLocation = game.FindItemOnContainers(itemId);

            if (itemLocation == null)
            {
                Console.WriteLine("Item " + itemId + " was not found on any containers.");
                return;
            }

            Point slotPoint = client.ContainerPosition(itemLocation.Slot, itemLocation.ContainerIndex);
            Point mapPoint = client.GroundPosition(location);
            if (slotPoint.X < 0 || mapPoint.X < 0)
                Console.WriteLine("Itemd id: " + itemId + " on location: " + location.ToString() + " not found");


            if (mapPoint.X < 0)
                Console.WriteLine("Game location: " + location.ToString() + " not found");

            inputSender.SendUseOnEvent(slotPoint, mapPoint);
        }

        private Point findPointOfItem(int itemID)
        {

            ItemLocation itemLocation = game.FindItem(itemID);
            if (itemLocation == null)
                return new Point(-1, -1);

            if (itemLocation.GetType() == typeof(ItemLocationContainer))
            {
                ItemLocationContainer containerLoc = (ItemLocationContainer)itemLocation;
                return client.ContainerPosition(containerLoc.Slot, containerLoc.ContainerIndex);
            }
            if (itemLocation.GetType() == typeof(ItemLocationInventory))
            {
                ItemLocationInventory inventoryLoc = (ItemLocationInventory)itemLocation;
                return client.InventoryPosition(inventoryLoc.SlotId);
            }
            return new Point(-1, -1);

        }
    }
}
