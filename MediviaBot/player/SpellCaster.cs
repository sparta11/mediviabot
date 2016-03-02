using MediviaBot.client;
using MediviaBot.game;
using MediviaBot.game.model;
using MediviaBot.input;
using MediviaBot.util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.player
{
    class SpellCaster
    {

        private Client client = ClientImpl.Instance;
        private Game game = GameImpl.Instance;
        protected Player player = PlayerImpl.Instance;

        private Object thisLock = new Object();
        private Stopwatch watch = Stopwatch.StartNew();

        private const int AGRESSIVE_EXAUSTED_MS = 2000;
        private const int HEALING_EXAUSTED_MS = 1000;
        private long exaustedTime = 0;

        public bool CanCast()
        {

            //Console.WriteLine("Elapsed time: " + watch.ElapsedMilliseconds);
            //Console.WriteLine("Exausted time: " + exaustedTime);
            if (watch.ElapsedMilliseconds >= exaustedTime)
            {
                resetExaustedTime();
                return true;
            }
            return false;
        }

        public void Cast(string words)
        {

            Spell spell = game.GetSpell(words);
            if (spell == null)
            {
                Console.WriteLine("SpellCaster: spell with words: " + words + " not foud");
                return;
            }

            if (spell.Category == SpellCategory.Attack)
            {
                if (CanCast())               
                    setExaustedTime(AGRESSIVE_EXAUSTED_MS);               
            }
            else
            {
                if (CanCast())                
                    setExaustedTime(HEALING_EXAUSTED_MS);                
            }

            Console.WriteLine("============================== Casting: " + spell.Words);
            string hotkey = client.GetClientHotkey(spell.Words);
            if (hotkey.Equals("not found"))
            {
                Console.WriteLine("Hotkey with text: " + spell.Words + " not found");
                return;
            }

            if (spell.IsRune && spell.Type != SpellType.ItemTransformation && spell.Type != SpellType.Creation)
            {

                Rune rune = game.GetRune(spell.Words);
                if (rune == null)
                {
                    Console.WriteLine("SpellCasterImpl: Rune with spell: " + spell.Words + " not found");
                    return;
                }

                player.UseItemOn(rune.Id, player.Location());

            }
            else
            {

                player.PressKey(hotkey);

            }


        }

        private void resetExaustedTime()
        {
            lock (thisLock)
            {
                exaustedTime = 0;
            }
        }

        private void setExaustedTime(int milliseconds)
        {
            lock (thisLock)
            {
                exaustedTime = milliseconds;
                watch.Restart();
            }
        }

    }
}
