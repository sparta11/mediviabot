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
            Console.WriteLine("|-- PreLoader: Setting process...");
            Process[] mediviaProcess = Process.GetProcessesByName("Medivia_OGL");
            process = mediviaProcess[0];
            ClientImpl.Process = process;

            InputSender inputSender = InputSenderImpl.Instance;
            Console.WriteLine("|-- QueueManager: Creating queue manager thread ... ");
            Client client = ClientImpl.Instance;
            Console.WriteLine("|-- PreLoader: Setting process... [done]");
            Game game = GameImpl.Instance;
            Bot bot = BotImpl.Instance;
            Player player = PlayerImpl.Instance;
            Console.WriteLine("|-- PreLoader: Everyting done ...");


            Creature swampTroll = new Creature(12313, "Swamp Troll", 1, 1, 1, 100);

            Console.WriteLine("SwampTroll isMonster: " + swampTroll.IsMonster());
            Console.WriteLine("SwampTroll IsPlayer: " + swampTroll.IsPlayer());
            Console.WriteLine("SwampTroll IsSelf: " + swampTroll.IsSelf());

            Creature blackFire = new Creature(12313, "Black Fire", 1, 1, 1, 100);

            Console.WriteLine("blackFire isMonster: " + blackFire.IsMonster());
            Console.WriteLine("blackFire IsPlayer: " + blackFire.IsPlayer());
            Console.WriteLine("blackFire IsSelf: " + blackFire.IsSelf());

            Creature Demon = new Creature(12313, "Demon", 1, 1, 1, 100);

            Console.WriteLine("Demon isMonster: " + swampTroll.IsMonster());
            Console.WriteLine("Demon IsPlayer: " + swampTroll.IsPlayer());
            Console.WriteLine("Demon IsSelf: " + swampTroll.IsSelf());

            //InputQueueManager queueManager = InputQueueManager.Instance;
            //Thread queueThread = new Thread(new ThreadStart(queueManager.Initialize));
            //queueThread.Start();
            //while (!queueThread.IsAlive) ;
            //Console.WriteLine("|-- QueueManager: Creating queue manager thread ... [done]");


            //if (process == null)
            //{
            //    Console.WriteLine("|-- PreLoader: Process is null... ");
            //}

            //ClientImpl.Process = process;


            //player.MoveItems(2120, "0", "lhand");

            //bot.SetSetting("/RuneMaker/hand", "lhand");
            //bot.SetSetting("/RuneMaker/spell", "heavy magic missile");
            //bot.SetSetting("/RuneMaker/condition", "mana below");
            //bot.SetSetting("/RuneMaker/value", "70");
            //bot.SetSetting("/runemaker/logout", "true");
            //bot.SetSetting("/RuneMaker/Enabled", "true");

            //player.UseItemOn();

            //while (true)
            //{
            //    Console.WriteLine("lhand ------");
            //    player.MoveItems(2148, "lhand");
            //    Console.WriteLine("rhand ------");
            //    player.MoveItems(2148, "rhand");
            //}

            //List<Creature> creatures = game.GetAllCreatures();
            //foreach (Creature creature in creatures)
            //{
            //    Console.WriteLine("|-------------- Creatures -------------------|");
            //    creature.PrintInfo();
            //}

            //List<Container> containers = game.GetAllContainers();
            //foreach (Container container in containers)
            //{
            //    Console.WriteLine("|-------------- Containers -------------------|");
            //    container.PrintInfo();
            //}

        }
    }

}
