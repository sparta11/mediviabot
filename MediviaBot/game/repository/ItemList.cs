using MediviaBot.game.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.game.repository
{
    class ItemList : List<Item>
    {
        public ItemList()
        {
            this.AddRange(new RuneList());
            this.AddRange(new ContainerList());
            this.AddRange(FoodList.Foods);
            this.AddRange(new RuneList());
            this.AddRange(new ValuableList());
        }

        public int ItemId(string name)
        {
            foreach (Item item in this)
            {
                if (item.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                    return item.Id;
            }
            return -1;
        }

        public string ItemName(int itemId)
        {
            foreach (Item item in this)
            {
                if (item.Id == itemId)
                {
                    return item.Name;
                }
            }
            return "not found";
        }

        public Item FidItem(int itemId)
        {
            foreach (Item item in this)
            {
                if (item.Id == itemId)                
                    return item;
                
            }
            return null;
        }
    }
}
