using System;
using System.Collections.Generic;
using System.Linq;

namespace Cafe
{
    internal class ProgramUI
    {
        private IMenuRepository _menuRepo;
        public ProgramUI()
        {
            _menuRepo = new MenuRepository();
        }
        internal void Run()
        {
            SeedData();
            Console.WriteLine("Welcome to the Cafe! Press any key to continue.");
            Console.ReadKey();
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                MenuPrompt();
                isRunning = Menu();
            }
        }
        private bool Menu()
        {
            switch (VerifyIntput())
            {
                case 1:
                    PrintCurrentMenu();
                    return true;
                case 2:
                    AddNewItem();
                    return true;
                case 3:
                    RemoveMenuItem();
                    return true;
                case 4:
                    return false;
                default:
                    return true;
            }
        }
        private void RemoveMenuItem()
        {
            PrintCurrentMenu();
            Console.WriteLine("\nWhat menu item would you like to remove. Please enter the Meal Number.");
            int intput = VerifyIntput();
            bool success = _menuRepo.RemoveMealFromMenu(intput);
            OperationStatus(success);
        }
        private void AddNewItem()
        {
            Console.WriteLine("Please enter the following information\n" +
                "Meal Price: ");
            var price = VerifyDecimalIntput();

            Console.WriteLine("Meal Name: ");
            var name = Console.ReadLine();

            Console.WriteLine("Meal Description: ");
            var description = Console.ReadLine();

            var ingredients = AddIngredients();

            var meal = new Meal(price, name, description, ingredients);

            bool success = _menuRepo.AddMenuItem(meal);

            OperationStatus(success);
        }
        private IEnumerable<string> AddIngredients()
        {
            Console.WriteLine("Please enter the ingredients and separate with comma, space, or /");
            string ingredients = Console.ReadLine();
            return ingredients.Split(',', ' ', '/').ToList();
        }
        private void PrintCurrentMenu()
        {
            Console.Clear();
            Console.WriteLine("Current Menu");
            IDictionary<int, IMeal> menu = _menuRepo.GetMenu();

            foreach (KeyValuePair<int, IMeal> meal in menu)
            {
                Console.WriteLine($"\nMeal Number: {meal.ToString().Trim('[',']', ',')}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void MenuPrompt()
        {
            Console.WriteLine("Please select from the following options.\n\t" +
                "1. Current Menu\n\t" +
                "2. Add new Menu Item \n\t" +
                "3. Remove Menu Item \n\t" +
                "4. Exit");
        }
        private int VerifyIntput()
        {
            bool success = false;
            int intput = 0;
            while (!success)
            {
                if (int.TryParse(Console.ReadLine(), out intput))
                {
                    success = true;
                }
                else
                {
                    Console.WriteLine("Invalid Input please try again.");
                }
            }
            return intput;
        }
        private decimal VerifyDecimalIntput()
        {
            bool success = false;
            decimal input = 0m;
            while (!success)
            {
                if (decimal.TryParse(Console.ReadLine(), out input))
                {
                    success = true;
                }
                else
                {
                    Console.WriteLine("Invalid Input please try again.");

                }
            }
            return input;
        }
        private static void OperationStatus(bool success)
        {
            Console.Clear();
            if (success)
            {
                Console.WriteLine("\nOperation was successful. Press any key to continue.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nOperation was unsuccessful, please try again. Press any key to continue.");
                Console.ReadKey();
            }
        }
        private void SeedData()
        {
            var meal = new Meal(6.99m, "spaghetti", "italian", new List<string> { "pasta", "meat", "tomato" });
            var mealOne = new Meal(16.99m, "fancy spaghetti", "fancy italian", new List<string> { "pasta", "meat", "tomato" });
            var mealTwo = new Meal(1.99m, "cheap spaghetti", "cheap italian made with ramen", new List<string> { "pasta", "meat", "tomato", "ramen" });
            var mealThree = new Meal(6.99m, "spam musubi", "Hawaiian", new List<string> { "rice", "seaweed", "spam", "fudikake", "teriyaki" });
            var mealFour = new Meal(6.99m, "spaghetti alfredo", "italian", new List<string> { "pasta", "meat", "alfredo" });

            _menuRepo.AddMenuItem(meal);
            _menuRepo.AddMenuItem(mealOne);
            _menuRepo.AddMenuItem(mealTwo);
            _menuRepo.AddMenuItem(mealThree);
            _menuRepo.AddMenuItem(mealFour);
        }
    }
}