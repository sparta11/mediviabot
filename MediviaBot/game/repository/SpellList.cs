using MediviaBot.game.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.game.repository
{
    class SpellList : List<Spell>
    {
        public SpellList()
        {
            this.Add(Spells.Light);
            this.Add(Spells.FindPerson);
            this.Add(Spells.Food);
            this.Add(Spells.MagicRope);
            this.Add(Spells.LightHealing);
            this.Add(Spells.Antidote);
            this.Add(Spells.Levitate);
            this.Add(Spells.LightMagicMissile);
            this.Add(Spells.LastResort);
            this.Add(Spells.DeathStrike);
            this.Add(Spells.ConjureArrow);
            this.Add(Spells.PoisonField);
            this.Add(Spells.IntenseHealing);
            this.Add(Spells.EnergyStrike);
            this.Add(Spells.GreatLight);
            this.Add(Spells.FlameStrike);
            this.Add(Spells.HeavyMagicMissile);
            this.Add(Spells.FireHealing);
            this.Add(Spells.EnergyHealing);
            this.Add(Spells.FireField);
            this.Add(Spells.MagicShield);
            this.Add(Spells.Haste);
            this.Add(Spells.IntenseHealingRune);
            this.Add(Spells.Challenge);
            this.Add(Spells.ConjureHuntingArrow);
            this.Add(Spells.Berserk);
            this.Add(Spells.AntidoteRune);
            this.Add(Spells.ConjurePoisonedArrow);
            this.Add(Spells.Fireball);
            this.Add(Spells.EnergyField);
            this.Add(Spells.DestroyField);
            this.Add(Spells.ConjureBolt);
            this.Add(Spells.FireWave);
            this.Add(Spells.HealFriend);
            this.Add(Spells.AnimateDead);
            this.Add(Spells.UltimateHealing);
            this.Add(Spells.Desintegrate);
            this.Add(Spells.StrongHaste);
            this.Add(Spells.PoisonBomb);
            this.Add(Spells.ConjureHuntingBolt);
            this.Add(Spells.FireBomb);
            this.Add(Spells.GreatFireball);
            this.Add(Spells.MassEnergyHealing);
            this.Add(Spells.MassFireHealing);
            this.Add(Spells.ConvinceCreature);
            this.Add(Spells.CreatureIllusion);
            this.Add(Spells.EnergyBeam);
            this.Add(Spells.ConjureExplosiveArrow);
            this.Add(Spells.UltimateHealingRune);
            this.Add(Spells.Chameleon);
            this.Add(Spells.PoisonWall);
            this.Add(Spells.UltimateLight);
            this.Add(Spells.Explosion);
            this.Add(Spells.CancelInvisibility);
            this.Add(Spells.Soulfire);
            this.Add(Spells.WildGrowth);
            this.Add(Spells.MagicWall);
            this.Add(Spells.ConjurePowerBolt);
            this.Add(Spells.Invisible);
            this.Add(Spells.MassHealing);
            this.Add(Spells.SummonCreature);
            this.Add(Spells.EnergyBomb);
            this.Add(Spells.EnergyWall);
            this.Add(Spells.EnergyWave);
            this.Add(Spells.SuddenDeath);
            this.Add(Spells.PoisonStorm);
            this.Add(Spells.UndeadLegion);
            this.Add(Spells.EnchantStaff);
            this.Add(Spells.FireWall);
            this.Add(Spells.Paralyze);
            this.Add(Spells.UltimateExplosion);
        }

        public Spell FindSpell(string spellNameOrWords, bool wholeWord)
        {
            return this.Find(delegate (Spell s)
            {
                if (wholeWord)
                    return (s.Name.Equals(spellNameOrWords, System.StringComparison.CurrentCultureIgnoreCase)) ||
                        (s.Words.Equals(spellNameOrWords, System.StringComparison.CurrentCultureIgnoreCase));
                else
                    return (s.Name.IndexOf(spellNameOrWords, StringComparison.CurrentCultureIgnoreCase) != -1) ||
                        (s.Words.IndexOf(spellNameOrWords, StringComparison.CurrentCultureIgnoreCase) != -1);
            });
        }

        public List<Spell> GetRuneSpells()
        {
            return this.FindAll(delegate (Spell s)
            {
                return s.IsRune == true;
            });
        }

        public List<Spell> FindSpells(SpellCategory spellCategory)
        {
            return this.FindAll(delegate (Spell s)
            {
                return s.Category == spellCategory;
            });
        }

        public List<Spell> FindSpells(SpellType spellType)
        {
            return this.FindAll(delegate (Spell s)
            {
                return s.Type == spellType;
            });
        }

        public List<Spell> FindSpells(int requiredMana)
        {
            return this.FindAll(delegate (Spell s)
            {
                return s.Mana <= requiredMana;
            });
        }
    }
}
