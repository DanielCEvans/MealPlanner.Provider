using MealPlanner.Provider.Endpoint.Models;
using MealPlanner.Provider.Persistence.Models;
using MealPlanner.Provider.Persistence.Repositories;

namespace MealPlanner.Provider.Endpoint.Services.Interfaces;

public interface IMealPlannerService
{
    List<RecipeDTO> GetAllRecipes();
    List<IngredientWithCategoryDTO> GetAllIngredients();
    List<UserIngredientInfoDTO> GetUserIngredientsAndIngredientInfo(int userId);
    void AddUserIngredients(AddUserIngredientsRequest addUserIngredientsRequest);

    List<RecipeIngredientDTO> GetShoppingList(ShoppingListRequest request);
}