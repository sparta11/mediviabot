using MediviaBot.addresses;
using MediviaBot.game.model;
using MediviaBot.memory.creature;
using MediviaBot.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MediviaBot.memory.game
{
    class GameMemoryReader : MemoryManager, GameReader
    {
        protected GameAddress address = GameAddressRepository.Instance;
        protected CreatureAddress creatureAdresss = CreatureAddressRepository.Instance;
        protected CreatureReader creatureReader = new CreatureMemoryReader();

        public Creature GetAttackingCreature()
        {
            return creatureReader.ReadCreature(GetBaseAddress() + address.GetAttackingCreatureAddress());
        }

        public Location GetAttackingCreatureLocation()
        {
            uint attackingCreatureAdr = ReadUInt32(GetBaseAddress() + address.GetAttackingCreatureAddress());
            int xPos = ReadInt32(attackingCreatureAdr + creatureAdresss.GetXPositionAddress());
            int yPos = ReadInt32(attackingCreatureAdr + creatureAdresss.GetYPositionAddress());
            int zPos = ReadInt16(attackingCreatureAdr + creatureAdresss.GetZPositionAddress());

            if (xPos > 60000 || yPos > 60000 || zPos > 20)
                return new Location(-1, -1, -1);

            return new Location(xPos, yPos, zPos);

        }

        public Creature GetFollowingCreature()
        {
            return creatureReader.ReadCreature(address.GetFollowingCreatureAddress());
        }

        public bool GetIsOnline()
        {
            byte isOnline = ReadByte(GetBaseAddress() + address.GetIsOnlineAddress());
            return Convert.ToBoolean(isOnline);
        }

        public int GetPing()
        {
            uint ping = ReadUInt16(GetBaseAddress() + address.GetPingAddress());

            if (ping > 5000)
            {
                return 500;
            }
            return (int)ping;
        }

    }
}
