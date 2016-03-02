using MediviaBot.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.bot
{
    interface Bot
    {

        void WaitPing();

        void PlaySound(string file);

        string GetSetting(string path);

        void SetSetting(string path, string value);

        void AddHotkey(Hotkey hotkey);

        void RemoveHotkeyById(string hotkeyId);


        List<Hotkey> GetHotkeys();

    }
}
