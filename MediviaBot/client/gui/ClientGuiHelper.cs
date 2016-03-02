using MediviaBot.util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.client.gui
{
    class ClientGuiHelper
    {

        private static Random rnd = new Random();
        public static Point GetRandomCenterPos(Rect rect)
        {
            Point p = getCenterPos(rect);
            Point point = new Point();
            point.X = p.X + (rnd.Next(0, 5));
            point.Y = p.Y + (rnd.Next(0, 5));
            return point;
        }

        public static int calculateSqmWidth(Rect gameMap, int numRows, int numCols)
        {
            int gameMapArea = gameMap.Width * gameMap.Height;
            int numberSquares = numRows * numCols;
            int sqmArea = gameMapArea / numberSquares;
            int sqmWidth = (int)Math.Sqrt(sqmArea);
            return sqmWidth;
        }

        public static Point getCenterPos(Rect rect)
        {
            return new Point(rect.Left + rect.Width / 2,
                             rect.Top + rect.Height / 2);
        }
    }
}
