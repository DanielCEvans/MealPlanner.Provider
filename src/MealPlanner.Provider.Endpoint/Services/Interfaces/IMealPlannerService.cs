using MealPlanner.Provider.Endpoint.Models;
using MealPlanner.Provider.Persistence.Models;
using MealPlanner.Provider.Persistence.Repositories;

namespace MealPlanner.Provider.Endpoint.Services.Interfaces;

public interface IMealPlannerService
{
    List<RecipeDTO> GetAllRecipes();
    // void AddMeal(AddMealRequest addMealRequest);
    List<IngredientWithCategoryDTO> GetAllIngredients();
    // List<MealIngredients> GetMealIngredients(string mealName);
    // List<RequiredIngredient> GetIngredientsList(List<string> mealNames);
    // void AddIngredient(AddIngredientRequest ingredientRequest);
    void AddUserIngredient(AddUserIngredientRequest addUserIngredientRequest);

    List<RecipeIngredientDTO> GetShoppingList(ShoppingListRequest request);
}