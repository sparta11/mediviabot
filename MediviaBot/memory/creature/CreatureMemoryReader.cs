using MediviaBot.addresses;
using MediviaBot.game.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MediviaBot.memory.creature
{
    class CreatureMemoryReader : MemoryManager, CreatureReader
    {

        protected StructureHelper structHelper = new StructureHelper();
        protected CreatureAddress addresses = CreatureAddressRepository.Instance;

        protected uint creatureStartAdr = 0;
        public CreatureMemoryReader()
        {
            creatureStartAdr = ReadUInt32(GetBaseAddress() + addresses.GetCreatureStartAddress());
        }

        public Creature GetCreatureByName(string name)
        {

            int creatureListSize = ReadInt32(GetBaseAddress() + addresses.GetCreatureListSizeAddress());
            uint nextCreature = addresses.GetNextCreatureAddress();
            uint indexCreatAdr = creatureStartAdr;
            for (int i = 0; i < creatureListSize; i++)
            {
                indexCreatAdr = ReadUInt32(indexCreatAdr + nextCreature);
                //Console.WriteLine("indexCreatAdr: " + Convert.ToInt32(indexCreatAdr).ToString("X"));
                uint creatureAddress = indexCreatAdr + addresses.GetCreatureOffset();
                Creature c = ReadCreature(creatureAddress);
                if (c != null)
                {
                    if (c.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                        return c;
                }

            }
            return null;

        }

        public Creature GetCreatureById(int creatureId)
        {
            int creatureListSize = ReadInt32(GetBaseAddress() + addresses.GetCreatureListSizeAddress());
            uint nextCreature = addresses.GetNextCreatureAddress();
            uint indexCreatAdr = creatureStartAdr;
            for (int i = 0; i < creatureListSize; i++)
            {
                indexCreatAdr = ReadUInt32(indexCreatAdr + nextCreature);
                //Console.WriteLine("indexCreatAdr: " + Convert.ToInt32(indexCreatAdr).ToString("X"));
                uint creatureAddress = indexCreatAdr + addresses.GetCreatureOffset();
                Creature c = ReadCreature(creatureAddress);
                if (c != null)
                {
                    if (c.Id == creatureId)
                        return c;
                }
                    
            }
            return null;
        }

        public List<Creature> GetAllCreatures()
        {
            
            int creatureListSize = ReadInt32(GetBaseAddress() + addresses.GetCreatureListSizeAddress());
            uint nextCreature = addresses.GetNextCreatureAddress();

            List<Creature> creatures = new List<Creature>();
            uint indexCreatAdr = creatureStartAdr;
            for (int i = 0; i < creatureListSize; i++)
            {
                indexCreatAdr = ReadUInt32(indexCreatAdr + nextCreature);
                //Console.WriteLine("indexCreatAdr: " + Convert.ToInt32(indexCreatAdr).ToString("X"));
                uint creatureAddress = indexCreatAdr + addresses.GetCreatureOffset();
                Creature c = this.ReadCreature(creatureAddress);
                if (c != null)
                    creatures.Add(c);
            }
            return creatures;
        }

        public Creature ReadCreature(uint creatureAdr)
        {
            //Console.WriteLine("Creature addr: " + Convert.ToUInt32(creatureAdr).ToString("X"));
            creatureAdr = ReadUInt32(creatureAdr);
            int xPos = ReadInt32(creatureAdr + addresses.GetXPositionAddress());
            int yPos = ReadInt32(creatureAdr + addresses.GetYPositionAddress());
            int zPos = ReadInt16(creatureAdr + addresses.GetZPositionAddress());
            int speed = ReadInt32(creatureAdr + addresses.GetBaseSpeedAddress());
            if (xPos > 60000 || yPos > 60000 || zPos > 20)
                return null;

            int id = ReadInt32(creatureAdr + addresses.GetIdAddress());
            string name = ReadString(creatureAdr + addresses.GetNameAddress());
            int hpPc = ReadByte(creatureAdr + addresses.GetHpPercentageAddress());

            if (string.IsNullOrEmpty(name))
                return null;

            Creature creature = new Creature(id, name, xPos, yPos, zPos, hpPc);
            creature.Speed = speed;
            return creature;
        }
    }
}
