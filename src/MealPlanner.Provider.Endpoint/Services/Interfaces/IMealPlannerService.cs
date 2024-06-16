using MealPlanner.Provider.Endpoint.Models.DTOs;
using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Endpoint.Services.Interfaces;

public interface IMealPlannerService
{
    List<Meal> GetAllMeals();
    List<Ingredient> GetAllIngredients();
    List<MealIngredients> GetMealIngredients(string mealName);
    List<RequiredIngredient> GetIngredientsList(List<int> mealIds);
}