using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.memory
{
    class MemoryManagerHelper
    {

        public static byte[] ReadBytes(IntPtr handle, long address, uint bytesToRead)
        {
            IntPtr ptrBytesRead;
            byte[] buffer = new byte[bytesToRead];
            WindowsAPI.ReadProcessMemory(handle, new IntPtr(address), buffer, bytesToRead, out ptrBytesRead);
            return buffer;
        }

        public static byte ReadByte(IntPtr handle, long address)
        {
            return ReadBytes(handle, address, 1)[0];
        }


        public static short ReadInt16(IntPtr handle, long address)
        {
            return BitConverter.ToInt16(ReadBytes(handle, address, 2), 0);
        }


        public static ushort ReadUInt16(IntPtr handle, long address)
        {
            return BitConverter.ToUInt16(ReadBytes(handle, address, 2), 0);
        }

        [Obsolete("Please use ReadInt16")]
        public static short ReadShort(IntPtr handle, long address)
        {
            return BitConverter.ToInt16(ReadBytes(handle, address, 2), 0);
        }


        public static int ReadInt32(IntPtr handle, long address)
        {
            return BitConverter.ToInt32(ReadBytes(handle, address, 4), 0);
        }

        public static uint ReadUInt32(IntPtr handle, long address)
        {
            return BitConverter.ToUInt32(ReadBytes(handle, address, 4), 0);
        }

        public static ulong ReadUInt64(IntPtr handle, long address)
        {
            return BitConverter.ToUInt64(ReadBytes(handle, address, 8), 0);
        }

        public static double ReadDouble(IntPtr handle, long address)
        {
            return BitConverter.ToDouble(ReadBytes(handle, address, 8), 0);
        }

        public static string ReadString(IntPtr handle, long address)
        {
            return ReadString(handle, address, 0);
        }

        public static string ReadString(IntPtr handle, long address, uint length)
        {
            if (length > 0)
            {
                byte[] buffer;
                buffer = ReadBytes(handle, address, length);
                return System.Text.ASCIIEncoding.Default.GetString(buffer).Split(new Char())[0];
            }
            else
            {
                string s = "";
                byte temp = ReadByte(handle, address++);
                while (temp != 0)
                {
                    s += (char)temp;
                    temp = ReadByte(handle, address++);
                }
                return s;
            }
        }


        public static bool WriteBytes(IntPtr handle, long address, byte[] bytes, int length)
        {
            IntPtr bytesWritten;
            // Write from memory
            return WindowsAPI.WriteProcessMemory(handle, new IntPtr(address), bytes, length, out bytesWritten);

        }

    }
}
