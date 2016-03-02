using MediviaBot.game.model;
using MediviaBot.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.player
{
    interface PlayerVariables
    {

        int Id();
        int Health();
        int MaxHealth();
        int Mana();
        int MaxMana();
        int HealthPercent();
        int ManaPercent();
        string Name();
        int PosX();
        int PosY();
        int PosZ();
        Location Location();
        string Direction();
        Item GetEquipment(string slot);
        long StandTime();

        void PrintPlayerInfo();

    }
}
