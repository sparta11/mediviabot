using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediviaBot.game.model;
using MediviaBot.memory.game;

namespace MediviaBot.game
{
    class GameVariablesImpl : GameVariables
    {

        private GameReader gameReader = new GameMemoryReader();

        public bool IsConnected()
        {
            return gameReader.GetIsOnline();
        }

        public int Ping()
        {
            return gameReader.GetPing();
        }

        public Creature Target()
        {
            return gameReader.GetAttackingCreature();
        }

    }
}
