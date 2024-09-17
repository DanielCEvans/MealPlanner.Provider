using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Persistence.Repositories;

public class ShoppingLists : IShoppingLists
{
    private readonly MealPlannerContext _dbContext;

    public ShoppingLists(MealPlannerContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void SaveShoppingList(ShoppingList shoppingList)
    {
        _dbContext.Add(shoppingList);
        _dbContext.SaveChanges();
    }
}