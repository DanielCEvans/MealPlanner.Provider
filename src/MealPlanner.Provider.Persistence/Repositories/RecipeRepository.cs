using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Persistence.Repositories;

public class RecipeDTO
{
    public int RecipeId { get; set; }
    public string RecipeName { get; set; }
    public string RecipeDescription { get; set; }
}

public class RecipeRepository : IRecipeRepository
{
    private readonly MealPlannerContext _dbContext;

    public RecipeRepository(MealPlannerContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<RecipeDTO> GetAllRecipes()
    {
        return _dbContext.Recipes.Select(r => new RecipeDTO
        {
            RecipeId = r.RecipeId,
            RecipeName = r.RecipeName,
            RecipeDescription = r.Description
        }).ToList();
    }
}