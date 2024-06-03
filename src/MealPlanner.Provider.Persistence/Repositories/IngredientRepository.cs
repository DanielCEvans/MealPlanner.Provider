using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Persistence.Repositories;

public class IngredientRepository : IIngredientRepository
{
    private readonly MealPlannerContext _dbContext;

    public IngredientRepository(MealPlannerContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Ingredient> GetAllIngredients()
    {
        List<Ingredient> ingredients = _dbContext.Ingredients.ToList();
        
        return ingredients;
    }
}