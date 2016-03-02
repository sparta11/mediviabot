using MediviaBot.game.model;
using MediviaBot.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.bot.modules.runemaker
{
    class RuneMakerSettings
    {

        public bool Enabled { get; set; }
        public string InventoryLocation { get; set; }
        public Spell Spell { get; set; }
        public PlayerConditions Condition { get; set; }
        public int Value { get; set; }
        public bool LogoutBlankRunes { get; set; }

    }
}
