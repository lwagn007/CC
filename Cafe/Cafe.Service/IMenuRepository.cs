using System.Collections.Generic;

namespace Cafe
{
    public interface IMenuRepository
    {
        bool AddMenuItem(IMeal meal);
        IDictionary<int, IMeal> GetMenu();
        bool RemoveMealFromMenu(int id);
        IMeal GetMeal(int id);
        void ResetMenuKeys();
    }
}