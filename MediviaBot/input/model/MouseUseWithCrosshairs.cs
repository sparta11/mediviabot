using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.input
{
    class MouseUseWithCrosshairs : Input
    {

        public MouseUseWithCrosshairs(Point point, int priority) : base (priority, InputType.Mouse)
        {
            Priority = priority;
            Point = point;
        }

        public Point Point { get; set; }

    }
}
