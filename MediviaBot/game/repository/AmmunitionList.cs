using MediviaBot.game.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.game.repository
{
    class AmmunitionList : List<Item>
    {

        public AmmunitionList()
        {
            this.Add(new Item(new string[] { "stackable", "pickupable" }, 2546, "Burst Arrow"));
            this.Add(new Item(new string[] { "stackable", "pickupable" }, 2544, "Arrow"));
            this.Add(new Item(new string[] { "stackable", "pickupable" }, 2543, "Bolts"));
            this.Add(new Item(new string[] { "stackable", "pickupable" }, 2545, "Poison Arrow"));
            this.Add(new Item(new string[] { "stackable", "pickupable" }, 2547, "Power Bolt"));
            this.Add(new Item(new string[] { "stackable", "pickupable" }, 2352, "Crystal Arrow"));
        }

    }
}
