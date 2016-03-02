using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.addresses
{
    class CreatureAddressRepository : CreatureAddress
    {

        uint creatureStart = 0x00579F84;
        uint creatureListSize = 0x00579F88; //+4
        uint nextCreature = 0x0;

        uint creatureOffset = 0x0C;

        uint xPosition = 0x0C;
        uint yPosition = 0x10;
        uint zPosition = 0x14;

        uint id = 0x1C;
        uint name = 0x20;
        uint hpPercentage = 0x38;

        //uint direction = 
       
        uint baseSpeed = 0xA8;

        //singleton instance
        private static CreatureAddressRepository instance;

        private CreatureAddressRepository() { }

        public static CreatureAddressRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CreatureAddressRepository();
                }
                return instance;
            }
        }

        public uint GetCreatureStartAddress()
        {
            return this.creatureStart;
        }

        public uint GetCreatureListSizeAddress()
        {
            return this.creatureListSize;
        }

        public uint GetNextCreatureAddress()
        {
            return this.nextCreature;
        }

        public uint GetXPositionAddress()
        {
            return this.xPosition;
        }

        public uint GetYPositionAddress()
        {
            return this.yPosition;
        }

        public uint GetZPositionAddress()
        {
            return this.zPosition;
        }

        public uint GetIdAddress()
        {
            return this.id;
        }

        public uint GetNameAddress()
        {
            return this.name;
        }

        public uint GetHpPercentageAddress()
        {
            return hpPercentage;
        }

        public uint GetCreatureOffset()
        {
            return this.creatureOffset;
        }

        public uint GetBaseSpeedAddress()
        {
            return this.baseSpeed;
        }
    }
}
