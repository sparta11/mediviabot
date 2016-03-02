using MediviaBot.game;
using MediviaBot.player;
using MediviaBot.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediviaBot.bot.modules.antidle
{
    class AntidleModule : Module
    {

        private Game game = GameImpl.Instance;
        private Player player = PlayerImpl.Instance;
        private Random rnd = new Random();
        private bool enabled;

        private int MIN_TIME_MS = 1000 * 60 * 10; // 10 min
        private int MAX_TIME_MS = 1000 * 60 * 14; // 14 min

        public void Disable()
        {
            this.enabled = false;
        }

        public void Enable()
        {
            this.enabled = true;
            Console.WriteLine("|-- Antidle starting...");
            Thread thread = new Thread(new ThreadStart(this.startModule));
            thread.Start();
        }

        private void startModule()
        {
            while (enabled == true)
            {

                try
                {

                    if (game.IsConnected())
                    {
                        string lastDir = player.Direction();

                        for (int i = 0; i < 2; i++)
                        {
                            string randomDir = getRandomDirection(lastDir);
                            player.Turn(randomDir);
                            Thread.Sleep(500);
                        }

                        player.Turn(lastDir);
                    }

                    //Console.WriteLine("Spleeping...");
                    Thread.Sleep(rnd.Next(MIN_TIME_MS, MAX_TIME_MS));

                }
                catch (Exception)
                {
                    Console.WriteLine("Error on AntiIdleModule module");
                }

            }
        }

        private string getRandomDirection(string strLastDir)
        {

            int lastDir = DirectionUtil.GetIntDirection(strLastDir);

            int randomDir = rnd.Next(0, 4);
            while (randomDir == lastDir)
                randomDir = rnd.Next(0, 4);

            switch (randomDir)
            {
                case 0:
                    return "n";
                case 1:
                    return "e";
                case 2:
                    return "s";
                case 3:
                    return "w";
            }

            return "n";
        }

        public string GetSetting(string[] path)
        {
            if (path[0].Equals("enabled", StringComparison.CurrentCultureIgnoreCase))
            {
                return this.enabled.ToString();
            }

            return "not found";
        }

        public void SetSetting(string[] path, string value)
        {
            if (path[0].Equals("enabled", StringComparison.CurrentCultureIgnoreCase))
            {
                if (BotUtil.Bool(value))
                {
                    this.enabled = true;
                    this.Enable();
                } else
                {
                    this.enabled = false;
                    this.Disable();
                }
            }

        }
    }
}
