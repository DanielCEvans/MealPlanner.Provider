using MealPlanner.Provider.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Provider.Persistence.Repositories;

public class UserIngredientRepository : IUserIngredientRepository
{
    private readonly MealPlannerContext _dbContext;

    public UserIngredientRepository(MealPlannerContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddUserIngredient(UserIngredient userIngredient)
    {
        _dbContext.UserIngredients.Add(userIngredient);
        _dbContext.SaveChanges();
    }
}