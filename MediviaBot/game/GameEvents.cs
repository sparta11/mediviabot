using MediviaBot.game.model;
using MediviaBot.util.item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.game
{
    interface GameEvents
    {

        void Logout();
        //void SetAttackMode(string attackMode, string chaseMode);
        //void EnableSkull(bool value);
        //void XLog();
        List<Creature> GetAllCreatures();
        Creature GetCreature(string name);
        Creature GetCreatureById(int id);
        //int MonsterAround(int range, params string[] names);
        //int PlayersAround(int range, params string[] names);
        Item GetItemById(int itemId);
        int ItemId(string name);
        string ItemName(int itemId);
        int ItemCount(int itemId, string location = "");

        Spell GetSpell(string spellWords);
        List<Spell> GetAllSpells();
        Rune GetRune(string spellName);

        //bool ItemHasProperty(int itemId, string property);
        Container GetContainer(int index);
        Container GetContainer(string containerName);
        Container GetContainerWithFreeSlots();
        List<Container> GetAllContainers();

        List<Item> FindItems(int itemId, string location);
       


        ItemLocation FindItem(int itemId);
        ItemLocationContainer FindItemOnContainers(int itemId);
        ItemLocationContainer FindItemOnContainers(int itemId, int containerIndex);
        ItemLocationInventory FindItemOnInventory(int itemId);

    }
}
