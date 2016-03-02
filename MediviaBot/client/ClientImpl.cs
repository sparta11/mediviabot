using MediviaBot.client.gui;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MediviaBot.memory;
using MediviaBot.util;
using System.Threading;

namespace MediviaBot.client
{
    class ClientImpl : Client
    {

        //singleton instance
        private static ClientImpl instance;
        public static Process Process;
        private static IntPtr ProcessHandle;
        private static ClientGui gui;

        private ClientImpl() { }
        public static ClientImpl Instance
        {
            get
            {
                if (instance == null)
                {
                    Console.WriteLine("|-- Client: Creating Client instance .... ");
                    instance = new ClientImpl();
                    Console.WriteLine("|-- Client: Singleton insntace created .... ");
                    gui = new ClientGuiImpl();
                    Console.WriteLine("|-- ClientGuiImpl: insntace created .... ");
                }
                return instance;
            }
        }

        public Process GetProcess()
        {
            return Process;
        }

        public IntPtr GetProcessHandle()
        {
            if (ProcessHandle == IntPtr.Zero)
            {
                ProcessHandle = Process.Handle;
            }

            return ProcessHandle;
        }

        public void FlashClient()
        {
            throw new NotImplementedException();
        }

        public void SetFocus()
        {
            throw new NotImplementedException();            
        }

        public bool HasFocus()
        {
            IntPtr foregroundWindow = WindowsAPI.GetForegroundWindow();
            if (foregroundWindow == IntPtr.Zero)
                return false;

            int mediviaProcessID = ClientImpl.Process.Id;
            int activeProcId;
            WindowsAPI.GetWindowThreadProcessId(foregroundWindow, out activeProcId);
            return mediviaProcessID == activeProcId;
        }


        public Point GroundPosition(string location)
        {
            return gui.GroundPosition(location);
        }

        public Point ContainerPosition(int slot, int containerIndex)
        {
            return gui.ContainerPosition(slot, containerIndex);
        }

        public Point InventoryPosition(int slotId)
        {
            return gui.InventoryPosition(slotId);
        }

        public string GetClientHotkey(string text)
        {
            return gui.GetClientHotkey(text);
        }

        public string GetStatusMessage()
        {
            return gui.GetStatusMessage();
        }

        public Point GroundPosition(Location location)
        {
            return gui.GroundPosition(location);
        }
    }
}
