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
        MenuRepository _menuRepository = new MenuRepository();
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
                        DisplayMenu();
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
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void DisplayMenu()
        {
            List<MenuItem> menuList = _menuRepository.GetMenu();
            foreach (MenuItem item in menuList)
            {
                Console.WriteLine($"Meal Number: {item.MealNum}\n" +
                $"Meal Name: {item.Name}\n" +
                $"Description: {item.Description}\n" +
                $"Ingredients: {item.Ingredients}\n" +
                $"Price: ${item.Price}\n");
            }
        }
        private void SeedMenu()
        {
            MenuItem mealOne = new MenuItem(1, "Cereal", "An endless bowl of cereal, your choice.", "Cereal, milk,", 4.99);
            MenuItem mealTwo = new MenuItem(2, "Basic Breakfast", "Nothing more than your basic breakfast. (Eggs, bacon, toast, oatmeal.)", "Eggs, bacon, flour, yeast, baking soda, whole oats, brown sugar", 9.99);
            MenuItem mealThree = new MenuItem(1, "Pancakes", "All you can eat pancakes.", "flour, eggs, milk", 4.99);

            _menuRepository.AddItemToMenu(mealOne);
            _menuRepository.AddItemToMenu(mealTwo);
            _menuRepository.AddItemToMenu(mealThree);
        }
    }
}
