using MealPlanner.Provider.Endpoint.Models;
using MealPlanner.Provider.Endpoint.Services.Interfaces;
using MealPlanner.Provider.Persistence.Models;
using MealPlanner.Provider.Persistence.Repositories;

namespace MealPlanner.Provider.Endpoint.Services;

public class MealPlannerService : IMealPlannerService
{
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IRecipeRepository _recipeRepository;
    private readonly IUserIngredientRepository _userIngredientRepository;

    private readonly IRecipeIngredientRepository _recipeIngredientRepository;

    public MealPlannerService(
        IIngredientRepository ingredientRepository,
        IRecipeRepository recipeRepository,
        IUserIngredientRepository userIngredientRepository,
        IRecipeIngredientRepository recipeIngredientRepository
        )
    {
        _ingredientRepository = ingredientRepository;
        _recipeRepository = recipeRepository;
        _userIngredientRepository = userIngredientRepository;
        _recipeIngredientRepository = recipeIngredientRepository;
    }
    
    public List<RecipeDTO> GetAllRecipes()
    {
        return _recipeRepository.GetAllRecipes(); 
    }

    public List<IngredientWithCategoryDTO> GetAllIngredients()
    {
        return _ingredientRepository.GetAllIngredients();
    }

    public void AddUserIngredient(AddUserIngredientRequest addUserIngredientRequest)
    {
        var userIngredient = new UserIngredient
        {
            UserId = addUserIngredientRequest.UserId,
            IngredientId = addUserIngredientRequest.IngredientId,
            Quantity = addUserIngredientRequest.Quantity
        };
        _userIngredientRepository.AddUserIngredient(userIngredient);
    }

    public List<IngredientWithCategoryDTO> GetShoppingList(ShoppingListRequest request)
    {
        // Get all ingredients from the RecipeIngredients table for each selected recipe
        
        // {
        //     recipeID,
        //     ingredientID,
        //     ingredientName
        //     quantity,
        //     category
        // }
        var recipeIngredients = _recipeIngredientRepository.GetRecipeIngredients(request.RecipeIds);
        
        // Get all the ingredients from the UserIngredients table for each matching ingredient from the Recipe Ingredients (use ingredientId)
        
        // {
        //     userId,
        //     ingredientID,    
        //     quantity,    
        // }
        var userIngredients = _userIngredientRepository.GetUserIngredients(request.UserId);
        // Subtract the recipe ingredients from the user ingredients to determine the shopping list
        // Note, you might have duplicates in the recipe ingredients list if there a recipes requiring the same ingredient
        // these need to be added up
        
        // {
        //     userId,
        //     [ingredientID,
        //      ingredientName,
        //      quantity,    
        //      category,]    
        // }
        
        // add the shopping list to the Shopping List table (pass in user ID)
        
        // add the shopping list ingredients to the Shopping List Items table
        // add all ingredients and returned shopping list id to table
        
        // return the shopping list
        
        throw new NotImplementedException();
    }

    // public List<MealIngredients> GetMealIngredients (string mealName)
    // {
    //     return _mealIngredientRepository.GetMealIngredients(mealName);
    // }
    //
    // public List<RequiredIngredient> GetIngredientsList(List<string> mealNames)
    // {
    //     List<IngredientAndMealIngredient> mealIngredients = _mealIngredientRepository.GetMealIngredients(mealNames);
    //
    //     Dictionary<string, IngredientAndMealIngredient> ingredientsListAsDictionary =
    //         GetIngredientsListAsDictionary(mealIngredients);
    //
    //     List<RequiredIngredient> finalIngredientsList = GetFinalIngredientsList(ingredientsListAsDictionary);
    //
    //     return finalIngredientsList;
    // }

    // public void AddIngredient(AddIngredientRequest ingredientRequest)
    // {
    //     Ingredient ingredient = _ingredientMapper.ToPersistence(ingredientRequest);
    //     _ingredientRepository.AddIngredient(ingredient);
    // }

    // public void AddMeal(AddMealRequest addMealRequest)
    // {
    //     Meal meal = _mealMapper.AddMealRequestToMealPersistence(addMealRequest);
    //     _mealRepository.AddMeal(meal);
    //     
    //     List<Ingredient> ingredients = _ingredientMapper.ToPersistence(addMealRequest.MealIngredients);
    //     _ingredientRepository.AddIngredients(ingredients);
    //
    //     List<MealIngredients> mealIngredients = _mealIngredientMapper.ToPersistance(addMealRequest);
    //     _mealIngredientRepository.AddMeal(mealIngredients);
    // }

    // private List<RequiredIngredient> GetFinalIngredientsList(Dictionary<string, IngredientAndMealIngredient> ingredientsListAsDictionary)
    // {
    //     List<RequiredIngredient> finalIngredientsList = new List<RequiredIngredient>();
    //
    //     foreach (var ingredient in ingredientsListAsDictionary.Values)
    //     {
    //         if (ingredient.MealIngredientAmount > ingredient.KitchenIngredientAmount)
    //         {
    //             RequiredIngredient requiredIngredient = new RequiredIngredient
    //             {
    //                 IngredientName = ingredient.IngredientName,
    //                 RequiredIngredientAmount = ingredient.MealIngredientAmount - ingredient.KitchenIngredientAmount,
    //                 MeasurementUnit = ingredient.MeasurementUnit,
    //                 IngredientCategory = ingredient.IngredientCategory
    //             };
    //             
    //             finalIngredientsList.Add(requiredIngredient);
    //             
    //         }
    //     }
    //     return finalIngredientsList.OrderBy(ingredient => ingredient.IngredientCategory).ToList();
    // }

    // private Dictionary<string, IngredientAndMealIngredient> GetIngredientsListAsDictionary(
    //     List<IngredientAndMealIngredient> mealIngredients)
    // {
    //     Dictionary<string, IngredientAndMealIngredient> ingredientsListAsDictionary = new Dictionary<string, IngredientAndMealIngredient>();
    //      
    //     foreach (IngredientAndMealIngredient mealIngredient in mealIngredients)
    //     {
    //         if (ingredientsListAsDictionary.ContainsKey(mealIngredient.IngredientName))
    //         {
    //             ingredientsListAsDictionary[mealIngredient.IngredientName].MealIngredientAmount +=
    //                 mealIngredient.MealIngredientAmount;
    //         }
    //         else
    //         {
    //             ingredientsListAsDictionary.Add(mealIngredient.IngredientName, mealIngredient);
    //         }
    //     }
    //     return ingredientsListAsDictionary;
    // }
}
