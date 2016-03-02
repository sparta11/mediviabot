using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.addresses
{
    class PlayerAddressRepository : PlayerAddress
    {

        private uint playerStart = 0x579A68;

        private uint xPos = 0x0C;
        private uint yPos = 0x10;
        private uint zPos = 0x14;

        private uint id = 0x1C;
        private uint name = 0x20;
        private uint direction = 0x3C;
       // private uint hpPercent = 0x38;
        private uint health = 0x328;
        private uint maxHealth = 0x330;
        private uint capacity = 0x338;

        private uint mana = 0x360;
        private uint maxMana = 0x368;

        private uint lightAddress = 0xA4;

        private uint inventoryHelmet = 0x274;
        private uint inventoryNeck = 0x278;
        private uint inventoryBack = 0x27C;
        private uint inventoryArmor = 0x280;
        private uint inventoryRightHand = 0x284;
        private uint inventoryLeftHand = 0x288;
        private uint inventoryLegs = 0x28C;
        private uint inventoryFeet = 0x290;
        private uint inventoryRing = 0x294;
        private uint inventoryBelt = 0x298;


        //singleton instance
        private static PlayerAddressRepository instance;

        private PlayerAddressRepository() { }

        public static PlayerAddressRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlayerAddressRepository();
                }
                return instance;
            }
        }


        public uint GetPlayerStartAddress()
        {
            return this.playerStart;
        }

        public uint GetXPosAddress()
        {
            return this.xPos;
        }

        public uint GetYPosAddress()
        {
            return this.yPos;
        }

        public uint GetZPosAddress()
        {
            return this.zPos;
        }

        public uint GetIdAddress()
        {
            return this.id;
        }

        public uint GetNameAddress()
        {
            return this.name;
        }

        public uint GetHealthAddress()
        {
            return this.health;
        }

        public uint GetMaxHealthAddress()
        {
            return this.maxHealth;
        }

        public uint GetCapacityAddress()
        {
            return this.capacity;
        }

        public uint GetManaAddress()
        {
            return this.mana;
        }

        public uint GetMaxManaAddress()
        {
            return this.maxMana;
        }

        public uint GetInventoryHelmetAddress()
        {
            return this.inventoryHelmet;
        }

        public uint GetInventoryNeckAddress()
        {
            return this.inventoryNeck;
        }

        public uint GetInventoryBackAddress()
        {
            return this.inventoryBack;
        }

        public uint GetInventoryArmorAddress()
        {
            return this.inventoryArmor;
        }

        public uint GetInventoryRightHandAddress()
        {
            return this.inventoryRightHand;
        }

        public uint GetInventoryLeftHandAddress()
        {
            return this.inventoryLeftHand;
        }

        public uint GetInventoryLegsAddress()
        {
            return this.inventoryLegs;
        }

        public uint GetInventoryFeetAddress()
        {
            return this.inventoryFeet;
        }

        public uint GetInventoryRingAddress()
        {
            return this.inventoryRing;
        }

        public uint GetInventoryBeltAddress()
        {
            return this.inventoryBelt;
        }

        public uint GetLightAddress()
        {
            return this.lightAddress;
        }

        public uint GetDirectionAddress()
        {
            return this.direction;
        }
    }
}
//private:
//    // walk related
//    Position m_lastPrewalkDestination;
//Position m_autoWalkDestination;
//Position m_lastAutoWalkPosition;
//ScheduledEventPtr m_serverWalkEndEvent;
//ScheduledEventPtr m_autoWalkContinueEvent;
//ticks_t m_walkLockExpiration;
//stdext::boolean<false> m_preWalking;
//stdext::boolean<true> m_lastPrewalkDone;
//stdext::boolean<false> m_secondPreWalk;
//stdext::boolean<false> m_serverWalking;
//stdext::boolean<false> m_knownCompletePath;

//stdext::boolean<false> m_premium;
//stdext::boolean<false> m_known;
//stdext::boolean<false> m_pending;

//ItemPtr m_inventoryItems[Otc::LastInventorySlot];
//Timer m_idleTimer;

//std::array<int, Otc::LastSkill> m_skillsLevel;
//std::array<int, Otc::LastSkill> m_skillsBaseLevel;
//std::array<int, Otc::LastSkill> m_skillsLevelPercent;
//std::vector<int> m_spells;

//int m_states;
//int m_vocation;
//int m_blessings;

//double m_health;
//double m_maxHealth;
//double m_freeCapacity;
//double m_totalCapacity;
//double m_experience;
//double m_level;
//double m_levelPercent;
//double m_mana;
//double m_maxMana;
//double m_magicLevel;
//double m_magicLevelPercent;
//double m_baseMagicLevel;
//double m_soul;
//double m_stamina;
//double m_regenerationTime;
//double m_offlineTrainingTime;
//};
