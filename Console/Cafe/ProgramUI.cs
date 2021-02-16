using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoles
{
    class ProgramUI
    {
        private List<MenuItem> _menuRepo = new List<MenuItem>();
        public void Run()
        {
            SeedMenu();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueRun = true;
            while (continueRun)
            {
                Console.WriteLine("What would you like to do? \n" +
                    "1. View menu\n" +
                    "2. Add new menu item\n" +
                    "3. Delete menu item\n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ShowMenu();
                        break;
                    case "2":
                        // Update Menu
                        break;
                    case "3":
                        // Delete items from menu
                        break;
                    case "4":
                        // Exit
                        break;
                }
            }
        }
        private void DisplayMenu(MenuItem menuItem)
        {
            Console.WriteLine($"Meal Number: {menuItem.MealNum}\n" +
                $"Meal Name: {menuItem.Name}\n" +
                $"Description: {menuItem.Description}\n" +
                $"Ingredients: {menuItem.Ingredients}\n" +
                $"Price: ${menuItem.Price}\n");
        }

        private void ShowMenu()
        {
            //List<MenuItem> menuList = _menuRepo.GetMenu();
        }
        private void SeedMenu()
        {
            MenuItem mealOne = new MenuItem( 1, "Cereal", "An endless bowl of cereal of your choosing.", "Cereal, milk,", 4.99);
            MenuItem mealTwo = new MenuItem(2, "Basic Breakfast", "Nothing more than your basic breakfast. (Eggs, bacon, toast, oatmeal.)", "Eggs, bacon, flour, yeast, baking soda, whole oats, brown sugar", 9.99);
            MenuItem mealThree = new MenuItem(1, "Pancakes", "All you can eat pancakes.", "flour, eggs, milk", 4.99);

            _menuRepo.Add(mealOne);
            _menuRepo.Add(mealTwo);
            _menuRepo.Add(mealThree);
        }
    }
}
