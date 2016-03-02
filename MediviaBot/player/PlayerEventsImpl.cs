using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediviaBot.game.model;
using MediviaBot.memory.player;
using MediviaBot.bot.core.mousesimulator;
using MediviaBot.bot.core.keyboardsimulator;
using MediviaBot.util;
using MediviaBot.game;

namespace MediviaBot.player
{
    class PlayerEventsImpl : PlayerEvents
    {

        private Game game = GameImpl.Instance;
        private PlayerReader playerReader = new PlayerMemoryReader();
        private SpellCaster spellCaster = new SpellCaster();
        private MouseSimulator mouse = new MouseSimulatorImpl();
        private KeyboardSimulator keyboard = new KeyboardSimulatorImpl();

        public void Cast(string words)
        {
            spellCaster.Cast(words);
        }

        public bool CanCast()
        {
            return spellCaster.CanCast();
        }

        public void Move(string dir)
        {
            Direction direction = DirectionUtil.GetDirection(dir);
            switch (direction)
            {
                case Direction.North:
                    keyboard.SendKeyPress("up");
                    break;
                case Direction.East:
                    keyboard.SendKeyPress("right");
                    break;
                case Direction.South:
                    keyboard.SendKeyPress("down");
                    break;
                case Direction.West:
                    keyboard.SendKeyPress("left");
                    break;
            }
        }

        public void MoveTo(int x, int y, int z)
        {
            mouse.LeftCLick(new Location(x, y, z));
        }

        public void Say(string text)
        {
            throw new NotImplementedException();
        }

        public void Turn(string dir)
        {
            Direction direction = DirectionUtil.GetDirection(dir);
            switch (direction)
            {
                case Direction.North:
                    keyboard.SendKeyPress("ctrl+up");
                    break;
                case Direction.East:
                    keyboard.SendKeyPress("ctrl+right");
                    break;
                case Direction.South:
                    keyboard.SendKeyPress("ctrl+down");
                    break;
                case Direction.West:
                    keyboard.SendKeyPress("ctrl+left");
                    break;
            }
        }

        public void EatFood()
        {
            List<Container> containers = game.GetAllContainers();
            foreach (Container c in containers)
            {
                List<Item> items = c.Items;
                foreach (Item item in items)
                {
                    if (item.IsFood())
                        this.UseItem(item.Id);
                }
            }
        }

        public void Attack(int creatureId)
        {

            Creature creature = game.GetCreatureById(creatureId);
            mouse.RightCLick(new Location(creature.XPos, creature.YPos, creature.ZPos));

        }

        public void Attack(Creature creature)
        {
            Location location = new Location(creature.XPos, creature.YPos, creature.ZPos);
            mouse.RightCLick(location);
        }

        public void Attack(string creatureName)
        {

            Creature creature = game.GetCreature(creatureName);
            if (creature == null)
            {
                Console.WriteLine("Creature with name: " + creatureName + " not found...");
                return;
            }

            this.Attack(creature);
        }

        public void MoveItems(string name, string to, string from = "")
        {
            this.MoveItems(game.ItemId(name), to, from);
        }

        public void MoveItems(int itemId, string to, string from = "")
        {
            mouse.MoveItems(itemId, to, from);
        }

        public void UseItem(int itemId, string location = "")
        {
            mouse.UseItem(itemId, location);
        }

        public void UseItem(int itemId, int containerIndex)
        {
            mouse.UseItem(itemId, containerIndex);
        }

        public void UseItem(string itemName, string location = "")
        {
            this.UseItem(game.ItemId(itemName), location);
        }

        public void UseItem(string itemName, int containerIndex)
        {
            this.UseItem(game.ItemId(itemName), containerIndex);
        }

        public void useItemWithCrossHairs(int itemId)
        {
            mouse.UseItem(itemId);
        }

        public void PressKey(string key)
        {
            keyboard.SendKeyPress(key);
        }

        public void UseItemOn(int itemId, string location)
        {
            mouse.UseItemOn(itemId, location);
        }

        public void UseItemOn(int itemId, Location location)
        {
            mouse.UseItemOn(itemId, location);
        }
    }
}
