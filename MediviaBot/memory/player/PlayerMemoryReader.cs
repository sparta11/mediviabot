using MediviaBot.addresses;
using MediviaBot.game.model;
using MediviaBot.memory.item;
using MediviaBot.util;
using MediviaBot.util.item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace MediviaBot.memory.player
{
    class PlayerMemoryReader : MemoryManager, PlayerReader
    {

        protected PlayerAddress address = PlayerAddressRepository.Instance;
        protected ItemReader itemReader = new ItemMemoryReader();



        private uint getPlayerStartAddres()
        {
            return ReadUInt32(GetBaseAddress() + address.GetPlayerStartAddress());
        }

        public int GetCapacity()
        {
            return (int)ReadDouble(getPlayerStartAddres() + address.GetCapacityAddress());
        }

        public double GetHealth()
        {
            return ReadDouble(getPlayerStartAddres() + address.GetHealthAddress());
        }

        public int GetID()
        {
            return ReadInt32(getPlayerStartAddres() + address.GetIdAddress());
        }

        public int GetXPos()
        {
            return ReadInt32(getPlayerStartAddres() + address.GetXPosAddress());
        }

        public int GetYPos()
        {
            return ReadInt32(getPlayerStartAddres() + address.GetYPosAddress());
        }

        public int GetZPos()
        {
            return ReadInt16(getPlayerStartAddres() + address.GetZPosAddress());
        }

        public double GetMana()
        {

            return ReadDouble(getPlayerStartAddres() + address.GetManaAddress());
        }

        public double GetManaMax()
        {
            return ReadDouble(getPlayerStartAddres() + address.GetMaxManaAddress());
        }

        public double GetMaxHealth()
        {
            return ReadDouble(getPlayerStartAddres() + address.GetMaxHealthAddress());
        }

        public string GetName()
        {
            return ReadString(getPlayerStartAddres() + address.GetNameAddress());
        }

        public string GetDirection()
        {
            byte dir = ReadByte(getPlayerStartAddres() + address.GetDirectionAddress());
            if (dir >= 0 && dir <= 3)
            {
                switch (dir)
                {
                    case 0:
                        return "n";
                    case 1:
                        return "e";
                    case 2:
                        return "s";
                    case 3:
                        return "w";
                }
            }

            return "invalid";
        }

        public Item GetInventoryItem(InventoryLocation inventory)
        {

            uint itemAdr = 0;
            switch (inventory)
            {
                case InventoryLocation.Head:
                    itemAdr = ReadUInt32(getPlayerStartAddres() + address.GetInventoryHelmetAddress());
                    return readItem(itemAdr);
                case InventoryLocation.Neck:
                    itemAdr = ReadUInt32(getPlayerStartAddres() + address.GetInventoryNeckAddress());
                    return readItem(itemAdr);

                case InventoryLocation.Back:
                    itemAdr = ReadUInt32(getPlayerStartAddres() + address.GetInventoryBackAddress());
                    return readItem(itemAdr);

                case InventoryLocation.Armor:
                    itemAdr = ReadUInt32(getPlayerStartAddres() + address.GetInventoryArmorAddress());
                    return readItem(itemAdr);

                case InventoryLocation.RHand:
                    itemAdr = ReadUInt32(getPlayerStartAddres() + address.GetInventoryRightHandAddress());
                    return readItem(itemAdr);

                case InventoryLocation.LHand:
                    itemAdr = ReadUInt32(getPlayerStartAddres() + address.GetInventoryLeftHandAddress());
                    return readItem(itemAdr);

                case InventoryLocation.Finger:
                    itemAdr = ReadUInt32(getPlayerStartAddres() + address.GetInventoryRingAddress());
                    return readItem(itemAdr);

                case InventoryLocation.Legs:
                    itemAdr = ReadUInt32(getPlayerStartAddres() + address.GetInventoryLegsAddress());
                    return readItem(itemAdr);

                case InventoryLocation.Belt:
                    itemAdr = ReadUInt32(getPlayerStartAddres() + address.GetInventoryBeltAddress());
                    return readItem(itemAdr);

                case InventoryLocation.Feet:
                    itemAdr = ReadUInt32(getPlayerStartAddres() + address.GetInventoryFeetAddress());
                    return readItem(itemAdr);

                default:
                    throw new ArgumentException("Invalid inventory location: " + inventory);

            }
        }

        private Item readItem(uint itemAdr)
        {
            Item item = itemReader.ReadItem(itemAdr);
            return item;
        }
    }
}
