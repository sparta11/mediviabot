using MediviaBot.game.model;
using MediviaBot.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MediviaBot.memory.game
{
    interface GameReader
    {

        Creature GetAttackingCreature();
        Location GetAttackingCreatureLocation();
        Creature GetFollowingCreature();
        bool GetIsOnline();
        int GetPing();

    }
}
