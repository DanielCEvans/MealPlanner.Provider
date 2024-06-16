using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Persistence.Repositories;

public class MealIngredientRepository : IMealIngredientRepository
{
    private readonly MealPlannerContext _dbContext;

    public MealIngredientRepository(MealPlannerContext mealPlannerContext)
    {
        _dbContext = mealPlannerContext;
    }

    public List<MealIngredients> GetMealIngredients(string mealName)
    {
        List<MealIngredients> mealIngredients = _dbContext.MealIngredients.Where(mi => mi.MealName == mealName).ToList();
        return mealIngredients;
    }
    
    public List<IngredientAndMealIngredient> GetMealIngredients(List<int> mealIds)
    {
        var query = from mealIngredient in _dbContext.MealIngredients
            join ingredient in _dbContext.Ingredients on mealIngredient.IngredientId equals ingredient.IngredientId
            // where mealIds.Contains(mealIngredient.MealId)
            select new IngredientAndMealIngredient()
            {
                IngredientName = ingredient.IngredientName,
                KitchenIngredientAmount = ingredient.IngredientAmount,
                MealIngredientAmount = mealIngredient.MealIngredientAmount,
                MeasurementUnit = ingredient.MeasurementUnit,
                IngredientCategory = ingredient.IngredientCategory
            };
        return query.ToList();
    }
}