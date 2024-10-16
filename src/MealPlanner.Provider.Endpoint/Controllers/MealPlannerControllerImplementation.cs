using System.Net;
using MealPlanner.Provider.Endpoint.Models;
using MealPlanner.Provider.Endpoint.Services.Interfaces;
using MealPlanner.Provider.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Provider.Endpoint.Controllers;

[ApiController]
[Route("api/")]
public class MealPlannerControllerImplementation : ControllerBase
{
    private readonly IMealPlannerService _mealPlannerService;
    public MealPlannerControllerImplementation(IMealPlannerService mealPlannerService)
    {
        _mealPlannerService = mealPlannerService;
    }

    [HttpGet]
    [Route("recipes")]
    public List<RecipeDTO> GetAllRecipes()
    {
        return _mealPlannerService.GetAllRecipes();
    }

    [HttpPost]
    [Route("shopping-list")]
    public List<RecipeIngredientDTO> GetShoppingList(HttpContext context, [FromBody] ShoppingListRequest request)
    {
        return _mealPlannerService.GetShoppingList(request);
    }
    
    [HttpGet]
    [Route("ingredients/all")]
    public List<IngredientWithCategoryDTO> GetAllIngredients()
    {
        return _mealPlannerService.GetAllIngredients();
    }
    
    [HttpGet]
    [Route("ingredients/user")]
    public List<UserIngredientInfoDTO> GetUserIngredients([FromQuery] int userId)
    {
        
        return _mealPlannerService.GetUserIngredientsAndIngredientInfo(userId);
    }

    [HttpPost]
    [Route("ingredients/user")]
    public HttpStatusCode AddUserIngredients([FromBody] AddUserIngredientsRequest requests)
    {
        _mealPlannerService.AddUserIngredients(requests);
        return HttpStatusCode.Created;
    }
}