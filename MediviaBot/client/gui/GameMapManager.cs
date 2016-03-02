using MediviaBot.memory.gui;
using MediviaBot.player;
using MediviaBot.util;
using memory.gui;
using System;
using System.Drawing;

namespace MediviaBot.client.gui
{
    internal class GameMapManager
    {

        private GuiReader guiReader = new GuiMemoryReader();
        private Player player = PlayerImpl.Instance;
        private const int xCenter = 8;
        private const int yCenter = 6;


        public Point GetGroundPosition(Location location)
        {
            Rect gameMapRect = guiReader.GetGameMapRect();
            Location center = player.Location();
            int xDif = location.X - center.X;
            int yDif = location.Y - center.Y;

            if (isOutOFRange(xDif, yDif, location.Z, center.Z))
                return (new Point(-1, -1));

            Rect sqm = getSqmRect(xDif, yDif, gameMapRect);
            Rect sqmClient = convertRelativeToClient(sqm, gameMapRect);
            return ClientGuiHelper.GetRandomCenterPos(sqmClient);
        }

        public Point GetGroundPosition(string location)
        {
            Location gameLocation = Location.Parse(location);
            return this.GetGroundPosition(gameLocation);
        }

        private bool isOutOFRange(int xDif, int yDif, int locationZ, int centerZ)
        {
            if (locationZ != centerZ)
            {
                Console.WriteLine("gameLocation.Z != center.Z");
                return true;
            }

            if (xDif > 7 || xDif < -7 || yDif > 5 || yDif < -5)
            {
                Console.WriteLine("isOutOFRange: xDif > 7 || xDif < -7 || yDif > 5 || yDif < -5");
                return true;
            }
            return false;
        }

        private Rect getSqmRect(int xDif, int yDif, Rect gameMapRect)
        {

            int numCols = 11;
            int numRows = 15;

            int sqmWidth = ClientGuiHelper.calculateSqmWidth(gameMapRect, numCols, numRows);

            //Console.WriteLine("SQM width: " + sqmWidth);

            Rect[,] map = new Rect[numRows, numCols];
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    Rect r = new Rect();
                    r.Left = i * sqmWidth;
                    r.Top = j * sqmWidth;
                    r.Right = r.Left + sqmWidth;
                    r.Bottom = r.Top + sqmWidth;
                    map[i, j] = r;
                }
            }

            int posX = xCenter + xDif;
            int posY = yCenter + yDif;

            Rect sqm = map[posX - 1, posY - 1];
            return sqm;
        }

        private Rect convertRelativeToClient(Rect sqm, Rect gameMap)
        {
            Rect sqmClient = new Rect();
            sqmClient.Left = sqm.Left + gameMap.Left;
            sqmClient.Top = sqm.Top + gameMap.Top;
            sqmClient.Right = sqm.Right + gameMap.Left;
            sqmClient.Bottom = sqm.Bottom + gameMap.Top;
            return sqmClient;
        }

    }
}