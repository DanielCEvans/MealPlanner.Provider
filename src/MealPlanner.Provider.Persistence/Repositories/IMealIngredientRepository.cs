using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Persistence.Repositories;

public interface IMealIngredientRepository
{
    public List<MealIngredients> GetMealIngredients(string mealName);
    public List<IngredientAndMealIngredient> GetMealIngredients(List<string> mealNames);
    public void AddMeal(List<MealIngredients> mealIngredients);
}