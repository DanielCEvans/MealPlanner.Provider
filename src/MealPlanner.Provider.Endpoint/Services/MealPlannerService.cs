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

    public List<string> GetIngredientsList(List<int> mealIds)
    {
        List<MealIngredients> allMealIngredients = _mealIngredientRepository.GetMealIngredients(mealIds);
        
        Dictionary<string, List<string>> ingredientsList = new Dictionary<string, List<string>>();

        foreach (MealIngredients mealIngredient in allMealIngredients)
        {
            if (ingredientsList.ContainsKey(mealIngredient.IngredientName))
            {
                ingredientsList[mealIngredient.IngredientName].Add(mealIngredient.IngredientAmount);
            }
            else
            {
                ingredientsList.Add(mealIngredient.IngredientName, new List<string> {mealIngredient.IngredientAmount});
            }
        }
        return ingredientsList.Values.SelectMany(list => list).ToList();
    }
}