using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{

    [TestClass]
    public class CafeTests
    {
        MenuRepository _menu = new MenuRepository();

        [TestMethod]
        public void AddMenuItemTest()
        {
            MenuItem mealOne = new MenuItem();
            mealOne.MealNum = 1;
            mealOne.Name = "Cereal";
            mealOne.Description = "An endless bowl of cereal of your choosing. Also comes with your choice of coffee, juice, or water.";
            mealOne.Price = 4.99;

            _menu.AddItemToMenu(mealOne);
            bool wasAdded = _menu.AddItemToMenu(mealOne);

            Assert.IsTrue(wasAdded);

        }

    }
}
