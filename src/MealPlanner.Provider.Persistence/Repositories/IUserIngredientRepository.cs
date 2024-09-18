using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Persistence.Repositories;

public interface IUserIngredientRepository
{
    public void AddUserIngredients(List<UserIngredient> userIngredients);

    public List<UserIngredientDTO> GetUserIngredients(int userId);
}