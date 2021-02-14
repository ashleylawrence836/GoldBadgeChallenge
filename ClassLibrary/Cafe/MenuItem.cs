using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class MenuItem
    {
        public int MealNum { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        // Ingredients
        public MenuItem() { }
        public MenuItem(int mealNum, string name, string description, double price)
        {
            MealNum = mealNum;
            Name = name;
            Description = description;
            Price = price;
        }


    }


}
