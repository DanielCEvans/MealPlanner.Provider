using MealPlanner.Provider.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Provider.Persistence.Repositories;

public class IngredientRepository : IIngredientRepository
{
    private readonly MealPlannerContext _dbContext;

    public IngredientRepository(MealPlannerContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Ingredient> GetAllIngredients()
    {
        return _dbContext.Ingredients.ToList();
    }

    public void AddIngredient(Ingredient ingredient)
    {
        _dbContext.Ingredients.Add(ingredient);
        _dbContext.SaveChanges();
    }

    public void AddIngredients(List<Ingredient> ingredients)
    {
        foreach (var ingredient in ingredients)
        {
            try
            {
                _dbContext.Ingredients.Add(ingredient);
                _dbContext.SaveChanges();
            }
            catch (DbUpdateException)
            {
                Console.WriteLine("Ingredient already exists, continuing to next ingredient");
                _dbContext.Entry(ingredient).State = EntityState.Detached;
            }
        }
    }
}