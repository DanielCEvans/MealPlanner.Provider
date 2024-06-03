using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Endpoint.Services.Interfaces;

public interface IMealPlannerService
{
    List<Meal> GetAllMeals();
    List<Ingredient> GetAllIngredients();
    List<MealIngredients> GetMealIngredients(int id);
    List<MealIngredients> GetMeals(List<int> mealIds);
}