using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediviaBot.util;

namespace MediviaBot.bot
{
    interface Module
    {
        void Enable();
        void Disable();
        string GetSetting(string[] path);
        void SetSetting(string[] path, string value);
    }
}
