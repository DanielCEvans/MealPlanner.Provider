using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Persistence.Repositories;

public class MealRepository : IMealRepository
{
    private readonly MealPlannerContext _dbContext;

    public MealRepository(MealPlannerContext mealPlannerContext)
    {
        _dbContext = mealPlannerContext;
    }
    public List<Meal> GetAllMeals()
    {
        List<Meal> meals = _dbContext.Meals.ToList();

        return meals;
    }

    public void AddMeal(Meal meal)
    {
        _dbContext.Meals.Add(meal);
        _dbContext.SaveChanges();
    }
}