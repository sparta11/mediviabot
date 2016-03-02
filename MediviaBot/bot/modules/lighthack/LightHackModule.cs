using MediviaBot.memory.lighthack;
using MediviaBot.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.bot.modules.lighthack
{
    class LightHackModule : Module
    {

        private LightHackMemory light = new LightHackMemory();

        public void Disable()
        {
        }

        public void Enable()
        {
            light.TurnOn();
        }

        public string GetSetting(string[] path)
        {
            return "not found";
        }

        public void SetSetting(string[] path, string value)
        {
            if (path[0].Equals("enabled", StringComparison.CurrentCultureIgnoreCase))
            {
                if(BotUtil.Bool(value))
                    this.Enable();
            }
        }
    }
}
