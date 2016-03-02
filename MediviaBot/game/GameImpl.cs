using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediviaBot.game.model;
using MediviaBot.util.item;

namespace MediviaBot.game
{
    class GameImpl : Game
    {

        protected static GameEvents events = new GameEventsImpl();
        protected static GameVariables variables = new GameVariablesImpl();
        //singleton instance
        private static GameImpl instance;

        private GameImpl() { }

        public static GameImpl Instance
        {
            get
            {
                if (instance == null)
                {
                    Console.WriteLine("|-- GameImpl: Creating GameImpl instance .... ");
                    instance = new GameImpl();
                    Console.WriteLine("|-- GameImpl: Creating GameImpl instance .... [DONE] ");
                }
                return instance;
            }
        }

        //-----------------------------------------------
        //-----------------------------------------------
        //---------------------- EVENTS -----------------
        //-----------------------------------------------
        //-----------------------------------------------    
        public void Logout()
        {
            events.Logout();
        }

        public Creature GetCreature(string name)
        {
            return events.GetCreature(name);
        }

        public Creature GetCreatureById(int id)
        {
            return events.GetCreatureById(id);
        }

        public int ItemId(string name)
        {
            return events.ItemId(name);
        }

        public string ItemName(int itemId)
        {
            return events.ItemName(itemId);
        }

        public int ItemCount(int itemId, string location = "")
        {
            return events.ItemCount(itemId, location);
        }

        public Item GetItemById(int itemId)
        {
            return events.GetItemById(itemId);
        }

        public Container GetContainer(int index)
        {
            return events.GetContainer(index);
        }

        public Container GetContainer(string containerName)
        {
            return events.GetContainer(containerName);
        }

        public List<Container> GetAllContainers()
        {
            return events.GetAllContainers();
        }

        public List<Creature> GetAllCreatures()
        {
            return events.GetAllCreatures();
        }

        public Spell GetSpell(string spellWords)
        {
            return events.GetSpell(spellWords);
        }
        public Rune GetRune(string spellName)
        {
            return events.GetRune(spellName);
        }

        public List<Item> FindItems(int itemId, string location)
        {
            return events.FindItems(itemId, location);
        }

        public Container GetContainerWithFreeSlots()
        {
            return events.GetContainerWithFreeSlots();
        }

        //-----------------------------------------------
        //-----------------------------------------------
        //-------------------- VARIABLES ----------------
        //-----------------------------------------------
        //-----------------------------------------------  
        public Creature Target()
        {
            return variables.Target();
        }

        public int Ping()
        {
            return variables.Ping();
        }

        public bool IsConnected()
        {
            return variables.IsConnected();
        }

        public ItemLocation FindItem(int itemId)
        {
            return events.FindItem(itemId);
        }

        public ItemLocationContainer FindItemOnContainers(int itemId)
        {
            return events.FindItemOnContainers(itemId);
        }

        public ItemLocationContainer FindItemOnContainers(int itemId, int containerIndex)
        {
            return events.FindItemOnContainers(itemId, containerIndex);
        }

        public ItemLocationInventory FindItemOnInventory(int itemId)
        {
            return events.FindItemOnInventory(itemId);
        }

        public List<Spell> GetAllSpells()
        {
            return events.GetAllSpells();
        }
    }
}
