using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Persistence.Repositories;

public interface IRecipeRepository
{
    public List<RecipeDTO> GetAllRecipes();
}