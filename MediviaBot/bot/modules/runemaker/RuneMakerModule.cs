using MediviaBot.game;
using MediviaBot.game.model;
using MediviaBot.player;
using MediviaBot.util;
using MediviaBot.util.item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediviaBot.bot.modules.runemaker
{
    class RuneMakerModule : Module
    {
        private RuneMakerSettings settings = new RuneMakerSettings();
        private Game game = GameImpl.Instance;
        private Player player = PlayerImpl.Instance;
        private Bot bot = BotImpl.Instance;
        private const int blankRuneId = 2260;

        public void Disable()
        {
            settings.Enabled = false;
            bot.SetSetting("/eatfood/enabled", "false");
        }

        public void Enable()
        {
            settings.Enabled = true;
            Console.WriteLine("Starting runemaker module ...");
            Thread thread = new Thread(new ThreadStart(this.startModule));
            thread.Start();
        }

        private void startModule()
        {
            while (settings.Enabled)
            {

                if (settings.LogoutBlankRunes)
                    this.startLogoutBlankThread();

                if (!game.IsConnected())
                {
                    Thread.Sleep(5000);
                    continue;
                }

                try
                {

                    if (settings.Condition == PlayerConditions.ManaPercentAbove)
                    {
                        if (player.ManaPercent() >= settings.Value)
                            makeRune();
                    }
                    else
                    {
                        if (player.Mana() >= settings.Value)
                            makeRune();
                    }
                    Thread.Sleep(5000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    Console.WriteLine("Error on runemaker module");
                }

                Thread.Sleep(5000);

            }
        }

        private void startLogoutBlankThread()
        {
            Thread thread = new Thread(new ThreadStart(this.startLogoutBlankRunes));
            thread.Start();
        }

        private void startLogoutBlankRunes()
        {
            while (settings.Enabled && settings.LogoutBlankRunes)
            {

                if (!game.IsConnected())
                {
                    Thread.Sleep(5000);
                    continue;
                }

                if (game.ItemCount(blankRuneId) == 0)
                {
                    game.Logout();
                    settings.LogoutBlankRunes = false;
                }

                Thread.Sleep(5000);
            }

        }

        private void makeRune()
        {
            string inventoryLocation = settings.InventoryLocation;
            Console.WriteLine("Inventory location: " + inventoryLocation);
            Item handItem = player.GetEquipment(inventoryLocation);
            if (handItem == null)
            {
                //Console.WriteLine("Nao ha items na mao");
                ItemLocationContainer itemLocation = game.FindItemOnContainers(blankRuneId);
                if (itemLocation == null)
                    throw new InvalidOperationException("No blank runes");

                moveBlankAndCastSpell(inventoryLocation, settings.Spell);
            }
            else
            {
                //Console.WriteLine("existe item na mao: " + inventoryLocation);
                Item beltItem = player.GetEquipment("belt");
                if (beltItem == null)
                {

                    //move rhanditem from belt
                    Thread.Sleep(500);
                    player.MoveItems(handItem.Id, "belt", inventoryLocation);

                    //make rune
                    Thread.Sleep(500);
                    moveBlankAndCastSpell(inventoryLocation, settings.Spell);

                    //move rhanditem back from rhand
                    Thread.Sleep(500);
                    player.MoveItems(handItem.Id, inventoryLocation, "belt");

                }
                else
                {
                    //move from backpack
                    //find a container with free slots
                    Container c = game.GetContainerWithFreeSlots();
                    if (c == null)
                    {
                        Console.WriteLine("Nao existe container com free slots");
                        throw new InvalidOperationException("Nowhere from put handItem on runemaker module");
                    }

                    //move the handItem from container
                    Thread.Sleep(500);
                    player.MoveItems(handItem.Id, "" + c.Index, inventoryLocation);

                    //make rune
                    Thread.Sleep(500);
                    moveBlankAndCastSpell(inventoryLocation, settings.Spell);

                    //move handitem back from handLocation
                    Thread.Sleep(500);
                    player.MoveItems(handItem.Id, inventoryLocation);

                }
            }
        }

        private void moveBlankAndCastSpell(string inventoryLocation, Spell spell)
        {
            //move blank rune
            Thread.Sleep(500);
            player.MoveItems(blankRuneId, inventoryLocation);

            //cast spell
            Thread.Sleep(500);
            player.Cast(spell.Words);

            Item rune = player.GetEquipment(inventoryLocation);
            if (rune == null)
                return;

            //move rune back to container
            Thread.Sleep(500);
            Container c = game.GetContainerWithFreeSlots();
            if (c == null)
                throw new InvalidOperationException("Nowhere from put rune, all containers are full");

            player.MoveItems(rune.Id, "" + c.Index, inventoryLocation);
        }

        public string GetSetting(string[] path)
        {
            if (path[0].Equals("enabled", StringComparison.CurrentCultureIgnoreCase))
                return settings.Enabled.ToString();

            if (path[0].Equals("hand", StringComparison.CurrentCultureIgnoreCase))
                return settings.InventoryLocation;

            if (path[0].Equals("spell", StringComparison.CurrentCultureIgnoreCase))
                return settings.Spell.Name;

            if (path[0].Equals("value", StringComparison.CurrentCultureIgnoreCase))
                return settings.Value.ToString();

            if (path[0].Equals("condition", StringComparison.CurrentCultureIgnoreCase))
                return settings.Condition.ToString();

            if (path[0].Equals("logout", StringComparison.CurrentCultureIgnoreCase))
                return settings.LogoutBlankRunes.ToString();

            return "not found";

        }

        public void SetSetting(string[] path, string value)
        {

            if (path[0].Equals("enabled", StringComparison.CurrentCultureIgnoreCase))
            {
                // Console.WriteLine("|Runemaker module: Enable: " + value);                
                settings.Enabled = BotUtil.Bool(value);
                if (settings.Enabled)
                    this.Enable();
                else
                    this.Disable();

            }
            else if (path[0].Equals("hand", StringComparison.CurrentCultureIgnoreCase))
            {
                if (!ItemLocation.IsInventory(value))
                    return;

                Console.WriteLine("seeting inventory location: " + value);
                settings.InventoryLocation = value;
            }
            else if (path[0].Equals("spell", StringComparison.CurrentCultureIgnoreCase))
            {
                Spell spell = game.GetSpell(value);
                if (spell == null)
                    return;

                settings.Spell = spell;
            }
            else if (path[0].Equals("value", StringComparison.CurrentCultureIgnoreCase))
            {
                int val = BotUtil.Number(value);
                if (val < 0)
                    return;

                settings.Value = val;
            }
            else if (path[0].Equals("condition", StringComparison.CurrentCultureIgnoreCase))
            {
                value = value.ToLower();
                switch (value)
                {
                    case "mana percent above":
                        settings.Condition = PlayerConditions.ManaPercentAbove;
                        break;
                    case "mana above":
                        settings.Condition = PlayerConditions.ManaAbove;
                        break;
                }
            }
            else if (path[0].Equals("logout", StringComparison.CurrentCultureIgnoreCase))
            {
                settings.LogoutBlankRunes = BotUtil.Bool(value);
            }

        }
    }
}
