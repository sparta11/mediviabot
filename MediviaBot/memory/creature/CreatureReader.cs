using MediviaBot.game.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.memory.creature
{
    interface CreatureReader
    {
        //Creature GetCreatureByID();
        List<Creature> GetAllCreatures();
        Creature GetCreatureByName(string name);
        Creature GetCreatureById(int creatureId);

        Creature ReadCreature(uint creatureAddress);
    }
}
