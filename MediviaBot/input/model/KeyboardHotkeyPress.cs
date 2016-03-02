using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediviaBot.input
{

    class KeyboardHotkeyPress : Input
    {

        public KeyboardHotkeyPress(Key key1, Key key2, int priority) : base(priority, InputType.Keyboard)
        {
            Priority = Priority;
            this.key1 = key1;
            this.key2 = key2;
        }

        public Key key1 { get; set; }
        public Key key2 { get; set; }

    }


}
