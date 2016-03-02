using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.game.model
{
    class Spell
    {
        public Spell(string name, string words, int mana, bool isRune, SpellCategory category, SpellType type)
        {
            Name = name;
            Words = words;
            Mana = mana;
            IsRune = isRune;
            Category = category;
            Type = type;
        }

        public string Name { get; private set; }
        public string Words { get; private set; }
        public int Mana { get; private set; }
        public bool IsRune { get; private set; }
        public SpellCategory Category { get; private set; }
        public SpellType Type { get; private set; }

    }

    public enum SpellCategory
    {
        Attack,
        Healing,
        Summon,
        Supply,
        Support
    }

    public enum SpellType
    {
        Instant,
        ItemTransformation,
        Creation
    }
}
