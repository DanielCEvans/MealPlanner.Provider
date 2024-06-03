using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Persistence.Repositories;

public interface IMealIngredientRepository
{
    public List<MealIngredients> GetMealIngredients(int id);
    public List<MealIngredients> GetMealIngredients(List<int> mealIds);
}