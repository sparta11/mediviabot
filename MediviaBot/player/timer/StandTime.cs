using MediviaBot.game;
using MediviaBot.util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediviaBot.player.timer
{
    class StandTime
    {
        private Stopwatch standTimeWatch = Stopwatch.StartNew();
        private Player player = PlayerImpl.Instance;
        private Game game = GameImpl.Instance;
        private bool isOnline = false;

        public StandTime()
        {

            if (game.IsConnected())
                standTimeWatch = Stopwatch.StartNew();
            else
            {
                standTimeWatch = Stopwatch.StartNew();
                standTimeWatch.Stop();
                standTimeWatch.Reset();
            }

            Thread standTimeThread = new Thread(new ThreadStart(this.startStandTimeUpdater));
            standTimeThread.Start();
        }

        private void startStandTimeUpdater()
        {
            Location lastLoc = player.Location();

            while (true)
            {
                Thread.Sleep(1000);
                if (checkIsOnline())
                {

                    Location location = player.Location();
                    if (!location.Equals(lastLoc))
                    {
                        lastLoc = location;
                        //restart
                        //Console.WriteLine("Diferent.. restarting...");
                        standTimeWatch.Reset();
                        standTimeWatch.Start();
                    }

                }
            }
        }

        private bool checkIsOnline()
        {

            bool onlineCheck = game.IsConnected();

            if (isOnline != onlineCheck)
            {
                isOnline = onlineCheck;
                if (isOnline)
                {
                    standTimeWatch.Reset();
                    standTimeWatch.Start();
                }
                else
                {
                    standTimeWatch.Reset();
                    standTimeWatch.Stop();
                }
            }

            return isOnline;
        }

        internal long GetStandTime()
        {
            return standTimeWatch.ElapsedMilliseconds;
        }
    }
}
