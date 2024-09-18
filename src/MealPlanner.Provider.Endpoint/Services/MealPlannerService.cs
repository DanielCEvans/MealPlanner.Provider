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
    private readonly IShoppingLists _shoppingListsRepository;

    public MealPlannerService(
        IIngredientRepository ingredientRepository,
        IRecipeRepository recipeRepository,
        IUserIngredientRepository userIngredientRepository,
        IRecipeIngredientRepository recipeIngredientRepository,
        IShoppingLists shoppingListsRepository
        )
    {
        _ingredientRepository = ingredientRepository;
        _recipeRepository = recipeRepository;
        _userIngredientRepository = userIngredientRepository;
        _recipeIngredientRepository = recipeIngredientRepository;
        _shoppingListsRepository = shoppingListsRepository;
    }
    
    public List<RecipeDTO> GetAllRecipes()
    {
        return _recipeRepository.GetAllRecipes(); 
    }

    public List<IngredientWithCategoryDTO> GetAllIngredients()
    {
        return _ingredientRepository.GetAllIngredients();
    }

    public void AddUserIngredients(AddUserIngredientsRequest addUserIngredientsRequest)
    {
        var userIngredients = new List<UserIngredient>();
        var userId = addUserIngredientsRequest.UserId;
        
        foreach (var ingredient in addUserIngredientsRequest.Ingredients)
        {
            userIngredients.Add(new UserIngredient
            {
                UserId = userId,
                IngredientId = ingredient.IngredientID,
                Quantity = ingredient.Quantity
            });
        }
        
        _userIngredientRepository.AddUserIngredients(userIngredients);
    }

    public List<RecipeIngredientDTO> GetShoppingList(ShoppingListRequest request)
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
        Dictionary<int, RecipeIngredientDTO> recipeIngredientsDictionary = new Dictionary<int, RecipeIngredientDTO>();
        // multiple recipes can have the same ingredient which is why we need to check if the ingredient has already 
        // been added to the dictionary
        foreach (var ingredient in recipeIngredients)
        {
            int ingredientId = ingredient.IngredientId;
            
            if (recipeIngredientsDictionary.ContainsKey(ingredientId))
            {
                recipeIngredientsDictionary[ingredientId].RecipeIngredientQuantity += ingredient.RecipeIngredientQuantity;
            }
            else
            {
                recipeIngredientsDictionary[ingredientId] = ingredient;
            }
        }
        
        // Get all the ingredients from the UserIngredients table for each matching ingredient from the Recipe Ingredients (use ingredientId)
        
        // {
        //     userId,
        //     ingredientID,    
        //     quantity,    
        // }
        var userIngredients = _userIngredientRepository.GetUserIngredients(request.UserId);
        Dictionary<int, UserIngredientDTO> userIngredientsDictionary = new Dictionary<int, UserIngredientDTO>();
        // we know a user cannot have multiple of the same ingredients in the 'fridge' at once
        foreach (var ingredient in userIngredients)
        {
            userIngredientsDictionary[ingredient.IngredientId] = ingredient;
        }
        
        // Subtract the recipe ingredients from the user ingredients to determine the shopping list
        // {
        //     userId,
        //     [ingredientID,
        //      ingredientName,
        //      quantity,    
        //      category,]    
        // }
        
        // for each ingredient in the recipe ingredients, it is assumed that the ingredient will be consumed
        // therefore, even if the recipe ingredient is not required and doesn't make it onto the list, the amount of the ingredient
        // in the userIngredients table needs to be updated.
        //
        // for each ingredient in recipe ingredients, check if ingredient is in user ingredients and if so, 
        // subtract the amount in the 'fridge' from the required amount
        
        // for each ingredient in the recipe ingredients list, if the ingredient amount > 0, this ingredient goes onto the list
        
        // add the shopping list to the Shopping List table (pass in user ID)
        
        // add the shopping list ingredients to the Shopping List Items table
        // add all ingredients and returned shopping list id to table
        
        // update the user ingredients table by specifying the new amount after generating the list. 
        // e.g. if 1000grams of flour and we require 400grams, amount in the database should be 600grams
        // return the shopping list

        foreach (var recipeIngredient in recipeIngredientsDictionary)
        {
            int ingredientId = recipeIngredient.Key;
            if (userIngredientsDictionary.ContainsKey(ingredientId))
            {
                recipeIngredient.Value.RecipeIngredientQuantity -=
                    userIngredientsDictionary[ingredientId].UserIngredientQuantity;

                userIngredientsDictionary[ingredientId].UserIngredientQuantity -=
                    recipeIngredient.Value.RecipeIngredientQuantity;
            }
        }

        List<RecipeIngredientDTO> shoppingList = new List<RecipeIngredientDTO>();

        foreach (var ingredient in recipeIngredientsDictionary.Values)
        {
            if (ingredient.RecipeIngredientQuantity > 0)
            {
                shoppingList.Add(ingredient);
            }
        }
        
        // save shopping list to database
        var databaseShoppingList = new ShoppingList
        {
            GeneratedDate = DateTime.UtcNow,
            UserId = request.UserId,
            ShoppingListItems = new List<ShoppingListItem>(),
        };

        foreach (var ingredient in shoppingList)
        {
            databaseShoppingList.ShoppingListItems.Add(new ShoppingListItem
            {
                IngredientId = ingredient.IngredientId,
                RequiredQuantity = ingredient.RecipeIngredientQuantity
            });
        }
        _shoppingListsRepository.SaveShoppingList(databaseShoppingList);
        return shoppingList;
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

    // {
    //     recipeID,
    //     ingredientID,
    //     ingredientName
    //     quantity,
    //     category
    // }
    // private Dictionary<int, RecipeIngredientDTO> GetRecipeIngredientsListAsDictionary(
    //     List<RecipeIngredientDTO> recipeIngredients)
    // {
    //     Dictionary<int, RecipeIngredientDTO> recipeIngredient
    // }
}
