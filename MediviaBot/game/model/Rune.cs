using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.game.model
{
    class Rune : Item
    {
        public Spell Spell { get; private set; }

        public Rune(string[] properties, int id, string name, Spell spell) : base(properties, id, name)
        {
            Spell = spell;
        }
    }
}
