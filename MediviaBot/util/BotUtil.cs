using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.util
{
    class BotUtil
    {

        public static int Number(string str)
        {
            try
            {
                return Convert.ToInt32(str);
            }
            catch (Exception)
            {
                Console.WriteLine("BotUtil: error converting string to int..");
                return -1;
            }
        }

        public static bool Bool(string str)
        {
            try
            {
                return Convert.ToBoolean(str);
            }
            catch (Exception)
            {
                Console.WriteLine("BotUtil: error converting string to boolean..");
                return false;
            }
        }

    }
}
