using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediviaBot.input
{
    class MouseDragPressingKey : Input
    {

        public MouseDragPressingKey(Point to, Point from, Key key, int priority) : base (priority, InputType.MouseAndKeyboard)
        {
            Priority = priority;
            To = to;
            From = from;
            Key = key;
        }

        public Point To { get; set; }
        public Point From { get; set; }
        public Key Key { get; set; }

    }
}
