using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Persistence.Repositories;

public class RecipeDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
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
            Id = r.Id,
            Name = r.Name,
            Description = r.Description
        }).ToList();
    }

    public void AddRecipe(Recipe recipe)
    {
        _dbContext.Recipes.Add(recipe);
        _dbContext.SaveChanges();
    }
}