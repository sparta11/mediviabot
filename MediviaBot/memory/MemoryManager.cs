using MediviaBot.client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.memory
{
    class MemoryManager
    {
        private Client client = ClientImpl.Instance;

        private uint baseAddrss = 0;

        public uint GetBaseAddress()
        {
            if (baseAddrss == 0)          
                baseAddrss = Convert.ToUInt32(client.GetProcess().MainModule.BaseAddress.ToInt32());   
            
            return baseAddrss;
        }


        public byte[] ReadBytes(long address, uint bytesToRead)
        {
            return MemoryManagerHelper.ReadBytes(client.GetProcessHandle(), address, bytesToRead);
        }

        public byte ReadByte(long address)
        {
            return MemoryManagerHelper.ReadByte(client.GetProcessHandle(), address);
        }

        public short ReadInt16(long address)
        {
            return MemoryManagerHelper.ReadInt16(client.GetProcessHandle(), address);
        }

        public ushort ReadUInt16(long address)
        {
            return MemoryManagerHelper.ReadUInt16(client.GetProcessHandle(), address);
        }

        public int ReadInt32(long address)
        {
            return MemoryManagerHelper.ReadInt32(client.GetProcessHandle(), address);
        }

        public uint ReadUInt32(long address)
        {

            return MemoryManagerHelper.ReadUInt32(client.GetProcessHandle(), address);
        }

        public ulong ReadUInt64(long address)
        {
            return MemoryManagerHelper.ReadUInt64(client.GetProcessHandle(), address);
        }

        public double ReadDouble(long address)
        {
            return MemoryManagerHelper.ReadDouble(client.GetProcessHandle(), address);
        }

        public string ReadString(long address)
        {
            return MemoryManagerHelper.ReadString(client.GetProcessHandle(), address);
        }

        public string ReadString(long address, uint length)
        {
            return MemoryManagerHelper.ReadString(client.GetProcessHandle(), address, length);
        }

        public bool WriteBytes(long address, byte[] bytes, int length)
        {
            return MemoryManagerHelper.WriteBytes(client.GetProcessHandle(), address, bytes, length);
        }
    }
}

