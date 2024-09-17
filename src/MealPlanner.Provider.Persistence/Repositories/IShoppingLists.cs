using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Persistence.Repositories;

public interface IShoppingLists
{
    public void SaveShoppingList(ShoppingList shoppingList);
}