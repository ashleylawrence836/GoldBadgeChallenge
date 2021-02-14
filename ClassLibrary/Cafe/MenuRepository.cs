using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.NewFolder1
{
    public class MenuRepository
    {
        private readonly List<MenuItem> _menu = new List<MenuItem>();

        //CREATE
        public bool AddItemToMenu(MenuItem menuItem)
        {
            int startCount = _menu.Count;
            _menu.Add(menuItem);

            bool wasAdded = _menu.Count > startCount;
            return wasAdded;
        }

        //READ

        public List<MenuItem> GetMenu()
        {
            return _menu;
        }

        //DELETE

        public MenuItem GetItemByMealNum(int mealNum)
        {
            foreach (MenuItem meal in _menu)
            {
                if (mealNum == meal.MealNum)
                {
                    return meal;
                }
                else
                {
                    return null;
                    //throw new Exception("That meal number doesn't exist!");
                }
            }
        }
        public bool DeleteItem(int mealNum)
        {

        }
    }
}
