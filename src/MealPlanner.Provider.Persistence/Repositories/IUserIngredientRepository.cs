using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Persistence.Repositories;

public interface IUserIngredientRepository
{
    public void AddUserIngredients(List<UserIngredient> userIngredients);

    public List<UserIngredient> GetUserIngredients(int userId);
    public List<UserIngredientInfoDTO> GetUserIngredientsAndIngredientInfo(int userId);

    public void UpdateUserIngredients(List<UserIngredient> userIngredients);
}