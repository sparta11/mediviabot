using MediviaBot.client.gui;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.client
{
    interface Client : ClientGui
    {

        void FlashClient();
        void SetFocus();
        bool HasFocus();
        Process GetProcess();
        IntPtr GetProcessHandle();
    }
}
