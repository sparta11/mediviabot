using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediviaBot.game.model;
using MediviaBot.util;

namespace MediviaBot.player
{
    class PlayerImpl : Player
    {

        private static PlayerEvents events = new PlayerEventsImpl();
        private static PlayerVariables variables = new PlayerVariablesImpl();

        //singleton instance
        private static PlayerImpl instance;
        private PlayerImpl() { }
        public static PlayerImpl Instance
        {
            get
            {
                if (instance == null)
                {
                    Console.WriteLine("|-- GameImpl: Creating PlayerImpl instance .... ");
                    instance = new PlayerImpl();
                    Console.WriteLine("|-- GameImpl: Creating PlayerImpl instance .... [DONE] ");
                }
                return instance;
            }
        }


        //-----------------------------------------------
        //-----------------------------------------------
        //---------------------- EVENTS -----------------
        //-----------------------------------------------
        //-----------------------------------------------  
        public void Cast(string words)
        {
            events.Cast(words);
        }

        public bool CanCast()
        {
            return events.CanCast();
        }

        public void Move(string direction)
        {
            events.Move(direction);
        }

        public void MoveTo(int x, int y, int z)
        {
            events.MoveTo(x, y, z);
        }

        public void Say(string text)
        {
            events.Say(text);
        }

        public void Turn(string direction)
        {
            events.Turn(direction);
        }

        public void EatFood()
        {
            events.EatFood();
        }

        public void Attack(int creatureId)
        {
            events.Attack(creatureId);
        }

        public void Attack(Creature creature)
        {
            events.Attack(creature);
        }

        public void Attack(string creatureName)
        {
            events.Attack(creatureName);
        }

        public void MoveItems(string name, string to, string from = "")
        {
            events.MoveItems(name, to, from);
        }

        public void MoveItems(int itemId, string to, string from = "")
        {
            events.MoveItems(itemId, to, from);
        }

        public void UseItem(int itemId, string location = "")
        {
            events.UseItem(itemId, location);
        }

        public void UseItem(int itemId, int containerIndex)
        {
            events.UseItem(itemId, containerIndex);
        }

        public void UseItem(string itemName, string location = "")
        {
            events.UseItem(itemName, location);
        }

        public void UseItem(string itemName, int containerIndex)
        {
            events.UseItem(itemName, containerIndex);
        }

        public void useItemWithCrossHairs(int itemId)
        {
            events.useItemWithCrossHairs(itemId);
        }

        public void UseItemOn(int itemId, string location)
        {
            events.UseItemOn(itemId, location);
        }

        public void UseItemOn(int itemId, Location location)
        {
            events.UseItemOn(itemId, location);
        }

        public void PressKey(string key)
        {
            events.PressKey(key);
        }
        //-----------------------------------------------
        //-----------------------------------------------
        //------------------- Variables -----------------
        //-----------------------------------------------
        //-----------------------------------------------  
        public int Id()
        {
            return variables.Id();
        }

        public int Health()
        {
            return variables.Health();
        }

        public int MaxHealth()
        {
            return variables.MaxHealth();
        }

        public int Mana()
        {
            return variables.Mana();
        }

        public int MaxMana()
        {
            return variables.MaxMana();
        }

        public int HealthPercent()
        {
            return variables.HealthPercent();
        }

        public int ManaPercent()
        {
            return variables.ManaPercent();
        }

        public string Name()
        {
            return variables.Name();
        }

        public int PosX()
        {
            return variables.PosX();
        }

        public int PosY()
        {
            return variables.PosY();
        }

        public int PosZ()
        {
            return variables.PosZ();
        }

        public Location Location()
        {
            return variables.Location();
        }

        public Item GetEquipment(string slot)
        {
            return variables.GetEquipment(slot);
        }

        public long StandTime()
        {
            return variables.StandTime();
        }

        public void PrintPlayerInfo()
        {
            variables.PrintPlayerInfo();
        }

        public string Direction()
        {
            return variables.Direction();
        }
    }
}
