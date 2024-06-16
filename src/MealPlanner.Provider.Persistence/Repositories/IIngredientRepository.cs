using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Persistence.Repositories;

public interface IIngredientRepository
{
    public List<Ingredient> GetAllIngredients();
    
    public void AddIngredient(Ingredient ingredient);
}