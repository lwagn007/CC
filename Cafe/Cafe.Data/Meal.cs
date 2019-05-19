using System.Collections.Generic;

namespace Cafe
{
    public class Meal : IMeal
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Ingredients { get; set; }
        public Meal(decimal price, string name, string description, IEnumerable<string> ingredients)
        {
            Price += price;
            Name = name;
            Description = description;
            Ingredients = ingredients;
        }
        public Meal()
        {

        }
        public override string ToString()
        {
            string ingredients = "Ingredients: ";
            foreach(string ingredient in Ingredients)
            {
                ingredients += $"{ingredient} - ";
            }
            return $"\nMeal Price: {Price}\nMeal Name: {Name}\nMeal Description: {Description}\n{ingredients}\n";
        }
    }
}