using MediviaBot.client;
using MediviaBot.game;
using MediviaBot.game.model;
using MediviaBot.input;
using MediviaBot.player;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediviaBot.bot
{
    class PreLoader
    {

        public void Initialize(Process process)
        {
            //Console.WriteLine("|-- PreLoader: Setting process...");
            //Process[] mediviaProcess = Process.GetProcessesByName("Medivia_OGL");
            //process = mediviaProcess[0];
            if (process == null)
                Console.WriteLine("null");
            ClientImpl.Process = process;

            InputSender inputSender = InputSenderImpl.Instance;
            Console.WriteLine("|-- QueueManager: Creating queue manager thread ... ");
            Console.WriteLine("|-- PreLoader: Setting process... [done]");
            Client client = ClientImpl.Instance;
            Game game = GameImpl.Instance;
            Bot bot = BotImpl.Instance;
            Player player = PlayerImpl.Instance;
            Console.WriteLine("|-- PreLoader: Everyting done ...");


            //InputQueueManager queueManager = InputQueueManager.Instance;
            //Thread queueThread = new Thread(new ThreadStart(queueManager.Initialize));
            //queueThread.Start();
            //while (!queueThread.IsAlive) ;
            //Console.WriteLine("|-- QueueManager: Creating queue manager thread ... [done]");



        }
    }

}
