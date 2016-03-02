using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.util
{

    class DirectionUtil
    {

        public static int GetIntDirection(string dir)
        {
            switch (dir)
            {
                case "n":
                    return 0;
                case "e":
                    return 1;
                case "s":
                    return 2;
                case "w":
                    return 3;
                case "ne":
                    return 4;
                case "nw":
                    return 5;
                case "se":
                    return 6;
                case "sw":
                    return 7;
                default:
                    return -1;
            }

        }

        public static Direction GetDirection(string dir)
        {
            dir = dir.ToLower();
            switch (dir)
            {
                case "n":
                    return Direction.North;
                case "e":
                    return Direction.East;
                case "s":
                    return Direction.South;
                case "w":
                    return Direction.West;
                case "ne":
                    return Direction.NorthEast;
                case "nw":
                    return Direction.NorthWest;
                case "se":
                    return Direction.SouthEast;
                case "sw":
                    return Direction.SouthWest;
                default:
                    return Direction.Invalid;

            }
        }


    }

    enum Direction
    {
        North,
        East,
        South,
        West,
        NorthEast,
        NorthWest,
        SouthEast,
        SouthWest,
        Invalid
    }
}
