using MediviaBot.memory.player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediviaBot.game.model;
using MediviaBot.util;
using MediviaBot.player.timer;
using MediviaBot.util.item;

namespace MediviaBot.player
{
    class PlayerVariablesImpl : PlayerVariables
    {
        private PlayerReader playerReader = new PlayerMemoryReader();
        private StandTime standTime = new StandTime();

        public Item GetEquipment(string location)
        {
            int slotId = ItemLocationInventory.GetInventorySlotId(location);
            if (slotId < 1)
            {
                Console.WriteLine("| Inventory: location " + location + " not found");
                return null;
            }
            return playerReader.GetInventoryItem((InventoryLocation)slotId);
        }

        public int Health()
        {
            return (int)playerReader.GetHealth();
        }

        public int HealthPercent()
        {
            double health = this.Health();
            double healthMax = this.MaxHealth();
            if (health == 0 || healthMax == 0)
                return 0;
            double hpPc = (health / healthMax) * 100;
            return (int)hpPc;
        }

        public int Id()
        {
            return playerReader.GetID();
        }

        public Location Location()
        {
            return new Location(this.PosX(), this.PosY(), this.PosZ());
        }

        public int Mana()
        {
            return (int)playerReader.GetMana();
        }

        public int ManaPercent()
        {
            double mana = this.Mana();
            double maxMana = this.MaxMana();
            if (mana == 0 || maxMana == 0)
                return 0;
            double manaPerc = (mana / maxMana) * 100; 
            return (int)manaPerc;
        }

        public int MaxHealth()
        {
            return (int)playerReader.GetMaxHealth();
        }

        public int MaxMana()
        {
            return (int)playerReader.GetManaMax();
        }

        public string Name()
        {
            return playerReader.GetName();
        }

        public int PosX()
        {
            return playerReader.GetXPos();
        }

        public int PosY()
        {
            return playerReader.GetYPos();
        }

        public int PosZ()
        {
            return playerReader.GetZPos();
        }

        public long StandTime()
        {
            return standTime.GetStandTime();
        }

        public void PrintPlayerInfo()
        {
            Console.WriteLine("|------ testing player variables -------------");
            Console.WriteLine("Name: " + this.Name());
            Console.WriteLine("id: " + this.Id());
            Console.WriteLine("Health: " + this.Health());
            Console.WriteLine("MaxHealth: " + this.MaxHealth());
            Console.WriteLine("Mana : " + this.Mana());
            Console.WriteLine("MaxMana : " + this.MaxMana());
            Console.WriteLine("HealthPercent : " + this.HealthPercent());
            Console.WriteLine("ManaPercent : " + this.ManaPercent());
            Console.WriteLine("PosX : " + this.PosX());
            Console.WriteLine("PosY : " + this.PosY());
            Console.WriteLine("PosZ : " + this.PosZ());
            Console.WriteLine("Location : " + this.Location());
            Console.WriteLine("GetEquipment : " + this.GetEquipment("lhand"));
            Console.WriteLine("StandTime : " + this.StandTime());
        }

        public string Direction()
        {
            return playerReader.GetDirection();
        }
    }
}
