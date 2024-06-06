using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Endpoint.Services.Interfaces;

public interface IMealPlannerService
{
    List<Meal> GetAllMeals();
    List<Ingredient> GetAllIngredients();
    List<MealIngredients> GetMealIngredients(int id);
    Dictionary<string, int> GetIngredientsList(List<int> mealIds);
}