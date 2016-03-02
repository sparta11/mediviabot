using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.game.repository
{
    class MonsterList : List<String>
    {

        public static MonsterList List = new MonsterList();

        public MonsterList()
        {
            this.Add("Rabbit");
            this.Add("Dog");
            this.Add("Sheep");
            this.Add("Black Sheep");
            this.Add("Deer");
            this.Add("Pig");
            this.Add("Rat");
            this.Add("Snake");
            this.Add("Cave Rat");
            this.Add("Spider");

            this.Add("Wolf");
            this.Add("Bug");
            this.Add("Winter Wolf");
            this.Add("Troll");
            this.Add("Hyaena");
            this.Add("Poison Spider");
            this.Add("Frost Troll");
            this.Add("Bear");
            this.Add("Nether Spiderling");
            this.Add("Wasp");


            this.Add("Goblin");
            this.Add("Swamp Troll");
            this.Add("Orc");
            this.Add("Polar Bear");
            this.Add("Cobra");
            this.Add("Lion");
            this.Add("Skeleton");
            this.Add("Sand Troll");
            this.Add("Orc Spearman");
            this.Add("Rotworm");


            this.Add("Elf");
            this.Add("Larva");
            this.Add("Scorpion");
            this.Add("Dwarf");
            this.Add("Sand Spider");
            this.Add("Minotaur");
            this.Add("Orc Warrior");
            this.Add("War Wolf");
            this.Add("Wild Warrior");
            this.Add("Amazon");


            this.Add("Minotaur Archer");
            this.Add("Bandit");
            this.Add("Dwarf Soldier");
            this.Add("Elf Scout");
            this.Add("Mutated Rat");
            this.Add("Ghoul");
            this.Add("Valkyrie");
            this.Add("Stalker");
            this.Add("Gazer");
            this.Add("Valkyrie Cavalry");


            this.Add("Orc Shaman");
            this.Add("Fire Devil");
            this.Add("Ghost");
            this.Add("Witch");
            this.Add("Scarab");
            this.Add("Mummy");
            this.Add("Minotaur Mage");
            this.Add("Hunter");
            this.Add("Gargoyle");
            this.Add("Cyclops");


            this.Add("Slime");
            this.Add("Minotaur Guard");
            this.Add("Stone Golem");
            this.Add("Dwarf Slayer");
            this.Add("Dwarf Guard");
            this.Add("Beholder");
            this.Add("Elf Arcanist");
            this.Add("Orc Bowman");
            this.Add("Elf Guardian");
            this.Add("Orc Berserker");


            this.Add("Crypt Shambler");
            this.Add("Slave Hunter");
            this.Add("Green Djinn");
            this.Add("Blue Djinn");
            this.Add("Monk");
            this.Add("Fire Elemental");
            this.Add("Demon Skeleton");
            this.Add("Dwarf Geomancer");
            this.Add("Harpy");
            this.Add("Ember Beetle");

            this.Add("Orc Leader");
            this.Add("Elder Beholder");
            this.Add("Vampire");
            this.Add("Cyclops Warrior");
            this.Add("Efreet");
            this.Add("Marid");
            this.Add("Harpy Spellweaver");
            this.Add("Elf Sharpshooter");
            this.Add("Priestess");
            this.Add("Sandskull Spider");

            this.Add("Dwarf Dragoneater");
            this.Add("Archer");
            this.Add("Giant Jellyfish");
            this.Add("Vigilante");
            this.Add("Bonebeast");
            this.Add("Sandbeast");
            this.Add("Necromancer");
            this.Add("Elf Swordmaster");
            this.Add("Harpy Queen");
            this.Add("Thaian Soldier");

            this.Add("Orc Warlord");
            this.Add("Dragon");
            this.Add("Ancient Scarab");
            this.Add("Lich");
            this.Add("Banshee");
            this.Add("Giant Spider");
            this.Add("Ogre Gruntz");
            this.Add("Tar Monstrosity");
            this.Add("Dwarf Renegade");
            this.Add("Slave Guard");

            this.Add("Corrupted Spider");
            this.Add("Hero");
            this.Add("Nether Spider");
            this.Add("Black Knight");
            this.Add("Ogre Smasher");
            this.Add("Dragon Lord");
            this.Add("Ogre Warrior");
            this.Add("Daraman Prayer");
            this.Add("Traitor");
            this.Add("Ancient Golem");

            this.Add("Behemoth");
            this.Add("Lernaean Hydra");
            this.Add("Lightbringer Knight");
            this.Add("Shattered Soul");
            this.Add("Warlock");
            this.Add("Wight");
            this.Add("Tar Priest");
            this.Add("Albino Dragon");
            this.Add("Royalist");
            this.Add("Manticore");


            this.Add("Frost Dragon");
            this.Add("Undead Dragon");
            this.Add("Chimera");
            this.Add("Demon");
            this.Add("Abomination");
            this.Add("Queen's Follower");


            this.Add("Munster");
            this.Add("The Horned Fox");
            this.Add("General Murius");
            this.Add("Gladiator");
            this.Add("Yeti");
            this.Add("Dharalion");
            this.Add("Fernfang");
            this.Add("Robin Hood");
            this.Add("The Evil Eye");
            this.Add("Bogir Lightbringer");
            this.Add("Grorlam");
            this.Add("Dipthrah");
            this.Add("Vashresamun");
            this.Add("Thalas");
            this.Add("Omruc");
            this.Add("Morguthis");
            this.Add("Mahrdis");
            this.Add("Rahemos");
            this.Add("Ashmunrah");
            this.Add("The Old Widow");
            this.Add("Demodras");
            this.Add("Ferumbras");
            this.Add("Necromantica");
            this.Add("Orshabaal");
            this.Add("Goshnar");
            this.Add("Porgol");
        }


        public bool FindMonster(string name)
        {
            if (this.Any(str => str.Contains(name)))
                return true;

            return false;
        }


    }
}
