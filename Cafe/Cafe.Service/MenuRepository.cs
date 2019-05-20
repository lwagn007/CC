using System;
using System.Collections.Generic;
using System.Linq;

namespace Cafe
{
    public class MenuRepository : IMenuRepository
    {
        IDictionary<int, IMeal> _menu;
        private int _menuId;
        public MenuRepository()
        {
            _menu = new Dictionary<int, IMeal>();
            _menuId = 0;
        }
        public bool AddMenuItem(IMeal meal)
        {
            if (meal.Price != 0 && !string.IsNullOrWhiteSpace(meal.Name) && !string.IsNullOrWhiteSpace(meal.Description) && meal.Ingredients.ToList().Count > 0)
            {
                _menuId++;
                _menu.Add(_menuId, meal);
                return true;
            }
            else
                return false;
        }
        public IMeal GetMeal(int id)
        {
            if (id > 0)
            {
                foreach (KeyValuePair<int, IMeal> meal in _menu)
                {
                    if (meal.Key == id)
                    {
                        return meal.Value;
                    }
                }
            }
            return new Meal();
        }
        public IDictionary<int, IMeal> GetMenu()
        {
            return _menu;
        }
        public bool RemoveMealFromMenu(int id)
        {
            if (id > 0)
            {
                foreach (KeyValuePair<int, IMeal> meal in _menu)
                {
                    if (meal.Key == id)
                    {
                        _menu.Remove(meal);
                        ResetMenuKeys();
                        return true;
                    }
                }
            }
            return false;
        }
        public void ResetMenuKeys()
        {
            IDictionary<int, IMeal> newMenu = new Dictionary<int, IMeal>();
            _menuId = 1;
            foreach (KeyValuePair<int, IMeal> meal in _menu)
            {
                int newId = _menuId++;
                newMenu.Add(newId, meal.Value);
            }
            _menu = newMenu;
        }
    }
}