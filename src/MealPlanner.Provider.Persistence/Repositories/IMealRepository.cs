using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Persistence.Repositories;

public interface IMealRepository
{
    public List<Meal> GetAllMeals();
    public void AddMeal(Meal meal);
}