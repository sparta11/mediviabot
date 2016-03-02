using MediviaBot.game.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.memory.item
{
    interface ItemReader
    {

        Item ReadItem(uint itemAddr);

    }
}
