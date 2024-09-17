using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Persistence.Repositories;



public class RecipeRepository : IRecipeRepository
{
    private readonly MealPlannerContext _dbContext;

    public RecipeRepository(MealPlannerContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Recipe> GetAllRecipes()
    {
        return _dbContext.Recipes.ToList();
    }
}