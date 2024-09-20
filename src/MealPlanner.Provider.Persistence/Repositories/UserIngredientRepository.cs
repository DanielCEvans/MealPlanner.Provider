using MealPlanner.Provider.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Provider.Persistence.Repositories;

public class UserIngredientInfoDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Unit { get; set; }
    public string CategoryName { get; set; }
    public decimal Quantity { get; set; }
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

    public void UpdateUserIngredients(List<UserIngredient> userIngredients)
    {
        _dbContext.UserIngredients.UpdateRange(userIngredients);
        _dbContext.SaveChanges();
    }

    public List<UserIngredient> GetUserIngredients(int userId)
    {
        var userIngredients = _dbContext.UserIngredients
            .Where(ui => ui.UserId == userId).ToList();
        return userIngredients;
    }
    public List<UserIngredientInfoDTO> GetUserIngredientsAndIngredientInfo(int userId)
    {
        var userIngredients = (from ui in _dbContext.UserIngredients
            join i in _dbContext.Ingredients on ui.IngredientId equals i.Id
            join ic in _dbContext.IngredientCategories on i.CategoryId equals ic.Id
            where ui.UserId == userId
            select new UserIngredientInfoDTO()
            {
                Id = i.Id,
                Name = i.Name,
                Unit = i.Unit,
                CategoryName = ic.Name,
                Quantity = ui.Quantity
            }).ToList();
        return userIngredients;
    }

}   