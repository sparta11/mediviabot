using MediviaBot.game.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.game.model
{
    class Item : Thing
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        //public ItemLocation location { get; set; }

        public Item(string[] properties, int id, string name) : base(properties)
        {
            Id = id;
            Name = name;
        }

        public bool IsFood()
        {
            return FoodList.Foods.Contains(this);
        }

        public void printItem()
        {
            Console.WriteLine("|----item----");
            Console.WriteLine("|-- Id: " + Id);
            Console.WriteLine("|-- Count: " + Count);
            Console.WriteLine("|------------");
        }

    }
}
