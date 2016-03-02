using MediviaBot.game.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.game.repository
{
    class ContainerList  : List<Item>
    {
        public ContainerList()
        {
            this.Add(new Item(new string[] { "container", "usable", "pickupable" }, 1987, "Normal Bag"));
            this.Add(new Item(new string[] { "container", "usable", "pickupable" }, 1991, "Green Bag"));
            this.Add(new Item(new string[] { "container", "usable", "pickupable" }, 1992, "Yellow Bag"));
            this.Add(new Item(new string[] { "container", "usable", "pickupable" }, 1993, "Red Bag"));
            this.Add(new Item(new string[] { "container", "usable", "pickupable" }, 1994, "Purple Bag"));
            this.Add(new Item(new string[] { "container", "usable", "pickupable" }, 1995, "Blue Bag"));
            this.Add(new Item(new string[] { "container", "usable", "pickupable" }, 1996, "Grey Bag"));
            this.Add(new Item(new string[] { "container", "usable", "pickupable" }, 1997, "Golden Bag"));
            this.Add(new Item(new string[] { "container", "usable", "pickupable" }, 3939, "Camouflage Bag"));
            this.Add(new Item(new string[] { "container", "usable", "pickupable" }, 1988, "Normal Backpack"));
            this.Add(new Item(new string[] { "container", "usable", "pickupable" }, 1998, "Green Backpack"));
            this.Add(new Item(new string[] { "container", "usable", "pickupable" }, 1999, "Yellow Backpack"));
            this.Add(new Item(new string[] { "container", "usable", "pickupable" }, 2000, "Red Backpack"));
            this.Add(new Item(new string[] { "container", "usable", "pickupable" }, 2001, "Purple Backpack"));
            this.Add(new Item(new string[] { "container", "usable", "pickupable" }, 2002, "Blue Backpack"));
            this.Add(new Item(new string[] { "container", "usable", "pickupable" }, 2003, "Grey Backpack"));
            this.Add(new Item(new string[] { "container", "usable", "pickupable" }, 2004, "Golden Backpack"));
            this.Add(new Item(new string[] { "container", "usable", "pickupable" }, 2595, "Parcel"));
            this.Add(new Item(new string[] { "container", "usable", "pickupable" }, 2596, "Stampped Parcel"));
            this.Add(new Item(new string[] { "container", "usable", "pickupable" }, 3940, "Camouflage Backpack"));
        }

    }
}
