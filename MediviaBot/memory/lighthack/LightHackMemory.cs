using MediviaBot.addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.memory.lighthack
{
    class LightHackMemory : MemoryManager
    {

        private PlayerAddress playerAddress = PlayerAddressRepository.Instance;
        public void TurnOn()
        {
            uint creatureAdr = ReadUInt32(GetBaseAddress() + playerAddress.GetPlayerStartAddress());
            uint torchAdr = GetBaseAddress() + 0xDF336;
            uint floorChangeAddress = GetBaseAddress() + 0xE5B76;
            byte[] opteCode = { 0x66, 0xB8, 0xFF, 0xD7 };
            WriteBytes(torchAdr, opteCode, opteCode.Length);
            WriteBytes(floorChangeAddress, opteCode, opteCode.Length);
            uint lightAddr = playerAddress.GetLightAddress() + creatureAdr;
            byte[] lightValue = { 0xFF, 0xD7 };
            WriteBytes(lightAddr, lightValue, 2);
        }



    }
}
