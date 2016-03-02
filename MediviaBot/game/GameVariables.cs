using MediviaBot.game.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.game
{
    interface GameVariables
    {

        Creature Target();
        int Ping();
        bool IsConnected();
        //int ExpHour();
        //int ExpGained();

    }
}
