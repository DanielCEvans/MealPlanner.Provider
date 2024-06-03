using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Persistence.Repositories;

public class MealIngredientRepository : IMealIngredientRepository
{
    private readonly MealPlannerContext _dbContext;

    public MealIngredientRepository(MealPlannerContext mealPlannerContext)
    {
        _dbContext = mealPlannerContext;
    }

    public List<MealIngredients> GetMealIngredients(int id)
    {
        List<MealIngredients> mealIngredients = _dbContext.MealIngredients.Where(mi => mi.MealId == id).ToList();
        return mealIngredients;
    }
}