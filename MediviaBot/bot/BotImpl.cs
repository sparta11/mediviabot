using MediviaBot.bot.modules.hotkeys;
using MediviaBot.bot.modules.runemaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediviaBot.util;
using MediviaBot.game;
using System.Threading;
using MediviaBot.bot.modules.lighthack;
using MediviaBot.bot.modules.antidle;
using MediviaBot.bot.modules.eatfood;

namespace MediviaBot.bot
{
    class BotImpl : Bot
    {

        private static HotkeysModule hotKeyModule = new HotkeysModule();
        private static Module runeMakerModule = new RuneMakerModule();
        private static Module lightHackModule = new LightHackModule();
        private static Module antidleModule = new AntidleModule();
        private static Module eatFoodModule = new EatFoodModule();

        private Game game = GameImpl.Instance;
        private ClientChooser clientChooser = new ClientChooser();

        //singleton instance
        private static BotImpl instance;
        private BotImpl() { }
        public static BotImpl Instance
        {
            get
            {
                if (instance == null)
                {
                    Console.WriteLine("|-- GameImpl: Creating BotImpl instance .... ");
                    instance = new BotImpl();
                    Console.WriteLine("|-- GameImpl: Creating BotImpl instance .... [DONE] ");
                }
                return instance;
            }
        }

        public void PlaySound(string file)
        {
            throw new NotImplementedException();
        }

        public string GetSetting(string path)
        {
            string[] tokens = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length < 2)
                return "not found";

            if (tokens[0].StartsWith("RuneMaker", StringComparison.CurrentCultureIgnoreCase))
            {
                return runeMakerModule.GetSetting(tokens.Skip(1).ToArray());
            }

            if (tokens[0].StartsWith("lighthack", StringComparison.CurrentCultureIgnoreCase))
            {
                return lightHackModule.GetSetting(tokens.Skip(1).ToArray());
            }

            if (tokens[0].StartsWith("antidle", StringComparison.CurrentCultureIgnoreCase))
            {
                return antidleModule.GetSetting(tokens.Skip(1).ToArray());
            }

            if (tokens[0].StartsWith("eatfood", StringComparison.CurrentCultureIgnoreCase))
            {
                return eatFoodModule.GetSetting(tokens.Skip(1).ToArray());
            }

            return "not found";
        }

        public void SetSetting(string path, string value)
        {

            //"setSetting("/RuneMaker/enabled", "true")
            string[] tokens = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length < 2)
                return;

            if (tokens[0].StartsWith("RuneMaker", StringComparison.CurrentCultureIgnoreCase))
            {
                runeMakerModule.SetSetting(tokens.Skip(1).ToArray(), value);
            }

            if (tokens[0].StartsWith("hotkeys", StringComparison.CurrentCultureIgnoreCase))
            {
                hotKeyModule.SetSetting(tokens.Skip(1).ToArray(), value);
            }

            if (tokens[0].StartsWith("lighthack", StringComparison.CurrentCultureIgnoreCase))
            {
                lightHackModule.SetSetting(tokens.Skip(1).ToArray(), value);
            }

            if (tokens[0].StartsWith("antidle", StringComparison.CurrentCultureIgnoreCase))
            {
                antidleModule.SetSetting(tokens.Skip(1).ToArray(), value);
            }

            if (tokens[0].StartsWith("eatfood", StringComparison.CurrentCultureIgnoreCase))
            {
                eatFoodModule.SetSetting(tokens.Skip(1).ToArray(), value);
            }

            //throw new NotImplementedException();
        }

        public void AddHotkey(Hotkey hotkey)
        {
            hotKeyModule.AddHotkey(hotkey);
        }

        public void RemoveHotkeyById(string hotkeyId)
        {
            hotKeyModule.RemoveHotkeyById(hotkeyId);
        }

        public void WaitPing()
        {
            Thread.Sleep(game.Ping());
        }

        public List<Hotkey> GetHotkeys()
        {
            return hotKeyModule.GetHotkeys();
        }
    }
}
