using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediviaBot.input
{
    class Input
    {
        public Input(int priority, InputType type)
        {
            Type = type;
            Priority = priority;
        }

        public InputType Type { get; set;}
        public int Priority { get; set; }
    }
}
