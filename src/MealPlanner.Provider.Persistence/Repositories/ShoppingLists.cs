using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Persistence.Repositories;

public class ShoppingLists(MealPlannerContext dbContext) : IShoppingLists
{
    public void SaveShoppingList(ShoppingList shoppingList)
    {
        dbContext.Add(shoppingList);
        dbContext.SaveChanges();
    }
}