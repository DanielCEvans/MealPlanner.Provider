namespace MealPlanner.Provider.Persistence.Repositories;

public interface IRecipeIngredientRepository
{
    List<RecipeIngredientDTO> GetRecipeIngredients(List<int> recipeIds);
}