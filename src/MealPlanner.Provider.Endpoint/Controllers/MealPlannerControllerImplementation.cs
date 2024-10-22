using System.Net;
using MealPlanner.Provider.Endpoint.Models;
using MealPlanner.Provider.Endpoint.Models.Enums;
using MealPlanner.Provider.Endpoint.Services.Interfaces;
using MealPlanner.Provider.Persistence.Models;
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
    [Route("recipes")]
    public HttpStatusCode AddRecipe([FromBody] AddRecipeRequest request)
    {
        // TODO: validation?!
        
        _mealPlannerService.AddRecipe(request);
        return HttpStatusCode.Created;
    }

    [HttpPost]
    [Route("shopping-list")]
    public List<RecipeIngredientDTO> GetShoppingList([FromBody] ShoppingListRequest request)
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
    public HttpStatusCode AddUserIngredients([FromBody] AddUserIngredientsRequest request)
    {
        _mealPlannerService.AddUserIngredients(request);
        return HttpStatusCode.Created;
    }
    
    [HttpPost]
    [Route("ingredients")]
    public IActionResult AddIngredient([FromBody] AddIngredientRequest request)
    {
        if (request is { Unit: DatabaseMeasurementUnit.gm, GramsPerCup: null })
        {
            var response = "If ingredient is in grams, please specify the number of grams in a cup";
            return BadRequest(response);
        }

        if (request.CategoryId == 0)
        {
            var response = "Category Id must be specified";
            return BadRequest(response);
        }
        
        _mealPlannerService.AddIngredients(request);
        return StatusCode((int)HttpStatusCode.Created);
    }
}