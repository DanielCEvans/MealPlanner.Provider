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

    public List<MealIngredients> GetMealIngredients(List<int> mealIds)
    {
        // Is this where we need to do a DTO? getting data from the database in the service layer
        // maybe in the service layer?
        // this method will return all of th data -> it is being mapped 
        List<MealIngredients> mealIngredients = _dbContext.MealIngredients.Where(mi => mealIds.Contains(mi.MealId)).ToList();
        return mealIngredients;
    }
}