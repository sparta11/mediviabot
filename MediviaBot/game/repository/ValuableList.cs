using MediviaBot.game.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.game.repository
{
    class ValuableList : List<Item>
    {

        public ValuableList()
        {
            this.Add(new Item(new string[] { "stackable", "pickupable" }, 2148, "Gold Coin"));
            this.Add(new Item(new string[] { "stackable", "pickupable" }, 2152, "Platinum Coin"));
            this.Add(new Item(new string[] { "stackable", "pickupable" }, 2160, "Crystal Coin"));
            this.Add(new Item(new string[] { "stackable", "pickupable" }, 2159, "Scarab Coin"));
            this.Add(new Item(new string[] { "stackable", "pickupable" }, 2143, "White Pearl"));
            this.Add(new Item(new string[] { "stackable", "pickupable" }, 2144, "Black Pearl"));
            this.Add(new Item(new string[] { "stackable", "pickupable" }, 2145, "Small Diamond"));
            this.Add(new Item(new string[] { "stackable", "pickupable" }, 2146, "Small Sapphire"));
            this.Add(new Item(new string[] { "stackable", "pickupable" }, 2147, "Small Ruby"));
            this.Add(new Item(new string[] { "stackable", "pickupable" }, 2149, "Small Emerald"));
            this.Add(new Item(new string[] { "stackable", "pickupable" }, 2150, "Small Amethyst"));
            this.Add(new Item(new string[] { "stackable", "pickupable" }, 2151, "Talon"));
            this.Add(new Item(new string[] { "pickupable" }, 2154, "Yellow Gem"));
            this.Add(new Item(new string[] { "pickupable" }, 2153, "Violet Gem"));
            this.Add(new Item(new string[] { "pickupable" }, 2156, "Red Gem"));
            this.Add(new Item(new string[] { "pickupable" }, 2155, "Green Gem"));
            this.Add(new Item(new string[] { "pickupable" }, 2158, "Blue Gem"));
            this.Add(new Item(new string[] { "pickupable" }, 2134, "Silver Brooch"));
            this.Add(new Item(new string[] { "pickupable" }, 2127, "Emerald Bangle"));
            this.Add(new Item(new string[] { "stackable", "pickupable" }, 2157, "Gold Nugget"));
        }



    }
}
