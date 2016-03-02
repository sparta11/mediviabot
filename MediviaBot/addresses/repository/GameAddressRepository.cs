using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.addresses
{
    class GameAddressRepository : GameAddress
    {

        private uint localPlayer = 0x579A68;
        private uint attackingCreature = 0x579A6C; // + 0x4
        private uint followingCreature = 0x579A70; //+ 0x4
        private uint containerStart = 0x579A78;

        private uint pingAddr = 0x579A90;
        private uint characterName = 0x579AE0;
        private uint isOnline = 0x579A88; //1byte

        //singleton instance
        private static GameAddressRepository instance;

        private GameAddressRepository() { }

        public static GameAddressRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameAddressRepository();
                }
                return instance;
            }
        }

        public uint GetLocalPlayerAddress()
        {
            return this.localPlayer;
        }

        public uint GetAttackingCreatureAddress()
        {
            return this.attackingCreature;
        }

        public uint GetFollowingCreatureAddress()
        {
            return this.followingCreature;
        }

        public uint GetContainerStartAddress()
        {
            return this.containerStart;
        }

        public uint GetPingAddress()
        {
            return this.pingAddr;
        }

        public uint GetCharacterNameAddress()
        {
            return this.characterName;
        }

        public uint GetIsOnlineAddress()
        {

            return this.isOnline;
        }
    }
}
