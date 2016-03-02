using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.bot
{
    class ClientOption
    {
        public ClientOption(string id, string charName, Process process)
        {
            Id = id;
            CharName = charName;
            Process = process;
        }

        public string Id { get; set; }
        public string CharName { get; set; }
        public Process Process { get; set; }
    }
}
