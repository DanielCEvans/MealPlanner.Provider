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
    public List<UserIngredientInfoDTO> GetUserIngredientsAndIngredientInfo(int userId)
    {
        return _userIngredientRepository.GetUserIngredientsAndIngredientInfo(userId);
    }

    public void AddUserIngredients(AddUserIngredientsRequest addUserIngredientsRequest)
    {
        // At the moment, the application will come preconfigured with a host of regular ingredients
        // This endpoint/method is meant for when a user has gone shopping and is needing to update their ingredient inventory
        
        // The logic here is stating:
        // Get all the user ingredients currently in 'fridge', for each ingredient in the request, check if it is in the 
        // fridge already, if so, update the quantity, else, add this ingredient to the database (unsure if this is
        // best practice/ how this will work in the frontend)
        
        var userId = addUserIngredientsRequest.UserId;
        var userIngredients = _userIngredientRepository.GetUserIngredients(userId);
        var userIngredientsDict = userIngredients.ToDictionary(i => i.IngredientId);

        var newIngredients = new List<UserIngredient>();
        foreach (var ingredient in addUserIngredientsRequest.Ingredients)
        {
            var ingredientId = ingredient.IngredientID;
            if (userIngredientsDict.ContainsKey(ingredientId))
            {
                userIngredientsDict[ingredientId].Quantity += ingredient.Quantity;
            }
            else
            {
                newIngredients.Add(new UserIngredient
                {
                    IngredientId = ingredient.IngredientID,
                    UserId = userId,
                    Quantity = ingredient.Quantity
                });
            }
        }
        
        _userIngredientRepository.AddUserIngredients(newIngredients);
        _userIngredientRepository.UpdateUserIngredients(userIngredientsDict.Values.ToList());
    }

    public List<RecipeIngredientDTO> GetShoppingList(ShoppingListRequest request)
    {
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
        
        // we know a user cannot have multiple of the same ingredients in the 'fridge' at once
        var userIngredients = _userIngredientRepository.GetUserIngredients(request.UserId);
        var userIngredientsDict = userIngredients.ToDictionary(i => i.IngredientId);
        
        // for each ingredient in the recipe ingredients, it is assumed that the ingredient will be consumed
        // therefore, even if the recipe ingredient is not required and doesn't make it onto the list, the amount of the ingredient
        // in the userIngredients table needs to be updated.
        foreach (var recipeIngredient in recipeIngredientsDictionary)
        {
            int ingredientId = recipeIngredient.Key;
            if (userIngredientsDict.ContainsKey(ingredientId))
            {
                recipeIngredient.Value.RecipeIngredientQuantity -=
                    userIngredientsDict[ingredientId].Quantity;

                userIngredientsDict[ingredientId].Quantity -=
                    recipeIngredient.Value.RecipeIngredientQuantity;
            }
        }
        
        List<RecipeIngredientDTO> shoppingList = new List<RecipeIngredientDTO>();
        var databaseShoppingList = new ShoppingList
        {
            GeneratedDate = DateTime.UtcNow,
            UserId = request.UserId,
            ShoppingListItems = new List<ShoppingListItem>(),
        };
        
        foreach (var ingredient in recipeIngredientsDictionary.Values)
        {
            if (ingredient.RecipeIngredientQuantity > 0)
            {
                shoppingList.Add(ingredient);
                databaseShoppingList.ShoppingListItems.Add(new ShoppingListItem
                {
                    IngredientId = ingredient.IngredientId,
                    RequiredQuantity = ingredient.RecipeIngredientQuantity
                });
            }
        }
        _shoppingListsRepository.SaveShoppingList(databaseShoppingList);
        
        // Do I need to update the userIngredients table at this point?
        // Or should i wait until the user has confirmed they have cooked the recipes?
        return shoppingList;
    }
}
