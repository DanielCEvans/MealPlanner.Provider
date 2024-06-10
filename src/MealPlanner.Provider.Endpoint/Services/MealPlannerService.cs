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
        IMealIngredientRepository mealIngredientRepository
        )
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

    public List<IngredientAndMealIngredient> GetIngredientsList(List<int> mealIds)
    {
        List<IngredientAndMealIngredient> mealIngredients = _mealIngredientRepository.GetMealIngredients(mealIds);
        
        Dictionary<string, IngredientAndMealIngredient> ingredientsListAsDictionary = new Dictionary<string, IngredientAndMealIngredient>();
         
        foreach (IngredientAndMealIngredient mealIngredient in mealIngredients)
        {
            if (ingredientsListAsDictionary.ContainsKey(mealIngredient.IngredientName))
            {
                ingredientsListAsDictionary[mealIngredient.IngredientName].MealIngredientAmount +=
                    mealIngredient.MealIngredientAmount;
            }
            else
            {
                ingredientsListAsDictionary.Add(mealIngredient.IngredientName, mealIngredient);
            }
        }

        List<IngredientAndMealIngredient> finalIngredientsList = new List<IngredientAndMealIngredient>();

        foreach (var ingredient in ingredientsListAsDictionary.Values)
        {
            if (ingredient.MealIngredientAmount > ingredient.KitchenIngredientAmount)
            {
                finalIngredientsList.Add(ingredient);
            }
        }

        // what about updating the ingredient amount in the database after generating the ingredients list?
        // probably should occur after cooking all of the meals?
        
        return finalIngredientsList;
    }
}
