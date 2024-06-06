using MealPlanner.Provider.Endpoint.Services.Interfaces;
using MealPlanner.Provider.Persistence.Models;
using MealPlanner.Provider.Persistence.Repositories;

namespace MealPlanner.Provider.Endpoint.Services;

public class MealPlannerService : IMealPlannerService
{
    private readonly IMealRepository _mealRepository;
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IMealIngredientRepository _mealIngredientRepository;

    public MealPlannerService(
        IMealRepository mealRepository, 
        IIngredientRepository ingredientRepository, 
        IMealIngredientRepository mealIngredientRepository)
    {
        _mealRepository = mealRepository;
        _ingredientRepository = ingredientRepository;
        _mealIngredientRepository = mealIngredientRepository;
    }
    public List<Meal> GetAllMeals()
    {
        return _mealRepository.GetAllMeals();
    }

    public List<Ingredient> GetAllIngredients()
    {
        return _ingredientRepository.GetAllIngredients();
    }

    public List<MealIngredients> GetMealIngredients (int id)
    {
        return _mealIngredientRepository.GetMealIngredients(id);
    }

    public Dictionary<string, int> GetIngredientsList(List<int> mealIds)
    {
        List<MealIngredients> allMealIngredients = _mealIngredientRepository.GetMealIngredients(mealIds);
        
        Dictionary<string, int> ingredientsList = new Dictionary<string, int>();

        foreach (MealIngredients mealIngredient in allMealIngredients)
        {
            if (ingredientsList.ContainsKey(mealIngredient.IngredientName))
            {
                ingredientsList[mealIngredient.IngredientName] += (mealIngredient.IngredientAmount);
            }
            else
            {
                ingredientsList.Add(mealIngredient.IngredientName, mealIngredient.IngredientAmount);
            }
        }
        return ingredientsList;
    }
}