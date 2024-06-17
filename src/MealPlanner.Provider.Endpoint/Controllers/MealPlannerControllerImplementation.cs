using System.Net;
using MealPlanner.Provider.Endpoint.Models;
using MealPlanner.Provider.Endpoint.Models.DTOs;
using MealPlanner.Provider.Endpoint.Services.Interfaces;
using MealPlanner.Provider.Persistence.Models;
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
    [Route("meals")]
    public List<Meal> GetAllMeals()
    {
        return _mealPlannerService.GetAllMeals();
    }
    
    [HttpGet]
    [Route("meals/{mealName}")]
    public List<MealIngredients> GetMeal(string mealName)
    {
        return _mealPlannerService.GetMealIngredients(mealName);
    }

    [HttpPost]
    [Route("meals")]
    public List<RequiredIngredient> GetIngredientsList([FromBody] GetIngredientsListRequest request)
    {
        return _mealPlannerService.GetIngredientsList(request.MealNames);
    }

    [HttpPost]
    [Route("meals/add")]
    public HttpStatusCode AddMeal([FromBody] AddMealRequest request)
    {
        
        // 1. Add meal in to the meal table

            // TODO: if the meal already exists, return bad request 
            
        // 2. Get all the ingredients from the database that contain the ingredients in the request
        
        // 3. Loop through each ingredient in the request
        
            // if ingredient is not in the list returned from the database
                    
                // add the ingredient into the database
            
            // add the mealIngredient into the mealIngredients table
            
        return HttpStatusCode.Created;
    }
    
    [HttpGet]
    [Route("ingredients")]
    public List<Ingredient> GetAllIngredients()
    {
        return _mealPlannerService.GetAllIngredients();
    }

    [HttpPost]
    [Route("ingredients")]
    public HttpStatusCode AddIngredient([FromBody] AddIngredientRequest request)
    {
        _mealPlannerService.AddIngredient(request);
        return HttpStatusCode.Created;
    }
}