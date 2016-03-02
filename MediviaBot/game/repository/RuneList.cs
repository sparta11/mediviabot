using MediviaBot.game.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.game.repository
{
    class RuneList : List<Item>
    {

        public RuneList()
        {
            this.Add(new Rune(new string[] { "usable", "rune", "pickupable" }, 2260, "Blank Rune", null));
            this.Add(new Rune(new string[] { "usable", "rune", "pickupable" }, 2287, "Light Magic Missile Rune", Spells.LightMagicMissile));
            this.Add(new Rune(new string[] { "usable", "rune", "pickupable" }, 2285, "Poison Field Rune", Spells.PoisonField));
            this.Add(new Rune(new string[] { "usable", "rune", "pickupable" }, 2301, "Fire Field Rune", Spells.FireField));
            this.Add(new Rune(new string[] { "usable", "rune", "pickupable" }, 2311, "Heavy Magic Missile Rune", Spells.HeavyMagicMissile));
            this.Add(new Rune(new string[] { "usable", "rune", "pickupable" }, 2265, "Intense Healing Rune", Spells.IntenseHealingRune));
            this.Add(new Rune(new string[] { "usable", "rune", "pickupable" }, 2266, "Antidote Rune", Spells.AntidoteRune));
            this.Add(new Rune(new string[] { "usable", "rune", "pickupable" }, 2302, "Fireball Rune", Spells.Fireball));
            this.Add(new Rune(new string[] { "usable", "rune", "pickupable" }, 2277, "Energy Field Rune", Spells.EnergyField));
            this.Add(new Rune(new string[] { "usable", "rune", "pickupable" }, 2261, "Destroy Field Rune", Spells.DestroyField));
            this.Add(new Rune(new string[] { "usable", "rune", "pickupable" }, 2316, "Animate Dead Rune", Spells.AnimateDead));
            this.Add(new Rune(new string[] { "usable", "rune", "pickupable" }, 2310, "Desintegrate Rune", Spells.Desintegrate));
            this.Add(new Rune(new string[] { "usable", "rune", "pickupable" }, 2286, "Poison Bomb Rune", Spells.PoisonBomb));
            this.Add(new Rune(new string[] { "usable", "rune", "pickupable" }, 2305, "Fire Bomb Rune", Spells.FireBomb));
            this.Add(new Rune(new string[] { "usable", "rune", "pickupable" }, 2304, "Great Fireball Rune", Spells.GreatFireball));
            this.Add(new Rune(new string[] { "usable", "rune", "pickupable" }, 2290, "Convince Creature Rune", Spells.ConvinceCreature));
            this.Add(new Rune(new string[] { "usable", "rune", "pickupable" }, 2273, "Ultimate Healing Rune", Spells.UltimateHealingRune));
            this.Add(new Rune(new string[] { "usable", "rune", "pickupable" }, 2291, "Chameleon Rune", Spells.Chameleon));
            this.Add(new Rune(new string[] { "usable", "rune", "pickupable" }, 2289, "Poison Wall Rune", Spells.PoisonWall));
            this.Add(new Rune(new string[] { "usable", "rune", "pickupable" }, 2313, "Explosion Rune", Spells.Explosion));
            this.Add(new Rune(new string[] { "usable", "rune", "pickupable" }, 2308, "Soulfire Rune", Spells.Soulfire));
            this.Add(new Rune(new string[] { "usable", "rune", "pickupable" }, 2293, "Magic Wall Rune", Spells.MagicWall));
            this.Add(new Rune(new string[] { "usable", "rune", "pickupable" }, 2262, "Energy Bomb Rune", Spells.EnergyBomb));
            this.Add(new Rune(new string[] { "usable", "rune", "pickupable" }, 2279, "Energy Wall Rune", Spells.EnergyWall));
            this.Add(new Rune(new string[] { "usable", "rune", "pickupable" }, 2268, "Sudden Death Rune", Spells.SuddenDeath));
            this.Add(new Rune(new string[] { "usable", "rune", "pickupable" }, 2303, "Fire Wall Rune", Spells.FireWall));
            this.Add(new Rune(new string[] { "usable", "rune", "pickupable" }, 2278, "Paralyze Rune", Spells.Paralyze));
        }

        public Rune FineRune(string spellName)
        {
            foreach (Rune rune in this)
            {

                if (rune.Spell == null)
                    continue;

                if (rune.Spell.Name.Equals(spellName, StringComparison.CurrentCultureIgnoreCase))
                    return rune;

            }

            return null;
        }

        public Rune FineRuneById(int itemId)
        {
            foreach (Rune rune in this)
            {
                if (rune.Id == itemId)
                    return rune;
            }

            return null;
        }
    }
}
