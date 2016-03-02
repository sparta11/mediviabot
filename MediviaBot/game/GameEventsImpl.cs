using MediviaBot.game.model;
using MediviaBot.memory.container;
using MediviaBot.memory.creature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediviaBot.util.item;
using MediviaBot.player;
using MediviaBot.game.repository;
using MediviaBot.util;

namespace MediviaBot.game
{
    class GameEventsImpl : GameEvents
    {

        private ContainerReader containerReader = new ContainerMemoryReader();
        private CreatureReader creatureReader = new CreatureMemoryReader();
        private Player player = PlayerImpl.Instance;
        private ItemList itemList = new ItemList();
        private SpellList spellList = new SpellList();
        private RuneList runeList = new RuneList();

        public ItemLocation FindItem(int itemId)
        {
            //search on containers
            ItemLocation location = this.FindItemOnContainers(itemId);
            if (location != null)
                return location;

            //search on inventory
            return this.FindItemOnInventory(itemId);
        }

        public ItemLocationContainer FindItemOnContainers(int itemId)
        {
            return containerReader.FindItemOnContainer(itemId);
        }

        public ItemLocationContainer FindItemOnContainers(int itemId, int containerIndex)
        {
            return containerReader.FindItemOnContainer(itemId, containerIndex);
        }

        public ItemLocationInventory FindItemOnInventory(int itemId)
        {
            //search on inventory
            int first = (int)InventoryLocation.Head;
            //Console.WriteLine("First slot: " + first);
            int last = (int)InventoryLocation.Belt;
            //Console.WriteLine("Last slot: " + last);
            for (int i = first; i <= last; i++)
            {
                //Console.WriteLine("Asking for player for the item on slot: " + i);
                string slotName = ItemLocationInventory.GetInventorySlotName(i);
                Item item = player.GetEquipment(slotName);
                if (item != null)
                {
                    if (item.Id == itemId)
                        return new ItemLocationInventory(item, i, slotName);
                }
            }
            return null;
        }

        public List<Container> GetAllContainers()
        {
            return containerReader.GetAllContainers();
        }

        public Container GetContainer(string containerName)
        {
            return containerReader.GetContainerByName(containerName);
        }

        public Container GetContainer(int index)
        {
            return containerReader.GetContainerByIndex(index);
        }

        public Creature GetCreature(string name)
        {
            return creatureReader.GetCreatureByName(name);
        }

        public Creature GetCreatureById(int id)
        {
            return creatureReader.GetCreatureById(id);
        }

        public int ItemCount(int itemId, string location)
        {
            List<Item> items = this.FindItems(itemId, location);
            int count = 0;
            foreach (Item item in items)
            {
                count += item.Count;
            }
            return count;
        }

        public List<Item> FindItems(int itemId, string location)
        {

            if (ItemLocation.IsContainer(location))
            {
                return findItemsOnContainer(itemId, location);
            } 

            if (ItemLocation.IsInventory(location))
            {
                ItemLocationInventory invLocation = this.FindItemOnInventory(itemId);
                if (invLocation == null)
                    return new List<Item>();

                return new List<Item>() { invLocation.item };
            }

            //no location
            return findItemOnAllContainers(itemId);
        }

        private List<Item> findItemOnAllContainers(int itemId)
        {
            List<Item> items = new List<Item>();
            List<Container> containers = this.GetAllContainers();
            foreach (Container container in containers)
            {
                foreach (Item item in container.Items)
                {
                    if (item.Id == itemId)
                        items.Add(item);
                }
            }
            return items;
        }

        private List<Item> findItemsOnContainer(int itemId, string location)
        {
            List<Item> items = new List<Item>();
            Container c = this.GetContainer(BotUtil.Number(location));
            if (c == null)
                return items;

            foreach (Item item in c.Items)
            {
                if (item.Id == itemId)
                    items.Add(item);
            }
            return items;
        }

        public void Logout()
        {
            player.PressKey("ctrl+L");
        }

        public int ItemId(string name)
        {
            return this.itemList.ItemId(name);
        }

        public string ItemName(int itemId)
        {
            return this.ItemName(itemId);
        }

        public Item GetItemById(int itemId)
        {
            return itemList.FidItem(itemId);
        }

        public List<Creature> GetAllCreatures()
        {
            return creatureReader.GetAllCreatures();
        }

        public Spell GetSpell(string spellWords)
        {
            return this.spellList.FindSpell(spellWords, true);
        }

        public Rune GetRune(string spellName)
        {
            return runeList.FineRune(spellName);
        }

        public Container GetContainerWithFreeSlots()
        {
            List<Container> containers = this.GetAllContainers();
            foreach (Container c in containers)
            {
                if (!c.IsFull())
                    return c;
            }
            return null;
        }

        public List<Spell> GetAllSpells()
        {
            return this.spellList;
        }
    }
}
