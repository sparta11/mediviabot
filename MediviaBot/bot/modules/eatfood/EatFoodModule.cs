using MediviaBot.client;
using MediviaBot.game;
using MediviaBot.game.model;
using MediviaBot.player;
using MediviaBot.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediviaBot.bot.modules.eatfood
{
    class EatFoodModule : Module
    {

        private bool enabled;
        private Game game = GameImpl.Instance;
        private Client client = ClientImpl.Instance;
        private Player player = PlayerImpl.Instance;
        private Random rnd = new Random();
        private int MIN_TIME_MS = 1000 * 60 * 15; // 15 min
        private int MAX_TIME_MS = 1000 * 60 * 19; // 19 min

        public void Disable()
        {
            this.enabled = false;          
        }

        public void Enable()
        {
            Console.WriteLine("Starting runemaker module ...");
            Thread thread = new Thread(new ThreadStart(this.startModule));
            this.enabled = true;
            thread.Start();
        }

        private void startModule()
        {
            do
            {
                if (!game.IsConnected())
                {
                    Thread.Sleep(rnd.Next(MIN_TIME_MS, MAX_TIME_MS));
                    continue;
                }

                for (int i = 0; i < 10; i++)
                {
                    //Console.WriteLine("Trying to eat: " + i);
                    player.EatFood();
                    Thread.Sleep(game.Ping());
                    if (isFull())
                        break;
                }

                Thread.Sleep(rnd.Next(MIN_TIME_MS, MAX_TIME_MS));

            } while (enabled);
        }

        private bool isFull()
        {
            string message = client.GetStatusMessage();
            //Console.WriteLine("Client message: " + message);
            if (message.Contains("full"))
            {
                //Console.WriteLine("Stopping eat");
                return true;
            }

            //Console.WriteLine("Not full");
            return false;

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
                }
                else
                {
                    this.enabled = false;
                    this.Disable();
                }
            }
        }
    }
}
