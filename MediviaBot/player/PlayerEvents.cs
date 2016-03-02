using MediviaBot.game.model;
using MediviaBot.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.player
{
    interface PlayerEvents
    {


        void Cast(string words);
        bool CanCast();
        void Move(string direction);
        void MoveTo(int x, int y, int z);
        void Say(string text);
        void Turn(string direction);
        void EatFood();
        void Attack(int creatureId);
        void Attack(Creature creature);
        void Attack(string creatureName);

        void MoveItems(string name, string to, string from = "");
        void MoveItems(int itemId, string to, string from = "");

        void UseItem(int itemId, string location = "");
        void UseItem(int itemId, int containerIndex);
        void UseItem(string itemName, string location = "");
        void UseItem(string itemName, int containerIndex);


        void UseItemOn(int itemId, string location);
        void UseItemOn(int itemId, Location location);

        void useItemWithCrossHairs(int itemId);

        void PressKey(string key);

    }
}
