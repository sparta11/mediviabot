using MediviaBot.addresses;
using MediviaBot.memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.bot
{
    class ClientChooser
    {


        protected GameAddress gameAddress = GameAddressRepository.Instance;
        private List<ClientOption> clients = new List<ClientOption>();
        internal List<ClientOption> GetAllClients()
        {

            //Console.WriteLine("|-- PreLoader: Setting process...");
            Process[] mediviaProcess = Process.GetProcessesByName("Medivia_OGL");
            clients.Clear();

            int count = 1;
            foreach (Process p in mediviaProcess)
            {
                ClientOption client = getClientChoose(p);
                if (client == null)
                    continue;
                client.Id = Convert.ToString(count);
                clients.Add(client);
                count++;
            }

            return clients;

        }

        private ClientOption getClientChoose(Process p)
        {


            try
            {
                uint baseAdr = Convert.ToUInt32(p.MainModule.BaseAddress.ToInt32());
                IntPtr handle = p.Handle;

                bool isOnline = Convert.ToBoolean(MemoryManagerHelper.ReadByte(handle, baseAdr + gameAddress.GetIsOnlineAddress()));
                string charName = "Disconnected";
                //Console.WriteLine("Name: " + MemoryReaderHelper.ReadString(handle, baseAdr + gameAddress.GetCharacterNameAddress(), 24));
                if (isOnline)
                {
                    charName = MemoryManagerHelper.ReadString(handle, baseAdr + gameAddress.GetCharacterNameAddress(), 24);
                }

                return new ClientOption("0", charName, p);
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal ClientOption GetClientOptionById(string id)
        {

            foreach (ClientOption client in clients)
            {
                if (client.Id.Equals(id))
                    return client;
            }

            return null;

        }

    }
}
