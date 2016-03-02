using MediviaBot.game.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.util.item
{
    class ItemLocationGround : ItemLocation
    {

        public Location Location { get; set; }

        public ItemLocationGround(Item item, Location location) : base(ItemLocationType.Ground, item)
        {
            Location = location;
        }
    }
}
