using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class MenuRepository
    {
        private readonly List<MenuItem> _menu = new List<MenuItem>();

        public bool AddItemToMenu(MenuItem menuItem)
        {
            int startCount = _menu.Count;
            _menu.Add(menuItem);

            bool wasAdded = _menu.Count > startCount;
            return wasAdded;
        }

        public List<MenuItem> GetMenu()
        {
            return _menu;
        }

        public MenuItem GetItemByMealNum(int mealNum)
        {
            foreach (MenuItem meal in _menu)
            {
                if (mealNum == meal.MealNum)
                {
                    return meal;
                }
            }
            throw new Exception("That meal doesn't exist!");
        }

        public bool RemoveMenuItem(int mealNum)
        {
            MenuItem item = GetItemByMealNum(mealNum);
            if( item == null)
            {
                return false;
            }

            int initialCount = _menu.Count;
            _menu.Remove(item);

            if (initialCount > _menu.Count)
            {
                return true;
            }
            return false;
        }
    }
}
