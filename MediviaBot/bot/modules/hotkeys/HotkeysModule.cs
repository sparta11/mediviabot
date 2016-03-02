using MediviaBot.game;
using MediviaBot.game.model;
using MediviaBot.player;
using MediviaBot.util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediviaBot.bot.modules.hotkeys
{
    class HotkeysModule : Module
    {
        private List<Hotkey> hotkeys = new List<Hotkey>();
        private bool enabled = false;
        private LowLevelKeyboardListener _listener;
        private Player player = PlayerImpl.Instance;
        private Game game = GameImpl.Instance;
        private KeyConverter keyConverter = new KeyConverter();

        public HotkeysModule()
        {
            _listener = new LowLevelKeyboardListener();
            _listener.OnKeyPressed += _listener_OnKeyPressed;
        }


        public void AddHotkey(Hotkey hotkey)
        {
            this.hotkeys.Add(hotkey);
        }

        public void RemoveHotkeyById(string hotkeyId)
        {
            for (int i = 0; i < hotkeys.Count; i++)
            {
                Hotkey h = hotkeys[i];
                if (h.Id.Equals(hotkeyId))
                {
                    hotkeys.Remove(h);
                    return;
                }
            }
            return;
        }

        public void Enable()
        {
            //Console.WriteLine("HotkeyModule is enebled");;
            _listener.HookedKeys.Clear();
            foreach (Hotkey k in hotkeys)
            {
                //add from hooked keys
                //Console.WriteLine("Adding " + k.Key.ToString() + " from hooked keys...");
                Key mykey = (Key)keyConverter.ConvertFromString(k.Key);
                _listener.HookedKeys.Add(mykey);
            }
            _listener.HookKeyboard();
        }

        public void Disable()
        {
            _listener.UnHookKeyboard();
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

        void _listener_OnKeyPressed(object sender, KeyPressedArgs e)
        {
            foreach (Hotkey h in hotkeys)
            {
                if (e.KeyPressed.ToString().Equals(h.Key))
                    performHotkeyAction(h);
            }

        }

        private void performHotkeyAction(Hotkey h)
        {

            //var watch = Stopwatch.StartNew();
            // the code that you want to measure comes here

            switch (h.Type)
            {
                case HotkeyType.UseOnYourself:
                    player.UseItemOn(h.ItemId, player.Location().ToString());
                    break;
                case HotkeyType.UseOnTarget:
                    Creature creature = game.Target();
                    if (creature != null)
                    {
                        Console.WriteLine("notnull creature");
                        player.UseItemOn(h.ItemId, creature.Location);

                    }
                    else
                    {
                        Console.WriteLine("Null creature");
                    }

                    break;
                case HotkeyType.UseWithCrosshairs:
                    player.useItemWithCrossHairs(h.ItemId);
                    break;
                case HotkeyType.UseItem:
                    player.UseItem(h.ItemId);
                    break;
                case HotkeyType.EquipItem:
                    player.MoveItems(h.ItemId, h.InventoryLocation);
                    break;
                case HotkeyType.UnequipItem:
                    Container c = game.GetContainerWithFreeSlots();
                    if (c == null)
                        return;

                    Item lhand = player.GetEquipment(h.InventoryLocation);
                    if (lhand == null)
                        return;

                    player.MoveItems(lhand.Id, "" + c.Index, h.InventoryLocation);
                    break;
            }

            //watch.Stop();
            //var elapsedMs = watch.ElapsedMilliseconds;
            //Console.WriteLine("Time to shoot: " + elapsedMs);
        }

        internal List<Hotkey> GetHotkeys()
        {
            return this.hotkeys;
        }
    }
}
