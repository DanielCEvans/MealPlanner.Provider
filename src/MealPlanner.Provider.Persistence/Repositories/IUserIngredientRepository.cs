using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Persistence.Repositories;

public interface IUserIngredientRepository
{
    public void AddUserIngredient(UserIngredient request);

    public List<UserIngredientDTO> GetUserIngredients(int userId);
}