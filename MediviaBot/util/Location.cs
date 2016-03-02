using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.util
{

    public struct Location
    {
        /// <summary>
        /// Get an invalid instance of this struct. Used for function overloading.
        /// </summary>
        /// <returns></returns>
        public static Location Invalid = new Location(-1, -1, -1);

        public int X, Y, Z;

        /// <summary>
        /// Create a new location given the coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Location(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override int GetHashCode()
        {
            if (this.Equals(Invalid))
                return (-1).GetHashCode();
            ushort shortX = (ushort)X;
            ushort shortY = (ushort)Y;
            byte byteZ = (byte)Z;
            return ((shortX << 3) + (shortY << 1) + byteZ).GetHashCode();
        }

        /// <summary>
        /// Convert the location from bytes from be placed into a packet.
        /// </summary>
        /// <returns>A byte array of length 5 containing the coordinates.</returns>
        public byte[] ToBytes()
        {
            byte[] bytes = new byte[5];
            Array.Copy(BitConverter.GetBytes((ushort)X), 0, bytes, 0, 2);
            Array.Copy(BitConverter.GetBytes((ushort)Y), 0, bytes, 2, 2);
            bytes[4] = (byte)Z;

            return bytes;
        }

        /// <summary>
        /// Checks if this struct is valid (all coordinates non-negative).
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return X >= 0 && Y >= 0 && Z >= 0;
        }

        /// <summary>
        /// Returns true of the provided location is adjacent from (touching)
        /// this location.
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public bool IsAdjacentTo(Location loc)
        {

            return loc.Z == Z && Math.Max(Math.Abs(X - loc.X), Math.Abs(Y - loc.Y)) <= 1;
        }

        /// <summary>
        /// Returns the string representation of this struct.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return "x:" + X + ", y:" + Y + ", z:" + Z;
            //return string.Format("({0}, {1}, {2})", X, Y, Z);
        }

        /// <summary>
        /// Gets the distance between locations. Ignores Z.
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public double DistanceTo(Location l)
        {
            int xDist = X - l.X;
            int yDist = Y - l.Y;

            return Math.Sqrt(xDist * xDist + yDist * yDist);
        }

        /// <summary>
        /// Return a Location structure to a string.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// 
        public static Location Parse(string location)
        {

            try
            {
                string[] split = location.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                string x = split[0].Substring(split[0].LastIndexOf(':') + 1);
                x = x.Trim();

                string y = split[1].Substring(split[1].LastIndexOf(':') + 1);
                y = y.Trim();

                string z = split[2].Substring(split[2].LastIndexOf(':') + 1);
                z = z.Trim();

                return new Location(int.Parse(x), int.Parse(y), int.Parse(z));
            }
            catch (Exception)
            {               
                Console.WriteLine(" Location Parse received an invalid location");
                return Location.Invalid; ;
            }

        }
        //public static Location Parse(string s)
        //{
        //    try
        //    {
        //        string replace = "~!@#$%^&*()_+`-={}|:\"<>?[]\\;',./ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        //        foreach (char c in replace)
        //            s = s.Replace(c, ' ');

        //        string[] split = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        //        return new Location(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));
        //    }
        //    catch
        //    {
        //        return Location.Invalid;
        //    }
        //}

        public override bool Equals(object other)
        {
            return other is Location && Equals((Location)other);
        }

        public bool Equals(Location other)
        {
            return other.X == X && other.Y == Y && other.Z == Z;
        }

        public static bool operator ==(Location me, Location other)
        {
            return me.Equals(other);
        }

        public static bool operator !=(Location me, Location other)
        {
            return !me.Equals(other);
        }

        public Location Offset(int x, int y, int z)
        {
            return new Location(X + x, Y + y, Z + z);
        }


    }
   }
