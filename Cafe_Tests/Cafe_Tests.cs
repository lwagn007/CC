using System;
using System.Collections.Generic;
using Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cafe_Tests
{
    [TestClass]
    public class Cafe_Tests
    {
        IMenuRepository _menuRepo;
        [TestInitialize]
        public void Arrange()
        {
            _menuRepo = new MenuRepository();
            SeedData();
        }
        [TestMethod]
        public void AddMenuItem_AddingItem_BoolShouldBeTrueAndCountCorrect()
        {
            //Arrange
            Arrange();
            //Act
            var expected = true;
            var actual = _menuRepo.AddMenuItem(new Meal(6.99m, "spaghetti", "italian", new List<string> { "pasta", "meat", "tomato" }));

            var expectedCount = 6;
            var actualCount = _menuRepo.GetMenu().Count;
            Console.WriteLine(actualCount);
            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedCount, actualCount);
        }
        [TestMethod]
        public void AddMenuItem_AddingItemWithEmptyDescription_BoolShouldBeFalse()
        {
            //Arrange
            Arrange();
            //Act
            var expected = false;
            var actual = _menuRepo.AddMenuItem(new Meal(0, "spaghetti", " ", new List<string> { "pasta", "meat", "tomato" }));
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetMenuItem_ShouldReturnSelectedMeal_MealsShouldBeTheSame()
        {
            //Arrange
            Arrange();
            //Act
            var expected = new Meal(6.99m, "spaghetti alfredo", "italian", new List<string> { "pasta", "meat", "alfredo" });
            var actual = _menuRepo.GetMeal(5);
            //Assert
            Assert.ReferenceEquals(expected, actual);
        }
        [TestMethod]
        public void GetMenuItem_ShouldNotReturnSelectedMeal_MealsShouldNotBeTheSame()
        {
            //Arrange
            Arrange();
            //Act
            var expected = new Meal();
            var actual = _menuRepo.GetMeal(5);
            //Assert
            Assert.AreNotSame(expected, actual);
        }
        [TestMethod]
        public void RemoveMenuItem_ShouldRemoveMealAndRenumberKeys_CountShouldBeCorrect()
        {
            //Arrange
            Arrange();
            _menuRepo.RemoveMealFromMenu(5);
            //Act
            var expected = 4;
            var actual = _menuRepo.GetMenu().Count;

            var expectedTwo = new Meal(1.99m, "cheap spaghetti", "cheap italian made with ramen", new List<string> { "pasta", "meat", "tomato", "ramen" });
            var actualTwo = _menuRepo.GetMeal(3);
            //Assert
            Assert.AreNotSame(expected, actual);
            Assert.ReferenceEquals(expectedTwo, actualTwo);
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
