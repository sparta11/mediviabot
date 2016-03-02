using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.input
{
    class MouseDrag : Input
    {

        public MouseDrag(Point to, Point from, int priority) : base (priority, InputType.Mouse)
        {
            Priority = priority;
            To = to;
            From = from;
        }

        public Point To { get; set; }
        public Point From { get; set; }
    }
}
