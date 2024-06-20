using MealPlanner.Provider.Endpoint.Mappers;
using MealPlanner.Provider.Endpoint.Models;
using MealPlanner.Provider.Endpoint.Models.DTOs;
using MealPlanner.Provider.Endpoint.Services.Interfaces;
using MealPlanner.Provider.Persistence.Models;
using MealPlanner.Provider.Persistence.Repositories;

namespace MealPlanner.Provider.Endpoint.Services;

public class MealPlannerService : IMealPlannerService
{
    private readonly IMealRepository _mealRepository;
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IMealIngredientRepository _mealIngredientRepository;
    private readonly IIngredientMapper _ingredientMapper;
    private readonly IMealMapper _mealMapper;

    public MealPlannerService(
        IMealRepository mealRepository, 
        IIngredientRepository ingredientRepository, 
        IMealIngredientRepository mealIngredientRepository,
        IIngredientMapper ingredientMapper,
        IMealMapper mealMapper
        )
    {
        _mealRepository = mealRepository;
        _ingredientRepository = ingredientRepository;
        _mealIngredientRepository = mealIngredientRepository;
        _ingredientMapper = ingredientMapper;
        _mealMapper = mealMapper;
    }
    public List<Meal> GetAllMeals()
    {
        return _mealRepository.GetAllMeals();
    }

    public List<Ingredient> GetAllIngredients()
    {
        return _ingredientRepository.GetAllIngredients();
    }

    public List<MealIngredients> GetMealIngredients (string mealName)
    {
        return _mealIngredientRepository.GetMealIngredients(mealName);
    }

    public List<RequiredIngredient> GetIngredientsList(List<string> mealNames)
    {
        List<IngredientAndMealIngredient> mealIngredients = _mealIngredientRepository.GetMealIngredients(mealNames);

        Dictionary<string, IngredientAndMealIngredient> ingredientsListAsDictionary =
            GetIngredientsListAsDictionary(mealIngredients);

        List<RequiredIngredient> finalIngredientsList = GetFinalIngredientsList(ingredientsListAsDictionary);

        return finalIngredientsList;
    }

    public void AddIngredient(AddIngredientRequest ingredientRequest)
    {
        Ingredient ingredient = _ingredientMapper.ToPersistence(ingredientRequest);
        _ingredientRepository.AddIngredient(ingredient);
    }

    public void AddIngredients(List<MealIngredient> mealIngredients)
    {
        List<Ingredient> ingredients = _ingredientMapper.ToPersistence(mealIngredients);
        _ingredientRepository.AddIngredients(ingredients);
    }

    public void AddMeal(AddMealRequest addMealRequest)
    {
        Meal meal = _mealMapper.AddMealRequestToMealPersistence(addMealRequest);
        _mealRepository.AddMeal(meal);
    }

    private List<RequiredIngredient> GetFinalIngredientsList(Dictionary<string, IngredientAndMealIngredient> ingredientsListAsDictionary)
    {
        List<RequiredIngredient> finalIngredientsList = new List<RequiredIngredient>();

        foreach (var ingredient in ingredientsListAsDictionary.Values)
        {
            if (ingredient.MealIngredientAmount > ingredient.KitchenIngredientAmount)
            {
                RequiredIngredient requiredIngredient = new RequiredIngredient
                {
                    IngredientName = ingredient.IngredientName,
                    RequiredIngredientAmount = ingredient.MealIngredientAmount - ingredient.KitchenIngredientAmount,
                    MeasurementUnit = ingredient.MeasurementUnit,
                    IngredientCategory = ingredient.IngredientCategory
                };
                
                finalIngredientsList.Add(requiredIngredient);
                
            }
        }
        return finalIngredientsList.OrderBy(ingredient => ingredient.IngredientCategory).ToList();
    }

    private Dictionary<string, IngredientAndMealIngredient> GetIngredientsListAsDictionary(
        List<IngredientAndMealIngredient> mealIngredients)
    {
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
        return ingredientsListAsDictionary;
    }
}
