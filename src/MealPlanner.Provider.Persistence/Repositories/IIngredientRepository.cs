using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Persistence.Repositories;

public interface IIngredientRepository
{
    public List<IngredientWithCategoryDTO> GetAllIngredients();
    public void AddIngredient(Ingredient ingredient);
    public void AddIngredients(List<Ingredient> ingredients);
}