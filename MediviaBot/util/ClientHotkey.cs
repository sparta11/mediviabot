using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.util
{
    class ClientHotkey
    {

        public string Text { get; private set; }
        public string Keys { get; private set; }

        public ClientHotkey(string text, string keys)
        {
            Text = text;
            Keys = keys;
        }

    }
}
