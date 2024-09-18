using MealPlanner.Provider.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Provider.Persistence.Repositories;

public class UserIngredientDTO
{
    public int IngredientId { get; set; }
    public decimal UserIngredientQuantity { get; set; }
}

public class UserIngredientRepository : IUserIngredientRepository
{
    private readonly MealPlannerContext _dbContext;

    public UserIngredientRepository(MealPlannerContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddUserIngredients(List<UserIngredient> userIngredients)
    {
        _dbContext.UserIngredients.AddRange(userIngredients);
        _dbContext.SaveChanges();
    }

    public List<UserIngredientDTO> GetUserIngredients(int userId)
    {
        var userIngredients = _dbContext.UserIngredients
            .Where(ui => ui.UserId == userId)
            .Select(ui => new UserIngredientDTO
            {
                IngredientId = ui.IngredientId,
                UserIngredientQuantity = ui.Quantity
            }).ToList();
        return userIngredients;
    }
}   