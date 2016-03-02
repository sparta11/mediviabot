using MediviaBot.game.model;
using MediviaBot.util;
using MediviaBot.util.item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MediviaBot.memory.player
{
    interface PlayerReader
    {

        int GetXPos();
        int GetYPos();
        int GetZPos();
        int GetID();
        string GetName();
        string GetDirection();
        double GetHealth();
        double GetMaxHealth();
        int GetCapacity();
        double GetMana();
        double GetManaMax();

        Item GetInventoryItem(InventoryLocation location);

    }
}
