using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoles
{
    class ProgramUI_Menu
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
                Console.WriteLine("What would you like to do? \n\n" +
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
                        CreateMenuItem();
                        break;
                    case "3":
                        RemoveMenuItem();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        continueRun = false;
                        break;
                    default:
                        Console.WriteLine("That is not a valid option");
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
            MenuItem mealThree = new MenuItem(3, "Pancakes", "All you can eat pancakes.", "flour, eggs, milk", 4.99);

            _menuRepository.AddItemToMenu(mealOne);
            _menuRepository.AddItemToMenu(mealTwo);
            _menuRepository.AddItemToMenu(mealThree);
        }

        private void CreateMenuItem()
        {
            Console.Clear();

            MenuItem newItem = new MenuItem();
            Console.WriteLine("Enter the meal number");
            newItem.MealNum = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter the meal name");
            newItem.Name =Console.ReadLine();
            Console.WriteLine("Enter the meal description");
            newItem.Description = Console.ReadLine();
            Console.WriteLine("Enter the ingredients of the meal (Ex. Pasta, water, seasonings)");
            newItem.Ingredients = Console.ReadLine();
            Console.WriteLine("Enter the price of the meal");
            newItem.Name = Console.ReadLine();

            _menuRepository.AddItemToMenu(newItem);
        }

        private void RemoveMenuItem()
        {
            DisplayMenu();
            Console.WriteLine("What is the number of the meal you want to delete?");
            int input = Convert.ToInt32(Console.ReadLine());

            _menuRepository.RemoveMenuItem(input);
        }
    }
}
