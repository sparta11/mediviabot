using core.itemuser.mover;
using MediviaBot.game;
using MediviaBot.util.item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.bot.core.mousesimulator
{
    class MouseMover
    {

        private FromContainer fromContainer = new FromContainer();
        private FromInventory fromInventory = new FromInventory();
        private FromGround fromGround = new FromGround();
        private Game game = GameImpl.Instance;

        internal void MoveItems(int itemId, string to, string from)
        {
            ItemLocationContainer locationContainer = null;
            ItemLocationInventory locationInventory = null;
            if (string.IsNullOrEmpty(from))
            {
                ItemLocation itemLocation = game.FindItem(itemId);
                if (itemLocation != null && itemLocation.GetType() == typeof(ItemLocationContainer))
                {
                    locationContainer = (ItemLocationContainer)itemLocation;
                    from = "" + locationContainer.ContainerIndex;
                }
                else if (itemLocation != null && itemLocation.GetType() == typeof(ItemLocationInventory))
                {
                    locationInventory = (ItemLocationInventory)itemLocation;
                    from = locationInventory.SlotName;
                }
                else
                {
                    Console.WriteLine("MoveItems not found item: " + itemId);
                }
            }

            //from container
            if (ItemLocation.IsContainer(from))
            {

                if (locationContainer == null)
                {
                    //Console.WriteLine("moveItem: Trying to move item: from container " + from + " to: " + to);
                    int containerIndex = ItemLocationContainer.GetContainerIndex(from);
                    if (containerIndex < 0)
                    {
                        Console.WriteLine("moveItem: Invalid container index");
                        return;
                    }
                    locationContainer = game.FindItemOnContainers(itemId, containerIndex);
                    if (locationContainer == null)
                    {
                        Console.WriteLine("moveItem: Item " + itemId + " not found on container index: " + containerIndex);
                        return;
                    }
                }


                //container to container
                if (ItemLocation.IsContainer(to))
                {
                    fromContainer.ToContainer(itemId, to, locationContainer);
                    return;
                }
                //container to inventory
                if (ItemLocation.IsInventory(to))
                {
                    fromContainer.ToInventory(itemId, to, locationContainer);
                    return;
                }
                //container to ground
                if (ItemLocation.IsGround(to))
                {
                    fromContainer.ToGround(itemId, to, locationContainer);
                    return;
                }

            }

            //from inventory
            if (ItemLocation.IsInventory(from))
            {

                //inventory to inventory
                if (ItemLocation.IsInventory(to))
                {
                    fromInventory.ToInventory(itemId, to, from);
                    return;
                }
                //inventory to container
                if (ItemLocation.IsContainer(to))
                {
                    fromInventory.ToContainer(itemId, to, from);
                    return;
                }
                //inventory to ground
                if (ItemLocation.IsGround(to))
                {
                    fromInventory.ToGround(itemId, to, from);
                    return;
                }
            }

            //from ground
            if (ItemLocation.IsGround(from))
            {
                //ground to ground
                if (ItemLocation.IsGround(to))
                {
                    fromGround.ToGround(itemId, to, from);
                    return;
                }
                //ground to container
                if (ItemLocation.IsContainer(to))
                {
                    fromGround.ToContainer(itemId, to, from);
                    return;
                }
                //ground to inventory
                if (ItemLocation.IsInventory(to))
                {
                    fromGround.ToInventory(itemId, to, from);
                    return;
                }
            }


            Console.WriteLine("Item move: Invalid location: " + from + " " + to);
        }
    }
}
