using MediviaBot.game.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.game.repository
{
    class FoodList : List<Item>
    {

        public static List<Item> Foods = new List<Item>()
        {
            new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2674, "Red Apple", 72),
            new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2676, "Banana", 96),
            new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2677, "Blueberry", 12),
            new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2689, "Bread", 120),
            new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2691, "Brown Bread", 96),
            new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2789, "Brown Mushroom", 264),
            new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2684, "Carrot", 60),
            new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2696, "Cheese", 108),
            new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2679, "Cherry", 12),
            new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2726, "Coconut", 216),
            new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2687, "Cookie", 24),
            new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2686, "Corncob", 108),
            new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2672, "Dragon Ham", 720),
            new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2695, "Egg", 72),
            new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2667, "Fish", 144),
            new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2681, "Grapes", 108),
            new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2796, "Green Mushroom", 60),
            new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2671, "Ham", 360),
            new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2666, "Meat", 180),
            new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2682, "Mellon", 240),
            new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2675, "Orange", 156),
            new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2690, "Roll", 36),
            new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2668, "Salmon", 120),
            new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2787, "White Mushroom", 108)
        };

        //public FoodList()
        //{
        //    this.Add(new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2674, "Red Apple", 72));
        //    this.Add(new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2676, "Banana", 96));
        //    this.Add(new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2677, "Blueberry", 12));
        //    this.Add(new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2689, "Bread", 120));
        //    this.Add(new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2691, "Brown Bread", 96));
        //    this.Add(new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2789, "Brown Mushroom", 264));
        //    this.Add(new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2684, "Carrot", 60));
        //    this.Add(new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2696, "Cheese", 108));
        //    this.Add(new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2679, "Cherry", 12));
        //    this.Add(new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2726, "Coconut", 216));
        //    this.Add(new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2687, "Cookie", 24));
        //    this.Add(new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2686, "Corncob", 108));
        //    this.Add(new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2672, "Dragon Ham", 720));
        //    this.Add(new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2695, "Egg", 72));
        //    this.Add(new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2667, "Fish", 144));
        //    this.Add(new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2681, "Grapes", 108));
        //    this.Add(new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2796, "Green Mushroom", 60));
        //    this.Add(new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2671, "Ham", 360));
        //    this.Add(new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2666, "Meat", 180));
        //    this.Add(new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2682, "Mellon", 240));
        //    this.Add(new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2675, "Orange", 156));
        //    this.Add(new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2690, "Roll", 36));
        //    this.Add(new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2668, "Salmon", 120));
        //    this.Add(new Food(new string[] { "stackable", "usable", "food", "pickupable" }, 2787, "White Mushroom", 108));
        //}

    }
}
