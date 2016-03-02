using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.util
{
    public struct Rect
    {

        public int Left { get; set; }
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }

        private int width;
        private int height;

        public int Height
        {
            get
            {
                return this.Bottom - this.Top;
            }

            set
            {
                height = value;
            }
        }

        public int Width
        {
            get
            {
                return this.Right - this.Left;
            }

            set
            {
                width = value;
            }
        }

        public int ContainsPoint(Point point)
        {

            int pos = 0;
            int deltaXLeft = point.X - this.Left;
            if (deltaXLeft <= 0)
                return -2;

            int deltaXRight = point.X - this.Right;
            if (deltaXRight >= 0)
                return 2;

            int deltaYTop = point.Y - this.Top;
            if (deltaYTop <= 0)
                pos = -1;

            int deltaYBottom = point.Y - this.Bottom;
            if (deltaYBottom >= 0)
                pos = 1;

            return pos;
        }
    }
}
